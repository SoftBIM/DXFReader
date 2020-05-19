using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class TableDimStyle
	{
		private const string cstrClassName = "TableDimStyle";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadDimStyles mobjAcadDimStyles;

		internal int TblBeg
		{
			get
			{
				return mlngTblBeg;
			}
			set
			{
				mlngTblBeg = value;
			}
		}

		internal int TblEnd
		{
			get
			{
				return mlngTblEnd;
			}
			set
			{
				mlngTblEnd = value;
			}
		}

		public string Name => "DIMSTYLE";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableDimStyle()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableDimStyle()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjAcadDimStyles = null;
				mobjAcadDatabase = null;
				mblnOpened = false;
			}
		}

		public void Init(ref AcadDatabase robjAcadDatabase, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		{
			mobjAcadDatabase = robjAcadDatabase;
			mobjDictReadCodes = robjDictReadCodes;
			mobjDictReadValues = robjDictReadValues;
		}

		public bool Read(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			return InternReadTable(ref nrstrErrMsg);
		}

		public void ListTable(ref int rlngIdx)
		{
			mobjAcadDimStyles = mobjAcadDatabase.DimStyles;
			if (mobjAcadDimStyles == null)
			{
				return;
			}
			InternAddToDictLine(ref rlngIdx, 0, "TABLE");
			mlngTblBeg = rlngIdx;
			AcadDimStyles acadDimStyles = mobjAcadDimStyles;
			InternAddToDictLine(ref rlngIdx, 2, acadDimStyles.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadDimStyles.Handle);
			hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadDimStyles.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadDimStyles.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadDimStyles.SuperiorObjectName);
			InternAddToDictLine(ref rlngIdx, 70, acadDimStyles.Count);
			InternAddToDictLine(ref rlngIdx, 100, acadDimStyles.ObjectName);
			InternAddToDictLine(ref rlngIdx, 71, acadDimStyles.FriendGetUnknown71);
			Dictionary<object, object> dobjDictUnknown340 = acadDimStyles.FriendGetDictUnknown340;
			if (dobjDictUnknown340 != null)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictUnknown340.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIndex = num; dlngIndex <= num2; dlngIndex = checked(dlngIndex + 1))
				{
					InternAddToDictLine(ref rlngIdx, 340, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIndex
					}, null)));
				}
			}
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadDimStyles.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadDimStyles = null;
			InternListTable(ref rlngIdx);
			mlngTblEnd = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 0, "ENDTAB");
		}

		private bool InternReadTable(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			int dlngIdx = checked(mlngTblBeg + 1);
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictUnknown341 = new Dictionary<object, object>();
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			int dlngCount = default(int);
			bool InternReadTable = default(bool);
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTable(mobjAcadDatabase, mobjDictReadCodes, mobjDictReadValues, ref dlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dlngCount, ref dobjDictXDictionary2, ref nrstrErrMsg))
			{
				mobjAcadDimStyles = mobjAcadDatabase.FriendAddAcadObjectDimStyles(ddblObjectID, ref nrstrErrMsg);
				bool dblnError;
				if (mobjAcadDimStyles == null)
				{
					nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
					dblnError = true;
				}
				else
				{
					mobjAcadDimStyles.FriendSetDictXDictionary = dobjDictXDictionary2;
					int dlngUnknown71 = default(int);
					if (InternReadDimStyleTable(ref dlngIdx, ref dlngUnknown71, ref dobjDictUnknown341, ref nrstrErrMsg))
					{
						mobjAcadDimStyles.FriendLetUnknown71 = dlngUnknown71;
						mobjAcadDimStyles.FriendSetDictUnknown340 = dobjDictUnknown341;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref dlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							mobjAcadDimStyles.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
							bool dblnStop = default(bool);
							while (dlngIdx <= mlngTblEnd && !dblnError && !dblnStop)
							{
								int dlngCode = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
								object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
								if (dlngCode != 0 && dlngCode != 0)
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Tabelleneintrag/ende in Zeile " + Conversions.ToString(checked(dlngIdx * 2 + 1)) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectEqual(dvarValue, "ENDTAB", TextCompare: false))
								{
									dlngIdx = checked(dlngIdx + 1);
									dblnStop = true;
								}
								else if (!InternReadDimStyle(ddblObjectID, ref dlngIdx, ref mobjAcadDimStyles, ref nrstrErrMsg))
								{
									dblnError = true;
								}
							}
						}
					}
					else
					{
						dblnError = true;
					}
				}
				InternReadTable = !dblnError;
			}
			dobjDictXDictionary2 = null;
			dobjDictUnknown341 = null;
			return InternReadTable;
		}

		private bool InternReadDimStyle(double vdblDefOwnerID, ref int rlngIdx, ref AcadDimStyles robjAcadDimStyles, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadDimStyle = default(bool);
				AcadSysVar dobjAcadSysVar2;
				AcadDimStyle dobjAcadDimStyle2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "DIMSTYLE", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbDimStyleTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Dimstilname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode2 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						if (robjAcadDimStyles.FriendNameExist(dstrName))
						{
							nrstrErrMsg = "Bemaßungsstil " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
							dblnError = true;
						}
						else
						{
							dobjAcadDimStyle2 = robjAcadDimStyles.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
							if (dobjAcadDimStyle2 == null)
							{
								nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
								dblnError = true;
							}
							else
							{
								AcadDimStyle acadDimStyle = dobjAcadDimStyle2;
								acadDimStyle.FriendLetFlags70 = dlngCode2;
								acadDimStyle.FriendSetDictReactors = dobjDictReactors2;
								acadDimStyle.FriendSetDictXDictionary = dobjDictXDictionary2;
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								acadDimStyle.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
								acadDimStyle = null;
								object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(hwpDxf_Vars.pobjDictDxfDimVarOrder.Keys));
								object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(hwpDxf_Vars.pobjDictDxfDimVarOrder.Values));
								int dlngCode = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
								int num = Information.LBound((Array)dvarKeys);
								int num2 = Information.UBound((Array)dvarKeys);
								string dstrTableRecordName = default(string);
								for (int dlngKeyIdx = num; dlngKeyIdx <= num2; dlngKeyIdx++)
								{
									int dlngKey = Conversions.ToInteger(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
									{
									dlngKeyIdx
									}, null));
									string dstrItem = Conversions.ToString(NewLateBinding.LateIndexGet(dvarItems, new object[1]
									{
									dlngKeyIdx
									}, null));
									if (dlngCode != dlngKey)
									{
										continue;
									}
									object dvarValue;
									switch (dlngKey)
									{
										case 340:
											if (!InternFindTextStyleNameByObjectID(Conversions.ToDouble(mobjDictReadValues[rlngIdx]), ref dstrTableRecordName, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											dvarValue = dstrTableRecordName;
											goto IL_0532;
										case 341:
											if (!InternFindBlockNameByObjectID(Conversions.ToDouble(mobjDictReadValues[rlngIdx]), ref dstrTableRecordName, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											dvarValue = dstrTableRecordName;
											goto IL_0532;
										case 342:
											if (!InternFindBlockNameByObjectID(Conversions.ToDouble(mobjDictReadValues[rlngIdx]), ref dstrTableRecordName, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											dvarValue = dstrTableRecordName;
											goto IL_0532;
										case 343:
											if (!InternFindBlockNameByObjectID(Conversions.ToDouble(mobjDictReadValues[rlngIdx]), ref dstrTableRecordName, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											dvarValue = dstrTableRecordName;
											goto IL_0532;
										case 344:
											if (!InternFindBlockNameByObjectID(Conversions.ToDouble(mobjDictReadValues[rlngIdx]), ref dstrTableRecordName, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											dvarValue = dstrTableRecordName;
											goto IL_0532;
										default:
											{
												dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]);
												goto IL_0532;
											}
										IL_0532:
											dobjAcadSysVar2 = dobjAcadDimStyle2.FriendFindVariable(dstrItem);
											if (dobjAcadSysVar2 == null)
											{
												dobjAcadSysVar2 = (AcadSysVar)dobjAcadDimStyle2.FriendGetAcadSysVars.FriendAddXXX(dstrItem);
											}
											if (!dobjAcadSysVar2.FriendSetValue(RuntimeHelpers.GetObjectValue(dvarValue), vblnRaiseEvent: false, ref nrstrErrMsg))
											{
												nrstrErrMsg = nrstrErrMsg + " In Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
												dblnError = true;
												break;
											}
											rlngIdx++;
											dlngCode = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
											continue;
									}
									break;
								}
								if (!dblnError)
								{
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadDimStyle2.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									}
								}
							}
						}
					}
					InternReadDimStyle = !dblnError;
				}
				dobjAcadSysVar2 = null;
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadDimStyle2 = null;
				return InternReadDimStyle;
			}
		}

		private bool InternFindBlockNameByObjectID(double vdblObjectID, ref string rstrName, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			rstrName = null;
			AcadDatabase acadDatabase = mobjAcadDatabase;
			string nrstrErrMsg2 = "";
			bool InternFindBlockNameByObjectID = default(bool);
			AcadBlock dobjAcadBlock2;
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (!acadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg2))
			{
				nrstrErrMsg = "Objekt kann über die Objekt-ID nicht gefunden werden.";
			}
			else if (Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbBlockTableRecord", TextCompare: false) != 0)
			{
				nrstrErrMsg = "Das über die Objekt-ID gefundene Objekt ist ungültig.";
			}
			else
			{
				dobjAcadBlock2 = (AcadBlock)dobjAcadObject2;
				rstrName = dobjAcadBlock2.Name;
				InternFindBlockNameByObjectID = true;
			}
			dobjAcadBlock2 = null;
			dobjAcadObject2 = null;
			return InternFindBlockNameByObjectID;
		}

		private bool InternFindTextStyleNameByObjectID(double vdblObjectID, ref string rstrName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			rstrName = null;
			AcadDatabase acadDatabase = mobjAcadDatabase;
			string nrstrErrMsg2 = "";
			bool InternFindTextStyleNameByObjectID = default(bool);
			AcadTextStyle dobjAcadTextStyle2;
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (!acadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg2))
			{
				nrstrErrMsg = "Objekt kann über die Objekt-ID nicht gefunden werden.";
			}
			else if (Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbTextStyleTableRecord", TextCompare: false) != 0)
			{
				nrstrErrMsg = "Das über die Objekt-ID gefundene Objekt ist ungültig.";
			}
			else
			{
				dobjAcadTextStyle2 = (AcadTextStyle)dobjAcadObject2;
				rstrName = dobjAcadTextStyle2.Name;
				InternFindTextStyleNameByObjectID = true;
			}
			dobjAcadTextStyle2 = null;
			dobjAcadObject2 = null;
			return InternFindTextStyleNameByObjectID;
		}

		private bool InternReadDimStyleTable(ref int rlngIdx, ref int rlngUnknown71, ref Dictionary<object, object> robjDictUnknown340, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			robjDictUnknown340.Clear();
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbDimStyleTable", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 71, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode (?) in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else
				{
					rlngUnknown71 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 1]);
					rlngIdx += 2;
					int dlngCount = default(int);
					while (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 340, TextCompare: false))
					{
						robjDictUnknown340.Add("K" + Conversions.ToString(dlngCount), RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]));
						dlngCount++;
						rlngIdx++;
					}
				}
				return !dblnError;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadDimStyle dobjAcadDimStyle2;
			try
			{
				enumerator = mobjAcadDimStyles.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadDimStyle2 = (AcadDimStyle)enumerator.Current;
					AcadDimStyle acadDimStyle = dobjAcadDimStyle2;
					InternAddToDictLine(ref rlngIdx, 0, acadDimStyle.DXFName);
					InternAddToDictLine(ref rlngIdx, 105, acadDimStyle.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadDimStyle.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadDimStyle.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadDimStyle.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadDimStyle.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadDimStyle.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadDimStyle.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadDimStyle.Flags70);
					InternListSysVars(ref rlngIdx, dobjAcadDimStyle2);
					acadDimStyle.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadDimStyle = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadDimStyle2 = null;
		}

		private void InternListSysVars(ref int rlngIdx, AcadDimStyle vobjAcadDimStyle)
		{
			object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(hwpDxf_Vars.pobjDictDxfDimVarOrder.Keys));
			object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(hwpDxf_Vars.pobjDictDxfDimVarOrder.Values));
			AcadSysVars dobjAcadSysVars2 = vobjAcadDimStyle.FriendGetAcadSysVars;
			int num = Information.LBound((Array)dvarKeys);
			int num2 = Information.UBound((Array)dvarKeys);
			object dvarValue = default(object);
			AcadTextStyle dobjAcadTextStyle = default(AcadTextStyle);
			AcadBlock dobjAcadBlock4;
			AcadSysVar dobjAcadSysVar;
			for (int dlngKeyIdx = num; dlngKeyIdx <= num2; dlngKeyIdx = checked(dlngKeyIdx + 1))
			{
				int dlngKey = Conversions.ToInteger(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
				{
				dlngKeyIdx
				}, null));
				string dstrItem = Conversions.ToString(NewLateBinding.LateIndexGet(dvarItems, new object[1]
				{
				dlngKeyIdx
				}, null));
				dobjAcadSysVar = dobjAcadSysVars2.FriendGetItem(dstrItem);
				if (dobjAcadSysVar == null)
				{
					continue;
				}
				switch (dlngKey)
				{
					case 340:
						dobjAcadTextStyle = (AcadTextStyle)mobjAcadDatabase.TextStyles.FriendGetItem(RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value));
						if (dobjAcadTextStyle != null)
						{
							dvarValue = dobjAcadTextStyle.ObjectID;
						}
						break;
					case 341:
						dobjAcadBlock4 = (AcadBlock)mobjAcadDatabase.Blocks.FriendGetItem(RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value));
						if (dobjAcadTextStyle != null)
						{
							dvarValue = dobjAcadBlock4.ObjectID;
						}
						break;
					case 342:
						dobjAcadBlock4 = (AcadBlock)mobjAcadDatabase.Blocks.FriendGetItem(RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value));
						if (dobjAcadTextStyle != null)
						{
							dvarValue = dobjAcadBlock4.ObjectID;
						}
						break;
					case 343:
						dobjAcadBlock4 = (AcadBlock)mobjAcadDatabase.Blocks.FriendGetItem(RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value));
						if (dobjAcadTextStyle != null)
						{
							dvarValue = dobjAcadBlock4.ObjectID;
						}
						break;
					case 344:
						dobjAcadBlock4 = (AcadBlock)mobjAcadDatabase.Blocks.FriendGetItem(RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value));
						if (dobjAcadTextStyle != null)
						{
							dvarValue = dobjAcadBlock4.ObjectID;
						}
						break;
					default:
						dvarValue = RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value);
						break;
				}
				InternAddToDictLine(ref rlngIdx, dlngKey, RuntimeHelpers.GetObjectValue(dvarValue));
			}
			dobjAcadTextStyle = null;
			dobjAcadBlock4 = null;
			dobjAcadSysVar = null;
			dobjAcadSysVars2 = null;
		}
	}
}
