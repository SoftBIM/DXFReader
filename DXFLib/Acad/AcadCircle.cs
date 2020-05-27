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
    public class AcadCircle : AcadCurve
	{
		private const string cstrClassName = "AcadCircle";

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
					Information.Err().Raise(50000, "AcadCircle", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadCircle", dstrErrMsg);
				}
				else
				{
					base.FriendLetRadius = RuntimeHelpers.GetObjectValue(value);
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
					Information.Err().Raise(50000, "AcadCircle", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadCircle", dstrErrMsg);
				}
			}
		}

		public object Area => RuntimeHelpers.GetObjectValue(base.FriendGetArea);

		public object Circumference => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

		public object Diameter
		{
			get
			{
				bool flag = false;
				return Operators.MultiplyObject(base.FriendGetRadius, 2.0);
			}
		}

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

		public AcadCircle()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveCircle;
			base.FriendLetNodeImageEnabledID = 169;
			base.FriendLetNodeImageDisabledID = 170;
			base.FriendLetNodeName = "Kreis";
			base.FriendLetNodeText = "Kreis";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblThickness = hwpDxf_Vars.pdblThickness;
			base.FriendLetDXFName = "CIRCLE";
			base.FriendLetObjectName = "AcDbCircle";
			base.FriendLetEntityType = Enums.AcEntityName.acCircle;
		}

		~AcadCircle()
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
