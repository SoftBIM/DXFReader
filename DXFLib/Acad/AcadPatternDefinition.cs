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
   public class AcadPatternDefinition : NodeObject
	{
		private const string cstrClassName = "AcadPatternDefinition";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private object mdecAngleDegree;

		private double mdblAngleDegree;

		private object mdecBaseX;

		private double mdblBaseX;

		private object mdecBaseY;

		private double mdblBaseY;

		private object mdecOffsetX;

		private double mdblOffsetX;

		private object mdecOffsetY;

		private double mdblOffsetY;

		private AcadPatternDefDashes mobjAcadPatternDefDashes;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				mobjAcadPatternDefDashes.FriendLetDatabaseIndex = value;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				mobjAcadPatternDefDashes.FriendLetDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				mobjAcadPatternDefDashes.FriendLetApplicationIndex = value;
			}
		}

		internal int FriendLetIndex
		{
			set
			{
				mlngIndex = value;
			}
		}

		internal object FriendLetAngleDegree
		{
			set
			{
				ref object rvarValueDec = ref mdecAngleDegree;
				ref double reference = ref mdblAngleDegree;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetAngle
		{
			set
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					bool flag = false;
					mdblAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		internal object FriendLetBaseX
		{
			set
			{
				ref object rvarValueDec = ref mdecBaseX;
				ref double reference = ref mdblBaseX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetBaseY
		{
			set
			{
				ref object rvarValueDec = ref mdecBaseY;
				ref double reference = ref mdblBaseY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetOffsetX
		{
			set
			{
				ref object rvarValueDec = ref mdecOffsetX;
				ref double reference = ref mdblOffsetX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetOffsetY
		{
			set
			{
				ref object rvarValueDec = ref mdecOffsetY;
				ref double reference = ref mdblOffsetY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		public AcadPatternDefDashes Dashes => mobjAcadPatternDefDashes;

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

		public int NumberOfDashes => mobjAcadPatternDefDashes.Count;

		public object AngleDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecAngleDegree), mdblAngleDegree));

		public object Angle => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(AngleDegree)));

		public object BaseX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecBaseX), mdblBaseX));

		public object BaseY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecBaseY), mdblBaseY));

		public object OffsetX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecOffsetX), mdblOffsetX));

		public object OffsetY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecOffsetY), mdblOffsetY));

		public AcadPatternDefinition()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 269;
			base.FriendLetNodeImageDisabledID = 270;
			base.FriendLetNodeName = "Schraffurmuster-Definitionslinie";
			base.FriendLetNodeText = "Schraffurmuster-Definitionslinie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblAngleDegree = hwpDxf_Vars.pdblAngleDegree;
			mdblBaseX = hwpDxf_Vars.pdblBaseX;
			mdblBaseY = hwpDxf_Vars.pdblBaseY;
			mdblOffsetX = hwpDxf_Vars.pdblOffsetX;
			mdblOffsetY = hwpDxf_Vars.pdblOffsetY;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mobjAcadPatternDefDashes = new AcadPatternDefDashes();
			mobjAcadPatternDefDashes.FriendLetNodeParentID = base.NodeID;
			mobjAcadPatternDefDashes.FriendLetApplicationIndex = FriendGetApplicationIndex;
			mobjAcadPatternDefDashes.FriendLetDocumentIndex = FriendGetDocumentIndex;
			mobjAcadPatternDefDashes.FriendLetDatabaseIndex = FriendGetDatabaseIndex;
		}

		~AcadPatternDefinition()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadPatternDefDashes.FriendQuit();
				base.FriendQuit();
				mobjAcadPatternDefDashes = null;
				mblnOpened = false;
			}
		}
	}

}
