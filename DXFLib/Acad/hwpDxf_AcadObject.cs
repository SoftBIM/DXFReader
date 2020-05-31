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
    public class hwpDxf_AcadObject
	{
		public static void BkAcadObject_Quit(ref AcadObject robjAcadObject)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2.FriendQuit();
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendQuit();
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendQuit();
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendQuit();
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendQuit();
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendQuit();
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendQuit();
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendQuit();
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendQuit();
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendQuit();
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendQuit();
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendQuit();
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendQuit();
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendQuit();
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendQuit();
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendQuit();
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendQuit();
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendQuit();
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendQuit();
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendQuit();
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendQuit();
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendQuit();
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendQuit();
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendQuit();
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendQuit();
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendQuit();
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendQuit();
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendQuit();
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendQuit();
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendQuit();
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendQuit();
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendQuit();
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendQuit();
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendQuit();
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendQuit();
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendQuit();
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendQuit();
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendQuit();
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendQuit();
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendQuit();
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendQuit();
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendQuit();
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2.FriendQuit();
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendQuit();
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendQuit();
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendQuit();
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendQuit();
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendQuit();
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendQuit();
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendQuit();
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendQuit();
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = robjAcadObject as AcadProxyObject;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendQuit();
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendQuit();
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendQuit();
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendQuit();
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendQuit();
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendQuit();
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendQuit();
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendQuit();
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendQuit();
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendQuit();
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendQuit();
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendQuit();
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendQuit();
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendQuit();
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendQuit();
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendQuit();
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendQuit();
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendQuit();
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendQuit();
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendQuit();
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendQuit();
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendQuit();
					}
					break;
			}
		}

		public static void BkAcadObject_LetNodeParentID(ref AcadObject robjAcadObject, int vlngNodeParentID)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = (AcadProxyObject)robjAcadObject;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendLetNodeParentID = vlngNodeParentID;
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendLetNodeParentID = vlngNodeParentID;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendLetNodeParentID = vlngNodeParentID;
					}
					break;
			}
		}

		public static bool BkAcadObject_SetObjectID(ref AcadObject robjAcadObject, double vdblObjectID, ref string nrstrErrMsg = "")
		{
			bool BkAcadObject_SetObjectID;
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						BkAcadObject_SetObjectID = dobjAcadObject2.FriendSetObjectID(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg);
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary3 = (AcadDictionary)robjAcadObject;
						AcadDictionary acadDictionary = dobjAcadDictionary3;
						AcadObject nrobjAcadObject = dobjAcadDictionary3;
						bool flag = acadDictionary.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDictionary3 = (AcadDictionary)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDictionary3 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault3 = (AcadDictionaryWithDefault)robjAcadObject;
						AcadDictionaryWithDefault acadDictionaryWithDefault = dobjAcadDictionaryWithDefault3;
						AcadObject nrobjAcadObject = dobjAcadDictionaryWithDefault3;
						bool flag = acadDictionaryWithDefault.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDictionaryWithDefault3 = (AcadDictionaryWithDefault)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDictionaryWithDefault3 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries3 = (AcadDictionaries)robjAcadObject;
						AcadDictionaries acadDictionaries = dobjAcadDictionaries3;
						AcadObject nrobjAcadObject = dobjAcadDictionaries3;
						bool flag = acadDictionaries.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDictionaries3 = (AcadDictionaries)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDictionaries3 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups3 = (AcadGroups)robjAcadObject;
						AcadGroups acadGroups = dobjAcadGroups3;
						AcadObject nrobjAcadObject = dobjAcadGroups3;
						bool flag = acadGroups.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadGroups3 = (AcadGroups)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadGroups3 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts3 = (AcadLayouts)robjAcadObject;
						AcadLayouts acadLayouts = dobjAcadLayouts3;
						AcadObject nrobjAcadObject = dobjAcadLayouts3;
						bool flag = acadLayouts.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLayouts3 = (AcadLayouts)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLayouts3 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles3 = (AcadMLineStyles)robjAcadObject;
						AcadMLineStyles acadMLineStyles = dobjAcadMLineStyles3;
						AcadObject nrobjAcadObject = dobjAcadMLineStyles3;
						bool flag = acadMLineStyles.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadMLineStyles3 = (AcadMLineStyles)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadMLineStyles3 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations3 = (AcadPlotConfigurations)robjAcadObject;
						AcadPlotConfigurations acadPlotConfigurations = dobjAcadPlotConfigurations3;
						AcadObject nrobjAcadObject = dobjAcadPlotConfigurations3;
						bool flag = acadPlotConfigurations.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPlotConfigurations3 = (AcadPlotConfigurations)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPlotConfigurations3 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout3 = (AcadLayout)robjAcadObject;
						AcadLayout acadLayout = dobjAcadLayout3;
						AcadObject nrobjAcadObject = dobjAcadLayout3;
						bool flag = acadLayout.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLayout3 = (AcadLayout)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLayout3 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar3 = (AcadDictionaryVar)robjAcadObject;
						AcadDictionaryVar acadDictionaryVar = dobjAcadDictionaryVar3;
						AcadObject nrobjAcadObject = dobjAcadDictionaryVar3;
						bool flag = acadDictionaryVar.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDictionaryVar3 = (AcadDictionaryVar)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDictionaryVar3 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity3 = (AcadEntity)robjAcadObject;
						AcadEntity acadEntity = dobjAcadEntity3;
						AcadObject nrobjAcadObject = dobjAcadEntity3;
						bool flag = acadEntity.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadEntity3 = (AcadEntity)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadEntity3 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace3 = (Acad3DFace)robjAcadObject;
						Acad3DFace acad3DFace = dobjAcad3DFace3;
						AcadObject nrobjAcadObject = dobjAcad3DFace3;
						bool flag = acad3DFace.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcad3DFace3 = (Acad3DFace)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcad3DFace3 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid3 = (Acad3DSolid)robjAcadObject;
						Acad3DSolid acad3DSolid = dobjAcad3DSolid3;
						AcadObject nrobjAcadObject = dobjAcad3DSolid3;
						bool flag = acad3DSolid.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcad3DSolid3 = (Acad3DSolid)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcad3DSolid3 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute3 = (AcadAttribute)robjAcadObject;
						AcadAttribute acadAttribute = dobjAcadAttribute3;
						AcadObject nrobjAcadObject = dobjAcadAttribute3;
						bool flag = acadAttribute.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadAttribute3 = (AcadAttribute)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadAttribute3 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference3 = (AcadAttributeReference)robjAcadObject;
						AcadAttributeReference acadAttributeReference = dobjAcadAttributeReference3;
						AcadObject nrobjAcadObject = dobjAcadAttributeReference3;
						bool flag = acadAttributeReference.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadAttributeReference3 = (AcadAttributeReference)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadAttributeReference3 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd3 = (AcadBlockEnd)robjAcadObject;
						AcadBlockEnd acadBlockEnd = dobjAcadBlockEnd3;
						AcadObject nrobjAcadObject = dobjAcadBlockEnd3;
						bool flag = acadBlockEnd.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadBlockEnd3 = (AcadBlockEnd)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadBlockEnd3 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin3 = (AcadBlockBegin)robjAcadObject;
						AcadBlockBegin acadBlockBegin = dobjAcadBlockBegin3;
						AcadObject nrobjAcadObject = dobjAcadBlockBegin3;
						bool flag = acadBlockBegin.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadBlockBegin3 = (AcadBlockBegin)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadBlockBegin3 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference3 = (AcadBlockReference)robjAcadObject;
						AcadBlockReference acadBlockReference = dobjAcadBlockReference3;
						AcadObject nrobjAcadObject = dobjAcadBlockReference3;
						bool flag = acadBlockReference.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadBlockReference3 = (AcadBlockReference)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadBlockReference3 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve3 = (AcadCurve)robjAcadObject;
						AcadCurve acadCurve = dobjAcadCurve3;
						AcadObject nrobjAcadObject = dobjAcadCurve3;
						bool flag = acadCurve.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadCurve3 = (AcadCurve)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadCurve3 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline3 = (Acad3DPolyline)robjAcadObject;
						Acad3DPolyline acad3DPolyline = dobjAcad3DPolyline3;
						AcadObject nrobjAcadObject = dobjAcad3DPolyline3;
						bool flag = acad3DPolyline.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcad3DPolyline3 = (Acad3DPolyline)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcad3DPolyline3 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc3 = (AcadArc)robjAcadObject;
						AcadArc acadArc = dobjAcadArc3;
						AcadObject nrobjAcadObject = dobjAcadArc3;
						bool flag = acadArc.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadArc3 = (AcadArc)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadArc3 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle3 = (AcadCircle)robjAcadObject;
						AcadCircle acadCircle = dobjAcadCircle3;
						AcadObject nrobjAcadObject = dobjAcadCircle3;
						bool flag = acadCircle.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadCircle3 = (AcadCircle)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadCircle3 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse3 = (AcadEllipse)robjAcadObject;
						AcadEllipse acadEllipse = dobjAcadEllipse3;
						AcadObject nrobjAcadObject = dobjAcadEllipse3;
						bool flag = acadEllipse.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadEllipse3 = (AcadEllipse)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadEllipse3 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader3 = (AcadLeader)robjAcadObject;
						AcadLeader acadLeader = dobjAcadLeader3;
						AcadObject nrobjAcadObject = dobjAcadLeader3;
						bool flag = acadLeader.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLeader3 = (AcadLeader)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLeader3 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine3 = (AcadLine)robjAcadObject;
						AcadLine acadLine = dobjAcadLine3;
						AcadObject nrobjAcadObject = dobjAcadLine3;
						bool flag = acadLine.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLine3 = (AcadLine)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLine3 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline3 = (AcadLWPolyline)robjAcadObject;
						AcadLWPolyline acadLWPolyline = dobjAcadLWPolyline3;
						AcadObject nrobjAcadObject = dobjAcadLWPolyline3;
						bool flag = acadLWPolyline.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLWPolyline3 = (AcadLWPolyline)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLWPolyline3 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline3 = (AcadPolyline)robjAcadObject;
						AcadPolyline acadPolyline = dobjAcadPolyline3;
						AcadObject nrobjAcadObject = dobjAcadPolyline3;
						bool flag = acadPolyline.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPolyline3 = (AcadPolyline)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPolyline3 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex3 = (Acad2DVertex)robjAcadObject;
						Acad2DVertex acad2DVertex = dobjAcad2DVertex3;
						AcadObject nrobjAcadObject = dobjAcad2DVertex3;
						bool flag = acad2DVertex.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcad2DVertex3 = (Acad2DVertex)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcad2DVertex3 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex3 = (Acad3DVertex)robjAcadObject;
						Acad3DVertex acad3DVertex = dobjAcad3DVertex3;
						AcadObject nrobjAcadObject = dobjAcad3DVertex3;
						bool flag = acad3DVertex.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcad3DVertex3 = (Acad3DVertex)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcad3DVertex3 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex3 = (AcadPolygonMeshVertex)robjAcadObject;
						AcadPolygonMeshVertex acadPolygonMeshVertex = dobjAcadPolygonMeshVertex3;
						AcadObject nrobjAcadObject = dobjAcadPolygonMeshVertex3;
						bool flag = acadPolygonMeshVertex.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPolygonMeshVertex3 = (AcadPolygonMeshVertex)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPolygonMeshVertex3 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex3 = (AcadPolyfaceMeshVertex)robjAcadObject;
						AcadPolyfaceMeshVertex acadPolyfaceMeshVertex = dobjAcadPolyfaceMeshVertex3;
						AcadObject nrobjAcadObject = dobjAcadPolyfaceMeshVertex3;
						bool flag = acadPolyfaceMeshVertex.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPolyfaceMeshVertex3 = (AcadPolyfaceMeshVertex)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPolyfaceMeshVertex3 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord3 = (AcadFaceRecord)robjAcadObject;
						AcadFaceRecord acadFaceRecord = dobjAcadFaceRecord3;
						AcadObject nrobjAcadObject = dobjAcadFaceRecord3;
						bool flag = acadFaceRecord.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadFaceRecord3 = (AcadFaceRecord)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadFaceRecord3 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay3 = (AcadRay)robjAcadObject;
						AcadRay acadRay = dobjAcadRay3;
						AcadObject nrobjAcadObject = dobjAcadRay3;
						bool flag = acadRay.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadRay3 = (AcadRay)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadRay3 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline3 = (AcadSpline)robjAcadObject;
						AcadSpline acadSpline = dobjAcadSpline3;
						AcadObject nrobjAcadObject = dobjAcadSpline3;
						bool flag = acadSpline.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadSpline3 = (AcadSpline)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadSpline3 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline3 = (AcadXline)robjAcadObject;
						AcadXline acadXline = dobjAcadXline3;
						AcadObject nrobjAcadObject = dobjAcadXline3;
						bool flag = acadXline.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadXline3 = (AcadXline)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadXline3 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch3 = (AcadHatch)robjAcadObject;
						AcadHatch acadHatch = dobjAcadHatch3;
						AcadObject nrobjAcadObject = dobjAcadHatch3;
						bool flag = acadHatch.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadHatch3 = (AcadHatch)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadHatch3 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock3 = (AcadMInsertBlock)robjAcadObject;
						AcadMInsertBlock acadMInsertBlock = dobjAcadMInsertBlock3;
						AcadObject nrobjAcadObject = dobjAcadMInsertBlock3;
						bool flag = acadMInsertBlock.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadMInsertBlock3 = (AcadMInsertBlock)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadMInsertBlock3 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine3 = (AcadMLine)robjAcadObject;
						AcadMLine acadMLine = dobjAcadMLine3;
						AcadObject nrobjAcadObject = dobjAcadMLine3;
						bool flag = acadMLine.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadMLine3 = (AcadMLine)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadMLine3 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText3 = (AcadMText)robjAcadObject;
						AcadMText acadMText = dobjAcadMText3;
						AcadObject nrobjAcadObject = dobjAcadMText3;
						bool flag = acadMText.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadMText3 = (AcadMText)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadMText3 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint3 = (AcadPoint)robjAcadObject;
						AcadPoint acadPoint = dobjAcadPoint3;
						AcadObject nrobjAcadObject = dobjAcadPoint3;
						bool flag = acadPoint.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPoint3 = (AcadPoint)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPoint3 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh3 = (AcadPolyfaceMesh)robjAcadObject;
						AcadPolyfaceMesh acadPolyfaceMesh = dobjAcadPolyfaceMesh3;
						AcadObject nrobjAcadObject = dobjAcadPolyfaceMesh3;
						bool flag = acadPolyfaceMesh.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPolyfaceMesh3 = (AcadPolyfaceMesh)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPolyfaceMesh3 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh3 = (AcadPolygonMesh)robjAcadObject;
						AcadPolygonMesh acadPolygonMesh = dobjAcadPolygonMesh3;
						AcadObject nrobjAcadObject = dobjAcadPolygonMesh3;
						bool flag = acadPolygonMesh.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPolygonMesh3 = (AcadPolygonMesh)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPolygonMesh3 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd3 = (AcadSequenceEnd)robjAcadObject;
						AcadSequenceEnd acadSequenceEnd = dobjAcadSequenceEnd3;
						AcadObject nrobjAcadObject = dobjAcadSequenceEnd3;
						bool flag = acadSequenceEnd.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadSequenceEnd3 = (AcadSequenceEnd)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadSequenceEnd3 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape3 = (AcadShape)robjAcadObject;
						AcadShape acadShape = dobjAcadShape3;
						AcadObject nrobjAcadObject = dobjAcadShape3;
						bool flag = acadShape.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadShape3 = (AcadShape)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadShape3 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText3 = (AcadText)robjAcadObject;
						AcadText acadText = dobjAcadText3;
						AcadObject nrobjAcadObject = dobjAcadText3;
						bool flag = acadText.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadText3 = (AcadText)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadText3 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace3 = (AcadTrace)robjAcadObject;
						AcadTrace acadTrace = dobjAcadTrace3;
						AcadObject nrobjAcadObject = dobjAcadTrace3;
						bool flag = acadTrace.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadTrace3 = (AcadTrace)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadTrace3 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid3 = (AcadSolid)robjAcadObject;
						AcadSolid acadSolid = dobjAcadSolid3;
						AcadObject nrobjAcadObject = dobjAcadSolid3;
						bool flag = acadSolid.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadSolid3 = (AcadSolid)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadSolid3 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable3 = (AcadFontTable)robjAcadObject;
						AcadFontTable acadFontTable = dobjAcadFontTable3;
						AcadObject nrobjAcadObject = dobjAcadFontTable3;
						bool flag = acadFontTable.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadFontTable3 = (AcadFontTable)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadFontTable3 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord3 = (AcadFontTableRecord)robjAcadObject;
						AcadFontTableRecord acadFontTableRecord = dobjAcadFontTableRecord3;
						AcadObject nrobjAcadObject = dobjAcadFontTableRecord3;
						bool flag = acadFontTableRecord.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadFontTableRecord3 = (AcadFontTableRecord)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadFontTableRecord3 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup3 = (AcadGroup)robjAcadObject;
						AcadGroup acadGroup = dobjAcadGroup3;
						AcadObject nrobjAcadObject = dobjAcadGroup3;
						bool flag = acadGroup.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadGroup3 = (AcadGroup)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadGroup3 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle3 = (AcadMLineStyle)robjAcadObject;
						AcadMLineStyle acadMLineStyle = dobjAcadMLineStyle3;
						AcadObject nrobjAcadObject = dobjAcadMLineStyle3;
						bool flag = acadMLineStyle.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadMLineStyle3 = (AcadMLineStyle)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadMLineStyle3 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder3 = (AcadPlaceholder)robjAcadObject;
						AcadPlaceholder acadPlaceholder = dobjAcadPlaceholder3;
						AcadObject nrobjAcadObject = dobjAcadPlaceholder3;
						bool flag = acadPlaceholder.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPlaceholder3 = (AcadPlaceholder)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPlaceholder3 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration3 = (AcadPlotConfiguration)robjAcadObject;
						AcadPlotConfiguration acadPlotConfiguration = dobjAcadPlotConfiguration3;
						AcadObject nrobjAcadObject = dobjAcadPlotConfiguration3;
						bool flag = acadPlotConfiguration.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPlotConfiguration3 = (AcadPlotConfiguration)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadPlotConfiguration3 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject3 = (AcadProxyObject)robjAcadObject;
						AcadProxyObject acadProxyObject = dobjAcadProxyObject3;
						AcadObject nrobjAcadObject = dobjAcadProxyObject3;
						bool flag = acadProxyObject.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadProxyObject3 = (AcadProxyObject)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadProxyObject3 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable3 = (AcadTable)robjAcadObject;
						AcadTable acadTable = dobjAcadTable3;
						AcadObject nrobjAcadObject = dobjAcadTable3;
						bool flag = acadTable.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadTable3 = (AcadTable)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadTable3 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews3 = (AcadAbstractViews)robjAcadObject;
						AcadAbstractViews acadAbstractViews = dobjAcadAbstractViews3;
						AcadObject nrobjAcadObject = dobjAcadAbstractViews3;
						bool flag = acadAbstractViews.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadAbstractViews3 = (AcadAbstractViews)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadAbstractViews3 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews3 = (AcadViews)robjAcadObject;
						AcadViews acadViews = dobjAcadViews3;
						AcadObject nrobjAcadObject = dobjAcadViews3;
						bool flag = acadViews.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadViews3 = (AcadViews)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadViews3 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports3 = (AcadViewports)robjAcadObject;
						AcadViewports acadViewports = dobjAcadViewports3;
						AcadObject nrobjAcadObject = dobjAcadViewports3;
						bool flag = acadViewports.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadViewports3 = (AcadViewports)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadViewports3 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks3 = (AcadBlocks)robjAcadObject;
						AcadBlocks acadBlocks = dobjAcadBlocks3;
						AcadObject nrobjAcadObject = dobjAcadBlocks3;
						bool flag = acadBlocks.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadBlocks3 = (AcadBlocks)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadBlocks3 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles3 = (AcadDimStyles)robjAcadObject;
						AcadDimStyles acadDimStyles = dobjAcadDimStyles3;
						AcadObject nrobjAcadObject = dobjAcadDimStyles3;
						bool flag = acadDimStyles.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDimStyles3 = (AcadDimStyles)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDimStyles3 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers3 = (AcadLayers)robjAcadObject;
						AcadLayers acadLayers = dobjAcadLayers3;
						AcadObject nrobjAcadObject = dobjAcadLayers3;
						bool flag = acadLayers.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLayers3 = (AcadLayers)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLayers3 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes3 = (AcadLineTypes)robjAcadObject;
						AcadLineTypes acadLineTypes = dobjAcadLineTypes3;
						AcadObject nrobjAcadObject = dobjAcadLineTypes3;
						bool flag = acadLineTypes.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLineTypes3 = (AcadLineTypes)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLineTypes3 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications3 = (AcadRegisteredApplications)robjAcadObject;
						AcadRegisteredApplications acadRegisteredApplications = dobjAcadRegisteredApplications3;
						AcadObject nrobjAcadObject = dobjAcadRegisteredApplications3;
						bool flag = acadRegisteredApplications.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadRegisteredApplications3 = (AcadRegisteredApplications)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadRegisteredApplications3 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles3 = (AcadTextStyles)robjAcadObject;
						AcadTextStyles acadTextStyles = dobjAcadTextStyles3;
						AcadObject nrobjAcadObject = dobjAcadTextStyles3;
						bool flag = acadTextStyles.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadTextStyles3 = (AcadTextStyles)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadTextStyles3 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs3 = (AcadUCSs)robjAcadObject;
						AcadUCSs acadUCSs = dobjAcadUCSs3;
						AcadObject nrobjAcadObject = dobjAcadUCSs3;
						bool flag = acadUCSs.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadUCSs3 = (AcadUCSs)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadUCSs3 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord3 = (AcadTableRecord)robjAcadObject;
						AcadTableRecord acadTableRecord = dobjAcadTableRecord3;
						AcadObject nrobjAcadObject = dobjAcadTableRecord3;
						bool flag = acadTableRecord.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadTableRecord3 = (AcadTableRecord)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadTableRecord3 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView3 = (AcadAbstractView)robjAcadObject;
						AcadAbstractView acadAbstractView = dobjAcadAbstractView3;
						AcadObject nrobjAcadObject = dobjAcadAbstractView3;
						bool flag = acadAbstractView.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadAbstractView3 = (AcadAbstractView)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadAbstractView3 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView3 = (AcadView)robjAcadObject;
						AcadView acadView = dobjAcadView3;
						AcadObject nrobjAcadObject = dobjAcadView3;
						bool flag = acadView.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadView3 = (AcadView)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadView3 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport3 = (AcadViewport)robjAcadObject;
						AcadViewport acadViewport = dobjAcadViewport3;
						AcadObject nrobjAcadObject = dobjAcadViewport3;
						bool flag = acadViewport.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadViewport3 = (AcadViewport)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadViewport3 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock3 = (AcadBlock)robjAcadObject;
						AcadBlock acadBlock = dobjAcadBlock3;
						AcadObject nrobjAcadObject = dobjAcadBlock3;
						bool flag = acadBlock.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadBlock3 = (AcadBlock)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadBlock3 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle3 = (AcadDimStyle)robjAcadObject;
						AcadDimStyle acadDimStyle = dobjAcadDimStyle3;
						AcadObject nrobjAcadObject = dobjAcadDimStyle3;
						bool flag = acadDimStyle.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDimStyle3 = (AcadDimStyle)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadDimStyle3 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer3 = (AcadLayer)robjAcadObject;
						AcadLayer acadLayer = dobjAcadLayer3;
						AcadObject nrobjAcadObject = dobjAcadLayer3;
						bool flag = acadLayer.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLayer3 = (AcadLayer)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLayer3 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype3 = (AcadLineType)robjAcadObject;
						AcadLineType acadLineType = dobjAcadLinetype3;
						AcadObject nrobjAcadObject = dobjAcadLinetype3;
						bool flag = acadLineType.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadLinetype3 = (AcadLineType)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadLinetype3 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication3 = (AcadRegisteredApplication)robjAcadObject;
						AcadRegisteredApplication acadRegisteredApplication = dobjAcadRegisteredApplication3;
						AcadObject nrobjAcadObject = dobjAcadRegisteredApplication3;
						bool flag = acadRegisteredApplication.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadRegisteredApplication3 = (AcadRegisteredApplication)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadRegisteredApplication3 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle3 = (AcadTextStyle)robjAcadObject;
						AcadTextStyle acadTextStyle = dobjAcadTextStyle3;
						AcadObject nrobjAcadObject = dobjAcadTextStyle3;
						bool flag = acadTextStyle.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadTextStyle3 = (AcadTextStyle)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadTextStyle3 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS3 = (AcadUCS)robjAcadObject;
						AcadUCS acadUCS = dobjAcadUCS3;
						AcadObject nrobjAcadObject = dobjAcadUCS3;
						bool flag = acadUCS.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadUCS3 = (AcadUCS)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadUCS3 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable3 = (AcadVXTable)robjAcadObject;
						AcadVXTable acadVXTable = dobjAcadVXTable3;
						AcadObject nrobjAcadObject = dobjAcadVXTable3;
						bool flag = acadVXTable.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadVXTable3 = (AcadVXTable)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadVXTable3 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord3 = (AcadVXTableRecord)robjAcadObject;
						AcadVXTableRecord acadVXTableRecord = dobjAcadVXTableRecord3;
						AcadObject nrobjAcadObject = dobjAcadVXTableRecord3;
						bool flag = acadVXTableRecord.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadVXTableRecord3 = (AcadVXTableRecord)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
						dobjAcadVXTableRecord3 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt2 = (AcadUnknownEnt)robjAcadObject;
						AcadUnknownEnt acadUnknownEnt = dobjAcadUnknownEnt2;
						AcadObject nrobjAcadObject = dobjAcadUnknownEnt2;
						bool flag = acadUnknownEnt.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadUnknownEnt2 = (AcadUnknownEnt)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry2 = (AcadDictionaryEntry)robjAcadObject;
						AcadDictionaryEntry acadDictionaryEntry = dobjAcadDictionaryEntry2;
						AcadObject nrobjAcadObject = dobjAcadDictionaryEntry2;
						bool flag = acadDictionaryEntry.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadDictionaryEntry2 = (AcadDictionaryEntry)nrobjAcadObject;
						BkAcadObject_SetObjectID = flag;
					}
					break;
			}
			return BkAcadObject_SetObjectID;
		}

		public static void BkAcadObject_LetOwnerID(ref AcadObject robjAcadObject, double vdblOwnerID)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendLetOwnerID = vdblOwnerID;
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendLetOwnerID = vdblOwnerID;
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendLetOwnerID = vdblOwnerID;
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendLetOwnerID = vdblOwnerID;
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendLetOwnerID = vdblOwnerID;
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = (AcadProxyObject)robjAcadObject;
						dobjAcadProxyObject2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendLetOwnerID = vdblOwnerID;
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendLetOwnerID = vdblOwnerID;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendLetOwnerID = vdblOwnerID;
					}
					break;
			}
		}

		public static void BkAcadObject_LetApplicationIndex(ref AcadObject robjAcadObject, int vlngApplicationIndex)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = (AcadProxyObject)robjAcadObject;
						dobjAcadProxyObject2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendLetApplicationIndex = vlngApplicationIndex;
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendLetApplicationIndex = vlngApplicationIndex;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendLetApplicationIndex = vlngApplicationIndex;
					}
					break;
			}
		}

		public static void BkAcadObject_LetDatabaseIndex(ref AcadObject robjAcadObject, int vlngDatabaseIndex)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = (AcadProxyObject)robjAcadObject;
						dobjAcadProxyObject2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendLetDatabaseIndex = vlngDatabaseIndex;
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendLetDatabaseIndex = vlngDatabaseIndex;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendLetDatabaseIndex = vlngDatabaseIndex;
					}
					break;
			}
		}

		public static void BkAcadObject_LetDocumentIndex(ref AcadObject robjAcadObject, int vlngDocumentIndex)
		{
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbObject":
					{
						AcadObject dobjAcadObject2 = robjAcadObject;
						dobjAcadObject2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadObject2 = null;
						break;
					}
				case "AcDbDictionary":
					{
						AcadDictionary dobjAcadDictionary2 = (AcadDictionary)robjAcadObject;
						dobjAcadDictionary2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDictionary2 = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadObject;
						dobjAcadDictionaryWithDefault2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDictionaryWithDefault2 = null;
						break;
					}
				case "AcDbDictionaries":
					{
						AcadDictionaries dobjAcadDictionaries2 = (AcadDictionaries)robjAcadObject;
						dobjAcadDictionaries2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDictionaries2 = null;
						break;
					}
				case "AcDbGroups":
					{
						AcadGroups dobjAcadGroups2 = (AcadGroups)robjAcadObject;
						dobjAcadGroups2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadGroups2 = null;
						break;
					}
				case "AcDbLayouts":
					{
						AcadLayouts dobjAcadLayouts2 = (AcadLayouts)robjAcadObject;
						dobjAcadLayouts2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLayouts2 = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						AcadMLineStyles dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadObject;
						dobjAcadMLineStyles2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadMLineStyles2 = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						AcadPlotConfigurations dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadObject;
						dobjAcadPlotConfigurations2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPlotConfigurations2 = null;
						break;
					}
				case "AcDbLayout":
					{
						AcadLayout dobjAcadLayout2 = (AcadLayout)robjAcadObject;
						dobjAcadLayout2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLayout2 = null;
						break;
					}
				case "DictionaryVariables":
					{
						AcadDictionaryVar dobjAcadDictionaryVar2 = (AcadDictionaryVar)robjAcadObject;
						dobjAcadDictionaryVar2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDictionaryVar2 = null;
						break;
					}
				case "AcDbEntity":
					{
						AcadEntity dobjAcadEntity2 = (AcadEntity)robjAcadObject;
						dobjAcadEntity2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadEntity2 = null;
						break;
					}
				case "AcDbFace":
					{
						Acad3DFace dobjAcad3DFace2 = (Acad3DFace)robjAcadObject;
						dobjAcad3DFace2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcad3DFace2 = null;
						break;
					}
				case "AcDb3dSolid":
					{
						Acad3DSolid dobjAcad3DSolid2 = (Acad3DSolid)robjAcadObject;
						dobjAcad3DSolid2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcad3DSolid2 = null;
						break;
					}
				case "AcDbAttributeDefinition":
					{
						AcadAttribute dobjAcadAttribute2 = (AcadAttribute)robjAcadObject;
						dobjAcadAttribute2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadAttribute2 = null;
						break;
					}
				case "AcDbAttribute":
					{
						AcadAttributeReference dobjAcadAttributeReference2 = (AcadAttributeReference)robjAcadObject;
						dobjAcadAttributeReference2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadAttributeReference2 = null;
						break;
					}
				case "AcDbBlockEnd":
					{
						AcadBlockEnd dobjAcadBlockEnd2 = (AcadBlockEnd)robjAcadObject;
						dobjAcadBlockEnd2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadBlockEnd2 = null;
						break;
					}
				case "AcDbBlockBegin":
					{
						AcadBlockBegin dobjAcadBlockBegin2 = (AcadBlockBegin)robjAcadObject;
						dobjAcadBlockBegin2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadBlockBegin2 = null;
						break;
					}
				case "AcDbBlockReference":
					{
						AcadBlockReference dobjAcadBlockReference2 = (AcadBlockReference)robjAcadObject;
						dobjAcadBlockReference2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadBlockReference2 = null;
						break;
					}
				case "AcDbCurve":
					{
						AcadCurve dobjAcadCurve2 = (AcadCurve)robjAcadObject;
						dobjAcadCurve2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadCurve2 = null;
						break;
					}
				case "AcDb3dPolyline":
					{
						Acad3DPolyline dobjAcad3DPolyline2 = (Acad3DPolyline)robjAcadObject;
						dobjAcad3DPolyline2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcad3DPolyline2 = null;
						break;
					}
				case "AcDbArc":
					{
						AcadArc dobjAcadArc2 = (AcadArc)robjAcadObject;
						dobjAcadArc2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadArc2 = null;
						break;
					}
				case "AcDbCircle":
					{
						AcadCircle dobjAcadCircle2 = (AcadCircle)robjAcadObject;
						dobjAcadCircle2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadCircle2 = null;
						break;
					}
				case "AcDbEllipse":
					{
						AcadEllipse dobjAcadEllipse2 = (AcadEllipse)robjAcadObject;
						dobjAcadEllipse2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadEllipse2 = null;
						break;
					}
				case "AcDbLeader":
					{
						AcadLeader dobjAcadLeader2 = (AcadLeader)robjAcadObject;
						dobjAcadLeader2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLeader2 = null;
						break;
					}
				case "AcDbLine":
					{
						AcadLine dobjAcadLine2 = (AcadLine)robjAcadObject;
						dobjAcadLine2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLine2 = null;
						break;
					}
				case "AcDbPolyline":
					{
						AcadLWPolyline dobjAcadLWPolyline2 = (AcadLWPolyline)robjAcadObject;
						dobjAcadLWPolyline2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLWPolyline2 = null;
						break;
					}
				case "AcDb2dPolyline":
					{
						AcadPolyline dobjAcadPolyline2 = (AcadPolyline)robjAcadObject;
						dobjAcadPolyline2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPolyline2 = null;
						break;
					}
				case "AcDb2dVertex":
					{
						Acad2DVertex dobjAcad2DVertex2 = (Acad2DVertex)robjAcadObject;
						dobjAcad2DVertex2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcad2DVertex2 = null;
						break;
					}
				case "AcDb3dPolylineVertex":
					{
						Acad3DVertex dobjAcad3DVertex2 = (Acad3DVertex)robjAcadObject;
						dobjAcad3DVertex2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcad3DVertex2 = null;
						break;
					}
				case "AcDbPolygonMeshVertex":
					{
						AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2 = (AcadPolygonMeshVertex)robjAcadObject;
						dobjAcadPolygonMeshVertex2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPolygonMeshVertex2 = null;
						break;
					}
				case "AcDbPolyFaceMeshVertex":
					{
						AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2 = (AcadPolyfaceMeshVertex)robjAcadObject;
						dobjAcadPolyfaceMeshVertex2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPolyfaceMeshVertex2 = null;
						break;
					}
				case "AcDbFaceRecord":
					{
						AcadFaceRecord dobjAcadFaceRecord2 = (AcadFaceRecord)robjAcadObject;
						dobjAcadFaceRecord2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadFaceRecord2 = null;
						break;
					}
				case "AcDbRay":
					{
						AcadRay dobjAcadRay2 = (AcadRay)robjAcadObject;
						dobjAcadRay2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadRay2 = null;
						break;
					}
				case "AcDbSpline":
					{
						AcadSpline dobjAcadSpline2 = (AcadSpline)robjAcadObject;
						dobjAcadSpline2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadSpline2 = null;
						break;
					}
				case "AcDbXline":
					{
						AcadXline dobjAcadXline2 = (AcadXline)robjAcadObject;
						dobjAcadXline2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadXline2 = null;
						break;
					}
				case "AcDbHatch":
					{
						AcadHatch dobjAcadHatch2 = (AcadHatch)robjAcadObject;
						dobjAcadHatch2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadHatch2 = null;
						break;
					}
				case "AcDbMInsertBlock":
					{
						AcadMInsertBlock dobjAcadMInsertBlock2 = (AcadMInsertBlock)robjAcadObject;
						dobjAcadMInsertBlock2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadMInsertBlock2 = null;
						break;
					}
				case "AcDbMLine":
					{
						AcadMLine dobjAcadMLine2 = (AcadMLine)robjAcadObject;
						dobjAcadMLine2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadMLine2 = null;
						break;
					}
				case "AcDbMText":
					{
						AcadMText dobjAcadMText2 = (AcadMText)robjAcadObject;
						dobjAcadMText2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadMText2 = null;
						break;
					}
				case "AcDbPoint":
					{
						AcadPoint dobjAcadPoint2 = (AcadPoint)robjAcadObject;
						dobjAcadPoint2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPoint2 = null;
						break;
					}
				case "AcDbPolyFaceMesh":
					{
						AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = (AcadPolyfaceMesh)robjAcadObject;
						dobjAcadPolyfaceMesh2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPolyfaceMesh2 = null;
						break;
					}
				case "AcDbPolygonMesh":
					{
						AcadPolygonMesh dobjAcadPolygonMesh2 = (AcadPolygonMesh)robjAcadObject;
						dobjAcadPolygonMesh2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPolygonMesh2 = null;
						break;
					}
				case "AcDbSequenceEnd":
					{
						AcadSequenceEnd dobjAcadSequenceEnd2 = (AcadSequenceEnd)robjAcadObject;
						dobjAcadSequenceEnd2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadSequenceEnd2 = null;
						break;
					}
				case "AcDbShape":
					{
						AcadShape dobjAcadShape2 = (AcadShape)robjAcadObject;
						dobjAcadShape2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadShape2 = null;
						break;
					}
				case "AcDbText":
					{
						AcadText dobjAcadText2 = (AcadText)robjAcadObject;
						dobjAcadText2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadText2 = null;
						break;
					}
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						AcadTrace dobjAcadTrace2 = (AcadTrace)robjAcadObject;
						dobjAcadTrace2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadTrace2 = null;
					}
					else
					{
						AcadSolid dobjAcadSolid2 = (AcadSolid)robjAcadObject;
						dobjAcadSolid2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadSolid2 = null;
					}
					break;
				case "AcDbFontTable":
					{
						AcadFontTable dobjAcadFontTable2 = (AcadFontTable)robjAcadObject;
						dobjAcadFontTable2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadFontTable2 = null;
						break;
					}
				case "AcDbFontTableRecord":
					{
						AcadFontTableRecord dobjAcadFontTableRecord2 = (AcadFontTableRecord)robjAcadObject;
						dobjAcadFontTableRecord2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadFontTableRecord2 = null;
						break;
					}
				case "AcDbGroup":
					{
						AcadGroup dobjAcadGroup2 = (AcadGroup)robjAcadObject;
						dobjAcadGroup2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadGroup2 = null;
						break;
					}
				case "AcDbMlineStyle":
					{
						AcadMLineStyle dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadObject;
						dobjAcadMLineStyle2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadMLineStyle2 = null;
						break;
					}
				case "AcDbPlaceholder":
					{
						AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
						dobjAcadPlaceholder2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPlaceholder2 = null;
						break;
					}
				case "AcDbPlotSettings":
					{
						AcadPlotConfiguration dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)robjAcadObject;
						dobjAcadPlotConfiguration2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadPlotConfiguration2 = null;
						break;
					}
				case "AcDbProxyObject":
					{
						AcadProxyObject dobjAcadProxyObject2 = (AcadProxyObject)robjAcadObject;
						dobjAcadProxyObject2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadProxyObject2 = null;
						break;
					}
				case "AcDbSymbolTable":
					{
						AcadTable dobjAcadTable2 = (AcadTable)robjAcadObject;
						dobjAcadTable2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadTable2 = null;
						break;
					}
				case "AcDbAbstractViewTable":
					{
						AcadAbstractViews dobjAcadAbstractViews2 = (AcadAbstractViews)robjAcadObject;
						dobjAcadAbstractViews2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadAbstractViews2 = null;
						break;
					}
				case "AcDbViewTable":
					{
						AcadViews dobjAcadViews2 = (AcadViews)robjAcadObject;
						dobjAcadViews2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadViews2 = null;
						break;
					}
				case "AcDbViewportTable":
					{
						AcadViewports dobjAcadViewports2 = (AcadViewports)robjAcadObject;
						dobjAcadViewports2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadViewports2 = null;
						break;
					}
				case "AcDbBlockTable":
					{
						AcadBlocks dobjAcadBlocks2 = (AcadBlocks)robjAcadObject;
						dobjAcadBlocks2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadBlocks2 = null;
						break;
					}
				case "AcDbDimStyleTable":
					{
						AcadDimStyles dobjAcadDimStyles2 = (AcadDimStyles)robjAcadObject;
						dobjAcadDimStyles2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDimStyles2 = null;
						break;
					}
				case "AcDbLayerTable":
					{
						AcadLayers dobjAcadLayers2 = (AcadLayers)robjAcadObject;
						dobjAcadLayers2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLayers2 = null;
						break;
					}
				case "AcDbLinetypeTable":
					{
						AcadLineTypes dobjAcadLineTypes2 = (AcadLineTypes)robjAcadObject;
						dobjAcadLineTypes2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLineTypes2 = null;
						break;
					}
				case "AcDbRegAppTable":
					{
						AcadRegisteredApplications dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)robjAcadObject;
						dobjAcadRegisteredApplications2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadRegisteredApplications2 = null;
						break;
					}
				case "AcDbTextStyleTable":
					{
						AcadTextStyles dobjAcadTextStyles2 = (AcadTextStyles)robjAcadObject;
						dobjAcadTextStyles2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadTextStyles2 = null;
						break;
					}
				case "AcDbUCSTable":
					{
						AcadUCSs dobjAcadUCSs2 = (AcadUCSs)robjAcadObject;
						dobjAcadUCSs2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadUCSs2 = null;
						break;
					}
				case "AcDbSymbolTableRecord":
					{
						AcadTableRecord dobjAcadTableRecord2 = (AcadTableRecord)robjAcadObject;
						dobjAcadTableRecord2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadTableRecord2 = null;
						break;
					}
				case "AcDbAbstractViewTableRecord":
					{
						AcadAbstractView dobjAcadAbstractView2 = (AcadAbstractView)robjAcadObject;
						dobjAcadAbstractView2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadAbstractView2 = null;
						break;
					}
				case "AcDbViewTableRecord":
					{
						AcadView dobjAcadView2 = (AcadView)robjAcadObject;
						dobjAcadView2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadView2 = null;
						break;
					}
				case "AcDbViewportTableRecord":
					{
						AcadViewport dobjAcadViewport2 = (AcadViewport)robjAcadObject;
						dobjAcadViewport2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadViewport2 = null;
						break;
					}
				case "AcDbBlockTableRecord":
					{
						AcadBlock dobjAcadBlock2 = (AcadBlock)robjAcadObject;
						dobjAcadBlock2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadBlock2 = null;
						break;
					}
				case "AcDbDimStyleTableRecord":
					{
						AcadDimStyle dobjAcadDimStyle2 = (AcadDimStyle)robjAcadObject;
						dobjAcadDimStyle2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadDimStyle2 = null;
						break;
					}
				case "AcDbLayerTableRecord":
					{
						AcadLayer dobjAcadLayer2 = (AcadLayer)robjAcadObject;
						dobjAcadLayer2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLayer2 = null;
						break;
					}
				case "AcDbLinetypeTableRecord":
					{
						AcadLineType dobjAcadLinetype2 = (AcadLineType)robjAcadObject;
						dobjAcadLinetype2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadLinetype2 = null;
						break;
					}
				case "AcDbRegAppTableRecord":
					{
						AcadRegisteredApplication dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)robjAcadObject;
						dobjAcadRegisteredApplication2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadRegisteredApplication2 = null;
						break;
					}
				case "AcDbTextStyleTableRecord":
					{
						AcadTextStyle dobjAcadTextStyle2 = (AcadTextStyle)robjAcadObject;
						dobjAcadTextStyle2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadTextStyle2 = null;
						break;
					}
				case "AcDbUCSTableRecord":
					{
						AcadUCS dobjAcadUCS2 = (AcadUCS)robjAcadObject;
						dobjAcadUCS2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadUCS2 = null;
						break;
					}
				case "AcDbVXTable":
					{
						AcadVXTable dobjAcadVXTable2 = (AcadVXTable)robjAcadObject;
						dobjAcadVXTable2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadVXTable2 = null;
						break;
					}
				case "AcDbVXTableRecord":
					{
						AcadVXTableRecord dobjAcadVXTableRecord2 = (AcadVXTableRecord)robjAcadObject;
						dobjAcadVXTableRecord2.FriendLetDocumentIndex = vlngDocumentIndex;
						dobjAcadVXTableRecord2 = null;
						break;
					}
				default:
					if (robjAcadObject is AcadUnknownEnt)
					{
						AcadUnknownEnt dobjAcadUnknownEnt = (AcadUnknownEnt)robjAcadObject;
						dobjAcadUnknownEnt.FriendLetDocumentIndex = vlngDocumentIndex;
					}
					else
					{
						AcadDictionaryEntry dobjAcadDictionaryEntry = (AcadDictionaryEntry)robjAcadObject;
						dobjAcadDictionaryEntry.FriendLetDocumentIndex = vlngDocumentIndex;
					}
					break;
			}
		}
	}
}
