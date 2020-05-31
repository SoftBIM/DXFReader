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
	public class AcadViewport : AcadAbstractView
	{
		private const string cstrClassName = "AcadViewport";

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private const int clngPerspectiveEnabled = 1;

		private const int clngFrontClipEnabled = 2;

		private const int clngBackClipEnabled = 4;

		private const int clngUCSFollowMode = 8;

		private const int clngFrontClipAtEye = 16;

		private const int clngUCSIconOn = 1;

		private const int clngUCSIconAtOrigin = 2;

		private bool mblnOpened;

		private object mdecDepth;

		private double mdblDepth;

		private object[] madecOrigin;

		private double[] madblOrigin;

		private Enums.AcOrthoView mnumUCSOrthographic;

		private object[] madecXVector;

		private double[] madblXVector;

		private object[] madecYVector;

		private double[] madblYVector;

		private int mlngArcSmoothness;

		private bool mblnFastZoomsEnabled;

		private bool mblnFrontClipAtEye;

		private bool mblnGridOn;

		private object mdecGridSpacingX;

		private double mdblGridSpacingX;

		private object mdecGridSpacingY;

		private double mdblGridSpacingY;

		private bool mblnIsometricSnapEnabled;

		private object[] madecLowerLeftCorner;

		private double[] madblLowerLeftCorner;

		private object[] madecSnapBasePoint;

		private double[] madblSnapBasePoint;

		private bool mblnSnapOn;

		private hwpDxf_Enums.SNAP_PAIR mnumSnapPair;

		private object mdecSnapRotationAngleDegree;

		private double mdblSnapRotationAngleDegree;

		private object mdecSnapSpacingX;

		private double mdblSnapSpacingX;

		private object mdecSnapSpacingY;

		private double mdblSnapSpacingY;

		private bool mblnUCSFollowMode;

		private bool mblnUCSIconAtOrigin;

		private bool mblnUCSIconOn;

		private bool mblnUCSSavedWithViewport;

		private object[] madecUpperRightCorner;

		private double[] madblUpperRightCorner;

		private int mlngFlags70;

		private int mlngFlags71;

		private int mlngFlags74;

		private double mdblAssociatedUcsObjectID;

		private double mdblOrthographicUcsObjectID;

		private bool mblnFriendLetFlags;

		private AcadSysVars mobjAcadSysVars;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				mobjAcadSysVars.FriendLetDocumentIndex = value;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				mobjAcadSysVars.FriendLetApplicationIndex = value;
			}
		}

		public AcadUCS AssociatedUcs
		{
			get
			{
				AcadUCS AssociatedUcs = default(AcadUCS);
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (UcsAssociatedToView)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblAssociatedUcsObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbUCSTableRecord", TextCompare: false) == 0)
					{
						AssociatedUcs = (AcadUCS)dobjAcadObject2;
					}
				}
				dobjAcadObject2 = null;
				return AssociatedUcs;
			}
		}

		public AcadUCS OrthographicUcs
		{
			get
			{
				AcadUCS OrthographicUcs = default(AcadUCS);
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (HasOrthographicUcs)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblOrthographicUcsObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbUCSTableRecord", TextCompare: false) == 0)
					{
						OrthographicUcs = (AcadUCS)dobjAcadObject2;
					}
				}
				dobjAcadObject2 = null;
				return OrthographicUcs;
			}
		}

		internal object FriendLetDepth
		{
			set
			{
				ref object rvarValueDec = ref mdecDepth;
				ref double reference = ref mdblDepth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal Enums.AcOrthoView FriendLetUCSOrthographic
		{
			set
			{
				mnumUCSOrthographic = value;
				if (mnumUCSOrthographic == Enums.AcOrthoView.acOvNone)
				{
					mdblOrthographicUcsObjectID = -1.0;
				}
			}
		}

		internal bool FriendLetFastZoomsEnabled
		{
			set
			{
				mblnFastZoomsEnabled = value;
			}
		}

		internal bool FriendLetFrontClipAtEye
		{
			set
			{
				mblnFrontClipAtEye = value;
				InternCalcFlags71();
			}
		}

		internal object FriendLetGridSpacingX
		{
			set
			{
				ref object rvarValueDec = ref mdecGridSpacingX;
				ref double reference = ref mdblGridSpacingX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetGridSpacingY
		{
			set
			{
				ref object rvarValueDec = ref mdecGridSpacingY;
				ref double reference = ref mdblGridSpacingY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal bool FriendLetIsometricSnapEnabled
		{
			set
			{
				mblnIsometricSnapEnabled = value;
			}
		}

		internal object FriendLetLowerLeftCorner
		{
			set
			{
				ref object[] reference = ref madecLowerLeftCorner;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblLowerLeftCorner;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal hwpDxf_Enums.SNAP_PAIR FriendLetSnapPair
		{
			set
			{
				mnumSnapPair = value;
			}
		}

		internal string FriendGetSnapPairString
		{
			get
			{
				switch (mnumSnapPair)
				{
					case hwpDxf_Enums.SNAP_PAIR.spLeft:
						return "Links";
					case hwpDxf_Enums.SNAP_PAIR.spTop:
						return "Oben";
					case hwpDxf_Enums.SNAP_PAIR.spRight:
						return "Rechts";
					default:
						{
							string dstrSnapPair = default(string);
							return dstrSnapPair;
						}
				}
			}
		}

		internal object FriendLetSnapSpacingX
		{
			set
			{
				ref object rvarValueDec = ref mdecSnapSpacingX;
				ref double reference = ref mdblSnapSpacingX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetSnapSpacingY
		{
			set
			{
				ref object rvarValueDec = ref mdecSnapSpacingY;
				ref double reference = ref mdblSnapSpacingY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal bool FriendLetUCSFollowMode
		{
			set
			{
				mblnUCSFollowMode = value;
				InternCalcFlags71();
			}
		}

		internal bool FriendLetUCSSavedWithViewport
		{
			set
			{
				mblnUCSSavedWithViewport = value;
			}
		}

		internal object FriendLetUpperRightCorner
		{
			set
			{
				ref object[] reference = ref madecUpperRightCorner;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblUpperRightCorner;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = (value & -65);
				base.FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				base.FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		internal int FriendLetFlags71
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags71 = value;
				base.FriendLetPerspectiveEnabled = ((1 & mlngFlags71) == 1);
				base.FriendLetFrontClipEnabled = ((2 & mlngFlags71) == 2);
				base.FriendLetBackClipEnabled = ((4 & mlngFlags71) == 4);
				FriendLetUCSFollowMode = ((8 & mlngFlags71) == 8);
				FriendLetFrontClipAtEye = ((0x10 & mlngFlags71) == 16);
				mblnFriendLetFlags = false;
			}
		}

		internal int FriendLetFlags74
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags74 = value;
				UCSIconOn = ((1 & mlngFlags74) == 1);
				UCSIconAtOrigin = ((2 & mlngFlags74) == 2);
				mblnFriendLetFlags = false;
			}
		}

		internal double FriendLetAssociatedUcsObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblAssociatedUcsObjectID = value;
				}
			}
		}

		internal double FriendLetOrthographicUcsObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblOrthographicUcsObjectID = value;
				}
			}
		}

		public object Depth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecDepth), mdblDepth));

		public object Origin
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecOrigin, madblOrigin));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblOrigin;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
				}
			}
		}

		public Enums.AcOrthoView UCSOrthographic => mnumUCSOrthographic;

		public object XVector
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecXVector, madblXVector));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecXVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblXVector;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
				}
			}
		}

		public object YVector
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecYVector, madblYVector));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecYVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblYVector;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
				}
			}
		}

		public int ArcSmoothness
		{
			get
			{
				return mlngArcSmoothness;
			}
			set
			{
				mlngArcSmoothness = value;
			}
		}

		public bool FastZoomsEnabled => mblnFastZoomsEnabled;

		public bool FrontClipAtEye => mblnFrontClipAtEye;

		public bool GridOn
		{
			get
			{
				return mblnGridOn;
			}
			set
			{
				mblnGridOn = value;
			}
		}

		public object GridSpacingX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecGridSpacingX), mdblGridSpacingX));

		public object GridSpacingY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecGridSpacingY), mdblGridSpacingY));

		public bool IsometricSnapEnabled => mblnIsometricSnapEnabled;

		public object LowerLeftCorner => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecLowerLeftCorner, madblLowerLeftCorner));

		public object SnapBasePoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecSnapBasePoint, madblSnapBasePoint));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecSnapBasePoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblSnapBasePoint;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
				}
			}
		}

		public bool SnapOn
		{
			get
			{
				return mblnSnapOn;
			}
			set
			{
				mblnSnapOn = value;
			}
		}

		public int SnapPair => (int)mnumSnapPair;

		public object SnapRotationAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecSnapRotationAngleDegree), mdblSnapRotationAngleDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecSnapRotationAngleDegree;
				ref double reference = ref mdblSnapRotationAngleDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
				}
			}
		}

		public object SnapRotationAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(SnapRotationAngleDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadViewport", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblSnapRotationAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public object SnapSpacingX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecSnapSpacingX), mdblSnapSpacingX));

		public object SnapSpacingY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecSnapSpacingY), mdblSnapSpacingY));

		public bool UCSFollowMode => mblnUCSFollowMode;

		public bool UCSIconAtOrigin
		{
			get
			{
				return mblnUCSIconAtOrigin;
			}
			set
			{
				mblnUCSIconAtOrigin = value;
			}
		}

		public bool UCSIconOn
		{
			get
			{
				return mblnUCSIconOn;
			}
			set
			{
				mblnUCSIconOn = value;
			}
		}

		public bool UCSSavedWithViewport => mblnUCSSavedWithViewport;

		public object UpperRightCorner => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecUpperRightCorner, madblUpperRightCorner));

		public int Flags70 => mlngFlags70;

		public int Flags71 => mlngFlags71;

		public int Flags74 => mlngFlags74;

		public double AssociatedUcsObjectID => mdblAssociatedUcsObjectID;

		public string AssociatedUcsReference
		{
			get
			{
				if (UcsAssociatedToView)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblAssociatedUcsObjectID);
				}
				return null;
			}
		}

		public double OrthographicUcsObjectID => mdblOrthographicUcsObjectID;

		public string OrthographicUcsReference
		{
			get
			{
				if (HasOrthographicUcs)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblOrthographicUcsObjectID);
				}
				return null;
			}
		}

		public bool UcsAssociatedToView => mdblAssociatedUcsObjectID > 0.0;

		public bool HasOrthographicUcs => (mnumUCSOrthographic != Enums.AcOrthoView.acOvNone) & (mdblOrthographicUcsObjectID > 0.0);

		public AcadViewport()
		{
			madecOrigin = new object[3];
			madblOrigin = new double[3];
			madecXVector = new object[3];
			madblXVector = new double[3];
			madecYVector = new object[3];
			madblYVector = new double[3];
			madecLowerLeftCorner = new object[2];
			madblLowerLeftCorner = new double[2];
			madecSnapBasePoint = new object[2];
			madblSnapBasePoint = new double[2];
			madecUpperRightCorner = new object[2];
			madblUpperRightCorner = new double[2];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 117;
			base.FriendLetNodeImageDisabledID = 118;
			base.FriendLetNodeName = "Ansichtsfenster";
			base.FriendLetNodeText = "Ansichtsfenster";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblDepth = hwpDxf_Vars.pdblDepth;
			madblOrigin[0] = hwpDxf_Vars.padblOrigin[0];
			madblOrigin[1] = hwpDxf_Vars.padblOrigin[1];
			madblOrigin[2] = hwpDxf_Vars.padblOrigin[2];
			madblXVector[0] = hwpDxf_Vars.padblXVector[0];
			madblXVector[1] = hwpDxf_Vars.padblXVector[1];
			madblXVector[2] = hwpDxf_Vars.padblXVector[2];
			madblYVector[0] = hwpDxf_Vars.padblYVector[0];
			madblYVector[1] = hwpDxf_Vars.padblYVector[1];
			madblYVector[2] = hwpDxf_Vars.padblYVector[2];
			mnumUCSOrthographic = hwpDxf_Vars.pnumUCSOrthographic;
			bool flag2 = false;
			mdblGridSpacingX = hwpDxf_Vars.pdblGridSpacingX;
			mdblGridSpacingY = hwpDxf_Vars.pdblGridSpacingY;
			madblLowerLeftCorner[0] = hwpDxf_Vars.padblLowerLeftCorner[0];
			madblLowerLeftCorner[1] = hwpDxf_Vars.padblLowerLeftCorner[1];
			madblSnapBasePoint[0] = hwpDxf_Vars.padblSnapBasePoint[0];
			madblSnapBasePoint[1] = hwpDxf_Vars.padblSnapBasePoint[1];
			mdblSnapRotationAngleDegree = hwpDxf_Vars.pdblSnapRotationAngleDegree;
			mdblSnapSpacingX = hwpDxf_Vars.pdblSnapSpacingX;
			mdblSnapSpacingY = hwpDxf_Vars.pdblSnapSpacingY;
			madblUpperRightCorner[0] = hwpDxf_Vars.padblUpperRightCorner[0];
			madblUpperRightCorner[1] = hwpDxf_Vars.padblUpperRightCorner[1];
			mlngArcSmoothness = hwpDxf_Vars.plngArcSmoothness;
			mblnFastZoomsEnabled = hwpDxf_Vars.pblnFastZoomsEnabled;
			mblnFrontClipAtEye = hwpDxf_Vars.pblnFrontClipAtEye;
			mblnGridOn = hwpDxf_Vars.pblnGridOn;
			mblnIsometricSnapEnabled = hwpDxf_Vars.pblnIsometricSnapEnabled;
			mblnSnapOn = hwpDxf_Vars.pblnSnapOn;
			mnumSnapPair = hwpDxf_Vars.pnumSnapPair;
			mblnUCSFollowMode = hwpDxf_Vars.pblnUCSFollowMode;
			mblnUCSIconAtOrigin = hwpDxf_Vars.pblnUCSIconAtOrigin;
			mblnUCSIconOn = hwpDxf_Vars.pblnUCSIconOn;
			mblnUCSSavedWithViewport = hwpDxf_Vars.pblnUCSSavedWithViewport;
			mdblAssociatedUcsObjectID = -1.0;
			mdblOrthographicUcsObjectID = -1.0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcFlags71();
			InternCalcFlags74();
			mobjAcadSysVars = new AcadSysVars();
			mobjAcadSysVars.FriendLetNodeParentID = base.NodeID;
			mobjAcadSysVars.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			mobjAcadSysVars.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			base.FriendLetDXFName = "VPORT";
			base.FriendLetObjectName = "AcDbViewportTableRecord";
		}

		~AcadViewport()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendOpen()
		{
			mobjAcadSysVars.FriendOpen(hwpDxf_Enums.REF_TYPE.rtViewport);
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadSysVars.FriendQuit();
				base.FriendQuit();
				mobjAcadSysVars = null;
				mblnOpened = false;
			}
		}

		public void GetGridSpacing(ref object rvarXSpacing, ref object rvarYSpacing)
		{
		}

		public void GetSnapSpacing(ref object rvarXSpacing, ref object rvarYSpacing)
		{
		}

		public void SetGridSpacing(object vvarXSpacing, object vvarYSpacing)
		{
		}

		public void SetSnapSpacing(object vvarXSpacing, object vvarYSpacing)
		{
		}

		public void SetView(AcadView vobjView)
		{
		}

		public void Split_Renamed(Enums.AcViewportSplitType vnumWins)
		{
		}

		internal AcadSysVar FriendFindVariable(string vstrName)
		{
			return mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName));
		}

		internal object FriendGetVariable(string vstrName)
		{
			return RuntimeHelpers.GetObjectValue(mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName)).Value);
		}

		internal void FriendSetVariable(string vstrName, object vvarValue)
		{
			object value = mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName)).Value;
			object[] obj = new object[1]
			{
			vvarValue
			};
			object[] array = obj;
			bool[] obj2 = new bool[1]
			{
			true
			};
			bool[] array2 = obj2;
			NewLateBinding.LateCall(value, null, "FriendSetValueSilent", obj, null, null, obj2, IgnoreReturn: true);
			if (array2[0])
			{
				vvarValue = RuntimeHelpers.GetObjectValue(array[0]);
			}
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(base.Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(base.Resolved, 32, 0)));
			}
		}

		private void InternCalcFlags71()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags71 = 0;
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.PerspectiveEnabled, 1, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.FrontClipEnabled, 2, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.BackClipEnabled, 4, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(UCSFollowMode, 8, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(FrontClipAtEye, 16, 0)));
			}
		}

		private void InternCalcFlags74()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags74 = 0;
				mlngFlags74 = Conversions.ToInteger(Operators.OrObject(mlngFlags74, Interaction.IIf(UCSIconOn, 1, 0)));
				mlngFlags74 = Conversions.ToInteger(Operators.OrObject(mlngFlags74, Interaction.IIf(UCSIconAtOrigin, 2, 0)));
			}
		}
	}

}
