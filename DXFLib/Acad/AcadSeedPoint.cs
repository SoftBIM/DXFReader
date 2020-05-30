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
	public class AcadSeedPoint : NodeObject
	{
		private const string cstrClassName = "AcadSeedPoint";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private object mdecCoordX;

		private double mdblCoordX;

		private object mdecCoordY;

		private double mdblCoordY;

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

		internal object FriendLetCoordX
		{
			set
			{
				ref object rvarValueDec = ref mdecCoordX;
				ref double reference = ref mdblCoordX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetCoordY
		{
			set
			{
				ref object rvarValueDec = ref mdecCoordY;
				ref double reference = ref mdblCoordY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
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

		public object CoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordX), mdblCoordX));

		public object CoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCoordY), mdblCoordY));

		public AcadSeedPoint()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 281;
			base.FriendLetNodeImageDisabledID = 282;
			base.FriendLetNodeName = "Schraffurkontur-Saatpunkt";
			base.FriendLetNodeText = "Schraffurkontur-Saatpunkt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCoordX = hwpDxf_Vars.pdblCoordX;
			mdblCoordY = hwpDxf_Vars.pdblCoordY;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
		}

		~AcadSeedPoint()
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
