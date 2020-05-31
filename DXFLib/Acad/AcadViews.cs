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
	public class AcadViews : AcadAbstractViews
	{
		private const string cstrClassName = "AcadViews";

		private bool mblnOpened;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadView dobjAcadView2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadView2 = (AcadView)enumerator.Current;
						dobjAcadView2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadView2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadView dobjAcadView2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadView2 = (AcadView)enumerator.Current;
						dobjAcadView2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadView2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadView dobjAcadView2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadView2 = (AcadView)enumerator.Current;
						dobjAcadView2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadView2 = null;
			}
		}

		public AcadViews()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 131;
			base.FriendLetNodeImageDisabledID = 132;
			base.FriendLetNodeName = "Tabelle Ansichten";
			base.FriendLetNodeText = "Tabelle Ansichten";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "VIEW";
			base.FriendLetObjectName = "AcDbViewTable";
			base.FriendLetSubordinateObjectName = "AcDbViewTable";
		}

		internal void FriendInit()
		{
		}

		~AcadViews()
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

		internal AcadView FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadView dobjAcadView4 = new AcadView();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadView acadView = dobjAcadView4;
			acadView.Name = vstrName;
			acadView.FriendLetNodeParentID = base.NodeID;
			acadView.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadView.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadView.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadView.FriendLetOwnerID = base.ObjectID;
			AcadView acadView2 = acadView;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadView4;
			bool flag = acadView2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadView4 = (AcadView)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadView.ObjectName + ": " + nrstrErrMsg);
			}
			acadView = null;
			AcadView FriendAddAcadObject = default(AcadView);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadView4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadView4 = (AcadView)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadView4;
			}
			dobjAcadView4 = null;
			return FriendAddAcadObject;
		}
	}
}
