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
	public class AcadXline : AcadCurve
	{
		private const string cstrClassName = "AcadXline";

		private bool mblnOpened;

		public object BasePoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetBasePoint);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadXline", dstrErrMsg);
				}
				else
				{
					base.FriendLetBasePoint = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object SecondPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetSecondPoint);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadXline", dstrErrMsg);
				}
				else
				{
					base.FriendLetSecondPoint = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public object DirectionVector => RuntimeHelpers.GetObjectValue(base.FriendGetDirectionVector);

		public bool Is2DWorld => Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(BasePoint, new object[1]
		{
		2
		}, null), 0m, TextCompare: false), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(SecondPoint, new object[1]
		{
		2
		}, null), 0m, TextCompare: false)));

		private void mobjAcadCurve_CurveMinMaxCoords(object MinMaxCoords)
		{
			FriendSetMinMaxCoords(RuntimeHelpers.GetObjectValue(MinMaxCoords));
		}

		public AcadXline()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveXLine;
			base.FriendLetNodeImageEnabledID = 185;
			base.FriendLetNodeImageDisabledID = 186;
			base.FriendLetNodeName = "Konstruktionslinie";
			base.FriendLetNodeText = "Konstruktionslinie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "XLINE";
			base.FriendLetObjectName = "AcDbXline";
			base.FriendLetEntityType = Enums.AcEntityName.acXline;
		}

		~AcadXline()
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
