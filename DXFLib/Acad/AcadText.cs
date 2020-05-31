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
	public class AcadText : AcadEntity
	{
		private const string cstrClassName = "AcadText";

		private bool mblnOpened;

		private string mstrSuperiorObjectName;

		private Enums.AcAlignment mnumAlignment;

		private object mdecHeight;

		private double mdblHeight;

		private Enums.AcHorizontalAlignment mnumHorizontalAlignment;

		private object[] madecInsertionPoint;

		private double[] madblInsertionPoint;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mdecObliqueAngleDegree;

		private double mdblObliqueAngleDegree;

		private object mdecRotationDegree;

		private double mdblRotationDegree;

		private object mdecScaleFactor;

		private double mdblScaleFactor;

		private double mdblTextStyleObjectID;

		private object[] madecTextAlignmentPoint;

		private double[] madblTextAlignmentPoint;

		private Enums.AcTextGenerationFlag mnumTextGenerationFlag;

		private string mstrTextString;

		private object mdecThickness;

		private double mdblThickness;

		private Enums.AcVerticalAlignment mnumVerticalAlignment;

		internal string FriendGetAlignmentString
		{
			get
			{
				switch (mnumAlignment)
				{
					case Enums.AcAlignment.acAlignmentLeft:
						return "Links Basislinie";
					case Enums.AcAlignment.acAlignmentCenter:
						return "Zentrum Basislinie";
					case Enums.AcAlignment.acAlignmentRight:
						return "Rechts Basislinie";
					case Enums.AcAlignment.acAlignmentAligned:
						return "Ausgerichtet";
					case Enums.AcAlignment.acAlignmentMiddle:
						return "Mitte";
					case Enums.AcAlignment.acAlignmentFit:
						return "Einpassen";
					case Enums.AcAlignment.acAlignmentTopLeft:
						return "Oben links";
					case Enums.AcAlignment.acAlignmentTopCenter:
						return "Oben zentriert";
					case Enums.AcAlignment.acAlignmentTopRight:
						return "Oben rechts";
					case Enums.AcAlignment.acAlignmentMiddleLeft:
						return "Mitte links";
					case Enums.AcAlignment.acAlignmentMiddleCenter:
						return "Mitte zentriert";
					case Enums.AcAlignment.acAlignmentMiddleRight:
						return "Mitte rechts";
					case Enums.AcAlignment.acAlignmentBottomLeft:
						return "Unten links";
					case Enums.AcAlignment.acAlignmentBottomCenter:
						return "Unten zentriert";
					case Enums.AcAlignment.acAlignmentBottomRight:
						return "Unten rechts";
					default:
						{
							string dstrAlignment = default(string);
							return dstrAlignment;
						}
				}
			}
		}

		internal string FriendGetHorizontalAlignmentString
		{
			get
			{
				switch (mnumHorizontalAlignment)
				{
					case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
						return "Links";
					case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
						return "Zentrum";
					case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
						return "Rechts";
					default:
						{
							string dstrHorizontalAlignment = default(string);
							return dstrHorizontalAlignment;
						}
				}
			}
		}

		internal string FriendGetVerticalAlignmentString
		{
			get
			{
				switch (mnumVerticalAlignment)
				{
					case Enums.AcVerticalAlignment.acVerticalAlignmentBaseline:
						return "Basislinie";
					case Enums.AcVerticalAlignment.acVerticalAlignmentBottom:
						return "Unten";
					case Enums.AcVerticalAlignment.acVerticalAlignmentMiddle:
						return "Mitte";
					case Enums.AcVerticalAlignment.acVerticalAlignmentTop:
						return "Oben";
					default:
						{
							string dstrVerticalAlignment = default(string);
							return dstrVerticalAlignment;
						}
				}
			}
		}

		public Enums.AcAlignment Alignment
		{
			get
			{
				return mnumAlignment;
			}
			set
			{
				InternSetAlignment(value);
			}
		}

		public bool Backward
		{
			get
			{
				return (Enums.AcTextGenerationFlag.acTextFlagBackward & mnumTextGenerationFlag) == Enums.AcTextGenerationFlag.acTextFlagBackward;
			}
			set
			{
				if (value)
				{
					mnumTextGenerationFlag |= Enums.AcTextGenerationFlag.acTextFlagBackward;
				}
				else
				{
					mnumTextGenerationFlag &= (Enums.AcTextGenerationFlag)(-3);
				}
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
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
			}
		}

		public Enums.AcHorizontalAlignment HorizontalAlignment
		{
			get
			{
				return mnumHorizontalAlignment;
			}
			set
			{
				InterSetHorizontalAlignment(value);
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
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
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
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
			}
		}

		public object ObliqueAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecObliqueAngleDegree), mdblObliqueAngleDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecObliqueAngleDegree;
				ref double reference = ref mdblObliqueAngleDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
			}
		}

		public object ObliqueAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(ObliqueAngleDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblObliqueAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
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
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblRotationDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public object ScaleFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecScaleFactor), mdblScaleFactor));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecScaleFactor;
				ref double reference = ref mdblScaleFactor;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
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
					hwpDxf_Functions.BkDXF_DebugPrint("AcadText: Textstil '" + value + "' konnte nicht gefunden werden.");
				}
				dobjAcadTextStyle2 = null;
			}
		}

		public object TextAlignmentPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecTextAlignmentPoint, madblTextAlignmentPoint));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecTextAlignmentPoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblTextAlignmentPoint;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
			}
		}

		public Enums.AcTextGenerationFlag TextGenerationFlag
		{
			get
			{
				return mnumTextGenerationFlag;
			}
			set
			{
				mnumTextGenerationFlag = value;
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

		public object Thickness
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecThickness), mdblThickness));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecThickness;
				ref double reference = ref mdblThickness;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadText", dstrErrMsg);
				}
			}
		}

		public bool UpsideDown
		{
			get
			{
				return (Enums.AcTextGenerationFlag.acTextFlagUpsideDown & mnumTextGenerationFlag) == Enums.AcTextGenerationFlag.acTextFlagUpsideDown;
			}
			set
			{
				if (value)
				{
					mnumTextGenerationFlag |= Enums.AcTextGenerationFlag.acTextFlagUpsideDown;
				}
				else
				{
					mnumTextGenerationFlag &= (Enums.AcTextGenerationFlag)(-5);
				}
			}
		}

		public Enums.AcVerticalAlignment VerticalAlignment
		{
			get
			{
				return mnumVerticalAlignment;
			}
			set
			{
				InterSetVerticalAlignment(value);
			}
		}

		public string SuperiorObjectName => mstrSuperiorObjectName;

		public AcadText()
		{
			madecInsertionPoint = new object[3];
			madblInsertionPoint = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			madecTextAlignmentPoint = new object[3];
			madblTextAlignmentPoint = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 235;
			base.FriendLetNodeImageDisabledID = 236;
			base.FriendLetNodeName = "Text";
			base.FriendLetNodeText = "Text";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			InternSetAlignment(hwpDxf_Vars.pnumAlignment);
			bool flag = false;
			mdblHeight = hwpDxf_Vars.pdblHeight;
			madblInsertionPoint[0] = hwpDxf_Vars.padblInsertionPoint[0];
			madblInsertionPoint[1] = hwpDxf_Vars.padblInsertionPoint[1];
			madblInsertionPoint[2] = hwpDxf_Vars.padblInsertionPoint[2];
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mdblObliqueAngleDegree = hwpDxf_Vars.pdblObliqueAngleDegree;
			mdblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
			mdblScaleFactor = hwpDxf_Vars.pdblScaleFactor;
			madblTextAlignmentPoint[0] = hwpDxf_Vars.padblTextAlignmentPoint[0];
			madblTextAlignmentPoint[1] = hwpDxf_Vars.padblTextAlignmentPoint[1];
			madblTextAlignmentPoint[2] = hwpDxf_Vars.padblTextAlignmentPoint[2];
			mdblThickness = hwpDxf_Vars.pdblThickness;
			mdblTextStyleObjectID = -1.0;
			mnumTextGenerationFlag = hwpDxf_Vars.pnumTextGenerationFlag;
			mstrTextString = hwpDxf_Vars.pstrTextString;
			base.FriendLetDXFName = "TEXT";
			mstrSuperiorObjectName = "AcDbText";
			base.FriendLetObjectName = "AcDbText";
			base.FriendLetEntityType = Enums.AcEntityName.acText;
		}

		~AcadText()
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

		private void InternSetAlignment(Enums.AcAlignment vnumAlignment)
		{
			mnumAlignment = vnumAlignment;
			switch (vnumAlignment)
			{
				case Enums.AcAlignment.acAlignmentLeft:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentCenter:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentRight:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentRight;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentAligned:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentAligned;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentMiddle:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentMiddle;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentFit:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentFit;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcAlignment.acAlignmentTopLeft:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentTop;
					break;
				case Enums.AcAlignment.acAlignmentTopCenter:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentTop;
					break;
				case Enums.AcAlignment.acAlignmentTopRight:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentRight;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentTop;
					break;
				case Enums.AcAlignment.acAlignmentMiddleLeft:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentMiddle;
					break;
				case Enums.AcAlignment.acAlignmentMiddleCenter:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentMiddle;
					break;
				case Enums.AcAlignment.acAlignmentMiddleRight:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentRight;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentMiddle;
					break;
				case Enums.AcAlignment.acAlignmentBottomLeft:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBottom;
					break;
				case Enums.AcAlignment.acAlignmentBottomCenter:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBottom;
					break;
				case Enums.AcAlignment.acAlignmentBottomRight:
					mnumHorizontalAlignment = Enums.AcHorizontalAlignment.acHorizontalAlignmentRight;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBottom;
					break;
			}
		}

		private void InterSetHorizontalAlignment(Enums.AcHorizontalAlignment vnumHorizontalAlignment)
		{
			mnumHorizontalAlignment = vnumHorizontalAlignment;
			switch (vnumHorizontalAlignment)
			{
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
					switch (mnumVerticalAlignment)
					{
						case Enums.AcVerticalAlignment.acVerticalAlignmentBaseline:
							mnumAlignment = Enums.AcAlignment.acAlignmentLeft;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentBottom:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomLeft;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentMiddle:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleLeft;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentTop:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopLeft;
							break;
					}
					break;
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
					switch (mnumVerticalAlignment)
					{
						case Enums.AcVerticalAlignment.acVerticalAlignmentBaseline:
							mnumAlignment = Enums.AcAlignment.acAlignmentCenter;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentBottom:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomCenter;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentMiddle:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleCenter;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentTop:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopCenter;
							break;
					}
					break;
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
					switch (mnumVerticalAlignment)
					{
						case Enums.AcVerticalAlignment.acVerticalAlignmentBaseline:
							mnumAlignment = Enums.AcAlignment.acAlignmentRight;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentBottom:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomRight;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentMiddle:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleRight;
							break;
						case Enums.AcVerticalAlignment.acVerticalAlignmentTop:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopRight;
							break;
					}
					break;
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentAligned:
					mnumAlignment = Enums.AcAlignment.acAlignmentAligned;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentMiddle:
					mnumAlignment = Enums.AcAlignment.acAlignmentMiddle;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
				case Enums.AcHorizontalAlignment.acHorizontalAlignmentFit:
					mnumAlignment = Enums.AcAlignment.acAlignmentFit;
					mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
					break;
			}
		}

		private void InterSetVerticalAlignment(Enums.AcVerticalAlignment vnumVerticalAlignment)
		{
			if ((mnumAlignment == Enums.AcAlignment.acAlignmentAligned) | (mnumAlignment == Enums.AcAlignment.acAlignmentMiddle) | (mnumAlignment == Enums.AcAlignment.acAlignmentFit))
			{
				mnumVerticalAlignment = Enums.AcVerticalAlignment.acVerticalAlignmentBaseline;
				return;
			}
			mnumVerticalAlignment = vnumVerticalAlignment;
			switch (vnumVerticalAlignment)
			{
				case Enums.AcVerticalAlignment.acVerticalAlignmentBaseline:
					switch (mnumHorizontalAlignment)
					{
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
							mnumAlignment = Enums.AcAlignment.acAlignmentLeft;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
							mnumAlignment = Enums.AcAlignment.acAlignmentCenter;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
							mnumAlignment = Enums.AcAlignment.acAlignmentRight;
							break;
					}
					break;
				case Enums.AcVerticalAlignment.acVerticalAlignmentBottom:
					switch (mnumHorizontalAlignment)
					{
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomLeft;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomCenter;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
							mnumAlignment = Enums.AcAlignment.acAlignmentBottomRight;
							break;
					}
					break;
				case Enums.AcVerticalAlignment.acVerticalAlignmentMiddle:
					switch (mnumHorizontalAlignment)
					{
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleLeft;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleCenter;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
							mnumAlignment = Enums.AcAlignment.acAlignmentMiddleRight;
							break;
					}
					break;
				case Enums.AcVerticalAlignment.acVerticalAlignmentTop:
					switch (mnumHorizontalAlignment)
					{
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopLeft;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentCenter:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopCenter;
							break;
						case Enums.AcHorizontalAlignment.acHorizontalAlignmentRight:
							mnumAlignment = Enums.AcAlignment.acAlignmentTopRight;
							break;
					}
					break;
			}
		}
	}
}
