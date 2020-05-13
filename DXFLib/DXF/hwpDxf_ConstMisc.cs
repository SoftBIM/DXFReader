using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    class hwpDxf_ConstMisc
    {

		public const bool pcblnIgnoreUnknowDictionaries = true;

		public const bool pcblnIgnoreUnknowNamedObjectDictionaryElements = true;

		public const string pcstrIsBinary = "AutoCAD Binary DXF";

		public const bool pcblnAddAndInitObjects = true;

		public const bool pcblnDecimal = false;

		public const string pcstrSuffix = "dxf";

		public const int pclngErrNr = 50000;

		public const string pcstrSectionBeg = "SECTION";

		public const string pcstrSectionEnd = "ENDSEC";

		public const string pcstrSecNameHeader = "HEADER";

		public const string pcstrSecNameClasses = "CLASSES";

		public const string pcstrSecNameTables = "TABLES";

		public const string pcstrSecNameBlocks = "BLOCKS";

		public const string pcstrSecNameEntities = "ENTITIES";

		public const string pcstrSecNameObjects = "OBJECTS";

		public const string pcstrSecNameThumbnailimage = "THUMNAILIMAGE";

		public const int pclngSecPosHeader = 1;

		public const int pclngSecPosClasses = 2;

		public const int pclngSecPosTables = 3;

		public const int pclngSecPosBlocks = 4;

		public const int pclngSecPosEntities = 5;

		public const int pclngSecPosObjects = 6;

		public const int pclngSecPosThumbnail = 7;

		public const string pcstrTableSecBeg = "TABLE";

		public const string pcstrTableSecEnd = "ENDTAB";

		public const int pclngTablePosVPort = 1;

		public const int pclngTablePosLType = 2;

		public const int pclngTablePosLayer = 3;

		public const int pclngTablePosStyle = 4;

		public const int pclngTablePosView = 5;

		public const int pclngTablePosUcs = 6;

		public const int pclngTablePosAppid = 7;

		public const int pclngTablePosDimstyle = 8;

		public const int pclngTablePosBlock_Record = 9;

		public const string pcstrClassSecBeg = "CLASS";

		public const string pcstrBracketBeg = "{";

		public const string pcstrBracketEnd = "}";

		public const string pcstrAcadReactors = "{ACAD_REACTORS";

		public const string pcstrAcadXDictionary = "{ACAD_XDICTIONARY";

		public const string pcstrBlkrefs = "{BLKREFS";

		public const string pcstrBlockSecBeg = "BLOCK";

		public const string pcstrBlockSecEnd = "ENDBLK";

		public const string pcstrDxfSysVarPrefix = "$";

		public const string pcstrActiveViewport = "Active";

		public const short pcintNoNextCode = -1;

		public const short pcintNextCodeStep = 10;

		public const int pclngVisible = 0;

		public const int pclngInvisible = 1;

		public const int pclngPaperSpace = 1;

		public const int pclng2DLWVertexCoordX = 0;

		public const int pclng2DLWVertexCoordY = 1;

		public const int pclng2DLWVertexBulge = 2;

		public const int pclng2DLWVertexStartWidth = 3;

		public const int pclng2DLWVertexEndWidth = 4;

		public const int pclng2DHWVertexCoordX = 0;

		public const int pclng2DHWVertexCoordY = 1;

		public const int pclng2DHWVertexCoordZ = 2;

		public const int pclng2DHWVertexBulge = 3;

		public const int pclng2DHWVertexStartWidth = 4;

		public const int pclng2DHWVertexEndWidth = 5;

		public const int pclng3DVertexCoordX = 0;

		public const int pclng3DVertexCoordY = 1;

		public const int pclng3DVertexCoordZ = 2;

		public const int pclngStartID = -1;

		public const int pclngNoID = 0;

		public const double pcdblStartID = -1.0;

		public const double pcdblNoID = 0.0;

		public const string pcstrItemKeyPrefix = "K";

		public const int pclngStartIndex = -1;

		public const int pclngNewNameIndex = 1;

		public const string pcstrGUIDBracketBeg = "{";

		public const string pcstrGUIDBracketEnd = "}";

		public static int pcnumUnitsBase = 1;

		public static int pcnumUnitsMetric = 0;

		public static int pcnumUnitsBritish = 0;

		public const string pcstrDefProfileName = "<<Unbenanntes Profil>>";

		public const bool pcblnImageFrameHighlight = false;

		public const bool pcblnShowRasterImage = false;

		public const int pclngXRefFadeIntensity = 50;

		public const int pclngXRefFadeIntensityMin = 0;

		public const int pclngXRefFadeIntensityMax = 90;

		public const int pclngCursorSize = 5;

		public const int pclngCursorSizeMin = 1;

		public const int pclngCursorSizeMax = 100;

		public const bool pcblnAutoSnapAperture = false;

		public const int pclngAutoSnapApertureSize = 10;

		public const int pclngAutoSnapApertureSizeMin = 1;

		public const int pclngAutoSnapApertureSizeMax = 50;

		public const bool pcblnAutoSnapMagnet = true;

		public const bool pcblnAutoSnapMarker = true;

		public const bool pcblnAutoSnapTooltip = true;

		public const bool pcblnAutoTrackTooltip = true;

		public const bool pcblnFullScreenTrackingVector = true;

		public const bool pcblnPolarTrackingVector = true;

		public const string pcstrDefaultInternetURL = "www.autodesk.com/acaduser";

		public const string pcstrPostScriptPrologFile = "";

		public const string pcstrAltFontFile = "simplex.shx";

		public const string pcstrCustomDictionary = "";

		public const string pcstrFontFileMap = "acad.fmp";

		public const string pcstrMainDictionary = "de";

		public const string pcstrTextEditor = "Intern";

		public const int pclngIncrementalSavePercent = 50;

		public const int pclngIncrementalSavePercentMin = 0;

		public const int pclngIncrementalSavePercentMax = 100;

		public const bool pcblnSavePreviewThumbnail = true;

		public const int pclngAutoSaveInterval = 120;

		public const int pclngAutoSaveIntervalMin = 0;

		public const int pclngAutoSaveIntervalMax = 600;

		public const bool pcblnCreateBackup = true;

		public const bool pcblnLogFileOn = false;

		public const string pcstrTempFileExtension = "ac$";

		public const int pclngDemandLoadARXApp = 3;

		public static int pclngProxyImage = 1;

		public const bool pcblnShowProxyDialogBox = true;

		public static int pclngXRefDemandLoad = 1;

		public static int pclngOLEQuality = 1;

		public const bool pcblnPrinterPaperSizeAlert = false;

		public static int pclngPrinterSpoolAlert = 0;

		public static int pclngPlotPolicy = 1;

		public const string pcstrDefaultPlotStyleForLayer = "Normal";

		public const bool pcblnPlotLegacy = false;

		public const bool pcblnDisplayGrips = true;

		public const bool pcblnDisplayGripsWithinBlocks = false;

		public static int pclngGripColorSelected = 1;

		public static int pclngGripColorUnselected = 5;

		public const int pclngGripSize = 3;

		public const int pclngGripSizeMin = 1;

		public const int pclngGripSizeMax = 255;

		public const bool pcblnPickAdd = true;

		public const bool pcblnPickAuto = true;

		public const int pclngPickBox = 3;

		public const int pclngPickBoxMin = 0;

		public const int pclngPickBoxMax = 50;

		public const bool pcblnPickDrag = false;

		public const bool pcblnPickFirst = true;

		public const bool pcblnPickGroup = true;

		public const bool pcblnLoadAcadLspInAllDocuments = false;

		public static int pclngKeyboardPriority = 2;

		public const bool pcblnShortCutMenuDisplay = true;

		public static int pclngSCMCommandMode = 1;

		public static int pclngSCMDefaultMode = 1;

		public static int pclngSCMEditMode = 1;

		public const int pclngContourLinesPerSurface = 4;

		public const bool pcblnDisplaySilhouette = false;

		public const int pclngSegmentPerPolyline = 8;

		public const bool pcblnSolidFill = true;

		public const bool pcblnTextFrameDisplay = false;

		public const bool pcblnXRefEdit = true;

		public const bool pcblnXRefLayerVisibility = true;

		public const bool pcblnOLELaunch = false;

		public const bool pcblnAllowLongSymbolNames = true;

		public static int pclngLineweight = -1;

		public const bool pcblnLineWeightDisplay = true;

		public const bool pcblnObjectSortByPlotting = true;

		public const bool pcblnObjectSortByPSOutput = true;

		public const bool pcblnObjectSortByRedraws = false;

		public const bool pcblnObjectSortByRegens = false;

		public const bool pcblnObjectSortBySelection = false;

		public const bool pcblnObjectSortBySnap = false;

		public const int pclngMaxActiveViewports = 48;

		public static int pclngFirstEntityName = 1;

		public static int pclngLastEntityName = 42;
	}

}

