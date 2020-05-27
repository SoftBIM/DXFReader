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
	public class AcadLayers : AcadTable
	{
		private const string cstrClassName = "AcadLayers";

		private bool mblnOpened;

		private AcadLayer mobjAcadLayer0;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayer dobjAcadLayer2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayer2 = (AcadLayer)enumerator.Current;
						dobjAcadLayer2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayer2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayer dobjAcadLayer2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayer2 = (AcadLayer)enumerator.Current;
						dobjAcadLayer2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayer2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLayer dobjAcadLayer2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLayer2 = (AcadLayer)enumerator.Current;
						dobjAcadLayer2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLayer2 = null;
			}
		}

		public AcadLayer Layer0
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLayer0(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLayers()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 123;
			base.FriendLetNodeImageDisabledID = 124;
			base.FriendLetNodeName = "Tabelle Layer";
			base.FriendLetNodeText = "Tabelle Layer";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "LAYER";
			base.FriendLetObjectName = "AcDbLayerTable";
			base.FriendLetSubordinateObjectName = "AcDbLayerTable";
		}

		internal AcadLayer FriendAddAcadObjectLayer0(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLayer0 == null)
			{
				string dstrLayerName = "0";
				mobjAcadLayer0 = (AcadLayer)FriendGetItem(dstrLayerName);
				if (mobjAcadLayer0 == null)
				{
					mobjAcadLayer0 = FriendAddAcadObject(dstrLayerName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadLayer0 != null)
					{
						mobjAcadLayer0.FriendLetPlotStyleNameObjectID = base.Database.Dictionaries.PlotStyleNames.PlaceholderNormal.ObjectID;
					}
				}
			}
			return mobjAcadLayer0;
		}

		~AcadLayers()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadLayer0 = null;
				mblnOpened = false;
			}
		}

		internal AcadLayer FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadLayer dobjAcadLayer4 = new AcadLayer();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadLayer acadLayer = dobjAcadLayer4;
			acadLayer.Name = vstrName;
			acadLayer.FriendLetNodeParentID = base.NodeID;
			acadLayer.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLayer.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLayer.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLayer.FriendLetOwnerID = base.ObjectID;
			AcadLayer acadLayer2 = acadLayer;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadLayer4;
			bool flag = acadLayer2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLayer4 = (AcadLayer)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLayer.ObjectName + ": " + nrstrErrMsg);
			}
			acadLayer = null;
			AcadLayer FriendAddAcadObject = default(AcadLayer);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadLayer4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadLayer4 = (AcadLayer)robjAcadTableRecord;
				FriendAddAcadObject = dobjAcadLayer4;
			}
			dobjAcadLayer4 = null;
			return FriendAddAcadObject;
		}
	}

}
