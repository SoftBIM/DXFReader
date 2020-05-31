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
	public class AcadSummaryInfoField : NodeObject
	{
		private const string cstrClassName = "AcadSummaryInfoField";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngIndex;

		private string mstrKey;

		private string mstrValue;

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
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

		public AcadApplication Application
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		internal int FriendLetIndex
		{
			set
			{
				mlngIndex = value;
			}
		}

		internal string FriendLetKey
		{
			set
			{
				mstrKey = value;
			}
		}

		public int Index => mlngIndex;

		public string Key => mstrKey;

		public string Value
		{
			get
			{
				return mstrValue;
			}
			set
			{
				mstrValue = value;
			}
		}

		public AcadSummaryInfoField()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 297;
			base.FriendLetNodeImageDisabledID = 298;
			base.FriendLetNodeName = "Datei-Infofeld";
			base.FriendLetNodeText = "Datei-Infofeld";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
		}

		~AcadSummaryInfoField()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}
	}

}
