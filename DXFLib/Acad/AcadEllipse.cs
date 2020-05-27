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
    public class AcadEllipse : AcadCurve
	{
		private const string cstrClassName = "AcadEllipse";

		private bool mblnOpened;

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
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetCenter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object MajorAxis
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetMajorAxis);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetMajorAxis = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object RadiusRatio
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetRadiusRatio);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetRadiusRatio = RuntimeHelpers.GetObjectValue(value);
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
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetNormal = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object StartParameter
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
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetStartParameter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object EndParameter
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
					Information.Err().Raise(50000, "AcadEllipse", dstrErrMsg);
				}
				else
				{
					base.FriendLetEndParameter = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object StartAngle => RuntimeHelpers.GetObjectValue(base.FriendGetStartParameter);

		public object StartAngleDegree => RuntimeHelpers.GetObjectValue(base.FriendGetStartParameterDegree);

		public object EndAngle => RuntimeHelpers.GetObjectValue(base.FriendGetEndParameter);

		public object EndAngleDegree => RuntimeHelpers.GetObjectValue(base.FriendGetEndParameterDegree);

		public object MajorRadius => RuntimeHelpers.GetObjectValue(base.FriendGetMajorRadius);

		public object MinorRadius => RuntimeHelpers.GetObjectValue(base.FriendGetMinorRadius);

		public object MinorAxis => RuntimeHelpers.GetObjectValue(base.FriendGetMinorAxis);

		public object StartPoint => RuntimeHelpers.GetObjectValue(base.FriendGetStartPoint);

		public object EndPoint => RuntimeHelpers.GetObjectValue(base.FriendGetEndPoint);

		public object Area => RuntimeHelpers.GetObjectValue(base.FriendGetArea);

		public object Length => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

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
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(MajorAxis, new object[1]
		{
		2
		}, null), 0m, TextCompare: false)));

		private void mobjAcadCurve_CurveMinMaxCoords(object MinMaxCoords)
		{
			FriendSetMinMaxCoords(RuntimeHelpers.GetObjectValue(MinMaxCoords));
		}

		public AcadEllipse()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveEllipse;
			base.FriendLetNodeImageEnabledID = 257;
			base.FriendLetNodeImageDisabledID = 258;
			base.FriendLetNodeName = "Ellipse";
			base.FriendLetNodeText = "Ellipse";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "ELLIPSE";
			base.FriendLetObjectName = "AcDbEllipse";
			base.FriendLetEntityType = Enums.AcEntityName.acEllipse;
		}

		~AcadEllipse()
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
