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
	public class AcadDictionaries : AcadDictionary
	{
		private const string cstrClassName = "AcadDictionaries";

		private bool mblnOpened;

		private AcadGroups mobjAcadGroups;

		private AcadDictionaryWithDefault mobjAcadPlotStyleNames;

		private AcadMLineStyles mobjAcadMLineStyles;

		private AcadPlotConfigurations mobjAcadPlotConfigurations;

		private AcadLayouts mobjAcadLayouts;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDictionary dobjAcadDictionary3;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDictionary3 = (AcadDictionary)enumerator.Current;
						AcadObject robjAcadObject = dobjAcadDictionary3;
						hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref robjAcadObject, value);
						dobjAcadDictionary3 = (AcadDictionary)robjAcadObject;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDictionary3 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDictionary dobjAcadDictionary3;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDictionary3 = (AcadDictionary)enumerator.Current;
						AcadObject robjAcadObject = dobjAcadDictionary3;
						hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref robjAcadObject, value);
						dobjAcadDictionary3 = (AcadDictionary)robjAcadObject;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDictionary3 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDictionary dobjAcadDictionary3;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDictionary3 = (AcadDictionary)enumerator.Current;
						AcadObject robjAcadObject = dobjAcadDictionary3;
						hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref robjAcadObject, value);
						dobjAcadDictionary3 = (AcadDictionary)robjAcadObject;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadDictionary3 = null;
			}
		}

		public AcadGroups Groups
		{
			get
			{
				if (mobjAcadGroups == null)
				{
					string nrstrErrMsg = "";
					FriendAddAcadObjectGroups(-1.0, ref nrstrErrMsg);
				}
				return mobjAcadGroups;
			}
		}

		public AcadDictionaryWithDefault PlotStyleNames
		{
			get
			{
				if (mobjAcadPlotStyleNames == null)
				{
					string nrstrErrMsg = "";
					FriendAddAcadObjectPlotStyleNames(-1.0, ref nrstrErrMsg);
				}
				return mobjAcadPlotStyleNames;
			}
		}

		public AcadMLineStyles MlineStyles
		{
			get
			{
				if (mobjAcadMLineStyles == null)
				{
					string nrstrErrMsg = "";
					FriendAddAcadObjectMLineStyles(-1.0, ref nrstrErrMsg);
				}
				return mobjAcadMLineStyles;
			}
		}

		public AcadPlotConfigurations PlotConfigurations
		{
			get
			{
				if (mobjAcadPlotConfigurations == null)
				{
					string nrstrErrMsg = "";
					FriendAddAcadObjectPlotConfigurations(-1.0, ref nrstrErrMsg);
				}
				return mobjAcadPlotConfigurations;
			}
		}

		public AcadLayouts Layouts
		{
			get
			{
				if (mobjAcadLayouts == null)
				{
					string nrstrErrMsg = "";
					FriendAddAcadObjectLayouts(-1.0, ref nrstrErrMsg);
				}
				return mobjAcadLayouts;
			}
		}

		public AcadDictionaries()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 205;
			base.FriendLetNodeImageDisabledID = 206;
			base.FriendLetNodeName = "Wörterbücher";
			base.FriendLetNodeText = "Wörterbücher";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetName = "ACAD_NAMEDOBJECTDICTIONARY";
			base.FriendLetDXFName = "DICTIONARY";
			base.FriendLetObjectName = "AcDbDictionaries";
		}

		internal AcadGroups FriendAddAcadObjectGroups(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadGroups dobjAcadGroups3;
			if (mobjAcadGroups == null)
			{
				dobjAcadGroups3 = new AcadGroups();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadGroups acadGroups = dobjAcadGroups3;
				acadGroups.FriendLetNodeParentID = base.NodeID;
				acadGroups.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadGroups.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadGroups.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadGroups.FriendLetOwnerID = base.ObjectID;
				AcadGroups acadGroups2 = acadGroups;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadGroups3;
				bool flag = acadGroups2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadGroups3 = (AcadGroups)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					acadGroups.FriendAddReactorsID(base.ObjectID, 330);
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadGroups.ObjectName + ": " + nrstrErrMsg);
				}
				acadGroups = null;
				if (dblnValid)
				{
					mobjAcadGroups = dobjAcadGroups3;
					FriendAddItem(mobjAcadGroups.Name, mobjAcadGroups);
				}
			}
			AcadGroups FriendAddAcadObjectGroups = mobjAcadGroups;
			dobjAcadGroups3 = null;
			return FriendAddAcadObjectGroups;
		}

		internal AcadDictionaryWithDefault FriendAddAcadObjectPlotStyleNames(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadDictionaryWithDefault dobjAcadPlotStyleNames3;
			if (mobjAcadPlotStyleNames == null)
			{
				base.Database.Classes.FriendAddAcDbDictionaryWithDefault();
				dobjAcadPlotStyleNames3 = new AcadDictionaryWithDefault();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadDictionaryWithDefault acadDictionaryWithDefault = dobjAcadPlotStyleNames3;
				acadDictionaryWithDefault.Name = "ACAD_PLOTSTYLENAME";
				acadDictionaryWithDefault.FriendLetNodeParentID = base.NodeID;
				acadDictionaryWithDefault.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadDictionaryWithDefault.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadDictionaryWithDefault.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadDictionaryWithDefault.FriendLetOwnerID = base.ObjectID;
				AcadDictionaryWithDefault acadDictionaryWithDefault2 = acadDictionaryWithDefault;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadPlotStyleNames3;
				bool flag = acadDictionaryWithDefault2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadPlotStyleNames3 = (AcadDictionaryWithDefault)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					acadDictionaryWithDefault.FriendAddReactorsID(base.ObjectID, 330);
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadDictionaryWithDefault.ObjectName + ": " + nrstrErrMsg);
				}
				acadDictionaryWithDefault = null;
				if (dblnValid)
				{
					mobjAcadPlotStyleNames = dobjAcadPlotStyleNames3;
					FriendAddItem(mobjAcadPlotStyleNames.Name, mobjAcadPlotStyleNames);
				}
			}
			AcadDictionaryWithDefault FriendAddAcadObjectPlotStyleNames = mobjAcadPlotStyleNames;
			dobjAcadPlotStyleNames3 = null;
			return FriendAddAcadObjectPlotStyleNames;
		}

		internal AcadMLineStyles FriendAddAcadObjectMLineStyles(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadMLineStyles dobjAcadMLineStyles3;
			if (mobjAcadMLineStyles == null)
			{
				dobjAcadMLineStyles3 = new AcadMLineStyles();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadMLineStyles acadMLineStyles = dobjAcadMLineStyles3;
				acadMLineStyles.FriendLetNodeParentID = base.NodeID;
				acadMLineStyles.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadMLineStyles.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadMLineStyles.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadMLineStyles.FriendLetOwnerID = base.ObjectID;
				AcadMLineStyles acadMLineStyles2 = acadMLineStyles;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadMLineStyles3;
				bool flag = acadMLineStyles2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadMLineStyles3 = (AcadMLineStyles)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					acadMLineStyles.FriendAddReactorsID(base.ObjectID, 330);
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadMLineStyles.ObjectName + ": " + nrstrErrMsg);
				}
				acadMLineStyles = null;
				if (dblnValid)
				{
					mobjAcadMLineStyles = dobjAcadMLineStyles3;
					FriendAddItem(mobjAcadMLineStyles.Name, mobjAcadMLineStyles);
				}
			}
			AcadMLineStyles FriendAddAcadObjectMLineStyles = mobjAcadMLineStyles;
			dobjAcadMLineStyles3 = null;
			return FriendAddAcadObjectMLineStyles;
		}

		internal AcadPlotConfigurations FriendAddAcadObjectPlotConfigurations(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadPlotConfigurations dobjAcadPlotConfigurations3;
			if (mobjAcadPlotConfigurations == null)
			{
				dobjAcadPlotConfigurations3 = new AcadPlotConfigurations();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadPlotConfigurations acadPlotConfigurations = dobjAcadPlotConfigurations3;
				acadPlotConfigurations.FriendLetNodeParentID = base.NodeID;
				acadPlotConfigurations.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPlotConfigurations.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPlotConfigurations.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPlotConfigurations.FriendLetOwnerID = base.ObjectID;
				AcadPlotConfigurations acadPlotConfigurations2 = acadPlotConfigurations;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadPlotConfigurations3;
				bool flag = acadPlotConfigurations2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadPlotConfigurations3 = (AcadPlotConfigurations)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					acadPlotConfigurations.FriendAddReactorsID(base.ObjectID, 330);
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadPlotConfigurations.ObjectName + ": " + nrstrErrMsg);
				}
				acadPlotConfigurations = null;
				if (dblnValid)
				{
					mobjAcadPlotConfigurations = dobjAcadPlotConfigurations3;
					FriendAddItem(mobjAcadPlotConfigurations.Name, mobjAcadPlotConfigurations);
				}
			}
			AcadPlotConfigurations FriendAddAcadObjectPlotConfigurations = mobjAcadPlotConfigurations;
			dobjAcadPlotConfigurations3 = null;
			return FriendAddAcadObjectPlotConfigurations;
		}

		internal AcadLayouts FriendAddAcadObjectLayouts(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			AcadLayouts dobjAcadLayouts3;
			if (mobjAcadLayouts == null)
			{
				dobjAcadLayouts3 = new AcadLayouts();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadLayouts acadLayouts = dobjAcadLayouts3;
				acadLayouts.FriendLetNodeParentID = base.NodeID;
				acadLayouts.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadLayouts.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadLayouts.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadLayouts.FriendLetOwnerID = base.ObjectID;
				AcadLayouts acadLayouts2 = acadLayouts;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadLayouts3;
				bool flag = acadLayouts2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadLayouts3 = (AcadLayouts)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					acadLayouts.FriendAddReactorsID(base.ObjectID, 330);
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadLayouts.ObjectName + ": " + nrstrErrMsg);
				}
				acadLayouts = null;
				if (dblnValid)
				{
					mobjAcadLayouts = dobjAcadLayouts3;
					FriendAddItem(mobjAcadLayouts.Name, mobjAcadLayouts);
				}
			}
			AcadLayouts FriendAddAcadObjectLayouts = mobjAcadLayouts;
			dobjAcadLayouts3 = null;
			return FriendAddAcadObjectLayouts;
		}

		~AcadDictionaries()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadGroups = null;
				mobjAcadPlotStyleNames = null;
				mobjAcadMLineStyles = null;
				mobjAcadPlotConfigurations = null;
				mobjAcadLayouts = null;
				mblnOpened = false;
			}
		}

		internal AcadDictionary FriendAddAcadObject(string vstrName, double vdblObjectID, ref string nrstrErrMsg = "")
		{
			AcadDictionary dobjAcadDictionary3 = new AcadDictionary();
			AcadDictionary acadDictionary = dobjAcadDictionary3;
			acadDictionary.Name = vstrName;
			acadDictionary.FriendLetNodeParentID = base.NodeID;
			acadDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadDictionary.FriendLetOwnerID = base.ObjectID;
			AcadDictionary acadDictionary2 = acadDictionary;
			AcadObject nrobjAcadObject = dobjAcadDictionary3;
			bool flag = acadDictionary2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadDictionary3 = (AcadDictionary)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				acadDictionary.FriendAddReactorsID(base.ObjectID, 330);
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadDictionary.ObjectName + ": " + nrstrErrMsg);
			}
			acadDictionary = null;
			AcadDictionary FriendAddAcadObject = default(AcadDictionary);
			if (dblnValid && FriendAddItem(vstrName, dobjAcadDictionary3))
			{
				FriendAddAcadObject = dobjAcadDictionary3;
			}
			dobjAcadDictionary3 = null;
			return FriendAddAcadObject;
		}
	}
}
