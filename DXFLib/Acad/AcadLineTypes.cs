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
	public class AcadLineTypes : AcadTable
	{
		private const string cstrClassName = "AcadLineTypes";

		private bool mblnOpened;

		private AcadLineType mobjAcadLineTypeByBlock;

		private AcadLineType mobjAcadLineTypeByLayer;

		private AcadLineType mobjAcadLineTypeContinuous;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineType dobjAcadLinetype2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLinetype2 = (AcadLineType)enumerator.Current;
						dobjAcadLinetype2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLinetype2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineType dobjAcadLinetype2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLinetype2 = (AcadLineType)enumerator.Current;
						dobjAcadLinetype2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLinetype2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineType dobjAcadLinetype2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLinetype2 = (AcadLineType)enumerator.Current;
						dobjAcadLinetype2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLinetype2 = null;
			}
		}

		public AcadLineType LineTypeByBlock
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLineTypeByBlock(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLineType LineTypeByLayer
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLineTypeByLayer(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLineType LineTypeContinuous
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLineTypeContinuous(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLineTypes()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 119;
			base.FriendLetNodeImageDisabledID = 120;
			base.FriendLetNodeName = "Tabelle Linientypen";
			base.FriendLetNodeText = "Tabelle Linientypen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "LTYPE";
			base.FriendLetObjectName = "AcDbLinetypeTable";
			base.FriendLetSubordinateObjectName = "AcDbLinetypeTable";
		}

		internal AcadLineType FriendAddAcadObjectLineTypeByBlock(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLineTypeByBlock == null)
			{
				string dstrLineTypeName = "ByBlock";
				mobjAcadLineTypeByBlock = (AcadLineType)FriendGetItem(dstrLineTypeName);
				if (mobjAcadLineTypeByBlock == null)
				{
					mobjAcadLineTypeByBlock = FriendAddAcadObject(dstrLineTypeName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
				}
			}
			return mobjAcadLineTypeByBlock;
		}

		internal AcadLineType FriendAddAcadObjectLineTypeByLayer(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLineTypeByLayer == null)
			{
				string dstrLineTypeName = "ByLayer";
				mobjAcadLineTypeByLayer = (AcadLineType)FriendGetItem(dstrLineTypeName);
				if (mobjAcadLineTypeByLayer == null)
				{
					mobjAcadLineTypeByLayer = FriendAddAcadObject(dstrLineTypeName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
				}
			}
			return mobjAcadLineTypeByLayer;
		}

		internal AcadLineType FriendAddAcadObjectLineTypeContinuous(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLineTypeContinuous == null)
			{
				string dstrLineTypeName = "Continuous";
				mobjAcadLineTypeContinuous = (AcadLineType)FriendGetItem(dstrLineTypeName);
				if (mobjAcadLineTypeContinuous == null)
				{
					mobjAcadLineTypeContinuous = FriendAddAcadObject(dstrLineTypeName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
				}
			}
			return mobjAcadLineTypeContinuous;
		}

		~AcadLineTypes()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadLineTypeByBlock = null;
				mobjAcadLineTypeByLayer = null;
				mobjAcadLineTypeContinuous = null;
				mblnOpened = false;
			}
		}

		internal AcadLineType FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadLineType dobjAcadLinetype4 = new AcadLineType();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadLineType acadLineType = dobjAcadLinetype4;
			acadLineType.Name = vstrName;
			acadLineType.FriendLetNodeParentID = base.NodeID;
			acadLineType.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLineType.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLineType.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLineType.FriendLetOwnerID = base.ObjectID;
			AcadLineType acadLineType2 = acadLineType;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadLinetype4;
			bool flag = acadLineType2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLinetype4 = (AcadLineType)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLineType.ObjectName + ": " + nrstrErrMsg);
			}
			acadLineType = null;
			AcadLineType FriendAddAcadObject = default(AcadLineType);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadLinetype4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadLinetype4 = (AcadLineType)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadLinetype4;
			}
			dobjAcadLinetype4 = null;
			return FriendAddAcadObject;
		}

		public void Load(string vstrName, string vstrFileName)
		{
		}
	}

}
