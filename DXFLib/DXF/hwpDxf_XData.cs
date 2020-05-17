using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class hwpDxf_XData
	{
		//public static bool BkDXFXData_IsArrayCode(short vintCode, ref short nrintNextCode = 0)
		//{
		//	nrintNextCode = -1;
		//	checked
		//	{
		//		bool dblnValid = default(bool);
		//		switch (vintCode)
		//		{
		//			case 1010:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1020:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1030:
		//				dblnValid = true;
		//				break;
		//			case 1011:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1021:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1031:
		//				dblnValid = true;
		//				break;
		//			case 1012:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1022:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1032:
		//				dblnValid = true;
		//				break;
		//			case 1013:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1023:
		//				dblnValid = true;
		//				nrintNextCode = (short)unchecked(vintCode + 10);
		//				break;
		//			case 1033:
		//				dblnValid = true;
		//				break;
		//		}
		//		return dblnValid;
		//	}
		//}

		public static bool BkDXFXData_TypeIsValid(int vlngXDataType, bool nvblnWithAppName = true, bool nvblnExtCoords = true)
		{
			switch (vlngXDataType)
			{
				case 1000:
					return true;
				case 1001:
					return nvblnWithAppName;
				case 1002:
					return true;
				case 1003:
					return true;
				case 1004:
					return true;
				case 1005:
					return true;
				case 1010:
					return true;
				case 1020:
					return nvblnExtCoords;
				case 1030:
					return nvblnExtCoords;
				case 1011:
					return true;
				case 1021:
					return nvblnExtCoords;
				case 1031:
					return nvblnExtCoords;
				case 1012:
					return true;
				case 1022:
					return nvblnExtCoords;
				case 1032:
					return nvblnExtCoords;
				case 1013:
					return true;
				case 1023:
					return nvblnExtCoords;
				case 1033:
					return nvblnExtCoords;
				case 1040:
					return true;
				case 1041:
					return true;
				case 1042:
					return true;
				case 1070:
					return true;
				case 1071:
					return true;
				default:
					{
						bool dblnValid = default(bool);
						return dblnValid;
					}
			}
		}

		public static bool BkDXFXData_ValueIsValid(int vlngXDataType, object vvarXDataValue, bool nvblnWithAppName = true, bool nvblnExtCoords = true)
		{
			VariantType dnumVarType = Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataValue));
			switch (vlngXDataType)
			{
				case 1000:
					if (dnumVarType == VariantType.String)
					{
						return Strings.Len(RuntimeHelpers.GetObjectValue(vvarXDataValue)) <= 255;
					}
					break;
				case 1001:
					if (nvblnWithAppName && dnumVarType == VariantType.String)
					{
						return Strings.Len(RuntimeHelpers.GetObjectValue(vvarXDataValue)) <= 255;
					}
					break;
				case 1002:
					if (dnumVarType == VariantType.String)
					{
						return Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(vvarXDataValue, "{", TextCompare: false), Operators.CompareObjectEqual(vvarXDataValue, "}", TextCompare: false)));
					}
					break;
				case 1003:
					if (dnumVarType == VariantType.String)
					{
						return true;
					}
					break;
				case 1004:
					if (dnumVarType == VariantType.String)
					{
						return true;
					}
					break;
				case 1005:
					if (dnumVarType == VariantType.String)
					{
						return true;
					}
					break;
				case 1010:
					if (nvblnExtCoords)
					{
						if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
						{
							return true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, (VariantType)8201, (VariantType)8197), TextCompare: false))
					{
						return (Information.LBound((Array)vvarXDataValue) == 0) & (Information.UBound((Array)vvarXDataValue) == 2);
					}
					break;
				case 1020:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1030:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1011:
					if (nvblnExtCoords)
					{
						if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
						{
							return true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, (VariantType)8201, (VariantType)8197), TextCompare: false))
					{
						return (Information.LBound((Array)vvarXDataValue) == 0) & (Information.UBound((Array)vvarXDataValue) == 2);
					}
					break;
				case 1021:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1031:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1012:
					if (nvblnExtCoords)
					{
						if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
						{
							return true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, (VariantType)8201, (VariantType)8197), TextCompare: false))
					{
						return (Information.LBound((Array)vvarXDataValue) == 0) & (Information.UBound((Array)vvarXDataValue) == 2);
					}
					break;
				case 1022:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1032:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1013:
					if (nvblnExtCoords)
					{
						if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
						{
							return true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, (VariantType)8201, (VariantType)8197), TextCompare: false))
					{
						return (Information.LBound((Array)vvarXDataValue) == 0) & (Information.UBound((Array)vvarXDataValue) == 2);
					}
					break;
				case 1023:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1033:
					if (nvblnExtCoords && Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1040:
					if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1041:
					if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1042:
					if (Operators.ConditionalCompareObjectEqual(dnumVarType, Interaction.IIf(Expression: false, VariantType.Decimal, VariantType.Double), TextCompare: false))
					{
						return true;
					}
					break;
				case 1070:
					if (dnumVarType == VariantType.Short)
					{
						return true;
					}
					break;
				case 1071:
					if (dnumVarType == VariantType.Integer)
					{
						return true;
					}
					break;
			}
			bool dblnValid = default(bool);
			return dblnValid;
		}

		public static string BkDXFXData_ValueToString(object vvarXDataValue)
		{
			switch (Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataValue)))
			{
				case VariantType.String:
					return Conversions.ToString(vvarXDataValue);
				case VariantType.Double:
					return Conversions.ToString(vvarXDataValue);
				case VariantType.Decimal:
					return Conversions.ToString(vvarXDataValue);
				case (VariantType)8201:
					{
						int num = Information.LBound((Array)vvarXDataValue);
						int num2 = Information.UBound((Array)vvarXDataValue);
						string dstrValue = default(string);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
						{
							dstrValue = dstrValue + " " + Conversions.ToString(NewLateBinding.LateIndexGet(vvarXDataValue, new object[1]
							{
					dlngIdx
							}, null));
						}
						return Strings.Mid(dstrValue, 2);
					}
				case VariantType.Short:
					return Conversions.ToString(vvarXDataValue);
				case VariantType.Integer:
					return Conversions.ToString(vvarXDataValue);
				default:
					return "Unbekannt";
			}
		}

		//public static bool BkDXFXData_Check(object vvarXDataType, object vvarXDataValue, bool nvblnWithAppName = true, bool nvblnExtCoords = true, ref string nrstrErrMsg = "")
		//{
		//	nrstrErrMsg = null;
		//	if (((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataType))) != VariantType.Array) | ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataValue))) != VariantType.Array))
		//	{
		//		nrstrErrMsg = "Keine gültigen Arrays.";
		//	}
		//	else
		//	{
		//		int dlngLBoundXDataType = Information.LBound((Array)vvarXDataType);
		//		int dlngLBoundXDataValue = Information.LBound((Array)vvarXDataValue);
		//		int dlngUBoundXDataType = Information.UBound((Array)vvarXDataType);
		//		int dlngUBoundXDataValue = Information.UBound((Array)vvarXDataValue);
		//		if (dlngLBoundXDataType != dlngLBoundXDataValue || dlngUBoundXDataType != dlngUBoundXDataValue || dlngLBoundXDataType != 0)
		//		{
		//			nrstrErrMsg = "Arrays besitzen unterschiedliche Grenzen.";
		//		}
		//		else
		//		{
		//			int num = dlngLBoundXDataType;
		//			int num2 = dlngUBoundXDataType;
		//			int dlngIdx = num;
		//			checked
		//			{
		//				while (true)
		//				{
		//					if (dlngIdx <= num2)
		//					{
		//						object dvarXDataType = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarXDataType, new object[1]
		//						{
		//						dlngIdx
		//						}, null));
		//						object dvarXDataValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarXDataValue, new object[1]
		//						{
		//						dlngIdx
		//						}, null));
		//						if (Information.VarType(RuntimeHelpers.GetObjectValue(dvarXDataType)) != VariantType.Short)
		//						{
		//							nrstrErrMsg = Conversions.ToString(dlngIdx + 1) + ". Gruppencode-Variablentyp ist ungültig.";
		//							break;
		//						}
		//						if (!BkDXFXData_TypeIsValid(Conversions.ToInteger(dvarXDataType), nvblnWithAppName, nvblnExtCoords))
		//						{
		//							nrstrErrMsg = Conversions.ToString(dlngIdx + 1) + ". Gruppencode ist ungültig.";
		//							break;
		//						}
		//						if (!BkDXFXData_ValueIsValid(Conversions.ToInteger(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), nvblnWithAppName, nvblnExtCoords))
		//						{
		//							nrstrErrMsg = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Conversions.ToString(dlngIdx + 1) + ". Wert ist für Gruppencode ", dvarXDataType), " ungültig."));
		//							break;
		//						}
		//						dlngIdx++;
		//						continue;
		//					}
		//					return true;
		//				}
		//			}
		//		}
		//	}
		//	bool BkDXFXData_Check = default(bool);
		//	return BkDXFXData_Check;
		//}
	}
}
