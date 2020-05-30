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
	public class AcadRay : AcadCurve
	{
		private const string cstrClassName = "AcadRay";

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
					Information.Err().Raise(50000, "AcadRay", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadRay", dstrErrMsg);
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

		public AcadRay()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveRay;
			base.FriendLetNodeImageEnabledID = 181;
			base.FriendLetNodeImageDisabledID = 182;
			base.FriendLetNodeName = "Strahl";
			base.FriendLetNodeText = "Strahl";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "RAY";
			base.FriendLetObjectName = "AcDbRay";
			base.FriendLetEntityType = Enums.AcEntityName.acRay;
		}

		~AcadRay()
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
