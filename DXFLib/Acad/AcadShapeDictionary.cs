﻿using System;
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
	public class AcadShapeDictionary : NodeObject
	{
		private const string cstrClassName = "AcadShapeDictionary";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngEntityIndex;

		private double mdblOwnerID;

		private Dictionary<object, object> mobjDictEntities;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				AcadShape dobjAcadShape = default(AcadShape);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					double ddblCurObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null));
					AcadDatabase database = Database;
					AcadObject robjAcadObject = dobjAcadShape;
					string nrstrErrMsg = "";
					database.FriendObjectIdToObject(ddblCurObjectID, ref robjAcadObject, ref nrstrErrMsg);
					dobjAcadShape = (AcadShape)robjAcadObject;
					dobjAcadShape.FriendLetDatabaseIndex = value;
				}
				dobjAcadShape = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				AcadShape dobjAcadShape = default(AcadShape);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					double ddblCurObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null));
					AcadDatabase database = Database;
					AcadObject robjAcadObject = dobjAcadShape;
					string nrstrErrMsg = "";
					database.FriendObjectIdToObject(ddblCurObjectID, ref robjAcadObject, ref nrstrErrMsg);
					dobjAcadShape = (AcadShape)robjAcadObject;
					dobjAcadShape.FriendLetDocumentIndex = value;
				}
				dobjAcadShape = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				AcadShape dobjAcadShape = default(AcadShape);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					double ddblCurObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null));
					AcadDatabase database = Database;
					AcadObject robjAcadObject = dobjAcadShape;
					string nrstrErrMsg = "";
					database.FriendObjectIdToObject(ddblCurObjectID, ref robjAcadObject, ref nrstrErrMsg);
					dobjAcadShape = (AcadShape)robjAcadObject;
					dobjAcadShape.FriendLetApplicationIndex = value;
				}
				dobjAcadShape = null;
			}
		}

		internal double FriendLetOwnerID
		{
			set
			{
				mdblOwnerID = value;
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				AcadShape dobjAcadShape = default(AcadShape);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					double ddblCurObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null));
					AcadDatabase database = Database;
					AcadObject robjAcadObject = dobjAcadShape;
					string nrstrErrMsg = "";
					database.FriendObjectIdToObject(ddblCurObjectID, ref robjAcadObject, ref nrstrErrMsg);
					dobjAcadShape = (AcadShape)robjAcadObject;
					dobjAcadShape.FriendLetOwnerID = value;
				}
				dobjAcadShape = null;
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

		public int Count => mobjDictEntities.Count;

		public object ObjectIDs => RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));

		public double OwnerID => mdblOwnerID;

		public string OwnerHandle => hwpDxf_Functions.BkDXF_DblToHex(mdblOwnerID);

		public AcadShapeDictionary()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 259;
			base.FriendLetNodeImageDisabledID = 260;
			base.FriendLetNodeName = "Symbole";
			base.FriendLetNodeText = "B Symbole";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngEntityIndex = -1;
			mdblOwnerID = -1.0;
			mobjDictEntities = new Dictionary<object, object>();
		}

		~AcadShapeDictionary()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			AcadShape dobjAcadShape2 = default(AcadShape);
			AcadDatabase dobjAcadDatabase2;
			if (mblnOpened)
			{
				if (mobjDictEntities.Count > 0)
				{
					dobjAcadDatabase2 = hwpDxf_Vars.pobjAcadDatabases.FriendGetItem(mlngDatabaseIndex);
					if (dobjAcadDatabase2 != null)
					{
						object dvarObjectIDs = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
						int num = Information.LBound((Array)dvarObjectIDs);
						int num2 = Information.UBound((Array)dvarObjectIDs);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
						{
							AcadDatabase acadDatabase = dobjAcadDatabase2;
							double vdblObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarObjectIDs, new object[1]
							{
							dlngIdx
							}, null));
							AcadObject robjAcadObject = dobjAcadShape2;
							string nrstrErrMsg = "";
							bool flag = acadDatabase.FriendObjectIdToObject(vdblObjectID, ref robjAcadObject, ref nrstrErrMsg);
							dobjAcadShape2 = (AcadShape)robjAcadObject;
							if (flag)
							{
								dobjAcadShape2.FriendQuit();
								dobjAcadShape2 = null;
							}
						}
					}
				}
				base.FriendQuit();
				mobjDictEntities = null;
				mblnOpened = false;
			}
			dobjAcadShape2 = null;
			dobjAcadDatabase2 = null;
		}

		internal bool FriendReplaceObjectID(double vdblOldObjectID, double vdblNewObjectID)
		{
			if (mobjDictEntities.ContainsKey("K" + Conversions.ToString(vdblOldObjectID)) & !mobjDictEntities.ContainsKey("K" + Conversions.ToString(vdblNewObjectID)))
			{
				mobjDictEntities.Remove("K" + Conversions.ToString(vdblOldObjectID));
				mobjDictEntities.Add("K" + Conversions.ToString(vdblNewObjectID), vdblNewObjectID);
				return true;
			}
			bool FriendReplaceObjectID = default(bool);
			return FriendReplaceObjectID;
		}

		internal void FriendAdd(ref AcadShape robjAcadShape)
		{
			robjAcadShape.FriendLetNodeParentID = base.NodeID;
			checked
			{
				mlngEntityIndex++;
				AcadShape acadShape = robjAcadShape;
				mobjDictEntities.Add("K" + Conversions.ToString(acadShape.ObjectID), acadShape.ObjectID);
				acadShape = null;
			}
		}

		internal object FriendGetMinMaxCoords()
		{
			object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
			int num = Information.LBound((Array)dvarItems);
			int num2 = Information.UBound((Array)dvarItems);
			bool dblnFirst = default(bool);
			object dvarMaxCoordX = default(object);
			object dvarMaxCoordY = default(object);
			object dvarMinCoordX = default(object);
			object dvarMinCoordY = default(object);
			AcadShape dobjObject = default(AcadShape);
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				double ddblCurObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarItems, new object[1]
				{
				dlngIdx
				}, null));
				AcadDatabase database = Database;
				AcadObject robjAcadObject = dobjObject;
				string nrstrErrMsg = "";
				database.FriendObjectIdToObject(ddblCurObjectID, ref robjAcadObject, ref nrstrErrMsg);
				dobjObject = (AcadShape)robjAcadObject;
				object dvarMinMaxCoords = RuntimeHelpers.GetObjectValue(dobjObject.MinMaxCoords);
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
			object FriendGetMinMaxCoords = (!dblnFirst) ? null : new object[4]
			{
			dvarMaxCoordX,
			dvarMaxCoordY,
			dvarMinCoordX,
			dvarMinCoordY
			};
			dobjObject = null;
			return FriendGetMinMaxCoords;
		}

		public bool Exists(object vvarValue)
		{
			if (mobjDictEntities.Count > 0)
			{
				switch (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)))
				{
					case VariantType.Double:
						{
							double ddblObjectID = Conversions.ToDouble(vvarValue);
							return mobjDictEntities.ContainsKey("K" + Conversions.ToString(ddblObjectID));
						}
					case VariantType.String:
						{
							string vstrHexNum = Conversions.ToString(vvarValue);
							int nrlngErrNum = 0;
							string nrstrErrMsg = "";
							if (hwpDxf_Functions.BkDXF_ValidHexNum(vstrHexNum, ref nrlngErrNum, ref nrstrErrMsg))
							{
								double ddblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(vvarValue));
								return mobjDictEntities.ContainsKey("K" + Conversions.ToString(ddblObjectID));
							}
							break;
						}
					case VariantType.Short:
					case VariantType.Integer:
						{
							int dlngIndex = Conversions.ToInteger(vvarValue);
							return (dlngIndex >= 0) & (dlngIndex < mobjDictEntities.Count);
						}
				}
			}
			bool Exists = default(bool);
			return Exists;
		}

		public AcadShape Item(object vvarValue)
		{
			if (mobjDictEntities.Count > 0)
			{
				AcadDatabase dobjAcadDatabase = hwpDxf_Vars.pobjAcadDatabases.FriendGetItem(mlngDatabaseIndex);
				if (dobjAcadDatabase != null)
				{
					AcadShape dobjAcadShape4 = default(AcadShape);
					switch (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)))
					{
						case VariantType.Double:
							{
								double ddblObjectID2 = Conversions.ToDouble(vvarValue);
								if (mobjDictEntities.ContainsKey("K" + Conversions.ToString(ddblObjectID2)))
								{
									double ddblCurObjectID2 = Conversions.ToDouble(mobjDictEntities["K" + Conversions.ToString(ddblObjectID2)]);
									double vdblObjectID3 = ddblCurObjectID2;
									AcadObject robjAcadObject = dobjAcadShape4;
									string nrstrErrMsg = "";
									bool flag = dobjAcadDatabase.FriendObjectIdToObject(vdblObjectID3, ref robjAcadObject, ref nrstrErrMsg);
									dobjAcadShape4 = (AcadShape)robjAcadObject;
									if (flag)
									{
										return dobjAcadShape4;
									}
								}
								break;
							}
						case VariantType.String:
							{
								string vstrHexNum = Conversions.ToString(vvarValue);
								int nrlngErrNum = 0;
								string nrstrErrMsg = "";
								if (!hwpDxf_Functions.BkDXF_ValidHexNum(vstrHexNum, ref nrlngErrNum, ref nrstrErrMsg))
								{
									break;
								}
								double ddblObjectID2 = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(vvarValue));
								if (mobjDictEntities.ContainsKey("K" + Conversions.ToString(ddblObjectID2)))
								{
									double ddblCurObjectID2 = Conversions.ToDouble(mobjDictEntities["K" + Conversions.ToString(ddblObjectID2)]);
									double vdblObjectID2 = ddblCurObjectID2;
									AcadObject robjAcadObject = dobjAcadShape4;
									nrstrErrMsg = "";
									bool flag = dobjAcadDatabase.FriendObjectIdToObject(vdblObjectID2, ref robjAcadObject, ref nrstrErrMsg);
									dobjAcadShape4 = (AcadShape)robjAcadObject;
									if (flag)
									{
										return dobjAcadShape4;
									}
								}
								break;
							}
						case VariantType.Short:
						case VariantType.Integer:
							{
								int dlngIndex = Conversions.ToInteger(vvarValue);
								if ((dlngIndex >= 0) & (dlngIndex < mobjDictEntities.Count))
								{
									object dvarObjectIDs = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictEntities.Values));
									double vdblObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarObjectIDs, new object[1]
									{
							dlngIndex
									}, null));
									AcadObject robjAcadObject = dobjAcadShape4;
									string nrstrErrMsg = "";
									bool flag = dobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref robjAcadObject, ref nrstrErrMsg);
									dobjAcadShape4 = (AcadShape)robjAcadObject;
									if (flag)
									{
										return dobjAcadShape4;
									}
								}
								break;
							}
					}
				}
			}
			AcadShape Item = default(AcadShape);
			return Item;
		}
	}

}
