using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
	class Acad3DPolyline : AcadCurve
	{
		private const string cstrClassName = "Acad3DPolyline";

		private const int clngClosed = 1;

		private const int clngIsSpline = 4;

		private const int clngIs3DPolyline = 8;

		private const short clngSplineTypeNone = 0;

		private const short clngSplineTypeCubicSpline = 5;

		private const short clngSplineTypeQuadSpline = 6;

		private bool mblnOpened;

		private object mdecMinMaxCenterX;

		private double mdblMinMaxCenterX;

		private object mdecMinMaxCenterY;

		private double mdblMinMaxCenterY;

		private object mdecMinMaxCenterZ;

		private double mdblMinMaxCenterZ;

		private object mdecMaxCoordX;

		private double mdblMaxCoordX;

		private object mdecMinCoordX;

		private double mdblMinCoordX;

		private object mdecMaxCoordY;

		private double mdblMaxCoordY;

		private object mdecMinCoordY;

		private double mdblMinCoordY;

		private object mdecMaxCoordZ;

		private double mdblMaxCoordZ;

		private object mdecMinCoordZ;

		private double mdblMinCoordZ;

		private int mlngFlags66;

		private object mdecCode10;

		private double mdblCode10;

		private object mdecCode20;

		private double mdblCode20;

		private object mdecCode30;

		private double mdblCode30;

		private int mlngFlags70;

		private bool mblnIsSpline;

		private bool mblnIs3DPolyline;

		private int mlngSplineType;

		private Enums.Ac3dPolylineType mnumPType;

		private bool mblnFriendLetFlags;

		private bool mblnFriendCalcSizeStop;

		private Dictionary<object, object> mobjDictVertices;

		private AcadSequenceEnd mobjAcadSequenceEnd;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetDatabaseIndex = value;
				}
				Acad3DVertex dobjAcad3DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad3DVertex2 != null)
						{
							dobjAcad3DVertex2.FriendLetDatabaseIndex = value;
						}
					}
				}
				dobjAcad3DVertex2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetDocumentIndex = value;
				}
				Acad3DVertex dobjAcad3DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad3DVertex2 != null)
						{
							dobjAcad3DVertex2.FriendLetDocumentIndex = value;
						}
					}
				}
				dobjAcad3DVertex2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetApplicationIndex = value;
				}
				Acad3DVertex dobjAcad3DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad3DVertex2 != null)
						{
							dobjAcad3DVertex2.FriendLetApplicationIndex = value;
						}
					}
				}
				dobjAcad3DVertex2 = null;
			}
		}

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
				Closed = ((1 & mlngFlags70) == 1);
				IsSpline = ((4 & mlngFlags70) == 4);
				mblnIs3DPolyline = ((8 & mlngFlags70) == 8);
				mblnFriendLetFlags = false;
				InternCalcFlags70();
			}
		}

		internal bool FriendCalcSizeStop
		{
			set
			{
				mblnFriendCalcSizeStop = value;
			}
		}

		internal string FriendGetPTypeString
		{
			get
			{
				switch (mnumPType)
				{
					case Enums.Ac3dPolylineType.acSimple3DPoly:
						return "Einfache 3D-Polylinie";
					case Enums.Ac3dPolylineType.acCubicSplined3dPoly:
						return "Kubische geglättete 3D-Polylinie";
					case Enums.Ac3dPolylineType.acQuadSpline3DPoly:
						return "Quadratisch geglättet 3D-Polylinie";
					default:
						{
							string dstr3DPolylineType = default(string);
							return dstr3DPolylineType;
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
					default:
						{
							string dstrSplineType = default(string);
							return dstrSplineType;
						}
				}
			}
		}

		internal bool FriendGetIs3DPolyline => mblnIs3DPolyline;

		public AcadSequenceEnd SequenceEnd
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectSequenceEnd(-1.0, nvblnWithoutObjectID: false, ref nrstrErrMsg);
			}
		}

		public int Flags70 => mlngFlags70;

		public bool Closed
		{
			get
			{
				return base.IsClosed;
			}
			set
			{
				if (base.IsClosed != value)
				{
					base.FriendLetIsClosed = value;
					InternCalcFlags70();
					InternCalcSize();
				}
			}
		}

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
					InternCalcSize();
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
				if ((value == 0 || value == 5 || value == 6) && mlngSplineType != value)
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
					InternCalcFlags70();
					InternCalcPType();
					InternCalcSize();
				}
			}
		}

		public Enums.Ac3dPolylineType PType
		{
			set
			{
				if (mnumPType != value)
				{
					mnumPType = value;
					switch (mnumPType)
					{
						case Enums.Ac3dPolylineType.acSimple3DPoly:
							mblnIsSpline = false;
							mlngSplineType = 0;
							break;
						case Enums.Ac3dPolylineType.acCubicSplined3dPoly:
							mblnIsSpline = true;
							mlngSplineType = 5;
							break;
						case Enums.Ac3dPolylineType.acQuadSpline3DPoly:
							mblnIsSpline = true;
							mlngSplineType = 6;
							break;
					}
					InternCalcFlags70();
					InternCalcSize();
				}
			}
		}

		public Enums.Ac3dPolylineType Pype
		{
			get
			{
				PType = mnumPType;
				Enums.Ac3dPolylineType Pype = default(Enums.Ac3dPolylineType);
				return Pype;
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
				Acad3DVertex dobjAcad3DVertex2;
				if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "Acad3DPolyline", "Ungültiger Index.");
				}
				else
				{
					dobjAcad3DVertex2 = (Acad3DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcad3DVertex2 != null)
					{
						Coordinate = RuntimeHelpers.GetObjectValue(dobjAcad3DVertex2.Coordinate);
					}
				}
				dobjAcad3DVertex2 = null;
				return Coordinate;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				Acad3DVertex dobjAcad3DVertex2;
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "Acad3DPolyline", dstrErrMsg);
				}
				else if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "Acad3DPolyline", "Ungültiger Index.");
				}
				else
				{
					dobjAcad3DVertex2 = (Acad3DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcad3DVertex2 != null)
					{
						dobjAcad3DVertex2.FriendSetCoordinate(RuntimeHelpers.GetObjectValue(value));
						InternCalcSize();
					}
				}
				dobjAcad3DVertex2 = null;
			}
		}

		public object Coordinates
		{
			get
			{
				checked
				{
					object Coordinates = default(object);
					Acad3DVertex dobjAcad3DVertex2;
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
							dobjAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							if (dobjAcad3DVertex2 != null)
							{
								bool flag2 = false;
								dadblCoordinate[dlngIndex * 3] = Conversions.ToDouble(dobjAcad3DVertex2.CoordX);
								dadblCoordinate[dlngIndex * 3 + 1] = Conversions.ToDouble(dobjAcad3DVertex2.CoordY);
								dadblCoordinate[dlngIndex * 3 + 2] = Conversions.ToDouble(dobjAcad3DVertex2.CoordZ);
							}
							dlngIndex++;
						}
						object[] dadecCoordinate = default(object[]);
						Coordinates = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
					}
					dobjAcad3DVertex2 = null;
					return Coordinates;
				}
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (value == null)
				{
					InternClearVertices();
					return;
				}
				checked
				{
					int dlngLBound = default(int);
					int dlngUBound2 = default(int);
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(value))) == VariantType.Array)
					{
						dlngLBound = Information.LBound((Array)value);
						dlngUBound2 = Information.UBound((Array)value);
						int dlngCount2 = dlngUBound2 - dlngLBound + 1;
						dlngCount2 = (int)Math.Round(Conversion.Fix((double)dlngCount2 / 3.0) * 3.0);
						dlngUBound2 = dlngCount2 - 1 + dlngLBound;
					}
					string dstrErrMsg = default(string);
					if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), dlngLBound, dlngUBound2, ref dstrErrMsg))
					{
						Information.Err().Raise(50000, "Acad3DPolyline", dstrErrMsg);
						return;
					}
					InternClearVertices();
					int num = dlngLBound;
					int num2 = dlngUBound2;
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
					InternCalcSize();
				}
			}
		}

		public object MaxCoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordX), mdblMaxCoordX));

		public object MaxCoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordY), mdblMaxCoordY));

		public object MaxCoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordZ), mdblMaxCoordZ));

		public object MinCoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordX), mdblMinCoordX));

		public object MinCoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordY), mdblMinCoordY));

		public object MinCoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordZ), mdblMinCoordZ));

		public object MinMaxCenterX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterX), mdblMinMaxCenterX));

		public object MinMaxCenterY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterY), mdblMinMaxCenterY));

		public object MinMaxCenterZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterZ), mdblMinMaxCenterZ));

		public int NumVerts => mobjDictVertices.Count;

		public object Length => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

		public Acad3DPolyline()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurve3dPolyline;
			base.FriendLetNodeImageEnabledID = 317;
			base.FriendLetNodeImageDisabledID = 318;
			base.FriendLetNodeName = "3D-Polylinie";
			base.FriendLetNodeText = "3D-Polylinie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCode10 = hwpDxf_Vars.pdblCode10;
			mdblCode20 = hwpDxf_Vars.pdblCode20;
			mdblCode30 = hwpDxf_Vars.pdblCode30;
			mlngFlags66 = hwpDxf_Vars.plngFlags66;
			mblnIsSpline = hwpDxf_Vars.pblnIsSpline;
			mblnIs3DPolyline = hwpDxf_Vars.pblnIs3DPolyline;
			mlngSplineType = 0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcPType();
			mblnFriendCalcSizeStop = false;
			mobjDictVertices = new Dictionary<object, object>();
			InternClearVertices();
			base.FriendLetDXFName = "POLYLINE";
			base.FriendLetObjectName = "AcDb3dPolyline";
			base.FriendLetEntityType = Enums.AcEntityName.ac3dPolyline;
		}

		~Acad3DPolyline()
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

		internal void FriendCalcSize()
		{
			mblnFriendCalcSizeStop = false;
			InternCalcSize();
		}

		internal Acad3DVertex FriendAppendVertex(double vdblObjectID, object vvar3DVertex, ref string nrstrErrMsg = "")
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
			Acad3DVertex dobjAcad3DVertex3 = new Acad3DVertex();
			Acad3DVertex acad3DVertex = dobjAcad3DVertex3;
			acad3DVertex.FriendLetCoordinate = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
			acad3DVertex.FriendLetNodeParentID = base.NodeID;
			acad3DVertex.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acad3DVertex.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acad3DVertex.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acad3DVertex.FriendLetOwnerID = base.ObjectID;
			Acad3DVertex acad3DVertex2 = acad3DVertex;
			AcadObject nrobjAcadObject = dobjAcad3DVertex3;
			bool flag2 = acad3DVertex2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcad3DVertex3 = (Acad3DVertex)nrobjAcadObject;
			if (flag2)
			{
				bool dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acad3DVertex.ObjectName + ": " + nrstrErrMsg);
			}
			acad3DVertex = null;
			mobjDictVertices.Add("K" + Conversions.ToString(mobjDictVertices.Count), dobjAcad3DVertex3);
			if (checked(mobjDictVertices.Count - 1) == 0)
			{
				base.FriendLetStartPoint = RuntimeHelpers.GetObjectValue(dobjAcad3DVertex3.Coordinate);
			}
			base.FriendLetEndPoint = RuntimeHelpers.GetObjectValue(dobjAcad3DVertex3.Coordinate);
			InternCalcSize();
			Acad3DVertex FriendAppendVertex = dobjAcad3DVertex3;
			dobjAcad3DVertex3 = null;
			return FriendAppendVertex;
		}

		public void Explode()
		{
		}

		public void Offset(object vvarDistance)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public Acad3DVertex AppendVertex(object vvarVertex, string nvstrHandle = null)
		{
			string dstrErrMsg = default(string);
			Acad3DVertex AppendVertex = default(Acad3DVertex);
			Acad3DVertex dobjAcad3DVertex2;
			if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(vvarVertex), 0, 2, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "Acad3DPolyline", dstrErrMsg);
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
				dobjAcad3DVertex2 = FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(dvar3DVertex), ref dstrErrMsg);
				if (dobjAcad3DVertex2 == null)
				{
					Information.Err().Raise(50000, "Acad3DPolyline", "Der Kontrollpunkt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
				}
				else
				{
					AppendVertex = dobjAcad3DVertex2;
				}
			}
			dobjAcad3DVertex2 = null;
			return AppendVertex;
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Closed, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsSpline, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIs3DPolyline, 8, 0)));
			}
		}

		private void InternCalcPType()
		{
			if (IsSpline & (mlngSplineType == 6))
			{
				mnumPType = Enums.Ac3dPolylineType.acQuadSpline3DPoly;
			}
			else if (IsSpline & (mlngSplineType == 5))
			{
				mnumPType = Enums.Ac3dPolylineType.acCubicSplined3dPoly;
			}
			else if (IsSpline)
			{
				mnumPType = Enums.Ac3dPolylineType.acQuadSpline3DPoly;
				mlngSplineType = 6;
			}
			else
			{
				mnumPType = Enums.Ac3dPolylineType.acSimple3DPoly;
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
			Acad3DVertex dobjAcad3DVertex3;
			if (mobjDictVertices.Count > 0)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				mobjDictVertices.Clear();
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcad3DVertex3 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					dobjAcad3DVertex3.FriendQuit();
					dobjAcad3DVertex3 = null;
				}
			}
			bool flag = false;
			mdblMaxCoordX = 0.0;
			mdblMinCoordX = 0.0;
			mdblMaxCoordY = 0.0;
			mdblMinCoordY = 0.0;
			mdblMaxCoordZ = 0.0;
			mdblMinCoordZ = 0.0;
			mdblMinMaxCenterX = 0.0;
			mdblMinMaxCenterY = 0.0;
			mdblMinMaxCenterZ = 0.0;
			dadblPoint[0] = 0.0;
			dadblPoint[1] = 0.0;
			dadblPoint[2] = 0.0;
			base.FriendLetStartPoint = Support.CopyArray(dadblPoint);
			base.FriendLetEndPoint = Support.CopyArray(dadblPoint);
			base.FriendLetLength = 0.0;
			dobjAcad3DVertex3 = null;
		}

		private void InternCalcSize()
		{
			checked
			{
				Acad3DVertex dobjSecondAcad3DVertex2;
				Acad3DVertex dobjFirstAcad3DVertex2;
				Acad3DVertex dobjStartAcad3DVertex2;
				if (!mblnFriendCalcSizeStop)
				{
					object dvarLen = 0m;
					bool dblnClosed = Closed;
					if (mobjDictVertices.Count > 1)
					{
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngLBound = Information.LBound((Array)dvarItems);
						int dlngUBound = Information.UBound((Array)dvarItems);
						dobjStartAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngLBound
						}, null);
						dobjFirstAcad3DVertex2 = dobjStartAcad3DVertex2;
						int num = dlngLBound + 1;
						int num2 = dlngUBound;
						object dvarSegLen = default(object);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							dobjSecondAcad3DVertex2 = (Acad3DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							InternCalcSeg(dlngIdx == dlngLBound + 1, dobjFirstAcad3DVertex2, dobjSecondAcad3DVertex2, ref dvarSegLen, vblnCalcLen: true, vblnIgnoreBulg: false);
							dvarLen = Operators.AddObject(dvarLen, dvarSegLen);
							dobjFirstAcad3DVertex2 = dobjSecondAcad3DVertex2;
						}
						InternCalcSeg(vblnFirst: false, dobjFirstAcad3DVertex2, dobjStartAcad3DVertex2, ref dvarSegLen, dblnClosed, !dblnClosed);
						dvarLen = Operators.AddObject(dvarLen, dvarSegLen);
					}
					base.FriendLetLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(dvarLen), Conversions.ToDouble(dvarLen)));
					bool flag = false;
					mdblMinMaxCenterX = mdblMinCoordX + (mdblMaxCoordX - mdblMinCoordX) / 2.0;
					mdblMinMaxCenterY = mdblMinCoordY + (mdblMaxCoordY - mdblMinCoordY) / 2.0;
					mdblMinMaxCenterZ = mdblMinCoordZ + (mdblMaxCoordZ - mdblMinCoordZ) / 2.0;
				}
				dobjSecondAcad3DVertex2 = null;
				dobjFirstAcad3DVertex2 = null;
				dobjStartAcad3DVertex2 = null;
			}
		}

		private void InternCalcSeg(bool vblnFirst, Acad3DVertex dobjFirstAcad3DVertex, Acad3DVertex dobjSecondAcad3DVertex, ref object rvarLen, bool vblnCalcLen, bool vblnIgnoreBulg)
		{
			object[] dadecPoint1 = new object[3];
			double[] dadblPoint1 = new double[3];
			object[] dadecPoint2 = new object[3];
			double[] dadblPoint2 = new double[3];
			rvarLen = 0m;
			bool flag = false;
			double ddblCoordX1 = Conversions.ToDouble(dobjFirstAcad3DVertex.CoordX);
			double ddblCoordY1 = Conversions.ToDouble(dobjFirstAcad3DVertex.CoordY);
			double ddblCoordZ1 = Conversions.ToDouble(dobjFirstAcad3DVertex.CoordZ);
			double ddblCoordX2 = Conversions.ToDouble(dobjSecondAcad3DVertex.CoordX);
			double ddblCoordY2 = Conversions.ToDouble(dobjSecondAcad3DVertex.CoordY);
			double ddblCoordZ2 = Conversions.ToDouble(dobjSecondAcad3DVertex.CoordZ);
			if (vblnFirst)
			{
				bool flag2 = false;
				mdblMaxCoordX = ddblCoordX1;
				mdblMinCoordX = ddblCoordX1;
				mdblMaxCoordY = ddblCoordY1;
				mdblMinCoordY = ddblCoordY1;
				mdblMaxCoordZ = ddblCoordZ1;
				mdblMinCoordZ = ddblCoordZ1;
			}
			else
			{
				bool flag3 = false;
				if (ddblCoordX1 > mdblMaxCoordX)
				{
					mdblMaxCoordX = ddblCoordX1;
				}
				if (ddblCoordX1 < mdblMinCoordX)
				{
					mdblMinCoordX = ddblCoordX1;
				}
				if (ddblCoordY1 > mdblMaxCoordY)
				{
					mdblMaxCoordY = ddblCoordY1;
				}
				if (ddblCoordY1 < mdblMinCoordY)
				{
					mdblMinCoordY = ddblCoordY1;
				}
				if (ddblCoordZ1 > mdblMaxCoordZ)
				{
					mdblMaxCoordZ = ddblCoordZ1;
				}
				if (ddblCoordZ1 < mdblMinCoordZ)
				{
					mdblMinCoordZ = ddblCoordZ1;
				}
			}
			bool flag4 = false;
			dadblPoint1[0] = ddblCoordX1;
			dadblPoint1[1] = ddblCoordY1;
			dadblPoint1[2] = ddblCoordZ1;
			dadblPoint2[0] = ddblCoordX2;
			dadblPoint2[1] = ddblCoordY2;
			dadblPoint2[2] = ddblCoordZ2;
			if (vblnCalcLen)
			{
				bool flag5 = false;
				rvarLen = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.LineLength(dadblPoint1, dadblPoint2));
			}
		}
	}
}
