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
	public class AcadLayouts : AcadDictionary
	{
		private const string cstrClassName = "AcadLayouts";

		private bool mblnOpened;

		private AcadLayout mobjAcadLayout1;

		private AcadLayout mobjAcadLayoutModel;

		private AcadLayout mobjAcadLayout2;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayout dobjAcadLayout2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayout2 = (AcadLayout)enumerator.Current;
						dobjAcadLayout2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayout2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayout dobjAcadLayout2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayout2 = (AcadLayout)enumerator.Current;
						dobjAcadLayout2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayout2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayout dobjAcadLayout2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayout2 = (AcadLayout)enumerator.Current;
						dobjAcadLayout2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayout2 = null;
			}
		}

		public AcadLayout Layout1
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLayout1(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLayout LayoutModel
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLayoutModel(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLayout Layout2
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLayout2(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLayouts()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 155;
			base.FriendLetNodeImageDisabledID = 156;
			base.FriendLetNodeName = "Wörterbuch Layouts";
			base.FriendLetNodeText = "Wörterbuch Layouts";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_LAYOUT";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbLayouts";
		}

		internal void FriendInit()
		{
		}

		internal AcadLayout FriendAddAcadObjectLayout1(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			object[] dadecExtMin = new object[3];
			double[] dadblExtMin = new double[3];
			object[] dadecExtMax = new object[3];
			double[] dadblExtMax = new double[3];
			if (mobjAcadLayout1 == null)
			{
				string dstrLayoutName = "Layout1";
				mobjAcadLayout1 = (AcadLayout)FriendGetItem(dstrLayoutName);
				if (mobjAcadLayout1 == null)
				{
					mobjAcadLayout1 = FriendAddAcadObject(dstrLayoutName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadLayout1 != null)
					{
						bool flag = false;
						dadblExtMin[0] = 1E+20;
						dadblExtMin[1] = 1E+20;
						dadblExtMin[2] = 1E+20;
						dadblExtMax[0] = -1E+20;
						dadblExtMax[1] = -1E+20;
						dadblExtMax[2] = -1E+20;
						AcadLayout acadLayout = mobjAcadLayout1;
						acadLayout.FriendAddReactorsID(base.ObjectID, 330);
						acadLayout.FriendLetExtMin = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecExtMin, dadblExtMin));
						acadLayout.FriendLetExtMax = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecExtMax, dadblExtMax));
						acadLayout = null;
					}
				}
			}
			return mobjAcadLayout1;
		}

		internal AcadLayout FriendAddAcadObjectLayoutModel(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			object[] dadecExtMin = new object[3];
			double[] dadblExtMin = new double[3];
			object[] dadecExtMax = new object[3];
			double[] dadblExtMax = new double[3];
			if (mobjAcadLayoutModel == null)
			{
				string dstrLayoutName = "Model";
				mobjAcadLayoutModel = (AcadLayout)FriendGetItem(dstrLayoutName);
				if (mobjAcadLayoutModel == null)
				{
					mobjAcadLayoutModel = FriendAddAcadObject(dstrLayoutName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadLayoutModel != null)
					{
						bool flag = false;
						dadblExtMin[0] = 1E+20;
						dadblExtMin[1] = 1E+20;
						dadblExtMin[2] = 1E+20;
						dadblExtMax[0] = -1E+20;
						dadblExtMax[1] = -1E+20;
						dadblExtMax[2] = -1E+20;
						AcadLayout acadLayout = mobjAcadLayoutModel;
						acadLayout.FriendLetModelType = true;
						acadLayout.PlotType = Enums.AcPlotType.acDisplay;
						acadLayout.StandardScale = Enums.AcPlotScale.acScaleToFit;
						acadLayout.FriendAddReactorsID(base.ObjectID, 330);
						acadLayout = null;
					}
				}
			}
			return mobjAcadLayoutModel;
		}

		internal AcadLayout FriendAddAcadObjectLayout2(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			object[] dadecExtMin = new object[3];
			double[] dadblExtMin = new double[3];
			object[] dadecExtMax = new object[3];
			double[] dadblExtMax = new double[3];
			if (mobjAcadLayout2 == null)
			{
				string dstrLayoutName = "Layout2";
				mobjAcadLayout2 = (AcadLayout)FriendGetItem(dstrLayoutName);
				if (mobjAcadLayout2 == null)
				{
					mobjAcadLayout2 = FriendAddAcadObject(dstrLayoutName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadLayout2 != null)
					{
						bool flag = false;
						dadblExtMin[0] = 1E+20;
						dadblExtMin[1] = 1E+20;
						dadblExtMin[2] = 1E+20;
						dadblExtMax[0] = -1E+20;
						dadblExtMax[1] = -1E+20;
						dadblExtMax[2] = -1E+20;
						AcadLayout acadLayout = mobjAcadLayout2;
						acadLayout.FriendAddReactorsID(base.ObjectID, 330);
						acadLayout = null;
					}
				}
			}
			return mobjAcadLayout2;
		}

		~AcadLayouts()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadLayout1 = null;
				mobjAcadLayoutModel = null;
				mobjAcadLayout2 = null;
				mblnOpened = false;
			}
		}

		internal AcadLayout FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadLayout dobjAcadLayout3 = new AcadLayout();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadLayout acadLayout = dobjAcadLayout3;
			acadLayout.Name = vstrName;
			acadLayout.FriendLetNodeParentID = base.NodeID;
			acadLayout.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLayout.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLayout.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLayout.FriendLetOwnerID = base.ObjectID;
			AcadLayout acadLayout2 = acadLayout;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadLayout3;
			bool flag = acadLayout2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLayout3 = (AcadLayout)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLayout.ObjectName + ": " + nrstrErrMsg);
			}
			acadLayout = null;
			AcadLayout FriendAddAcadObject = default(AcadLayout);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadLayout3))
			{
				FriendAddAcadObject = dobjAcadLayout3;
			}
			dobjAcadLayout3 = null;
			return FriendAddAcadObject;
		}
	}

}
