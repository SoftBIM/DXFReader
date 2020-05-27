using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
    public class AcadArc : AcadCurve
	{
		private const string cstrClassName = "AcadArc";

		private bool mblnOpened;

		private object mdecThickness;

		private double mdblThickness;

		public object Center
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetCenter);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetCenter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object Radius
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetRadius);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetRadius = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object StartAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetStartParameter);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetStartParameter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object StartAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetStartParameterDegree);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetStartParameterDegree = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object EndAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetEndParameter);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetEndParameter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object EndAngleDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetEndParameterDegree);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetEndParameterDegree = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object Normal
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetNormal);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
				else
				{
					base.FriendLetNormal = RuntimeHelpers.GetObjectValue(value);
				}
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
					Information.Err().Raise(50000, "AcadArc", dstrErrMsg);
				}
			}
		}

		public object StartPoint => RuntimeHelpers.GetObjectValue(base.FriendGetStartPoint);

		public object EndPoint => RuntimeHelpers.GetObjectValue(base.FriendGetEndPoint);

		public object Area => RuntimeHelpers.GetObjectValue(base.FriendGetArea);

		public object ArcLength => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

		public object TotalAngle => RuntimeHelpers.GetObjectValue(base.FriendGetTotalAngle);

		public object TotalAngleDegree => RuntimeHelpers.GetObjectValue(base.FriendGetTotalAngleDegree);

		public bool Is2DWorld => Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		0
		}, null), 0m, TextCompare: false), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		1
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		2
		}, null), 1m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(base.FriendGetCenter, new object[1]
		{
		2
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(Thickness, 0m, TextCompare: false)));

		public AcadArc()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveArc;
			base.FriendLetNodeImageEnabledID = 165;
			base.FriendLetNodeImageDisabledID = 166;
			base.FriendLetNodeName = "Bogen";
			base.FriendLetNodeText = "Bogen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblThickness = hwpDxf_Vars.pdblThickness;
			base.FriendLetDXFName = "ARC";
			base.FriendLetObjectName = "AcDbArc";
			base.FriendLetEntityType = Enums.AcEntityName.acArc;
		}

		~AcadArc()
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
