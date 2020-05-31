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
	public class AcGeVertex2d
	{
		private const string cstrClassName = "AcGeVertex2d";

		private bool mblnOpened;

		private object mdecCoordX;

		private double mdblCoordX;

		private object mdecCoordY;

		private double mdblCoordY;

		private object mdecBulge;

		private double mdblBulge;

		internal object FriendLetCoordX
		{
			set
			{
				ref object rvarValueDec = ref mdecCoordX;
				ref double reference = ref mdblCoordX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetCoordY
		{
			set
			{
				ref object rvarValueDec = ref mdecCoordY;
				ref double reference = ref mdblCoordY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetBulge
		{
			set
			{
				ref object rvarValueDec = ref mdecBulge;
				ref double reference = ref mdblBulge;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordX), mdblCoordX));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordY), mdblCoordY));

		public object Bulge => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecBulge), mdblBulge));

		public AcGeVertex2d()
		{
			mblnOpened = true;
			bool flag = false;
			mdblCoordX = hwpDxf_Vars.pdblCoordX;
			mdblCoordY = hwpDxf_Vars.pdblCoordY;
			mdblBulge = hwpDxf_Vars.pdblBulge;
		}

		~AcGeVertex2d()
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
