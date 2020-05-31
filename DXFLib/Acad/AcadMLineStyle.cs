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
	class AcadMLineStyle : AcadObject
	{
		private const string cstrClassName = "AcadMLineStyle";

		private const int clngFilled = 1;

		private const int clngShowMiters = 2;

		private const int clngStartSquareCap = 16;

		private const int clngStartInnerArcs = 32;

		private const int clngStartRoundCap = 64;

		private const int clngEndSquareCap = 256;

		private const int clngEndInnerArcs = 512;

		private const int clngEndRoundCap = 1024;

		private bool mblnOpened;

		private string mstrName;

		private string mstrDescription;

		private bool mblnFilled;

		private Enums.AcColor mnumColor;

		private object mdecStartAngleDegree;

		private double mdblStartAngleDegree;

		private bool mblnStartSquareCap;

		private bool mblnStartRoundCap;

		private bool mblnStartInnerArcs;

		private object mdecEndAngleDegree;

		private double mdblEndAngleDegree;

		private bool mblnEndSquareCap;

		private bool mblnEndRoundCap;

		private bool mblnEndInnerArcs;

		private bool mblnShowMiters;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		private int mlngIndex;

		private AcadMLineStyleElements mobjAcadMLineStyleElements;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				mobjAcadMLineStyleElements.FriendLetDatabaseIndex = value;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				mobjAcadMLineStyleElements.FriendLetDocumentIndex = value;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				mobjAcadMLineStyleElements.FriendLetApplicationIndex = value;
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				Filled = ((1 & mlngFlags70) == 1);
				ShowMiters = ((2 & mlngFlags70) == 2);
				StartSquareCap = ((0x10 & mlngFlags70) == 16);
				StartInnerArcs = ((0x20 & mlngFlags70) == 32);
				StartRoundCap = ((0x40 & mlngFlags70) == 64);
				EndSquareCap = ((0x100 & mlngFlags70) == 256);
				EndInnerArcs = ((0x200 & mlngFlags70) == 512);
				EndRoundCap = ((0x400 & mlngFlags70) == 1024);
				mblnFriendLetFlags = false;
			}
		}

		public AcadMLineStyleElements Elements => mobjAcadMLineStyleElements;

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

		public string Description
		{
			get
			{
				return mstrDescription;
			}
			set
			{
				mstrDescription = value;
			}
		}

		public bool Filled
		{
			get
			{
				return mblnFilled;
			}
			set
			{
				mblnFilled = value;
				InternCalcFlags70();
			}
		}

		public Enums.AcColor Color
		{
			get
			{
				return mnumColor;
			}
			set
			{
				mnumColor = value;
			}
		}

		public object StartAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartAngleDegree), mdblStartAngleDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecStartAngleDegree;
				ref double reference = ref mdblStartAngleDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMLineStyle", dstrErrMsg);
				}
			}
		}

		public object StartAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(StartAngleDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadMLineStyle", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblStartAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public bool StartSquareCap
		{
			get
			{
				return mblnStartSquareCap;
			}
			set
			{
				mblnStartSquareCap = value;
				InternCalcFlags70();
			}
		}

		public bool StartRoundCap
		{
			get
			{
				return mblnStartRoundCap;
			}
			set
			{
				mblnStartRoundCap = value;
				InternCalcFlags70();
			}
		}

		public bool StartInnerArcs
		{
			get
			{
				return mblnStartInnerArcs;
			}
			set
			{
				mblnStartInnerArcs = value;
				InternCalcFlags70();
			}
		}

		public object EndAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndAngleDegree), mdblEndAngleDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecEndAngleDegree;
				ref double reference = ref mdblEndAngleDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMLineStyle", dstrErrMsg);
				}
			}
		}

		public object EndAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(EndAngleDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadMLineStyle", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblEndAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
			}
		}

		public bool EndSquareCap
		{
			get
			{
				return mblnEndSquareCap;
			}
			set
			{
				mblnEndSquareCap = value;
				InternCalcFlags70();
			}
		}

		public bool EndRoundCap
		{
			get
			{
				return mblnEndRoundCap;
			}
			set
			{
				mblnEndRoundCap = value;
				InternCalcFlags70();
			}
		}

		public bool EndInnerArcs
		{
			get
			{
				return mblnEndInnerArcs;
			}
			set
			{
				mblnEndInnerArcs = value;
				InternCalcFlags70();
			}
		}

		public bool ShowMiters
		{
			get
			{
				return mblnShowMiters;
			}
			set
			{
				mblnShowMiters = value;
				InternCalcFlags70();
			}
		}

		public int Flags70 => mlngFlags70;

		public AcadMLineStyle()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 217;
			base.FriendLetNodeImageDisabledID = 218;
			base.FriendLetNodeName = "Multilinien-Stil";
			base.FriendLetNodeText = "Multilinien-Stil";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblStartAngleDegree = hwpDxf_Vars.pdblMLineStyleStartAngleDegree;
			mdblEndAngleDegree = hwpDxf_Vars.pdblMLineStyleEndAngleDegree;
			mstrName = hwpDxf_Vars.pstrName;
			mstrDescription = hwpDxf_Vars.pstrDescription;
			mblnFilled = hwpDxf_Vars.pblnFilled;
			mnumColor = hwpDxf_Vars.pnumMLineStyleColor;
			mblnStartSquareCap = hwpDxf_Vars.pblnStartSquareCap;
			mblnStartRoundCap = hwpDxf_Vars.pblnStartRoundCap;
			mblnStartInnerArcs = hwpDxf_Vars.pblnStartInnerArcs;
			mblnEndSquareCap = hwpDxf_Vars.pblnEndSquareCap;
			mblnEndRoundCap = hwpDxf_Vars.pblnEndRoundCap;
			mblnEndInnerArcs = hwpDxf_Vars.pblnEndInnerArcs;
			mblnShowMiters = hwpDxf_Vars.pblnShowMiters;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			mlngIndex = -1;
			mobjAcadMLineStyleElements = new AcadMLineStyleElements();
			mobjAcadMLineStyleElements.FriendLetNodeParentID = base.NodeID;
			mobjAcadMLineStyleElements.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			mobjAcadMLineStyleElements.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			mobjAcadMLineStyleElements.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			base.FriendLetDXFName = "MLINESTYLE";
			base.FriendLetObjectName = "AcDbMlineStyle";
		}

		~AcadMLineStyle()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadMLineStyleElements.FriendQuit();
				base.FriendQuit();
				mobjAcadMLineStyleElements = null;
				mblnOpened = false;
			}
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Filled, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ShowMiters, 2, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(StartSquareCap, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(StartInnerArcs, 32, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(StartRoundCap, 64, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(EndSquareCap, 256, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(EndInnerArcs, 512, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(EndRoundCap, 1024, 0)));
			}
		}
	}

}
