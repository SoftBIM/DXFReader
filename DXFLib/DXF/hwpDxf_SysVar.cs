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
	class hwpDxf_SysVar
	{
		public static object BkDXFSysVar_ConvertValue(VariantType vnumVarType, object vvarValue)
		{
			checked
			{
				object dvarConvertValue2 = default(object);
				switch (vnumVarType)
				{
					case VariantType.Boolean:
						dvarConvertValue2 = Conversions.ToBoolean(vvarValue);
						break;
					case VariantType.Byte:
						dvarConvertValue2 = Conversions.ToByte(vvarValue);
						break;
					case VariantType.Decimal:
						dvarConvertValue2 = Conversions.ToDouble(vvarValue);
						dvarConvertValue2 = ((!Operators.ConditionalCompareObjectGreaterEqual(dvarConvertValue2, decimal.MaxValue, TextCompare: false)) ? ((!Operators.ConditionalCompareObjectLessEqual(dvarConvertValue2, decimal.MinValue, TextCompare: false)) ? ((object)Conversions.ToDecimal(vvarValue)) : ((object)decimal.MinValue)) : ((object)decimal.MaxValue));
						break;
					case VariantType.Date:
						dvarConvertValue2 = Conversions.ToDate(vvarValue);
						break;
					case VariantType.Double:
						dvarConvertValue2 = Conversions.ToDouble(vvarValue);
						break;
					case VariantType.Short:
						dvarConvertValue2 = Conversions.ToShort(vvarValue);
						break;
					case VariantType.Integer:
						dvarConvertValue2 = Conversions.ToInteger(vvarValue);
						break;
					case VariantType.Single:
						dvarConvertValue2 = Conversions.ToSingle(vvarValue);
						break;
					case VariantType.String:
						dvarConvertValue2 = Conversions.ToString(vvarValue);
						break;
					case (VariantType)8201:
						if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) == VariantType.Array)
						{
							bool flag = false;
							double[] dadblValue = new double[Information.UBound((Array)vvarValue) + 1];
							int num = Information.LBound((Array)vvarValue);
							int num2 = Information.UBound((Array)vvarValue);
							for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
							{
								dadblValue[dlngIdx] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvarValue, new object[1]
								{
							dlngIdx
								}, null));
							}
							dvarConvertValue2 = Support.CopyArray(dadblValue);
						}
						else
						{
							dvarConvertValue2 = RuntimeHelpers.GetObjectValue(vvarValue);
						}
						break;
				}
				return RuntimeHelpers.GetObjectValue(dvarConvertValue2);
			}
		}

		public static string BkDXFSysVar_StringValue(VariantType vnumVarType, object vvarValue, bool nvblnCommaString = true)
		{
			string dstrStringValue = default(string);
			if (vvarValue == null)
			{
				dstrStringValue = null;
			}
			else
			{
				switch (vnumVarType)
				{
					case VariantType.Boolean:
						dstrStringValue = Conversions.ToString(Interaction.IIf(Conversions.ToBoolean(vvarValue), "Wahr", "Falsch"));
						break;
					case VariantType.Byte:
						dstrStringValue = Conversions.ToString(Conversions.ToByte(vvarValue));
						break;
					case VariantType.Decimal:
						dstrStringValue = Strings.Replace(Conversions.ToString(Conversions.ToDecimal(vvarValue)), ",", ".");
						break;
					case VariantType.Date:
						dstrStringValue = Conversions.ToString(Conversions.ToDate(vvarValue));
						break;
					case VariantType.Double:
						dstrStringValue = Strings.Replace(Conversions.ToString(Conversions.ToDouble(vvarValue)), ",", ".");
						break;
					case VariantType.Short:
						dstrStringValue = Conversions.ToString((int)Conversions.ToShort(vvarValue));
						break;
					case VariantType.Integer:
						dstrStringValue = Conversions.ToString(Conversions.ToInteger(vvarValue));
						break;
					case VariantType.Single:
						dstrStringValue = Conversions.ToString(Conversions.ToSingle(vvarValue));
						break;
					case VariantType.String:
						dstrStringValue = ((!nvblnCommaString) ? Conversions.ToString(vvarValue) : ("'" + Conversions.ToString(vvarValue) + "'"));
						break;
					case (VariantType)8201:
						if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) == VariantType.Array)
						{
							bool flag = false;
							int num = Information.LBound((Array)vvarValue);
							int num2 = Information.UBound((Array)vvarValue);
							for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
							{
								dstrStringValue = dstrStringValue + ", " + Strings.Replace(Conversions.ToString(Conversions.ToDouble(NewLateBinding.LateIndexGet(vvarValue, new object[1]
								{
							dlngIdx
								}, null))), ",", ".");
							}
							dstrStringValue = Strings.LTrim(Strings.Mid(dstrStringValue, 2));
						}
						else
						{
							dstrStringValue = null;
						}
						break;
				}
			}
			return dstrStringValue;
		}

		public static bool BkDXFSysVar_CheckType(string vstrVarName, VariantType vnumVarType, object vvarArraySize, object vvarValue, ref string rstrErrMsg)
		{
			rstrErrMsg = null;
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != vnumVarType && vnumVarType != VariantType.Char && vnumVarType != VariantType.Decimal && vnumVarType != VariantType.Short)
			{
				hwpDxf_Functions.BkDXF_DebugPrint("1: " + vstrVarName + " " + Conversions.ToString((int)Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) + " " + Conversions.ToString((int)vnumVarType));
				rstrErrMsg = vstrVarName + "\nUngültiger Variablentyp. Soll: " + vnumVarType.ToString() + ", Ist: " + Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue));
			}
			else if (((Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.Char) & (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.String)) && vnumVarType == VariantType.Char)
			{
				hwpDxf_Functions.BkDXF_DebugPrint("2: " + vstrVarName + " " + Conversions.ToString((int)Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) + " " + Conversions.ToString((int)vnumVarType));
				rstrErrMsg = vstrVarName + "\nUngültiger Variablentyp. Soll: " + vnumVarType.ToString() + ", Ist: " + Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue));
			}
			else if (((Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.Decimal) & (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.Double)) && vnumVarType == VariantType.Decimal)
			{
				hwpDxf_Functions.BkDXF_DebugPrint("3: " + vstrVarName + " " + Conversions.ToString((int)Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) + " " + Conversions.ToString((int)vnumVarType));
				rstrErrMsg = vstrVarName + "\nUngültiger Variablentyp. Soll: " + vnumVarType.ToString() + ", Ist: " + Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue));
			}
			else if (((Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.Short) & (Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue)) != VariantType.Integer)) && vnumVarType == VariantType.Short)
			{
				hwpDxf_Functions.BkDXF_DebugPrint("4: " + vstrVarName + " " + Conversions.ToString((int)Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue))) + " " + Conversions.ToString((int)vnumVarType));
				rstrErrMsg = vstrVarName + "\nUngültiger Variablentyp. Soll: " + vnumVarType.ToString() + ", Ist: " + Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue));
			}
			else
			{
				if ((VariantType.Array & vnumVarType) != VariantType.Array)
				{
					return true;
				}
				if (vvarArraySize != null)
				{
					if (!Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(Information.UBound((Array)vvarValue), Operators.SubtractObject(vvarArraySize, 1), TextCompare: false))))
					{
						return true;
					}
					rstrErrMsg = "Ungültige Arraygröße für Variable.";
				}
			}
			bool BkDXFSysVar_CheckType = default(bool);
			return BkDXFSysVar_CheckType;
		}
	}
}
