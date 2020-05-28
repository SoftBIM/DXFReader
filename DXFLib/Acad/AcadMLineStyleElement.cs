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
	public class AcadMLineStyleElement : NodeObject
	{
		private const string cstrClassName = "AcadMLineStyleElement";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private object mdecOffset;

		private double mdblOffset;

		private Enums.AcColor mnumColor;

		private double mdblLinetypeObjectID;

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

		public object Offset
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecOffset), mdblOffset));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecOffset;
				ref double reference = ref mdblOffset;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMLineStyleElement", dstrErrMsg);
				}
			}
		}

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
				string Linetype = default(string);
				AcadLineType dobjAcadLinetype2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (mdblLinetypeObjectID > 0.0)
				{
					AcadDatabase database = Database;
					double vdblObjectID = mdblLinetypeObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbLinetypeTableRecord", TextCompare: false) == 0)
					{
						dobjAcadLinetype2 = (AcadLineType)dobjAcadObject2;
						Linetype = dobjAcadLinetype2.Name;
					}
				}
				else
				{
					Linetype = hwpDxf_Vars.pstrEntityLinetype;
				}
				dobjAcadLinetype2 = null;
				dobjAcadObject2 = null;
				return Linetype;
			}
			set
			{
				AcadLineType dobjAcadLinetype2 = (AcadLineType)Database.Linetypes.FriendGetItem(hwpDxf_Functions.BkDXF_LinetypeString(value));
				if (dobjAcadLinetype2 != null)
				{
					mdblLinetypeObjectID = dobjAcadLinetype2.ObjectID;
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint("AcadMLineStyleElement: Linientyp '" + value + "' konnte nicht gefunden werden.");
				}
				dobjAcadLinetype2 = null;
			}
		}

		public AcadMLineStyleElement()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 221;
			base.FriendLetNodeImageDisabledID = 222;
			base.FriendLetNodeName = "Multilinien-Stil-Element";
			base.FriendLetNodeText = "Multilinien-Stil-Element";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblOffset = hwpDxf_Vars.pdblOffset;
			mnumColor = hwpDxf_Vars.pnumEntityColor;
			mdblLinetypeObjectID = -1.0;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
		}

		~AcadMLineStyleElement()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}
	}

}
