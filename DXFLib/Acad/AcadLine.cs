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
	public class AcadLine : AcadCurve
	{
		private const string cstrClassName = "AcadLine";

		private bool mblnOpened;

		private object mdecThickness;

		private double mdblThickness;

		public object StartPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetStartPoint);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadLine", dstrErrMsg);
				}
				else
				{
					base.FriendLetStartPoint = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object EndPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetEndPoint);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadLine", dstrErrMsg);
				}
				else
				{
					base.FriendLetEndPoint = RuntimeHelpers.GetObjectValue(value);
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
					Information.Err().Raise(50000, "AcadLine", dstrErrMsg);
				}
				else
				{
					base.FriendLetNormal = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object Length => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

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
					Information.Err().Raise(50000, "AcadLine", dstrErrMsg);
				}
			}
		}

		public object DirectionVector => RuntimeHelpers.GetObjectValue(base.FriendGetDirectionVector);

		public object Angle => RuntimeHelpers.GetObjectValue(base.FriendGetTotalAngle);

		public object AngleDegree => RuntimeHelpers.GetObjectValue(base.FriendGetTotalAngleDegree);

		public object Delta
		{
			get
			{
				object[] davarDelta = new object[3];
				object dvarStartPoint = RuntimeHelpers.GetObjectValue(base.FriendGetStartPoint);
				object dvarEndPoint = RuntimeHelpers.GetObjectValue(base.FriendGetEndPoint);
				davarDelta[0] = Operators.SubtractObject(NewLateBinding.LateIndexGet(dvarEndPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(dvarStartPoint, new object[1]
				{
				0
				}, null));
				davarDelta[1] = Operators.SubtractObject(NewLateBinding.LateIndexGet(dvarEndPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(dvarStartPoint, new object[1]
				{
				1
				}, null));
				davarDelta[2] = Operators.SubtractObject(NewLateBinding.LateIndexGet(dvarEndPoint, new object[1]
				{
				2
				}, null), NewLateBinding.LateIndexGet(dvarStartPoint, new object[1]
				{
				2
				}, null));
				return Support.CopyArray(davarDelta);
			}
		}

		public bool Is2DWorld => Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		0
		}, null), 0m, TextCompare: false), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		1
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		2
		}, null), 1m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(base.FriendGetStartPoint, new object[1]
		{
		2
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(base.FriendGetEndPoint, new object[1]
		{
		2
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(Thickness, 0m, TextCompare: false)));

		public AcadLine()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveLine;
			base.FriendLetNodeImageEnabledID = 173;
			base.FriendLetNodeImageDisabledID = 174;
			base.FriendLetNodeName = "Linie";
			base.FriendLetNodeText = "Linie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblThickness = hwpDxf_Vars.pdblThickness;
			base.FriendLetDXFName = "LINE";
			base.FriendLetObjectName = "AcDbLine";
			base.FriendLetEntityType = Enums.AcEntityName.acLine;
		}

		~AcadLine()
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
