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
	public class AcadPolygonMesh : AcadEntity
	{
		private const string cstrClassName = "AcadPolygonMesh";

		private const int clngMClosed = 1;

		private const int clngIsSpline = 4;

		private const int clngIsPolygonMesh = 16;

		private const int clngNClosed = 32;

		private const short clngSplineTypeNone = 0;

		private const short clngSplineTypeCubicSpline = 5;

		private const short clngSplineTypeQuadSpline = 6;

		private const short clngSplineTypeBezier = 8;

		private bool mblnOpened;

		private int mlngFlags66;

		private object mdecCode10;

		private double mdblCode10;

		private object mdecCode20;

		private double mdblCode20;

		private object mdecCode30;

		private double mdblCode30;

		private int mlngFlags70;

		private bool mblnMClosed;

		private bool mblnIsSpline;

		private bool mblnIsPolygonMesh;

		private bool mblnNClosed;

		private int mlngMVertexCount;

		private int mlngNVertexCount;

		private int mlngMDensity;

		private int mlngNDensity;

		private int mlngSplineType;

		private Enums.AcPolymeshType mnumPType;

		private bool mblnFriendLetFlags;

		private Dictionary<object, object> mobjDictVertices;

		private AcadSequenceEnd mobjAcadSequenceEnd;

		internal int FriendLetFlags66
		{
			set
			{
				mlngFlags66 = value;
			}
		}

		internal int FriendGetFlags66 => mlngFlags66;

		internal object FriendGetCode10 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode10), mdblCode10));

		internal object FriendGetCode20 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode20), mdblCode20));

		internal object FriendGetCode30 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode30), mdblCode30));

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				MClosed = ((1 & mlngFlags70) == 1);
				IsSpline = ((4 & mlngFlags70) == 4);
				FriendLetIsPolygonMesh = ((0x10 & mlngFlags70) == 16);
				NClosed = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
				InternCalcFlags70();
			}
		}

		internal string FriendGetPTypeString
		{
			get
			{
				switch (mnumPType)
				{
					case Enums.AcPolymeshType.acSimpleMesh:
						return "Einfaches Polygonnetz";
					case Enums.AcPolymeshType.acCubicSurfaceMesh:
						return "Kubisch geglättetes Polygonnetz";
					case Enums.AcPolymeshType.acQuadSurfaceMesh:
						return "Quadratisch geglättetes Polygonnetz";
					case Enums.AcPolymeshType.acBezierSurfaceMesh:
						return "Bézier geglättetes Polygonnetz";
					default:
						{
							string dstrPolymeshType = default(string);
							return dstrPolymeshType;
						}
				}
			}
		}

		internal string FriendGetSplineTypeString
		{
			get
			{
				switch (mlngSplineType)
				{
					case 0:
						return "Keine glatte Oberfläche angepaßt";
					case 5:
						return "Oberfläche eines quadratischen B-Spline";
					case 6:
						return "Oberfläche eines kubischen B-Spline";
					case 8:
						return "Bézier-Oberfläche";
					default:
						{
							string dstrSplineType = default(string);
							return dstrSplineType;
						}
				}
			}
		}

		internal bool FriendLetIsPolygonMesh
		{
			set
			{
				mblnIsPolygonMesh = value;
			}
		}

		internal bool FriendGetIsPolygonMesh => mblnIsPolygonMesh;

		internal int FriendLetMVertexCount
		{
			set
			{
				if (value >= 0)
				{
					mlngMVertexCount = value;
				}
			}
		}

		internal int FriendLetNVertexCount
		{
			set
			{
				if (value >= 0)
				{
					mlngNVertexCount = value;
				}
			}
		}

		internal int FriendLetMDensity
		{
			set
			{
				if (value >= 2 && value <= 256)
				{
					mlngMDensity = value;
				}
			}
		}

		internal int FriendLetNDensity
		{
			set
			{
				if (value >= 2 && value <= 256)
				{
					mlngNDensity = value;
				}
			}
		}

		public AcadSequenceEnd SequenceEnd
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectSequenceEnd(-1.0, nvblnWithoutObjectID: false, ref nrstrErrMsg);
			}
		}

		public int Flags70 => mlngFlags70;

		public bool IsSpline
		{
			get
			{
				return mblnIsSpline;
			}
			set
			{
				if (mblnIsSpline != value)
				{
					mblnIsSpline = value;
					InternCalcFlags70();
					InternCalcPType();
				}
			}
		}

		public bool MClosed
		{
			get
			{
				return mblnMClosed;
			}
			set
			{
				if (mblnMClosed != value)
				{
					mblnMClosed = value;
					InternCalcFlags70();
				}
			}
		}

		public bool NClosed
		{
			get
			{
				return mblnNClosed;
			}
			set
			{
				if (mblnNClosed != value)
				{
					mblnNClosed = value;
					InternCalcFlags70();
				}
			}
		}

		public int SplineType
		{
			get
			{
				return mlngSplineType;
			}
			set
			{
				if ((value == 0 || value == 5 || value == 6 || value == 8) && mlngSplineType != value)
				{
					mlngSplineType = value;
					if (mlngSplineType == 0)
					{
						mblnIsSpline = false;
					}
					else if (mlngSplineType == 5)
					{
						mblnIsSpline = true;
					}
					else if (mlngSplineType == 6)
					{
						mblnIsSpline = true;
					}
					else if (mlngSplineType == 8)
					{
						mblnIsSpline = true;
					}
					InternCalcFlags70();
					InternCalcPType();
				}
			}
		}

		public Enums.AcPolymeshType PType
		{
			get
			{
				return mnumPType;
			}
			set
			{
				if (mnumPType != value)
				{
					mnumPType = value;
					switch (mnumPType)
					{
						case Enums.AcPolymeshType.acSimpleMesh:
							mblnIsSpline = false;
							mlngSplineType = 0;
							break;
						case Enums.AcPolymeshType.acQuadSurfaceMesh:
							mblnIsSpline = true;
							mlngSplineType = 5;
							break;
						case Enums.AcPolymeshType.acCubicSurfaceMesh:
							mblnIsSpline = true;
							mlngSplineType = 6;
							break;
						case Enums.AcPolymeshType.acBezierSurfaceMesh:
							mblnIsSpline = true;
							mlngSplineType = 8;
							break;
					}
					InternCalcFlags70();
				}
			}
		}

		public object Coordinate
		{
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			get
			{
				object[] dadecCoordinate = new object[3];
				double[] dadblCoordinate = new double[3];
				object Coordinate = default(object);
				AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2;
				if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolygonMesh", "Ungültiger Index.");
				}
				else
				{
					dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcadPolygonMeshVertex2 != null)
					{
						Coordinate = RuntimeHelpers.GetObjectValue(dobjAcadPolygonMeshVertex2.Coordinate);
					}
				}
				dobjAcadPolygonMeshVertex2 = null;
				return Coordinate;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadPolygonMesh", dstrErrMsg);
				}
				else if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolygonMesh", "Ungültiger Index.");
				}
				else
				{
					((AcadPolygonMeshVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)])?.FriendSetCoordinate(RuntimeHelpers.GetObjectValue(value));
				}
				AcadPolygonMeshVertex dobjAcadPolygonMeshVertex = null;
			}
		}

		public object Coordinates
		{
			get
			{
				checked
				{
					object Coordinates = default(object);
					AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2;
					if (mobjDictVertices.Count > 0)
					{
						bool flag = false;
						double[] dadblCoordinate = new double[mobjDictVertices.Count * 3 - 1 + 1];
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngIndex = 0;
						int num = Information.LBound((Array)dvarItems);
						int num2 = Information.UBound((Array)dvarItems);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							if (dobjAcadPolygonMeshVertex2 != null)
							{
								bool flag2 = false;
								dadblCoordinate[dlngIndex * 3] = Conversions.ToDouble(dobjAcadPolygonMeshVertex2.CoordX);
								dadblCoordinate[dlngIndex * 3 + 1] = Conversions.ToDouble(dobjAcadPolygonMeshVertex2.CoordY);
								dadblCoordinate[dlngIndex * 3 + 2] = Conversions.ToDouble(dobjAcadPolygonMeshVertex2.CoordZ);
							}
							dlngIndex++;
						}
						object[] dadecCoordinate = default(object[]);
						Coordinates = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
					}
					dobjAcadPolygonMeshVertex2 = null;
					return Coordinates;
				}
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (value == null)
				{
					InternClearVertices();
					mlngMVertexCount = hwpDxf_Vars.plngMVertexCountNumberOfVertices;
					mlngNVertexCount = hwpDxf_Vars.plngNVertexCountNumberOfFaces;
					return;
				}
				checked
				{
					int dlngLBound = default(int);
					int dlngUBound = default(int);
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(value))) == VariantType.Array)
					{
						dlngLBound = Information.LBound((Array)value);
						dlngUBound = mlngMVertexCount * mlngNVertexCount * 3 - 1 + dlngLBound;
					}
					string dstrErrMsg = default(string);
					if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), dlngLBound, dlngUBound, ref dstrErrMsg))
					{
						Information.Err().Raise(50000, "AcadPolygonMesh", dstrErrMsg);
						return;
					}
					InternClearVertices();
					int num = dlngLBound;
					int num2 = dlngUBound;
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 3)
					{
						double ddblObjectID = base.Database.FriendGetNextObjectID;
						object dvar3DVertex = RuntimeHelpers.GetObjectValue(InternCreate3DVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 1
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 2
						}, null)), dlngIdx == dlngLBound));
						object objectValue = RuntimeHelpers.GetObjectValue(dvar3DVertex);
						string nrstrErrMsg = "";
						FriendAppendVertex(ddblObjectID, objectValue, ref nrstrErrMsg);
					}
				}
			}
		}

		public int MVertexCount => mlngMVertexCount;

		public int NVertexCount => mlngNVertexCount;

		public int MDensity => mlngMDensity;

		public int NDensity => mlngNDensity;

		public AcadPolygonMesh()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 325;
			base.FriendLetNodeImageDisabledID = 326;
			base.FriendLetNodeName = "Polygonnetz";
			base.FriendLetNodeText = "Polygonnetz";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCode10 = hwpDxf_Vars.pdblCode10;
			mdblCode20 = hwpDxf_Vars.pdblCode20;
			mdblCode30 = hwpDxf_Vars.pdblCode30;
			mlngFlags66 = hwpDxf_Vars.plngFlags66;
			mblnMClosed = hwpDxf_Vars.pblnMClosed;
			mblnIsSpline = hwpDxf_Vars.pblnIsSpline;
			mblnIsPolygonMesh = hwpDxf_Vars.pblnIsPolygonMesh;
			mblnNClosed = hwpDxf_Vars.pblnNClosed;
			mlngMVertexCount = hwpDxf_Vars.plngMVertexCountNumberOfVertices;
			mlngNVertexCount = hwpDxf_Vars.plngNVertexCountNumberOfFaces;
			mlngMDensity = hwpDxf_Vars.plngMDensity;
			mlngNDensity = hwpDxf_Vars.plngNDensity;
			mlngSplineType = 0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcPType();
			mobjDictVertices = new Dictionary<object, object>();
			InternClearVertices();
			base.FriendLetDXFName = "POLYLINE";
			base.FriendLetObjectName = "AcDbPolygonMesh";
			base.FriendLetEntityType = Enums.AcEntityName.acPolymesh;
		}

		~AcadPolygonMesh()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClearVertices();
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendQuit();
				}
				base.FriendQuit();
				mobjDictVertices = null;
				mobjAcadSequenceEnd = null;
				mblnOpened = false;
			}
		}

		internal AcadSequenceEnd FriendAddAcadObjectSequenceEnd(double nvdblObjectID = -1.0, bool nvblnWithoutObjectID = false, ref string nrstrErrMsg = "")
		{
			AcadSequenceEnd dobjAcadSequenceEnd2;
			if (mobjAcadSequenceEnd == null)
			{
				dobjAcadSequenceEnd2 = new AcadSequenceEnd();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadSequenceEnd acadSequenceEnd = dobjAcadSequenceEnd2;
				acadSequenceEnd.FriendLetNodeParentID = base.NodeID;
				acadSequenceEnd.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadSequenceEnd.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadSequenceEnd.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadSequenceEnd.FriendLetOwnerID = base.ObjectID;
				bool dblnValid = default(bool);
				if (nvblnWithoutObjectID)
				{
					dblnValid = true;
				}
				else
				{
					AcadSequenceEnd acadSequenceEnd2 = acadSequenceEnd;
					double vdblObjectID = nvdblObjectID;
					AcadObject nrobjAcadObject = dobjAcadSequenceEnd2;
					bool flag = acadSequenceEnd2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
					dobjAcadSequenceEnd2 = (AcadSequenceEnd)nrobjAcadObject;
					if (flag)
					{
						dblnValid = true;
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint(acadSequenceEnd.ObjectName + ": " + nrstrErrMsg);
					}
				}
				acadSequenceEnd = null;
				if (dblnValid)
				{
					mobjAcadSequenceEnd = dobjAcadSequenceEnd2;
				}
			}
			AcadSequenceEnd FriendAddAcadObjectSequenceEnd = mobjAcadSequenceEnd;
			dobjAcadSequenceEnd2 = null;
			return FriendAddAcadObjectSequenceEnd;
		}

		internal AcadPolygonMeshVertex FriendAppendVertex(double vdblObjectID, object vvar3DVertex, ref string nrstrErrMsg = "")
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			nrstrErrMsg = null;
			bool flag = false;
			dadblCoordinate[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar3DVertex, new object[1]
			{
			0
			}, null));
			dadblCoordinate[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar3DVertex, new object[1]
			{
			1
			}, null));
			dadblCoordinate[2] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar3DVertex, new object[1]
			{
			2
			}, null));
			AcadPolygonMeshVertex dobjAcadPolygonMeshVertex3 = new AcadPolygonMeshVertex();
			AcadPolygonMeshVertex acadPolygonMeshVertex = dobjAcadPolygonMeshVertex3;
			acadPolygonMeshVertex.FriendLetCoordinate = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
			acadPolygonMeshVertex.FriendLetNodeParentID = base.NodeID;
			acadPolygonMeshVertex.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPolygonMeshVertex.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPolygonMeshVertex.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPolygonMeshVertex.FriendLetOwnerID = base.ObjectID;
			AcadPolygonMeshVertex acadPolygonMeshVertex2 = acadPolygonMeshVertex;
			AcadObject nrobjAcadObject = dobjAcadPolygonMeshVertex3;
			bool flag2 = acadPolygonMeshVertex2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPolygonMeshVertex3 = (AcadPolygonMeshVertex)nrobjAcadObject;
			if (flag2)
			{
				bool dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPolygonMeshVertex.ObjectName + ": " + nrstrErrMsg);
			}
			acadPolygonMeshVertex = null;
			mobjDictVertices.Add("K" + Conversions.ToString(mobjDictVertices.Count), dobjAcadPolygonMeshVertex3);
			AcadPolygonMeshVertex FriendAppendVertex = dobjAcadPolygonMeshVertex3;
			dobjAcadPolygonMeshVertex3 = null;
			return FriendAppendVertex;
		}

		public void Explode()
		{
		}

		public void Offset(object vvarDistance)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadPolygonMeshVertex AppendVertex(object vvarVertex, string nvstrHandle = null)
		{
			string dstrErrMsg = default(string);
			AcadPolygonMeshVertex AppendVertex = default(AcadPolygonMeshVertex);
			AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2;
			if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(vvarVertex), 0, 2, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadPolygonMesh", dstrErrMsg);
			}
			else
			{
				double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
				object dvar3DVertex = RuntimeHelpers.GetObjectValue(InternCreate3DVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				0
				}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				1
				}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				2
				}, null)), mobjDictVertices.Count == 0));
				dobjAcadPolygonMeshVertex2 = FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(dvar3DVertex), ref dstrErrMsg);
				if (dobjAcadPolygonMeshVertex2 == null)
				{
					Information.Err().Raise(50000, "AcadPolygonMesh", "Der Kontrollpunkt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
				}
				else
				{
					AppendVertex = dobjAcadPolygonMeshVertex2;
				}
			}
			dobjAcadPolygonMeshVertex2 = null;
			return AppendVertex;
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(MClosed, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsSpline, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsPolygonMesh, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(NClosed, 32, 0)));
			}
		}

		private void InternCalcPType()
		{
			if (IsSpline & (mlngSplineType == 8))
			{
				mnumPType = Enums.AcPolymeshType.acBezierSurfaceMesh;
			}
			else if (IsSpline & (mlngSplineType == 6))
			{
				mnumPType = Enums.AcPolymeshType.acQuadSurfaceMesh;
			}
			else if (IsSpline & (mlngSplineType == 5))
			{
				mnumPType = Enums.AcPolymeshType.acCubicSurfaceMesh;
			}
			else if (IsSpline)
			{
				mnumPType = Enums.AcPolymeshType.acQuadSurfaceMesh;
				mlngSplineType = 6;
			}
			else
			{
				mnumPType = Enums.AcPolymeshType.acSimpleMesh;
				mlngSplineType = 0;
			}
		}

		private object InternCreate3DVertex(object vvarCoordX, object vvarCoordY, object vvarCoordZ, bool vblnFirst)
		{
			object[] dadec3DVertex = new object[3];
			double[] dadbl3DVertex = new double[3];
			bool flag = false;
			dadbl3DVertex[0] = Conversions.ToDouble(vvarCoordX);
			dadbl3DVertex[1] = Conversions.ToDouble(vvarCoordY);
			dadbl3DVertex[2] = Conversions.ToDouble(vvarCoordZ);
			return Support.CopyArray(dadbl3DVertex);
		}

		private void InternClearVertices()
		{
			object[] dadecPoint = new object[3];
			double[] dadblPoint = new double[3];
			AcadPolygonMeshVertex dobjAcadPolygonMeshVertex3;
			if (mobjDictVertices.Count > 0)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				mobjDictVertices.Clear();
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcadPolygonMeshVertex3 = (AcadPolygonMeshVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					dobjAcadPolygonMeshVertex3.FriendQuit();
					dobjAcadPolygonMeshVertex3 = null;
				}
			}
			dobjAcadPolygonMeshVertex3 = null;
		}
	}

}
