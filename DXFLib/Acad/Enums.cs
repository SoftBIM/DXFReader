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
	public class Enums
	{
		public enum TiJulDateType
		{
			tiNotValid,
			tiJulDateTime,
			tiJulTimeOnly
		}

		public enum TiJulDateIntervall
		{
			tiDays = 1,
			tiHours,
			tiMinutes,
			tiSeconds,
			tiMilliSecs
		}

		public enum TiJulDateCalcModus
		{
			tiAddDates = 1,
			tiSubDates
		}

		public enum AcOrthoView
		{
			acOvNone,
			acOvTopView,
			acOvBottomView,
			acOvFrontView,
			acOvBackView,
			acOvLeftView,
			acOvRightView
		}

		public enum AcBoolean
		{
			acFalse,
			acTrue
		}

		public enum AcOnOff
		{
			acOff,
			acOn
		}

		public enum AcEntityName
		{
			acUnknownEnt = -10,
			acFaceRecord = -9,
			acPolyfaceMeshVertex = -8,
			acPolygonMeshVertex = -7,
			ac3DVertex = -6,
			ac2DVertex = -5,
			acSequenceEnd = -4,
			acBlockBegin = -3,
			acBlockEnd = -2,
			acCurve = -1,
			acEntity = 0,
			ac3dFace = 1,
			ac3dPolyline = 2,
			ac3dSolid = 3,
			acArc = 4,
			acAttribute = 5,
			acAttributeReference = 6,
			acBlockReference = 7,
			acCircle = 8,
			acDimAligned = 9,
			acDimAngular = 10,
			acDimDiametric = 12,
			acDimOrdinate = 13,
			acDimRadial = 14,
			acDimRotated = 0xF,
			acEllipse = 0x10,
			acHatch = 17,
			acLeader = 18,
			acLine = 19,
			acMtext = 21,
			acPoint = 22,
			acPolyline = 23,
			acPolylineLight = 24,
			acPolymesh = 25,
			acRaster = 26,
			acRay = 27,
			acRegion = 28,
			acShape = 29,
			acSolid = 30,
			acSpline = 0x1F,
			acText = 0x20,
			acTolerance = 33,
			acTrace = 34,
			acPViewport = 35,
			acXline = 36,
			acGroup = 37,
			acMInsertBlock = 38,
			acPolyfaceMesh = 39,
			acMLine = 40,
			acDim3PointAngular = 41,
			acExternalReference = 42
		}

		public enum AcCurveName
		{
			acCurveCurve,
			acCurveXLine,
			acCurveRay,
			acCurveLine,
			acCurveCircle,
			acCurveArc,
			acCurveEllipse,
			acCurveSpline,
			acCurvePolylineLight,
			acCurvePolyline,
			acCurve3dPolyline,
			acCurveLeader
		}

		public enum AcActiveSpace
		{
			acPaperSpace,
			acModelSpace
		}

		public enum AcKeyboardAccelerator
		{
			acPreferenceClassic,
			acPreferenceCustom
		}

		public enum AcPlotOrientation
		{
			acPlotOrientationPortrait,
			acPlotOrientationLandscape
		}

		public enum AcColor
		{
			acByBlock,
			acRed,
			acYellow,
			acGreen,
			acCyan,
			acBlue,
			acMagenta,
			acWhite,
			acColor8,
			acColor9,
			acColor10,
			acColor11,
			acColor12,
			acColor13,
			acColor14,
			acColor15,
			acColor16,
			acColor17,
			acColor18,
			acColor19,
			acColor20,
			acColor21,
			acColor22,
			acColor23,
			acColor24,
			acColor25,
			acColor26,
			acColor27,
			acColor28,
			acColor29,
			acColor30,
			acColor31,
			acColor32,
			acColor33,
			acColor34,
			acColor35,
			acColor36,
			acColor37,
			acColor38,
			acColor39,
			acColor40,
			acColor41,
			acColor42,
			acColor43,
			acColor44,
			acColor45,
			acColor46,
			acColor47,
			acColor48,
			acColor49,
			acColor50,
			acColor51,
			acColor52,
			acColor53,
			acColor54,
			acColor55,
			acColor56,
			acColor57,
			acColor58,
			acColor59,
			acColor60,
			acColor61,
			acColor62,
			acColor63,
			acColor64,
			acColor65,
			acColor66,
			acColor67,
			acColor68,
			acColor69,
			acColor70,
			acColor71,
			acColor72,
			acColor73,
			acColor74,
			acColor75,
			acColor76,
			acColor77,
			acColor78,
			acColor79,
			acColor80,
			acColor81,
			acColor82,
			acColor83,
			acColor84,
			acColor85,
			acColor86,
			acColor87,
			acColor88,
			acColor89,
			acColor90,
			acColor91,
			acColor92,
			acColor93,
			acColor94,
			acColor95,
			acColor96,
			acColor97,
			acColor98,
			acColor99,
			acColor100,
			acColor101,
			acColor102,
			acColor103,
			acColor104,
			acColor105,
			acColor106,
			acColor107,
			acColor108,
			acColor109,
			acColor110,
			acColor111,
			acColor112,
			acColor113,
			acColor114,
			acColor115,
			acColor116,
			acColor117,
			acColor118,
			acColor119,
			acColor120,
			acColor121,
			acColor122,
			acColor123,
			acColor124,
			acColor125,
			acColor126,
			acColor127,
			acColor128,
			acColor129,
			acColor130,
			acColor131,
			acColor132,
			acColor133,
			acColor134,
			acColor135,
			acColor136,
			acColor137,
			acColor138,
			acColor139,
			acColor140,
			acColor141,
			acColor142,
			acColor143,
			acColor144,
			acColor145,
			acColor146,
			acColor147,
			acColor148,
			acColor149,
			acColor150,
			acColor151,
			acColor152,
			acColor153,
			acColor154,
			acColor155,
			acColor156,
			acColor157,
			acColor158,
			acColor159,
			acColor160,
			acColor161,
			acColor162,
			acColor163,
			acColor164,
			acColor165,
			acColor166,
			acColor167,
			acColor168,
			acColor169,
			acColor170,
			acColor171,
			acColor172,
			acColor173,
			acColor174,
			acColor175,
			acColor176,
			acColor177,
			acColor178,
			acColor179,
			acColor180,
			acColor181,
			acColor182,
			acColor183,
			acColor184,
			acColor185,
			acColor186,
			acColor187,
			acColor188,
			acColor189,
			acColor190,
			acColor191,
			acColor192,
			acColor193,
			acColor194,
			acColor195,
			acColor196,
			acColor197,
			acColor198,
			acColor199,
			acColor200,
			acColor201,
			acColor202,
			acColor203,
			acColor204,
			acColor205,
			acColor206,
			acColor207,
			acColor208,
			acColor209,
			acColor210,
			acColor211,
			acColor212,
			acColor213,
			acColor214,
			acColor215,
			acColor216,
			acColor217,
			acColor218,
			acColor219,
			acColor220,
			acColor221,
			acColor222,
			acColor223,
			acColor224,
			acColor225,
			acColor226,
			acColor227,
			acColor228,
			acColor229,
			acColor230,
			acColor231,
			acColor232,
			acColor233,
			acColor234,
			acColor235,
			acColor236,
			acColor237,
			acColor238,
			acColor239,
			acColor240,
			acColor241,
			acColor242,
			acColor243,
			acColor244,
			acColor245,
			acColor246,
			acColor247,
			acColor248,
			acColor249,
			acColor250,
			acColor251,
			acColor252,
			acColor253,
			acColor254,
			acColor255,
			acByLayer
		}

		public enum AcAttachmentPoint
		{
			acAttachmentPointTopLeft = 1,
			acAttachmentPointTopCenter,
			acAttachmentPointTopRight,
			acAttachmentPointMiddleLeft,
			acAttachmentPointMiddleCenter,
			acAttachmentPointMiddleRight,
			acAttachmentPointBottomLeft,
			acAttachmentPointBottomCenter,
			acAttachmentPointBottomRight
		}

		public enum AcDrawingDirection
		{
			acLeftToRight = 1,
			acRightToLeft,
			acTopToBottom,
			acBottomToTop,
			acByStyle
		}

		public enum AcLeaderType
		{
			acLineNoArrow,
			acSplineNoArrow,
			acLineWithArrow,
			acSplineWithArrow
		}

		public enum AcAttributeMode
		{
			acAttributeModeNormal = 0,
			acAttributeModeInvisible = 1,
			acAttributeModeConstant = 2,
			acAttributeModeVerify = 4,
			acAttributeModePreset = 8
		}

		public enum AcHorizontalAlignment
		{
			acHorizontalAlignmentLeft,
			acHorizontalAlignmentCenter,
			acHorizontalAlignmentRight,
			acHorizontalAlignmentAligned,
			acHorizontalAlignmentMiddle,
			acHorizontalAlignmentFit
		}

		public enum AcVerticalAlignment
		{
			acVerticalAlignmentBaseline,
			acVerticalAlignmentBottom,
			acVerticalAlignmentMiddle,
			acVerticalAlignmentTop
		}

		public enum AcTextGenerationFlag
		{
			acTextFlagNormal = 0,
			acTextFlagBackward = 2,
			acTextFlagUpsideDown = 4
		}

		public enum AcSelect
		{
			acSelectionSetWindow,
			acSelectionSetCrossing,
			acSelectionSetFence,
			acSelectionSetPrevious,
			acSelectionSetLast,
			acSelectionSetAll,
			acSelectionSetWindowPolygon,
			acSelectionSetCrossingPolygon
		}

		public enum AcPatternType
		{
			acHatchPatternTypeUserDefined,
			acHatchPatternTypePreDefined,
			acHatchPatternTypeCustomDefined
		}

		public enum AcLoopType
		{
			acHatchLoopTypeDefault = 0,
			acHatchLoopTypeExternal = 1,
			acHatchLoopTypePolyline = 2,
			acHatchLoopTypeDerived = 4,
			acHatchLoopTypeTextbox = 8,
			acHatchLoopTypeOutermost = 0x10
		}

		public enum AcLoopEdgeType
		{
			acHatchLoopEdgeTypeUndefined,
			acHatchLoopEdgeTypeLine,
			acHatchLoopEdgeTypeCirArc,
			acHatchLoopEdgeTypeEllArc,
			acHatchLoopEdgeTypeSpline
		}

		public enum AcHatchStyle
		{
			acHatchStyleNormal,
			acHatchStyleOuter,
			acHatchStyleIgnore
		}

		public enum AcPolylineType
		{
			acSimplePoly,
			acFitCurvePoly,
			acQuadSplinePoly,
			acCubicSplinePoly
		}

		public enum Ac3dPolylineType
		{
			acSimple3DPoly,
			acQuadSpline3DPoly,
			acCubicSplined3dPoly
		}

		public enum AcViewportSplitType
		{
			acViewport2Horizontal,
			acViewport2Vertical,
			acViewport3Left,
			acViewport3Right,
			acViewport3Horizontal,
			acViewport3Vertical,
			acViewport3Above,
			acViewport3Below,
			acViewport4
		}

		public enum AcRegenType
		{
			acActiveViewport,
			acAllViewports
		}

		public enum AcBooleanType
		{
			acUnion,
			acIntersection,
			acSubtraction
		}

		public enum AcExtendOption
		{
			acExtendNone,
			acExtendThisEntity,
			acExtendOtherEntity,
			acExtendBoth
		}

		public enum AcAngleUnits
		{
			acDegrees,
			acDegreeMinuteSeconds,
			acGrads,
			acRadians
		}

		public enum AcUnits
		{
			acDefaultUnits = -1,
			acScientific = 1,
			acDecimal = 2,
			acEngineering = 3,
			acArchitectural = 4,
			acFractional = 5
		}

		public enum AcCoordinateSystem
		{
			acWorld,
			acUCS,
			acDisplayDCS,
			acPaperSpaceDCS,
			acOCS
		}

		public enum AcMeasurementUnits
		{
			acEnglish,
			acMetric
		}

		public enum AcXRefDemandLoad
		{
			acDemandLoadDisabled,
			acDemandLoadEnabled,
			acDemandLoadEnabledWithCopy
		}

		public enum AcPreviewMode
		{
			acPartialPreview,
			acFullPreview
		}

		public enum AcPolymeshType
		{
			acSimpleMesh = 0,
			acQuadSurfaceMesh = 5,
			acCubicSurfaceMesh = 6,
			acBezierSurfaceMesh = 8
		}

		public enum AcZoomScaleType
		{
			acZoomScaledAbsolute,
			acZoomScaledRelative,
			acZoomScaledRelativePSpace
		}

		public enum AcDragDisplayMode
		{
			acDragDoNotDisplay,
			acDragDisplayOnRequest,
			acDragDisplayAutomatically
		}

		public enum AcARXDemandLoad
		{
			acDemanLoadDisable,
			acDemandLoadOnObjectDetect,
			acDemandLoadCmdInvoke
		}

		public enum AcTextFontStyle
		{
			acFontRegular,
			acFontItalic,
			acFontBold,
			acFontBoldItalic
		}

		public enum AcProxyImage
		{
			acProxyNotShow,
			acProxyShow,
			acProxyBoundingBox
		}

		public enum AcKeyboardPriority
		{
			acKeyboardRunningObjSnap,
			acKeyboardEntry,
			acKeyboardEntryExceptScripts
		}

		public enum AcMenuGroupType
		{
			acBaseMenuGroup,
			acPartialMenuGroup
		}

		public enum AcMenuFileType
		{
			acMenuFileCompiled,
			acMenuFileSource
		}

		public enum AcMenuItemType
		{
			acMenuItem,
			acMenuSeparator,
			acMenuSubMenu
		}

		public enum AcToolbarItemType
		{
			acToolbarButton,
			acToolbarSeparator,
			acToolbarControl,
			acToolbarFlyout
		}

		public enum AcToolbarDockStatus
		{
			acToolbarDockTop,
			acToolbarDockBottom,
			acToolbarDockLeft,
			acToolbarDockRight,
			acToolbarFloating
		}

		public enum AcLineWeight
		{
			acLnWt000 = 0,
			acLnWt005 = 5,
			acLnWt009 = 9,
			acLnWt013 = 13,
			acLnWt015 = 0xF,
			acLnWt018 = 18,
			acLnWt020 = 20,
			acLnWt025 = 25,
			acLnWt030 = 30,
			acLnWt035 = 35,
			acLnWt040 = 40,
			acLnWt050 = 50,
			acLnWt053 = 53,
			acLnWt060 = 60,
			acLnWt070 = 70,
			acLnWt080 = 80,
			acLnWt090 = 90,
			acLnWt100 = 100,
			acLnWt106 = 106,
			acLnWt120 = 120,
			acLnWt140 = 140,
			acLnWt158 = 158,
			acLnWt200 = 200,
			acLnWt211 = 211,
			acLnWtByLayer = -1,
			acLnWtByBlock = -2,
			acLnWtByLwDefault = -3
		}

		public enum AcWindowState
		{
			acNorm = 1,
			acMin,
			acMax
		}

		public enum AcPlotPaperUnits
		{
			acInches,
			acMillimeters,
			acPixels
		}

		public enum AcPlotRotation
		{
			ac0degrees,
			ac90degrees,
			ac180degrees,
			ac270degrees
		}

		public enum AcPlotType
		{
			acDisplay,
			acExtents,
			acLimits,
			acView,
			acWindow,
			acLayout
		}

		public enum AcPlotScale
		{
			acScaleToFit,
			ac1_128in_1ft,
			ac1_64in_1ft,
			ac1_32in_1ft,
			ac1_16in_1ft,
			ac3_32in_1ft,
			ac1_8in_1ft,
			ac3_16in_1ft,
			ac1_4in_1ft,
			ac3_8in_1ft,
			ac1_2in_1ft,
			ac3_4in_1ft,
			ac1in_1ft,
			ac3in_1ft,
			ac6in_1ft,
			ac1ft_1ft,
			ac1_1,
			ac1_2,
			ac1_4,
			ac1_8,
			ac1_10,
			ac1_16,
			ac1_20,
			ac1_30,
			ac1_40,
			ac1_50,
			ac1_100,
			ac2_1,
			ac4_1,
			ac8_1,
			ac10_1,
			ac100_1
		}

		public enum AcAlignment
		{
			acAlignmentLeft,
			acAlignmentCenter,
			acAlignmentRight,
			acAlignmentAligned,
			acAlignmentMiddle,
			acAlignmentFit,
			acAlignmentTopLeft,
			acAlignmentTopCenter,
			acAlignmentTopRight,
			acAlignmentMiddleLeft,
			acAlignmentMiddleCenter,
			acAlignmentMiddleRight,
			acAlignmentBottomLeft,
			acAlignmentBottomCenter,
			acAlignmentBottomRight
		}

		public enum AcLineSpacingStyle
		{
			acLineSpacingStyleAtLeast = 1,
			acLineSpacingStyleExactly
		}

		public enum AcDimPrecision
		{
			acDimPrecisionZero,
			acDimPrecisionOne,
			acDimPrecisionTwo,
			acDimPrecisionThree,
			acDimPrecisionFour,
			acDimPrecisionFive,
			acDimPrecisionSix,
			acDimPrecisionSeven,
			acDimPrecisionEight
		}

		public enum AcDimUnits
		{
			acDimScientific = 1,
			acDimDecimal,
			acDimEngineering,
			acDimArchitecturalStacked,
			acDimFractionalStacked,
			acDimArchitectural,
			acDimFractional,
			acDimWindowsDesktop
		}

		public enum AcDimLUnits
		{
			acDimLScientific = 1,
			acDimLDecimal,
			acDimLEngineering,
			acDimLArchitectural,
			acDimLFractional,
			acDimLWindowsDesktop
		}

		public enum AcDimArrowheadType
		{
			acArrowDefault,
			acArrowClosedBlank,
			acArrowClosed,
			acArrowDot,
			acArrowArchTick,
			acArrowOblique,
			acArrowOpen,
			acArrowOrigin,
			acArrowOrigin2,
			acArrowOpen90,
			acArrowOpen30,
			acArrowDotSmall,
			acArrowDotBlank,
			acArrowSmall,
			acArrowBoxBlank,
			acArrowBoxFilled,
			acArrowDatumBlank,
			acArrowDatumFilled,
			acArrowIntegral,
			acArrowNone,
			acArrowUserDefined
		}

		public enum AcDimCenterType
		{
			acCenterMark,
			acCenterLine,
			acCenterNone
		}

		public enum AcDimFit
		{
			acTextAndArrows,
			acArrowsOnly,
			acTextOnly,
			acBestFit
		}

		public enum AcDimFractionType
		{
			acHorizontal,
			acDiagonal,
			acNotStacked
		}

		public enum AcDimHorizontalJustification
		{
			acHorzCentered,
			acFirstExtensionLine,
			acSecondExtensionLine,
			acOverFirstExtension,
			acOverSecondExtension
		}

		public enum AcDimVerticalJustification
		{
			acVertCentered,
			acAbove,
			acOutside,
			acJIS
		}

		public enum AcDimTextMovement
		{
			acDimLineWithText,
			acMoveTextAddLeader,
			acMoveTextNoLeader
		}

		public enum AcDimToleranceMethod
		{
			acTolNone,
			acTolSymmetrical,
			acTolDeviation,
			acTolLimits,
			acTolBasic
		}

		public enum AcDimToleranceJustify
		{
			acTolBottom,
			acTolMiddle,
			acTolTop
		}

		public enum AcViewportScale
		{
			acVpScaleToFit,
			acVpCustomScale,
			acVp1_1,
			acVp1_2,
			acVp1_4,
			acVp1_8,
			acVp1_10,
			acVp1_16,
			acVp1_20,
			acVp1_30,
			acVp1_40,
			acVp1_50,
			acVp1_100,
			acVp2_1,
			acVp4_1,
			acVp8_1,
			acVp10_1,
			acVp100_1,
			acVp1_128in_1ft,
			acVp1_64in_1ft,
			acVp1_32in_1ft,
			acVp1_16in_1ft,
			acVp3_32in_1ft,
			acVp1_8in_1ft,
			acVp3_16in_1ft,
			acVp1_4in_1ft,
			acVp3_8in_1ft,
			acVp1_2in_1ft,
			acVp3_4in_1ft,
			acVp1in_1ft,
			acVp3in_1ft,
			acVp6in_1ft,
			acVp1ft_1ft
		}

		public enum AcISOPenWidth
		{
			acPenWidth013 = 13,
			acPenWidth018 = 18,
			acPenWidth025 = 25,
			acPenWidth035 = 35,
			acPenWidth050 = 50,
			acPenWidth070 = 70,
			acPenWidth100 = 100,
			acPenWidth140 = 140,
			acPenWidth200 = 200,
			acPenWidthUnk = -1
		}

		public enum AcSaveAsType
		{
			acUnknown = -1,
			acR12_dxf = 1,
			acR13_dwg = 4,
			acR13_dxf = 5,
			acR14_dwg = 8,
			acR14_dxf = 9,
			acR15_dwg = 12,
			acR15_dxf = 13,
			acR15_Template = 14,
			acNative = 12
		}

		public enum AcPrinterSpoolAlert
		{
			acPrinterAlwaysAlert,
			acPrinterAlertOnce,
			acPrinterNeverAlertLogOnce,
			acPrinterNeverAlert
		}

		public enum AcPlotPolicyForNewDwgs
		{
			acPolicyNewDefault,
			acPolicyNewLegacy
		}

		public enum AcPlotPolicyForLegacyDwgs
		{
			acPolicyLegacyDefault,
			acPolicyLegacyQuery,
			acPolicyLegacyLegacy
		}

		public enum AcOleQuality
		{
			acOQLineArt,
			acOQText,
			acOQGraphics,
			acOQPhoto,
			acOQHighPhoto
		}

		public enum AcLoadPalette
		{
			acPaletteByDrawing,
			acPaletteBySession
		}

		public enum AcInsertUnits
		{
			acInsertUnitsUnitless,
			acInsertUnitsInches,
			acInsertUnitsFeet,
			acInsertUnitsMiles,
			acInsertUnitsMillimeters,
			acInsertUnitsCentimeters,
			acInsertUnitsMeters,
			acInsertUnitsKilometers,
			acInsertUnitsMicroinches,
			acInsertUnitsMils,
			acInsertUnitsYards,
			acInsertUnitsAngstroms,
			acInsertUnitsNanometers,
			acInsertUnitsMicrons,
			acInsertUnitsDecimeters,
			acInsertUnitsDecameters,
			acInsertUnitsHectometers,
			acInsertUnitsGigameters,
			acInsertUnitsAstronomicalUnits,
			acInsertUnitsLightYears,
			acInsertUnitsParsecs
		}

		public enum AcAlignmentPointAcquisition
		{
			acAlignPntAcquisitionAutomatic,
			acAlignPntAcquisitionShiftToAcquire
		}

		public enum AcInsertUnitsAction
		{
			acInsertUnitsPrompt,
			acInsertUnitsAutoAssign
		}

		public enum AcPlotPolicy
		{
			acPolicyNamed,
			acPolicyLegacy
		}

		public enum AcDrawingAreaShortCutMenu
		{
			acNoDrawingAreaShortCutMenu,
			acUseDefaultDrawingAreaShortCutMenu
		}

		public enum AcDrawingAreaSCMDefault
		{
			acRepeatLastCommand,
			acSCM
		}

		public enum AcDrawingAreaSCMEdit
		{
			acEdRepeatLastCommand,
			acEdSCM
		}

		public enum AcDrawingAreaSCMCommand
		{
			acEnter,
			acEnableSCMOptions,
			acEnableSCM
		}
	}
}
