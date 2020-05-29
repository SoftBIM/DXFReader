using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
	public class AcadPlotConfigurations : AcadDictionary
	{
		private const string cstrClassName = "AcadPlotConfigurations";

		private bool mblnOpened;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPlotConfiguration dobjAcadPlotConfiguration2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)enumerator.Current;
						dobjAcadPlotConfiguration2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPlotConfiguration2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPlotConfiguration dobjAcadPlotConfiguration2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)enumerator.Current;
						dobjAcadPlotConfiguration2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPlotConfiguration2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPlotConfiguration dobjAcadPlotConfiguration2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)enumerator.Current;
						dobjAcadPlotConfiguration2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPlotConfiguration2 = null;
			}
		}

		public AcadPlotConfigurations()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 223;
			base.FriendLetNodeImageDisabledID = 224;
			base.FriendLetNodeName = "Wörterbuch Plotstile";
			base.FriendLetNodeText = "Wörterbuch Plotstile";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_PLOTSETTINGS";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbPlotSettingsTable";
		}

		~AcadPlotConfigurations()
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

		internal AcadPlotConfiguration FriendAddAcadObject(string vstrName, double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadPlotConfiguration dobjAcadPlotConfiguration3 = new AcadPlotConfiguration();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadPlotConfiguration acadPlotConfiguration = dobjAcadPlotConfiguration3;
			acadPlotConfiguration.Name = vstrName;
			acadPlotConfiguration.FriendLetNodeParentID = base.NodeID;
			acadPlotConfiguration.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPlotConfiguration.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPlotConfiguration.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPlotConfiguration.FriendLetOwnerID = base.ObjectID;
			AcadPlotConfiguration acadPlotConfiguration2 = acadPlotConfiguration;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadPlotConfiguration3;
			bool flag = acadPlotConfiguration2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPlotConfiguration3 = (AcadPlotConfiguration)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPlotConfiguration.ObjectName + ": " + nrstrErrMsg);
			}
			acadPlotConfiguration = null;
			AcadPlotConfiguration FriendAddAcadObject = default(AcadPlotConfiguration);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadPlotConfiguration3))
			{
				FriendAddAcadObject = dobjAcadPlotConfiguration3;
			}
			dobjAcadPlotConfiguration3 = null;
			return FriendAddAcadObject;
		}
	}

}
