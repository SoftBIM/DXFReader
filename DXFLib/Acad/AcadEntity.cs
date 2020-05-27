using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadEntity : AcadObject
	{
		private const string cstrClassName = "AcadEntity";

		private bool mblnOpened;

		private Enums.AcEntityName mnumEntityType;

		private Enums.AcColor mnumColor;

		private string mstrLayer;

		private double mdblLayerObjectID;

		private string mstrLinetype;

		private double mdblLinetypeObjectID;

		private object mdecLinetypeScale;

		private double mdblLinetypeScale;

		private Enums.AcLineWeight mnumLineweight;

		private bool mblnVisible;

		private double mdblPlotStyleNameObjectID;

		private int mlngRGB;

		private bool mblnSized;

		private object mdecMaxCoordX;

		private double mdblMaxCoordX;

		private object mdecMaxCoordY;

		private double mdblMaxCoordY;

		private object mdecMinCoordX;

		private double mdblMinCoordX;

		private object mdecMinCoordY;

		private double mdblMinCoordY;

		private AcadHyperlinks mobjAcadHyperlinks;

		internal Enums.AcEntityName FriendLetEntityType
		{
			set
			{
				mnumEntityType = value;
			}
		}

		internal double FriendLetPlotStyleNameObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblPlotStyleNameObjectID = value;
				}
			}
		}

		internal string FriendLetPlotStyleNameReference
		{
			set
			{
				if (Operators.CompareString(value, null, TextCompare: false) != 0)
				{
					double ddblPlotStyleNameObjectID = FriendLetPlotStyleNameObjectID = hwpDxf_Functions.BkDXF_HexToDbl(value);
				}
			}
		}

		internal int FriendLetRGB
		{
			set
			{
				mlngRGB = value;
			}
		}

		public Enums.AcEntityName EntityType => mnumEntityType;

		public Enums.AcColor Color
		{
			get
			{
				return mnumColor;
			}
			set
			{
				mnumColor = value;
			}
		}

		public AcadHyperlinks Hyperlinks => mobjAcadHyperlinks;

		public double LayerObjectID => mdblLayerObjectID;

		public string LayerReference
		{
			get
			{
				if (mdblLayerObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblLayerObjectID);
				}
				return null;
			}
		}

		public string Layer
		{
			get
			{
				if (mdblLayerObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblLayerObjectID;
					string nrstrErrMsg = "";
					AcadObject dobjAcadObject = default(AcadObject);
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject.ObjectName, "AcDbLayerTableRecord", TextCompare: false) == 0)
					{
						AcadLayer dobjAcadLayer = (AcadLayer)dobjAcadObject;
						mstrLayer = dobjAcadLayer.Name;
					}
				}
				return mstrLayer;
			}
			set
			{
				AcadLayer dobjAcadLayer = (AcadLayer)base.Database.Layers.FriendGetItem(value);
				if (dobjAcadLayer != null)
				{
					mstrLayer = dobjAcadLayer.Name;
					mdblLayerObjectID = dobjAcadLayer.ObjectID;
				}
				else
				{
					mstrLayer = value;
					mdblLayerObjectID = -1.0;
					hwpDxf_Functions.BkDXF_DebugPrint("AcadEntity: Layer '" + value + "' konnte nicht gefunden werden.");
				}
			}
		}

		public double LinetypeObjectID => mdblLinetypeObjectID;

		public string LinetypeReference
		{
			get
			{
				if (mdblLinetypeObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblLinetypeObjectID);
				}
				return null;
			}
		}

		public string Linetype
		{
			get
			{
				if (mdblLinetypeObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblLinetypeObjectID;
					string nrstrErrMsg = "";
					AcadObject dobjAcadObject = default(AcadObject);
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject.ObjectName, "AcDbLinetypeTableRecord", TextCompare: false) == 0)
					{
						AcadLineType dobjAcadLinetype = (AcadLineType)dobjAcadObject;
						mstrLinetype = dobjAcadLinetype.Name;
					}
				}
				return mstrLinetype;
			}
			set
			{
				AcadLineType dobjAcadLinetype = (AcadLineType)base.Database.Linetypes.FriendGetItem(hwpDxf_Functions.BkDXF_LinetypeString(value));
				if (dobjAcadLinetype != null)
				{
					mstrLinetype = dobjAcadLinetype.Name;
					mdblLinetypeObjectID = dobjAcadLinetype.ObjectID;
				}
				else
				{
					mstrLinetype = value;
					mdblLinetypeObjectID = -1.0;
					hwpDxf_Functions.BkDXF_DebugPrint("AcadEntity: Linientyp '" + value + "' konnte nicht gefunden werden.");
				}
			}
		}

		public object LinetypeScale
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecLinetypeScale), mdblLinetypeScale));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecLinetypeScale;
				ref double reference = ref mdblLinetypeScale;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadEntity", dstrErrMsg);
				}
			}
		}

		public Enums.AcLineWeight Lineweight
		{
			get
			{
				return mnumLineweight;
			}
			set
			{
				mnumLineweight = value;
			}
		}

		public bool Visible
		{
			get
			{
				return mblnVisible;
			}
			set
			{
				mblnVisible = value;
			}
		}

		public int RGB_Renamed => mlngRGB;

		public double PlotStyleNameObjectID => mdblPlotStyleNameObjectID;

		public string PlotStyleNameReference
		{
			get
			{
				if (mdblPlotStyleNameObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblPlotStyleNameObjectID);
				}
				return null;
			}
		}

		public string PlotStyleName
		{
			get
			{
				if (mdblPlotStyleNameObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblPlotStyleNameObjectID;
					string nrstrErrMsg = "";
					AcadObject dobjAcadObject = default(AcadObject);
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject.ObjectName, "AcDbPlaceholder", TextCompare: false) == 0)
					{
						AcadPlaceholder dobjAcadPlaceholder = (AcadPlaceholder)dobjAcadObject;
						return dobjAcadPlaceholder.Name;
					}
				}
				string PlotStyleName = default(string);
				return PlotStyleName;
			}
			set
			{
				AcadPlaceholder dobjAcadPlaceholder = (AcadPlaceholder)base.Database.Dictionaries.PlotStyleNames.FriendGetItem(value);
				if (dobjAcadPlaceholder != null)
				{
					mdblPlotStyleNameObjectID = dobjAcadPlaceholder.ObjectID;
				}
			}
		}

		public object MinMaxCoords
		{
			get
			{
				if (mblnSized)
				{
					return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new object[4]
					{
					mdecMaxCoordX,
					mdecMaxCoordY,
					mdecMinCoordX,
					mdecMinCoordY
					}, new object[4]
					{
					mdblMaxCoordX,
					mdblMaxCoordY,
					mdblMinCoordX,
					mdblMinCoordY
					}));
				}
				return null;
			}
		}

		public AcadEntity()
		{
			mblnOpened = true;
			base.FriendLetDXFName = "ENTITY";
			base.FriendLetObjectName = "AcDbEntity";
			bool flag = false;
			mdblLinetypeScale = hwpDxf_Vars.pdblLinetypeScale;
			mnumEntityType = Enums.AcEntityName.acEntity;
			mnumColor = hwpDxf_Vars.pnumEntityColor;
			mstrLayer = hwpDxf_Vars.pstrLayer;
			mdblLayerObjectID = -1.0;
			mstrLinetype = hwpDxf_Vars.pstrEntityLinetype;
			mdblLinetypeObjectID = -1.0;
			mnumLineweight = hwpDxf_Vars.pnumEntityLineweight;
			mblnVisible = hwpDxf_Vars.pblnVisible;
			mlngRGB = hwpDxf_Vars.plngRGB;
			mdblPlotStyleNameObjectID = -1.0;
			mobjAcadHyperlinks = new AcadHyperlinks();
		}

		~AcadEntity()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadHyperlinks.FriendQuit();
				base.FriendQuit();
				mobjAcadHyperlinks = null;
				mblnOpened = false;
			}
		}

		internal void FriendSetMinMaxCoords(object vvarMinMaxCoords)
		{
			InternSetSize(RuntimeHelpers.GetObjectValue(vvarMinMaxCoords));
		}

		public object ArrayPolar(int vlngNumberOfObjects, object vvarAngleToFill, object vvarCenterPoint)
		{
			object ArrayPolar = default(object);
			return ArrayPolar;
		}

		public object ArrayRectangular(int vlngNumberOfRows, int vlngNumberOfColumns, int vlngNumberOfLevels, object vvarDistBetweenRows, object vvarDistBetweenCols, object vvarDistBetweenLevels)
		{
			object ArrayRectangular = default(object);
			return ArrayRectangular;
		}

		public object Copy()
		{
			object Copy = default(object);
			return Copy;
		}

		public void GetBoundingBox(ref object rvarMinPoint, ref object rvarMaxPoint)
		{
		}

		public void Highlight(bool vblnHighlightFlag)
		{
		}

		public object IntersectWith(object vobjIntersectObject, Enums.AcExtendOption vnumOption)
		{
			object IntersectWith = default(object);
			return IntersectWith;
		}

		public object Mirror(object vvarPoint1, object vvarPoint2)
		{
			object Mirror = default(object);
			return Mirror;
		}

		public object Mirror3D(object vvarPoint1, object vvarPoint2, object vvarPoint3)
		{
			object Mirror3D = default(object);
			return Mirror3D;
		}

		public void Move(object vvarFromPoint, object vvarToPoint)
		{
		}

		public void Rotate(object vvarBasePoint, object vvarRotationAngle)
		{
		}

		public void Rotate3D(object vvarPoint1, object vvarPoint2, object vvarRotationAngle)
		{
		}

		public void ScaleEntity(object vvarBasePoint, object vvarScaleFactor)
		{
		}

		public void TransformBy(object vvarTransformationMatrix)
		{
		}

		public void Update()
		{
		}

		private void InternSetSize(object vvarMinMaxCoords)
		{
			if (vvarMinMaxCoords == null)
			{
				return;
			}
			object dvarMaxCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarMinMaxCoords, new object[1]
			{
			0
			}, null));
			object dvarMaxCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarMinMaxCoords, new object[1]
			{
			1
			}, null));
			object dvarMinCoordX = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarMinMaxCoords, new object[1]
			{
			2
			}, null));
			object dvarMinCoordY = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarMinMaxCoords, new object[1]
			{
			3
			}, null));
			double ddblMaxCoordX2 = default(double);
			object rvarValueDbl = ddblMaxCoordX2;
			object objectValue = RuntimeHelpers.GetObjectValue(dvarMaxCoordX);
			string nrstrErrMsg = "";
			object ddecMaxCoordX = default(object);
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecMaxCoordX, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			ddblMaxCoordX2 = Conversions.ToDouble(rvarValueDbl);
			double ddblMaxCoordY2 = default(double);
			rvarValueDbl = ddblMaxCoordY2;
			object objectValue2 = RuntimeHelpers.GetObjectValue(dvarMaxCoordY);
			nrstrErrMsg = "";
			object ddecMaxCoordY = default(object);
			bool num2 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecMaxCoordY, ref rvarValueDbl, objectValue2, ref nrstrErrMsg);
			ddblMaxCoordY2 = Conversions.ToDouble(rvarValueDbl);
			bool num3 = num && num2;
			double ddblMinCoordX2 = default(double);
			rvarValueDbl = ddblMinCoordX2;
			object objectValue3 = RuntimeHelpers.GetObjectValue(dvarMinCoordX);
			nrstrErrMsg = "";
			object ddecMinCoordX = default(object);
			bool num4 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecMinCoordX, ref rvarValueDbl, objectValue3, ref nrstrErrMsg);
			ddblMinCoordX2 = Conversions.ToDouble(rvarValueDbl);
			bool num5 = num3 && num4;
			double ddblMinCoordY2 = default(double);
			rvarValueDbl = ddblMinCoordY2;
			object objectValue4 = RuntimeHelpers.GetObjectValue(dvarMinCoordY);
			nrstrErrMsg = "";
			object ddecMinCoordY = default(object);
			bool num6 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecMinCoordY, ref rvarValueDbl, objectValue4, ref nrstrErrMsg);
			ddblMinCoordY2 = Conversions.ToDouble(rvarValueDbl);
			if (num5 && num6)
			{
				bool flag = false;
				if (ddblMaxCoordX2 >= ddblMinCoordX2 && ddblMaxCoordY2 >= ddblMinCoordY2)
				{
					mdblMaxCoordX = ddblMaxCoordX2;
					mdblMaxCoordY = ddblMaxCoordY2;
					mdblMinCoordX = ddblMinCoordX2;
					mdblMinCoordY = ddblMinCoordY2;
					mblnSized = true;
				}
			}
		}
	}
}
