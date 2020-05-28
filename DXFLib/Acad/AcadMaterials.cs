using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadMaterials : AcadDictionary
	{
		private const string cstrClassName = "AcadMaterials";

		private bool mblnOpened;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMaterial dobjAcadMaterial2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMaterial2 = (AcadMaterial)enumerator.Current;
						dobjAcadMaterial2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMaterial2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMaterial dobjAcadMaterial2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMaterial2 = (AcadMaterial)enumerator.Current;
						dobjAcadMaterial2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMaterial2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMaterial dobjAcadMaterial2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMaterial2 = (AcadMaterial)enumerator.Current;
						dobjAcadMaterial2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMaterial2 = null;
			}
		}

		public AcadMaterials()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 299;
			base.FriendLetNodeImageDisabledID = 300;
			base.FriendLetNodeName = "Wörterbuch Materialien";
			base.FriendLetNodeText = "Wörterbuch Materialien";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_MATERIAL";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbMaterials";
		}

		~AcadMaterials()
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

		internal AcadMaterial FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadMaterial dobjAcadMaterial3 = new AcadMaterial();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadMaterial acadMaterial = dobjAcadMaterial3;
			acadMaterial.Name = vstrName;
			acadMaterial.FriendLetNodeParentID = base.NodeID;
			acadMaterial.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadMaterial.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadMaterial.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadMaterial.FriendLetOwnerID = base.ObjectID;
			AcadMaterial acadMaterial2 = acadMaterial;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadMaterial3;
			bool flag = acadMaterial2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadMaterial3 = (AcadMaterial)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadMaterial.ObjectName + ": " + nrstrErrMsg);
			}
			acadMaterial = null;
			AcadMaterial FriendAddAcadObject = default(AcadMaterial);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadMaterial3))
			{
				FriendAddAcadObject = dobjAcadMaterial3;
			}
			dobjAcadMaterial3 = null;
			return FriendAddAcadObject;
		}
	}

}
