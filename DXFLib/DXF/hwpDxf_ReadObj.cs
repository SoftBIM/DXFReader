using DXFLib.Acad;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_ReadObj
	{
		public static bool BkDXFReadObj_AcadNamedObjectDictionary(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadDatabase robjAcadDatabase, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictEntryName2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictEntryObjectID2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			double ddblLineOwnerID = default(double);
			int dlngTreatElementsAsHard = default(int);
			int dlngMergeStyle = default(int);
			bool BkDXFReadObj_AcadNamedObjectDictionary = default(bool);
			AcadDictionaries dobjAcadDictionaries2;
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadDictionary(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngTreatElementsAsHard, ref dlngMergeStyle, ref dobjDictEntryName2, ref dobjDictEntryObjectID2, ref nrstrErrMsg))
			{
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				bool dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
				if (!dblnError)
				{
					dobjAcadDictionaries2 = robjAcadDatabase.FriendAddAcadObjectDictionaries(ddblObjectID, ref nrstrErrMsg);
					if (dobjAcadDictionaries2 == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						AcadDictionaries acadDictionaries = dobjAcadDictionaries2;
						acadDictionaries.FriendSetDictReactors = dobjDictReactors2;
						acadDictionaries.FriendLetTreatElementsAsHard = (dlngTreatElementsAsHard == 1);
						acadDictionaries.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)dlngMergeStyle;
						acadDictionaries.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
						acadDictionaries = null;
						dblnError = !BkDXFReadObj_AcadNamedObjectDictionaryElements(vobjAcadDatabase, dobjAcadDictionaries2, dobjDictEntryName2, dobjDictEntryObjectID2, ref nrstrErrMsg);
					}
				}
				BkDXFReadObj_AcadNamedObjectDictionary = !dblnError;
			}
			dobjDictEntryObjectID2 = null;
			dobjDictEntryName2 = null;
			dobjDictReactors2 = null;
			dobjAcadDictionaries2 = null;
			return BkDXFReadObj_AcadNamedObjectDictionary;
		}

		public static bool BkDXFReadObj_AcadNamedObjectDictionaryElements(AcadDatabase vobjAcadDatabase, AcadDictionaries vobjAcadDictionaries, Dictionary<object, object> vobjDictEntryName, Dictionary<object, object> vobjDictEntryObjectID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			object dvarEntryNameItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDictEntryName.Values));
			object dvarEntryObjectIDItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDictEntryObjectID.Values));
			int num = Information.LBound((Array)dvarEntryNameItems);
			int num2 = Information.UBound((Array)dvarEntryNameItems);
			bool dblnError = default(bool);
			bool dblnAdded = default(bool);
			AcadObject dobjAcadObject13;
			for (int dlngIndex = num; dlngIndex <= num2; dlngIndex = checked(dlngIndex + 1))
			{
				double ddblEntryObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarEntryObjectIDItems, new object[1]
				{
				dlngIndex
				}, null));
				if (!vobjAcadDatabase.FriendValidObjectID(ddblEntryObjectID, ref nrstrErrMsg))
				{
					bool flag = false;
					hwpDxf_Functions.BkDXF_DebugPrint("Referenz für Hauptwörterbucheintrag ist ungültig.\n" + nrstrErrMsg);
					continue;
				}
				string dstrEntryName = Conversions.ToString(NewLateBinding.LateIndexGet(dvarEntryNameItems, new object[1]
				{
				dlngIndex
				}, null));
				switch (dstrEntryName)
				{
					case "ACAD_GROUP":
						dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObjectGroups(ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject13 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject13 = null;
						continue;
					case "ACAD_PLOTSTYLENAME":
						dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObjectPlotStyleNames(ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject13 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject13 = null;
						continue;
					case "ACAD_MLINESTYLE":
						dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObjectMLineStyles(ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject13 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject13 = null;
						continue;
					case "ACAD_PLOTSETTINGS":
						dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObjectPlotConfigurations(ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject13 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject13 = null;
						continue;
					case "ACAD_LAYOUT":
						dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObjectLayouts(ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject13 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject13 = null;
						continue;
					default:
						if (dblnAdded)
						{
							continue;
						}
						if (Operators.CompareString(dstrEntryName, "AcDbVariableDictionary", TextCompare: false) == 0)
						{
							dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObject(dstrEntryName, ddblEntryObjectID, ref nrstrErrMsg);
							if (dobjAcadObject13 != null)
							{
								dobjAcadObject13 = null;
								continue;
							}
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
						}
						else
						{
							dobjAcadObject13 = vobjAcadDictionaries.FriendAddAcadObject(dstrEntryName, ddblEntryObjectID, ref nrstrErrMsg);
							if (dobjAcadObject13 != null)
							{
								dobjAcadObject13 = null;
								continue;
							}
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
						}
						break;
				}
				break;
			}
			bool BkDXFReadObj_AcadNamedObjectDictionaryElements = !dblnError;
			dobjAcadObject13 = null;
			return BkDXFReadObj_AcadNamedObjectDictionaryElements;
		}

		public static bool BkDXFReadObj_AcadDictionary(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, bool vblnWithDefault, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictEntryName2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictEntryObjectID2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadDictionary = default(bool);
				AcadDictionary dobjAcadDictionary2;
				AcadLayers dobjAcadLayers2;
				AcadDictionaries dobjAcadDictionaries2;
				AcadLayout dobjAcadLayout2;
				AcadBlock dobjAcadBlock2 = default(AcadBlock);
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					if (!vobjAcadDatabase.Dictionaries.FriendObjectIDExist(ddblObjectID))
					{
						double vdblObjectID = ddblOwnerID;
						string nrstrErrMsg2 = "";
						bool dblnRefFound = default(bool);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg2))
						{
							switch (dobjAcadObject2.ObjectName)
							{
								case "AcDbBlockTableRecord":
									dobjAcadBlock2 = (AcadBlock)dobjAcadObject2;
									vdblDefOwnerID = dobjAcadBlock2.ObjectID;
									dblnRefFound = true;
									break;
								case "AcDbLayout":
									dobjAcadLayout2 = (AcadLayout)dobjAcadObject2;
									vdblDefOwnerID = dobjAcadLayout2.ObjectID;
									dblnRefFound = true;
									break;
								case "AcDbDictionaries":
									dobjAcadDictionaries2 = (AcadDictionaries)dobjAcadObject2;
									vdblDefOwnerID = dobjAcadDictionaries2.ObjectID;
									dblnRefFound = true;
									break;
								case "AcDbLayerTable":
									dobjAcadLayers2 = (AcadLayers)dobjAcadObject2;
									vdblDefOwnerID = dobjAcadLayers2.ObjectID;
									dblnRefFound = true;
									break;
								default:
									hwpDxf_Functions.BkDXF_DebugPrint("Unbekannter Besitzer: " + dobjAcadObject2.ObjectName);
									break;
							}
						}
						if (!dblnRefFound)
						{
							bool flag = false;
							hwpDxf_Functions.BkDXF_DebugPrint("Unbekannter Hauptwörterbucheintrag wird ignoriert.");
						}
					}
					bool dblnError = default(bool);
					if (!dblnError)
					{
						if (ddblOwnerID != vdblDefOwnerID)
						{
							hwpDxf_Functions.BkDXF_DebugPrint("Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(ddblOwnerID) + "' in Zeile " + Conversions.ToString(rlngIdx * 2) + ".");
						}
						int dlngTreatElementsAsHard = default(int);
						int dlngMergeStyle = default(int);
						if (hwpDxf_ReadRef.BkDXFReadRef_AcadDictionary(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngTreatElementsAsHard, ref dlngMergeStyle, ref dobjDictEntryName2, ref dobjDictEntryObjectID2, ref nrstrErrMsg))
						{
							double ddblDefaultID = default(double);
							if (vblnWithDefault)
							{
								if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbDictionaryWithDefault", TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 340, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Vorgabe-Objekt-ID in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
									dblnError = true;
								}
								else
								{
									ddblDefaultID = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							if (!dblnError)
							{
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError && dobjAcadBlock2 == null)
								{
									dobjAcadDictionary2 = (AcadDictionary)vobjAcadDatabase.Dictionaries.FriendGetItemByObjectID(ddblObjectID);
									if (dobjAcadDictionary2 != null)
									{
										if (!BkDXFReadObj_AcadDictionaryElements(vobjAcadDatabase, ref dobjAcadDictionary2, dobjDictEntryName2, dobjDictEntryObjectID2, ref nrstrErrMsg))
										{
											dblnError = true;
										}
										else
										{
											BkDXFReadObj_AcadDictionaryValues(vobjAcadDatabase.Document.AcadVer, ref dobjAcadDictionary2, dlngTreatElementsAsHard, dlngMergeStyle, ddblDefaultID, RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), dobjDictReactors2);
										}
									}
								}
							}
						}
					}
					BkDXFReadObj_AcadDictionary = !dblnError;
				}
				dobjDictEntryObjectID2 = null;
				dobjDictEntryName2 = null;
				dobjDictReactors2 = null;
				dobjAcadDictionary2 = null;
				dobjAcadLayers2 = null;
				dobjAcadDictionaries2 = null;
				dobjAcadLayout2 = null;
				dobjAcadBlock2 = null;
				dobjAcadObject2 = null;
				return BkDXFReadObj_AcadDictionary;
			}
		}

		public static bool BkDXFReadObj_AcadDictionaryElements(AcadDatabase vobjAcadDatabase, ref AcadDictionary robjAcadDictionary, Dictionary<object, object> vobjDictEntryName, Dictionary<object, object> vobjDictEntryObjectID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			object dvarEntryNameItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDictEntryName.Values));
			object dvarEntryObjectIDItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDictEntryObjectID.Values));
			int num = Information.LBound((Array)dvarEntryNameItems);
			int num2 = Information.UBound((Array)dvarEntryNameItems);
			bool dblnError = default(bool);
			bool dblnAdded = default(bool);
			AcadDictionaryEntry dobjAcadDictionaryEntry3;
			AcadObject dobjAcadObject3;
			AcadDictionaryVar dobjAcadDictionaryVar3;
			AcadDictionary dobjAcadDictionary2;
			AcadLayouts dobjAcadLayouts2;
			AcadPlotConfigurations dobjAcadPlotConfigurations2;
			AcadMLineStyles dobjAcadMLineStyles2;
			AcadPlaceholder dobjAcadPlaceholder2;
			AcadDictionaryWithDefault dobjAcadDictionaryWithDefault;
			AcadGroups dobjAcadGroups;
			for (int dlngIndex = num; dlngIndex <= num2; dlngIndex = checked(dlngIndex + 1))
			{
				double ddblEntryObjectID = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvarEntryObjectIDItems, new object[1]
				{
				dlngIndex
				}, null));
				if (!vobjAcadDatabase.FriendValidObjectID(ddblEntryObjectID, ref nrstrErrMsg))
				{
					nrstrErrMsg = "Referenz für Wörterbucheintrag ist ungültig.\n" + nrstrErrMsg;
					dblnError = true;
					break;
				}
				string dstrEntryName = Conversions.ToString(NewLateBinding.LateIndexGet(dvarEntryNameItems, new object[1]
				{
				dlngIndex
				}, null));
				switch (robjAcadDictionary.ObjectName)
				{
					case "AcDbGroups":
						dobjAcadGroups = (AcadGroups)robjAcadDictionary;
						dobjAcadGroups.Add(dstrEntryName, Conversions.ToString(ddblEntryObjectID));
						continue;
					case "AcDbDictionaryWithDefault":
						{
							dobjAcadDictionaryWithDefault = (AcadDictionaryWithDefault)robjAcadDictionary;
							string name2 = dobjAcadDictionaryWithDefault.Name;
							if (Operators.CompareString(name2, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
							{
								dobjAcadPlaceholder2 = new AcadPlaceholder();
								dobjAcadPlaceholder2.FriendLetName = dstrEntryName;
								AcadDictionaryWithDefault acadDictionaryWithDefault = dobjAcadDictionaryWithDefault;
								AcadObject robjAcadObject = dobjAcadPlaceholder2;
								acadDictionaryWithDefault.FriendAdd(dstrEntryName, ddblEntryObjectID, ref robjAcadObject);
								dobjAcadPlaceholder2 = (AcadPlaceholder)robjAcadObject;
							}
							else
							{
								hwpDxf_Functions.BkDXF_DebugPrint("Objekte - D Unbekanntes Dictionary mit Vorgaben: " + dobjAcadDictionaryWithDefault.Name);
							}
							continue;
						}
					case "AcDbMlineStyles":
						dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadDictionary;
						dobjAcadObject3 = dobjAcadMLineStyles2.FriendAddAcadObject(dstrEntryName, ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject3 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject3 = null;
						continue;
					case "AcDbPlotSettingsTable":
						dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadDictionary;
						dobjAcadObject3 = dobjAcadPlotConfigurations2.FriendAddAcadObject(dstrEntryName, ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject3 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject3 = null;
						continue;
					case "AcDbLayouts":
						dobjAcadLayouts2 = (AcadLayouts)robjAcadDictionary;
						dobjAcadObject3 = dobjAcadLayouts2.FriendAddAcadObject(dstrEntryName, ddblEntryObjectID, ref nrstrErrMsg);
						if (dobjAcadObject3 == null)
						{
							nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
							dblnError = true;
							break;
						}
						dobjAcadObject3 = null;
						continue;
					case "AcDbDictionary":
						{
							dobjAcadDictionary2 = robjAcadDictionary;
							string name = dobjAcadDictionary2.Name;
							if (Operators.CompareString(name, "AcDbVariableDictionary", TextCompare: false) == 0)
							{
								switch (dstrEntryName)
								{
									case "DIMASSOC":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "PROJECTNAME":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "INDEXCTL":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "SORTENTS":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "XCLIPFRAME":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "HIDETEXT":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									case "CTABLESTYLE":
										{
											bool dblnEntryIsDictionaryVar8 = true;
											break;
										}
									default:
										{
											bool dblnEntryIsDictionaryVar8 = false;
											hwpDxf_Functions.BkDXF_DebugPrint("Objekte - E Unbekannte DictionaryVar: " + dstrEntryName);
											break;
										}
								}
								dobjAcadDictionaryVar3 = new AcadDictionaryVar();
								dobjAcadDictionaryVar3.FriendLetName = dstrEntryName;
								AcadDictionary acadDictionary = dobjAcadDictionary2;
								AcadObject robjAcadObject = dobjAcadDictionaryVar3;
								AcadObject acadObject = acadDictionary.FriendAdd(dstrEntryName, ddblEntryObjectID, ref robjAcadObject);
								dobjAcadDictionaryVar3 = (AcadDictionaryVar)robjAcadObject;
								dobjAcadObject3 = acadObject;
								if (dobjAcadObject3 != null)
								{
									dobjAcadObject3 = null;
									continue;
								}
								nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
								dblnError = true;
							}
							else
							{
								dobjAcadDictionaryEntry3 = new AcadDictionaryEntry();
								dobjAcadDictionaryEntry3.FriendLetName = dstrEntryName;
								AcadDictionary acadDictionary2 = dobjAcadDictionary2;
								AcadObject acadObject = dobjAcadDictionaryEntry3;
								AcadObject robjAcadObject = acadDictionary2.FriendAdd(dstrEntryName, ddblEntryObjectID, ref acadObject);
								dobjAcadDictionaryEntry3 = (AcadDictionaryEntry)acadObject;
								dobjAcadObject3 = robjAcadObject;
								if (dobjAcadObject3 != null)
								{
									dobjAcadObject3 = null;
									continue;
								}
								nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
								dblnError = true;
							}
							break;
						}
					default:
						if (!dblnAdded)
						{
							hwpDxf_Functions.BkDXF_DebugPrint("Objekte - C Unbekanntes Element: " + robjAcadDictionary.ObjectName);
						}
						continue;
				}
				break;
			}
			bool BkDXFReadObj_AcadDictionaryElements = !dblnError;
			dobjAcadDictionaryEntry3 = null;
			dobjAcadObject3 = null;
			dobjAcadDictionaryVar3 = null;
			dobjAcadDictionary2 = null;
			dobjAcadLayouts2 = null;
			dobjAcadPlotConfigurations2 = null;
			dobjAcadMLineStyles2 = null;
			dobjAcadPlaceholder2 = null;
			dobjAcadDictionaryWithDefault = null;
			dobjAcadGroups = null;
			return BkDXFReadObj_AcadDictionaryElements;
		}

		public static void BkDXFReadObj_AcadDictionaryValues(string vstrAcadVer, ref AcadDictionary robjAcadDictionary, int vlngTreatElementsAsHard, int vlngMergeStyle, double vdblDefaultID, object vvarXDataType, object vvarXDataValue, Dictionary<object, object> vobjDictReactors)
		{
			AcadDictionary dobjAcadDictionary2;
			AcadLayouts dobjAcadLayouts2;
			AcadPlotConfigurations dobjAcadPlotConfigurations2;
			AcadMLineStyles dobjAcadMLineStyles2;
			AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2;
			AcadGroups dobjAcadGroups2;
			switch (robjAcadDictionary.ObjectName)
			{
				case "AcDbGroups":
					{
						dobjAcadGroups2 = (AcadGroups)robjAcadDictionary;
						AcadGroups acadGroups = dobjAcadGroups2;
						acadGroups.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadGroups.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadGroups.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadGroups.FriendSetDictReactors = vobjDictReactors;
						acadGroups = null;
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)robjAcadDictionary;
						AcadDictionaryWithDefault acadDictionaryWithDefault = dobjAcadDictionaryWithDefault2;
						acadDictionaryWithDefault.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadDictionaryWithDefault.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadDictionaryWithDefault.FriendLetDefaultID = vdblDefaultID;
						acadDictionaryWithDefault.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadDictionaryWithDefault.FriendSetDictReactors = vobjDictReactors;
						acadDictionaryWithDefault = null;
						break;
					}
				case "AcDbMlineStyles":
					{
						dobjAcadMLineStyles2 = (AcadMLineStyles)robjAcadDictionary;
						AcadMLineStyles acadMLineStyles = dobjAcadMLineStyles2;
						acadMLineStyles.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadMLineStyles.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadMLineStyles.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadMLineStyles.FriendSetDictReactors = vobjDictReactors;
						acadMLineStyles = null;
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)robjAcadDictionary;
						AcadPlotConfigurations acadPlotConfigurations = dobjAcadPlotConfigurations2;
						acadPlotConfigurations.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadPlotConfigurations.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadPlotConfigurations.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadPlotConfigurations.FriendSetDictReactors = vobjDictReactors;
						acadPlotConfigurations = null;
						break;
					}
				case "AcDbLayouts":
					{
						dobjAcadLayouts2 = (AcadLayouts)robjAcadDictionary;
						AcadLayouts acadLayouts = dobjAcadLayouts2;
						acadLayouts.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadLayouts.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadLayouts.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadLayouts.FriendSetDictReactors = vobjDictReactors;
						acadLayouts = null;
						break;
					}
				case "AcDbDictionary":
					{
						dobjAcadDictionary2 = robjAcadDictionary;
						AcadDictionary acadDictionary = dobjAcadDictionary2;
						acadDictionary.FriendLetTreatElementsAsHard = (vlngTreatElementsAsHard == 1);
						acadDictionary.FriendLetMergeStyle = (hwpDxf_Enums.MERGE_STYLE)vlngMergeStyle;
						acadDictionary.SetXData(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue));
						acadDictionary.FriendSetDictReactors = vobjDictReactors;
						acadDictionary = null;
						break;
					}
				default:
					{
						bool dblnRead = default(bool);
						if (!dblnRead)
						{
							hwpDxf_Functions.BkDXF_DebugPrint("Objekte - F Unbekanntes Dictionary: " + robjAcadDictionary.ObjectName);
						}
						break;
					}
			}
			dobjAcadDictionary2 = null;
			dobjAcadLayouts2 = null;
			dobjAcadPlotConfigurations2 = null;
			dobjAcadMLineStyles2 = null;
			dobjAcadDictionaryWithDefault2 = null;
			dobjAcadGroups2 = null;
		}

		public static bool BkDXFReadObj_AcadPlaceholder(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, AcadDictionaryWithDefault vobjAcadPlotStyleNames, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			double ddblLineOwnerID = default(double);
			bool BkDXFReadObj_AcadPlaceholder = default(bool);
			AcadPlaceholder dobjAcadPlaceholder2;
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
			{
				if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
				{
					nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString(checked((dlngStartIndex + 1) * 2)) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
					double vdblObjectID = ddblObjectID;
					string nrstrErrMsg2 = "";
					AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
					if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
					{
						hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
					}
					dobjObjectIDAcadObject2 = null;
					bool dblnError2 = true;
				}
				else
				{
					object dvarXDataType = default(object);
					object dvarXDataValue = default(object);
					bool dblnError2 = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
					if (!dblnError2)
					{
						dobjAcadPlaceholder2 = (AcadPlaceholder)vobjAcadPlotStyleNames.FriendGetItemByObjectID(ddblObjectID);
						AcadPlaceholder acadPlaceholder = dobjAcadPlaceholder2;
						acadPlaceholder.FriendSetDictReactors = dobjDictReactors2;
						acadPlaceholder.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
						acadPlaceholder = null;
					}
					BkDXFReadObj_AcadPlaceholder = !dblnError2;
				}
			}
			dobjDictReactors2 = null;
			dobjAcadPlaceholder2 = null;
			return BkDXFReadObj_AcadPlaceholder;
		}

		public static bool BkDXFReadObj_AcadLayout(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, ref AcadLayouts robjAcadLayouts, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarPaperMarginLowerLeft = new object[2];
			object[] davarPaperMarginUpperRight = new object[2];
			object[] davarPlotOrigin = new object[2];
			object[] davarWindowToPlotLowerLeft = new object[2];
			object[] davarWindowToPlotUpperRight = new object[2];
			object[] davarPaperImageOrigin = new object[2];
			object[] dadecLimMin = new object[2];
			double[] dadblLimMin = new double[2];
			object[] dadecLimMax = new object[2];
			double[] dadblLimMax = new double[2];
			object[] dadecInsBase = new object[3];
			double[] dadblInsBase = new double[3];
			object[] dadecExtMin = new object[3];
			double[] dadblExtMin = new double[3];
			object[] dadecExtMax = new object[3];
			double[] dadblExtMax = new double[3];
			object[] dadecUCSOrigin = new object[3];
			double[] dadblUCSOrigin = new double[3];
			object[] dadecUCSXVector = new object[3];
			double[] dadblUCSXVector = new double[3];
			object[] dadecUCSYVector = new object[3];
			double[] dadblUCSYVector = new double[3];
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadLayout = default(bool);
				AcadLayout dobjAcadLayout2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					string dstrPlotSettingsName = default(string);
					string dstrConfigName = default(string);
					string dstrCanonicalMediaName = default(string);
					string dstrViewToPlot = default(string);
					object dvarPaperWidth = default(object);
					object dvarPaperHeight = default(object);
					object dvarCustomScaleNumerator = default(object);
					object dvarCustomScaleDenominator = default(object);
					int dlngPlotCode70 = default(int);
					int dlngPaperUnits = default(int);
					int dlngPlotRotation = default(int);
					int dlngPlotType = default(int);
					string dstrStyleSheet = default(string);
					int dlngStandardScale = default(int);
					object dvarScaleFactor = default(object);
					int dlngShadePlotMode = default(int);
					int dlngShadePlotResolutionLevel = default(int);
					int dlngShadePlotCustomDPI = default(int);
					if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString((dlngStartIndex + 1) * 2) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
						double vdblObjectID = ddblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
						bool dblnError2 = true;
					}
					else if (hwpDxf_ReadRef.BkDXFReadRef_AcadPlotConfiguration(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dstrPlotSettingsName, ref dstrConfigName, ref dstrCanonicalMediaName, ref dstrViewToPlot, ref davarPaperMarginLowerLeft, ref davarPaperMarginUpperRight, ref dvarPaperWidth, ref dvarPaperHeight, ref davarPlotOrigin, ref davarWindowToPlotLowerLeft, ref davarWindowToPlotUpperRight, ref dvarCustomScaleNumerator, ref dvarCustomScaleDenominator, ref dlngPlotCode70, ref dlngPaperUnits, ref dlngPlotRotation, ref dlngPlotType, ref dstrStyleSheet, ref dlngStandardScale, ref dvarScaleFactor, ref dlngShadePlotMode, ref dlngShadePlotResolutionLevel, ref dlngShadePlotCustomDPI, ref davarPaperImageOrigin, ref nrstrErrMsg))
					{
						bool dblnError2;
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbLayout", TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 1, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Name in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 71, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Registerkartenreihenfolge in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Minimale Limiten X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Minimale Limiten Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 11, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Maximale Limiten X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 21, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Maximale Limiten Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 8], 12, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügebasispunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 9], 22, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügebasispunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 10], 32, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügebasispunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 11], 14, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Minimale Grenzen X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 12], 24, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Minimale Grenzen Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 13], 34, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Minimale Grenzen Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 27) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 14], 15, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Maximale Grenzen X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 29) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 15], 25, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Maximale Grenzen Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 31) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 16], 35, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Maximale Grenzen Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 33) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 17], 146, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Erhebung in Zeile " + Conversions.ToString(rlngIdx * 2 + 35) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 18], 13, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Ursprung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 37) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 19], 23, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Ursprung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 39) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 20], 33, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Ursprung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 41) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 21], 16, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-X-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 43) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 22], 26, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-X-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 45) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 23], 36, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-X-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 47) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 24], 17, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Y-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 49) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 25], 27, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Y-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 51) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 26], 37, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für BKS-Y-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 53) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 27], 76, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Orthogonaler Typ des BKS in Zeile " + Conversions.ToString(rlngIdx * 2 + 55) + ".";
							dblnError2 = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 28], 330, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Papierbereich-Objekt-ID in Zeile " + Conversions.ToString(rlngIdx * 2 + 57) + ".";
							dblnError2 = true;
						}
						else
						{
							string dstrName = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
							string dlngCode70 = Conversions.ToString(vobjDictReadValues[rlngIdx + 2]);
							int dlngTabOrder = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
							bool flag = false;
							dadblLimMin[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
							dadblLimMin[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
							dadblLimMax[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
							dadblLimMax[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 7]);
							dadblInsBase[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 8]);
							dadblInsBase[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 9]);
							dadblInsBase[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 10]);
							dadblExtMin[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 11]);
							dadblExtMin[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 12]);
							dadblExtMin[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 13]);
							dadblExtMax[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 14]);
							dadblExtMax[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 15]);
							dadblExtMax[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 16]);
							double ddblElevation = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 17]);
							dadblUCSOrigin[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 18]);
							dadblUCSOrigin[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 19]);
							dadblUCSOrigin[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 20]);
							dadblUCSXVector[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 21]);
							dadblUCSXVector[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 22]);
							dadblUCSXVector[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 23]);
							dadblUCSYVector[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 24]);
							dadblUCSYVector[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 25]);
							dadblUCSYVector[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 26]);
							int dlngUCSOrthographic = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 27]);
							double ddblPaperSpaceObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 28]);
							rlngIdx += 29;
							double ddblViewportObjectID;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 331, TextCompare: false))
							{
								ddblViewportObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								ddblViewportObjectID = -1.0;
							}
							double ddblNamedUCSObjectID;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 345, TextCompare: false))
							{
								ddblNamedUCSObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								ddblNamedUCSObjectID = -1.0;
							}
							double ddblReferencedUCSObjectID;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 346, TextCompare: false))
							{
								ddblReferencedUCSObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								ddblReferencedUCSObjectID = -1.0;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError2 = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							unchecked
							{
								if (!dblnError2)
								{
									dobjAcadLayout2 = (AcadLayout)robjAcadLayouts.FriendGetItemByObjectID(ddblObjectID);
									AcadLayout acadLayout = dobjAcadLayout2;
									acadLayout.FriendSetDictReactors = dobjDictReactors2;
									acadLayout.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadLayout.PlotSettingsName = dstrPlotSettingsName;
									acadLayout.ConfigName = dstrConfigName;
									acadLayout.CanonicalMediaName = dstrCanonicalMediaName;
									acadLayout.ViewToPlot = dstrViewToPlot;
									acadLayout.FriendLetPaperMarginLowerLeft = Support.CopyArray(davarPaperMarginLowerLeft);
									acadLayout.FriendLetPaperMarginUpperRight = Support.CopyArray(davarPaperMarginUpperRight);
									acadLayout.FriendLetPaperWidth = RuntimeHelpers.GetObjectValue(dvarPaperWidth);
									acadLayout.FriendLetPaperHeight = RuntimeHelpers.GetObjectValue(dvarPaperHeight);
									acadLayout.PlotOrigin = Support.CopyArray(davarPlotOrigin);
									acadLayout.FriendLetWindowToPlotLowerLeft = Support.CopyArray(davarWindowToPlotLowerLeft);
									acadLayout.FriendLetWindowToPlotUpperRight = Support.CopyArray(davarWindowToPlotUpperRight);
									acadLayout.FriendLetCustomScaleNumerator = RuntimeHelpers.GetObjectValue(dvarCustomScaleNumerator);
									acadLayout.FriendLetCustomScaleDenominator = RuntimeHelpers.GetObjectValue(dvarCustomScaleDenominator);
									acadLayout.FriendLetPlotSettingsFlags70 = dlngPlotCode70;
									acadLayout.PaperUnits = (Enums.AcPlotPaperUnits)dlngPaperUnits;
									acadLayout.PlotRotation = (Enums.AcPlotRotation)dlngPlotRotation;
									acadLayout.PlotType = (Enums.AcPlotType)dlngPlotType;
									acadLayout.StyleSheet = dstrStyleSheet;
									acadLayout.StandardScale = (Enums.AcPlotScale)dlngStandardScale;
									acadLayout.FriendLetScaleFactor = RuntimeHelpers.GetObjectValue(dvarScaleFactor);
									acadLayout.FriendLetPaperImageOrigin = Support.CopyArray(davarPaperImageOrigin);
									acadLayout.Name = dstrName;
									acadLayout.FriendLetFlags70 = Conversions.ToInteger(dlngCode70);
									acadLayout.TabOrder = dlngTabOrder;
									bool flag2 = false;
									acadLayout.FriendLetLimMin = Support.CopyArray(dadblLimMin);
									acadLayout.FriendLetLimMax = Support.CopyArray(dadblLimMax);
									acadLayout.FriendLetInsBase = Support.CopyArray(dadblInsBase);
									acadLayout.FriendLetExtMin = Support.CopyArray(dadblExtMin);
									acadLayout.FriendLetExtMax = Support.CopyArray(dadblExtMax);
									acadLayout.FriendLetElevation = ddblElevation;
									acadLayout.FriendLetUCSOrigin = Support.CopyArray(dadblUCSOrigin);
									acadLayout.FriendLetUCSXVector = Support.CopyArray(dadblUCSXVector);
									acadLayout.FriendLetUCSYVector = Support.CopyArray(dadblUCSYVector);
									acadLayout.FriendLetUCSOrthographic = (Enums.AcOrthoView)dlngUCSOrthographic;
									acadLayout.FriendLetPaperSpaceObjectID = ddblPaperSpaceObjectID;
									acadLayout.FriendLetViewportObjectID = ddblViewportObjectID;
									acadLayout.FriendLetNamedUCSObjectID = ddblNamedUCSObjectID;
									acadLayout.FriendLetReferencedUCSObjectID = ddblReferencedUCSObjectID;
									acadLayout.FriendLetShadePlotMode = dlngShadePlotMode;
									acadLayout.FriendLetShadePlotResolutionLevel = dlngShadePlotResolutionLevel;
									acadLayout.FriendLetShadePlotCustomDPI = dlngShadePlotCustomDPI;
									acadLayout.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadLayout = null;
								}
							}
						}
						BkDXFReadObj_AcadLayout = !dblnError2;
					}
				}
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				dobjAcadLayout2 = null;
				return BkDXFReadObj_AcadLayout;
			}
		}

		public static bool BkDXFReadObj_AcadMLineStyle(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, ref AcadMLineStyles robjAcadMLineStyles, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictElementOffset2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictElementColor2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictElementLinetype2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadMLineStyle = default(bool);
				AcadMLineStyleElements dobjAcadMLineStyleElements2;
				AcadMLineStyle dobjAcadMLineStyle2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					bool dblnError = default(bool);
					if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString((dlngStartIndex + 1) * 2) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
						double vdblObjectID = ddblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbMlineStyle", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Namen in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 3, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Stilbeschreibung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 62, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Füllfarbe in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 51, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anfangswinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 52, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Endwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anzahl in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
						string dstrDescription = Conversions.ToString(vobjDictReadValues[rlngIdx + 3]);
						int dlngFillColor = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 4]);
						bool flag = false;
						double ddblStartAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						double ddblEndAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
						rlngIdx += 8;
						int dlngCount = 0;
						object ddecElementOffset = default(object);
						while (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(vobjDictReadCodes[rlngIdx], 49, TextCompare: false), !dblnError)))
						{
							bool flag2 = false;
							double ddblElementOffset = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 62, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Elementfarbe in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
								continue;
							}
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 6, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Elementlinientyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
								continue;
							}
							int dlngElementColor = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							string dstrElementLinetype = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
							dobjDictElementOffset2.Add(dlngCount, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecElementOffset), ddblElementOffset)));
							dobjDictElementColor2.Add(dlngCount, dlngElementColor);
							dobjDictElementLinetype2.Add(dlngCount, dstrElementLinetype);
							dlngCount++;
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dobjAcadMLineStyle2 = (AcadMLineStyle)robjAcadMLineStyles.FriendGetItemByObjectID(ddblObjectID);
								AcadMLineStyle acadMLineStyle = dobjAcadMLineStyle2;
								acadMLineStyle.FriendSetDictReactors = dobjDictReactors2;
								acadMLineStyle.Name = dstrName;
								acadMLineStyle.FriendLetFlags70 = dlngCode70;
								acadMLineStyle.Description = dstrDescription;
								acadMLineStyle.Color = unchecked((Enums.AcColor)dlngFillColor);
								bool flag3 = false;
								acadMLineStyle.StartAngleDegree = ddblStartAngleDegree;
								acadMLineStyle.EndAngleDegree = ddblEndAngleDegree;
								acadMLineStyle.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
								acadMLineStyle = null;
								dobjAcadMLineStyleElements2 = dobjAcadMLineStyle2.Elements;
								dobjAcadMLineStyleElements2.FriendClear();
								int num = dobjDictElementOffset2.Count - 1;
								for (int dlngIndex = 0; dlngIndex <= num; dlngIndex++)
								{
									bool flag4 = false;
									double ddblElementOffset = Conversions.ToDouble(dobjDictElementOffset2[dlngIndex]);
									int dlngElementColor = Conversions.ToInteger(dobjDictElementColor2[dlngIndex]);
									string dstrElementLinetype = Conversions.ToString(dobjDictElementLinetype2[dlngIndex]);
									AcadMLineStyleElements acadMLineStyleElements = dobjAcadMLineStyleElements2;
									object objectValue = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecElementOffset), ddblElementOffset));
									int vnumColor = dlngElementColor;
									string vstrLinetype = dstrElementLinetype;
									string nrstrErrMsg2 = "";
									acadMLineStyleElements.FriendAdd(objectValue, unchecked((Enums.AcColor)vnumColor), vstrLinetype, ref nrstrErrMsg2);
								}
							}
						}
					}
					BkDXFReadObj_AcadMLineStyle = !dblnError;
				}
				dobjDictElementLinetype2 = null;
				dobjDictElementColor2 = null;
				dobjDictElementOffset2 = null;
				dobjDictReactors2 = null;
				dobjAcadMLineStyleElements2 = null;
				dobjAcadMLineStyle2 = null;
				return BkDXFReadObj_AcadMLineStyle;
			}
		}

		public static bool BkDXFReadObj_AcadGroup(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, ref AcadGroups robjAcadGroups, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadGroup = default(bool);
				Dictionary<object, object> dobjDictGrpObjectIDs2;
				AcadEntity dobjAcadEntity2 = default(AcadEntity);
				AcadObject dobjAcadObject2 = default(AcadObject);
				AcadGroup dobjAcadGroup2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					bool dblnError = default(bool);
					if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString((dlngStartIndex + 1) * 2) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
						double vdblObjectID = ddblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbGroup", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 300, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Beschreibung in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anonymität in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Wählbarkeit in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else
					{
						string dstrDescription = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
						int dlngCode71 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
						rlngIdx += 4;
						dobjDictGrpObjectIDs2 = new Dictionary<object, object>();
						int dlngCount = 0;
						while (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 340, TextCompare: false))
						{
							double ddblGrpObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dobjDictGrpObjectIDs2.Add(dlngCount, ddblGrpObjectID);
							dlngCount++;
							rlngIdx++;
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dobjAcadGroup2 = (AcadGroup)robjAcadGroups.FriendGetItemByObjectID(ddblObjectID);
								AcadGroup acadGroup = dobjAcadGroup2;
								acadGroup.FriendSetDictReactors = dobjDictReactors2;
								acadGroup.Description = dstrDescription;
								acadGroup.FriendLetFlags70 = dlngCode70;
								acadGroup.FriendLetFlags71 = dlngCode71;
								acadGroup.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
								acadGroup = null;
								int num = dobjDictGrpObjectIDs2.Count - 1;
								for (int dlngIndex = 0; dlngIndex <= num; dlngIndex++)
								{
									double ddblGrpObjectID = Conversions.ToDouble(dobjDictGrpObjectIDs2[dlngIndex]);
									double vdblObjectID2 = ddblGrpObjectID;
									string nrstrErrMsg2 = "";
									if (!vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID2, ref dobjAcadObject2, ref nrstrErrMsg2))
									{
										nrstrErrMsg = "Objekt-ID für Gruppe '" + dobjAcadGroup2.Name + "' ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblGrpObjectID) + "' ist nicht vergeben.";
										dblnError = true;
										break;
									}
									try
									{
										dobjAcadEntity2 = (AcadEntity)dobjAcadObject2;
									}
									catch (Exception ex2)
									{
										ProjectData.SetProjectError(ex2);
										Exception ex = ex2;
										ProjectData.ClearProjectError();
									}
									if (dobjAcadEntity2 == null)
									{
										nrstrErrMsg = "Objekt-ID für Gruppe '" + dobjAcadGroup2.Name + "' ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblGrpObjectID) + "' verweist auf ein ungültiges Objekt.";
										dblnError = true;
										break;
									}
									dobjAcadGroup2.FriendAddItem(dobjAcadEntity2);
								}
							}
						}
					}
					BkDXFReadObj_AcadGroup = !dblnError;
				}
				dobjDictGrpObjectIDs2 = null;
				dobjDictReactors2 = null;
				dobjAcadEntity2 = null;
				dobjAcadObject2 = null;
				dobjAcadGroup2 = null;
				return BkDXFReadObj_AcadGroup;
			}
		}

		public static bool BkDXFReadObj_AcadMaterial(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, ref AcadMaterials robjAcadMaterials, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadMaterial = default(bool);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					bool dblnError;
					if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString((dlngStartIndex + 1) * 2) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
						double vdblObjectID = ddblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbMaterial", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						nrstrErrMsg = "NICHT VERFÜGBAR.";
						dblnError = true;
					}
					BkDXFReadObj_AcadMaterial = !dblnError;
				}
				Dictionary<object, object> dobjDictGrpObjectIDs = null;
				dobjDictReactors2 = null;
				AcadEntity dobjAcadEntity = null;
				AcadObject dobjAcadObject = null;
				AcadMaterial dobjAcadMaterial = null;
				return BkDXFReadObj_AcadMaterial;
			}
		}

		public static bool BkDXFReadObj_AcadDictionaryVar(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, ref int rlngIdx, AcadDictionary vobjAcadDictionary, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> robjDictXDictionary = null;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadDictionaryVar = default(bool);
				AcadDictionaryVar dobjAcadDictionaryVar2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref robjDictXDictionary, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					bool dblnError;
					if (!vobjAcadDatabase.FriendObjectIDExist(ddblObjectID))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString((dlngStartIndex + 1) * 2) + " ist ungültig.\nDie Objekt-ID '" + Conversions.ToString(ddblObjectID) + "' ist nicht vergeben.";
						double vdblObjectID = ddblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "DictionaryVariables", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 280, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objekt-Schema Nummer in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 1, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Variablenwert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else
					{
						int dlngObjectSchemaNumber = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
						object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							dobjAcadDictionaryVar2 = (AcadDictionaryVar)vobjAcadDictionary.FriendGetItemByObjectID(ddblObjectID);
							AcadDictionaryVar acadDictionaryVar = dobjAcadDictionaryVar2;
							acadDictionaryVar.FriendSetDictReactors = dobjDictReactors2;
							acadDictionaryVar.FriendLetObjectSchemaNumber = dlngObjectSchemaNumber;
							acadDictionaryVar.FriendLetValue = RuntimeHelpers.GetObjectValue(dvarValue);
							acadDictionaryVar.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
							acadDictionaryVar = null;
						}
					}
					BkDXFReadObj_AcadDictionaryVar = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjAcadDictionaryVar2 = null;
				return BkDXFReadObj_AcadDictionaryVar;
			}
		}

		public static bool BkDXFReadObj_AcadDictionaryEntry(int vlngSecEnd, string vstrDXFName, AcadDatabase vobjAcadDatabase, ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictCodes2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictValues2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				bool BkDXFReadObj_AcadDictionaryEntry = default(bool);
				AcadDictionaryEntry dobjAcadDictionaryEntry2 = default(AcadDictionaryEntry);
				AcadPlotConfiguration dobjAcadPlotConfiguration2;
				AcadPlotConfigurations dobjAcadPlotConfigurations2;
				AcadDictionary dobjAcadDictionary2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						string dstrObjectName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						string pcstrAcDbRasterImageDefReactor = "AcDbRasterImageDefReactor";
						string pcstrAcDbRasterVariables = "AcDbRasterVariables";
						string pcstrAcDbSortentsTable = "AcDbSortentsTable";
						string pcstrAcDbTableStyle = "AcDbTableStyle";
						string pcstrAcDbRasterImageDef = "AcDbRasterImageDef";
						string text = dstrObjectName;
						string dstrName;
						switch (text)
						{
							case "AcDbXrecord":
								dstrName = null;
								break;
							case "AcDbColor":
								dstrName = null;
								break;
							case "DictionaryVariables":
								dstrName = null;
								break;
							default:
								if (Operators.CompareString(text, pcstrAcDbRasterImageDefReactor, TextCompare: false) == 0)
								{
									dstrName = null;
									break;
								}
								if (Operators.CompareString(text, pcstrAcDbRasterVariables, TextCompare: false) == 0)
								{
									dstrName = null;
									break;
								}
								if (Operators.CompareString(text, pcstrAcDbSortentsTable, TextCompare: false) == 0)
								{
									dstrName = null;
									break;
								}
								if (Operators.CompareString(text, pcstrAcDbRasterImageDef, TextCompare: false) == 0)
								{
									dstrName = null;
									break;
								}
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 3, TextCompare: false))
								{
									dstrName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									dstrName = null;
								}
								hwpDxf_Functions.BkDXF_DebugPrint("Unbekannter DictionaryEntry: " + dstrObjectName + ", Name: " + dstrName);
								break;
						}
						if (!dblnError)
						{
							int dlngIndex = 0;
							bool dblnStop = default(bool);
							while (unchecked(rlngIdx <= vlngSecEnd && !dblnStop))
							{
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 1001, TextCompare: false))
								{
									dblnStop = true;
									continue;
								}
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 0, TextCompare: false))
								{
									dblnStop = true;
									continue;
								}
								dobjDictCodes2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadCodes[rlngIdx]));
								dobjDictValues2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]));
								dlngIndex++;
								rlngIdx++;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dobjAcadDictionary2 = (AcadDictionary)vobjAcadDatabase.Dictionaries.FriendGetItemByObjectID(ddblOwnerID);
								if (dobjAcadDictionary2 != null)
								{
									string objectName = dobjAcadDictionary2.ObjectName;
									bool dblnDebugFound = default(bool);
									if (Operators.CompareString(objectName, "AcDbDictionary", TextCompare: false) != 0)
									{
										if (Operators.CompareString(objectName, "AcDbPlotSettingsTable", TextCompare: false) == 0)
										{
											dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)dobjAcadDictionary2;
											dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)dobjAcadPlotConfigurations2.FriendGetItemByObjectID(ddblObjectID);
											hwpDxf_Functions.BkDXF_DebugPrint("BkDXFReadObj_AcadDictionaryEntry: PlotConfiguration: " + Conversions.ToString(ddblObjectID));
											dblnDebugFound = true;
										}
										else
										{
											hwpDxf_Functions.BkDXF_DebugPrint(Versioned.TypeName(dobjAcadDictionary2) + " " + dobjAcadDictionary2.ObjectName);
											dobjAcadDictionaryEntry2 = (AcadDictionaryEntry)dobjAcadDictionary2.FriendGetItemByObjectID(ddblObjectID);
										}
									}
									else
									{
										dobjAcadDictionaryEntry2 = (AcadDictionaryEntry)dobjAcadDictionary2.FriendGetItemByObjectID(ddblObjectID);
									}
									if (dobjAcadDictionaryEntry2 != null)
									{
										AcadDictionaryEntry acadDictionaryEntry = dobjAcadDictionaryEntry2;
										acadDictionaryEntry.FriendSetDictCodes = dobjDictCodes2;
										acadDictionaryEntry.FriendSetDictValues = dobjDictValues2;
										acadDictionaryEntry.FriendSetDictReactors = dobjDictReactors2;
										if (dobjDictXDictionary2.Count > 0)
										{
											acadDictionaryEntry.FriendSetDictXDictionary = dobjDictXDictionary2;
										}
										acadDictionaryEntry.FriendLetDXFName = vstrDXFName;
										acadDictionaryEntry.FriendLetObjectName = dstrObjectName;
										acadDictionaryEntry.FriendLetName = dstrName;
										acadDictionaryEntry.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadDictionaryEntry = null;
									}
									else if (!dblnDebugFound)
									{
										hwpDxf_Functions.BkDXF_DebugPrint("BkDXFReadObj_AcadDictionaryEntry: Entry Unbekannt: " + Conversions.ToString(ddblObjectID));
									}
								}
								else
								{
									hwpDxf_Functions.BkDXF_DebugPrint("BkDXFReadObj_AcadDictionaryEntry: Dictionary Unbekannt: " + Conversions.ToString(ddblOwnerID));
								}
							}
						}
					}
					BkDXFReadObj_AcadDictionaryEntry = !dblnError;
				}
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				dobjAcadDictionaryEntry2 = null;
				dobjAcadPlotConfiguration2 = null;
				dobjAcadPlotConfigurations2 = null;
				dobjAcadDictionary2 = null;
				dobjDictValues2 = null;
				dobjDictCodes2 = null;
				return BkDXFReadObj_AcadDictionaryEntry;
			}
		}

		public static bool BkDXFReadObj_AcadObjectPointer(int vlngSecEnd, string vstrDXFName, AcadDatabase vobjAcadDatabase, ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngStartIndex = rlngIdx;
			Dictionary<object, object> dobjDictCodes2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictValues2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			double ddblLineOwnerID = default(double);
			bool BkDXFReadObj_AcadObjectPointer = default(bool);
			AcadDictionaryEntry dobjAcadDictionaryEntry2;
			AcadDictionary dobjAcadDictionary2;
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg, nvblnDoNotCheckObjectID: true))
			{
				int dlngIndex = 0;
				bool dblnStop = default(bool);
				while (rlngIdx <= vlngSecEnd && !dblnStop)
				{
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 1001, TextCompare: false))
					{
						dblnStop = true;
						continue;
					}
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 0, TextCompare: false))
					{
						dblnStop = true;
						continue;
					}
					dobjDictCodes2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadCodes[rlngIdx]));
					dobjDictValues2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]));
					checked
					{
						dlngIndex++;
						rlngIdx++;
					}
				}
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				bool dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
				if (!dblnError)
				{
					dobjAcadDictionary2 = (AcadDictionary)vobjAcadDatabase.Dictionaries.FriendGetItemByObjectID(ddblOwnerID);
					if (dobjAcadDictionary2 != null)
					{
						dobjAcadDictionaryEntry2 = (AcadDictionaryEntry)dobjAcadDictionary2.FriendGetItemByObjectID(ddblObjectID);
						if (dobjAcadDictionaryEntry2 != null)
						{
							AcadDictionaryEntry acadDictionaryEntry = dobjAcadDictionaryEntry2;
							acadDictionaryEntry.FriendSetDictCodes = dobjDictCodes2;
							acadDictionaryEntry.FriendSetDictValues = dobjDictValues2;
							acadDictionaryEntry.FriendSetDictReactors = dobjDictReactors2;
							if (dobjDictXDictionary2.Count > 0)
							{
								acadDictionaryEntry.FriendSetDictXDictionary = dobjDictXDictionary2;
							}
							acadDictionaryEntry.FriendLetDXFName = vstrDXFName;
							string dstrObjectName = default(string);
							acadDictionaryEntry.FriendLetObjectName = dstrObjectName;
							acadDictionaryEntry.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
							acadDictionaryEntry = null;
						}
						else
						{
							hwpDxf_Functions.BkDXF_DebugPrint("BkDXFReadObj_AcadObjectPointer: Entry Unbekannt: " + Conversions.ToString(ddblObjectID));
						}
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint("BkDXFReadObj_AcadObjectPointer: Dictionary Unbekannt: " + Conversions.ToString(ddblOwnerID));
					}
				}
				BkDXFReadObj_AcadObjectPointer = !dblnError;
			}
			dobjDictXDictionary2 = null;
			dobjDictReactors2 = null;
			dobjAcadDictionaryEntry2 = null;
			dobjAcadDictionary2 = null;
			dobjDictValues2 = null;
			dobjDictCodes2 = null;
			return BkDXFReadObj_AcadObjectPointer;
		}
	}
}
