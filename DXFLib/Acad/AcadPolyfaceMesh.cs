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
	public class AcadPolyfaceMesh : AcadEntity
	{
		private const string cstrClassName = "AcadPolyfaceMesh";

		private const int clngIsPolyfaceMesh = 64;

		private bool mblnOpened;

		private int mlngFlags66;

		private object mdecCode10;

		private double mdblCode10;

		private object mdecCode20;

		private double mdblCode20;

		private object mdecCode30;

		private double mdblCode30;

		private int mlngFlags70;

		private bool mblnIsPolyfaceMesh;

		private int mlngNumberOfVertices;

		private int mlngNumberOfFaces;

		private bool mblnFriendLetFlags;

		private Dictionary<object, object> mobjDictVertices;

		private Dictionary<object, object> mobjDictFaceRecords;

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
				FriendLetIsPolyfaceMesh = ((0x40 & mlngFlags70) == 64);
				mblnFriendLetFlags = false;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetIsPolyfaceMesh
		{
			set
			{
				mblnIsPolyfaceMesh = value;
			}
		}

		internal bool FriendGetIsPolyfaceMesh => mblnIsPolyfaceMesh;

		internal int FriendLetNumberOfVertices
		{
			set
			{
				if (value >= 0)
				{
					mlngNumberOfVertices = value;
				}
			}
		}

		internal int FriendLetNumberOfFaces
		{
			set
			{
				if (value >= 0)
				{
					mlngNumberOfFaces = value;
				}
			}
		}

		internal object FriendLetFaces
		{
			set
			{
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

		public object Coordinate
		{
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			get
			{
				object[] dadecCoordinate = new object[3];
				double[] dadblCoordinate = new double[3];
				object Coordinate = default(object);
				AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2;
				if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolyfaceMesh", "Ungültiger Index.");
				}
				else
				{
					dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcadPolyfaceMeshVertex2 != null)
					{
						Coordinate = RuntimeHelpers.GetObjectValue(dobjAcadPolyfaceMeshVertex2.Coordinate);
					}
				}
				dobjAcadPolyfaceMeshVertex2 = null;
				return Coordinate;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadPolyfaceMesh", dstrErrMsg);
				}
				else if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolyfaceMesh", "Ungültiger Index.");
				}
				else
				{
					((AcadPolyfaceMeshVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)])?.FriendSetCoordinate(RuntimeHelpers.GetObjectValue(value));
				}
				AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex = null;
			}
		}

		public object Coordinates
		{
			get
			{
				checked
				{
					object Coordinates = default(object);
					AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2;
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
							dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							if (dobjAcadPolyfaceMeshVertex2 != null)
							{
								bool flag2 = false;
								dadblCoordinate[dlngIndex * 3] = Conversions.ToDouble(dobjAcadPolyfaceMeshVertex2.CoordX);
								dadblCoordinate[dlngIndex * 3 + 1] = Conversions.ToDouble(dobjAcadPolyfaceMeshVertex2.CoordY);
								dadblCoordinate[dlngIndex * 3 + 2] = Conversions.ToDouble(dobjAcadPolyfaceMeshVertex2.CoordZ);
							}
							dlngIndex++;
						}
						object[] dadecCoordinate = default(object[]);
						Coordinates = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
					}
					dobjAcadPolyfaceMeshVertex2 = null;
					return Coordinates;
				}
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (value == null)
				{
					InternClearVertices();
					mlngNumberOfVertices = hwpDxf_Vars.plngMVertexCountNumberOfVertices;
					return;
				}
				checked
				{
					int dlngLBound = default(int);
					int dlngUBound = default(int);
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(value))) == VariantType.Array)
					{
						dlngLBound = Information.LBound((Array)value);
						dlngUBound = mlngNumberOfVertices - 1 + dlngLBound;
					}
					string dstrErrMsg = default(string);
					if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), dlngLBound, dlngUBound, ref dstrErrMsg))
					{
						Information.Err().Raise(50000, "AcadPolyfaceMesh", dstrErrMsg);
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

		public int NumberOfVertices => mlngNumberOfVertices;

		public int NumberOfFaces => mlngNumberOfFaces;

		public AcadPolyfaceMesh()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 333;
			base.FriendLetNodeImageDisabledID = 334;
			base.FriendLetNodeName = "Vielflächennetz";
			base.FriendLetNodeText = "Vielflächennetz";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCode10 = hwpDxf_Vars.pdblCode10;
			mdblCode20 = hwpDxf_Vars.pdblCode20;
			mdblCode30 = hwpDxf_Vars.pdblCode30;
			mlngFlags66 = hwpDxf_Vars.plngFlags66;
			mblnIsPolyfaceMesh = hwpDxf_Vars.pblnIsPolyfaceMesh;
			mlngNumberOfVertices = hwpDxf_Vars.plngMVertexCountNumberOfVertices;
			mlngNumberOfFaces = hwpDxf_Vars.plngNVertexCountNumberOfFaces;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			mobjDictVertices = new Dictionary<object, object>();
			InternClearVertices();
			mobjDictFaceRecords = new Dictionary<object, object>();
			InternClearFaces();
			base.FriendLetDXFName = "POLYLINE";
			base.FriendLetObjectName = "AcDbPolyFaceMesh";
			base.FriendLetEntityType = Enums.AcEntityName.acPolyfaceMesh;
		}

		~AcadPolyfaceMesh()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClearVertices();
				InternClearFaces();
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendQuit();
				}
				base.FriendQuit();
				mobjDictFaceRecords = null;
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

		internal AcadPolyfaceMeshVertex FriendAppendVertex(double vdblObjectID, object vvar3DVertex, ref string nrstrErrMsg = "")
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
			AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex3 = new AcadPolyfaceMeshVertex();
			AcadPolyfaceMeshVertex acadPolyfaceMeshVertex = dobjAcadPolyfaceMeshVertex3;
			acadPolyfaceMeshVertex.FriendLetCoordinate = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
			acadPolyfaceMeshVertex.FriendLetNodeParentID = base.NodeID;
			acadPolyfaceMeshVertex.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPolyfaceMeshVertex.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPolyfaceMeshVertex.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPolyfaceMeshVertex.FriendLetOwnerID = base.ObjectID;
			AcadPolyfaceMeshVertex acadPolyfaceMeshVertex2 = acadPolyfaceMeshVertex;
			AcadObject nrobjAcadObject = dobjAcadPolyfaceMeshVertex3;
			bool flag2 = acadPolyfaceMeshVertex2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPolyfaceMeshVertex3 = (AcadPolyfaceMeshVertex)nrobjAcadObject;
			if (flag2)
			{
				bool dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPolyfaceMeshVertex.ObjectName + ": " + nrstrErrMsg);
			}
			acadPolyfaceMeshVertex = null;
			mobjDictVertices.Add("K" + Conversions.ToString(mobjDictVertices.Count), dobjAcadPolyfaceMeshVertex3);
			AcadPolyfaceMeshVertex FriendAppendVertex = dobjAcadPolyfaceMeshVertex3;
			dobjAcadPolyfaceMeshVertex3 = null;
			return FriendAppendVertex;
		}

		internal AcadFaceRecord FriendAppendFace(double vdblObjectID, int vlngVertex1, int vlngVertex2, int vlngVertex3, int vlngVertex4, ref string nrstrErrMsg = "")
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			nrstrErrMsg = null;
			AcadFaceRecord dobjAcadFaceRecord3 = new AcadFaceRecord();
			AcadFaceRecord acadFaceRecord = dobjAcadFaceRecord3;
			acadFaceRecord.FriendLetVertex1 = vlngVertex1;
			acadFaceRecord.FriendLetVertex2 = vlngVertex2;
			acadFaceRecord.FriendLetVertex3 = vlngVertex3;
			acadFaceRecord.FriendLetVertex4 = vlngVertex4;
			acadFaceRecord.FriendLetNodeParentID = base.NodeID;
			acadFaceRecord.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadFaceRecord.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadFaceRecord.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadFaceRecord.FriendLetOwnerID = base.ObjectID;
			AcadFaceRecord acadFaceRecord2 = acadFaceRecord;
			AcadObject nrobjAcadObject = dobjAcadFaceRecord3;
			bool flag = acadFaceRecord2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadFaceRecord3 = (AcadFaceRecord)nrobjAcadObject;
			if (flag)
			{
				bool dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadFaceRecord.ObjectName + ": " + nrstrErrMsg);
			}
			acadFaceRecord = null;
			mobjDictFaceRecords.Add("K" + Conversions.ToString(mobjDictFaceRecords.Count), dobjAcadFaceRecord3);
			AcadFaceRecord FriendAppendFace = dobjAcadFaceRecord3;
			dobjAcadFaceRecord3 = null;
			return FriendAppendFace;
		}

		public void Explode()
		{
		}

		public void Offset(object vvarDistance)
		{
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsPolyfaceMesh, 64, 0)));
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
			AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex3;
			if (mobjDictVertices.Count > 0)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				mobjDictVertices.Clear();
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcadPolyfaceMeshVertex3 = (AcadPolyfaceMeshVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					dobjAcadPolyfaceMeshVertex3.FriendQuit();
					dobjAcadPolyfaceMeshVertex3 = null;
				}
			}
			dobjAcadPolyfaceMeshVertex3 = null;
		}

		private void InternClearFaces()
		{
			object[] dadecPoint = new object[3];
			double[] dadblPoint = new double[3];
			AcadFaceRecord dobjAcadFaceRecord3;
			if (mobjDictFaceRecords.Count > 0)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictFaceRecords.Values));
				mobjDictFaceRecords.Clear();
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcadFaceRecord3 = (AcadFaceRecord)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					dobjAcadFaceRecord3.FriendQuit();
					dobjAcadFaceRecord3 = null;
				}
			}
			dobjAcadFaceRecord3 = null;
		}
	}

}
