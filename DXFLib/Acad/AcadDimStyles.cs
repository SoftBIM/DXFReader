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
	public class AcadDimStyles : AcadTable
	{
		private const string cstrClassName = "AcadDimStyles";

		private bool mblnOpened;

		private int mlngUnknown71;

		private Dictionary<object, object> mobjDictUnknown340;

		private AcadDimStyle mobjAcadDimStyleDefault;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDimStyle dobjAcadDimStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDimStyle2 = (AcadDimStyle)enumerator.Current;
						dobjAcadDimStyle2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDimStyle2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDimStyle dobjAcadDimStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDimStyle2 = (AcadDimStyle)enumerator.Current;
						dobjAcadDimStyle2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDimStyle2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDimStyle dobjAcadDimStyle2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDimStyle2 = (AcadDimStyle)enumerator.Current;
						dobjAcadDimStyle2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDimStyle2 = null;
			}
		}

		internal int FriendGetUnknown71 => mlngUnknown71;

		internal int FriendLetUnknown71
		{
			set
			{
				mlngUnknown71 = value;
			}
		}

		internal Dictionary<object, object> FriendGetDictUnknown340 => mobjDictUnknown340;

		internal Dictionary<object, object> FriendSetDictUnknown340
		{
			set
			{
				if (value.Count == 0)
				{
					mobjDictUnknown340 = null;
				}
				else
				{
					mobjDictUnknown340 = value;
				}
			}
		}

		public AcadDimStyle DimStyleDefault
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectDimStyleDefault(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadDimStyles()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 135;
			base.FriendLetNodeImageDisabledID = 136;
			base.FriendLetNodeName = "Tabelle Bemassungsstile";
			base.FriendLetNodeText = "Tabelle Bemassungsstile";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "DIMSTYLE";
			base.FriendLetObjectName = "AcDbDimStyleTable";
			base.FriendLetSubordinateObjectName = "AcDbDimStyleTable";
		}

		internal AcadDimStyle FriendAddAcadObjectDimStyleDefault(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadDimStyleDefault == null)
			{
				string dstrDimStyleName = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(base.Application.FriendGetVariable("MEASUREINIT"), 0, TextCompare: false), "ISO-25", "Standard"));
				mobjAcadDimStyleDefault = (AcadDimStyle)FriendGetItem(dstrDimStyleName);
				if (mobjAcadDimStyleDefault == null)
				{
					mobjAcadDimStyleDefault = FriendAddAcadObject(dstrDimStyleName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
				}
			}
			return mobjAcadDimStyleDefault;
		}

		~AcadDimStyles()
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

		internal AcadDimStyle FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadDimStyle dobjAcadDimStyle4 = new AcadDimStyle();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadDimStyle acadDimStyle = dobjAcadDimStyle4;
			acadDimStyle.Name = vstrName;
			acadDimStyle.FriendLetNodeParentID = base.NodeID;
			acadDimStyle.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadDimStyle.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadDimStyle.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadDimStyle.FriendLetOwnerID = base.ObjectID;
			AcadDimStyle acadDimStyle2 = acadDimStyle;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadDimStyle4;
			bool flag = acadDimStyle2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadDimStyle4 = (AcadDimStyle)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadDimStyle.ObjectName + ": " + nrstrErrMsg);
			}
			acadDimStyle = null;
			AcadDimStyle FriendAddAcadObject = default(AcadDimStyle);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadDimStyle4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadDimStyle4 = (AcadDimStyle)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadDimStyle4;
			}
			dobjAcadDimStyle4 = null;
			return FriendAddAcadObject;
		}
	}
}
