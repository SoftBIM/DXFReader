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
	public class Acad3DVertex : AcadEntity
	{
		private const string cstrClassName = "Acad3DVertex";

		private const int clngSplineFitVertex = 8;

		private const int clngSplineCtlVertex = 16;

		private const int clngIs3DPolyline = 32;

		private bool mblnOpened;

		private object[] madecCoordinate;

		private double[] madblCoordinate;

		private int mlngFlags70;

		private bool mblnSplineFitVertex;

		private bool mblnSplineCtlVertex;

		private bool mblnIs3DPolyline;

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

		internal int FriendLetFlags70
		{
			set
			{
				mlngFlags70 = value;
				mblnSplineFitVertex = ((8 & mlngFlags70) == 8);
				mblnSplineCtlVertex = ((0x10 & mlngFlags70) == 16);
				mblnIs3DPolyline = ((0x20 & mlngFlags70) == 32);
			}
		}

		internal bool FriendGetIs3DPolyline => mblnIs3DPolyline;

		public object Coordinate => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCoordinate, madblCoordinate));

		public int Flags70 => mlngFlags70;

		public bool SplineFitVertex => mblnSplineFitVertex;

		public bool SplineCtlVertex => mblnSplineCtlVertex;

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[0]), madblCoordinate[0]));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[1]), madblCoordinate[1]));

		public object CoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[2]), madblCoordinate[2]));

		public Acad3DVertex()
		{
			madecCoordinate = new object[3];
			madblCoordinate = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 321;
			base.FriendLetNodeImageDisabledID = 322;
			base.FriendLetNodeName = "3D-Kontrollpunkt";
			base.FriendLetNodeText = "A 3D-Kontrollpunkt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblCoordinate[0] = hwpDxf_Vars.padblCoordinate[0];
			madblCoordinate[1] = hwpDxf_Vars.padblCoordinate[1];
			madblCoordinate[2] = hwpDxf_Vars.padblCoordinate[2];
			mblnSplineFitVertex = hwpDxf_Vars.pblnSplineFitVertex;
			mblnSplineCtlVertex = hwpDxf_Vars.pblnSplineCtlVertex;
			mblnIs3DPolyline = hwpDxf_Vars.pblnIs3DPolyline;
			InternCalcFlags70();
			base.FriendLetDXFName = "VERTEX";
			base.FriendLetObjectName = "AcDb3dPolylineVertex";
			base.FriendLetEntityType = Enums.AcEntityName.ac3DVertex;
		}

		~Acad3DVertex()
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

		private void InternCalcFlags70()
		{
			mlngFlags70 = 0;
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineFitVertex, 8, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineCtlVertex, 16, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIs3DPolyline, 32, 0)));
		}
	}
}
