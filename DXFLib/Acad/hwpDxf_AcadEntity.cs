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
	public class hwpDxf_AcadEntity
	{
		public static void BkAcadEntity_AddReactorsID(ref AcadEntity robjAcadEntity, double vdblObjectID, int vlngCode)
		{
			switch (robjAcadEntity.ObjectName)
			{
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = robjAcadEntity;
						dobjAcadEntity2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadEntity;
						dobjAcad3DFace2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadEntity;
						dobjAcad3DSolid2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadEntity;
						dobjAcadAttribute2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadEntity;
						dobjAcadAttributeReference2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadEntity;
						dobjAcadBlockEnd2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadEntity;
						dobjAcadBlockBegin2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadEntity;
						dobjAcadBlockReference2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadEntity;
						dobjAcadCurve2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadEntity;
						dobjAcad3DPolyline2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadEntity;
						dobjAcadArc2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadEntity;
						dobjAcadCircle2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadEntity;
						dobjAcadEllipse2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadEntity;
						dobjAcadLeader2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadEntity;
						dobjAcadLine2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadEntity;
						dobjAcadLWPolyline2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadEntity;
						dobjAcadPolyline2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadEntity;
						dobjAcad2DVertex2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadEntity;
						dobjAcad3DVertex2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadEntity;
						dobjAcadPolygonMeshVertex2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadEntity;
						dobjAcadPolyfaceMeshVertex2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadEntity;
						dobjAcadFaceRecord2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadEntity;
						dobjAcadRay2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadEntity;
						dobjAcadSpline2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadEntity;
						dobjAcadXline2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadEntity;
						dobjAcadHatch2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadEntity;
						dobjAcadMInsertBlock2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadEntity;
						dobjAcadMLine2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadEntity;
						dobjAcadMText2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadEntity;
						dobjAcadPoint2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadEntity;
						dobjAcadPolyfaceMesh2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadEntity;
						dobjAcadPolygonMesh2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadEntity;
						dobjAcadSequenceEnd2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadEntity;
						dobjAcadShape2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadEntity;
						dobjAcadText2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadEntity.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadEntity;
						dobjAcadTrace2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadEntity;
						dobjAcadSolid2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadSolid2 = null;
					}
					break;
				default:
					try
					{
						AcadUnknownEnt dobjAcadUnknownEnt2 = (AcadUnknownEnt)robjAcadEntity;
						dobjAcadUnknownEnt2.FriendAddReactorsID(vdblObjectID, vlngCode);
						dobjAcadUnknownEnt2 = null;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						ProjectData.ClearProjectError();
					}
					break;
			}
		}

		public static void BkAcadEntity_RemoveReactorsID(ref AcadEntity robjAcadEntity, double vdblObjectID)
		{
			switch (robjAcadEntity.ObjectName)
			{
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = robjAcadEntity;
						dobjAcadEntity2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadEntity;
						dobjAcad3DFace2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadEntity;
						dobjAcad3DSolid2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadEntity;
						dobjAcadAttribute2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadEntity;
						dobjAcadAttributeReference2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadEntity;
						dobjAcadBlockEnd2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadEntity;
						dobjAcadBlockBegin2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadEntity;
						dobjAcadBlockReference2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadEntity;
						dobjAcadCurve2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadEntity;
						dobjAcad3DPolyline2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadEntity;
						dobjAcadArc2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadEntity;
						dobjAcadCircle2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadEntity;
						dobjAcadEllipse2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadEntity;
						dobjAcadLeader2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadEntity;
						dobjAcadLine2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadEntity;
						dobjAcadLWPolyline2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadEntity;
						dobjAcadPolyline2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadEntity;
						dobjAcad2DVertex2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadEntity;
						dobjAcad3DVertex2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadEntity;
						dobjAcadPolygonMeshVertex2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadEntity;
						dobjAcadPolyfaceMeshVertex2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadEntity;
						dobjAcadFaceRecord2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadEntity;
						dobjAcadRay2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadEntity;
						dobjAcadSpline2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadEntity;
						dobjAcadXline2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadEntity;
						dobjAcadHatch2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadEntity;
						dobjAcadMInsertBlock2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadEntity;
						dobjAcadMLine2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadEntity;
						dobjAcadMText2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadEntity;
						dobjAcadPoint2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadEntity;
						dobjAcadPolyfaceMesh2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadEntity;
						dobjAcadPolygonMesh2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadEntity;
						dobjAcadSequenceEnd2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadEntity;
						dobjAcadShape2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadEntity;
						dobjAcadText2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadEntity.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadEntity;
						dobjAcadTrace2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadEntity;
						dobjAcadSolid2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadSolid2 = null;
					}
					break;
				default:
					try
					{
						AcadUnknownEnt dobjAcadUnknownEnt2 = (AcadUnknownEnt)robjAcadEntity;
						dobjAcadUnknownEnt2.FriendRemoveReactorsID(vdblObjectID);
						dobjAcadUnknownEnt2 = null;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						ProjectData.ClearProjectError();
					}
					break;
			}
		}
	}
}
