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
	public class AcadModelSpace
	{
		private const string cstrClassName = "AcadModelSpace";

		private bool mblnOpened;

		private AcadBlock mobjAcadBlock;

		public AcadDatabase Database => mobjAcadBlock.Database;

		public AcadDocument Document => mobjAcadBlock.Document;

		public AcadApplication Application => mobjAcadBlock.Application;

		public object DictReactors => RuntimeHelpers.GetObjectValue(mobjAcadBlock.DictReactors);

		public object DictXDictionaries => RuntimeHelpers.GetObjectValue(mobjAcadBlock.DictXDictionaries);

		public string DXFName => mobjAcadBlock.DXFName;

		public string Handle => mobjAcadBlock.Handle;

		public bool HasExtensionDictionary => mobjAcadBlock.HasExtensionDictionary;

		public bool HasReactors => mobjAcadBlock.HasReactors;

		public double ObjectID => mobjAcadBlock.ObjectID;

		public string ObjectName => mobjAcadBlock.ObjectName;

		public double OwnerID => mobjAcadBlock.OwnerID;

		public string OwnerHandle => mobjAcadBlock.OwnerHandle;

		public string Name => mobjAcadBlock.Name;

		public int TableIndex => mobjAcadBlock.TableIndex;

		public string SuperiorObjectName => mobjAcadBlock.SuperiorObjectName;

		public AcadBlockBegin BlockBegin => mobjAcadBlock.BlockBegin;

		public AcadBlockEnd BlockEnd => mobjAcadBlock.BlockEnd;

		public AcadDatabase XRefDatabase => mobjAcadBlock.XRefDatabase;

		public AcadArcDictionary ArcDictionary => mobjAcadBlock.ArcDictionary;

		public AcadCircleDictionary CircleDictionary => mobjAcadBlock.CircleDictionary;

		public AcadLineDictionary LineDictionary => mobjAcadBlock.LineDictionary;

		public AcadTextDictionary TextDictionary => mobjAcadBlock.TextDictionary;

		public AcadXlineDictionary XLineDictionary => mobjAcadBlock.XLineDictionary;

		public AcadSplineDictionary SplineDictionary => mobjAcadBlock.SplineDictionary;

		public AcadHatchDictionary HatchDictionary => mobjAcadBlock.HatchDictionary;

		public AcadEllipseDictionary EllipseDictionary => mobjAcadBlock.EllipseDictionary;

		public AcadShapeDictionary ShapeDictionary => mobjAcadBlock.ShapeDictionary;

		public AcadRayDictionary RayDictionary => mobjAcadBlock.RayDictionary;

		public AcadAttributeDictionary AttributeDictionary => mobjAcadBlock.AttributeDictionary;

		public AcadBlockRefDictionary BlockReferenceDictionary => mobjAcadBlock.BlockReferenceDictionary;

		public AcadMInsertBlockDictionary MInsertBlockDictionary => mobjAcadBlock.MInsertBlockDictionary;

		public AcadLWPolylineDictionary LWPolylineDictionary => mobjAcadBlock.LWPolylineDictionary;

		public AcadPolylineDictionary PolylineDictionary => mobjAcadBlock.PolylineDictionary;

		public Acad3DPolylineDictionary Polyline3DDictionary => mobjAcadBlock.Polyline3DDictionary;

		public AcadPolygonMeshDictionary PolygonMeshDictionary => mobjAcadBlock.PolygonMeshDictionary;

		public AcadPolyfaceMeshDictionary PolyfaceMeshDictionary => mobjAcadBlock.PolyfaceMeshDictionary;

		public AcadMTextDictionary MTextDictionary => mobjAcadBlock.MTextDictionary;

		public AcadTraceDictionary TraceDictionary => mobjAcadBlock.TraceDictionary;

		public AcadSolidDictionary SolidDictionary => mobjAcadBlock.SolidDictionary;

		public AcadUnknownEntDictionary UnknownEntDictionary => mobjAcadBlock.UnknownEntDictionary;

		public int Count => mobjAcadBlock.Count;

		public string Comment
		{
			get
			{
				return mobjAcadBlock.Comment;
			}
			set
			{
				mobjAcadBlock.Comment = value;
			}
		}

		public bool HasAttributeDefinitions => mobjAcadBlock.HasAttributeDefinitions;

		public bool HasBlkrefs => mobjAcadBlock.HasBlkrefs;

		public bool HasPreviewIcon => mobjAcadBlock.HasPreviewIcon;

		public bool IsAnonymous => mobjAcadBlock.IsAnonymous;

		public bool IsLayout => mobjAcadBlock.IsLayout;

		public bool IsXRef => mobjAcadBlock.IsXRef;

		public double LayoutObjectID => mobjAcadBlock.LayoutObjectID;

		public string LayoutReference => mobjAcadBlock.LayoutReference;

		public object Origin
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(mobjAcadBlock.Origin);
			}
			set
			{
				mobjAcadBlock.Origin = RuntimeHelpers.GetObjectValue(value);
			}
		}

		public int Flags70 => mobjAcadBlock.Flags70;

		public AcadModelSpace()
		{
			mblnOpened = true;
		}

		internal void FriendInit(ref AcadBlock robjAcadBlock)
		{
			mobjAcadBlock = robjAcadBlock;
		}

		~AcadModelSpace()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadBlock.FriendQuit();
				mobjAcadBlock = null;
				mblnOpened = false;
			}
		}

		public ICollection<AcadEntity> GetValues()
		{
			return mobjAcadBlock.GetValues();
		}

		public void Delete()
		{
			mobjAcadBlock.Delete();
		}

		public void EraseAll()
		{
			mobjAcadBlock.EraseAll();
		}

		public AcadDictionary GetExtensionDictionary()
		{
			return mobjAcadBlock.GetExtensionDictionary();
		}

		public void GetXData(string vstrAppName, ref object rvarXDataType, ref object rvarXDataValue)
		{
			mobjAcadBlock.GetXData(vstrAppName, ref rvarXDataType, ref rvarXDataValue);
		}

		public void SetXData(object vvarXDataType, object vvarXDataValue)
		{
			mobjAcadBlock.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
		}

		internal AcadBlock FriendGetAcadBlock()
		{
			return mobjAcadBlock;
		}

		public AcadEntity Item(int vlngIndex)
		{
			return mobjAcadBlock.Item(vlngIndex);
		}

		public AcadBlockReference InsertBlockDegree(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, string nvstrHandle = "")
		{
			return mobjAcadBlock.InsertBlockDegree(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotationDegree), nvstrHandle);
		}

		public AcadBlockReference InsertBlock(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotation, string nvstrHandle = "")
		{
			return mobjAcadBlock.InsertBlock(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotation), nvstrHandle);
		}

		public void Bind(bool vblnPrefixName)
		{
			mobjAcadBlock.Bind(vblnPrefixName);
		}

		public void Detach()
		{
			mobjAcadBlock.Detach();
		}

		public void Reload()
		{
			mobjAcadBlock.Reload();
		}

		public void Unload()
		{
			mobjAcadBlock.Unload();
		}

		public Acad3DFace Add3DFace(object vvarPoint1, object vvarPoint2, object vvarPoint3, object vvarPoint4, string nvstrHandle = "")
		{
			return mobjAcadBlock.Add3DFace(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), RuntimeHelpers.GetObjectValue(vvarPoint3), RuntimeHelpers.GetObjectValue(vvarPoint4), nvstrHandle);
		}

		public AcadPolygonMesh Add3DMesh(int vlngM, int vlngN, object vvarPointsMatrix, string nvstrHandle = "")
		{
			return mobjAcadBlock.Add3DMesh(vlngM, vlngN, RuntimeHelpers.GetObjectValue(vvarPointsMatrix), nvstrHandle);
		}

		public Acad3DPolyline Add3DPoly(object vvarPointsArray, string nvstrHandle = "")
		{
			return mobjAcadBlock.Add3DPoly(RuntimeHelpers.GetObjectValue(vvarPointsArray), nvstrHandle);
		}

		public AcadArc AddArc(object vvarCenter, object vvarRadius, object vvarStartAngle, object vvarEndAngle, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddArc(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), RuntimeHelpers.GetObjectValue(vvarStartAngle), RuntimeHelpers.GetObjectValue(vvarEndAngle), nvstrHandle);
		}

		public AcadAttribute AddAttribute(object vvarHeight, Enums.AcAttributeMode vnumMode, string vstrPrompt, object vvarInsertionPoint, string vstrTag, string vstrValue, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddAttribute(RuntimeHelpers.GetObjectValue(vvarHeight), vnumMode, vstrPrompt, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrTag, vstrValue, nvstrHandle);
		}

		public Acad3DSolid AddBox(object vvarOrigin, object vvarLength, object vvarWidth, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddBox(RuntimeHelpers.GetObjectValue(vvarOrigin), RuntimeHelpers.GetObjectValue(vvarLength), RuntimeHelpers.GetObjectValue(vvarWidth), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public AcadCircle AddCircle(object vvarCenter, object vvarRadius, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddCircle(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), nvstrHandle);
		}

		public Acad3DSolid AddCone(object vvarCenter, object vvarBaseRadius, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddCone(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarBaseRadius), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public object AddCustomObject(string vstrClassName, string nvstrHandle = "")
		{
			return RuntimeHelpers.GetObjectValue(mobjAcadBlock.AddCustomObject(vstrClassName, nvstrHandle));
		}

		public Acad3DSolid AddCylinder(object vvarCenter, object vvarRadius, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddCylinder(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public AcadEllipse AddEllipse(object vvarCenter, object vvarMajorAxis, object vvarRadiusRatio, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddEllipse(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarMajorAxis), RuntimeHelpers.GetObjectValue(vvarRadiusRatio), nvstrHandle);
		}

		public Acad3DSolid AddEllipticalCone(object vvarCenter, object vvarMajorRadius, object vvarMinorRadius, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddEllipticalCone(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarMajorRadius), RuntimeHelpers.GetObjectValue(vvarMinorRadius), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public Acad3DSolid AddEllipticalCylinder(object vvarCenter, object vvarMajorRadius, object vvarMinorRadius, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddEllipticalCylinder(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarMajorRadius), RuntimeHelpers.GetObjectValue(vvarMinorRadius), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public AcadHatch AddHatch(int vlngPatternType, string vstrPatternName, bool vblnAssociativity, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddHatch(vlngPatternType, vstrPatternName, vblnAssociativity, nvstrHandle);
		}

		public AcadLeader AddLeader(object vvarPointsArray, AcadEntity vobjAnnotation, Enums.AcLeaderType vnumLeaderType, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddLeader(RuntimeHelpers.GetObjectValue(vvarPointsArray), vobjAnnotation, vnumLeaderType, nvstrHandle);
		}

		public AcadLWPolyline AddLightWeightPolyline(object vvarVerticesList, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddLightWeightPolyline(RuntimeHelpers.GetObjectValue(vvarVerticesList), nvstrHandle);
		}

		public AcadLWPolyline AddLightWeightPolylineWithVertices(object vobjVertices, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddLightWeightPolylineWithVertices(RuntimeHelpers.GetObjectValue(vobjVertices), nvstrHandle);
		}

		public AcadPolyline AddPolyline(object vvarVerticesList, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddPolyline(RuntimeHelpers.GetObjectValue(vvarVerticesList), nvstrHandle);
		}

		public AcadLine AddLine(object vvarStartPoint, object vvarEndPoint, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddLine(RuntimeHelpers.GetObjectValue(vvarStartPoint), RuntimeHelpers.GetObjectValue(vvarEndPoint), nvstrHandle);
		}

		public AcadMInsertBlock AddMInsertBlockDegree(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, int vlngNumRows, int vlngNumColumns, object vvarRowSpacing, object vvarColumnSpacing, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddMInsertBlockDegree(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotationDegree), vlngNumRows, vlngNumColumns, RuntimeHelpers.GetObjectValue(vvarRowSpacing), RuntimeHelpers.GetObjectValue(vvarColumnSpacing), nvstrHandle);
		}

		public AcadMInsertBlock AddMInsertBlock(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotation, int vlngNumRows, int vlngNumColumns, object vvarRowSpacing, object vvarColumnSpacing, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddMInsertBlock(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotation), vlngNumRows, vlngNumColumns, RuntimeHelpers.GetObjectValue(vvarRowSpacing), RuntimeHelpers.GetObjectValue(vvarColumnSpacing), nvstrHandle);
		}

		public AcadMLine AddMLine(object vvarVertexList, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddMLine(RuntimeHelpers.GetObjectValue(vvarVertexList), nvstrHandle);
		}

		public AcadMText AddMText(object vvarInsertionPoint, object vvarWidth, string vstrText, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddMText(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarWidth), vstrText, nvstrHandle);
		}

		public AcadPoint AddPoint(object vvarPoint, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddPoint(RuntimeHelpers.GetObjectValue(vvarPoint), nvstrHandle);
		}

		public AcadPolyfaceMesh AddPolyfaceMesh(object vvarVertexList, object vvarFaceList, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddPolyfaceMesh(RuntimeHelpers.GetObjectValue(vvarVertexList), RuntimeHelpers.GetObjectValue(vvarFaceList), nvstrHandle);
		}

		public AcadRay AddRay(object vvarPoint1, object vvarPoint2, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddRay(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), nvstrHandle);
		}

		public AcadShape AddShape(string vstrName, object vvarInsertionPoint, object vvarScaleFactor, object vvarRotationAngle, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddShape(vstrName, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarScaleFactor), RuntimeHelpers.GetObjectValue(vvarRotationAngle), nvstrHandle);
		}

		public AcadSolid AddSolid(object vvarPoint1, object vvarPoint2, object vvarPoint3, object vvarPoint4, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddSolid(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), RuntimeHelpers.GetObjectValue(vvarPoint3), RuntimeHelpers.GetObjectValue(vvarPoint4), nvstrHandle);
		}

		public Acad3DSolid AddSphere(object vvarCenter, object vvarRadius, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddSphere(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), nvstrHandle);
		}

		public AcadSpline AddSpline(object vvarPointsArray, object vvarStartTangent, object vvarEndTangent, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddSpline(RuntimeHelpers.GetObjectValue(vvarPointsArray), RuntimeHelpers.GetObjectValue(vvarStartTangent), RuntimeHelpers.GetObjectValue(vvarEndTangent), nvstrHandle);
		}

		public AcadText AddText(string vstrTextString, object vvarInsertionPoint, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddText(vstrTextString, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public Acad3DSolid AddTorus(object vvarCenter, object vvarTorusRadius, object vvarTubeRadius, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddTorus(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarTorusRadius), RuntimeHelpers.GetObjectValue(vvarTubeRadius), nvstrHandle);
		}

		public AcadTrace AddTrace(object vvarPointsArray, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddTrace(RuntimeHelpers.GetObjectValue(vvarPointsArray), nvstrHandle);
		}

		public Acad3DSolid AddWedge(object vvarCenter, object vvarLength, object vvarWidth, object vvarHeight, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddWedge(RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarLength), RuntimeHelpers.GetObjectValue(vvarWidth), RuntimeHelpers.GetObjectValue(vvarHeight), nvstrHandle);
		}

		public AcadXline AddXline(object vvarPoint1, object vvarPoint2, string nvstrHandle = "")
		{
			return mobjAcadBlock.AddXline(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), nvstrHandle);
		}

		public object GetMinMaxCoords(object vvarEntityNames = null)
		{
			return RuntimeHelpers.GetObjectValue(mobjAcadBlock.GetMinMaxCoords(RuntimeHelpers.GetObjectValue(vvarEntityNames)));
		}
	}
}
