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
	public class AcadTextStyles : AcadTable
	{
		private const string cstrClassName = "AcadTextStyles";

		private bool mblnOpened;

		private AcadTextStyle mobjAcadTextStyleStandard;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadTextStyle dobjAcadTextStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadTextStyle2 = (AcadTextStyle)enumerator.Current;
						dobjAcadTextStyle2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadTextStyle2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadTextStyle dobjAcadTextStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadTextStyle2 = (AcadTextStyle)enumerator.Current;
						dobjAcadTextStyle2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadTextStyle2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadTextStyle dobjAcadTextStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadTextStyle2 = (AcadTextStyle)enumerator.Current;
						dobjAcadTextStyle2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadTextStyle2 = null;
			}
		}

		public AcadTextStyle TextStyleStandard
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectTextStyleStandard(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadTextStyles()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 127;
			base.FriendLetNodeImageDisabledID = 128;
			base.FriendLetNodeName = "Tabelle Textstile";
			base.FriendLetNodeText = "Tabelle Textstile";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "STYLE";
			base.FriendLetObjectName = "AcDbTextStyleTable";
			base.FriendLetSubordinateObjectName = "AcDbTextStyleTable";
		}

		internal AcadTextStyle FriendAddAcadObjectTextStyleStandard(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadTextStyleStandard == null)
			{
				string dstrTextStyleName = hwpDxf_Vars.pstrTextStyleName;
				mobjAcadTextStyleStandard = (AcadTextStyle)FriendGetItem(dstrTextStyleName);
				if (mobjAcadTextStyleStandard == null)
				{
					mobjAcadTextStyleStandard = FriendAddAcadObject(dstrTextStyleName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadTextStyleStandard != null)
					{
						AcadTextStyle acadTextStyle = mobjAcadTextStyleStandard;
						acadTextStyle.LastHeight = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0.2m, 0.2));
						acadTextStyle.FontFile = "txt";
						acadTextStyle = null;
					}
				}
			}
			return mobjAcadTextStyleStandard;
		}

		~AcadTextStyles()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadTextStyleStandard = null;
				mblnOpened = false;
			}
		}

		internal AcadTextStyle FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadTextStyle dobjAcadTextStyle4 = new AcadTextStyle();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadTextStyle acadTextStyle = dobjAcadTextStyle4;
			acadTextStyle.Name = vstrName;
			acadTextStyle.FriendLetNodeParentID = base.NodeID;
			acadTextStyle.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadTextStyle.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadTextStyle.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadTextStyle.FriendLetOwnerID = base.ObjectID;
			AcadTextStyle acadTextStyle2 = acadTextStyle;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadTextStyle4;
			bool flag = acadTextStyle2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadTextStyle4 = (AcadTextStyle)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadTextStyle.ObjectName + ": " + nrstrErrMsg);
			}
			acadTextStyle = null;
			AcadTextStyle FriendAddAcadObject = default(AcadTextStyle);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadTextStyle4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadTextStyle4 = (AcadTextStyle)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadTextStyle4;
			}
			dobjAcadTextStyle4 = null;
			return FriendAddAcadObject;
		}
	}
}
