using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadGroups : AcadDictionary
	{
		private const string cstrClassName = "AcadGroups";

		private bool mblnOpened;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadGroup dobjAcadGroup2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadGroup2 = (AcadGroup)enumerator.Current;
						dobjAcadGroup2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadGroup2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadGroup dobjAcadGroup2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadGroup2 = (AcadGroup)enumerator.Current;
						dobjAcadGroup2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadGroup2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadGroup dobjAcadGroup2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadGroup2 = (AcadGroup)enumerator.Current;
						dobjAcadGroup2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadGroup2 = null;
			}
		}

		public AcadGroups()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 209;
			base.FriendLetNodeImageDisabledID = 210;
			base.FriendLetNodeName = "Wörterbuch Gruppen";
			base.FriendLetNodeText = "Wörterbuch Gruppen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_GROUP";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbGroups";
		}

		~AcadGroups()
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

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadGroup Add(string vstrName, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : (-1.0);
			string dstrErrMsg = default(string);
			AcadGroup dobjAcadGroup2 = FriendAddAcadObject(vstrName, ddblObjectID, ref dstrErrMsg);
			AcadGroup Add = default(AcadGroup);
			if (dobjAcadGroup2 == null)
			{
				Information.Err().Raise(50000, "AcadGroups", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				Add = dobjAcadGroup2;
			}
			dobjAcadGroup2 = null;
			return Add;
		}

		internal AcadGroup FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadGroup dobjAcadGroup3 = new AcadGroup();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadGroup acadGroup = dobjAcadGroup3;
			acadGroup.Name = vstrName;
			acadGroup.FriendLetNodeParentID = base.NodeID;
			acadGroup.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadGroup.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadGroup.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadGroup.FriendLetOwnerID = base.ObjectID;
			AcadGroup acadGroup2 = acadGroup;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadGroup3;
			bool flag = acadGroup2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadGroup3 = (AcadGroup)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadGroup.ObjectName + ": " + nrstrErrMsg);
			}
			acadGroup = null;
			AcadGroup FriendAddAcadObject = default(AcadGroup);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadGroup3))
			{
				FriendAddAcadObject = dobjAcadGroup3;
			}
			dobjAcadGroup3 = null;
			return FriendAddAcadObject;
		}
	}

}
