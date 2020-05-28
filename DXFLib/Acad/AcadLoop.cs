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
	public class AcadLoop : NodeObject
	{
		private const string cstrClassName = "AcadLoop";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private Enums.AcLoopType mnumLoopType;

		private bool mblnIsDefault;

		private bool mblnIsExternal;

		private bool mblnIsPolyline;

		private bool mblnIsDerived;

		private bool mblnIsTextbox;

		private bool mblnIsOutermost;

		private bool mblnFriendLetFlags;

		private AcadLoopEdges mobjAcadLoopEdges;

		private AcGePolyline2d mobjAcGePolyline2d;

		private Dictionary<object, object> mobjDictAssocObjects;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				if (mobjAcadLoopEdges != null)
				{
					mobjAcadLoopEdges.FriendLetDatabaseIndex = value;
				}
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				if (mobjAcadLoopEdges != null)
				{
					mobjAcadLoopEdges.FriendLetDocumentIndex = value;
				}
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				if (mobjAcadLoopEdges != null)
				{
					mobjAcadLoopEdges.FriendLetApplicationIndex = value;
				}
			}
		}

		internal int FriendLetIndex
		{
			set
			{
				mlngIndex = value;
			}
		}

		internal Enums.AcLoopType FriendLetLoopType
		{
			set
			{
				mblnFriendLetFlags = true;
				mnumLoopType = value;
				FriendLetIsDefault = (value == Enums.AcLoopType.acHatchLoopTypeDefault);
				FriendLetIsExternal = ((Enums.AcLoopType.acHatchLoopTypeExternal & value) == Enums.AcLoopType.acHatchLoopTypeExternal);
				FriendLetIsPolyline = ((Enums.AcLoopType.acHatchLoopTypePolyline & value) == Enums.AcLoopType.acHatchLoopTypePolyline);
				FriendLetIsDerived = ((Enums.AcLoopType.acHatchLoopTypeDerived & value) == Enums.AcLoopType.acHatchLoopTypeDerived);
				FriendLetIsTextbox = ((Enums.AcLoopType.acHatchLoopTypeTextbox & value) == Enums.AcLoopType.acHatchLoopTypeTextbox);
				FriendLetIsOutermost = ((Enums.AcLoopType.acHatchLoopTypeOutermost & value) == Enums.AcLoopType.acHatchLoopTypeOutermost);
				mblnFriendLetFlags = false;
			}
		}

		internal bool FriendLetIsDefault
		{
			set
			{
				mblnIsDefault = value;
				InternCalcLoopType();
			}
		}

		internal bool FriendLetIsExternal
		{
			set
			{
				mblnIsExternal = value;
				InternCalcLoopType();
			}
		}

		internal bool FriendLetIsPolyline
		{
			set
			{
				mblnIsPolyline = value;
				InternCalcLoopType();
			}
		}

		internal bool FriendLetIsDerived
		{
			set
			{
				mblnIsDerived = value;
				InternCalcLoopType();
			}
		}

		internal bool FriendLetIsTextbox
		{
			set
			{
				mblnIsTextbox = value;
				InternCalcLoopType();
			}
		}

		internal bool FriendLetIsOutermost
		{
			set
			{
				mblnIsOutermost = value;
				InternCalcLoopType();
			}
		}

		internal object FriendSetAssocObjects
		{
			set
			{
				if (value == null)
				{
					mobjDictAssocObjects = null;
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(value, null, "Count", new object[0], null, null, null), 0, TextCompare: false))
				{
					mobjDictAssocObjects = null;
				}
				else
				{
					mobjDictAssocObjects = (Dictionary<object, object>)value;
				}
			}
		}

		internal string FriendGetAssocObjectsString => hwpDxf_Functions.BkDXF_StringDict(mobjDictAssocObjects);

		public AcadLoopEdges Edges
		{
			get
			{
				if (mobjAcadLoopEdges != null)
				{
					return mobjAcadLoopEdges;
				}
				AcadLoopEdges Edges = default(AcadLoopEdges);
				return Edges;
			}
		}

		public AcGePolyline2d Polyline
		{
			get
			{
				if (mobjAcGePolyline2d != null)
				{
					return mobjAcGePolyline2d;
				}
				AcGePolyline2d Polyline = default(AcGePolyline2d);
				return Polyline;
			}
		}

		public AcadDatabase Database
		{
			get
			{
				if (mlngDatabaseIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex);
				}
				AcadDatabase Database = default(AcadDatabase);
				return Database;
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
			}
		}

		public AcadApplication Application
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public int Index => mlngIndex;

		public int NumberOfEdges
		{
			get
			{
				if (mobjAcadLoopEdges == null)
				{
					return 0;
				}
				return mobjAcadLoopEdges.Count;
			}
		}

		public int NumberOfAssocObjects
		{
			get
			{
				if (mobjDictAssocObjects == null)
				{
					return 0;
				}
				return mobjDictAssocObjects.Count;
			}
		}

		public Enums.AcLoopType LoopType => mnumLoopType;

		public bool IsDefault => mblnIsDefault;

		public bool IsExternal => mblnIsExternal;

		public bool IsPolyline => mblnIsPolyline;

		public bool IsDerived => mblnIsDerived;

		public bool IsTextbox => mblnIsTextbox;

		public bool IsOutermost => mblnIsOutermost;

		public object AssocObjects => mobjDictAssocObjects;

		public AcadLoop()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 277;
			base.FriendLetNodeImageDisabledID = 278;
			base.FriendLetNodeName = "Schraffurkontur";
			base.FriendLetNodeText = "Schraffurkontur";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mnumLoopType = hwpDxf_Vars.pnumLoopType;
			mblnIsDefault = hwpDxf_Vars.pblnIsDefault;
			mblnIsExternal = hwpDxf_Vars.pblnIsExternal;
			mblnIsPolyline = hwpDxf_Vars.pblnIsPolyline;
			mblnIsDerived = hwpDxf_Vars.pblnIsDerived;
			mblnIsTextbox = hwpDxf_Vars.pblnIsTextbox;
			mblnIsOutermost = hwpDxf_Vars.pblnIsOutermost;
			mblnFriendLetFlags = false;
			InternCalcLoopType();
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
		}

		~AcadLoop()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				if (mobjAcadLoopEdges != null)
				{
					mobjAcadLoopEdges.FriendQuit();
				}
				if (mobjAcGePolyline2d != null)
				{
					mobjAcGePolyline2d.FriendQuit();
				}
				base.FriendQuit();
				mobjAcadLoopEdges = null;
				mobjAcGePolyline2d = null;
				mobjDictAssocObjects = null;
				mblnOpened = false;
			}
		}

		internal AcadLoopEdges FriendAddLoopEdges()
		{
			return InternAddLoopEdges();
		}

		internal AcGePolyline2d FriendAddAcGePolyline2d()
		{
			return InternAddAcGePolyline2d();
		}

		internal void FriendClearAssocObjects()
		{
			mobjDictAssocObjects = null;
		}

		internal bool FriendAddAssocObjectsID(double vdblObjectID, int vlngCode)
		{
			return hwpDxf_Functions.BkDXF_AddIDToDict(vdblObjectID, vlngCode, ref mobjDictAssocObjects);
		}

		internal bool FriendRemoveAssocObjectsID(double vdblObjectID)
		{
			return hwpDxf_Functions.BkDXF_RemoveIDFromDict(vdblObjectID, ref mobjDictAssocObjects);
		}

		private void InternCalcLoopType()
		{
			if (!mblnFriendLetFlags)
			{
				if (IsDefault)
				{
					mblnIsExternal = false;
					mblnIsPolyline = false;
					mblnIsDerived = false;
					mblnIsTextbox = false;
					mblnIsOutermost = false;
				}
				else
				{
					mnumLoopType = (Enums.AcLoopType)Conversions.ToInteger(Interaction.IIf(IsExternal, Enums.AcLoopType.acHatchLoopTypeExternal, 0));
					mnumLoopType = (Enums.AcLoopType)Conversions.ToInteger(Operators.OrObject(mnumLoopType, Interaction.IIf(IsPolyline, Enums.AcLoopType.acHatchLoopTypePolyline, 0)));
					mnumLoopType = (Enums.AcLoopType)Conversions.ToInteger(Operators.OrObject(mnumLoopType, Interaction.IIf(IsDerived, Enums.AcLoopType.acHatchLoopTypeDerived, 0)));
					mnumLoopType = (Enums.AcLoopType)Conversions.ToInteger(Operators.OrObject(mnumLoopType, Interaction.IIf(IsTextbox, Enums.AcLoopType.acHatchLoopTypeTextbox, 0)));
					mnumLoopType = (Enums.AcLoopType)Conversions.ToInteger(Operators.OrObject(mnumLoopType, Interaction.IIf(IsOutermost, Enums.AcLoopType.acHatchLoopTypeOutermost, 0)));
				}
			}
		}

		private AcadLoopEdges InternAddLoopEdges()
		{
			if (mobjAcadLoopEdges == null)
			{
				mobjAcadLoopEdges = new AcadLoopEdges();
				mobjAcadLoopEdges.FriendLetNodeParentID = base.NodeID;
				mobjAcadLoopEdges.FriendLetApplicationIndex = FriendGetApplicationIndex;
				mobjAcadLoopEdges.FriendLetDocumentIndex = FriendGetDocumentIndex;
				mobjAcadLoopEdges.FriendLetDatabaseIndex = FriendGetDatabaseIndex;
			}
			return mobjAcadLoopEdges;
		}

		private AcGePolyline2d InternAddAcGePolyline2d()
		{
			if (mobjAcGePolyline2d == null)
			{
				mobjAcGePolyline2d = new AcGePolyline2d();
			}
			return mobjAcGePolyline2d;
		}
	}

}
