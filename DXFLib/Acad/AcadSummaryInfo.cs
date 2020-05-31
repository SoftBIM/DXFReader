using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using Microsoft.VisualBasic;

namespace DXFLib.Acad
{
	public class AcadSummaryInfo : NodeObject
	{
		private const string cstrClassName = "AcadApplication";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private string mstrAuthor;

		private string mstrComments;

		private string mstrHyperlinkBase;

		private string mstrKeywords;

		private string mstrLastSavedBy;

		private string mstrRevisionNumber;

		private string mstrSubject;

		private string mstrTitle;

		private AcadSummaryInfoFields mobjAcadSummaryInfoFields;

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				mobjAcadSummaryInfoFields.FriendLetDocumentIndex = mlngDocumentIndex;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				mobjAcadSummaryInfoFields.FriendLetApplicationIndex = mlngApplicationIndex;
			}
		}

		internal AcadDocument FriendGetDocument
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.FriendGetItem(mlngApplicationIndex).Documents.FriendGetItem(mlngDocumentIndex);
				}
				AcadDocument FriendGetDocument = default(AcadDocument);
				return FriendGetDocument;
			}
		}

		internal AcadApplication FriendGetApplication
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.FriendGetItem(mlngApplicationIndex);
				}
				AcadApplication FriendGetApplication = default(AcadApplication);
				return FriendGetApplication;
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
			}
		}

		public AcadSummaryInfoFields Fields => mobjAcadSummaryInfoFields;

		internal string FriendLetLastSavedBy
		{
			set
			{
				mstrLastSavedBy = value;
			}
		}

		internal string FriendLetRevisionNumber
		{
			set
			{
				mstrRevisionNumber = value;
			}
		}

		public string Author
		{
			get
			{
				return mstrAuthor;
			}
			set
			{
				mstrAuthor = value;
			}
		}

		public string Comments
		{
			get
			{
				return mstrComments;
			}
			set
			{
				mstrComments = value;
			}
		}

		public string HyperlinkBase
		{
			get
			{
				return mstrHyperlinkBase;
			}
			set
			{
				mstrHyperlinkBase = value;
			}
		}

		public string Keywords
		{
			get
			{
				return mstrKeywords;
			}
			set
			{
				mstrKeywords = value;
			}
		}

		public string LastSavedBy => mstrLastSavedBy;

		public string RevisionNumber => mstrRevisionNumber;

		public string Subject
		{
			get
			{
				return mstrSubject;
			}
			set
			{
				mstrSubject = value;
			}
		}

		public string Title
		{
			get
			{
				return mstrTitle;
			}
			set
			{
				mstrTitle = value;
			}
		}

		public AcadSummaryInfo()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 293;
			base.FriendLetNodeImageDisabledID = 294;
			base.FriendLetNodeName = "Datei-Info";
			base.FriendLetNodeText = "Datei-Info";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mobjAcadSummaryInfoFields = new AcadSummaryInfoFields();
			mobjAcadSummaryInfoFields.FriendLetNodeParentID = base.NodeID;
			mobjAcadSummaryInfoFields.FriendLetApplicationIndex = FriendGetApplicationIndex;
			mobjAcadSummaryInfoFields.FriendLetDocumentIndex = FriendGetDocumentIndex;
		}

		internal void FriendReset()
		{
			mstrAuthor = null;
			mstrComments = null;
			mstrHyperlinkBase = null;
			mstrKeywords = null;
			mstrLastSavedBy = null;
			mstrRevisionNumber = null;
			mstrSubject = null;
			mstrTitle = null;
			mobjAcadSummaryInfoFields.FriendReset();
		}

		~AcadSummaryInfo()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadSummaryInfoFields.FriendQuit();
				base.FriendQuit();
				mobjAcadSummaryInfoFields = null;
				mblnOpened = false;
			}
		}

		public void AddCustomInfo(string vstrKey, string vstrValue)
		{
			mobjAcadSummaryInfoFields.Add(vstrKey, vstrValue);
		}

		public void GetCustomByIndex(int vlngIndex, ref string rstrKey, ref string rstrValue)
		{
			mobjAcadSummaryInfoFields.GetByIndex(vlngIndex, ref rstrKey, ref rstrValue);
		}

		public void GetCustomByKey(string vstrKey, ref string rstrValue)
		{
			mobjAcadSummaryInfoFields.GetByKey(vstrKey, ref rstrValue);
		}

		public int NumCustomInfo()
		{
			return mobjAcadSummaryInfoFields.Count;
		}

		public void RemoveCustomByIndex(int vlngIndex)
		{
			mobjAcadSummaryInfoFields.RemoveByIndex(vlngIndex);
		}

		public void RemoveCustomByKey(string vstrKey)
		{
			mobjAcadSummaryInfoFields.RemoveByKey(vstrKey);
		}

		public void SetCustomByIndex(int vlngIndex, ref string rstrKey, string vstrValue)
		{
			mobjAcadSummaryInfoFields.SetByIndex(vlngIndex, ref rstrKey, vstrValue);
		}

		public void SetCustomByKey(string vstrKey, string vstrValue)
		{
			mobjAcadSummaryInfoFields.SetByKey(vstrKey, vstrValue);
		}

		public int CustomExistsByIndex(int vlngIndex)
		{
			return 0 - (mobjAcadSummaryInfoFields.ExistsByIndex(vlngIndex) ? 1 : 0);
		}

		public int CustomExistsByKey(string vstrKey)
		{
			return 0 - (mobjAcadSummaryInfoFields.ExistsByKey(vstrKey) ? 1 : 0);
		}
	}

}
