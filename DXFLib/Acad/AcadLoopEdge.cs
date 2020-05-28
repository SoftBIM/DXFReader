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
    public class AcadLoopEdge : NodeObject
	{
		private const string cstrClassName = "AcadLoopEdge";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private Enums.AcLoopEdgeType mnumEdgeType;

		private object mobjAcGeObject;

		private AcGeLinSeg2d mobjAcGeLinSeg2d;

		private AcGeCircArc2d mobjAcGeCircArc2d;

		private AcGeEllipArc2d mobjAcGeEllipArc2d;

		private AcGeNurbCurve2d mobjAcGeNurbCurve2d;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
			}
		}

		internal int FriendLetIndex
		{
			set
			{
				mlngIndex = value;
			}
		}

		internal Enums.AcLoopEdgeType FriendLetEdgeType
		{
			set
			{
				mnumEdgeType = value;
			}
		}

		internal string FriendGetEdgeTypeString
		{
			get
			{
				switch (mnumEdgeType)
				{
					case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeUndefined:
						return "Nicht definiert";
					case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeLine:
						return "Linie";
					case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeCirArc:
						return "Kreisbogen";
					case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeEllArc:
						return "Ellipsenbogen";
					case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeSpline:
						return "Spline";
					default:
						return "Unbekannt";
				}
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

		internal object EdgeObject
		{
			get
			{
				if (mobjAcGeObject != null)
				{
					return RuntimeHelpers.GetObjectValue(mobjAcGeObject);
				}
				object EdgeObject = default(object);
				return EdgeObject;
			}
		}

		public int Index => mlngIndex;

		public object EdgeType => mnumEdgeType;

		public AcadLoopEdge()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 285;
			base.FriendLetNodeImageDisabledID = 286;
			base.FriendLetNodeName = "Schraffurkontur-Kante";
			base.FriendLetNodeText = "Schraffurkontur-Kante";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mnumEdgeType = hwpDxf_Vars.pnumEdgeType;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
		}

		~AcadLoopEdge()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				if (mobjAcGeLinSeg2d != null)
				{
					mobjAcGeLinSeg2d.FriendQuit();
				}
				if (mobjAcGeCircArc2d != null)
				{
					mobjAcGeCircArc2d.FriendQuit();
				}
				if (mobjAcGeEllipArc2d != null)
				{
					mobjAcGeEllipArc2d.FriendQuit();
				}
				if (mobjAcGeNurbCurve2d != null)
				{
					mobjAcGeNurbCurve2d.FriendQuit();
				}
				base.FriendQuit();
				mobjAcGeLinSeg2d = null;
				mobjAcGeCircArc2d = null;
				mobjAcGeEllipArc2d = null;
				mobjAcGeNurbCurve2d = null;
				mobjAcGeObject = null;
				mblnOpened = false;
			}
		}

		internal object FriendAddEdgeObject()
		{
			switch (mnumEdgeType)
			{
				case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeLine:
					return InternAddAcGeLinSeg2d();
				case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeCirArc:
					return InternAddAcGeCircArc2d();
				case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeEllArc:
					return InternAddAcGeEllipArc2d();
				case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeSpline:
					return InternAddAcGeNurbCurve2d();
				default:
					{
						object FriendAddEdgeObject = default(object);
						return FriendAddEdgeObject;
					}
			}
		}

		private AcGeLinSeg2d InternAddAcGeLinSeg2d()
		{
			if (mobjAcGeObject == null)
			{
				mobjAcGeLinSeg2d = new AcGeLinSeg2d();
				mobjAcGeObject = mobjAcGeLinSeg2d;
			}
			return mobjAcGeLinSeg2d;
		}

		private AcGeCircArc2d InternAddAcGeCircArc2d()
		{
			if (mobjAcGeObject == null)
			{
				mobjAcGeCircArc2d = new AcGeCircArc2d();
				mobjAcGeObject = mobjAcGeCircArc2d;
			}
			return mobjAcGeCircArc2d;
		}

		private AcGeEllipArc2d InternAddAcGeEllipArc2d()
		{
			if (mobjAcGeObject == null)
			{
				mobjAcGeEllipArc2d = new AcGeEllipArc2d();
				mobjAcGeObject = mobjAcGeEllipArc2d;
			}
			return mobjAcGeEllipArc2d;
		}

		private AcGeNurbCurve2d InternAddAcGeNurbCurve2d()
		{
			if (mobjAcGeObject == null)
			{
				mobjAcGeNurbCurve2d = new AcGeNurbCurve2d();
				mobjAcGeObject = mobjAcGeNurbCurve2d;
			}
			return mobjAcGeNurbCurve2d;
		}
	}

}
