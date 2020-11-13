using DXFLib.Basic;
using DXFLib.DXF;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DXFLib.Acad
{
	public class AcadObject : NodeObject
	{
		private const string cstrClassName = "AcadObject";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private string mstrDXFName;

		private double mdblObjectID;

		private string mstrObjectName;

		private double mdblOwnerID;

		private AcadXData mobjAcadXData;

		private Dictionary<object, object> mobjDictReactors;

		private Dictionary<object, object> mobjDictXDictionary;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal virtual int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				if (mobjAcadXData != null)
				{
					mobjAcadXData.FriendLetDatabaseIndex = value;
				}
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal virtual int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				if (mobjAcadXData != null)
				{
					mobjAcadXData.FriendLetDocumentIndex = value;
				}
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal virtual int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				if (mobjAcadXData != null)
				{
					mobjAcadXData.FriendLetApplicationIndex = value;
				}
			}
		}

		internal string FriendLetDXFName
		{
			set
			{
				mstrDXFName = value;
			}
		}

		internal string FriendLetObjectName
		{
			set
			{
				mstrObjectName = value;
			}
		}

		internal double FriendLetOwnerID
		{
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (mdblOwnerID != value)
				{
					if (mdblOwnerID != -1.0 || value == -1.0)
					{
						Information.Err().Raise(50000, "AcadObject", "Objekt-ID (Eigentümer) '" + Conversions.ToString(value) + "' darf nicht geändert werden.");
					}
					else if (value <= -1.0)
					{
						Information.Err().Raise(50000, "AcadObject", "Objekt-ID (Eigentümer) '" + Conversions.ToString(value) + "' ist ungültig.");
					}
					else if (value == 0.0)
					{
						mdblOwnerID = value;
					}
					else if (!Database.FriendObjectIDExist(value))
					{
						Information.Err().Raise(50000, "AcadObject", "Objekt-ID (Eigentümer) '" + Conversions.ToString(value) + "' ist nicht vergeben.");
					}
					else
					{
						mdblOwnerID = value;
					}
				}
			}
		}

		internal object FriendSetDictReactors
		{
			set
			{
				if (value == null)
				{
					mobjDictReactors = null;
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(value, null, "Count", new object[0], null, null, null), 0, TextCompare: false))
				{
					mobjDictReactors = null;
				}
				else
				{
					mobjDictReactors = (Dictionary<object, object>)value;
				}
			}
		}

		internal object FriendSetDictXDictionary
		{
			set
			{
				if (value == null)
				{
					mobjDictXDictionary = null;
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(value, null, "Count", new object[0], null, null, null), 0, TextCompare: false))
				{
					mobjDictXDictionary = null;
				}
				else
				{
					mobjDictXDictionary = (Dictionary<object, object>)value;
				}
			}
		}

		public object DictReactors => mobjDictReactors;

		public object DictXDictionaries => mobjDictXDictionary;

		internal string FriendGetReactorsString => hwpDxf_Functions.BkDXF_StringDict(mobjDictReactors);

		internal string FriendGetXDictionaryString => hwpDxf_Functions.BkDXF_StringDict(mobjDictXDictionary);

		internal new int FriendLetNodeID
		{
			set
			{
				base.FriendLetNodeID = value;
				if (mobjAcadXData != null)
				{
					mobjAcadXData.FriendLetNodeParentID = value;
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

		public string DXFName => mstrDXFName;

		public string Handle => hwpDxf_Functions.BkDXF_DblToHex(mdblObjectID);

		public bool HasExtensionDictionary => mobjDictXDictionary != null;

		public bool HasReactors => mobjDictReactors != null;

		public double ObjectID => mdblObjectID;

		public string ObjectName => mstrObjectName;

		public double OwnerID => mdblOwnerID;

		public string OwnerHandle => hwpDxf_Functions.BkDXF_DblToHex(mdblOwnerID);

		public AcadObject()
		{
			mblnOpened = true;
			base.FriendLetNodeID = -1;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mstrDXFName = "OBJECT";
			mdblObjectID = -1.0;
			mstrObjectName = "AcDbObject";
			mdblOwnerID = -1.0;
		}

		~AcadObject()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (!mblnOpened)
			{
				return;
			}
			if (mobjAcadXData != null)
			{
				mobjAcadXData.FriendQuit();
			}
			if (mdblObjectID > 0.0 && mlngDatabaseIndex > -1)
			{
				if (hwpDxf_Vars.pobjAcadDatabases.Opened)
				{
					AcadDatabase dobjAcadDatabase = hwpDxf_Vars.pobjAcadDatabases.FriendGetItem(mlngDatabaseIndex);
					if (dobjAcadDatabase != null)
					{
						double vdblObjectID = mdblObjectID;
						string nrstrErrMsg = "";
						AcadObject dobjAcadObject = default(AcadObject);
						if (dobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject, ref nrstrErrMsg) && Operators.CompareString(mstrObjectName, dobjAcadObject.ObjectName, TextCompare: false) == 0)
						{
							dobjAcadDatabase.FriendRemoveObjectID(mdblObjectID);
						}
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint("AcadObject, FriendQuit 2, Keine Datenbank: " + mstrObjectName);
					}
				}
				else
				{
					hwpDxf_Functions.BkDXF_DebugPrint("AcadObject, FriendQuit 1, Keine Datenbanken: " + mstrObjectName);
				}
			}
			base.FriendQuit();
			mdblObjectID = -1.0;
			mdblOwnerID = -1.0;
			mobjAcadXData = null;
			mobjDictReactors = null;
			mobjDictXDictionary = null;
			mblnOpened = false;
		}

		internal void FriendClearReactors()
		{
			mobjDictReactors = null;
		}

		internal void FriendClearXDictionary()
		{
			mobjDictXDictionary = null;
		}

		internal bool FriendAddReactorsID(double vdblObjectID, int vlngCode)
		{
			return hwpDxf_Functions.BkDXF_AddIDToDict(vdblObjectID, vlngCode, ref mobjDictReactors);
		}

		internal bool FriendAddXDictionaryID(double vdblObjectID, int vlngCode)
		{
			return hwpDxf_Functions.BkDXF_AddIDToDict(vdblObjectID, vlngCode, ref mobjDictXDictionary);
		}

		internal bool FriendRemoveReactorsID(double vdblObjectID)
		{
			return hwpDxf_Functions.BkDXF_RemoveIDFromDict(vdblObjectID, ref mobjDictReactors);
		}

		internal bool FriendRemoveXDictionaryID(double vdblObjectID)
		{
			return hwpDxf_Functions.BkDXF_RemoveIDFromDict(vdblObjectID, ref mobjDictXDictionary);
		}

		internal bool FriendSetHandle(ref AcadObject robjAcadObject, string vstrHandle, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			double ddblNewObjectID = hwpDxf_Functions.BkDXF_HexToDbl(vstrHandle);
			if (FriendSetObjectID(ddblNewObjectID, ref robjAcadObject, ref nrstrErrMsg))
			{
				return true;
			}
			nrstrErrMsg = "Die Referenz ist ungültig.\n" + nrstrErrMsg;
			bool FriendSetHandle = default(bool);
			return FriendSetHandle;
		}

		internal bool FriendSetObjectID(double vdblObjectID, ref AcadObject nrobjAcadObject = null, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			AcadDatabase dobjAcadDatabase = Database;
			if (mdblObjectID == vdblObjectID)
			{
				return true;
			}
			if (Operators.CompareString(mstrObjectName, nrobjAcadObject.ObjectName, TextCompare: false) != 0)
			{
				mdblObjectID = vdblObjectID;
				return true;
			}
			if (mdblObjectID != -1.0 || vdblObjectID <= -1.0)
			{
				nrstrErrMsg = "Die Object-ID darf nicht geändert werden.";
				hwpDxf_Functions.BkDXF_DebugPrint(mstrObjectName + ": " + nrstrErrMsg);
			}
			else
			{
				if (dobjAcadDatabase.FriendValidObjectID(vdblObjectID, ref nrstrErrMsg))
				{
					AcadObject robjAcadObject = (AcadObject)Interaction.IIf(nrobjAcadObject == null, this, nrobjAcadObject);
					dobjAcadDatabase.FriendAddObjectID(vdblObjectID, ref robjAcadObject);
					mdblObjectID = vdblObjectID;
					if (mobjAcadXData != null)
					{
						mobjAcadXData.FriendLetOwnerID = mdblObjectID;
					}
					return true;
				}
				hwpDxf_Functions.BkDXF_DebugPrint("2 " + mstrObjectName + ": " + nrstrErrMsg + ", " + Versioned.TypeName(nrobjAcadObject) + ", " + nrobjAcadObject.ObjectName);
			}
			bool FriendSetObjectID = default(bool);
			return FriendSetObjectID;
		}

		public void Delete()
		{
		}

		public void EraseAll()
		{
		}

		public AcadDictionary GetExtensionDictionary()
		{
			AcadDictionary GetExtensionDictionary = default(AcadDictionary);
			return GetExtensionDictionary;
		}

		public void GetXData(string vstrAppName, ref object rvarXDataType, ref object rvarXDataValue)
		{
			rvarXDataType = null;
			rvarXDataValue = null;
			if (mobjAcadXData != null)
			{
				mobjAcadXData.GetXData(vstrAppName, ref rvarXDataType, ref rvarXDataValue);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetXData(object vvarXDataType, object vvarXDataValue)
		{
			if (Operators.CompareString(mstrObjectName, "AcDbRegAppTable", TextCompare: false) == 0)
			{
				return;
			}
			if (vvarXDataType == null && vvarXDataValue == null)
			{
				if (mobjAcadXData != null)
				{
					mobjAcadXData.FriendQuit();
					mobjAcadXData = null;
				}
				return;
			}
			if (mobjAcadXData == null)
			{
				mobjAcadXData = new AcadXData();
				mobjAcadXData.FriendLetNodeParentID = base.NodeID;
				mobjAcadXData.FriendLetApplicationIndex = mlngApplicationIndex;
				mobjAcadXData.FriendLetDocumentIndex = mlngDocumentIndex;
				mobjAcadXData.FriendLetDatabaseIndex = mlngDatabaseIndex;
				mobjAcadXData.FriendLetOwnerID = mdblObjectID;
			}
			try
			{
				mobjAcadXData.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				string dstrErrMsg = ExceptionHelper.GetExceptionMessage(ex);
				if (mobjAcadXData.Count == 0)
				{
					mobjAcadXData.FriendQuit();
					mobjAcadXData = null;
				}
				Information.Err().Raise(50000, "AcadObject", dstrErrMsg);
				ProjectData.ClearProjectError();
				return;
			}
			if (mobjAcadXData.Count == 0)
			{
				mobjAcadXData.FriendQuit();
				mobjAcadXData = null;
			}
		}
	}
}
