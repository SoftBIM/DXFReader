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
	public class AcadMLineStyles : AcadDictionary
	{
		private const string cstrClassName = "AcadMLineStyles";

		private bool mblnOpened;

		private AcadMLineStyle mobjAcadMLineStyleStandard;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMLineStyle dobjAcadMLineStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyle2 = (AcadMLineStyle)enumerator.Current;
						dobjAcadMLineStyle2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyle2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMLineStyle dobjAcadMLineStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyle2 = (AcadMLineStyle)enumerator.Current;
						dobjAcadMLineStyle2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyle2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadMLineStyle dobjAcadMLineStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadMLineStyle2 = (AcadMLineStyle)enumerator.Current;
						dobjAcadMLineStyle2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadMLineStyle2 = null;
			}
		}

		public AcadMLineStyle MLineStyleStandard
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectMLineStyleStandard(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadMLineStyles()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 215;
			base.FriendLetNodeImageDisabledID = 216;
			base.FriendLetNodeName = "Wörterbuch Multilinien-Stile";
			base.FriendLetNodeText = "Wörterbuch Multilinien-Stile";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_MLINESTYLE";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbMlineStyles";
		}

		internal AcadMLineStyle FriendAddAcadObjectMLineStyleStandard(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadMLineStyleStandard == null)
			{
				string dstrMLineStyleName = "Standard";
				mobjAcadMLineStyleStandard = (AcadMLineStyle)FriendGetItem(dstrMLineStyleName);
				if (mobjAcadMLineStyleStandard == null)
				{
					mobjAcadMLineStyleStandard = FriendAddAcadObject(dstrMLineStyleName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadMLineStyleStandard != null)
					{
						mobjAcadMLineStyleStandard.FriendAddReactorsID(base.ObjectID, 330);
						AcadMLineStyleElements elements = mobjAcadMLineStyleStandard.Elements;
						AcadMLineStyleElements acadMLineStyleElements = elements;
						object objectValue = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0.5m, 0.5));
						Enums.AcColor pnumEntityColor = hwpDxf_Vars.pnumEntityColor;
						string pstrEntityLinetype = hwpDxf_Vars.pstrEntityLinetype;
						string nrstrErrMsg2 = "";
						acadMLineStyleElements.FriendAdd(objectValue, pnumEntityColor, pstrEntityLinetype, ref nrstrErrMsg2);
						AcadMLineStyleElements acadMLineStyleElements2 = elements;
						object objectValue2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, -0.5m, -0.5));
						Enums.AcColor pnumEntityColor2 = hwpDxf_Vars.pnumEntityColor;
						string pstrEntityLinetype2 = hwpDxf_Vars.pstrEntityLinetype;
						nrstrErrMsg2 = "";
						acadMLineStyleElements2.FriendAdd(objectValue2, pnumEntityColor2, pstrEntityLinetype2, ref nrstrErrMsg2);
						elements = null;
					}
				}
			}
			return mobjAcadMLineStyleStandard;
		}

		~AcadMLineStyles()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadMLineStyleStandard = null;
				mblnOpened = false;
			}
		}

		internal AcadMLineStyle FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadMLineStyle dobjAcadMLineStyle3 = new AcadMLineStyle();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadMLineStyle acadMLineStyle = dobjAcadMLineStyle3;
			acadMLineStyle.Name = vstrName;
			acadMLineStyle.FriendLetNodeParentID = base.NodeID;
			acadMLineStyle.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadMLineStyle.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadMLineStyle.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadMLineStyle.FriendLetOwnerID = base.ObjectID;
			AcadMLineStyle acadMLineStyle2 = acadMLineStyle;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadMLineStyle3;
			bool flag = acadMLineStyle2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadMLineStyle3 = (AcadMLineStyle)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadMLineStyle.ObjectName + ": " + nrstrErrMsg);
			}
			acadMLineStyle = null;
			AcadMLineStyle FriendAddAcadObject = default(AcadMLineStyle);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadMLineStyle3))
			{
				FriendAddAcadObject = dobjAcadMLineStyle3;
			}
			dobjAcadMLineStyle3 = null;
			return FriendAddAcadObject;
		}
	}
}
