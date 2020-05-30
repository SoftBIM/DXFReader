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
	public class AcadRegisteredApplications : AcadTable
	{
		private const string cstrClassName = "AcadRegisteredApplications";

		private bool mblnOpened;

		private AcadRegisteredApplication mobjAcadRegisteredApplicationAcad;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadRegisteredApplication dobjAcadRegisteredApplication2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)enumerator.Current;
						dobjAcadRegisteredApplication2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadRegisteredApplication2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadRegisteredApplication dobjAcadRegisteredApplication2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)enumerator.Current;
						dobjAcadRegisteredApplication2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadRegisteredApplication2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadRegisteredApplication dobjAcadRegisteredApplication2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)enumerator.Current;
						dobjAcadRegisteredApplication2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadRegisteredApplication2 = null;
			}
		}

		public AcadRegisteredApplication RegisteredApplicationAcad
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectRegisteredApplicationAcad(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadRegisteredApplications()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 143;
			base.FriendLetNodeImageDisabledID = 144;
			base.FriendLetNodeName = "Tabelle Anwendungen";
			base.FriendLetNodeText = "Tabelle Anwendungen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "APPID";
			base.FriendLetObjectName = "AcDbRegAppTable";
			base.FriendLetSubordinateObjectName = "AcDbRegAppTable";
		}

		internal AcadRegisteredApplication FriendAddAcadObjectRegisteredApplicationAcad(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadRegisteredApplicationAcad == null)
			{
				string dstrRegisteredApplicationName = "ACAD";
				mobjAcadRegisteredApplicationAcad = (AcadRegisteredApplication)FriendGetItem(dstrRegisteredApplicationName);
				if (mobjAcadRegisteredApplicationAcad == null)
				{
					mobjAcadRegisteredApplicationAcad = FriendAddAcadObject(dstrRegisteredApplicationName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
				}
			}
			return mobjAcadRegisteredApplicationAcad;
		}

		~AcadRegisteredApplications()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadRegisteredApplicationAcad = null;
				mblnOpened = false;
			}
		}

		internal AcadRegisteredApplication FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadRegisteredApplication dobjAcadRegisteredApplication4 = new AcadRegisteredApplication();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadRegisteredApplication acadRegisteredApplication = dobjAcadRegisteredApplication4;
			acadRegisteredApplication.Name = vstrName;
			acadRegisteredApplication.FriendLetNodeParentID = base.NodeID;
			acadRegisteredApplication.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadRegisteredApplication.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadRegisteredApplication.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadRegisteredApplication.FriendLetOwnerID = base.ObjectID;
			AcadRegisteredApplication acadRegisteredApplication2 = acadRegisteredApplication;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadRegisteredApplication4;
			bool flag = acadRegisteredApplication2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadRegisteredApplication4 = (AcadRegisteredApplication)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadRegisteredApplication.ObjectName + ": " + nrstrErrMsg);
			}
			acadRegisteredApplication = null;
			AcadRegisteredApplication FriendAddAcadObject = default(AcadRegisteredApplication);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadRegisteredApplication4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadRegisteredApplication4 = (AcadRegisteredApplication)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadRegisteredApplication4;
			}
			dobjAcadRegisteredApplication4 = null;
			return FriendAddAcadObject;
		}
	}

}
