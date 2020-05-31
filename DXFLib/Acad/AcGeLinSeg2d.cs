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
	public class AcGeLinSeg2d
	{
		private const string cstrClassName = "AcGeLinSeg2d";

		private bool mblnOpened;

		private object[] madecStartPoint;

		private double[] madblStartPoint;

		private object[] madecEndPoint;

		private double[] madblEndPoint;

		internal object FriendLetStartPoint
		{
			set
			{
				ref object[] reference = ref madecStartPoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblStartPoint;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetEndPoint
		{
			set
			{
				ref object[] reference = ref madecEndPoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblEndPoint;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		public object StartPoint => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecStartPoint, madblStartPoint));

		public object EndPoint => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecEndPoint, madblEndPoint));

		public AcGeLinSeg2d()
		{
			madecStartPoint = new object[2];
			madblStartPoint = new double[2];
			madecEndPoint = new object[2];
			madblEndPoint = new double[2];
			mblnOpened = true;
			bool flag = false;
			madblStartPoint[0] = hwpDxf_Vars.padblStartPoint[0];
			madblStartPoint[1] = hwpDxf_Vars.padblStartPoint[1];
			madblEndPoint[0] = hwpDxf_Vars.padblEndPoint[0];
			madblEndPoint[1] = hwpDxf_Vars.padblEndPoint[1];
		}

		~AcGeLinSeg2d()
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
