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
	public class AcGeCircArc2d
	{
		private const string cstrClassName = "AcGeCircArc2d";

		private bool mblnOpened;

		private object[] madecCenter;

		private double[] madblCenter;

		private object mdecRadius;

		private double mdblRadius;

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

		internal object FriendLetRadius
		{
			set
			{
				ref object rvarValueDec = ref mdecRadius;
				ref double reference = ref mdblRadius;
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

		public object Radius => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRadius), mdblRadius));

		public object StartAngleDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartAngleDegree), mdblStartAngleDegree));

		public object StartAngle => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(StartAngleDegree)));

		public object EndAngleDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndAngleDegree), mdblEndAngleDegree));

		public object EndAngle => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(EndAngleDegree)));

		public bool IsClockWise => mblnIsClockWise;

		public AcGeCircArc2d()
		{
			madecCenter = new object[2];
			madblCenter = new double[2];
			mblnOpened = true;
			bool flag = false;
			madblCenter[0] = hwpDxf_Vars.padblCenter[0];
			madblCenter[1] = hwpDxf_Vars.padblCenter[1];
			mdblRadius = hwpDxf_Vars.pdblRadius;
			mdblStartAngleDegree = hwpDxf_Vars.pdblStartAngleDegree;
			mdblEndAngleDegree = hwpDxf_Vars.pdblEndAngleDegree;
			mblnIsClockWise = hwpDxf_Vars.pblnIsClockWise;
		}

		~AcGeCircArc2d()
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
