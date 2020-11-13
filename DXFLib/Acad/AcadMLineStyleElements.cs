using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Collections.Specialized;

namespace DXFLib.Acad
{
    public class AcadMLineStyleElements : NodeObject
	{
		private const string cstrClassName = "AcadMLineStyleElements";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private OrderedDictionary mcolClass;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				IEnumerator<AcadMLineStyleElement> enumerator = default(IEnumerator<AcadMLineStyleElement>);
				AcadMLineStyleElement dobjAcadMLineStyleElement2;
				try
				{
					enumerator = (IEnumerator<AcadMLineStyleElement>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyleElement2 = (AcadMLineStyleElement)enumerator.Current;
						dobjAcadMLineStyleElement2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyleElement2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMLineStyleElement dobjAcadMLineStyleElement2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyleElement2 = (AcadMLineStyleElement)enumerator.Current;
						dobjAcadMLineStyleElement2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyleElement2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMLineStyleElement dobjAcadMLineStyleElement2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyleElement2 = (AcadMLineStyleElement)enumerator.Current;
						dobjAcadMLineStyleElement2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyleElement2 = null;
			}
		}

		public AcadDatabase Database
		{
			get
			{
				if (mlngDatabaseIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex);
				}
				AcadDatabase Database = default(AcadDatabase);
				return Database;
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

		public int Count => mcolClass.Count;

		public AcadMLineStyleElements()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 219;
			base.FriendLetNodeImageDisabledID = 220;
			base.FriendLetNodeName = "Multilinien-Stil-Elemente";
			base.FriendLetNodeText = "Multilinien-Stil-Elemente";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadMLineStyleElements()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				base.FriendQuit();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadMLineStyleElements");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadMLineStyleElement dobjAcadMLineStyleElement2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadMLineStyleElement2 = (AcadMLineStyleElement)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadMLineStyleElement2.Index));
					dobjAcadMLineStyleElement2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngIndex = -1;
			dobjAcadMLineStyleElement2 = null;
		}

		public ICollection<AcadMLineStyleElement> GetValues()
		{
			return (ICollection<AcadMLineStyleElement>)mcolClass.Values;
		}

		internal AcadMLineStyleElement FriendAdd(object vvarOffset, Enums.AcColor vnumColor, string vstrLinetype, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			checked
			{
				mlngIndex++;
				AcadMLineStyleElement dobjAcadMLineStyleElement2 = new AcadMLineStyleElement();
				dobjAcadMLineStyleElement2.FriendLetNodeParentID = base.NodeID;
				dobjAcadMLineStyleElement2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadMLineStyleElement2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadMLineStyleElement2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				dobjAcadMLineStyleElement2.FriendLetIndex = mlngIndex;
				dobjAcadMLineStyleElement2.Offset = RuntimeHelpers.GetObjectValue(vvarOffset);
				dobjAcadMLineStyleElement2.Color = vnumColor;
				dobjAcadMLineStyleElement2.Linetype = vstrLinetype;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadMLineStyleElement2);
				AcadMLineStyleElement FriendAdd = dobjAcadMLineStyleElement2;
				dobjAcadMLineStyleElement2 = null;
				return FriendAdd;
			}
		}

		internal void FriendClear()
		{
			InternClear();
		}

		public AcadMLineStyleElement Item(int vlngIndex)
		{
			return (AcadMLineStyleElement)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}

}
