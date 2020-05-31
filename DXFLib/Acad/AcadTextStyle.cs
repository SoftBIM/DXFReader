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
	public class AcadTextStyle : AcadTableRecord
	{
		private const string cstrClassName = "AcadTextStyle";

		private const int clngIsShapeFile = 1;

		private const int clngIsVertical = 4;

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private string mstrBigFontFile;

		private bool mblnDependend;

		private string mstrFontFile;

		private object mdecHeight;

		private double mdblHeight;

		private bool mblnIsShapeFile;

		private bool mblnIsVertical;

		private object mdecLastHeight;

		private double mdblLastHeight;

		private object mdecObliqueAngleDegree;

		private double mdblObliqueAngleDegree;

		private bool mblnResolved;

		private Enums.AcTextGenerationFlag mnumTextGenerationFlag;

		private object mdecWidth;

		private double mdblWidth;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		internal bool FriendLetDependend
		{
			set
			{
				mblnDependend = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetResolved
		{
			set
			{
				mblnResolved = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetIsShapeFile
		{
			set
			{
				mblnIsShapeFile = value;
				InternCalcFlags70();
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = (value & -65);
				FriendLetIsShapeFile = ((1 & mlngFlags70) == 1);
				IsVertical = ((4 & mlngFlags70) == 4);
				FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
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

		public string BigFontFile
		{
			get
			{
				return mstrBigFontFile;
			}
			set
			{
				mstrBigFontFile = value;
			}
		}

		public bool Dependend => mblnDependend;

		public string FontFile
		{
			get
			{
				return mstrFontFile;
			}
			set
			{
				mstrFontFile = value;
				if (Operators.CompareString(base.Name, null, TextCompare: false) == 0)
				{
					string vstrFile = mstrFontFile;
					string nrstrPre = "";
					string nrstrPost = "";
					base.FriendLetNodeText = "<" + hwpDxf_Functions.BkDXF_SeperateFilePrefix(vstrFile, ref nrstrPre, ref nrstrPost) + ">";
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
					Information.Err().Raise(50000, "AcadTextStyle", dstrErrMsg);
				}
			}
		}

		public bool IsShapeFile => mblnIsShapeFile;

		public bool IsVertical
		{
			get
			{
				return mblnIsVertical;
			}
			set
			{
				mblnIsVertical = value;
				InternCalcFlags70();
			}
		}

		public object LastHeight
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecLastHeight), mdblLastHeight));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecLastHeight;
				ref double reference = ref mdblLastHeight;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadTextStyle", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadTextStyle", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadTextStyle", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblObliqueAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public bool Resolved => mblnResolved;

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
					Information.Err().Raise(50000, "AcadTextStyle", dstrErrMsg);
				}
			}
		}

		public int Flags70
		{
			get
			{
				return mlngFlags70;
			}
			set
			{
				FriendLetFlags70 = value;
			}
		}

		public AcadTextStyle()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 129;
			base.FriendLetNodeImageDisabledID = 130;
			base.FriendLetNodeName = "Textstil";
			base.FriendLetNodeText = "Textstil";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblHeight = hwpDxf_Vars.pdblHeight;
			mdblLastHeight = hwpDxf_Vars.pdblLastHeight;
			mdblObliqueAngleDegree = hwpDxf_Vars.pdblObliqueAngleDegree;
			mdblWidth = hwpDxf_Vars.pdblTextWidth;
			mstrBigFontFile = hwpDxf_Vars.pstrBigFontFile;
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mstrFontFile = hwpDxf_Vars.pstrFontFile;
			mblnIsShapeFile = hwpDxf_Vars.pblnIsShapeFile;
			mblnIsVertical = hwpDxf_Vars.pblnIsVertical;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mnumTextGenerationFlag = hwpDxf_Vars.pnumTextGenerationFlag;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "STYLE";
			base.FriendLetObjectName = "AcDbTextStyleTableRecord";
		}

		~AcadTextStyle()
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

		public void GetFont(string vstrTypeFace, bool vblnBold, bool vblnItalic, int vlngCharset, int vlngPitchAndFamily)
		{
		}

		public void SetFont(string vstrTypeFace, bool vblnBold, bool vblnItalic, int vlngCharset, int vlngPitchAndFamily)
		{
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsShapeFile, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsVertical, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Resolved, 32, 0)));
			}
		}
	}
}
