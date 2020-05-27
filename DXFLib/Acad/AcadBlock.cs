using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
	public class AcadBlock : AcadTableRecord
	{
		private const string cstrClassName = "AcadBlock";

		private const int clngIsAnonymous = 1;

		private const int clngHasAttributeDefinitions = 2;

		private const int clngIsXRef = 4;

		private const int clngIsOverlayRef = 8;

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private string mstrComment;

		private bool mblnDependend;

		private bool mblnHasAttributeDefinitions;

		private bool mblnHasPreviewIcon;

		private bool mblnIsAnonymous;

		private bool mblnIsOverlayRef;

		private bool mblnIsXRef;

		private double mdblLayoutObjectID;

		private object[] madecOrigin;

		private double[] madblOrigin;

		private string mstrPathName;

		private bool mblnResolved;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		private OrderedDictionary mcolClass;

		private AcadBlockBegin mobjAcadBlockBegin;

		private AcadBlockEnd mobjAcadBlockEnd;

		private AcadDatabase mobjXrefAcadDatabase;

		private AcadArcDictionary mobjAcadArcDictionary;

		private AcadCircleDictionary mobjAcadCircleDictionary;

		private AcadLineDictionary mobjAcadLineDictionary;

		private AcadPointDictionary mobjAcadPointDictionary;

		private AcadTextDictionary mobjAcadTextDictionary;

		private AcadXlineDictionary mobjAcadXlineDictionary;

		private AcadSplineDictionary mobjAcadSplineDictionary;

		private AcadHatchDictionary mobjAcadHatchDictionary;

		private AcadEllipseDictionary mobjAcadEllipseDictionary;

		private AcadShapeDictionary mobjAcadShapeDictionary;

		private AcadRayDictionary mobjAcadRayDictionary;

		private AcadAttributeDictionary mobjAcadAttributeDictionary;

		private AcadBlockRefDictionary mobjAcadBlockReferenceDictionary;

		private AcadMInsertBlockDictionary mobjAcadMInsertBlockDictionary;

		private AcadLWPolylineDictionary mobjAcadLWPolylineDictionary;

		private AcadPolylineDictionary mobjAcadPolylineDictionary;

		private Acad3DPolylineDictionary mobjAcad3DPolylineDictionary;

		private AcadPolygonMeshDictionary mobjAcadPolygonMeshDictionary;

		private AcadPolyfaceMeshDictionary mobjAcadPolyfaceMeshDictionary;

		private AcadMTextDictionary mobjAcadMTextDictionary;

		private AcadTraceDictionary mobjAcadTraceDictionary;

		private AcadSolidDictionary mobjAcadSolidDictionary;

		private AcadUnknownEntDictionary mobjAcadUnknownEntDictionary;

		private Dictionary<object, object> mobjDictPreviewIcon;

		private Dictionary<object, object> mobjDictBlkrefs;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				if (mobjAcadBlockBegin != null)
				{
					mobjAcadBlockBegin.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadBlockEnd != null)
				{
					mobjAcadBlockEnd.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadArcDictionary != null)
				{
					mobjAcadArcDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadCircleDictionary != null)
				{
					mobjAcadCircleDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadLineDictionary != null)
				{
					mobjAcadLineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadPointDictionary != null)
				{
					mobjAcadPointDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadTextDictionary != null)
				{
					mobjAcadTextDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadXlineDictionary != null)
				{
					mobjAcadXlineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadSplineDictionary != null)
				{
					mobjAcadSplineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadHatchDictionary != null)
				{
					mobjAcadHatchDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadEllipseDictionary != null)
				{
					mobjAcadEllipseDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadShapeDictionary != null)
				{
					mobjAcadShapeDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadRayDictionary != null)
				{
					mobjAcadRayDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadAttributeDictionary != null)
				{
					mobjAcadAttributeDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadBlockReferenceDictionary != null)
				{
					mobjAcadBlockReferenceDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadMInsertBlockDictionary != null)
				{
					mobjAcadMInsertBlockDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadLWPolylineDictionary != null)
				{
					mobjAcadLWPolylineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadPolylineDictionary != null)
				{
					mobjAcadPolylineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcad3DPolylineDictionary != null)
				{
					mobjAcad3DPolylineDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadPolygonMeshDictionary != null)
				{
					mobjAcadPolygonMeshDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadPolyfaceMeshDictionary != null)
				{
					mobjAcadPolyfaceMeshDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadMTextDictionary != null)
				{
					mobjAcadMTextDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadTraceDictionary != null)
				{
					mobjAcadTraceDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadSolidDictionary != null)
				{
					mobjAcadSolidDictionary.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadUnknownEntDictionary != null)
				{
					mobjAcadUnknownEntDictionary.FriendLetDatabaseIndex = value;
				}
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				if (mobjAcadBlockBegin != null)
				{
					mobjAcadBlockBegin.FriendLetDocumentIndex = value;
				}
				if (mobjAcadBlockEnd != null)
				{
					mobjAcadBlockEnd.FriendLetDocumentIndex = value;
				}
				if (mobjAcadArcDictionary != null)
				{
					mobjAcadArcDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadCircleDictionary != null)
				{
					mobjAcadCircleDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadLineDictionary != null)
				{
					mobjAcadLineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadPointDictionary != null)
				{
					mobjAcadPointDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadTextDictionary != null)
				{
					mobjAcadTextDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadXlineDictionary != null)
				{
					mobjAcadXlineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadSplineDictionary != null)
				{
					mobjAcadSplineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadHatchDictionary != null)
				{
					mobjAcadHatchDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadEllipseDictionary != null)
				{
					mobjAcadEllipseDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadShapeDictionary != null)
				{
					mobjAcadShapeDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadRayDictionary != null)
				{
					mobjAcadRayDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadAttributeDictionary != null)
				{
					mobjAcadAttributeDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadBlockReferenceDictionary != null)
				{
					mobjAcadBlockReferenceDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadMInsertBlockDictionary != null)
				{
					mobjAcadMInsertBlockDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadLWPolylineDictionary != null)
				{
					mobjAcadLWPolylineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadPolylineDictionary != null)
				{
					mobjAcadPolylineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcad3DPolylineDictionary != null)
				{
					mobjAcad3DPolylineDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadPolygonMeshDictionary != null)
				{
					mobjAcadPolygonMeshDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadPolyfaceMeshDictionary != null)
				{
					mobjAcadPolyfaceMeshDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadMTextDictionary != null)
				{
					mobjAcadMTextDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadTraceDictionary != null)
				{
					mobjAcadTraceDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadSolidDictionary != null)
				{
					mobjAcadSolidDictionary.FriendLetDocumentIndex = value;
				}
				if (mobjAcadUnknownEntDictionary != null)
				{
					mobjAcadUnknownEntDictionary.FriendLetDocumentIndex = value;
				}
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				if (mobjAcadBlockBegin != null)
				{
					mobjAcadBlockBegin.FriendLetApplicationIndex = value;
				}
				if (mobjAcadBlockEnd != null)
				{
					mobjAcadBlockEnd.FriendLetApplicationIndex = value;
				}
				if (mobjAcadArcDictionary != null)
				{
					mobjAcadArcDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadCircleDictionary != null)
				{
					mobjAcadCircleDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadLineDictionary != null)
				{
					mobjAcadLineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadPointDictionary != null)
				{
					mobjAcadPointDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadTextDictionary != null)
				{
					mobjAcadTextDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadXlineDictionary != null)
				{
					mobjAcadXlineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadSplineDictionary != null)
				{
					mobjAcadSplineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadHatchDictionary != null)
				{
					mobjAcadHatchDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadEllipseDictionary != null)
				{
					mobjAcadEllipseDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadShapeDictionary != null)
				{
					mobjAcadShapeDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadRayDictionary != null)
				{
					mobjAcadRayDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadAttributeDictionary != null)
				{
					mobjAcadAttributeDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadBlockReferenceDictionary != null)
				{
					mobjAcadBlockReferenceDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadMInsertBlockDictionary != null)
				{
					mobjAcadMInsertBlockDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadLWPolylineDictionary != null)
				{
					mobjAcadLWPolylineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadPolylineDictionary != null)
				{
					mobjAcadPolylineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcad3DPolylineDictionary != null)
				{
					mobjAcad3DPolylineDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadPolygonMeshDictionary != null)
				{
					mobjAcadPolygonMeshDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadPolyfaceMeshDictionary != null)
				{
					mobjAcadPolyfaceMeshDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadMTextDictionary != null)
				{
					mobjAcadMTextDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadTraceDictionary != null)
				{
					mobjAcadTraceDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadSolidDictionary != null)
				{
					mobjAcadSolidDictionary.FriendLetApplicationIndex = value;
				}
				if (mobjAcadUnknownEntDictionary != null)
				{
					mobjAcadUnknownEntDictionary.FriendLetApplicationIndex = value;
				}
			}
		}

		internal AcadDatabase FriendSetXRefDatabase
		{
			set
			{
				mobjXrefAcadDatabase = value;
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				FriendLetIsAnonymous = ((1 & mlngFlags70) == 1);
				FriendLetHasAttributeDefinitions = ((2 & mlngFlags70) == 2);
				FriendLetIsXRef = ((4 & mlngFlags70) == 4);
				FriendLetIsOverlayRef = ((8 & mlngFlags70) == 8);
				FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		internal bool FriendLetDependend
		{
			set
			{
				mblnDependend = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetHasAttributeDefinitions
		{
			set
			{
				mblnHasAttributeDefinitions = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetIsAnonymous
		{
			set
			{
				mblnIsAnonymous = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetIsOverlayRef
		{
			set
			{
				mblnIsOverlayRef = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetIsXRef
		{
			set
			{
				mblnIsXRef = value;
				InternCalcFlags70();
			}
		}

		internal double FriendLetLayoutObjectID
		{
			set
			{
				mdblLayoutObjectID = value;
			}
		}

		internal string FriendLetPathName
		{
			set
			{
				mstrPathName = value;
			}
		}

		internal bool FriendLetResolved
		{
			set
			{
				mblnResolved = value;
				InternCalcFlags70();
			}
		}

		internal object FriendSetDictPreviewIcon
		{
			set
			{
				if (value == null)
				{
					mobjDictPreviewIcon = null;
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(value, null, "Count", new object[0], null, null, null), 0, TextCompare: false))
				{
					mobjDictPreviewIcon = null;
				}
				else
				{
					mobjDictPreviewIcon = (Dictionary<object, object>)value;
				}
			}
		}

		internal object FriendSetDictBlkrefs
		{
			set
			{
				if (value == null)
				{
					mobjDictBlkrefs = null;
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(value, null, "Count", new object[0], null, null, null), 0, TextCompare: false))
				{
					mobjDictBlkrefs = null;
				}
				else
				{
					mobjDictBlkrefs = (Dictionary<object, object>)value;
				}
			}
		}

		internal object FriendGetDictPreviewIcon => mobjDictPreviewIcon;

		internal object FriendGetDictBlkrefs => mobjDictBlkrefs;

		internal string FriendGetBlkrefsString => hwpDxf_Functions.BkDXF_StringDict(mobjDictBlkrefs);

		public AcadBlockBegin BlockBegin
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlockBegin(-1.0, nvblnWithoutObjectID: false, ref nrstrErrMsg);
			}
		}

		public AcadBlockEnd BlockEnd
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlockEnd(-1.0, nvblnWithoutObjectID: false, ref nrstrErrMsg);
			}
		}

		public AcadDatabase XRefDatabase => mobjXrefAcadDatabase;

		public AcadArcDictionary ArcDictionary => InternGetArcDictionary();

		public AcadCircleDictionary CircleDictionary => InternGetCircleDictionary();

		public AcadLineDictionary LineDictionary => InternGetLineDictionary();

		public AcadPointDictionary PointDictionary => InternGetPointDictionary();

		public AcadTextDictionary TextDictionary => InternGetTextDictionary();

		public AcadXlineDictionary XLineDictionary => InternGetXlineDictionary();

		public AcadSplineDictionary SplineDictionary => InternGetSplineDictionary();

		public AcadHatchDictionary HatchDictionary => InternGetHatchDictionary();

		public AcadEllipseDictionary EllipseDictionary => InternGetEllipseDictionary();

		public AcadShapeDictionary ShapeDictionary => InternGetShapeDictionary();

		public AcadRayDictionary RayDictionary => InternGetRayDictionary();

		public AcadAttributeDictionary AttributeDictionary => InternGetAttributeDictionary();

		public AcadBlockRefDictionary BlockReferenceDictionary => InternGetBlockReferenceDictionary();

		public AcadMInsertBlockDictionary MInsertBlockDictionary => InternGetMInsertBlockDictionary();

		public AcadLWPolylineDictionary LWPolylineDictionary => InternGetLWPolylineDictionary();

		public AcadPolylineDictionary PolylineDictionary => InternGetPolylineDictionary();

		public Acad3DPolylineDictionary Polyline3DDictionary => InternGet3DPolylineDictionary();

		public AcadPolygonMeshDictionary PolygonMeshDictionary => InternGetPolygonMeshDictionary();

		public AcadPolyfaceMeshDictionary PolyfaceMeshDictionary => InternGetPolyfaceMeshDictionary();

		public AcadMTextDictionary MTextDictionary => InternGetMTextDictionary();

		public AcadTraceDictionary TraceDictionary => InternGetTraceDictionary();

		public AcadSolidDictionary SolidDictionary => InternGetSolidDictionary();

		public AcadUnknownEntDictionary UnknownEntDictionary => InternGetUnknownEntDictionary();

		public int Count => mcolClass.Count;

		public string Comment
		{
			get
			{
				return mstrComment;
			}
			set
			{
				mstrComment = value;
			}
		}

		public bool Dependend => mblnDependend;

		public bool HasAttributeDefinitions => mblnHasAttributeDefinitions;

		public bool HasBlkrefs => mobjDictBlkrefs != null;

		public bool HasPreviewIcon => mobjDictPreviewIcon != null;

		public bool IsAnonymous => mblnIsAnonymous;

		public bool IsLayout => mdblLayoutObjectID > 0.0;

		public bool IsOverlayRef => mblnIsOverlayRef;

		public bool IsXRef => mblnIsXRef;

		public double LayoutObjectID => mdblLayoutObjectID;

		public string LayoutReference
		{
			get
			{
				if (mdblLayoutObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblLayoutObjectID);
				}
				return null;
			}
		}

		public object Origin
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecOrigin, madblOrigin));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblOrigin;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadBlock", dstrErrMsg);
				}
			}
		}

		public string PathName => mstrPathName;

		public bool Resolved => mblnResolved;

		public int Flags70 => mlngFlags70;

		public bool IsModelSpace => LikeOperator.LikeString(Strings.UCase(base.Name), Strings.UCase("[*]Model_Space"), CompareMethod.Binary);

		public bool IsPaperSpace => LikeOperator.LikeString(Strings.UCase(base.Name), Strings.UCase("[*]Paper_Space*"), CompareMethod.Binary);

		public AcadBlock()
		{
			madecOrigin = new object[3];
			madblOrigin = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 149;
			base.FriendLetNodeImageDisabledID = 150;
			base.FriendLetNodeName = "Block-Container";
			base.FriendLetNodeText = "Block-Container";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblOrigin[0] = hwpDxf_Vars.padblOrigin[0];
			madblOrigin[1] = hwpDxf_Vars.padblOrigin[1];
			madblOrigin[2] = hwpDxf_Vars.padblOrigin[2];
			mstrComment = hwpDxf_Vars.pstrComment;
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mblnHasAttributeDefinitions = hwpDxf_Vars.pblnHasAttributeDefinitions;
			mblnHasPreviewIcon = hwpDxf_Vars.pblnHasPreviewIcon;
			mblnIsAnonymous = hwpDxf_Vars.pblnIsAnonymous;
			mblnIsOverlayRef = hwpDxf_Vars.pblnIsOverlayRef;
			mblnIsXRef = hwpDxf_Vars.pblnIsXRef;
			mdblLayoutObjectID = hwpDxf_Vars.pdblLayoutObjectID;
			mstrPathName = hwpDxf_Vars.pstrPathName;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			mcolClass = new OrderedDictionary();
			base.FriendLetDXFName = "BLOCK_RECORD";
			base.FriendLetObjectName = "AcDbBlockTableRecord";
		}

		internal AcadBlockBegin FriendAddAcadObjectBlockBegin(double nvdblObjectID = -1.0, bool nvblnWithoutObjectID = false, ref string nrstrErrMsg = "")
		{
			AcadBlockBegin dobjAcadBlockBegin2;
			if (mobjAcadBlockBegin == null)
			{
				dobjAcadBlockBegin2 = new AcadBlockBegin();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadBlockBegin acadBlockBegin = dobjAcadBlockBegin2;
				acadBlockBegin.FriendLetNodeParentID = base.NodeID;
				acadBlockBegin.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadBlockBegin.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadBlockBegin.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadBlockBegin.FriendLetOwnerID = base.ObjectID;
				bool dblnValid = default(bool);
				if (nvblnWithoutObjectID)
				{
					dblnValid = true;
				}
				else
				{
					AcadBlockBegin acadBlockBegin2 = acadBlockBegin;
					double vdblObjectID = nvdblObjectID;
					AcadObject nrobjAcadObject = dobjAcadBlockBegin2;
					string dstrErrMsg = default(string);
					bool flag = acadBlockBegin2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref dstrErrMsg);
					dobjAcadBlockBegin2 = (AcadBlockBegin)nrobjAcadObject;
					if (flag)
					{
						dblnValid = true;
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint(acadBlockBegin.ObjectName + ": " + dstrErrMsg);
					}
				}
				acadBlockBegin = null;
				if (dblnValid)
				{
					mobjAcadBlockBegin = dobjAcadBlockBegin2;
				}
			}
			AcadBlockBegin FriendAddAcadObjectBlockBegin = mobjAcadBlockBegin;
			dobjAcadBlockBegin2 = null;
			return FriendAddAcadObjectBlockBegin;
		}

		internal AcadBlockEnd FriendAddAcadObjectBlockEnd(double nvdblObjectID = -1.0, bool nvblnWithoutObjectID = false, ref string nrstrErrMsg = "")
		{
			AcadBlockEnd dobjAcadBlockEnd2;
			if (mobjAcadBlockEnd == null)
			{
				dobjAcadBlockEnd2 = new AcadBlockEnd();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadBlockEnd acadBlockEnd = dobjAcadBlockEnd2;
				acadBlockEnd.FriendLetNodeParentID = base.NodeID;
				acadBlockEnd.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadBlockEnd.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadBlockEnd.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadBlockEnd.FriendLetOwnerID = base.ObjectID;
				bool dblnValid = default(bool);
				if (nvblnWithoutObjectID)
				{
					dblnValid = true;
				}
				else
				{
					AcadBlockEnd acadBlockEnd2 = acadBlockEnd;
					double vdblObjectID = nvdblObjectID;
					AcadObject nrobjAcadObject = dobjAcadBlockEnd2;
					string dstrErrMsg = default(string);
					bool flag = acadBlockEnd2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref dstrErrMsg);
					dobjAcadBlockEnd2 = (AcadBlockEnd)nrobjAcadObject;
					if (flag)
					{
						dblnValid = true;
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint(acadBlockEnd.ObjectName + ": " + dstrErrMsg);
					}
				}
				acadBlockEnd = null;
				if (dblnValid)
				{
					mobjAcadBlockEnd = dobjAcadBlockEnd2;
				}
			}
			AcadBlockEnd FriendAddAcadObjectBlockEnd = mobjAcadBlockEnd;
			dobjAcadBlockEnd2 = null;
			return FriendAddAcadObjectBlockEnd;
		}

		internal void FriendNewEntityDictionaries()
		{
			InternGetArcDictionary();
			InternGetCircleDictionary();
			InternGetLineDictionary();
			InternGetPointDictionary();
			InternGetTextDictionary();
			InternGetXlineDictionary();
			InternGetSplineDictionary();
			InternGetHatchDictionary();
			InternGetEllipseDictionary();
			InternGetShapeDictionary();
			InternGetRayDictionary();
			InternGetAttributeDictionary();
			InternGetBlockReferenceDictionary();
			InternGetMInsertBlockDictionary();
			InternGetLWPolylineDictionary();
			InternGetPolylineDictionary();
			InternGet3DPolylineDictionary();
			InternGetPolygonMeshDictionary();
			InternGetPolyfaceMeshDictionary();
			InternGetMTextDictionary();
			InternGetTraceDictionary();
			InternGetSolidDictionary();
			InternGetUnknownEntDictionary();
		}

		~AcadBlock()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				if (mobjAcadArcDictionary != null)
				{
					mobjAcadArcDictionary.FriendQuit();
				}
				if (mobjAcadCircleDictionary != null)
				{
					mobjAcadCircleDictionary.FriendQuit();
				}
				if (mobjAcadLineDictionary != null)
				{
					mobjAcadLineDictionary.FriendQuit();
				}
				if (mobjAcadPointDictionary != null)
				{
					mobjAcadPointDictionary.FriendQuit();
				}
				if (mobjAcadTextDictionary != null)
				{
					mobjAcadTextDictionary.FriendQuit();
				}
				if (mobjAcadXlineDictionary != null)
				{
					mobjAcadXlineDictionary.FriendQuit();
				}
				if (mobjAcadSplineDictionary != null)
				{
					mobjAcadSplineDictionary.FriendQuit();
				}
				if (mobjAcadHatchDictionary != null)
				{
					mobjAcadHatchDictionary.FriendQuit();
				}
				if (mobjAcadEllipseDictionary != null)
				{
					mobjAcadEllipseDictionary.FriendQuit();
				}
				if (mobjAcadShapeDictionary != null)
				{
					mobjAcadShapeDictionary.FriendQuit();
				}
				if (mobjAcadRayDictionary != null)
				{
					mobjAcadRayDictionary.FriendQuit();
				}
				if (mobjAcadAttributeDictionary != null)
				{
					mobjAcadAttributeDictionary.FriendQuit();
				}
				if (mobjAcadBlockReferenceDictionary != null)
				{
					mobjAcadBlockReferenceDictionary.FriendQuit();
				}
				if (mobjAcadMInsertBlockDictionary != null)
				{
					mobjAcadMInsertBlockDictionary.FriendQuit();
				}
				if (mobjAcadLWPolylineDictionary != null)
				{
					mobjAcadLWPolylineDictionary.FriendQuit();
				}
				if (mobjAcadPolylineDictionary != null)
				{
					mobjAcadPolylineDictionary.FriendQuit();
				}
				if (mobjAcad3DPolylineDictionary != null)
				{
					mobjAcad3DPolylineDictionary.FriendQuit();
				}
				if (mobjAcadPolygonMeshDictionary != null)
				{
					mobjAcadPolygonMeshDictionary.FriendQuit();
				}
				if (mobjAcadPolyfaceMeshDictionary != null)
				{
					mobjAcadPolyfaceMeshDictionary.FriendQuit();
				}
				if (mobjAcadMTextDictionary != null)
				{
					mobjAcadMTextDictionary.FriendQuit();
				}
				if (mobjAcadTraceDictionary != null)
				{
					mobjAcadTraceDictionary.FriendQuit();
				}
				if (mobjAcadSolidDictionary != null)
				{
					mobjAcadSolidDictionary.FriendQuit();
				}
				if (mobjAcadUnknownEntDictionary != null)
				{
					mobjAcadUnknownEntDictionary.FriendQuit();
				}
				if (mobjAcadBlockBegin != null)
				{
					mobjAcadBlockBegin.FriendQuit();
				}
				if (mobjAcadBlockEnd != null)
				{
					mobjAcadBlockEnd.FriendQuit();
				}
				if (mobjXrefAcadDatabase != null)
				{
					mobjXrefAcadDatabase.FriendQuit();
				}
				base.FriendQuit();
				mobjDictBlkrefs = null;
				mobjDictPreviewIcon = null;
				mobjAcadArcDictionary = null;
				mobjAcadCircleDictionary = null;
				mobjAcadLineDictionary = null;
				mobjAcadPointDictionary = null;
				mobjAcadTextDictionary = null;
				mobjAcadXlineDictionary = null;
				mobjAcadSplineDictionary = null;
				mobjAcadHatchDictionary = null;
				mobjAcadEllipseDictionary = null;
				mobjAcadShapeDictionary = null;
				mobjAcadRayDictionary = null;
				mobjAcadAttributeDictionary = null;
				mobjAcadBlockReferenceDictionary = null;
				mobjAcadMInsertBlockDictionary = null;
				mobjAcadLWPolylineDictionary = null;
				mobjAcadPolylineDictionary = null;
				mobjAcad3DPolylineDictionary = null;
				mobjAcadPolygonMeshDictionary = null;
				mobjAcadPolyfaceMeshDictionary = null;
				mobjAcadMTextDictionary = null;
				mobjAcadTraceDictionary = null;
				mobjAcadSolidDictionary = null;
				mobjAcadUnknownEntDictionary = null;
				mobjAcadBlockBegin = null;
				mobjAcadBlockEnd = null;
				mobjXrefAcadDatabase = null;
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadBlock");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadEntity dobjAcadEntity2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadEntity2 = (AcadEntity)enumerator.Current;
					try
					{
						mcolClass.Remove("K" + Conversions.ToString(dobjAcadEntity2.ObjectID));
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						ProjectData.ClearProjectError();
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadEntity2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal bool FriendReplaceObjectID(ref AcadObject robjAcadObject, double vdblOldObjectID, double vdblNewObjectID)
		{
			bool FriendReplaceObjectID2 = default(bool);
			try
			{
				mcolClass.Remove("K" + Conversions.ToString(vdblOldObjectID));
				mcolClass.Add("K" + Conversions.ToString(vdblNewObjectID), robjAcadObject);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				FriendReplaceObjectID2 = false;
				ProjectData.ClearProjectError();
				return FriendReplaceObjectID2;
			}
			switch (robjAcadObject.ObjectName)
			{
				case "AcDbArc":
					if (!InternGetArcDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbCircle":
					if (!InternGetCircleDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbLine":
					if (!InternGetLineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbPoint":
					if (!InternGetPointDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbText":
					if (!InternGetTextDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbXline":
					if (!InternGetXlineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbSpline":
					if (!InternGetSplineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbHatch":
					if (!InternGetHatchDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbEllipse":
					if (!InternGetEllipseDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbShape":
					if (!InternGetShapeDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbRay":
					if (!InternGetRayDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbAttributeDefinition":
					if (!InternGetAttributeDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbBlockReference":
					if (!InternGetBlockReferenceDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbMInsertBlock":
					if (!InternGetMInsertBlockDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbPolyline":
					if (!InternGetLWPolylineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDb2dPolyline":
					if (!InternGetPolylineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDb3dPolyline":
					if (!InternGet3DPolylineDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbPolygonMesh":
					if (!InternGetPolygonMeshDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbPolyFaceMesh":
					if (!InternGetPolyfaceMeshDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbMText":
					if (!InternGetMTextDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				case "AcDbTrace":
					if (Operators.CompareString(robjAcadObject.DXFName, "TRACE", TextCompare: false) == 0)
					{
						if (!InternGetTraceDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
						{
							break;
						}
					}
					else if (!InternGetSolidDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
					{
						break;
					}
					goto IL_06ac;
				default:
					{
						if (!InternGetUnknownEntDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
						{
							hwpDxf_Functions.BkDXF_DebugPrint("FriendReplaceObjectID: Unbekanntes Entity " + robjAcadObject.ObjectName);
							break;
						}
						goto IL_06ac;
					}
				IL_06ac:
					return true;
			}
			return FriendReplaceObjectID2;
		}

		internal object FriendGetItem(int vintIndex)
		{
			object FriendGetItem = default(object);
			try
			{
				FriendGetItem = RuntimeHelpers.GetObjectValue(mcolClass[checked(vintIndex - 1)]);
				return FriendGetItem;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
				return FriendGetItem;
			}
		}

		internal AcadArc FriendAddAcadObjectArc(double vdblObjectID, object vvarCenter, object vvarRadius, object vvarStartAngle, object vvarEndAngle, bool vblnAngleInDegree, ref string nrstrErrMsg = "")
		{
			AcadArc dobjAcadArc3 = new AcadArc();
			AcadArc acadArc = dobjAcadArc3;
			acadArc.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadArc.Center = RuntimeHelpers.GetObjectValue(vvarCenter);
			acadArc.Radius = RuntimeHelpers.GetObjectValue(vvarRadius);
			if (vblnAngleInDegree)
			{
				acadArc.StartAngleDegree = RuntimeHelpers.GetObjectValue(vvarStartAngle);
				acadArc.EndAngleDegree = RuntimeHelpers.GetObjectValue(vvarEndAngle);
			}
			else
			{
				acadArc.StartAngle = RuntimeHelpers.GetObjectValue(vvarStartAngle);
				acadArc.EndAngle = RuntimeHelpers.GetObjectValue(vvarEndAngle);
			}
			acadArc.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadArc.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadArc.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadArc.FriendLetOwnerID = base.ObjectID;
			AcadArc acadArc2 = acadArc;
			AcadObject nrobjAcadObject = dobjAcadArc3;
			bool flag = acadArc2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadArc3 = (AcadArc)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadArc.ObjectName + ": " + nrstrErrMsg);
			}
			acadArc = null;
			AcadArc FriendAddAcadObjectArc = default(AcadArc);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadArc3.ObjectID), dobjAcadArc3);
				InternGetArcDictionary().FriendAdd(ref dobjAcadArc3);
				FriendAddAcadObjectArc = dobjAcadArc3;
			}
			dobjAcadArc3 = null;
			return FriendAddAcadObjectArc;
		}

		internal AcadCircle FriendAddAcadObjectCircle(double vdblObjectID, object vvarCenter, object vvarRadius, ref string nrstrErrMsg = "")
		{
			AcadCircle dobjAcadCircle3 = new AcadCircle();
			AcadCircle acadCircle = dobjAcadCircle3;
			acadCircle.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadCircle.Center = RuntimeHelpers.GetObjectValue(vvarCenter);
			acadCircle.Radius = RuntimeHelpers.GetObjectValue(vvarRadius);
			acadCircle.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadCircle.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadCircle.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadCircle.FriendLetOwnerID = base.ObjectID;
			AcadCircle acadCircle2 = acadCircle;
			AcadObject nrobjAcadObject = dobjAcadCircle3;
			bool flag = acadCircle2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadCircle3 = (AcadCircle)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadCircle.ObjectName + ": " + nrstrErrMsg);
			}
			acadCircle = null;
			AcadCircle FriendAddAcadObjectCircle = default(AcadCircle);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadCircle3.ObjectID), dobjAcadCircle3);
				InternGetCircleDictionary().FriendAdd(ref dobjAcadCircle3);
				FriendAddAcadObjectCircle = dobjAcadCircle3;
			}
			dobjAcadCircle3 = null;
			return FriendAddAcadObjectCircle;
		}

		internal AcadLWPolyline FriendAddAcadObjectLWPolyline(double vdblObjectID, object nvarVerticesList = null, ref string nrstrErrMsg = "")
		{
			AcadLWPolyline dobjAcadLWPolyline3 = new AcadLWPolyline();
			AcadLWPolyline acadLWPolyline = dobjAcadLWPolyline3;
			if (hwpDxf_Vars.pblnAddLWPolylineStopCalcSize)
			{
				acadLWPolyline.FriendCalcSizeStop = true;
			}
			hwpDxf_Vars.pblnAddLWPolylineStopCalcSize = false;
			acadLWPolyline.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadLWPolyline.Coordinates = RuntimeHelpers.GetObjectValue(nvarVerticesList);
			acadLWPolyline.FriendCalcSizeStop = true;
			acadLWPolyline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLWPolyline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLWPolyline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLWPolyline.FriendLetOwnerID = base.ObjectID;
			AcadLWPolyline acadLWPolyline2 = acadLWPolyline;
			AcadObject nrobjAcadObject = dobjAcadLWPolyline3;
			bool flag = acadLWPolyline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLWPolyline3 = (AcadLWPolyline)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLWPolyline.ObjectName + ": " + nrstrErrMsg);
			}
			acadLWPolyline = null;
			AcadLWPolyline FriendAddAcadObjectLWPolyline = default(AcadLWPolyline);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadLWPolyline3.ObjectID), dobjAcadLWPolyline3);
				InternGetLWPolylineDictionary().FriendAdd(ref dobjAcadLWPolyline3);
				FriendAddAcadObjectLWPolyline = dobjAcadLWPolyline3;
			}
			dobjAcadLWPolyline3 = null;
			return FriendAddAcadObjectLWPolyline;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		internal AcadLWPolyline FriendAddAcadObjectLWPolylineWithVertices(double vdblObjectID, object vobjVertices, ref string nrstrErrMsg = "")
		{
			AcadLWPolyline dobjAcadLWPolyline3 = new AcadLWPolyline();
			AcadLWPolyline acadLWPolyline = dobjAcadLWPolyline3;
			acadLWPolyline.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			try
			{
				acadLWPolyline.Vertices = RuntimeHelpers.GetObjectValue(vobjVertices);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				nrstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				Information.Err().Raise(50000, "AcadBlock", "LWPolylinie konnte nicht hinzugefügt werden.\n" + nrstrErrMsg);
				ProjectData.ClearProjectError();
			}
			acadLWPolyline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLWPolyline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLWPolyline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLWPolyline.FriendLetOwnerID = base.ObjectID;
			AcadLWPolyline acadLWPolyline2 = acadLWPolyline;
			AcadObject nrobjAcadObject = dobjAcadLWPolyline3;
			bool flag = acadLWPolyline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLWPolyline3 = (AcadLWPolyline)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLWPolyline.ObjectName + ": " + nrstrErrMsg);
			}
			acadLWPolyline = null;
			AcadLWPolyline FriendAddAcadObjectLWPolylineWithVertices = default(AcadLWPolyline);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadLWPolyline3.ObjectID), dobjAcadLWPolyline3);
				InternGetLWPolylineDictionary().FriendAdd(ref dobjAcadLWPolyline3);
				FriendAddAcadObjectLWPolylineWithVertices = dobjAcadLWPolyline3;
			}
			dobjAcadLWPolyline3 = null;
			return FriendAddAcadObjectLWPolylineWithVertices;
		}

		internal AcadPolyline FriendAddAcadObjectPolyline(double vdblObjectID, object nvvarPointsArray = null, ref string nrstrErrMsg = "")
		{
			AcadPolyline dobjAcadPolyline3 = new AcadPolyline();
			AcadPolyline acadPolyline = dobjAcadPolyline3;
			if (hwpDxf_Vars.pblnAddPolylineStopCalcSize)
			{
				acadPolyline.FriendCalcSizeStop = true;
			}
			hwpDxf_Vars.pblnAddPolylineStopCalcSize = false;
			acadPolyline.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadPolyline.Coordinates = RuntimeHelpers.GetObjectValue(nvvarPointsArray);
			acadPolyline.FriendCalcSizeStop = true;
			acadPolyline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPolyline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPolyline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPolyline.FriendLetOwnerID = base.ObjectID;
			AcadPolyline acadPolyline2 = acadPolyline;
			AcadObject nrobjAcadObject = dobjAcadPolyline3;
			bool flag = acadPolyline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPolyline3 = (AcadPolyline)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPolyline.ObjectName + ": " + nrstrErrMsg);
			}
			acadPolyline = null;
			AcadPolyline FriendAddAcadObjectPolyline = default(AcadPolyline);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadPolyline3.ObjectID), dobjAcadPolyline3);
				InternGetPolylineDictionary().FriendAdd(ref dobjAcadPolyline3);
				FriendAddAcadObjectPolyline = dobjAcadPolyline3;
			}
			dobjAcadPolyline3 = null;
			return FriendAddAcadObjectPolyline;
		}

		internal Acad3DPolyline FriendAddAcadObject3DPolyline(double vdblObjectID, object nvvarPointsArray = null, ref string nrstrErrMsg = "")
		{
			Acad3DPolyline dobjAcad3DPolyline3 = new Acad3DPolyline();
			Acad3DPolyline acad3DPolyline = dobjAcad3DPolyline3;
			if (hwpDxf_Vars.pblnAdd3DPolylineStopCalcSize)
			{
				acad3DPolyline.FriendCalcSizeStop = true;
			}
			hwpDxf_Vars.pblnAdd3DPolylineStopCalcSize = false;
			acad3DPolyline.Coordinates = RuntimeHelpers.GetObjectValue(nvvarPointsArray);
			acad3DPolyline.FriendCalcSizeStop = true;
			acad3DPolyline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acad3DPolyline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acad3DPolyline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acad3DPolyline.FriendLetOwnerID = base.ObjectID;
			Acad3DPolyline acad3DPolyline2 = acad3DPolyline;
			AcadObject nrobjAcadObject = dobjAcad3DPolyline3;
			bool flag = acad3DPolyline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcad3DPolyline3 = (Acad3DPolyline)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acad3DPolyline.ObjectName + ": " + nrstrErrMsg);
			}
			acad3DPolyline = null;
			Acad3DPolyline FriendAddAcadObject3DPolyline = default(Acad3DPolyline);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcad3DPolyline3.ObjectID), dobjAcad3DPolyline3);
				InternGet3DPolylineDictionary().FriendAdd(ref dobjAcad3DPolyline3);
				FriendAddAcadObject3DPolyline = dobjAcad3DPolyline3;
			}
			dobjAcad3DPolyline3 = null;
			return FriendAddAcadObject3DPolyline;
		}

		internal AcadPolygonMesh FriendAddAcadObjectPolygonMesh(double vdblObjectID, int nvlngMVertexCount = 0, int nvlngNVertexCount = 0, object nvvarPointsMatrix = null, ref string nrstrErrMsg = "")
		{
			AcadPolygonMesh FriendAddAcadObjectPolygonMesh = default(AcadPolygonMesh);
			AcadPolygonMesh dobjAcadPolygonMesh3;
			if ((nvvarPointsMatrix != null) ? checked(nvlngMVertexCount * nvlngNVertexCount * 3 == Information.UBound((Array)nvvarPointsMatrix) - Information.LBound((Array)nvvarPointsMatrix) + 1) : (nvlngMVertexCount == 0 && nvlngNVertexCount == 0))
			{
				dobjAcadPolygonMesh3 = new AcadPolygonMesh();
				AcadPolygonMesh acadPolygonMesh = dobjAcadPolygonMesh3;
				acadPolygonMesh.FriendLetMVertexCount = nvlngMVertexCount;
				acadPolygonMesh.FriendLetNVertexCount = nvlngNVertexCount;
				dobjAcadPolygonMesh3.Coordinates = RuntimeHelpers.GetObjectValue(nvvarPointsMatrix);
				acadPolygonMesh.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPolygonMesh.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPolygonMesh.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPolygonMesh.FriendLetOwnerID = base.ObjectID;
				AcadPolygonMesh acadPolygonMesh2 = acadPolygonMesh;
				AcadObject nrobjAcadObject = dobjAcadPolygonMesh3;
				bool flag = acadPolygonMesh2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadPolygonMesh3 = (AcadPolygonMesh)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadPolygonMesh.ObjectName + ": " + nrstrErrMsg);
				}
				acadPolygonMesh = null;
				if (dblnValid)
				{
					mcolClass.Add("K" + Conversions.ToString(dobjAcadPolygonMesh3.ObjectID), dobjAcadPolygonMesh3);
					InternGetPolygonMeshDictionary().FriendAdd(ref dobjAcadPolygonMesh3);
					FriendAddAcadObjectPolygonMesh = dobjAcadPolygonMesh3;
				}
			}
			dobjAcadPolygonMesh3 = null;
			return FriendAddAcadObjectPolygonMesh;
		}

		internal AcadPolyfaceMesh FriendAddAcadObjectPolyfaceMesh(double vdblObjectID, object nvvarVertexList = null, object nvvarFaceList = null, ref string nrstrErrMsg = "")
		{
			AcadPolyfaceMesh dobjAcadPolyfaceMesh3 = new AcadPolyfaceMesh();
			AcadPolyfaceMesh acadPolyfaceMesh = dobjAcadPolyfaceMesh3;
			acadPolyfaceMesh.Coordinates = RuntimeHelpers.GetObjectValue(nvvarVertexList);
			acadPolyfaceMesh.FriendLetFaces = RuntimeHelpers.GetObjectValue(nvvarFaceList);
			acadPolyfaceMesh.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPolyfaceMesh.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPolyfaceMesh.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPolyfaceMesh.FriendLetOwnerID = base.ObjectID;
			AcadPolyfaceMesh acadPolyfaceMesh2 = acadPolyfaceMesh;
			AcadObject nrobjAcadObject = dobjAcadPolyfaceMesh3;
			bool flag = acadPolyfaceMesh2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPolyfaceMesh3 = (AcadPolyfaceMesh)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPolyfaceMesh.ObjectName + ": " + nrstrErrMsg);
			}
			acadPolyfaceMesh = null;
			AcadPolyfaceMesh FriendAddAcadObjectPolyfaceMesh = default(AcadPolyfaceMesh);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadPolyfaceMesh3.ObjectID), dobjAcadPolyfaceMesh3);
				InternGetPolyfaceMeshDictionary().FriendAdd(ref dobjAcadPolyfaceMesh3);
				FriendAddAcadObjectPolyfaceMesh = dobjAcadPolyfaceMesh3;
			}
			dobjAcadPolyfaceMesh3 = null;
			return FriendAddAcadObjectPolyfaceMesh;
		}

		internal AcadLine FriendAddAcadObjectLine(double vdblObjectID, object vvarStartPoint, object vvarEndPoint, ref string nrstrErrMsg = "")
		{
			AcadLine dobjAcadLine3 = new AcadLine();
			AcadLine acadLine = dobjAcadLine3;
			acadLine.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadLine.StartPoint = RuntimeHelpers.GetObjectValue(vvarStartPoint);
			acadLine.EndPoint = RuntimeHelpers.GetObjectValue(vvarEndPoint);
			acadLine.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadLine.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadLine.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadLine.FriendLetOwnerID = base.ObjectID;
			AcadLine acadLine2 = acadLine;
			AcadObject nrobjAcadObject = dobjAcadLine3;
			bool flag = acadLine2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadLine3 = (AcadLine)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadLine.ObjectName + ": " + nrstrErrMsg);
			}
			acadLine = null;
			AcadLine FriendAddAcadObjectLine = default(AcadLine);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadLine3.ObjectID), dobjAcadLine3);
				InternGetLineDictionary().FriendAdd(ref dobjAcadLine3);
				FriendAddAcadObjectLine = dobjAcadLine3;
			}
			dobjAcadLine3 = null;
			return FriendAddAcadObjectLine;
		}

		internal AcadMText FriendAddAcadObjectMText(double vdblObjectID, object vvarInsertionPoint, object vvarWidth, string vstrText, ref string nrstrErrMsg = "")
		{
			AcadMText dobjAcadMText3 = new AcadMText();
			AcadMText acadMText = dobjAcadMText3;
			acadMText.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadMText.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadMText.Width = RuntimeHelpers.GetObjectValue(vvarWidth);
			acadMText.TextString = vstrText;
			acadMText.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadMText.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadMText.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadMText.FriendLetOwnerID = base.ObjectID;
			AcadMText acadMText2 = acadMText;
			AcadObject nrobjAcadObject = dobjAcadMText3;
			bool flag = acadMText2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadMText3 = (AcadMText)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadMText.ObjectName + ": " + nrstrErrMsg);
			}
			acadMText = null;
			AcadMText FriendAddAcadObjectMText = default(AcadMText);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadMText3.ObjectID), dobjAcadMText3);
				InternGetMTextDictionary().FriendAdd(ref dobjAcadMText3);
				FriendAddAcadObjectMText = dobjAcadMText3;
			}
			dobjAcadMText3 = null;
			return FriendAddAcadObjectMText;
		}

		internal AcadTrace FriendAddAcadObjectTrace(double vdblObjectID, object nvvarPointsArray = null, ref string nrstrErrMsg = "")
		{
			AcadTrace dobjAcadTrace3 = new AcadTrace();
			AcadTrace acadTrace = dobjAcadTrace3;
			acadTrace.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadTrace.Coordinates = RuntimeHelpers.GetObjectValue(nvvarPointsArray);
			acadTrace.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadTrace.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadTrace.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadTrace.FriendLetOwnerID = base.ObjectID;
			AcadTrace acadTrace2 = acadTrace;
			AcadObject nrobjAcadObject = dobjAcadTrace3;
			bool flag = acadTrace2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadTrace3 = (AcadTrace)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadTrace.ObjectName + ": " + nrstrErrMsg);
			}
			acadTrace = null;
			AcadTrace FriendAddAcadObjectTrace = default(AcadTrace);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadTrace3.ObjectID), dobjAcadTrace3);
				InternGetTraceDictionary().FriendAdd(ref dobjAcadTrace3);
				FriendAddAcadObjectTrace = dobjAcadTrace3;
			}
			dobjAcadTrace3 = null;
			return FriendAddAcadObjectTrace;
		}

		internal AcadSolid FriendAddAcadObjectSolid(double vdblObjectID, object nvvarPointsArray = null, ref string nrstrErrMsg = "")
		{
			AcadSolid dobjAcadSolid3 = new AcadSolid();
			AcadSolid acadSolid = dobjAcadSolid3;
			acadSolid.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadSolid.Coordinates = RuntimeHelpers.GetObjectValue(nvvarPointsArray);
			acadSolid.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadSolid.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadSolid.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadSolid.FriendLetOwnerID = base.ObjectID;
			AcadSolid acadSolid2 = acadSolid;
			AcadObject nrobjAcadObject = dobjAcadSolid3;
			bool flag = acadSolid2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadSolid3 = (AcadSolid)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadSolid.ObjectName + ": " + nrstrErrMsg);
			}
			acadSolid = null;
			AcadSolid FriendAddAcadObjectSolid = default(AcadSolid);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadSolid3.ObjectID), dobjAcadSolid3);
				InternGetSolidDictionary().FriendAdd(ref dobjAcadSolid3);
				FriendAddAcadObjectSolid = dobjAcadSolid3;
			}
			dobjAcadSolid3 = null;
			return FriendAddAcadObjectSolid;
		}

		internal AcadPoint FriendAddAcadObjectPoint(double vdblObjectID, object vvarPoint, ref string nrstrErrMsg = "")
		{
			AcadPoint dobjAcadPoint3 = new AcadPoint();
			AcadPoint acadPoint = dobjAcadPoint3;
			acadPoint.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadPoint.Coordinate = RuntimeHelpers.GetObjectValue(vvarPoint);
			acadPoint.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadPoint.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadPoint.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadPoint.FriendLetOwnerID = base.ObjectID;
			AcadPoint acadPoint2 = acadPoint;
			AcadObject nrobjAcadObject = dobjAcadPoint3;
			bool flag = acadPoint2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadPoint3 = (AcadPoint)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadPoint.ObjectName + ": " + nrstrErrMsg);
			}
			acadPoint = null;
			AcadPoint FriendAddAcadObjectPoint = default(AcadPoint);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadPoint3.ObjectID), dobjAcadPoint3);
				InternGetPointDictionary().FriendAdd(ref dobjAcadPoint3);
				FriendAddAcadObjectPoint = dobjAcadPoint3;
			}
			dobjAcadPoint3 = null;
			return FriendAddAcadObjectPoint;
		}

		internal AcadSpline FriendAddAcadObjectSpline(double vdblObjectID, object vvarPointsArray, object vvarStartTangent, object vvarEndTangent, ref string nrstrErrMsg = "")
		{
			AcadSpline dobjAcadSpline3 = new AcadSpline();
			AcadSpline acadSpline = dobjAcadSpline3;
			acadSpline.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			int dlngLBound = Information.LBound((Array)vvarPointsArray);
			int dlngUBound = Information.UBound((Array)vvarPointsArray);
			checked
			{
				if (dlngUBound - dlngLBound > 0)
				{
					int num = dlngLBound;
					int num2 = dlngUBound;
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 3)
					{
						acadSpline.FriendAddFitPoint(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPointsArray, new object[1]
						{
						dlngIdx
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPointsArray, new object[1]
						{
						dlngIdx + 1
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPointsArray, new object[1]
						{
						dlngIdx + 2
						}, null)));
					}
				}
				acadSpline.StartTangent = RuntimeHelpers.GetObjectValue(vvarStartTangent);
				acadSpline.EndTangent = RuntimeHelpers.GetObjectValue(vvarEndTangent);
				acadSpline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadSpline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadSpline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadSpline.FriendLetOwnerID = base.ObjectID;
				AcadSpline acadSpline2 = acadSpline;
				AcadObject nrobjAcadObject = dobjAcadSpline3;
				bool flag = acadSpline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
				dobjAcadSpline3 = (AcadSpline)nrobjAcadObject;
				bool dblnValid = default(bool);
				if (flag)
				{
					dblnValid = true;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint(acadSpline.ObjectName + ": " + nrstrErrMsg);
				}
				acadSpline = null;
				AcadSpline FriendAddAcadObjectSpline = default(AcadSpline);
				if (dblnValid)
				{
					mcolClass.Add("K" + Conversions.ToString(dobjAcadSpline3.ObjectID), dobjAcadSpline3);
					InternGetSplineDictionary().FriendAdd(ref dobjAcadSpline3);
					FriendAddAcadObjectSpline = dobjAcadSpline3;
				}
				dobjAcadSpline3 = null;
				return FriendAddAcadObjectSpline;
			}
		}

		internal AcadText FriendAddAcadObjectText(double vdblObjectID, string vstrTextString, object vvarInsertionPoint, object vvarHeight, ref string nrstrErrMsg = "")
		{
			AcadText dobjAcadText3 = new AcadText();
			AcadText acadText = dobjAcadText3;
			acadText.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadText.TextString = vstrTextString;
			acadText.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadText.Height = RuntimeHelpers.GetObjectValue(vvarHeight);
			acadText.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadText.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadText.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadText.FriendLetOwnerID = base.ObjectID;
			AcadText acadText2 = acadText;
			AcadObject nrobjAcadObject = dobjAcadText3;
			bool flag = acadText2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadText3 = (AcadText)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadText.ObjectName + ": " + nrstrErrMsg);
			}
			acadText = null;
			AcadText FriendAddAcadObjectText = default(AcadText);
			if (dblnValid)
			{
				AcadTextStyle dobjAcadTextStyle = (AcadTextStyle)base.Database.TextStyles.FriendGetItem(hwpDxf_Vars.pstrTextStyleName);
				if (dobjAcadTextStyle != null)
				{
					dobjAcadText3.TextStyle = dobjAcadTextStyle.Name;
				}
				mcolClass.Add("K" + Conversions.ToString(dobjAcadText3.ObjectID), dobjAcadText3);
				InternGetTextDictionary().FriendAdd(ref dobjAcadText3);
				FriendAddAcadObjectText = dobjAcadText3;
			}
			dobjAcadText3 = null;
			return FriendAddAcadObjectText;
		}

		internal AcadShape FriendAddAcadObjectShape(double vdblObjectID, string vstrName, object vvarInsertionPoint, object vvarScaleFactor, object vvarRotationAngleDegree, ref string nrstrErrMsg = "")
		{
			AcadShape dobjAcadShape3 = new AcadShape();
			AcadShape acadShape = dobjAcadShape3;
			acadShape.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadShape.Name = vstrName;
			acadShape.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadShape.ScaleFactor = RuntimeHelpers.GetObjectValue(vvarScaleFactor);
			acadShape.RotationDegree = RuntimeHelpers.GetObjectValue(vvarRotationAngleDegree);
			acadShape.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadShape.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadShape.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadShape.FriendLetOwnerID = base.ObjectID;
			AcadShape acadShape2 = acadShape;
			AcadObject nrobjAcadObject = dobjAcadShape3;
			bool flag = acadShape2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadShape3 = (AcadShape)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadShape.ObjectName + ": " + nrstrErrMsg);
			}
			acadShape = null;
			AcadShape FriendAddAcadObjectShape = default(AcadShape);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadShape3.ObjectID), dobjAcadShape3);
				InternGetShapeDictionary().FriendAdd(ref dobjAcadShape3);
				FriendAddAcadObjectShape = dobjAcadShape3;
			}
			dobjAcadShape3 = null;
			return FriendAddAcadObjectShape;
		}

		internal AcadEllipse FriendAddAcadObjectEllipse(double vdblObjectID, object vvarCenter, object vvarMajorAxis, object vvarRadiusRatio, ref string nrstrErrMsg = "")
		{
			AcadEllipse dobjAcadEllipse3 = new AcadEllipse();
			AcadEllipse acadEllipse = dobjAcadEllipse3;
			acadEllipse.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadEllipse.Center = RuntimeHelpers.GetObjectValue(vvarCenter);
			acadEllipse.MajorAxis = RuntimeHelpers.GetObjectValue(vvarMajorAxis);
			acadEllipse.RadiusRatio = RuntimeHelpers.GetObjectValue(vvarRadiusRatio);
			acadEllipse.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadEllipse.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadEllipse.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadEllipse.FriendLetOwnerID = base.ObjectID;
			AcadEllipse acadEllipse2 = acadEllipse;
			AcadObject nrobjAcadObject = dobjAcadEllipse3;
			bool flag = acadEllipse2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadEllipse3 = (AcadEllipse)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadEllipse.ObjectName + ": " + nrstrErrMsg);
			}
			acadEllipse = null;
			AcadEllipse FriendAddAcadObjectEllipse = default(AcadEllipse);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadEllipse3.ObjectID), dobjAcadEllipse3);
				InternGetEllipseDictionary().FriendAdd(ref dobjAcadEllipse3);
				FriendAddAcadObjectEllipse = dobjAcadEllipse3;
			}
			dobjAcadEllipse3 = null;
			return FriendAddAcadObjectEllipse;
		}

		internal AcadXline FriendAddAcadObjectXline(double vdblObjectID, object vvarPoint1, object vvarPoint2, ref string nrstrErrMsg = "")
		{
			AcadXline dobjAcadXline3 = new AcadXline();
			AcadXline acadXline = dobjAcadXline3;
			acadXline.BasePoint = RuntimeHelpers.GetObjectValue(vvarPoint1);
			acadXline.SecondPoint = RuntimeHelpers.GetObjectValue(vvarPoint2);
			acadXline.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadXline.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadXline.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadXline.FriendLetOwnerID = base.ObjectID;
			AcadXline acadXline2 = acadXline;
			AcadObject nrobjAcadObject = dobjAcadXline3;
			bool flag = acadXline2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadXline3 = (AcadXline)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadXline.ObjectName + ": " + nrstrErrMsg);
			}
			acadXline = null;
			AcadXline FriendAddAcadObjectXline = default(AcadXline);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadXline3.ObjectID), dobjAcadXline3);
				InternGetXlineDictionary().FriendAdd(ref dobjAcadXline3);
				FriendAddAcadObjectXline = dobjAcadXline3;
			}
			dobjAcadXline3 = null;
			return FriendAddAcadObjectXline;
		}

		internal AcadHatch FriendAddAcadObjectHatch(double vdblObjectID, int vlngPatternType, string vstrPatternName, bool vblnAssociativity, ref string nrstrErrMsg = "")
		{
			AcadHatch dobjAcadHatch3 = new AcadHatch();
			AcadHatch acadHatch = dobjAcadHatch3;
			acadHatch.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadHatch.FriendLetPatternType = (Enums.AcPatternType)vlngPatternType;
			acadHatch.FriendLetPatternName = vstrPatternName;
			acadHatch.AssociativeHatch = vblnAssociativity;
			acadHatch.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadHatch.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadHatch.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadHatch.FriendLetOwnerID = base.ObjectID;
			AcadHatch acadHatch2 = acadHatch;
			AcadObject nrobjAcadObject = dobjAcadHatch3;
			bool flag = acadHatch2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadHatch3 = (AcadHatch)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadHatch.ObjectName + ": " + nrstrErrMsg);
			}
			acadHatch = null;
			AcadHatch FriendAddAcadObjectHatch = default(AcadHatch);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadHatch3.ObjectID), dobjAcadHatch3);
				InternGetHatchDictionary().FriendAdd(ref dobjAcadHatch3);
				FriendAddAcadObjectHatch = dobjAcadHatch3;
			}
			dobjAcadHatch3 = null;
			return FriendAddAcadObjectHatch;
		}

		internal AcadRay FriendAddAcadObjectRay(double vdblObjectID, object vvarPoint1, object vvarPoint2, ref string nrstrErrMsg = "")
		{
			AcadRay dobjAcadRay3 = new AcadRay();
			AcadRay acadRay = dobjAcadRay3;
			acadRay.BasePoint = RuntimeHelpers.GetObjectValue(vvarPoint1);
			acadRay.SecondPoint = RuntimeHelpers.GetObjectValue(vvarPoint2);
			acadRay.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadRay.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadRay.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadRay.FriendLetOwnerID = base.ObjectID;
			AcadRay acadRay2 = acadRay;
			AcadObject nrobjAcadObject = dobjAcadRay3;
			bool flag = acadRay2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadRay3 = (AcadRay)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadRay.ObjectName + ": " + nrstrErrMsg);
			}
			acadRay = null;
			AcadRay FriendAddAcadObjectRay = default(AcadRay);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadRay3.ObjectID), dobjAcadRay3);
				InternGetRayDictionary().FriendAdd(ref dobjAcadRay3);
				FriendAddAcadObjectRay = dobjAcadRay3;
			}
			dobjAcadRay3 = null;
			return FriendAddAcadObjectRay;
		}

		internal AcadAttribute FriendAddAcadObjectAttribute(double vdblObjectID, object vvarHeight, Enums.AcAttributeMode vnumMode, string vstrPrompt, object vvarInsertionPoint, string vstrTag, string vstrValue, ref string nrstrErrMsg = "")
		{
			AcadAttribute dobjAcadAttribute3 = new AcadAttribute();
			AcadAttribute acadAttribute = dobjAcadAttribute3;
			acadAttribute.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadAttribute.Height = RuntimeHelpers.GetObjectValue(vvarHeight);
			acadAttribute.FriendLetAttribFlags = vnumMode;
			acadAttribute.PromptString = vstrPrompt;
			acadAttribute.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadAttribute.TagString = vstrTag;
			acadAttribute.TextString = vstrValue;
			acadAttribute.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadAttribute.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadAttribute.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadAttribute.FriendLetOwnerID = base.ObjectID;
			AcadAttribute acadAttribute2 = acadAttribute;
			AcadObject nrobjAcadObject = dobjAcadAttribute3;
			bool flag = acadAttribute2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadAttribute3 = (AcadAttribute)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadAttribute.ObjectName + ": " + nrstrErrMsg);
			}
			acadAttribute = null;
			AcadAttribute FriendAddAcadObjectAttribute = default(AcadAttribute);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadAttribute3.ObjectID), dobjAcadAttribute3);
				InternGetAttributeDictionary().FriendAdd(ref dobjAcadAttribute3);
				FriendAddAcadObjectAttribute = dobjAcadAttribute3;
			}
			dobjAcadAttribute3 = null;
			return FriendAddAcadObjectAttribute;
		}

		internal AcadMInsertBlock FriendAddAcadObjectMInsertBlock(double vdblObjectID, object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, int vlngNumRows, int vlngNumColumns, object vvarRowSpacing, object vvarColumnSpacing, ref string nrstrErrMsg = "")
		{
			AcadMInsertBlock dobjAcadMInsertBlock3 = new AcadMInsertBlock();
			AcadMInsertBlock acadMInsertBlock = dobjAcadMInsertBlock3;
			acadMInsertBlock.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadMInsertBlock.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadMInsertBlock.XScaleFactor = RuntimeHelpers.GetObjectValue(vvarXScale);
			acadMInsertBlock.YScaleFactor = RuntimeHelpers.GetObjectValue(vvarYScale);
			acadMInsertBlock.ZScaleFactor = RuntimeHelpers.GetObjectValue(vvarZScale);
			acadMInsertBlock.RotationDegree = RuntimeHelpers.GetObjectValue(vvarRotationDegree);
			acadMInsertBlock.Rows = vlngNumRows;
			acadMInsertBlock.Columns = vlngNumColumns;
			acadMInsertBlock.RowSpacing = RuntimeHelpers.GetObjectValue(vvarRowSpacing);
			acadMInsertBlock.ColumnSpacing = RuntimeHelpers.GetObjectValue(vvarColumnSpacing);
			acadMInsertBlock.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadMInsertBlock.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadMInsertBlock.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadMInsertBlock.Name = vstrName;
			acadMInsertBlock.FriendLetOwnerID = base.ObjectID;
			AcadMInsertBlock acadMInsertBlock2 = acadMInsertBlock;
			AcadObject nrobjAcadObject = dobjAcadMInsertBlock3;
			bool flag = acadMInsertBlock2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadMInsertBlock3 = (AcadMInsertBlock)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadMInsertBlock.ObjectName + ": " + nrstrErrMsg);
			}
			acadMInsertBlock = null;
			AcadMInsertBlock FriendAddAcadObjectMInsertBlock = default(AcadMInsertBlock);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadMInsertBlock3.ObjectID), dobjAcadMInsertBlock3);
				InternGetMInsertBlockDictionary().FriendAdd(ref dobjAcadMInsertBlock3);
				FriendAddAcadObjectMInsertBlock = dobjAcadMInsertBlock3;
			}
			dobjAcadMInsertBlock3 = null;
			return FriendAddAcadObjectMInsertBlock;
		}

		internal AcadBlockReference FriendAddAcadObjectInsertBlock(double vdblObjectID, object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, ref string nrstrErrMsg = "")
		{
			AcadBlockReference dobjAcadBlockReference3 = new AcadBlockReference();
			AcadBlockReference acadBlockReference = dobjAcadBlockReference3;
			acadBlockReference.Normal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			acadBlockReference.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadBlockReference.XScaleFactor = RuntimeHelpers.GetObjectValue(vvarXScale);
			acadBlockReference.YScaleFactor = RuntimeHelpers.GetObjectValue(vvarYScale);
			acadBlockReference.ZScaleFactor = RuntimeHelpers.GetObjectValue(vvarZScale);
			acadBlockReference.RotationDegree = RuntimeHelpers.GetObjectValue(vvarRotationDegree);
			acadBlockReference.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadBlockReference.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadBlockReference.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadBlockReference.Name = vstrName;
			acadBlockReference.FriendLetOwnerID = base.ObjectID;
			AcadBlockReference acadBlockReference2 = acadBlockReference;
			AcadObject nrobjAcadObject = dobjAcadBlockReference3;
			bool flag = acadBlockReference2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadBlockReference3 = (AcadBlockReference)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadBlockReference.ObjectName + ": " + nrstrErrMsg);
			}
			acadBlockReference = null;
			AcadBlockReference FriendAddAcadObjectInsertBlock = default(AcadBlockReference);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadBlockReference3.ObjectID), dobjAcadBlockReference3);
				InternGetBlockReferenceDictionary().FriendAdd(ref dobjAcadBlockReference3);
				FriendAddAcadObjectInsertBlock = dobjAcadBlockReference3;
			}
			dobjAcadBlockReference3 = null;
			return FriendAddAcadObjectInsertBlock;
		}

		internal AcadUnknownEnt FriendAddAcadObjectUnknownEnt(double vdblObjectID, Dictionary<object, object> vobjDictCodes, Dictionary<object, object> vobjDictValues, ref string nrstrErrMsg = "")
		{
			AcadUnknownEnt dobjAcadUnknownEnt3 = new AcadUnknownEnt();
			AcadUnknownEnt acadUnknownEnt = dobjAcadUnknownEnt3;
			acadUnknownEnt.FriendSetDictCodes = vobjDictCodes;
			acadUnknownEnt.FriendSetDictValues = vobjDictValues;
			acadUnknownEnt.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadUnknownEnt.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadUnknownEnt.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadUnknownEnt.FriendLetOwnerID = base.ObjectID;
			AcadUnknownEnt acadUnknownEnt2 = acadUnknownEnt;
			AcadObject nrobjAcadObject = dobjAcadUnknownEnt3;
			bool flag = acadUnknownEnt2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadUnknownEnt3 = (AcadUnknownEnt)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadUnknownEnt.ObjectName + ": " + nrstrErrMsg);
			}
			acadUnknownEnt = null;
			AcadUnknownEnt FriendAddAcadObjectUnknownEnt = default(AcadUnknownEnt);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadUnknownEnt3.ObjectID), dobjAcadUnknownEnt3);
				InternGetUnknownEntDictionary().FriendAdd(ref dobjAcadUnknownEnt3);
				FriendAddAcadObjectUnknownEnt = dobjAcadUnknownEnt3;
			}
			dobjAcadUnknownEnt3 = null;
			return FriendAddAcadObjectUnknownEnt;
		}

		public AcadEntity Item(int vintIndex)
		{
			return (AcadEntity)mcolClass[checked(vintIndex - 1)];
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadBlockReference InsertBlockDegree(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadBlockReference dobjAcadBlockReference2 = FriendAddAcadObjectInsertBlock(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotationDegree), ref dstrErrMsg);
			AcadBlockReference InsertBlockDegree = default(AcadBlockReference);
			if (dobjAcadBlockReference2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				InsertBlockDegree = dobjAcadBlockReference2;
			}
			dobjAcadBlockReference2 = null;
			return InsertBlockDegree;
		}

		public AcadBlockReference InsertBlock(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotation, string nvstrHandle = "")
		{
			return InsertBlockDegree(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(vvarRotation))), nvstrHandle);
		}

		public void Bind(bool vblnPrefixName)
		{
		}

		public void Detach()
		{
		}

		public void Reload()
		{
		}

		public void Unload()
		{
		}

		public Acad3DFace Add3DFace(object vvarPoint1, object vvarPoint2, object vvarPoint3, object vvarPoint4, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DFace dobjAcad3DFace = null;
			Acad3DFace Add3DFace = default(Acad3DFace);
			return Add3DFace;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadPolygonMesh Add3DMesh(int vlngM, int vlngN, object vvarPointsMatrix, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadPolygonMesh dobjAcadPolygonMesh2 = FriendAddAcadObjectPolygonMesh(ddblObjectID, vlngM, vlngN, RuntimeHelpers.GetObjectValue(vvarPointsMatrix), ref dstrErrMsg);
			AcadPolygonMesh Add3DMesh = default(AcadPolygonMesh);
			if (dobjAcadPolygonMesh2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				Add3DMesh = dobjAcadPolygonMesh2;
			}
			dobjAcadPolygonMesh2 = null;
			return Add3DMesh;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public Acad3DPolyline Add3DPoly(object vvarPointsArray, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			Acad3DPolyline dobjAcad3DPolyline2 = FriendAddAcadObject3DPolyline(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPointsArray), ref dstrErrMsg);
			Acad3DPolyline Add3DPoly = default(Acad3DPolyline);
			if (dobjAcad3DPolyline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				Add3DPoly = dobjAcad3DPolyline2;
			}
			dobjAcad3DPolyline2 = null;
			return Add3DPoly;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadArc AddArc(object vvarCenter, object vvarRadius, object vvarStartAngle, object vvarEndAngle, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadArc dobjAcadArc2 = FriendAddAcadObjectArc(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), RuntimeHelpers.GetObjectValue(vvarStartAngle), RuntimeHelpers.GetObjectValue(vvarEndAngle), vblnAngleInDegree: false, ref dstrErrMsg);
			AcadArc AddArc = default(AcadArc);
			if (dobjAcadArc2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddArc = dobjAcadArc2;
			}
			dobjAcadArc2 = null;
			return AddArc;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadAttribute AddAttribute(object vvarHeight, Enums.AcAttributeMode vnumMode, string vstrPrompt, object vvarInsertionPoint, string vstrTag, string vstrValue, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadAttribute dobjAcadAttribute2 = FriendAddAcadObjectAttribute(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarHeight), vnumMode, vstrPrompt, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrTag, vstrValue, ref dstrErrMsg);
			AcadAttribute AddAttribute = default(AcadAttribute);
			if (dobjAcadAttribute2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddAttribute = dobjAcadAttribute2;
			}
			dobjAcadAttribute2 = null;
			return AddAttribute;
		}

		public Acad3DSolid AddBox(object vvarOrigin, object vvarLength, object vvarWidth, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddBox = default(Acad3DSolid);
			return AddBox;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadCircle AddCircle(object vvarCenter, object vvarRadius, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadCircle dobjAcadCircle2 = FriendAddAcadObjectCircle(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarRadius), ref dstrErrMsg);
			AcadCircle AddCircle = default(AcadCircle);
			if (dobjAcadCircle2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddCircle = dobjAcadCircle2;
			}
			dobjAcadCircle2 = null;
			return AddCircle;
		}

		public Acad3DSolid AddCone(object vvarCenter, object vvarBaseRadius, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddCone = default(Acad3DSolid);
			return AddCone;
		}

		public object AddCustomObject(string vstrClassName, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			object dobjObject = null;
			object AddCustomObject = default(object);
			return AddCustomObject;
		}

		public Acad3DSolid AddCylinder(object vvarCenter, object vvarRadius, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddCylinder = default(Acad3DSolid);
			return AddCylinder;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadEllipse AddEllipse(object vvarCenter, object vvarMajorAxis, object vvarRadiusRatio, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadEllipse dobjAcadEllipse2 = FriendAddAcadObjectEllipse(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarCenter), RuntimeHelpers.GetObjectValue(vvarMajorAxis), RuntimeHelpers.GetObjectValue(vvarRadiusRatio), ref dstrErrMsg);
			AcadEllipse AddEllipse = default(AcadEllipse);
			if (dobjAcadEllipse2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddEllipse = dobjAcadEllipse2;
			}
			dobjAcadEllipse2 = null;
			return AddEllipse;
		}

		public Acad3DSolid AddEllipticalCone(object vvarCenter, object vvarMajorRadius, object vvarMinorRadius, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddEllipticalCone = default(Acad3DSolid);
			return AddEllipticalCone;
		}

		public Acad3DSolid AddEllipticalCylinder(object vvarCenter, object vvarMajorRadius, object vvarMinorRadius, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddEllipticalCylinder = default(Acad3DSolid);
			return AddEllipticalCylinder;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadHatch AddHatch(int vlngPatternType, string vstrPatternName, bool vblnAssociativity, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadHatch dobjAcadHatch2 = FriendAddAcadObjectHatch(ddblObjectID, vlngPatternType, vstrPatternName, vblnAssociativity, ref dstrErrMsg);
			AcadHatch AddHatch = default(AcadHatch);
			if (dobjAcadHatch2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddHatch = dobjAcadHatch2;
			}
			dobjAcadHatch2 = null;
			return AddHatch;
		}

		public AcadLeader AddLeader(object vvarPointsArray, AcadEntity vobjAnnotation, Enums.AcLeaderType vnumLeaderType, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			AcadLeader dobjAcadLeader = null;
			AcadLeader AddLeader = default(AcadLeader);
			return AddLeader;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadLWPolyline AddLightWeightPolyline(object vvarVerticesList, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadLWPolyline dobjAcadLWPolyline2 = FriendAddAcadObjectLWPolyline(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarVerticesList), ref dstrErrMsg);
			AcadLWPolyline AddLightWeightPolyline = default(AcadLWPolyline);
			if (dobjAcadLWPolyline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddLightWeightPolyline = dobjAcadLWPolyline2;
			}
			dobjAcadLWPolyline2 = null;
			return AddLightWeightPolyline;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadLWPolyline AddLightWeightPolylineWithVertices(object vobjVertices, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadLWPolyline dobjAcadLWPolyline2 = FriendAddAcadObjectLWPolylineWithVertices(ddblObjectID, RuntimeHelpers.GetObjectValue(vobjVertices), ref dstrErrMsg);
			AcadLWPolyline AddLightWeightPolylineWithVertices = default(AcadLWPolyline);
			if (dobjAcadLWPolyline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddLightWeightPolylineWithVertices = dobjAcadLWPolyline2;
			}
			dobjAcadLWPolyline2 = null;
			return AddLightWeightPolylineWithVertices;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadPolyline AddPolyline(object vvarVerticesList, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadPolyline dobjAcadPolyline2 = FriendAddAcadObjectPolyline(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarVerticesList), ref dstrErrMsg);
			AcadPolyline AddPolyline = default(AcadPolyline);
			if (dobjAcadPolyline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddPolyline = dobjAcadPolyline2;
			}
			dobjAcadPolyline2 = null;
			return AddPolyline;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadLine AddLine(object vvarStartPoint, object vvarEndPoint, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadLine dobjAcadLine2 = FriendAddAcadObjectLine(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarStartPoint), RuntimeHelpers.GetObjectValue(vvarEndPoint), ref dstrErrMsg);
			AcadLine AddLine = default(AcadLine);
			if (dobjAcadLine2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddLine = dobjAcadLine2;
			}
			dobjAcadLine2 = null;
			return AddLine;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadMInsertBlock AddMInsertBlockDegree(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotationDegree, int vlngNumRows, int vlngNumColumns, object vvarRowSpacing, object vvarColumnSpacing, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadMInsertBlock dobjAcadMInsertBlock2 = FriendAddAcadObjectMInsertBlock(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(vvarRotationDegree), vlngNumRows, vlngNumColumns, RuntimeHelpers.GetObjectValue(vvarRowSpacing), RuntimeHelpers.GetObjectValue(vvarColumnSpacing), ref dstrErrMsg);
			AcadMInsertBlock AddMInsertBlockDegree = default(AcadMInsertBlock);
			if (dobjAcadMInsertBlock2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddMInsertBlockDegree = dobjAcadMInsertBlock2;
			}
			dobjAcadMInsertBlock2 = null;
			return AddMInsertBlockDegree;
		}

		public AcadMInsertBlock AddMInsertBlock(object vvarInsertionPoint, string vstrName, object vvarXScale, object vvarYScale, object vvarZScale, object vvarRotation, int vlngNumRows, int vlngNumColumns, object vvarRowSpacing, object vvarColumnSpacing, string nvstrHandle = "")
		{
			return AddMInsertBlockDegree(RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrName, RuntimeHelpers.GetObjectValue(vvarXScale), RuntimeHelpers.GetObjectValue(vvarYScale), RuntimeHelpers.GetObjectValue(vvarZScale), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(vvarRotation))), vlngNumRows, vlngNumColumns, RuntimeHelpers.GetObjectValue(vvarRowSpacing), RuntimeHelpers.GetObjectValue(vvarColumnSpacing), nvstrHandle);
		}

		public AcadMLine AddMLine(object vvarVertexList, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			AcadMLine dobjAcadMLine = null;
			AcadMLine AddMLine = default(AcadMLine);
			return AddMLine;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadMText AddMText(object vvarInsertionPoint, object vvarWidth, string vstrText, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadMText dobjAcadMText2 = FriendAddAcadObjectMText(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarWidth), vstrText, ref dstrErrMsg);
			AcadMText AddMText = default(AcadMText);
			if (dobjAcadMText2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddMText = dobjAcadMText2;
			}
			dobjAcadMText2 = null;
			return AddMText;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadPoint AddPoint(object vvarPoint, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadPoint dobjAcadPoint2 = FriendAddAcadObjectPoint(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPoint), ref dstrErrMsg);
			AcadPoint AddPoint = default(AcadPoint);
			if (dobjAcadPoint2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddPoint = dobjAcadPoint2;
			}
			dobjAcadPoint2 = null;
			return AddPoint;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadPolyfaceMesh AddPolyfaceMesh(object vvarVertexList, object vvarFaceList, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadPolyfaceMesh dobjAcadPolyfaceMesh2 = FriendAddAcadObjectPolyfaceMesh(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarVertexList), RuntimeHelpers.GetObjectValue(vvarFaceList), ref dstrErrMsg);
			AcadPolyfaceMesh AddPolyfaceMesh = default(AcadPolyfaceMesh);
			if (dobjAcadPolyfaceMesh2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddPolyfaceMesh = dobjAcadPolyfaceMesh2;
			}
			dobjAcadPolyfaceMesh2 = null;
			return AddPolyfaceMesh;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadRay AddRay(object vvarPoint1, object vvarPoint2, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadRay dobjAcadRay2 = FriendAddAcadObjectRay(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), ref dstrErrMsg);
			AcadRay AddRay = default(AcadRay);
			if (dobjAcadRay2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddRay = dobjAcadRay2;
			}
			dobjAcadRay2 = null;
			return AddRay;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadShape AddShape(string vstrName, object vvarInsertionPoint, object vvarScaleFactor, object vvarRotationAngle, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadShape dobjAcadShape2 = FriendAddAcadObjectShape(ddblObjectID, vstrName, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarScaleFactor), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(vvarRotationAngle))), ref dstrErrMsg);
			AcadShape AddShape = default(AcadShape);
			if (dobjAcadShape2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddShape = dobjAcadShape2;
			}
			dobjAcadShape2 = null;
			return AddShape;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadSolid AddSolid(object vvarPoint1, object vvarPoint2, object vvarPoint3, object vvarPoint4, string nvstrHandle = "")
		{
			object[] davarCoordinates = new object[12];
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			davarCoordinates[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null));
			davarCoordinates[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			1
			}, null));
			davarCoordinates[2] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			2
			}, null));
			davarCoordinates[3] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null));
			davarCoordinates[4] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			1
			}, null));
			davarCoordinates[5] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			2
			}, null));
			davarCoordinates[6] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint3, new object[1]
			{
			0
			}, null));
			davarCoordinates[7] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint3, new object[1]
			{
			1
			}, null));
			davarCoordinates[8] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint3, new object[1]
			{
			2
			}, null));
			davarCoordinates[9] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint4, new object[1]
			{
			0
			}, null));
			davarCoordinates[10] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint4, new object[1]
			{
			1
			}, null));
			davarCoordinates[11] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint4, new object[1]
			{
			2
			}, null));
			string dstrErrMsg = default(string);
			AcadSolid dobjAcadSolid2 = FriendAddAcadObjectSolid(ddblObjectID, davarCoordinates, ref dstrErrMsg);
			AcadSolid AddSolid = default(AcadSolid);
			if (dobjAcadSolid2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddSolid = dobjAcadSolid2;
			}
			dobjAcadSolid2 = null;
			return AddSolid;
		}

		public Acad3DSolid AddSphere(object vvarCenter, object vvarRadius, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddSphere = default(Acad3DSolid);
			return AddSphere;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadSpline AddSpline(object vvarPointsArray, object vvarStartTangent, object vvarEndTangent, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadSpline dobjAcadSpline2 = FriendAddAcadObjectSpline(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPointsArray), RuntimeHelpers.GetObjectValue(vvarStartTangent), RuntimeHelpers.GetObjectValue(vvarEndTangent), ref dstrErrMsg);
			AcadSpline AddSpline = default(AcadSpline);
			if (dobjAcadSpline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddSpline = dobjAcadSpline2;
			}
			dobjAcadSpline2 = null;
			return AddSpline;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadText AddText(string vstrTextString, object vvarInsertionPoint, object vvarHeight, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadText dobjAcadText2 = FriendAddAcadObjectText(ddblObjectID, vstrTextString, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), RuntimeHelpers.GetObjectValue(vvarHeight), ref dstrErrMsg);
			AcadText AddText = default(AcadText);
			if (dobjAcadText2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddText = dobjAcadText2;
			}
			dobjAcadText2 = null;
			return AddText;
		}

		public Acad3DSolid AddTorus(object vvarCenter, object vvarTorusRadius, object vvarTubeRadius, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddTorus = default(Acad3DSolid);
			return AddTorus;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadTrace AddTrace(object vvarPointsArray, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadTrace dobjAcadTrace2 = FriendAddAcadObjectTrace(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPointsArray), ref dstrErrMsg);
			AcadTrace AddTrace = default(AcadTrace);
			if (dobjAcadTrace2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddTrace = dobjAcadTrace2;
			}
			dobjAcadTrace2 = null;
			return AddTrace;
		}

		public Acad3DSolid AddWedge(object vvarCenter, object vvarLength, object vvarWidth, object vvarHeight, string nvstrHandle = "")
		{
			if (Operators.CompareString(nvstrHandle, null, TextCompare: false) == 0)
			{
				double ddblObjectID2 = base.Database.FriendGetNextObjectID;
			}
			else
			{
				double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle);
			}
			Acad3DSolid dobjAcad3DSolid = null;
			Acad3DSolid AddWedge = default(Acad3DSolid);
			return AddWedge;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadXline AddXline(object vvarPoint1, object vvarPoint2, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadXline dobjAcadXline2 = FriendAddAcadObjectXline(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), ref dstrErrMsg);
			AcadXline AddXline = default(AcadXline);
			if (dobjAcadXline2 == null)
			{
				Information.Err().Raise(50000, "AcadBlock", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddXline = dobjAcadXline2;
			}
			dobjAcadXline2 = null;
			return AddXline;
		}

		public object GetMinMaxCoords(object vvarEntityNames = null)
		{
			Dictionary<object, object> dobjDictEntityNames2 = new Dictionary<object, object>();
			if (vvarEntityNames == null)
			{
				if (hwpDxf_ConstMisc.pclngFirstEntityName <= hwpDxf_ConstMisc.pclngLastEntityName)
				{
					int pclngFirstEntityName = hwpDxf_ConstMisc.pclngFirstEntityName;
					int pclngLastEntityName = hwpDxf_ConstMisc.pclngLastEntityName;
					for (int dlngIdx2 = pclngFirstEntityName; dlngIdx2 <= pclngLastEntityName; dlngIdx2 = checked(dlngIdx2 + 1))
					{
						Enums.AcEntityName dnumEntityName3 = (Enums.AcEntityName)dlngIdx2;
						string dstrKey3 = "K" + Conversions.ToString((int)dnumEntityName3);
						if (!dobjDictEntityNames2.ContainsKey(dstrKey3))
						{
							dobjDictEntityNames2.Add(dstrKey3, dnumEntityName3);
						}
					}
				}
			}
			else
			{
				switch (Information.VarType(RuntimeHelpers.GetObjectValue(vvarEntityNames)))
				{
					case (VariantType)8195:
					case (VariantType)8201:
						{
							int num = Information.LBound((Array)vvarEntityNames);
							int num2 = Information.UBound((Array)vvarEntityNames);
							for (int dlngIdx2 = num; dlngIdx2 <= num2; dlngIdx2 = checked(dlngIdx2 + 1))
							{
								object dvarItem = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarEntityNames, new object[1]
								{
						dlngIdx2
								}, null));
								if (Information.VarType(RuntimeHelpers.GetObjectValue(dvarItem)) == VariantType.Integer && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarItem, hwpDxf_ConstMisc.pclngFirstEntityName, TextCompare: false), Operators.CompareObjectLessEqual(dvarItem, hwpDxf_ConstMisc.pclngLastEntityName, TextCompare: false))))
								{
									Enums.AcEntityName dnumEntityName3 = (Enums.AcEntityName)Conversions.ToInteger(dvarItem);
									string dstrKey3 = "K" + Conversions.ToString((int)dnumEntityName3);
									if (!dobjDictEntityNames2.ContainsKey(dstrKey3))
									{
										dobjDictEntityNames2.Add(dstrKey3, dnumEntityName3);
									}
								}
							}
							break;
						}
					case VariantType.Integer:
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vvarEntityNames, hwpDxf_ConstMisc.pclngFirstEntityName, TextCompare: false), Operators.CompareObjectLessEqual(vvarEntityNames, hwpDxf_ConstMisc.pclngLastEntityName, TextCompare: false))))
						{
							Enums.AcEntityName dnumEntityName3 = (Enums.AcEntityName)Conversions.ToInteger(vvarEntityNames);
							string dstrKey3 = "K" + Conversions.ToString((int)dnumEntityName3);
							if (!dobjDictEntityNames2.ContainsKey(dstrKey3))
							{
								dobjDictEntityNames2.Add(dstrKey3, dnumEntityName3);
							}
						}
						break;
				}
			}
			object GetMinMaxCoords = (dobjDictEntityNames2.Count <= 0) ? null : RuntimeHelpers.GetObjectValue(InternGetMinMaxCoords(RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictEntityNames2.Values))));
			dobjDictEntityNames2 = null;
			return GetMinMaxCoords;
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsAnonymous, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(HasAttributeDefinitions, 2, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsXRef, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsOverlayRef, 8, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Resolved, 32, 0)));
			}
		}

		private AcadArcDictionary InternGetArcDictionary()
		{
			if (mobjAcadArcDictionary == null)
			{
				mobjAcadArcDictionary = new AcadArcDictionary();
				AcadArcDictionary acadArcDictionary = mobjAcadArcDictionary;
				acadArcDictionary.FriendLetNodeParentID = base.NodeID;
				acadArcDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadArcDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadArcDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadArcDictionary.FriendLetOwnerID = base.ObjectID;
				acadArcDictionary = null;
			}
			return mobjAcadArcDictionary;
		}

		private AcadCircleDictionary InternGetCircleDictionary()
		{
			if (mobjAcadCircleDictionary == null)
			{
				mobjAcadCircleDictionary = new AcadCircleDictionary();
				AcadCircleDictionary acadCircleDictionary = mobjAcadCircleDictionary;
				acadCircleDictionary.FriendLetNodeParentID = base.NodeID;
				acadCircleDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadCircleDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadCircleDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadCircleDictionary.FriendLetOwnerID = base.ObjectID;
				acadCircleDictionary = null;
			}
			return mobjAcadCircleDictionary;
		}

		private AcadLineDictionary InternGetLineDictionary()
		{
			if (mobjAcadLineDictionary == null)
			{
				mobjAcadLineDictionary = new AcadLineDictionary();
				AcadLineDictionary acadLineDictionary = mobjAcadLineDictionary;
				acadLineDictionary.FriendLetNodeParentID = base.NodeID;
				acadLineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadLineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadLineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadLineDictionary.FriendLetOwnerID = base.ObjectID;
				acadLineDictionary = null;
			}
			return mobjAcadLineDictionary;
		}

		private AcadPointDictionary InternGetPointDictionary()
		{
			if (mobjAcadPointDictionary == null)
			{
				mobjAcadPointDictionary = new AcadPointDictionary();
				AcadPointDictionary acadPointDictionary = mobjAcadPointDictionary;
				acadPointDictionary.FriendLetNodeParentID = base.NodeID;
				acadPointDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPointDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPointDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPointDictionary.FriendLetOwnerID = base.ObjectID;
				acadPointDictionary = null;
			}
			return mobjAcadPointDictionary;
		}

		private AcadTextDictionary InternGetTextDictionary()
		{
			if (mobjAcadTextDictionary == null)
			{
				mobjAcadTextDictionary = new AcadTextDictionary();
				AcadTextDictionary acadTextDictionary = mobjAcadTextDictionary;
				acadTextDictionary.FriendLetNodeParentID = base.NodeID;
				acadTextDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadTextDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadTextDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadTextDictionary.FriendLetOwnerID = base.ObjectID;
				acadTextDictionary = null;
			}
			return mobjAcadTextDictionary;
		}

		private AcadXlineDictionary InternGetXlineDictionary()
		{
			if (mobjAcadXlineDictionary == null)
			{
				mobjAcadXlineDictionary = new AcadXlineDictionary();
				AcadXlineDictionary acadXlineDictionary = mobjAcadXlineDictionary;
				acadXlineDictionary.FriendLetNodeParentID = base.NodeID;
				acadXlineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadXlineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadXlineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadXlineDictionary.FriendLetOwnerID = base.ObjectID;
				acadXlineDictionary = null;
			}
			return mobjAcadXlineDictionary;
		}

		private AcadSplineDictionary InternGetSplineDictionary()
		{
			if (mobjAcadSplineDictionary == null)
			{
				mobjAcadSplineDictionary = new AcadSplineDictionary();
				AcadSplineDictionary acadSplineDictionary = mobjAcadSplineDictionary;
				acadSplineDictionary.FriendLetNodeParentID = base.NodeID;
				acadSplineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadSplineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadSplineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadSplineDictionary.FriendLetOwnerID = base.ObjectID;
				acadSplineDictionary = null;
			}
			return mobjAcadSplineDictionary;
		}

		private AcadHatchDictionary InternGetHatchDictionary()
		{
			if (mobjAcadHatchDictionary == null)
			{
				mobjAcadHatchDictionary = new AcadHatchDictionary();
				AcadHatchDictionary acadHatchDictionary = mobjAcadHatchDictionary;
				acadHatchDictionary.FriendLetNodeParentID = base.NodeID;
				acadHatchDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadHatchDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadHatchDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadHatchDictionary.FriendLetOwnerID = base.ObjectID;
				acadHatchDictionary = null;
			}
			return mobjAcadHatchDictionary;
		}

		private AcadEllipseDictionary InternGetEllipseDictionary()
		{
			if (mobjAcadEllipseDictionary == null)
			{
				mobjAcadEllipseDictionary = new AcadEllipseDictionary();
				AcadEllipseDictionary acadEllipseDictionary = mobjAcadEllipseDictionary;
				acadEllipseDictionary.FriendLetNodeParentID = base.NodeID;
				acadEllipseDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadEllipseDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadEllipseDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadEllipseDictionary.FriendLetOwnerID = base.ObjectID;
				acadEllipseDictionary = null;
			}
			return mobjAcadEllipseDictionary;
		}

		private AcadShapeDictionary InternGetShapeDictionary()
		{
			if (mobjAcadShapeDictionary == null)
			{
				mobjAcadShapeDictionary = new AcadShapeDictionary();
				AcadShapeDictionary acadShapeDictionary = mobjAcadShapeDictionary;
				acadShapeDictionary.FriendLetNodeParentID = base.NodeID;
				acadShapeDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadShapeDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadShapeDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadShapeDictionary.FriendLetOwnerID = base.ObjectID;
				acadShapeDictionary = null;
			}
			return mobjAcadShapeDictionary;
		}

		private AcadRayDictionary InternGetRayDictionary()
		{
			if (mobjAcadRayDictionary == null)
			{
				mobjAcadRayDictionary = new AcadRayDictionary();
				AcadRayDictionary acadRayDictionary = mobjAcadRayDictionary;
				acadRayDictionary.FriendLetNodeParentID = base.NodeID;
				acadRayDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadRayDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadRayDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadRayDictionary.FriendLetOwnerID = base.ObjectID;
				acadRayDictionary = null;
			}
			return mobjAcadRayDictionary;
		}

		private AcadAttributeDictionary InternGetAttributeDictionary()
		{
			if (mobjAcadAttributeDictionary == null)
			{
				mobjAcadAttributeDictionary = new AcadAttributeDictionary();
				AcadAttributeDictionary acadAttributeDictionary = mobjAcadAttributeDictionary;
				acadAttributeDictionary.FriendLetNodeParentID = base.NodeID;
				acadAttributeDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadAttributeDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadAttributeDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadAttributeDictionary.FriendLetOwnerID = base.ObjectID;
				acadAttributeDictionary = null;
			}
			return mobjAcadAttributeDictionary;
		}

		private AcadBlockRefDictionary InternGetBlockReferenceDictionary()
		{
			if (mobjAcadBlockReferenceDictionary == null)
			{
				mobjAcadBlockReferenceDictionary = new AcadBlockRefDictionary();
				AcadBlockRefDictionary acadBlockRefDictionary = mobjAcadBlockReferenceDictionary;
				acadBlockRefDictionary.FriendLetNodeParentID = base.NodeID;
				acadBlockRefDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadBlockRefDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadBlockRefDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadBlockRefDictionary.FriendLetOwnerID = base.ObjectID;
				acadBlockRefDictionary = null;
			}
			return mobjAcadBlockReferenceDictionary;
		}

		private AcadMInsertBlockDictionary InternGetMInsertBlockDictionary()
		{
			if (mobjAcadMInsertBlockDictionary == null)
			{
				mobjAcadMInsertBlockDictionary = new AcadMInsertBlockDictionary();
				AcadMInsertBlockDictionary acadMInsertBlockDictionary = mobjAcadMInsertBlockDictionary;
				acadMInsertBlockDictionary.FriendLetNodeParentID = base.NodeID;
				acadMInsertBlockDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadMInsertBlockDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadMInsertBlockDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadMInsertBlockDictionary.FriendLetOwnerID = base.ObjectID;
				acadMInsertBlockDictionary = null;
			}
			return mobjAcadMInsertBlockDictionary;
		}

		private AcadLWPolylineDictionary InternGetLWPolylineDictionary()
		{
			if (mobjAcadLWPolylineDictionary == null)
			{
				mobjAcadLWPolylineDictionary = new AcadLWPolylineDictionary();
				AcadLWPolylineDictionary acadLWPolylineDictionary = mobjAcadLWPolylineDictionary;
				acadLWPolylineDictionary.FriendLetNodeParentID = base.NodeID;
				acadLWPolylineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadLWPolylineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadLWPolylineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadLWPolylineDictionary.FriendLetOwnerID = base.ObjectID;
				acadLWPolylineDictionary = null;
			}
			return mobjAcadLWPolylineDictionary;
		}

		private AcadPolylineDictionary InternGetPolylineDictionary()
		{
			if (mobjAcadPolylineDictionary == null)
			{
				mobjAcadPolylineDictionary = new AcadPolylineDictionary();
				AcadPolylineDictionary acadPolylineDictionary = mobjAcadPolylineDictionary;
				acadPolylineDictionary.FriendLetNodeParentID = base.NodeID;
				acadPolylineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPolylineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPolylineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPolylineDictionary.FriendLetOwnerID = base.ObjectID;
				acadPolylineDictionary = null;
			}
			return mobjAcadPolylineDictionary;
		}

		private Acad3DPolylineDictionary InternGet3DPolylineDictionary()
		{
			if (mobjAcad3DPolylineDictionary == null)
			{
				mobjAcad3DPolylineDictionary = new Acad3DPolylineDictionary();
				Acad3DPolylineDictionary acad3DPolylineDictionary = mobjAcad3DPolylineDictionary;
				acad3DPolylineDictionary.FriendLetNodeParentID = base.NodeID;
				acad3DPolylineDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acad3DPolylineDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acad3DPolylineDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acad3DPolylineDictionary.FriendLetOwnerID = base.ObjectID;
				acad3DPolylineDictionary = null;
			}
			return mobjAcad3DPolylineDictionary;
		}

		private AcadPolygonMeshDictionary InternGetPolygonMeshDictionary()
		{
			if (mobjAcadPolygonMeshDictionary == null)
			{
				mobjAcadPolygonMeshDictionary = new AcadPolygonMeshDictionary();
				AcadPolygonMeshDictionary acadPolygonMeshDictionary = mobjAcadPolygonMeshDictionary;
				acadPolygonMeshDictionary.FriendLetNodeParentID = base.NodeID;
				acadPolygonMeshDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPolygonMeshDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPolygonMeshDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPolygonMeshDictionary.FriendLetOwnerID = base.ObjectID;
				acadPolygonMeshDictionary = null;
			}
			return mobjAcadPolygonMeshDictionary;
		}

		private AcadPolyfaceMeshDictionary InternGetPolyfaceMeshDictionary()
		{
			if (mobjAcadPolyfaceMeshDictionary == null)
			{
				mobjAcadPolyfaceMeshDictionary = new AcadPolyfaceMeshDictionary();
				AcadPolyfaceMeshDictionary acadPolyfaceMeshDictionary = mobjAcadPolyfaceMeshDictionary;
				acadPolyfaceMeshDictionary.FriendLetNodeParentID = base.NodeID;
				acadPolyfaceMeshDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadPolyfaceMeshDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadPolyfaceMeshDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadPolyfaceMeshDictionary.FriendLetOwnerID = base.ObjectID;
				acadPolyfaceMeshDictionary = null;
			}
			return mobjAcadPolyfaceMeshDictionary;
		}

		private AcadMTextDictionary InternGetMTextDictionary()
		{
			if (mobjAcadMTextDictionary == null)
			{
				mobjAcadMTextDictionary = new AcadMTextDictionary();
				AcadMTextDictionary acadMTextDictionary = mobjAcadMTextDictionary;
				acadMTextDictionary.FriendLetNodeParentID = base.NodeID;
				acadMTextDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadMTextDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadMTextDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadMTextDictionary.FriendLetOwnerID = base.ObjectID;
				acadMTextDictionary = null;
			}
			return mobjAcadMTextDictionary;
		}

		private AcadTraceDictionary InternGetTraceDictionary()
		{
			if (mobjAcadTraceDictionary == null)
			{
				mobjAcadTraceDictionary = new AcadTraceDictionary();
				AcadTraceDictionary acadTraceDictionary = mobjAcadTraceDictionary;
				acadTraceDictionary.FriendLetNodeParentID = base.NodeID;
				acadTraceDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadTraceDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadTraceDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadTraceDictionary.FriendLetOwnerID = base.ObjectID;
				acadTraceDictionary = null;
			}
			return mobjAcadTraceDictionary;
		}

		private AcadSolidDictionary InternGetSolidDictionary()
		{
			if (mobjAcadSolidDictionary == null)
			{
				mobjAcadSolidDictionary = new AcadSolidDictionary();
				AcadSolidDictionary acadSolidDictionary = mobjAcadSolidDictionary;
				acadSolidDictionary.FriendLetNodeParentID = base.NodeID;
				acadSolidDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadSolidDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadSolidDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadSolidDictionary.FriendLetOwnerID = base.ObjectID;
				acadSolidDictionary = null;
			}
			return mobjAcadSolidDictionary;
		}

		private AcadUnknownEntDictionary InternGetUnknownEntDictionary()
		{
			if (mobjAcadUnknownEntDictionary == null)
			{
				mobjAcadUnknownEntDictionary = new AcadUnknownEntDictionary();
				AcadUnknownEntDictionary acadUnknownEntDictionary = mobjAcadUnknownEntDictionary;
				acadUnknownEntDictionary.FriendLetNodeParentID = base.NodeID;
				acadUnknownEntDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadUnknownEntDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadUnknownEntDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadUnknownEntDictionary.FriendLetOwnerID = base.ObjectID;
				acadUnknownEntDictionary = null;
			}
			return mobjAcadUnknownEntDictionary;
		}

		private object InternGetMinMaxCoords(object vvarItems)
		{
			int num = Information.LBound((Array)vvarItems);
			int num2 = Information.UBound((Array)vvarItems);
			object dvarMinMaxCoords = default(object);
			bool dblnFirst = default(bool);
			object dvarMaxCoordX = default(object);
			object dvarMaxCoordY = default(object);
			object dvarMinCoordX = default(object);
			object dvarMinCoordY = default(object);
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				switch (Conversions.ToInteger(NewLateBinding.LateIndexGet(vvarItems, new object[1]
				{
				dlngIdx
				}, null)))
				{
					case 2:
						if (mobjAcad3DPolylineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcad3DPolylineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 4:
						if (mobjAcadArcDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadArcDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 5:
						if (mobjAcadAttributeDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadAttributeDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 7:
						if (mobjAcadBlockReferenceDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadBlockReferenceDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 8:
						if (mobjAcadCircleDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadCircleDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 16:
						if (mobjAcadEllipseDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadEllipseDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 17:
						if (mobjAcadHatchDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadHatchDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 19:
						if (mobjAcadLineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadLineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 21:
						if (mobjAcadMTextDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadMTextDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 22:
						if (mobjAcadPointDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadPointDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 23:
						if (mobjAcadPolylineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadPolylineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 24:
						if (mobjAcadLWPolylineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadLWPolylineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 25:
						if (mobjAcadPolygonMeshDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadPolygonMeshDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 27:
						if (mobjAcadRayDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadRayDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 29:
						if (mobjAcadShapeDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadShapeDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 30:
						if (mobjAcadSolidDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadSolidDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 31:
						if (mobjAcadSplineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadSplineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 32:
						if (mobjAcadTextDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadTextDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 34:
						if (mobjAcadTraceDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadTraceDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 36:
						if (mobjAcadXlineDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadXlineDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 38:
						if (mobjAcadMInsertBlockDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadMInsertBlockDictionary.FriendGetMinMaxCoords());
						}
						break;
					case 39:
						if (mobjAcadPolyfaceMeshDictionary != null)
						{
							dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(mobjAcadPolyfaceMeshDictionary.FriendGetMinMaxCoords());
						}
						break;
					default:
						dvarMinMaxCoords = null;
						break;
					case 1:
					case 3:
					case 6:
					case 9:
					case 10:
					case 12:
					case 13:
					case 14:
					case 15:
					case 18:
					case 26:
					case 28:
					case 33:
					case 35:
					case 37:
					case 40:
					case 41:
					case 42:
						break;
				}
				if (dvarMinMaxCoords == null)
				{
					continue;
				}
				if (!dblnFirst)
				{
					dvarMaxCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					0
					}, null));
					dvarMaxCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					1
					}, null));
					dvarMinCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					2
					}, null));
					dvarMinCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					3
					}, null));
					dblnFirst = true;
					continue;
				}
				if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
				{
				0
				}, null), dvarMaxCoordX, TextCompare: false))
				{
					dvarMaxCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					0
					}, null));
				}
				if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
				{
				1
				}, null), dvarMaxCoordY, TextCompare: false))
				{
					dvarMaxCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					1
					}, null));
				}
				if (Operators.ConditionalCompareObjectLess(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
				{
				2
				}, null), dvarMinCoordX, TextCompare: false))
				{
					dvarMinCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					2
					}, null));
				}
				if (Operators.ConditionalCompareObjectLess(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
				{
				3
				}, null), dvarMinCoordY, TextCompare: false))
				{
					dvarMinCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarMinMaxCoords, new object[1]
					{
					3
					}, null));
				}
			}
			if (dblnFirst)
			{
				return new object[4]
				{
				dvarMaxCoordX,
				dvarMaxCoordY,
				dvarMinCoordX,
				dvarMinCoordY
				};
			}
			return null;
		}
	}
}
