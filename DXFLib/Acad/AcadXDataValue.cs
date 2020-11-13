using DXFLib.DXF;
using System.Runtime.CompilerServices;

namespace DXFLib.Acad
{
	public class AcadXDataValue : NodeObject
	{
		private const string cstrClassName = "AcadXDataValue";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngXDataIndex;

		private short mintXDataType;

		private object mvarXDataValue;

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

		internal short FriendLetXDataType
		{
			set
			{
				mintXDataType = value;
			}
		}

		internal object FriendLetXDataValue
		{
			set
			{
				mvarXDataValue = RuntimeHelpers.GetObjectValue(value);
			}
		}

		internal int FriendLetXDataIndex
		{
			set
			{
				mlngXDataIndex = value;
				base.FriendLetNodeText = "Erweiterungswert";
			}
		}

		internal string FriendGetXDataValuetring => hwpDxf_XData.BkDXFXData_ValueToString(RuntimeHelpers.GetObjectValue(mvarXDataValue));

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

		public short XDataType => mintXDataType;

		public object XDataValue => RuntimeHelpers.GetObjectValue(mvarXDataValue);

		public int XDataIndex => mlngXDataIndex;

		public AcadXDataValue()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 195;
			base.FriendLetNodeImageDisabledID = 196;
			base.FriendLetNodeName = "Erweiterungswert";
			base.FriendLetNodeText = "Erweiterungswert";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngXDataIndex = -1;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mintXDataType = hwpDxf_Vars.pintXDataType;
			mvarXDataValue = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pvarXDataValue);
		}

		~AcadXDataValue()
		{
			FriendQuit();
			//base.Finalize();
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
