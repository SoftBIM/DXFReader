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
	public class AcGePoint3d
	{
		private const string cstrClassName = "AcGePoint3d";

		private bool mblnOpened;

		private object mdecCoordX;

		private double mdblCoordX;

		private object mdecCoordY;

		private double mdblCoordY;

		private object mdecCoordZ;

		private double mdblCoordZ;

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

		internal object FriendLetCoordZ
		{
			set
			{
				ref object rvarValueDec = ref mdecCoordZ;
				ref double reference = ref mdblCoordZ;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordX), mdblCoordX));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordY), mdblCoordY));

		public object CoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordZ), mdblCoordZ));

		public AcGePoint3d()
		{
			mblnOpened = true;
			bool flag = false;
			mdblCoordX = hwpDxf_Vars.pdblCoordX;
			mdblCoordY = hwpDxf_Vars.pdblCoordY;
			mdblCoordZ = hwpDxf_Vars.pdblCoordZ;
		}

		~AcGePoint3d()
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
