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
	public class AcadViewports : AcadAbstractViews
	{
		private const string cstrClassName = "AcadViewports";

		private bool mblnOpened;

		private int mlngActiveIndex;

		private AcadViewport mobjAcadViewportActive;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadViewport dobjAcadViewport2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadViewport2 = (AcadViewport)enumerator.Current;
						dobjAcadViewport2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadViewport2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadViewport dobjAcadViewport2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadViewport2 = (AcadViewport)enumerator.Current;
						dobjAcadViewport2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadViewport2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadViewport dobjAcadViewport2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadViewport2 = (AcadViewport)enumerator.Current;
						dobjAcadViewport2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadViewport2 = null;
			}
		}

		internal AcadViewport FriendGetActiveViewport
		{
			get
			{
				if (mlngActiveIndex > -1)
				{
					return (AcadViewport)FriendGetItemByTableIndex(mlngActiveIndex);
				}
				AcadViewport FriendGetActiveViewport = default(AcadViewport);
				return FriendGetActiveViewport;
			}
		}

		internal int FriendGetActiveIndex => mlngActiveIndex;

		public AcadViewport ViewportActive
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectViewportActive(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadViewports()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 115;
			base.FriendLetNodeImageDisabledID = 116;
			base.FriendLetNodeName = "Tabelle Ansichtsfenster";
			base.FriendLetNodeText = "Tabelle Ansichtsfenster";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngActiveIndex = -1;
			base.FriendLetDXFName = "VPORT";
			base.FriendLetObjectName = "AcDbViewportTable";
			base.FriendLetSubordinateObjectName = "AcDbViewportTable";
		}

		internal AcadViewport FriendAddAcadObjectViewportActive(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			object[] dadecCenter = new object[2];
			double[] dadblCenter = new double[2];
			if (mobjAcadViewportActive == null)
			{
				string dstrViewportName = "*Active";
				mobjAcadViewportActive = (AcadViewport)FriendGetItem(dstrViewportName);
				if (mobjAcadViewportActive == null)
				{
					mobjAcadViewportActive = FriendAddAcadObject(dstrViewportName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)), ref nrstrErrMsg);
					if (mobjAcadViewportActive != null)
					{
						bool flag = false;
						dadblCenter[0] = 8.23956262425447;
						dadblCenter[1] = 4.5;
						AcadViewport acadViewport = mobjAcadViewportActive;
						acadViewport.Height = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 9.80485521278679m, 9.80485521278679));
						acadViewport.Width = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1.73175182481752m, 1.73175182481752));
						acadViewport.Center = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCenter, dadblCenter));
						acadViewport = null;
					}
				}
			}
			return mobjAcadViewportActive;
		}

		~AcadViewports()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadViewportActive = null;
				mblnOpened = false;
			}
		}

		public void DeleteConfiguration(string vstrName)
		{
		}

		internal AcadViewport FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadViewport dobjAcadViewport4 = new AcadViewport();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadViewport acadViewport = dobjAcadViewport4;
			acadViewport.Name = vstrName;
			acadViewport.FriendLetNodeParentID = base.NodeID;
			acadViewport.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadViewport.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadViewport.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadViewport.FriendOpen();
			acadViewport.FriendLetOwnerID = base.ObjectID;
			AcadViewport acadViewport2 = acadViewport;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadViewport4;
			bool flag = acadViewport2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadViewport4 = (AcadViewport)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadViewport.ObjectName + ": " + nrstrErrMsg);
			}
			acadViewport = null;
			AcadViewport FriendAddAcadObject = default(AcadViewport);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadViewport4;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadViewport4 = (AcadViewport)robjAcadTableRecord;
				mlngActiveIndex = dobjAcadViewport4.TableIndex;
				FriendAddAcadObject = dobjAcadViewport4;
			}
			dobjAcadViewport4 = null;
			return FriendAddAcadObject;
		}
	}

}
