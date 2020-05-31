using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class Acad2DVertex : AcadEntity
	{
		private const string cstrClassName = "Acad2DVertex";

		private const int clngCurveFitVertex = 1;

		private const int clngIsTangentUsed = 2;

		private const int clngSplineFitVertex = 8;

		private const int clngSplineCtlVertex = 16;

		private bool mblnOpened;

		private object[] madecCoordinate;

		private double[] madblCoordinate;

		private object mdecStartWidth;

		private double mdblStartWidth;

		private object mdecEndWidth;

		private double mdblEndWidth;

		private object mdecBulge;

		private double mdblBulge;

		private int mlngFlags70;

		private bool mblnCurveFitVertex;

		private bool mblnIsTangentUsed;

		private bool mblnSplineFitVertex;

		private bool mblnSplineCtlVertex;

		private object mdecTangent;

		private double mdblTangent;

		internal object FriendLetCoordinate
		{
			set
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(objectValue, 0, 2, ref nrstrErrMsg))
				{
					ref object[] reference = ref madecCoordinate;
					object ravarArrayDec = reference;
					ref double[] reference2 = ref madblCoordinate;
					object ravarArrayDbl = reference2;
					object objectValue2 = RuntimeHelpers.GetObjectValue(value);
					nrstrErrMsg = "";
					hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue2, ref nrstrErrMsg);
					reference2 = (double[])ravarArrayDbl;
					reference = (object[])ravarArrayDec;
				}
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

		internal object FriendLetStartWidth
		{
			set
			{
				ref object rvarValueDec = ref mdecStartWidth;
				ref double reference = ref mdblStartWidth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetEndWidth
		{
			set
			{
				ref object rvarValueDec = ref mdecEndWidth;
				ref double reference = ref mdblEndWidth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mlngFlags70 = value;
				mblnCurveFitVertex = ((1 & mlngFlags70) == 1);
				mblnIsTangentUsed = ((2 & mlngFlags70) == 2);
				mblnSplineFitVertex = ((8 & mlngFlags70) == 8);
				mblnSplineCtlVertex = ((0x10 & mlngFlags70) == 16);
			}
		}

		internal object FriendLetTangent
		{
			set
			{
				ref object rvarValueDec = ref mdecTangent;
				ref double reference = ref mdblTangent;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		public object Coordinate => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCoordinate, madblCoordinate));

		public object StartWidth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartWidth), mdblStartWidth));

		public object EndWidth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndWidth), mdblEndWidth));

		public object Bulge => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecBulge), mdblBulge));

		public int Flags70 => mlngFlags70;

		public bool CurveFitVertex => mblnCurveFitVertex;

		public bool IsTangentUsed => mblnIsTangentUsed;

		public bool SplineFitVertex => mblnSplineFitVertex;

		public bool SplineCtlVertex => mblnSplineCtlVertex;

		public object Tangent
		{
			get
			{
				if (mblnIsTangentUsed)
				{
					return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecTangent), mdblTangent));
				}
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecTangent), hwpDxf_Vars.pdblTangent));
			}
		}

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[0]), madblCoordinate[0]));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[1]), madblCoordinate[1]));

		public object CoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[2]), madblCoordinate[2]));

		public Acad2DVertex()
		{
			madecCoordinate = new object[3];
			madblCoordinate = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 313;
			base.FriendLetNodeImageDisabledID = 314;
			base.FriendLetNodeName = "2D-Kontrollpunkt";
			base.FriendLetNodeText = "A 2D-Kontrollpunkt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblCoordinate[0] = hwpDxf_Vars.padblCoordinate[0];
			madblCoordinate[1] = hwpDxf_Vars.padblCoordinate[1];
			madblCoordinate[2] = hwpDxf_Vars.padblCoordinate[2];
			mdblStartWidth = hwpDxf_Vars.pdblStartWidth;
			mdblEndWidth = hwpDxf_Vars.pdblEndWidth;
			mdblBulge = hwpDxf_Vars.pdblBulge;
			mdblTangent = hwpDxf_Vars.pdblTangent;
			mblnCurveFitVertex = hwpDxf_Vars.pblnCurveFitVertex;
			mblnIsTangentUsed = hwpDxf_Vars.pblnIsTangentUsed;
			mblnSplineFitVertex = hwpDxf_Vars.pblnSplineFitVertex;
			mblnSplineCtlVertex = hwpDxf_Vars.pblnSplineCtlVertex;
			InternCalcFlags70();
			base.FriendLetDXFName = "VERTEX";
			base.FriendLetObjectName = "AcDb2dVertex";
			base.FriendLetEntityType = Enums.AcEntityName.ac2DVertex;
		}

		~Acad2DVertex()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}

		internal void FriendSetCoordinate(object value)
		{
			bool flag = false;
			madblCoordinate = (double[])value;
		}

		internal void FriendSetStartWidth(object value)
		{
			bool flag = false;
			mdblStartWidth = Conversions.ToDouble(value);
		}

		internal void FriendSetEndWidth(object value)
		{
			bool flag = false;
			mdblEndWidth = Conversions.ToDouble(value);
		}

		private void InternCalcFlags70()
		{
			mlngFlags70 = 0;
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(CurveFitVertex, 1, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsTangentUsed, 2, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineFitVertex, 8, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineCtlVertex, 16, 0)));
		}
	}
}
