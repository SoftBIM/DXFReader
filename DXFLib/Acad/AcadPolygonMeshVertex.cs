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
	public class AcadPolygonMeshVertex: AcadEntity
{
	private const string cstrClassName = "AcadPolygonMeshVertex";

	private const int clngSplineFitVertex = 8;

	private const int clngSplineCtlVertex = 16;

	private const int clngIsPolygonMesh = 64;

	private bool mblnOpened;

	private object[] madecCoordinate;

	private double[] madblCoordinate;

	private int mlngFlags70;

	private bool mblnSplineFitVertex;

	private bool mblnSplineCtlVertex;

	private bool mblnIsPolygonMesh;

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
			mblnIsPolygonMesh = ((0x40 & mlngFlags70) == 64);
		}
	}

	internal bool FriendGetIsPolygonMesh => mblnIsPolygonMesh;

	public object Coordinate => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCoordinate, madblCoordinate));

	public int Flags70 => mlngFlags70;

	public bool SplineFitVertex => mblnSplineFitVertex;

	public bool SplineCtlVertex => mblnSplineCtlVertex;

	public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[0]), madblCoordinate[0]));

	public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[1]), madblCoordinate[1]));

	public object CoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(madecCoordinate[2]), madblCoordinate[2]));

	public AcadPolygonMeshVertex()
	{
		madecCoordinate = new object[3];
		madblCoordinate = new double[3];
		mblnOpened = true;
		base.FriendLetNodeImageEnabledID = 329;
		base.FriendLetNodeImageDisabledID = 330;
		base.FriendLetNodeName = "Polygonnetz-Kontrollpunkt";
		base.FriendLetNodeText = "A Polygonnetz-Kontrollpunkt";
		object robjObject = this;
		FriendAddToCollection(ref robjObject);
		bool flag = false;
		madblCoordinate[0] = hwpDxf_Vars.padblCoordinate[0];
		madblCoordinate[1] = hwpDxf_Vars.padblCoordinate[1];
		madblCoordinate[2] = hwpDxf_Vars.padblCoordinate[2];
		mblnSplineFitVertex = hwpDxf_Vars.pblnSplineFitVertex;
		mblnSplineCtlVertex = hwpDxf_Vars.pblnSplineCtlVertex;
		mblnIsPolygonMesh = hwpDxf_Vars.pblnIsPolygonMesh;
		InternCalcFlags70();
		base.FriendLetDXFName = "VERTEX";
		base.FriendLetObjectName = "AcDbPolygonMeshVertex";
		base.FriendLetEntityType = Enums.AcEntityName.acPolygonMeshVertex;
	}

	~AcadPolygonMeshVertex()
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
		mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineFitVertex, 8, 0)));
		mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(SplineCtlVertex, 16, 0)));
		mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsPolygonMesh, 64, 0)));
	}
}

}
