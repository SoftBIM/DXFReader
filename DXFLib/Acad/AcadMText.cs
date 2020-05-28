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
	public class AcadMText : AcadEntity
	{
		private const string cstrClassName = "AcadMText";

		private bool mblnOpened;

		private Enums.AcAttachmentPoint mnumAttachmentPoint;

		private object mdecActualHeight;

		private double mdblActualHeight;

		private object mdecActualWidth;

		private double mdblActualWidth;

		private object[] madecDirection;

		private double[] madblDirection;

		private Enums.AcDrawingDirection mnumDrawingDirection;

		private object mdecHeight;

		private double mdblHeight;

		private object[] madecInsertionPoint;

		private double[] madblInsertionPoint;

		private object mdecLineSpacingFactor;

		private double mdblLineSpacingFactor;

		private Enums.AcLineSpacingStyle mnumLineSpacingStyle;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mdecRotationDegree;

		private double mdblRotationDegree;

		private double mdblTextStyleObjectID;

		private string mstrTextString;

		private object mdecWidth;

		private double mdblWidth;

		private int mlngBackgroundMode;

		private Enums.AcColor mnumBackgroundFillColor;

		private int mlngBackgroundFillRGB;

		private object mdecBackgroundBorderOffsetFactor;

		private object mdblBackgroundBorderOffsetFactor;

		private int mlngBackgroundCode441;

		internal object FriendLetActualHeight
		{
			set
			{
				ref object rvarValueDec = ref mdecActualHeight;
				ref double reference = ref mdblActualHeight;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetActualWidth
		{
			set
			{
				ref object rvarValueDec = ref mdecActualWidth;
				ref double reference = ref mdblActualWidth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetDirection
		{
			set
			{
				ref object[] reference = ref madecDirection;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblDirection;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		public Enums.AcAttachmentPoint AttachmentPoint
		{
			get
			{
				return mnumAttachmentPoint;
			}
			set
			{
				mnumAttachmentPoint = value;
			}
		}

		public object ActualHeight => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecActualHeight), mdblActualHeight));

		public object ActualWidth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecActualWidth), mdblActualWidth));

		public object Direction
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecDirection, madblDirection));
			}
			set
			{
				FriendLetDirection = RuntimeHelpers.GetObjectValue(value);
			}
		}

		public Enums.AcDrawingDirection DrawingDirection
		{
			get
			{
				return mnumDrawingDirection;
			}
			set
			{
				mnumDrawingDirection = value;
			}
		}

		public object Height
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecHeight), mdblHeight));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecHeight;
				ref double reference = ref mdblHeight;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public object InsertionPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecInsertionPoint, madblInsertionPoint));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecInsertionPoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblInsertionPoint;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public object LineSpacingFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecLineSpacingFactor), mdblLineSpacingFactor));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecLineSpacingFactor;
				ref double reference = ref mdblLineSpacingFactor;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public Enums.AcLineSpacingStyle LineSpacingStyle
		{
			get
			{
				return mnumLineSpacingStyle;
			}
			set
			{
				mnumLineSpacingStyle = value;
			}
		}

		public object Normal
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecNormal, madblNormal));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecNormal;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblNormal;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public object RotationDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRotationDegree), mdblRotationDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecRotationDegree;
				ref double reference = ref mdblRotationDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public object Rotation
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(RotationDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblRotationDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public double TextStyleObjectID => mdblTextStyleObjectID;

		public string TextStyleReference
		{
			get
			{
				if (mdblTextStyleObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblTextStyleObjectID);
				}
				return null;
			}
		}

		public string TextStyle
		{
			get
			{
				string TextStyle = default(string);
				AcadTextStyle dobjAcadTextStyle2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (mdblTextStyleObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblTextStyleObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbTextStyleTableRecord", TextCompare: false) == 0)
					{
						dobjAcadTextStyle2 = (AcadTextStyle)dobjAcadObject2;
						TextStyle = dobjAcadTextStyle2.Name;
					}
				}
				dobjAcadTextStyle2 = null;
				dobjAcadObject2 = null;
				return TextStyle;
			}
			set
			{
				AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)base.Database.TextStyles.FriendGetItem(value);
				if (dobjAcadTextStyle2 != null)
				{
					mdblTextStyleObjectID = dobjAcadTextStyle2.ObjectID;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint("AcadMText: Textstil '" + value + "' konnte nicht gefunden werden.");
				}
				dobjAcadTextStyle2 = null;
			}
		}

		public string TextString
		{
			get
			{
				return mstrTextString;
			}
			set
			{
				mstrTextString = value;
			}
		}

		public object Width
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecWidth), mdblWidth));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecWidth;
				ref double reference = ref mdblWidth;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public int BackgroundMode
		{
			get
			{
				return mlngBackgroundMode;
			}
			set
			{
				if (Operators.CompareString(base.Document.AcadVer, "AC1018", TextCompare: false) >= 0 && (value == 0 || value == 1 || value == 2 || value == 3))
				{
					mlngBackgroundMode = value;
				}
			}
		}

		public Enums.AcColor BackgroundFillColor
		{
			get
			{
				return mnumBackgroundFillColor;
			}
			set
			{
				if (Operators.CompareString(base.Document.AcadVer, "AC1018", TextCompare: false) >= 0 && (double)value > 0.0 && (double)value <= 256.0 && mnumBackgroundFillColor != value && mlngBackgroundFillRGB == hwpDxf_Vars.plngBackgroundFillRGB)
				{
					mnumBackgroundFillColor = value;
				}
			}
		}

		public int BackgroundFillRGB
		{
			get
			{
				return mlngBackgroundFillRGB;
			}
			set
			{
				if (Operators.CompareString(base.Document.AcadVer, "AC1018", TextCompare: false) < 0 || value < hwpDxf_Vars.plngBackgroundFillRGB || mlngBackgroundFillRGB == value)
				{
					return;
				}
				mlngBackgroundFillRGB = value;
				if (mlngBackgroundFillRGB == hwpDxf_Vars.plngBackgroundFillRGB)
				{
					if (mnumBackgroundFillColor == Enums.AcColor.acByLayer)
					{
						mnumBackgroundFillColor = hwpDxf_Vars.pnumBackgroundFillColor;
					}
				}
				else
				{
					mnumBackgroundFillColor = Enums.AcColor.acByLayer;
				}
			}
		}

		public object BackgroundBorderOffsetFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecBackgroundBorderOffsetFactor), RuntimeHelpers.GetObjectValue(mdblBackgroundBorderOffsetFactor)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (Operators.CompareString(base.Document.AcadVer, "AC1018", TextCompare: false) >= 0 && !hwpDxf_Functions.BkDXF_SetValueReal(ref mdecBackgroundBorderOffsetFactor, ref mdblBackgroundBorderOffsetFactor, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadMText", dstrErrMsg);
				}
			}
		}

		public int BackgroundCode441
		{
			get
			{
				return mlngBackgroundMode;
			}
			set
			{
				if (Operators.CompareString(base.Document.AcadVer, "AC1018", TextCompare: false) >= 0)
				{
					mlngBackgroundMode = value;
				}
			}
		}

		public AcadMText()
		{
			madecDirection = new object[3];
			madblDirection = new double[3];
			madecInsertionPoint = new object[3];
			madblInsertionPoint = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 199;
			base.FriendLetNodeImageDisabledID = 200;
			base.FriendLetNodeName = "Absatztext";
			base.FriendLetNodeText = "Absatztext";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblActualHeight = hwpDxf_Vars.pdblActualHeight;
			mdblActualWidth = hwpDxf_Vars.pdblActualWidth;
			madblDirection[0] = hwpDxf_Vars.padblMTextDirection[0];
			madblDirection[1] = hwpDxf_Vars.padblMTextDirection[1];
			madblDirection[2] = hwpDxf_Vars.padblMTextDirection[2];
			mdblHeight = hwpDxf_Vars.pdblMTextHeight;
			madblInsertionPoint[0] = hwpDxf_Vars.padblInsertionPoint[0];
			madblInsertionPoint[1] = hwpDxf_Vars.padblInsertionPoint[1];
			madblInsertionPoint[2] = hwpDxf_Vars.padblInsertionPoint[2];
			mdblLineSpacingFactor = hwpDxf_Vars.pdblLineSpacingFactor;
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mdblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
			mdblWidth = hwpDxf_Vars.pdblWidth;
			mnumAttachmentPoint = hwpDxf_Vars.pnumAttachmentPoint;
			mnumDrawingDirection = hwpDxf_Vars.pnumDrawingDirection;
			mnumLineSpacingStyle = hwpDxf_Vars.pnumLineSpacingStyle;
			mdblTextStyleObjectID = -1.0;
			mstrTextString = hwpDxf_Vars.pstrTextString;
			mlngBackgroundMode = hwpDxf_Vars.plngBackgroundMode;
			mnumBackgroundFillColor = hwpDxf_Vars.pnumBackgroundFillColor;
			mlngBackgroundFillRGB = hwpDxf_Vars.plngBackgroundFillRGB;
			mlngBackgroundCode441 = hwpDxf_Vars.plngBackgroundCode441;
			bool flag2 = false;
			mdblBackgroundBorderOffsetFactor = hwpDxf_Vars.pdblBackgroundBorderOffsetFactor;
			base.FriendLetDXFName = "MTEXT";
			base.FriendLetObjectName = "AcDbMText";
			base.FriendLetEntityType = Enums.AcEntityName.acMtext;
		}

		~AcadMText()
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
	}
}
