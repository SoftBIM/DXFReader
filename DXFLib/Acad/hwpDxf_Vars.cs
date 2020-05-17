using DXFLib.DXF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class hwpDxf_Vars
	{
		public static bool pblnAddDocument;

		public static bool pblnInitDocument;

		public static bool pblnAddDatabase;

		public static bool pblnInitDatabase;

		public static bool pblnReadDocument;

		public static bool pblnCleanDocument;

		public static bool pblnAddLWPolylineStopCalcSize;

		public static bool pblnAddPolylineStopCalcSize;

		public static bool pblnAdd3DPolylineStopCalcSize;

		public static AcadApplications pobjAcadApplications = new AcadApplications();

		public static AcadDatabases pobjAcadDatabases = new AcadDatabases();

		public static SysVars pobjSysVars = null;

		public static NodeObjects pobjNodeObjects = new NodeObjects();

		public static Dictionary<object, object> pobjDictDxfDimVarOrder = new Dictionary<object, object>();

		public static UtilMath pobjUtilMath = new UtilMath();

		public static UtilTime pobjUtilTime = new UtilTime();

		public static hwpDxf_Enums.UNITS_BASE pnumUnitsBase;

		public static object[] padecNormal = new object[3];

		public static double[] padblNormal = new double[3];

		public static object pdecThickness;

		public static double pdblThickness;

		public static object pdecHeight;

		public static double pdblHeight;

		public static object[] padecInsertionPoint = new object[3];

		public static double[] padblInsertionPoint = new double[3];

		public static string pstrName;

		public static object pdecObliqueAngleDegree;

		public static double pdblObliqueAngleDegree;

		public static object pdecRotationDegree;

		public static double pdblRotationDegree;

		public static object pdecScaleFactor;

		public static double pdblScaleFactor;

		public static bool pblnDependend;

		public static bool pblnResolved;

		public static Enums.AcTextGenerationFlag pnumTextGenerationFlag;

		public static object pdecWidth;

		public static double pdblWidth;

		public static object pdecDepth;

		public static double pdblDepth;

		public static object[] padecOrigin = new object[3];

		public static double[] padblOrigin = new double[3];

		public static Enums.AcOrthoView pnumUCSOrthographic;

		public static object[] padecXVector = new object[3];

		public static double[] padblXVector = new double[3];

		public static object[] padecYVector = new object[3];

		public static double[] padblYVector = new double[3];

		public static object pdecViewHeight;

		public static double pdblViewHeight;

		public static object pdecViewWidth;

		public static double pdblViewWidth;

		public static object pdecBackClipDistance;

		public static double pdblBackClipDistance;

		public static bool pblnBackClipEnabled;

		public static object[] padecCenter = new object[2];

		public static double[] padblCenter = new double[2];

		public static object[] padecDirection = new object[3];

		public static double[] padblDirection = new double[3];

		public static object pdecFrontClipDistance;

		public static double pdblFrontClipDistance;

		public static bool pblnFrontClipEnabled;

		public static object pdecLensLength;

		public static double pdblLensLength;

		public static bool pblnPerspectiveEnabled;

		public static hwpDxf_Enums.RENDER_MODE pnumRenderMode;

		public static object[] padecTarget = new object[3];

		public static double[] padblTarget = new double[3];

		public static object pdecViewTwistDegree;

		public static double pdblViewTwistDegree;

		public static string pstrDescription;

		public static int plngBulged;

		public static bool pblnClosed;

		public static double pblnIsPeriodic;

		public static string pstrAppPath;

		public static string pstrAppVersion;

		public static bool pblnActive;

		public static Enums.AcActiveSpace pnumActiveSpace;

		public static object pdecElevationModelSpace;

		public static double pdblElevationModelSpace;

		public static object pdecElevationPaperSpace;

		public static double pdblElevationPaperSpace;

		public static string pstrFullName;

		public static string pstrShortName;

		public static object[] padecLimits = new object[4];

		public static double[] padblLimits = new double[4];

		public static bool pblnMSpace;

		public static bool pblnObjectSnapMode;

		public static bool pblnSaved;

		public static string[] pvarSupportedAcadVer;

		public static string pstrMenu;

		public static object pdecPSVPScale;

		public static double pdblPSVPScale;

		public static bool pblnDwgTitled;

		public static bool pblnFullOpen;

		public static string pstrSaveFile;

		public static string pstrSaveName;

		public static object pvarValue;

		public static string pstrValueString;

		public static object pvarAppDefault;

		public static string pstrAppDefaultString;

		public static Enums.AcColor pnumLayerColor;

		public static bool pblnFreeze;

		public static bool pblnLayerOn;

		public static string pstrLayerLinetype;

		public static Enums.AcLineWeight pnumLayerLineweight;

		public static bool pblnLocked;

		public static string pstrLayerPlotStyleName;

		public static bool pblnPlottable;

		public static bool pblnViewportDefault;

		public static object pdecPatternLength;

		public static double pdblPatternLength;

		public static bool pblnScaledToFit;

		public static object pdecLength;

		public static double pdblLength;

		public static hwpDxf_Enums.DASH_TYPE pnumDashType;

		public static bool pblnShapeIsUcsOriented;

		public static int plngShapeNumber;

		public static int plngShapeStyle;

		public static object pdecShapeScale;

		public static double pdblShapeScale;

		public static object pdecShapeRotationDegree;

		public static double pdblShapeRotationDegree;

		public static object pdecShapeOffsetX;

		public static double pdblShapeOffsetX;

		public static object pdecShapeOffsetY;

		public static double pdblShapeOffsetY;

		public static string pstrText;

		public static string pstrBigFontFile;

		public static string pstrFontFile;

		public static bool pblnIsShapeFile;

		public static bool pblnIsVertical;

		public static object pdecLastHeight;

		public static double pdblLastHeight;

		public static object pdecTextWidth;

		public static double pdblTextWidth;

		public static bool pblnR12XdataSave;

		public static bool pblnPaperSpaceView;

		public static bool pblnUcsAssociatedToView;

		public static int plngArcSmoothness;

		public static bool pblnFastZoomsEnabled;

		public static bool pblnFrontClipAtEye;

		public static bool pblnGridOn;

		public static object pdecGridSpacingX;

		public static double pdblGridSpacingX;

		public static object pdecGridSpacingY;

		public static double pdblGridSpacingY;

		public static bool pblnIsometricSnapEnabled;

		public static object[] padecLowerLeftCorner = new object[2];

		public static double[] padblLowerLeftCorner = new double[2];

		public static object[] padecSnapBasePoint = new object[2];

		public static double[] padblSnapBasePoint = new double[2];

		public static bool pblnSnapOn;

		public static hwpDxf_Enums.SNAP_PAIR pnumSnapPair;

		public static object pdecSnapRotationAngleDegree;

		public static double pdblSnapRotationAngleDegree;

		public static object pdecSnapSpacingX;

		public static double pdblSnapSpacingX;

		public static object pdecSnapSpacingY;

		public static double pdblSnapSpacingY;

		public static bool pblnUCSFollowMode;

		public static bool pblnUCSIconAtOrigin;

		public static bool pblnUCSIconOn;

		public static bool pblnUCSSavedWithViewport;

		public static object[] padecUpperRightCorner = new object[2];

		public static double[] padblUpperRightCorner = new double[2];

		public static string pstrApplicationDescription;

		public static bool pblnAppWasAvailable;

		public static string pstrOriginalClassName;

		public static string pstrOriginalDXFName;

		public static int plngProxyFlags;

		public static int plngInstanceCount;

		public static hwpDxf_Enums.PROXY_TYPE pnumProxyType;

		public static string pstrComment;

		public static bool pblnHasAttributeDefinitions;

		public static bool pblnHasPreviewIcon;

		public static bool pblnIsLayout;

		public static bool pblnIsOverlayRef;

		public static bool pblnIsXRef;

		public static double pdblLayoutObjectID;

		public static string pstrPathName;

		public static bool pblnIsPaperSpace;

		public static bool pblnBlkBegEndVisible;

		public static int plngPaperSpace;

		public static Enums.AcColor pnumEntityColor;

		public static string pstrLayer;

		public static string pstrEntityLinetype;

		public static object pdecLinetypeScale;

		public static double pdblLinetypeScale;

		public static Enums.AcLineWeight pnumEntityLineweight;

		public static bool pblnVisible;

		public static int plngRGB;

		public static string pstrDictColor;

		public static object[] padecPointNull = new object[3];

		public static double[] padblPointNull = new double[3];

		public static object[] padecPointXOne = new object[3];

		public static double[] padblPointXOne = new double[3];

		public static object pdecValueNull;

		public static double pdblValueNull;

		public static object pdecValueOne;

		public static double pdblValueOne;

		public static bool pblnHasConstantWidth;

		public static object pdecConstantWidth;

		public static double pdblConstantWidth;

		public static object pdecElevation;

		public static double pdblElevation;

		public static bool pblnLinetypeGeneration;

		public static object pdecCoordX;

		public static double pdblCoordX;

		public static object pdecCoordY;

		public static double pdblCoordY;

		public static object pdecBulge;

		public static double pdblBulge;

		public static object pdecStartWidth;

		public static double pdblStartWidth;

		public static object pdecEndWidth;

		public static double pdblEndWidth;

		public static object pdecCode10;

		public static double pdblCode10;

		public static object pdecCode20;

		public static double pdblCode20;

		public static object pdecCode30;

		public static double pdblCode30;

		public static int plngFlags66;

		public static bool pblnIsCurve;

		public static bool pblnIsSpline;

		public static bool pblnIs3DPolyline;

		public static bool pblnMClosed;

		public static bool pblnSplineFitVertex;

		public static bool pblnSplineCtlVertex;

		public static bool pblnIsPolygonMesh;

		public static bool pblnNClosed;

		public static int plngMVertexCountNumberOfVertices;

		public static int plngNVertexCountNumberOfFaces;

		public static int plngMDensity;

		public static int plngNDensity;

		public static bool pblnIsPolyfaceMesh;

		public static bool pblnCurveFitVertex;

		public static bool pblnIsTangentUsed;

		public static object pdecTangent;

		public static double pdblTangent;

		public static bool pblnIsPolyfaceMeshVertex;

		public static bool pblnIsFaceRecord;

		public static int plngVertex1To4;

		public static object pdecRadius;

		public static double pdblRadius;

		public static object pdecArcStartAngleDegree;

		public static double pdblArcStartAngleDegree;

		public static object pdecArcEndAngleDegree;

		public static double pdblArcEndAngleDegree;

		public static object[] padecCoordinate = new object[3];

		public static double[] padblCoordinate = new double[3];

		public static Enums.AcAlignment pnumAlignment;

		public static string pstrTextStyleName;

		public static object[] padecTextAlignmentPoint = new object[3];

		public static double[] padblTextAlignmentPoint = new double[3];

		public static string pstrTextString;

		public static Enums.AcAttachmentPoint pnumAttachmentPoint;

		public static object pdecActualHeight;

		public static double pdblActualHeight;

		public static object pdecActualWidth;

		public static double pdblActualWidth;

		public static object[] padecMTextDirection = new object[3];

		public static double[] padblMTextDirection = new double[3];

		public static Enums.AcDrawingDirection pnumDrawingDirection;

		public static object pdecMTextHeight;

		public static double pdblMTextHeight;

		public static object pdecLineSpacingFactor;

		public static double pdblLineSpacingFactor;

		public static Enums.AcLineSpacingStyle pnumLineSpacingStyle;

		public static int plngBackgroundMode;

		public static Enums.AcColor pnumBackgroundFillColor;

		public static int plngBackgroundFillRGB;

		public static int plngBackgroundCode441;

		public static object pdecBackgroundBorderOffsetFactor;

		public static double pdblBackgroundBorderOffsetFactor;

		public static bool pblnTreatElementsAsHard;

		public static hwpDxf_Enums.MERGE_STYLE pnumMergeStyle;

		public static string pstrCanonicalMediaName;

		public static bool pblnCenterPlot;

		public static string pstrConfigName;

		public static bool pblnModelType;

		public static Enums.AcPlotPaperUnits pnumPaperUnits;

		public static bool pblnPlotHidden;

		public static object[] padecPlotOrigin = new object[2];

		public static double[] padblPlotOrigin = new double[2];

		public static Enums.AcPlotRotation pnumPlotRotation;

		public static Enums.AcPlotType pnumPlotType;

		public static bool pblnPlotViewportBorders;

		public static bool pblnPlotViewportsFirst;

		public static bool pblnPlotWithLineweights;

		public static bool pblnPlotWithPlotStyles;

		public static bool pblnScaleLineweights;

		public static bool pblnShowPlotStyles;

		public static Enums.AcPlotScale pnumStandardScale;

		public static string pstrStyleSheet;

		public static bool pblnUseStandardScale;

		public static string pstrViewToPlot;

		public static int plngShadePlotMode;

		public static int plngShadePlotResolutionLevel;

		public static int plngShadePlotCustomDPI;

		public static object[] padecPaperMarginLowerLeft = new object[2];

		public static double[] padblPaperMarginLowerLeft = new double[2];

		public static object[] padecPaperMarginUpperRight = new object[2];

		public static double[] padblPaperMarginUpperRight = new double[2];

		public static object pdecPaperWidth;

		public static double pdblPaperWidth;

		public static object pdecPaperHeight;

		public static double pdblPaperHeight;

		public static object[] padecWindowToPlotLowerLeft = new object[2];

		public static double[] padblWindowToPlotLowerLeft = new double[2];

		public static object[] padecWindowToPlotUpperRight = new object[2];

		public static double[] padblWindowToPlotUpperRight = new double[2];

		public static object pdecCustomScaleNumerator;

		public static double pdblCustomScaleNumerator;

		public static object pdecCustomScaleDenominator;

		public static double pdblCustomScaleDenominator;

		public static bool pblnUpdatePaper;

		public static bool pblnZoomToPaperOnUpdate;

		public static bool pblnInitializing;

		public static bool pblnPrevPlotInit;

		public static object pdecPaperScaleFactor;

		public static double pdblPaperScaleFactor;

		public static object[] padecPaperImageOrigin = new object[2];

		public static double[] padblPaperImageOrigin = new double[2];

		public static int plngTabOrder;

		public static object[] padecLayoutLimMin = new object[2];

		public static double[] padblLayoutLimMin = new double[2];

		public static object[] padecLayoutLimMax = new object[2];

		public static double[] padblLayoutLimMax = new double[2];

		public static object[] padecLayoutInsBase = new object[3];

		public static double[] padblLayoutInsBase = new double[3];

		public static object[] padecLayoutExtMin = new object[3];

		public static double[] padblLayoutExtMin = new double[3];

		public static object[] padecLayoutExtMax = new object[3];

		public static double[] padblLayoutExtMax = new double[3];

		public static bool pblnPsLtScale;

		public static bool pblnLimCheck;

		public static bool pblnFilled;

		public static Enums.AcColor pnumMLineStyleColor;

		public static object pdecMLineStyleStartAngleDegree;

		public static double pdblMLineStyleStartAngleDegree;

		public static bool pblnStartSquareCap;

		public static bool pblnStartRoundCap;

		public static bool pblnStartInnerArcs;

		public static object pdecMLineStyleEndAngleDegree;

		public static double pdblMLineStyleEndAngleDegree;

		public static bool pblnEndSquareCap;

		public static bool pblnEndRoundCap;

		public static bool pblnEndInnerArcs;

		public static bool pblnShowMiters;

		public static object pdecOffset;

		public static double pdblOffset;

		public static bool pblnIsAnonymous;

		public static bool pblnIsSelectable;

		public static string pstrAppName;

		public static short pintXDataType;

		public static object pvarXDataValue;

		public static int plngObjectSchemaNumber;

		public static object pdecXScaleFactor;

		public static double pdblXScaleFactor;

		public static object pdecYScaleFactor;

		public static double pdblYScaleFactor;

		public static object pdecZScaleFactor;

		public static double pdblZScaleFactor;

		public static bool pblnHasAttributes;

		public static object pdecColumnSpacing;

		public static double pdblColumnSpacing;

		public static object pdecRowSpacing;

		public static double pdblRowSpacing;

		public static int plngColumns;

		public static int plngRows;

		public static string pstrPromptString;

		public static string pstrTagString;

		public static int plngAttribFlags;

		public static bool pblnInvisible;

		public static bool pblnConstant;

		public static bool pblnVerify;

		public static bool pblnPreset;

		public static int plngFieldLength;

		public static bool pblnSequenceEndVisible;

		public static object[] padecMajorAxis = new object[3];

		public static double[] padblMajorAxis = new double[3];

		public static object pdecRadiusRatio;

		public static double pdblRadiusRatio;

		public static object pdecMajorRadius;

		public static double pdblMajorRadius;

		public static object pdecMinorRadius;

		public static double pdblMinorRadius;

		public static object[] padecMinorAxis = new object[3];

		public static double[] padblMinorAxis = new double[3];

		public static object[] padecElevation = new object[3];

		public static object[] padblElevation = new object[3];

		public static string pstrPatternName;

		public static bool pblnIsSolid;

		public static bool pblnAssociativeHatch;

		public static Enums.AcHatchStyle pnumHatchStyle;

		public static Enums.AcPatternType pnumPatternType;

		public static object pdecPatternAngle;

		public static double pdblPatternAngle;

		public static object pdecPatternScale;

		public static double pdblPatternScale;

		public static object pdecPatternSpace;

		public static double pdblPatternSpace;

		public static bool pblnPatternDouble;

		public static object pdecPixelSize;

		public static object pdblPixelSize;

		public static Enums.AcLoopType pnumLoopType;

		public static bool pblnIsDefault;

		public static bool pblnIsExternal;

		public static bool pblnIsPolyline;

		public static bool pblnIsDerived;

		public static bool pblnIsTextbox;

		public static bool pblnIsOutermost;

		public static Enums.AcLoopEdgeType pnumEdgeType;

		public static object pdecAngleDegree;

		public static double pdblAngleDegree;

		public static object pdecBaseX;

		public static double pdblBaseX;

		public static object pdecBaseY;

		public static double pdblBaseY;

		public static object pdecOffsetX;

		public static double pdblOffsetX;

		public static object pdecOffsetY;

		public static double pdblOffsetY;

		public static object[] padecStartPoint = new object[3];

		public static double[] padblStartPoint = new double[3];

		public static object[] padecEndPoint = new object[3];

		public static double[] padblEndPoint = new double[3];

		public static object pdecStartAngleDegree;

		public static double pdblStartAngleDegree;

		public static object pdecEndAngleDegree;

		public static double pdblEndAngleDegree;

		public static bool pblnIsClockWise;

		public static int plngDegree;

		public static bool pblnIsRational;

		public static object pdecWeight;

		public static double pdblWeight;

		public static object pdecCoordZ;

		public static double pdblCoordZ;

		public static bool pblnIsLinear;

		public static object pdecKnotTolerance;

		public static double pdblKnotTolerance;

		public static object pdecControlPointTolerance;

		public static double pdblControlPointTolerance;

		public static object pdecFitTolerance;

		public static double pdblFitTolerance;

		public static object[] padecStartTangent = new object[3];

		public static double[] padblStartTangent = new double[3];

		public static object[] padecEndTangent = new object[3];

		public static double[] padblEndTangent = new double[3];

		public static bool pblnHasStartTangent;

		public static bool pblnHasEndTangent;
	}
}
