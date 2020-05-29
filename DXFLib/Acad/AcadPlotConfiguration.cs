using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadPlotConfiguration : AcadObject
	{
		private const string cstrClassName = "AcadPlotConfiguration";

		private const int clngPlotViewportBorders = 1;

		private const int clngShowPlotStyles = 2;

		private const int clngCenterPlot = 4;

		private const int clngPlotHidden = 8;

		private const int clngUseStandardScale = 16;

		private const int clngPlotWithPlotStyles = 32;

		private const int clngScaleLineweights = 64;

		private const int clngPlotWithLineweights = 128;

		private const int clngPlotViewportsFirst = 512;

		private const int clngModelType = 1024;

		private const int clngUpdatePaper = 2048;

		private const int clngZoomToPaperOnUpdate = 4096;

		private const int clngInitializing = 8192;

		private const int clngPrevPlotInit = 16384;

		private bool mblnOpened;

		private string mstrSuperiorObjectName;

		private string mstrName;

		private string mstrCanonicalMediaName;

		private bool mblnCenterPlot;

		private string mstrConfigName;

		private bool mblnModelType;

		private Enums.AcPlotPaperUnits mnumPaperUnits;

		private bool mblnPlotHidden;

		private object[] madecPlotOrigin;

		private double[] madblPlotOrigin;

		private Enums.AcPlotRotation mnumPlotRotation;

		private Enums.AcPlotType mnumPlotType;

		private bool mblnPlotViewportBorders;

		private bool mblnPlotViewportsFirst;

		private bool mblnPlotWithLineweights;

		private bool mblnPlotWithPlotStyles;

		private bool mblnScaleLineweights;

		private bool mblnShowPlotStyles;

		private Enums.AcPlotScale mnumStandardScale;

		private string mstrStyleSheet;

		private bool mblnUseStandardScale;

		private string mstrViewToPlot;

		private object[] madecPaperMarginLowerLeft;

		private double[] madblPaperMarginLowerLeft;

		private object[] madecPaperMarginUpperRight;

		private double[] madblPaperMarginUpperRight;

		private object mdecPaperWidth;

		private double mdblPaperWidth;

		private object mdecPaperHeight;

		private double mdblPaperHeight;

		private object[] madecWindowToPlotLowerLeft;

		private double[] madblWindowToPlotLowerLeft;

		private object[] madecWindowToPlotUpperRight;

		private double[] madblWindowToPlotUpperRight;

		private object mdecCustomScaleNumerator;

		private double mdblCustomScaleNumerator;

		private object mdecCustomScaleDenominator;

		private double mdblCustomScaleDenominator;

		private bool mblnUpdatePaper;

		private bool mblnZoomToPaperOnUpdate;

		private bool mblnInitializing;

		private bool mblnPrevPlotInit;

		private object mdecScaleFactor;

		private double mdblScaleFactor;

		private int mlngShadePlotMode;

		private string mstrShadePlotMode;

		private int mlngShadePlotResolutionLevel;

		private string mstrShadePlotResolutionLevel;

		private int mlngShadePlotCustomDPI;

		private object[] madecPaperImageOrigin;

		private double[] madblPaperImageOrigin;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				PlotViewportBorders = ((1 & mlngFlags70) == 1);
				ShowPlotStyles = ((2 & mlngFlags70) == 2);
				CenterPlot = ((4 & mlngFlags70) == 4);
				PlotHidden = ((8 & mlngFlags70) == 8);
				UseStandardScale = ((0x10 & mlngFlags70) == 16);
				PlotWithPlotStyles = ((0x20 & mlngFlags70) == 32);
				ScaleLineweights = ((0x40 & mlngFlags70) == 64);
				PlotWithLineweights = ((0x80 & mlngFlags70) == 128);
				PlotViewportsFirst = ((0x200 & mlngFlags70) == 512);
				FriendLetModelType = ((0x400 & mlngFlags70) == 1024);
				FriendLetUpdatePaper = ((0x800 & mlngFlags70) == 2048);
				FriendLetZoomToPaperOnUpdate = ((0x1000 & mlngFlags70) == 4096);
				FriendLetInitializing = ((0x2000 & mlngFlags70) == 8192);
				FriendLetPrevPlotInit = ((0x4000 & mlngFlags70) == 16384);
				mblnFriendLetFlags = false;
			}
		}

		internal bool FriendLetModelType
		{
			set
			{
				mblnModelType = value;
				InternCalcFlags70();
			}
		}

		internal object FriendLetPaperMarginLowerLeft
		{
			set
			{
				ref object[] reference = ref madecPaperMarginLowerLeft;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblPaperMarginLowerLeft;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetPaperMarginUpperRight
		{
			set
			{
				ref object[] reference = ref madecPaperMarginUpperRight;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblPaperMarginUpperRight;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetPaperWidth
		{
			set
			{
				ref object rvarValueDec = ref mdecPaperWidth;
				ref double reference = ref mdblPaperWidth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetPaperHeight
		{
			set
			{
				ref object rvarValueDec = ref mdecPaperHeight;
				ref double reference = ref mdblPaperHeight;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetWindowToPlotLowerLeft
		{
			set
			{
				ref object[] reference = ref madecWindowToPlotLowerLeft;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblWindowToPlotLowerLeft;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetWindowToPlotUpperRight
		{
			set
			{
				ref object[] reference = ref madecWindowToPlotUpperRight;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblWindowToPlotUpperRight;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetCustomScaleNumerator
		{
			set
			{
				ref object rvarValueDec = ref mdecCustomScaleNumerator;
				ref double reference = ref mdblCustomScaleNumerator;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetCustomScaleDenominator
		{
			set
			{
				ref object rvarValueDec = ref mdecCustomScaleDenominator;
				ref double reference = ref mdblCustomScaleDenominator;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal bool FriendLetUpdatePaper
		{
			set
			{
				mblnUpdatePaper = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetZoomToPaperOnUpdate
		{
			set
			{
				mblnZoomToPaperOnUpdate = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetInitializing
		{
			set
			{
				mblnInitializing = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetPrevPlotInit
		{
			set
			{
				mblnPrevPlotInit = value;
				InternCalcFlags70();
			}
		}

		internal object FriendLetScaleFactor
		{
			set
			{
				ref object rvarValueDec = ref mdecScaleFactor;
				ref double reference = ref mdblScaleFactor;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetPaperImageOrigin
		{
			set
			{
				ref object[] reference = ref madecPaperImageOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblPaperImageOrigin;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal int FriendLetShadePlotMode
		{
			set
			{
				if (value >= 0 && value <= 3)
				{
					mlngShadePlotMode = value;
					switch (mlngShadePlotMode)
					{
						case 0:
							mstrShadePlotMode = "Wie angezeigt";
							break;
						case 1:
							mstrShadePlotMode = "Drahtkörper";
							break;
						case 2:
							mstrShadePlotMode = "Verdeckt";
							break;
						case 3:
							mstrShadePlotMode = "Gerendert";
							break;
					}
				}
			}
		}

		internal string FriendGetShadePlotModeString => mstrShadePlotMode;

		internal int FriendLetShadePlotResolutionLevel
		{
			set
			{
				if (value >= 0 && value <= 5)
				{
					mlngShadePlotResolutionLevel = value;
					switch (mlngShadePlotResolutionLevel)
					{
						case 0:
							mstrShadePlotResolutionLevel = "Entwurf";
							break;
						case 1:
							mstrShadePlotResolutionLevel = "Vorschau";
							break;
						case 2:
							mstrShadePlotResolutionLevel = "Normal";
							break;
						case 3:
							mstrShadePlotResolutionLevel = "Präsentation";
							break;
						case 4:
							mstrShadePlotResolutionLevel = "Optimal";
							break;
						case 5:
							mstrShadePlotResolutionLevel = "Benutzerdefiniert";
							break;
					}
				}
			}
		}

		internal string FriendGetShadePlotResolutionLevelString => mstrShadePlotResolutionLevel;

		internal int FriendLetShadePlotCustomDPI
		{
			set
			{
				if (value >= 100 && value <= 32767)
				{
					mlngShadePlotCustomDPI = value;
				}
			}
		}

		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
				base.FriendLetNodeText = mstrName;
			}
		}

		public string CanonicalMediaName
		{
			get
			{
				return mstrCanonicalMediaName;
			}
			set
			{
				mstrCanonicalMediaName = value;
			}
		}

		public bool CenterPlot
		{
			get
			{
				return mblnCenterPlot;
			}
			set
			{
				mblnCenterPlot = value;
				InternCalcFlags70();
			}
		}

		public string ConfigName
		{
			get
			{
				return mstrConfigName;
			}
			set
			{
				mstrConfigName = value;
			}
		}

		public bool ModelType => mblnModelType;

		public Enums.AcPlotPaperUnits PaperUnits
		{
			get
			{
				return mnumPaperUnits;
			}
			set
			{
				mnumPaperUnits = value;
			}
		}

		public bool PlotHidden
		{
			get
			{
				return mblnPlotHidden;
			}
			set
			{
				mblnPlotHidden = value;
				InternCalcFlags70();
			}
		}

		public object PlotOrigin
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecPlotOrigin, madblPlotOrigin));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecPlotOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblPlotOrigin;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadPlotConfiguration", dstrErrMsg);
				}
			}
		}

		public Enums.AcPlotRotation PlotRotation
		{
			get
			{
				return mnumPlotRotation;
			}
			set
			{
				mnumPlotRotation = value;
			}
		}

		public Enums.AcPlotType PlotType
		{
			get
			{
				return mnumPlotType;
			}
			set
			{
				mnumPlotType = value;
			}
		}

		public bool PlotViewportBorders
		{
			get
			{
				return mblnPlotViewportBorders;
			}
			set
			{
				mblnPlotViewportBorders = value;
				InternCalcFlags70();
			}
		}

		public bool PlotViewportsFirst
		{
			get
			{
				return mblnPlotViewportsFirst;
			}
			set
			{
				mblnPlotViewportsFirst = value;
				InternCalcFlags70();
			}
		}

		public bool PlotWithLineweights
		{
			get
			{
				return mblnPlotWithLineweights;
			}
			set
			{
				mblnPlotWithLineweights = value;
				InternCalcFlags70();
			}
		}

		public bool PlotWithPlotStyles
		{
			get
			{
				return mblnPlotWithPlotStyles;
			}
			set
			{
				mblnPlotWithPlotStyles = value;
				InternCalcFlags70();
			}
		}

		public bool ScaleLineweights
		{
			get
			{
				return mblnScaleLineweights;
			}
			set
			{
				mblnScaleLineweights = value;
				InternCalcFlags70();
			}
		}

		public int ShadePlotMode => mlngShadePlotMode;

		public int ShadePlotResolutionLevel => mlngShadePlotResolutionLevel;

		public int ShadePlotCustomDPI => mlngShadePlotCustomDPI;

		public bool ShowPlotStyles
		{
			get
			{
				return mblnShowPlotStyles;
			}
			set
			{
				mblnShowPlotStyles = value;
				InternCalcFlags70();
			}
		}

		public Enums.AcPlotScale StandardScale
		{
			get
			{
				return mnumStandardScale;
			}
			set
			{
				mnumStandardScale = value;
			}
		}

		public string StyleSheet
		{
			get
			{
				return mstrStyleSheet;
			}
			set
			{
				mstrStyleSheet = value;
			}
		}

		public bool UseStandardScale
		{
			get
			{
				return mblnUseStandardScale;
			}
			set
			{
				mblnUseStandardScale = value;
				InternCalcFlags70();
			}
		}

		public string ViewToPlot
		{
			get
			{
				return mstrViewToPlot;
			}
			set
			{
				mstrViewToPlot = value;
			}
		}

		public object PaperMarginLowerLeft => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecPaperMarginLowerLeft, madblPaperMarginLowerLeft));

		public object PaperMarginUpperRight => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecPaperMarginUpperRight, madblPaperMarginUpperRight));

		public object PaperWidth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPaperWidth), mdblPaperWidth));

		public object PaperHeight => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPaperHeight), mdblPaperHeight));

		public object WindowToPlotLowerLeft => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecWindowToPlotLowerLeft, madblWindowToPlotLowerLeft));

		public object WindowToPlotUpperRight => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecWindowToPlotUpperRight, madblWindowToPlotUpperRight));

		public object CustomScaleNumerator => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCustomScaleNumerator), mdblCustomScaleNumerator));

		public object CustomScaleDenominator => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCustomScaleDenominator), mdblCustomScaleDenominator));

		public bool UpdatePaper => mblnUpdatePaper;

		public bool ZoomToPaperOnUpdate => mblnZoomToPaperOnUpdate;

		public bool Initializing => mblnInitializing;

		public bool PrevPlotInit => mblnPrevPlotInit;

		public object ScaleFactor => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecScaleFactor), mdblScaleFactor));

		public object PaperImageOrigin => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecPaperImageOrigin, madblPaperImageOrigin));

		public string SuperiorObjectName => mstrSuperiorObjectName;

		public int Flags70 => mlngFlags70;

		public AcadPlotConfiguration()
		{
			madecPlotOrigin = new object[2];
			madblPlotOrigin = new double[2];
			madecPaperMarginLowerLeft = new object[2];
			madblPaperMarginLowerLeft = new double[2];
			madecPaperMarginUpperRight = new object[2];
			madblPaperMarginUpperRight = new double[2];
			madecWindowToPlotLowerLeft = new object[2];
			madblWindowToPlotLowerLeft = new double[2];
			madecWindowToPlotUpperRight = new object[2];
			madblWindowToPlotUpperRight = new double[2];
			madecPaperImageOrigin = new object[2];
			madblPaperImageOrigin = new double[2];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 225;
			base.FriendLetNodeImageDisabledID = 226;
			base.FriendLetNodeName = "Plotstil";
			base.FriendLetNodeText = "Plotstil";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblPlotOrigin[0] = hwpDxf_Vars.padblPlotOrigin[0];
			madblPlotOrigin[1] = hwpDxf_Vars.padblPlotOrigin[1];
			madblPaperMarginLowerLeft[0] = hwpDxf_Vars.padblPaperMarginLowerLeft[0];
			madblPaperMarginLowerLeft[1] = hwpDxf_Vars.padblPaperMarginLowerLeft[1];
			madblPaperMarginUpperRight[0] = hwpDxf_Vars.padblPaperMarginUpperRight[0];
			madblPaperMarginUpperRight[1] = hwpDxf_Vars.padblPaperMarginUpperRight[1];
			mdblPaperWidth = hwpDxf_Vars.pdblPaperWidth;
			mdblPaperHeight = hwpDxf_Vars.pdblPaperHeight;
			madblWindowToPlotLowerLeft[0] = hwpDxf_Vars.padblWindowToPlotLowerLeft[0];
			madblWindowToPlotLowerLeft[1] = hwpDxf_Vars.padblWindowToPlotLowerLeft[1];
			madblWindowToPlotUpperRight[0] = hwpDxf_Vars.padblWindowToPlotUpperRight[0];
			madblWindowToPlotUpperRight[1] = hwpDxf_Vars.padblWindowToPlotUpperRight[1];
			mdblCustomScaleNumerator = hwpDxf_Vars.pdblCustomScaleNumerator;
			mdblCustomScaleDenominator = hwpDxf_Vars.pdblCustomScaleDenominator;
			mdblScaleFactor = hwpDxf_Vars.pdblPaperScaleFactor;
			madblPaperImageOrigin[0] = hwpDxf_Vars.padblPaperImageOrigin[0];
			madblPaperImageOrigin[1] = hwpDxf_Vars.padblPaperImageOrigin[1];
			mstrName = hwpDxf_Vars.pstrName;
			mstrCanonicalMediaName = hwpDxf_Vars.pstrCanonicalMediaName;
			mblnCenterPlot = hwpDxf_Vars.pblnCenterPlot;
			mstrConfigName = InternGetConfigName();
			mblnModelType = hwpDxf_Vars.pblnModelType;
			mnumPaperUnits = hwpDxf_Vars.pnumPaperUnits;
			mblnPlotHidden = hwpDxf_Vars.pblnPlotHidden;
			mnumPlotRotation = hwpDxf_Vars.pnumPlotRotation;
			mnumPlotType = hwpDxf_Vars.pnumPlotType;
			mblnPlotViewportBorders = hwpDxf_Vars.pblnPlotViewportBorders;
			mblnPlotViewportsFirst = hwpDxf_Vars.pblnPlotViewportsFirst;
			mblnPlotWithLineweights = hwpDxf_Vars.pblnPlotWithLineweights;
			mblnPlotWithPlotStyles = hwpDxf_Vars.pblnPlotWithPlotStyles;
			mblnScaleLineweights = hwpDxf_Vars.pblnScaleLineweights;
			mblnShowPlotStyles = hwpDxf_Vars.pblnShowPlotStyles;
			mnumStandardScale = hwpDxf_Vars.pnumStandardScale;
			mstrStyleSheet = hwpDxf_Vars.pstrStyleSheet;
			mblnUseStandardScale = hwpDxf_Vars.pblnUseStandardScale;
			mstrViewToPlot = hwpDxf_Vars.pstrViewToPlot;
			FriendLetShadePlotMode = hwpDxf_Vars.plngShadePlotMode;
			FriendLetShadePlotResolutionLevel = hwpDxf_Vars.plngShadePlotResolutionLevel;
			mlngShadePlotCustomDPI = hwpDxf_Vars.plngShadePlotCustomDPI;
			mblnUpdatePaper = hwpDxf_Vars.pblnUpdatePaper;
			mblnZoomToPaperOnUpdate = hwpDxf_Vars.pblnZoomToPaperOnUpdate;
			mblnInitializing = hwpDxf_Vars.pblnInitializing;
			mblnPrevPlotInit = hwpDxf_Vars.pblnPrevPlotInit;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "PLOTCONFIGURATION";
			mstrSuperiorObjectName = "AcDbPlotSettings";
			base.FriendLetObjectName = "AcDbPlotSettings";
		}

		private string InternGetConfigName()
		{
			object dobjPrinter2 = default(object);
			try
			{
				dobjPrinter2 = null;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
			}
			string dstrConfigName = default(string);
			if (dobjPrinter2 != null)
			{
				dstrConfigName = Conversions.ToString(NewLateBinding.LateGet(dobjPrinter2, null, "DeviceName", new object[0], null, null, null));
			}
			if (Operators.CompareString(dstrConfigName, null, TextCompare: false) == 0)
			{
				dstrConfigName = hwpDxf_Vars.pstrConfigName;
			}
			string InternGetConfigName = dstrConfigName;
			dobjPrinter2 = null;
			return InternGetConfigName;
		}

		~AcadPlotConfiguration()
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

		public void CopyFrom(AcadPlotConfiguration vobjPlotConfig)
		{
		}

		public object GetCanonicalMediaNames()
		{
			object GetCanonicalMediaNames = default(object);
			return GetCanonicalMediaNames;
		}

		public void GetCustomScale(ref object rvarNumerator, ref object rvarDenominator)
		{
		}

		public string GetLocaleMediaName(string vstrName)
		{
			string GetLocaleMediaName = default(string);
			return GetLocaleMediaName;
		}

		public void GetPaperMargins(ref object rvarLowerLeft, ref object rvarUpperRight)
		{
		}

		public void GetPaperSize(ref object rvarWidth, ref object rvarHeight)
		{
		}

		public object GetPlotDeviceNames()
		{
			object GetPlotDeviceNames = default(object);
			return GetPlotDeviceNames;
		}

		public object GetPlotStyleTableNames()
		{
			object GetPlotStyleTableNames = default(object);
			return GetPlotStyleTableNames;
		}

		public void GetWindowToPlot(ref object rvarLowerLeft, ref object rvarUpperRight)
		{
		}

		public void RefreshPlotDeviceInfo()
		{
		}

		public void SetCustomScale(object vvarNumerator, object vvarDenominator)
		{
		}

		public void SetWindowToPlot(object vvarLowerLeft, object vvarUpperRight)
		{
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PlotViewportBorders, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ShowPlotStyles, 2, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(CenterPlot, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PlotHidden, 8, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(UseStandardScale, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PlotWithPlotStyles, 32, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ScaleLineweights, 64, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PlotWithLineweights, 128, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PlotViewportsFirst, 512, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ModelType, 1024, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(UpdatePaper, 2048, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ZoomToPaperOnUpdate, 4096, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Initializing, 8192, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PrevPlotInit, 16384, 0)));
			}
		}
	}
}
