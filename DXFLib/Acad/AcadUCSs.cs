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
	public class AcadUCSs : AcadTable
	{
		private const string cstrClassName = "AcadUCSs";

		private bool mblnOpened;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadUCS dobjAcadUCS2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadUCS2 = (AcadUCS)enumerator.Current;
						dobjAcadUCS2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadUCS2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadUCS dobjAcadUCS2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadUCS2 = (AcadUCS)enumerator.Current;
						dobjAcadUCS2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadUCS2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadUCS dobjAcadUCS2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadUCS2 = (AcadUCS)enumerator.Current;
						dobjAcadUCS2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadUCS2 = null;
			}
		}

		public AcadUCSs()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 139;
			base.FriendLetNodeImageDisabledID = 140;
			base.FriendLetNodeName = "Tabelle Benutzerkoordinatensysteme";
			base.FriendLetNodeText = "Tabelle Benutzerkoordinatensysteme";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "UCS";
			base.FriendLetObjectName = "AcDbUCSTable";
			base.FriendLetSubordinateObjectName = "AcDbUCSTable";
		}

		internal void FriendInit()
		{
		}

		~AcadUCSs()
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

		internal AcadUCS FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadUCS dobjAcadUCS4 = new AcadUCS();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadUCS acadUCS = dobjAcadUCS4;
			acadUCS.Name = vstrName;
			acadUCS.FriendLetNodeParentID = base.NodeID;
			acadUCS.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadUCS.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadUCS.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadUCS.FriendLetOwnerID = base.ObjectID;
			AcadUCS acadUCS2 = acadUCS;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadUCS4;
			bool flag = acadUCS2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadUCS4 = (AcadUCS)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadUCS.ObjectName + ": " + nrstrErrMsg);
			}
			acadUCS = null;
			AcadUCS FriendAddAcadObject = default(AcadUCS);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadUCS4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadUCS4 = (AcadUCS)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadUCS4;
			}
			dobjAcadUCS4 = null;
			return FriendAddAcadObject;
		}
	}

}
