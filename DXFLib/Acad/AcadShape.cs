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
	public class AcadShape : AcadEntity
	{
		private const string cstrClassName = "AcadShape";

		private bool mblnOpened;

		private object mdecHeight;

		private double mdblHeight;

		private object[] madecInsertionPoint;

		private double[] madblInsertionPoint;

		private string mstrName;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mdecObliqueAngleDegree;

		private double mdblObliqueAngleDegree;

		private object mdecRotationDegree;

		private double mdblRotationDegree;

		private object mdecScaleFactor;

		private double mdblScaleFactor;

		private object mdecThickness;

		private double mdblThickness;

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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
				}
			}
		}

		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadShape", dstrErrMsg);
				}
			}
		}

		public AcadShape()
		{
			madecInsertionPoint = new object[3];
			madblInsertionPoint = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 261;
			base.FriendLetNodeImageDisabledID = 262;
			base.FriendLetNodeName = "Symbol";
			base.FriendLetNodeText = "Symbol";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
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
			mdblThickness = hwpDxf_Vars.pdblThickness;
			mstrName = null;
			base.FriendLetDXFName = "SHAPE";
			base.FriendLetObjectName = "AcDbShape";
			base.FriendLetEntityType = Enums.AcEntityName.acShape;
		}

		~AcadShape()
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
