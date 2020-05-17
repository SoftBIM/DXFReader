using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_ReadBas
	{
		//public static bool BkDXFReadBas_Bracket(string vstrBracketName, object vvarGrpCodes, ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref Dictionary<object, object> robjDictBracket, ref string nrstrErrMsg = "")
		//{
		//	nrstrErrMsg = null;
		//	robjDictBracket.Clear();
		//	checked
		//	{
		//		bool dblnError = default(bool);
		//		if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 102, TextCompare: false))
		//		{
		//			if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], vstrBracketName, TextCompare: false))
		//			{
		//				nrstrErrMsg = "Ungültiger Anfang der Gruppe " + vstrBracketName + "} in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
		//				dblnError = true;
		//			}
		//			else
		//			{
		//				rlngIdx++;
		//				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
		//				while (unchecked(dlngCode != 102 && !dblnError))
		//				{
		//					bool dblnFound = false;
		//					int num = Information.LBound((Array)vvarGrpCodes);
		//					int num2 = Information.UBound((Array)vvarGrpCodes);
		//					for (int dlngIndex = num; dlngIndex <= num2; dlngIndex++)
		//					{
		//						if (!dblnFound)
		//						{
		//							dblnFound = Operators.ConditionalCompareObjectEqual(dlngCode, NewLateBinding.LateIndexGet(vvarGrpCodes, new object[1]
		//							{
		//							dlngIndex
		//							}, null), TextCompare: false);
		//						}
		//					}
		//					if (!dblnFound)
		//					{
		//						nrstrErrMsg = "Ungültiger Gruppencode für Gruppe " + vstrBracketName + "} in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
		//						dblnError = true;
		//						continue;
		//					}
		//					try
		//					{
		//						robjDictBracket.Add(RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]), dlngCode);
		//					}
		//					catch (Exception ex2)
		//					{
		//						ProjectData.SetProjectError(ex2);
		//						Exception ex = ex2;
		//						nrstrErrMsg = "Ungültiger oder doppelter Wert für Gruppe " + vstrBracketName + "} in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
		//						dblnError = true;
		//						ProjectData.ClearProjectError();
		//					}
		//					if (!dblnError)
		//					{
		//						rlngIdx++;
		//						dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
		//					}
		//				}
		//				if (!dblnError)
		//				{
		//					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "}", TextCompare: false))
		//					{
		//						nrstrErrMsg = "Fehlende Endklammer für Gruppe " + vstrBracketName + "} in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
		//						dblnError = true;
		//					}
		//					else
		//					{
		//						rlngIdx++;
		//					}
		//				}
		//			}
		//		}
		//		return !dblnError;
		//	}
		//}

		//public static bool BkDXFReadBas_Reactors(ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref Dictionary<object, object> robjDictReactors, ref string nrstrErrMsg = "")
		//{
		//	nrstrErrMsg = null;
		//	robjDictReactors.Clear();
		//	return BkDXFReadBas_Bracket("{ACAD_REACTORS", new object[1]
		//	{
		//	330
		//	}, ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictReactors, ref nrstrErrMsg);
		//}

		//public static bool BkDXFReadBas_XDictionary(ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref Dictionary<object, object> robjDictXDictionary, ref string nrstrErrMsg = "")
		//{
		//	nrstrErrMsg = null;
		//	robjDictXDictionary.Clear();
		//	return BkDXFReadBas_Bracket("{ACAD_XDICTIONARY", new object[1]
		//	{
		//	360
		//	}, ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictXDictionary, ref nrstrErrMsg);
		//}

		//public static bool BkDXFReadBas_Blkrefs(ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref Dictionary<object, object> robjDictBlockrefs, ref string nrstrErrMsg = "")
		//{
		//	nrstrErrMsg = null;
		//	robjDictBlockrefs.Clear();
		//	return BkDXFReadBas_Bracket("{BLKREFS", new object[2]
		//	{
		//	331,
		//	331
		//	}, ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictBlockrefs, ref nrstrErrMsg);
		//}

		//public static void BkDXFReadBas_PreviewIcon(ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref Dictionary<object, object> robjDictPreviewIcon)
		//{
		//	robjDictPreviewIcon.Clear();
		//	checked
		//	{
		//		if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 310, TextCompare: false))
		//		{
		//			int dlngCount = 0;
		//			while (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 310, TextCompare: false))
		//			{
		//				robjDictPreviewIcon.Add(dlngCount, RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]));
		//				dlngCount++;
		//				rlngIdx++;
		//			}
		//		}
		//	}
		//}

		//public static bool BkDXFReadBas_XData(ref int rlngIdx, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref object rvarXDataType, ref object rvarXDataValue, ref string nrstrErrMsg = "")
		//{
		//	object[] dadecArrayValue = new object[3];
		//	double[] dadblArrayValue = new double[3];
		//	nrstrErrMsg = null;
		//	checked
		//	{
		//		bool dblnError = default(bool);
		//		if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 1001, TextCompare: false))
		//		{
		//			int dlngCount = -1;
		//			short dintNextCode = -1;
		//			bool dblnIsArray = false;
		//			int dlngArrayCount = 0;
		//			Dictionary<object, object> dobjDictXDataType = new Dictionary<object, object>();
		//			Dictionary<object, object> dobjDictXDataValue = new Dictionary<object, object>();
		//			short dintArrayCode = default(short);
		//			while (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vobjDictReadCodes[rlngIdx], 1000, TextCompare: false), !dblnError)))
		//			{
		//				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
		//				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
		//				if (!hwpDxf_XData.BkDXFXData_TypeIsValid(dlngCode))
		//				{
		//					nrstrErrMsg = "Ungültiger Gruppencode für Erweiterungsdaten in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
		//					dblnError = true;
		//				}
		//				else if (!hwpDxf_XData.BkDXFXData_ValueIsValid(dlngCode, RuntimeHelpers.GetObjectValue(dvarValue)))
		//				{
		//					nrstrErrMsg = "Ungültiger Wert für Erweiterungsdaten in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
		//					dblnError = true;
		//				}
		//				else
		//				{
		//					short dintCode = (short)dlngCode;
		//					if (dblnIsArray)
		//					{
		//						if (dintCode != dintNextCode)
		//						{
		//							nrstrErrMsg = "Ungültiger Gruppencode für Koordinate in Erweiterungsdaten in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
		//							dblnError = true;
		//						}
		//						else if (dlngArrayCount == 1)
		//						{
		//							dlngArrayCount++;
		//							bool flag = false;
		//							dadblArrayValue[1] = Conversions.ToDouble(dvarValue);
		//							hwpDxf_XData.BkDXFXData_IsArrayCode(dintCode, ref dintNextCode);
		//						}
		//						else
		//						{
		//							dblnIsArray = false;
		//							dlngArrayCount = 0;
		//							bool flag2 = false;
		//							dadblArrayValue[2] = Conversions.ToDouble(dvarValue);
		//							dintCode = dintArrayCode;
		//							dvarValue = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecArrayValue, dadblArrayValue));
		//						}
		//					}
		//					else if (hwpDxf_XData.BkDXFXData_IsArrayCode(dintCode, ref dintNextCode))
		//					{
		//						dblnIsArray = true;
		//						dlngArrayCount++;
		//						dintArrayCode = dintCode;
		//						bool flag3 = false;
		//						dadblArrayValue[0] = Conversions.ToDouble(dvarValue);
		//					}
		//					if (!dblnIsArray)
		//					{
		//						dlngCount++;
		//						dobjDictXDataType.Add(dlngCount, dintCode);
		//						dobjDictXDataValue.Add(dlngCount, RuntimeHelpers.GetObjectValue(dvarValue));
		//					}
		//				}
		//				rlngIdx++;
		//			}
		//			if (!dblnError)
		//			{
		//				rvarXDataType = new object[dlngCount + 1];
		//				rvarXDataValue = new object[dlngCount + 1];
		//				int num = dlngCount;
		//				for (int dlngIndex = 0; dlngIndex <= num; dlngIndex++)
		//				{
		//					NewLateBinding.LateIndexSet(rvarXDataType, new object[2]
		//					{
		//					dlngIndex,
		//					dobjDictXDataType[dlngIndex]
		//					}, null);
		//					NewLateBinding.LateIndexSet(rvarXDataValue, new object[2]
		//					{
		//					dlngIndex,
		//					dobjDictXDataValue[dlngIndex]
		//					}, null);
		//				}
		//			}
		//		}
		//		return !dblnError;
		//	}
		//}

		//public static void BkDXFReadBas_UnknownObject(ref int rlngIdx, int vlngSecEnd, Dictionary<object, object> vobjDictReadCodes)
		//{
		//	bool dblnStop = default(bool);
		//	while (rlngIdx <= vlngSecEnd && !dblnStop)
		//	{
		//		checked
		//		{
		//			if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 0, TextCompare: false))
		//			{
		//				dblnStop = true;
		//			}
		//			else
		//			{
		//				rlngIdx++;
		//			}
		//		}
		//	}
		//}
	}
}
