using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadDatabase : NodeObject
	{
		private const string cstrClassName = "AcadDatabase";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private object mdecElevationModelSpace;

		private double mdblElevationModelSpace;

		private object mdecElevationPaperSpace;

		private double mdblElevationPaperSpace;

		private double mdblObjectID;

		private double mdblMaxObjectID;

		private Dictionary<object, object> mobjDictObjectID;

		private Dictionary<object, object> mobjDictReservedObjectID;

		private AcadClasses mobjAcadClasses;

		private AcadFontTable mobjAcadFontTable;

		private AcadVXTable mobjAcadVXTable;

		private AcadViewports mobjAcadViewports;

		private AcadLineTypes mobjAcadLineTypes;

		private AcadLayers mobjAcadLayers;

		private AcadTextStyles mobjAcadTextStyles;

		private AcadViews mobjAcadViews;

		private AcadDimStyles mobjAcadDimStyles;

		private AcadUCSs mobjAcadUCSs;

		private AcadRegisteredApplications mobjAcadRegisteredApplications;

		private AcadBlocks mobjAcadBlocks;

		private AcadDictionaries mobjAcadDictionaries;

		internal double FriendGetMaxObjectID => mdblMaxObjectID;

		internal double FriendGetNextObjectID => mdblObjectID;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				if (mobjAcadClasses != null)
				{
					mobjAcadClasses.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadFontTable != null)
				{
					mobjAcadFontTable.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadVXTable != null)
				{
					mobjAcadVXTable.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadViewports != null)
				{
					mobjAcadViewports.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadLineTypes != null)
				{
					mobjAcadLineTypes.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadLayers != null)
				{
					mobjAcadLayers.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadTextStyles != null)
				{
					mobjAcadTextStyles.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadViews != null)
				{
					mobjAcadViews.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadDimStyles != null)
				{
					mobjAcadDimStyles.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadUCSs != null)
				{
					mobjAcadUCSs.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadRegisteredApplications != null)
				{
					mobjAcadRegisteredApplications.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadBlocks != null)
				{
					mobjAcadBlocks.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
				if (mobjAcadDictionaries != null)
				{
					mobjAcadDictionaries.FriendLetDatabaseIndex = mlngDatabaseIndex;
				}
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				if (mobjAcadClasses != null)
				{
					mobjAcadClasses.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadFontTable != null)
				{
					mobjAcadFontTable.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadVXTable != null)
				{
					mobjAcadVXTable.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadViewports != null)
				{
					mobjAcadViewports.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadLineTypes != null)
				{
					mobjAcadLineTypes.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadLayers != null)
				{
					mobjAcadLayers.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadTextStyles != null)
				{
					mobjAcadTextStyles.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadViews != null)
				{
					mobjAcadViews.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadDimStyles != null)
				{
					mobjAcadDimStyles.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadUCSs != null)
				{
					mobjAcadUCSs.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadRegisteredApplications != null)
				{
					mobjAcadRegisteredApplications.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadBlocks != null)
				{
					mobjAcadBlocks.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadDictionaries != null)
				{
					mobjAcadDictionaries.FriendLetDocumentIndex = mlngDocumentIndex;
				}
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				if (mobjAcadClasses != null)
				{
					mobjAcadClasses.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadFontTable != null)
				{
					mobjAcadFontTable.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadVXTable != null)
				{
					mobjAcadVXTable.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadViewports != null)
				{
					mobjAcadViewports.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadLineTypes != null)
				{
					mobjAcadLineTypes.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadLayers != null)
				{
					mobjAcadLayers.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadTextStyles != null)
				{
					mobjAcadTextStyles.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadViews != null)
				{
					mobjAcadViews.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadDimStyles != null)
				{
					mobjAcadDimStyles.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadUCSs != null)
				{
					mobjAcadUCSs.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadRegisteredApplications != null)
				{
					mobjAcadRegisteredApplications.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadBlocks != null)
				{
					mobjAcadBlocks.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				if (mobjAcadDictionaries != null)
				{
					mobjAcadDictionaries.FriendLetApplicationIndex = mlngApplicationIndex;
				}
			}
		}

		internal AcadDocument FriendGetDocument
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.FriendGetItem(mlngApplicationIndex).Documents.FriendGetItem(mlngDocumentIndex);
				}
				AcadDocument FriendGetDocument = default(AcadDocument);
				return FriendGetDocument;
			}
		}

		internal AcadApplication FriendGetApplication
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.FriendGetItem(mlngApplicationIndex);
				}
				AcadApplication FriendGetApplication = default(AcadApplication);
				return FriendGetApplication;
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
			}
		}

		public AcadClasses Classes => FriendAddAcadClasses();

		public AcadFontTable FontTable
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectFontTable(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadVXTable VXTable
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectVXTable(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadViewports Viewports
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectViewports(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLineTypes Linetypes
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLineTypes(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadLayers Layers
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectLayers(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadTextStyles TextStyles
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectTextStyles(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadViews Views
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectViews(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadDimStyles DimStyles
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectDimStyles(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadUCSs UserCoordinateSystems
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectUCSs(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadRegisteredApplications RegisteredApplications
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectRegisteredApplications(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadBlocks Blocks
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlocks(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadModelSpace ModelSpace
		{
			get
			{
				string nrstrErrMsg = "";
				AcadBlocks dobjAcadBlocks2 = FriendAddAcadObjectBlocks(-1.0, ref nrstrErrMsg);
				AcadModelSpace ModelSpace = default(AcadModelSpace);
				if (dobjAcadBlocks2 != null)
				{
					ModelSpace = dobjAcadBlocks2.ModelSpace;
				}
				dobjAcadBlocks2 = null;
				return ModelSpace;
			}
		}

		public AcadPaperSpace PaperSpace
		{
			get
			{
				string nrstrErrMsg = "";
				AcadBlocks dobjAcadBlocks2 = FriendAddAcadObjectBlocks(-1.0, ref nrstrErrMsg);
				AcadPaperSpace PaperSpace = default(AcadPaperSpace);
				if (dobjAcadBlocks2 != null)
				{
					PaperSpace = dobjAcadBlocks2.PaperSpace;
				}
				dobjAcadBlocks2 = null;
				return PaperSpace;
			}
		}

		public AcadDictionaries Dictionaries
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
			}
		}

		public AcadGroups Groups
		{
			get
			{
				string nrstrErrMsg = "";
				AcadDictionaries dobjAcadDictionaries2 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
				AcadGroups Groups = default(AcadGroups);
				if (dobjAcadDictionaries2 != null)
				{
					Groups = dobjAcadDictionaries2.Groups;
				}
				dobjAcadDictionaries2 = null;
				return Groups;
			}
		}

		public AcadDictionaryWithDefault PlotStyleNames
		{
			get
			{
				string nrstrErrMsg = "";
				AcadDictionaries dobjAcadDictionaries2 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
				AcadDictionaryWithDefault PlotStyleNames = default(AcadDictionaryWithDefault);
				if (dobjAcadDictionaries2 != null)
				{
					PlotStyleNames = dobjAcadDictionaries2.PlotStyleNames;
				}
				dobjAcadDictionaries2 = null;
				return PlotStyleNames;
			}
		}

		public AcadMLineStyles MlineStyles
		{
			get
			{
				string nrstrErrMsg = "";
				AcadDictionaries dobjAcadDictionaries2 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
				AcadMLineStyles MlineStyles = default(AcadMLineStyles);
				if (dobjAcadDictionaries2 != null)
				{
					MlineStyles = dobjAcadDictionaries2.MlineStyles;
				}
				dobjAcadDictionaries2 = null;
				return MlineStyles;
			}
		}

		public AcadPlotConfigurations PlotConfigurations
		{
			get
			{
				string nrstrErrMsg = "";
				AcadDictionaries dobjAcadDictionaries2 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
				AcadPlotConfigurations PlotConfigurations = default(AcadPlotConfigurations);
				if (dobjAcadDictionaries2 != null)
				{
					PlotConfigurations = dobjAcadDictionaries2.PlotConfigurations;
				}
				dobjAcadDictionaries2 = null;
				return PlotConfigurations;
			}
		}

		public AcadLayouts Layouts
		{
			get
			{
				string nrstrErrMsg = "";
				AcadDictionaries dobjAcadDictionaries2 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
				AcadLayouts Layouts = default(AcadLayouts);
				if (dobjAcadDictionaries2 != null)
				{
					Layouts = dobjAcadDictionaries2.Layouts;
				}
				dobjAcadDictionaries2 = null;
				return Layouts;
			}
		}

		public object ElevationModelSpace
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecElevationModelSpace), mdblElevationModelSpace));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecElevationModelSpace;
				ref double reference = ref mdblElevationModelSpace;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
				}
			}
		}

		public object ElevationPaperSpace
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecElevationPaperSpace), mdblElevationPaperSpace));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecElevationPaperSpace;
				ref double reference = ref mdblElevationPaperSpace;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
				}
			}
		}

		public object Limits
		{
			get
			{
				object Limits = default(object);
				return Limits;
			}
			set
			{
			}
		}

		private void InternPropSet()
		{
			bool flag = false;
			mdblElevationModelSpace = hwpDxf_Vars.pdblElevationModelSpace;
			mdblElevationPaperSpace = hwpDxf_Vars.pdblElevationPaperSpace;
		}

		public AcadDatabase()
		{
			hwpDxf_Init.BkDXF_InitDefObjValues();
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 109;
			base.FriendLetNodeImageDisabledID = 110;
			base.FriendLetNodeName = "Datenbank";
			base.FriendLetNodeText = "Datenbank";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			InternPropSet();
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			AcadDatabases pobjAcadDatabases = hwpDxf_Vars.pobjAcadDatabases;
			AcadDatabase robjAcadDatabase = this;
			mlngDatabaseIndex = pobjAcadDatabases.Add(ref robjAcadDatabase);
			mobjDictObjectID = new Dictionary<object, object>();
			mobjDictReservedObjectID = new Dictionary<object, object>();
			AcadDocument dobjAcadDocument2;
			if (!hwpDxf_Vars.pblnAddDatabase)
			{
				hwpDxf_Vars.pblnInitDatabase = true;
				dobjAcadDocument2 = new AcadDocument();
				hwpDxf_Vars.pblnInitDatabase = false;
				AcadDocument acadDocument = dobjAcadDocument2;
				FriendInit(acadDocument.NodeID, acadDocument.FriendGetApplicationIndex, acadDocument.FriendGetDocumentIndex);
				acadDocument = null;
				AcadDocument acadDocument2 = dobjAcadDocument2;
				robjAcadDatabase = this;
				acadDocument2.FriendSetDatabase(ref robjAcadDatabase);
			}
			dobjAcadDocument2 = null;
		}

		internal void FriendInit(int vlngNodeParentID, int vlngApplicationIndex, int vlngDocumentIndex, bool nvblnNew = true, object nvvarReservedHandles = null)
		{
			if (nvblnNew)
			{
				base.FriendLetNodeParentID = vlngNodeParentID;
				mlngApplicationIndex = vlngApplicationIndex;
				mlngDocumentIndex = vlngDocumentIndex;
				InternCheckReservedHandles(RuntimeHelpers.GetObjectValue(nvvarReservedHandles));
				InternNextObjectID(1.0);
			}
			if (!hwpDxf_Vars.pblnReadDocument)
			{
				FriendAddAndInitObjects();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		internal void FriendAddAndInitObjects()
		{
			FriendAddAcadClasses();
			Classes.FriendAddAcDbDictionaryWithDefault();
			Classes.FriendAddAcDbPlaceholder();
			Classes.FriendAddAcDbLayout();
			string nrstrErrMsg = "";
			AcadObject dobjAcadObject59 = FriendAddAcadObjectBlocks(-1.0, ref nrstrErrMsg);
			if (dobjAcadObject59 != null)
			{
				dobjAcadObject59 = null;
				nrstrErrMsg = "";
				dobjAcadObject59 = FriendAddAcadObjectLayers(-1.0, ref nrstrErrMsg);
				if (dobjAcadObject59 != null)
				{
					dobjAcadObject59 = null;
					nrstrErrMsg = "";
					dobjAcadObject59 = FriendAddAcadObjectTextStyles(-1.0, ref nrstrErrMsg);
					if (dobjAcadObject59 != null)
					{
						dobjAcadObject59 = null;
						nrstrErrMsg = "";
						dobjAcadObject59 = FriendAddAcadObjectFontTable(-1.0, ref nrstrErrMsg);
						if (dobjAcadObject59 != null)
						{
							dobjAcadObject59 = null;
							nrstrErrMsg = "";
							dobjAcadObject59 = FriendAddAcadObjectLineTypes(-1.0, ref nrstrErrMsg);
							if (dobjAcadObject59 != null)
							{
								dobjAcadObject59 = null;
								nrstrErrMsg = "";
								dobjAcadObject59 = FriendAddAcadObjectViews(-1.0, ref nrstrErrMsg);
								if (dobjAcadObject59 != null)
								{
									dobjAcadObject59 = null;
									nrstrErrMsg = "";
									dobjAcadObject59 = FriendAddAcadObjectUCSs(-1.0, ref nrstrErrMsg);
									if (dobjAcadObject59 != null)
									{
										dobjAcadObject59 = null;
										nrstrErrMsg = "";
										dobjAcadObject59 = FriendAddAcadObjectViewports(-1.0, ref nrstrErrMsg);
										if (dobjAcadObject59 != null)
										{
											dobjAcadObject59 = null;
											nrstrErrMsg = "";
											dobjAcadObject59 = FriendAddAcadObjectRegisteredApplications(-1.0, ref nrstrErrMsg);
											if (dobjAcadObject59 != null)
											{
												dobjAcadObject59 = null;
												nrstrErrMsg = "";
												dobjAcadObject59 = FriendAddAcadObjectDimStyles(-1.0, ref nrstrErrMsg);
												if (dobjAcadObject59 != null)
												{
													dobjAcadObject59 = null;
													nrstrErrMsg = "";
													dobjAcadObject59 = FriendAddAcadObjectVXTable(-1.0, ref nrstrErrMsg);
													if (dobjAcadObject59 != null)
													{
														dobjAcadObject59 = null;
														nrstrErrMsg = "";
														dobjAcadObject59 = FriendAddAcadObjectDictionaries(-1.0, ref nrstrErrMsg);
														if (dobjAcadObject59 != null)
														{
															dobjAcadObject59 = null;
															AcadDictionaries dictionaries = Dictionaries;
															nrstrErrMsg = "";
															dobjAcadObject59 = dictionaries.FriendAddAcadObjectGroups(-1.0, ref nrstrErrMsg);
															if (dobjAcadObject59 != null)
															{
																dobjAcadObject59 = null;
																AcadDictionaries dictionaries2 = Dictionaries;
																nrstrErrMsg = "";
																dobjAcadObject59 = dictionaries2.FriendAddAcadObjectPlotStyleNames(-1.0, ref nrstrErrMsg);
																if (dobjAcadObject59 != null)
																{
																	dobjAcadObject59 = null;
																	AcadDictionaryWithDefault plotStyleNames = Dictionaries.PlotStyleNames;
																	nrstrErrMsg = "";
																	dobjAcadObject59 = plotStyleNames.FriendAddAcadObjectPlaceholderNormal(-1.0, ref nrstrErrMsg);
																	if (dobjAcadObject59 != null)
																	{
																		dobjAcadObject59 = null;
																		AcadLayers layers = Layers;
																		nrstrErrMsg = "";
																		dobjAcadObject59 = layers.FriendAddAcadObjectLayer0(-1.0, ref nrstrErrMsg);
																		if (dobjAcadObject59 != null)
																		{
																			dobjAcadObject59 = null;
																			AcadTextStyles textStyles = TextStyles;
																			nrstrErrMsg = "";
																			dobjAcadObject59 = textStyles.FriendAddAcadObjectTextStyleStandard(-1.0, ref nrstrErrMsg);
																			if (dobjAcadObject59 != null)
																			{
																				dobjAcadObject59 = null;
																				AcadRegisteredApplications registeredApplications = RegisteredApplications;
																				nrstrErrMsg = "";
																				dobjAcadObject59 = registeredApplications.FriendAddAcadObjectRegisteredApplicationAcad(-1.0, ref nrstrErrMsg);
																				if (dobjAcadObject59 != null)
																				{
																					dobjAcadObject59 = null;
																					if (mdblObjectID == 19.0)
																					{
																						InternNextObjectID();
																					}
																					AcadLineTypes linetypes = Linetypes;
																					nrstrErrMsg = "";
																					dobjAcadObject59 = linetypes.FriendAddAcadObjectLineTypeByBlock(-1.0, ref nrstrErrMsg);
																					if (dobjAcadObject59 != null)
																					{
																						dobjAcadObject59 = null;
																						AcadLineTypes linetypes2 = Linetypes;
																						nrstrErrMsg = "";
																						dobjAcadObject59 = linetypes2.FriendAddAcadObjectLineTypeByLayer(-1.0, ref nrstrErrMsg);
																						if (dobjAcadObject59 != null)
																						{
																							dobjAcadObject59 = null;
																							AcadLineTypes linetypes3 = Linetypes;
																							nrstrErrMsg = "";
																							dobjAcadObject59 = linetypes3.FriendAddAcadObjectLineTypeContinuous(-1.0, ref nrstrErrMsg);
																							if (dobjAcadObject59 != null)
																							{
																								dobjAcadObject59 = null;
																								AcadDictionaries dictionaries3 = Dictionaries;
																								nrstrErrMsg = "";
																								dobjAcadObject59 = dictionaries3.FriendAddAcadObjectMLineStyles(-1.0, ref nrstrErrMsg);
																								if (dobjAcadObject59 != null)
																								{
																									dobjAcadObject59 = null;
																									AcadMLineStyles mlineStyles = Dictionaries.MlineStyles;
																									nrstrErrMsg = "";
																									dobjAcadObject59 = mlineStyles.FriendAddAcadObjectMLineStyleStandard(-1.0, ref nrstrErrMsg);
																									if (dobjAcadObject59 != null)
																									{
																										dobjAcadObject59 = null;
																										AcadDictionaries dictionaries4 = Dictionaries;
																										nrstrErrMsg = "";
																										dobjAcadObject59 = dictionaries4.FriendAddAcadObjectPlotConfigurations(-1.0, ref nrstrErrMsg);
																										if (dobjAcadObject59 != null)
																										{
																											dobjAcadObject59 = null;
																											AcadDictionaries dictionaries5 = Dictionaries;
																											nrstrErrMsg = "";
																											dobjAcadObject59 = dictionaries5.FriendAddAcadObjectLayouts(-1.0, ref nrstrErrMsg);
																											if (dobjAcadObject59 != null)
																											{
																												dobjAcadObject59 = null;
																												AcadBlocks blocks = Blocks;
																												nrstrErrMsg = "";
																												AcadBlock dobjAcadBlock7 = blocks.FriendAddAcadObjectBlockPaperSpace(-1.0, ref nrstrErrMsg).FriendGetAcadBlock();
																												if (dobjAcadBlock7 != null)
																												{
																													dobjAcadBlock7 = null;
																													AcadBlocks blocks2 = Blocks;
																													nrstrErrMsg = "";
																													dobjAcadBlock7 = blocks2.FriendAddAcadObjectBlockModelSpace(-1.0, ref nrstrErrMsg).FriendGetAcadBlock();
																													if (dobjAcadBlock7 != null)
																													{
																														dobjAcadBlock7 = null;
																														AcadBlocks blocks3 = Blocks;
																														nrstrErrMsg = "";
																														dobjAcadBlock7 = blocks3.FriendAddAcadObjectBlockPaperSpace0(-1.0, ref nrstrErrMsg).FriendGetAcadBlock();
																														if (dobjAcadBlock7 != null)
																														{
																															dobjAcadBlock7 = null;
																															AcadDimStyles dimStyles = DimStyles;
																															nrstrErrMsg = "";
																															dobjAcadObject59 = dimStyles.FriendAddAcadObjectDimStyleDefault(-1.0, ref nrstrErrMsg);
																															if (dobjAcadObject59 != null)
																															{
																																dobjAcadObject59 = null;
																																AcadFontTable fontTable = FontTable;
																																nrstrErrMsg = "";
																																dobjAcadObject59 = fontTable.FriendAddAcadObject("1", ref nrstrErrMsg);
																																if (dobjAcadObject59 != null)
																																{
																																	dobjAcadObject59 = null;
																																	AcadFontTable fontTable2 = FontTable;
																																	nrstrErrMsg = "";
																																	dobjAcadObject59 = fontTable2.FriendAddAcadObject("2", ref nrstrErrMsg);
																																	if (dobjAcadObject59 != null)
																																	{
																																		dobjAcadObject59 = null;
																																		AcadViewports viewports = Viewports;
																																		nrstrErrMsg = "";
																																		dobjAcadObject59 = viewports.FriendAddAcadObjectViewportActive(-1.0, ref nrstrErrMsg);
																																		if (dobjAcadObject59 != null)
																																		{
																																			dobjAcadObject59 = null;
																																			dobjAcadBlock7 = null;
																																			dobjAcadObject59 = null;
																																			return;
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Information.Err().Raise(50000, "AcadDatabase", "Initialisierung fehlgeschlagen.");
		}

		internal AcadClasses FriendAddAcadClasses()
		{
			if (mobjAcadClasses == null)
			{
				mobjAcadClasses = new AcadClasses();
				AcadClasses acadClasses = mobjAcadClasses;
				acadClasses.FriendLetNodeParentID = base.NodeID;
				acadClasses.FriendLetApplicationIndex = mlngApplicationIndex;
				acadClasses.FriendLetDocumentIndex = mlngDocumentIndex;
				acadClasses.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadClasses = null;
			}
			return mobjAcadClasses;
		}

		internal AcadBlocks FriendAddAcadObjectBlocks(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadBlocks == null)
			{
				AcadBlocks dobjAcadBlocks3 = new AcadBlocks();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadBlocks acadBlocks = dobjAcadBlocks3;
				acadBlocks.FriendLetNodeParentID = base.NodeID;
				acadBlocks.FriendLetApplicationIndex = mlngApplicationIndex;
				acadBlocks.FriendLetDocumentIndex = mlngDocumentIndex;
				acadBlocks.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadBlocks.FriendLetOwnerID = 0.0;
				AcadBlocks acadBlocks2 = acadBlocks;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadBlocks3;
				bool flag = acadBlocks2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadBlocks3 = (AcadBlocks)nrobjAcadObject;
				if (flag)
				{
					mobjAcadBlocks = dobjAcadBlocks3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadBlocks.ObjectName + ": " + nrstrErrMsg);
				}
				acadBlocks = null;
				dobjAcadBlocks3 = null;
			}
			return mobjAcadBlocks;
		}

		internal AcadLayers FriendAddAcadObjectLayers(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLayers == null)
			{
				AcadLayers dobjAcadLayers3 = new AcadLayers();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadLayers acadLayers = dobjAcadLayers3;
				acadLayers.FriendLetNodeParentID = base.NodeID;
				acadLayers.FriendLetApplicationIndex = mlngApplicationIndex;
				acadLayers.FriendLetDocumentIndex = mlngDocumentIndex;
				acadLayers.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadLayers.FriendLetOwnerID = 0.0;
				AcadLayers acadLayers2 = acadLayers;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadLayers3;
				bool flag = acadLayers2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadLayers3 = (AcadLayers)nrobjAcadObject;
				if (flag)
				{
					mobjAcadLayers = dobjAcadLayers3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadLayers.ObjectName + ": " + nrstrErrMsg);
				}
				acadLayers = null;
				dobjAcadLayers3 = null;
			}
			return mobjAcadLayers;
		}

		internal AcadTextStyles FriendAddAcadObjectTextStyles(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadTextStyles == null)
			{
				AcadTextStyles dobjAcadTextStyles3 = new AcadTextStyles();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadTextStyles acadTextStyles = dobjAcadTextStyles3;
				acadTextStyles.FriendLetNodeParentID = base.NodeID;
				acadTextStyles.FriendLetApplicationIndex = mlngApplicationIndex;
				acadTextStyles.FriendLetDocumentIndex = mlngDocumentIndex;
				acadTextStyles.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadTextStyles.FriendLetOwnerID = 0.0;
				AcadTextStyles acadTextStyles2 = acadTextStyles;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadTextStyles3;
				bool flag = acadTextStyles2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadTextStyles3 = (AcadTextStyles)nrobjAcadObject;
				if (flag)
				{
					mobjAcadTextStyles = dobjAcadTextStyles3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadTextStyles.ObjectName + ": " + nrstrErrMsg);
				}
				acadTextStyles = null;
				dobjAcadTextStyles3 = null;
			}
			return mobjAcadTextStyles;
		}

		internal AcadFontTable FriendAddAcadObjectFontTable(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadFontTable == null)
			{
				AcadFontTable dobjAcadFontTable3 = new AcadFontTable();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadFontTable acadFontTable = dobjAcadFontTable3;
				acadFontTable.FriendLetNodeParentID = base.NodeID;
				acadFontTable.FriendLetApplicationIndex = mlngApplicationIndex;
				acadFontTable.FriendLetDocumentIndex = mlngDocumentIndex;
				acadFontTable.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadFontTable.FriendLetOwnerID = 0.0;
				AcadFontTable acadFontTable2 = acadFontTable;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadFontTable3;
				bool flag = acadFontTable2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadFontTable3 = (AcadFontTable)nrobjAcadObject;
				if (flag)
				{
					mobjAcadFontTable = dobjAcadFontTable3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadFontTable.ObjectName + ": " + nrstrErrMsg);
				}
				acadFontTable = null;
				dobjAcadFontTable3 = null;
			}
			return mobjAcadFontTable;
		}

		internal AcadLineTypes FriendAddAcadObjectLineTypes(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadLineTypes == null)
			{
				AcadLineTypes dobjAcadLineTypes3 = new AcadLineTypes();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadLineTypes acadLineTypes = dobjAcadLineTypes3;
				acadLineTypes.FriendLetNodeParentID = base.NodeID;
				acadLineTypes.FriendLetApplicationIndex = mlngApplicationIndex;
				acadLineTypes.FriendLetDocumentIndex = mlngDocumentIndex;
				acadLineTypes.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadLineTypes.FriendLetOwnerID = 0.0;
				AcadLineTypes acadLineTypes2 = acadLineTypes;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadLineTypes3;
				bool flag = acadLineTypes2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadLineTypes3 = (AcadLineTypes)nrobjAcadObject;
				if (flag)
				{
					mobjAcadLineTypes = dobjAcadLineTypes3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadLineTypes.ObjectName + ": " + nrstrErrMsg);
				}
				acadLineTypes = null;
				dobjAcadLineTypes3 = null;
			}
			return mobjAcadLineTypes;
		}

		internal AcadViews FriendAddAcadObjectViews(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadViews == null)
			{
				AcadViews dobjAcadViews3 = new AcadViews();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadViews acadViews = dobjAcadViews3;
				acadViews.FriendLetNodeParentID = base.NodeID;
				acadViews.FriendLetApplicationIndex = mlngApplicationIndex;
				acadViews.FriendLetDocumentIndex = mlngDocumentIndex;
				acadViews.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadViews.FriendLetOwnerID = 0.0;
				AcadViews acadViews2 = acadViews;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadViews3;
				bool flag = acadViews2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadViews3 = (AcadViews)nrobjAcadObject;
				if (flag)
				{
					mobjAcadViews = dobjAcadViews3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadViews.ObjectName + ": " + nrstrErrMsg);
				}
				acadViews = null;
				dobjAcadViews3 = null;
			}
			return mobjAcadViews;
		}

		internal AcadUCSs FriendAddAcadObjectUCSs(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadUCSs == null)
			{
				AcadUCSs dobjAcadUCSs3 = new AcadUCSs();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadUCSs acadUCSs = dobjAcadUCSs3;
				acadUCSs.FriendLetNodeParentID = base.NodeID;
				acadUCSs.FriendLetApplicationIndex = mlngApplicationIndex;
				acadUCSs.FriendLetDocumentIndex = mlngDocumentIndex;
				acadUCSs.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadUCSs.FriendLetOwnerID = 0.0;
				AcadUCSs acadUCSs2 = acadUCSs;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadUCSs3;
				bool flag = acadUCSs2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadUCSs3 = (AcadUCSs)nrobjAcadObject;
				if (flag)
				{
					mobjAcadUCSs = dobjAcadUCSs3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadUCSs.ObjectName + ": " + nrstrErrMsg);
				}
				acadUCSs = null;
				dobjAcadUCSs3 = null;
			}
			return mobjAcadUCSs;
		}

		internal AcadViewports FriendAddAcadObjectViewports(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadViewports == null)
			{
				AcadViewports dobjAcadViewports3 = new AcadViewports();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadViewports acadViewports = dobjAcadViewports3;
				acadViewports.FriendLetNodeParentID = base.NodeID;
				acadViewports.FriendLetApplicationIndex = mlngApplicationIndex;
				acadViewports.FriendLetDocumentIndex = mlngDocumentIndex;
				acadViewports.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadViewports.FriendLetOwnerID = 0.0;
				AcadViewports acadViewports2 = acadViewports;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadViewports3;
				bool flag = acadViewports2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadViewports3 = (AcadViewports)nrobjAcadObject;
				if (flag)
				{
					mobjAcadViewports = dobjAcadViewports3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadViewports.ObjectName + ": " + nrstrErrMsg);
				}
				acadViewports = null;
				dobjAcadViewports3 = null;
			}
			return mobjAcadViewports;
		}

		internal AcadRegisteredApplications FriendAddAcadObjectRegisteredApplications(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadRegisteredApplications == null)
			{
				AcadRegisteredApplications dobjAcadRegisteredApplications3 = new AcadRegisteredApplications();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadRegisteredApplications acadRegisteredApplications = dobjAcadRegisteredApplications3;
				acadRegisteredApplications.FriendLetNodeParentID = base.NodeID;
				acadRegisteredApplications.FriendLetApplicationIndex = mlngApplicationIndex;
				acadRegisteredApplications.FriendLetDocumentIndex = mlngDocumentIndex;
				acadRegisteredApplications.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadRegisteredApplications.FriendLetOwnerID = 0.0;
				AcadRegisteredApplications acadRegisteredApplications2 = acadRegisteredApplications;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadRegisteredApplications3;
				bool flag = acadRegisteredApplications2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadRegisteredApplications3 = (AcadRegisteredApplications)nrobjAcadObject;
				if (flag)
				{
					mobjAcadRegisteredApplications = dobjAcadRegisteredApplications3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadRegisteredApplications.ObjectName + ": " + nrstrErrMsg);
				}
				acadRegisteredApplications = null;
				dobjAcadRegisteredApplications3 = null;
			}
			return mobjAcadRegisteredApplications;
		}

		internal AcadDimStyles FriendAddAcadObjectDimStyles(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadDimStyles == null)
			{
				AcadDimStyles dobjAcadDimStyles3 = new AcadDimStyles();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadDimStyles acadDimStyles = dobjAcadDimStyles3;
				acadDimStyles.FriendLetNodeParentID = base.NodeID;
				acadDimStyles.FriendLetApplicationIndex = mlngApplicationIndex;
				acadDimStyles.FriendLetDocumentIndex = mlngDocumentIndex;
				acadDimStyles.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadDimStyles.FriendLetOwnerID = 0.0;
				AcadDimStyles acadDimStyles2 = acadDimStyles;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadDimStyles3;
				bool flag = acadDimStyles2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadDimStyles3 = (AcadDimStyles)nrobjAcadObject;
				if (flag)
				{
					mobjAcadDimStyles = dobjAcadDimStyles3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadDimStyles.ObjectName + ": " + nrstrErrMsg);
				}
				acadDimStyles = null;
				dobjAcadDimStyles3 = null;
			}
			return mobjAcadDimStyles;
		}

		internal AcadVXTable FriendAddAcadObjectVXTable(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadVXTable == null)
			{
				AcadVXTable dobjAcadVXTable3 = new AcadVXTable();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadVXTable acadVXTable = dobjAcadVXTable3;
				acadVXTable.FriendLetNodeParentID = base.NodeID;
				acadVXTable.FriendLetApplicationIndex = mlngApplicationIndex;
				acadVXTable.FriendLetDocumentIndex = mlngDocumentIndex;
				acadVXTable.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadVXTable.FriendLetOwnerID = 0.0;
				AcadVXTable acadVXTable2 = acadVXTable;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadVXTable3;
				bool flag = acadVXTable2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadVXTable3 = (AcadVXTable)nrobjAcadObject;
				if (flag)
				{
					mobjAcadVXTable = dobjAcadVXTable3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadVXTable.ObjectName + ": " + nrstrErrMsg);
				}
				acadVXTable = null;
				dobjAcadVXTable3 = null;
			}
			return mobjAcadVXTable;
		}

		internal AcadDictionaries FriendAddAcadObjectDictionaries(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (mobjAcadDictionaries == null)
			{
				AcadDictionaries dobjAcadDictionaries3 = new AcadDictionaries();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = FriendGetNextObjectID;
				}
				AcadDictionaries acadDictionaries = dobjAcadDictionaries3;
				acadDictionaries.FriendLetNodeParentID = base.NodeID;
				acadDictionaries.FriendLetApplicationIndex = mlngApplicationIndex;
				acadDictionaries.FriendLetDocumentIndex = mlngDocumentIndex;
				acadDictionaries.FriendLetDatabaseIndex = mlngDatabaseIndex;
				acadDictionaries.FriendLetOwnerID = 0.0;
				AcadDictionaries acadDictionaries2 = acadDictionaries;
				double vdblObjectID = nvdblObjectID;
				AcadObject nrobjAcadObject = dobjAcadDictionaries3;
				bool flag = acadDictionaries2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadDictionaries3 = (AcadDictionaries)nrobjAcadObject;
				if (flag)
				{
					mobjAcadDictionaries = dobjAcadDictionaries3;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadDictionaries.ObjectName + ": " + nrstrErrMsg);
				}
				acadDictionaries = null;
				dobjAcadDictionaries3 = null;
			}
			return mobjAcadDictionaries;
		}

		internal void FriendReset()
		{
			InternPropSet();
			InternQuit();
			mobjDictObjectID = new Dictionary<object, object>();
			mobjDictReservedObjectID = new Dictionary<object, object>();
			InternNextObjectID(1.0);
		}

		~AcadDatabase()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternQuit();
				hwpDxf_Vars.pobjAcadDatabases.Remove(mlngDatabaseIndex);
				base.FriendQuit();
				mobjDictObjectID = null;
				mobjDictReservedObjectID = null;
				mblnOpened = false;
			}
		}

		private void InternQuit()
		{
			if (mobjAcadClasses != null)
			{
				mobjAcadClasses.FriendQuit();
			}
			if (mobjAcadFontTable != null)
			{
				mobjAcadFontTable.FriendQuit();
			}
			if (mobjAcadVXTable != null)
			{
				mobjAcadVXTable.FriendQuit();
			}
			if (mobjAcadDictionaries != null)
			{
				mobjAcadDictionaries.FriendQuit();
			}
			if (mobjAcadBlocks != null)
			{
				mobjAcadBlocks.FriendQuit();
			}
			if (mobjAcadDimStyles != null)
			{
				mobjAcadDimStyles.FriendQuit();
			}
			if (mobjAcadRegisteredApplications != null)
			{
				mobjAcadRegisteredApplications.FriendQuit();
			}
			if (mobjAcadUCSs != null)
			{
				mobjAcadUCSs.FriendQuit();
			}
			if (mobjAcadViews != null)
			{
				mobjAcadViews.FriendQuit();
			}
			if (mobjAcadTextStyles != null)
			{
				mobjAcadTextStyles.FriendQuit();
			}
			if (mobjAcadLayers != null)
			{
				mobjAcadLayers.FriendQuit();
			}
			if (mobjAcadLineTypes != null)
			{
				mobjAcadLineTypes.FriendQuit();
			}
			if (mobjAcadViewports != null)
			{
				mobjAcadViewports.FriendQuit();
			}
			mobjAcadClasses = null;
			mobjAcadFontTable = null;
			mobjAcadVXTable = null;
			mobjAcadDictionaries = null;
			mobjAcadBlocks = null;
			mobjAcadDimStyles = null;
			mobjAcadRegisteredApplications = null;
			mobjAcadUCSs = null;
			mobjAcadViews = null;
			mobjAcadTextStyles = null;
			mobjAcadLayers = null;
			mobjAcadLineTypes = null;
			mobjAcadViewports = null;
			mobjDictObjectID.Clear();
			mobjDictReservedObjectID.Clear();
			mobjDictObjectID = null;
			mobjDictReservedObjectID = null;
		}

		internal bool FriendObjectIDExist(double vdblObjectID)
		{
			return mobjDictObjectID.ContainsKey("K" + Conversions.ToString(vdblObjectID));
		}

		internal bool FriendValidObjectID(double vdblObjectID, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			if (vdblObjectID <= 0.0)
			{
				nrstrErrMsg = "Die Objekt-ID '" + Conversions.ToString(vdblObjectID) + "' ist zu klein.";
			}
			else
			{
				if (!FriendObjectIDExist(vdblObjectID))
				{
					return true;
				}
				nrstrErrMsg = "Die Objekt-ID '" + Conversions.ToString(vdblObjectID) + "' ist bereits vergeben.";
			}
			bool FriendValidObjectID = default(bool);
			return FriendValidObjectID;
		}

		internal void FriendRemoveObjectID(double vdblObjectID)
		{
			if (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				mobjDictObjectID.Remove("K" + Conversions.ToString(vdblObjectID));
			}
		}

		internal void FriendAddObjectID(double vdblObjectID, ref AcadObject robjAcadObject)
		{
			mobjDictObjectID.Add("K" + Conversions.ToString(vdblObjectID), robjAcadObject);
			if (vdblObjectID >= mdblMaxObjectID)
			{
				mdblMaxObjectID = vdblObjectID + 1.0;
			}
			InternNextObjectID(mdblObjectID);
		}

		private bool InternCheckReplacedObjectID(ref AcadObject robjAcadObject, double vdblOldObjectID, double vdblNewObjectID)
		{
			AcadEntity dobjAcadEntity2 = default(AcadEntity);
			try
			{
				dobjAcadEntity2 = (AcadEntity)robjAcadObject;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
			}
			bool dblnReplaced = default(bool);
			AcadBlock dobjAcadBlock3 = default(AcadBlock);
			if (dobjAcadEntity2 != null)
			{
				double ownerID = dobjAcadEntity2.OwnerID;
				AcadObject robjAcadObject2 = dobjAcadBlock3;
				string nrstrErrMsg = "";
				bool flag = FriendObjectIdToObject(ownerID, ref robjAcadObject2, ref nrstrErrMsg);
				dobjAcadBlock3 = (AcadBlock)robjAcadObject2;
				if (flag)
				{
					dblnReplaced = dobjAcadBlock3.FriendReplaceObjectID(ref robjAcadObject, vdblOldObjectID, vdblNewObjectID);
				}
			}
			if (!dblnReplaced)
			{
				hwpDxf_Functions.BkDXF_DebugPrint("Database-ReplaceObjectID: Fehler " + robjAcadObject.ObjectName);
			}
			bool InternCheckReplacedObjectID = dblnReplaced;
			dobjAcadBlock3 = null;
			dobjAcadEntity2 = null;
			return InternCheckReplacedObjectID;
		}

		internal bool FriendHandleToObject(string vstrHandle, ref AcadObject robjAcadObject, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			robjAcadObject = null;
			double ddblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(vstrHandle);
			if (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(ddblObjectID)))
			{
				robjAcadObject = (AcadObject)mobjDictObjectID["K" + Conversions.ToString(ddblObjectID)];
			}
			if (robjAcadObject == null)
			{
				nrstrErrMsg = "Referenz nicht vergeben.";
				bool FriendHandleToObject = default(bool);
				return FriendHandleToObject;
			}
			return true;
		}

		internal bool FriendObjectIdToObject(double vdblObjectID, ref AcadObject robjAcadObject, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			if (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				robjAcadObject = (AcadObject)mobjDictObjectID["K" + Conversions.ToString(vdblObjectID)];
				return true;
			}
			robjAcadObject = null;
			nrstrErrMsg = "Objekt-ID nicht vergeben.";
			bool FriendObjectIdToObject = default(bool);
			return FriendObjectIdToObject;
		}

		internal bool FriendObjectIdToNodeID(double vdblObjectID, ref int rlngNodeID, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			rlngNodeID = -1;
			bool FriendObjectIdToNodeID = default(bool);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject3, ref nrstrErrMsg))
			{
				dobjAcadObject3 = null;
			}
			else
			{
				rlngNodeID = InternGetNodeID(dobjAcadObject3);
				FriendObjectIdToNodeID = true;
				dobjAcadObject3 = null;
			}
			return FriendObjectIdToNodeID;
		}

		internal bool FriendHandleToNodeID(string vstrHandle, ref int rlngNodeID, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			rlngNodeID = -1;
			bool FriendHandleToNodeID = default(bool);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendHandleToObject(vstrHandle, ref dobjAcadObject3, ref nrstrErrMsg))
			{
				dobjAcadObject3 = null;
			}
			else
			{
				rlngNodeID = InternGetNodeID(dobjAcadObject3);
				FriendHandleToNodeID = true;
				dobjAcadObject3 = null;
			}
			return FriendHandleToNodeID;
		}

		public object CopyObjects(object vvarObjects, object nvobjOwner = null, object nvvarIdPairs = null)
		{
			object CopyObjects = default(object);
			return CopyObjects;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object HandleToObject(string vstrHandle)
		{
			string dstrErrMsg = default(string);
			object HandleToObject = default(object);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendHandleToObject(vstrHandle, ref dobjAcadObject3, ref dstrErrMsg))
			{
				dobjAcadObject3 = null;
				Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
			}
			else
			{
				HandleToObject = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return HandleToObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object ObjectIdToObject(double vdblObjectID)
		{
			string dstrErrMsg = default(string);
			object ObjectIdToObject = default(object);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject3, ref dstrErrMsg))
			{
				dobjAcadObject3 = null;
				Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
			}
			else
			{
				ObjectIdToObject = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return ObjectIdToObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public int ObjectIdToNodeID(double vdblObjectID)
		{
			int dlngNodeID = default(int);
			string dstrErrMsg = default(string);
			if (!FriendObjectIdToNodeID(vdblObjectID, ref dlngNodeID, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
				int ObjectIdToNodeID = default(int);
				return ObjectIdToNodeID;
			}
			return dlngNodeID;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public int HandleToNodeID(string vstrHandle)
		{
			int dlngNodeID = default(int);
			string dstrErrMsg = default(string);
			if (!FriendHandleToNodeID(vstrHandle, ref dlngNodeID, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadDatabase", dstrErrMsg);
				int HandleToNodeID = default(int);
				return HandleToNodeID;
			}
			return dlngNodeID;
		}

		public void ClearReservedObjectIDs()
		{
			if (mobjDictReservedObjectID != null)
			{
				mobjDictReservedObjectID.Clear();
			}
		}

		public double FindNextFreeObjectID(double nvdblObjectID = 0.0)
		{
			nvdblObjectID = Math.Round(nvdblObjectID, 0);
			if (nvdblObjectID < 0.0)
			{
				nvdblObjectID = 0.0;
			}
			nvdblObjectID += 1.0;
			while (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(nvdblObjectID)))
			{
				nvdblObjectID += 1.0;
			}
			return nvdblObjectID;
		}

		public string FindNextFreeHandle(string nvstrHandle = null)
		{
			int nrlngErrNum = 0;
			string nrstrErrMsg = "";
			double dblObjectID = hwpDxf_Functions.BkDXF_ValidHexNum(nvstrHandle, ref nrlngErrNum, ref nrstrErrMsg) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : 0.0;
			return hwpDxf_Functions.BkDXF_DblToHex(FindNextFreeObjectID(dblObjectID));
		}

		private int InternGetNodeID(AcadObject vobjAcadObject)
		{
			NodeObject dobjNodeObject2;
			try
			{
				dobjNodeObject2 = vobjAcadObject;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				int InternGetNodeID = -1;
				ProjectData.ClearProjectError();
				return InternGetNodeID;
			}
			dobjNodeObject2 = null;
			return dobjNodeObject2.NodeID;
		}

		private void InternNextObjectID(double nvdblObjectID = 0.0)
		{
			if (nvdblObjectID == 0.0)
			{
				mdblObjectID += 1.0;
			}
			else
			{
				mdblObjectID = nvdblObjectID;
			}
			while (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(mdblObjectID)) | mobjDictReservedObjectID.ContainsKey("K" + Conversions.ToString(mdblObjectID)))
			{
				mdblObjectID += 1.0;
			}
			if (mdblObjectID > mdblMaxObjectID)
			{
				mdblMaxObjectID = mdblObjectID;
			}
		}

		private void InternCheckReservedHandles(object vvarReservedHandles)
		{
			mobjDictReservedObjectID.Clear();
			int dlngType = (int)Information.VarType(RuntimeHelpers.GetObjectValue(vvarReservedHandles));
			if (!(dlngType == 8201 || dlngType == 8200))
			{
				return;
			}
			int num = Information.LBound((Array)vvarReservedHandles);
			int num2 = Information.UBound((Array)vvarReservedHandles);
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				object dvarItem = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarReservedHandles, new object[1]
				{
				dlngIdx
				}, null));
				if (Information.VarType(RuntimeHelpers.GetObjectValue(dvarItem)) != VariantType.String)
				{
					continue;
				}
				string vstrHexNum = Conversions.ToString(dvarItem);
				int nrlngErrNum = 0;
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_ValidHexNum(vstrHexNum, ref nrlngErrNum, ref nrstrErrMsg))
				{
					double ddblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(dvarItem));
					if (ddblObjectID > 0.0 && !mobjDictReservedObjectID.ContainsKey("K" + Conversions.ToString(ddblObjectID)))
					{
						mobjDictReservedObjectID.Add("K" + Conversions.ToString(ddblObjectID), ddblObjectID);
					}
				}
			}
		}
	}
}
