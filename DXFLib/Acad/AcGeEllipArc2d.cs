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
	public class AcGeEllipArc2d
	{
		private const string cstrClassName = "AcGeEllipArc2d";

		private bool mblnOpened;

		private object[] madecCenter;

		private double[] madblCenter;

		private object mdecRadiusRatio;

		private double mdblRadiusRatio;

		private object[] madecMajorAxis;

		private double[] madblMajorAxis;

		private object mdecMajorRadius;

		private double mdblMajorRadius;

		private object[] madecMinorAxis;

		private double[] madblMinorAxis;

		private object mdecMinorRadius;

		private double mdblMinorRadius;

		private object mdecStartAngleDegree;

		private double mdblStartAngleDegree;

		private object mdecEndAngleDegree;

		private double mdblEndAngleDegree;

		private bool mblnIsClockWise;

		internal object FriendLetCenter
		{
			set
			{
				ref object[] reference = ref madecCenter;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblCenter;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetRadiusRatio
		{
			set
			{
				ref object rvarValueDec = ref mdecRadiusRatio;
				ref double reference = ref mdblRadiusRatio;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetMajorAxis
		{
			set
			{
				ref object[] reference = ref madecMajorAxis;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblMajorAxis;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetMajorRadius
		{
			set
			{
				ref object rvarValueDec = ref mdecMajorRadius;
				ref double reference = ref mdblMajorRadius;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetMinorAxis
		{
			set
			{
				ref object[] reference = ref madecMinorAxis;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblMinorAxis;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetMinorRadius
		{
			set
			{
				ref object rvarValueDec = ref mdecMinorRadius;
				ref double reference = ref mdblMinorRadius;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetStartAngleDegree
		{
			set
			{
				ref object rvarValueDec = ref mdecStartAngleDegree;
				ref double reference = ref mdblStartAngleDegree;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetStartAngle
		{
			set
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					bool flag = false;
					mdblStartAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		internal object FriendLetEndAngleDegree
		{
			set
			{
				ref object rvarValueDec = ref mdecEndAngleDegree;
				ref double reference = ref mdblEndAngleDegree;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetEndAngle
		{
			set
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					bool flag = false;
					mdblEndAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		internal bool FriendLetIsClockWise
		{
			set
			{
				mblnIsClockWise = value;
			}
		}

		public object Center => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCenter, madblCenter));

		public object RadiusRatio => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRadiusRatio), mdblRadiusRatio));

		public object MajorAxis => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMajorAxis, madblMajorAxis));

		public object MajorRadius => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMajorRadius), mdblMajorRadius));

		public object MinorAxis => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMinorAxis, madblMinorAxis));

		public object MinorRadius => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinorRadius), mdblMinorRadius));

		public object StartAngleDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartAngleDegree), mdblStartAngleDegree));

		public object StartAngle => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(StartAngleDegree)));

		public object EndAngleDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndAngleDegree), mdblEndAngleDegree));

		public object EndAngle => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(EndAngleDegree)));

		public bool IsClockWise => mblnIsClockWise;

		public AcGeEllipArc2d()
		{
			madecCenter = new object[2];
			madblCenter = new double[2];
			madecMajorAxis = new object[2];
			madblMajorAxis = new double[2];
			madecMinorAxis = new object[2];
			madblMinorAxis = new double[2];
			mblnOpened = true;
			bool flag = false;
			madblCenter[0] = hwpDxf_Vars.padblCenter[0];
			madblCenter[1] = hwpDxf_Vars.padblCenter[1];
			mdblRadiusRatio = hwpDxf_Vars.pdblRadiusRatio;
			madblMajorAxis[0] = hwpDxf_Vars.padblMajorAxis[0];
			madblMajorAxis[1] = hwpDxf_Vars.padblMajorAxis[1];
			mdblMajorRadius = hwpDxf_Vars.pdblMajorRadius;
			madblMinorAxis[0] = hwpDxf_Vars.padblMinorAxis[0];
			madblMinorAxis[1] = hwpDxf_Vars.padblMinorAxis[1];
			mdblMinorRadius = hwpDxf_Vars.pdblMinorRadius;
			mdblStartAngleDegree = hwpDxf_Vars.pdblStartAngleDegree;
			mdblEndAngleDegree = hwpDxf_Vars.pdblEndAngleDegree;
			mblnIsClockWise = hwpDxf_Vars.pblnIsClockWise;
		}

		~AcGeEllipArc2d()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mblnOpened = false;
			}
		}
	}
}
