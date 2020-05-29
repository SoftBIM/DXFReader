using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadPolyfaceMeshVertex : AcadEntity
	{
		private const string cstrClassName = "AcadPolyfaceMeshVertex";

		private const int clngIsPolyfaceMesh = 64;

		private const int clngIsPolyfaceMeshVertex = 128;

		private bool mblnOpened;

		private object[] madecCoordinate;

		private double[] madblCoordinate;

		private int mlngFlags70;

		private bool mblnIsPolyfaceMesh;

		private bool mblnIsPolyfaceMeshVertex;

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
				mblnIsPolyfaceMesh = ((0x40 & mlngFlags70) == 64);
				mblnIsPolyfaceMeshVertex = ((0x80 & mlngFlags70) == 128);
			}
		}

		internal bool FriendGetIsPolyfaceMesh => mblnIsPolyfaceMesh;

		internal bool FriendGetIsPolyfaceMeshVertex => mblnIsPolyfaceMeshVertex;

		public object Coordinate => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCoordinate, madblCoordinate));

		public int Flags70 => mlngFlags70;

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[0]), madblCoordinate[0]));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[1]), madblCoordinate[1]));

		public object CoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[2]), madblCoordinate[2]));

		public AcadPolyfaceMeshVertex()
		{
			madecCoordinate = new object[3];
			madblCoordinate = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 337;
			base.FriendLetNodeImageDisabledID = 338;
			base.FriendLetNodeName = "Vielflächennetz-Kontrollpunkt";
			base.FriendLetNodeText = "A Vielflächennetz-Kontrollpunkt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblCoordinate[0] = hwpDxf_Vars.padblCoordinate[0];
			madblCoordinate[1] = hwpDxf_Vars.padblCoordinate[1];
			madblCoordinate[2] = hwpDxf_Vars.padblCoordinate[2];
			mblnIsPolyfaceMesh = hwpDxf_Vars.pblnIsPolyfaceMesh;
			mblnIsPolyfaceMeshVertex = hwpDxf_Vars.pblnIsPolyfaceMeshVertex;
			InternCalcFlags70();
			base.FriendLetDXFName = "VERTEX";
			base.FriendLetObjectName = "AcDbPolyFaceMeshVertex";
			base.FriendLetEntityType = Enums.AcEntityName.acPolyfaceMeshVertex;
		}

		~AcadPolyfaceMeshVertex()
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

		internal void FriendSetCoordinate(object value)
		{
			bool flag = false;
			madblCoordinate = (double[])value;
		}

		private void InternCalcFlags70()
		{
			mlngFlags70 = 0;
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsPolyfaceMesh, 64, 0)));
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsPolyfaceMeshVertex, 128, 0)));
		}
	}

}
