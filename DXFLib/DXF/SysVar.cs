using DXFLib.Acad;
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
    public class SysVar
	{
		private const string cstrClassName = "SysVar";

		private bool mblnOpened;

		private string mstrName;

		private string mstrDescription;

		private VariantType mnumVarType;

		private string mstrVarTypeName;

		private object mvarArraySize;

		private bool mblnReadOnly;

		private object mvarDefault;

		private string mstrDefaultString;

		private object mblnDefaultByInit;

		private hwpDxf_Enums.SAVE_TYPE mnumSaveType;

		private string mstrSaveTypeName;

		private hwpDxf_Enums.PREF_TAB mnumPrefTab;

		private string mstrPrefTabName;

		private hwpDxf_Enums.SYMBOL_TABLE mnumSymTable;

		private string mstrSymTableName;

		private object mvarEmptyValue;

		private bool mblnUnitsRef;

		private bool mblnIsColor;

		private bool mblnIsDimValue;

		private object mvarMinValue;

		private string mstrMinValueString;

		private object mvarMaxValue;

		private string mstrMaxValueString;

		private object mvarBitValue;

		private string mstrBitValueString;

		private object mvarLstValues;

		private object mstrLstValuesString;

		private bool mblnRunTimeErr;

		private bool mblnIsUnitsBase;

		private object mvarHeaderCode;

		private string mstrHeaderCodeString;

		private object mvarHeaderPos;

		private string mstrHeaderPosString;

		private hwpDxf_Enums.REF_TYPE mnumRefType;

		private string mstrRefTypeName;

		private double mdblObjectID;

		private string mstrDwgStartAcadVer;

		private string mstrDwgEndAcadVer;

		private string mstrDxfStartAcadVer;

		private string mstrDxfEndAcadVer;

		private NodeObject mobjNodeObject;

		internal object FriendGetBitValueString => mstrBitValueString;

		internal string FriendGetDefaultString => mstrDefaultString;

		internal string FriendGetHeaderCodeString => mstrHeaderCodeString;

		internal string FriendGetHeaderPosString => mstrHeaderPosString;

		internal string FriendGetLstValuesString => Conversions.ToString(mstrLstValuesString);

		internal object FriendGetMaxValueString => mstrMaxValueString;

		internal string FriendGetMinValueString => mstrMinValueString;

		internal string FriendGetPrefTabName => mstrPrefTabName;

		internal string FriendGetRefTypeName => mstrRefTypeName;

		internal bool FriendGetRunTimeErr => mblnRunTimeErr;

		internal string FriendGetSaveTypeName => mstrSaveTypeName;

		internal string FriendGetSymTableName => mstrSymTableName;

		internal string FriendGetVarTypeName => mstrVarTypeName;

		public object ArraySize => RuntimeHelpers.GetObjectValue(mvarArraySize);

		public object BitValue => RuntimeHelpers.GetObjectValue(mvarBitValue);

		public object Default_Renamed => RuntimeHelpers.GetObjectValue(mvarDefault);

		public bool DefaultByInit => Conversions.ToBoolean(mblnDefaultByInit);

		public string Description => mstrDescription;

		public object EmptyValue => RuntimeHelpers.GetObjectValue(mvarEmptyValue);

		public object HeaderCode => RuntimeHelpers.GetObjectValue(mvarHeaderCode);

		public object HeaderPos => RuntimeHelpers.GetObjectValue(mvarHeaderPos);

		public bool IsBoolean
		{
			get
			{
				if ((mvarMinValue != null) & (mvarMaxValue != null))
				{
					return Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(mvarMinValue, 0, TextCompare: false), Operators.CompareObjectEqual(mvarMaxValue, 1, TextCompare: false)));
				}
				bool dblnIsBoolean = default(bool);
				return dblnIsBoolean;
			}
		}

		public bool IsColor => mblnIsColor;

		public bool IsDimValue => mblnIsDimValue;

		public bool IsUnitsBase => mblnIsUnitsBase;

		public object LstValues => RuntimeHelpers.GetObjectValue(mvarLstValues);

		public object MaxValue => RuntimeHelpers.GetObjectValue(mvarMaxValue);

		public object MinValue => RuntimeHelpers.GetObjectValue(mvarMinValue);

		public string Name => mstrName;

		public int PrefTab => (int)mnumPrefTab;

		public int RefType => (int)mnumRefType;

		public bool ReadOnly_Renamed => mblnReadOnly;

		public int SaveType => (int)mnumSaveType;

		public int SymTable => (int)mnumSymTable;

		public bool UnitsRef => mblnUnitsRef;

		public VariantType VarType_Renamed => mnumVarType;

		public double ObjectID => mdblObjectID;

		public string Reference
		{
			get
			{
				if (mdblObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblObjectID);
				}
				return null;
			}
		}

		public string DwgStartAcadVer => mstrDwgStartAcadVer;

		public string DwgEndAcadVer => mstrDwgEndAcadVer;

		public string DxfStartAcadVer => mstrDxfStartAcadVer;

		public string DxfEndAcadVer => mstrDxfEndAcadVer;

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
			mstrName = null;
			mstrDescription = null;
			mnumVarType = VariantType.Null;
			mstrVarTypeName = null;
			mvarArraySize = null;
			mblnReadOnly = false;
			mvarDefault = null;
			mstrDefaultString = "-";
			mblnDefaultByInit = false;
			mnumSaveType = hwpDxf_Enums.SAVE_TYPE.stUnknown;
			mstrSaveTypeName = "Unbekannt";
			mnumPrefTab = hwpDxf_Enums.PREF_TAB.ptUnknown;
			mstrPrefTabName = "Unbekannt";
			mnumSymTable = hwpDxf_Enums.SYMBOL_TABLE.symNone;
			mstrSymTableName = "Keine";
			mvarEmptyValue = null;
			mblnUnitsRef = false;
			mblnIsColor = false;
			mblnIsDimValue = false;
			mvarMinValue = null;
			mstrMinValueString = "-";
			mvarMaxValue = null;
			mstrMaxValueString = "-";
			mvarBitValue = null;
			mstrBitValueString = "-";
			mvarLstValues = null;
			mstrLstValuesString = "-";
			mblnRunTimeErr = false;
			mblnIsUnitsBase = false;
			mvarHeaderCode = null;
			mstrHeaderCodeString = "-";
			mvarHeaderPos = null;
			mstrHeaderPosString = "-";
			mnumRefType = hwpDxf_Enums.REF_TYPE.rtUnknown;
			mstrRefTypeName = "Unbekannt";
			mdblObjectID = -1.0;
			mstrDwgStartAcadVer = "";
			mstrDwgEndAcadVer = "";
			mstrDxfStartAcadVer = "";
			mstrDxfEndAcadVer = "";
		}

		public SysVar()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SysVar()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mblnOpened = false;
			}
		}

		internal void FriendInit(bool vblnUnitsRef, string vstrName, string vstrDescription, VariantType vnumVarType, object vvarArraySize, bool vblnReadOnly, object vvarDefault, object vvarMinValue, object vvarMaxValue, object vvarLstValues, object vvarBitValue, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, bool vblnIsUnitsBase, hwpDxf_Enums.SYMBOL_TABLE vnumSymTable, bool vblnIsColor, object vvarEmptyValue, bool vblnIsDimValue, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			mblnUnitsRef = vblnUnitsRef;
			mstrName = vstrName;
			mstrDescription = vstrDescription;
			mnumVarType = vnumVarType;
			checked
			{
				if (vvarArraySize == null)
				{
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(vvarDefault))) == VariantType.Array)
					{
						mvarArraySize = Information.UBound((Array)vvarDefault) + 1;
					}
					else
					{
						mvarArraySize = null;
					}
				}
				else
				{
					mvarArraySize = RuntimeHelpers.GetObjectValue(vvarArraySize);
				}
				switch (mnumVarType)
				{
					case VariantType.Double:
						mstrVarTypeName = "Reele Zahl (Kurz)";
						break;
					case VariantType.Decimal:
						mstrVarTypeName = "Reele Zahl (Lang)";
						break;
					case VariantType.Short:
						mstrVarTypeName = "Ganzzahl (Kurz)";
						break;
					case VariantType.Integer:
						mstrVarTypeName = "Ganzzahl (Lang)";
						break;
					case VariantType.String:
						mstrVarTypeName = "Zeichenkette";
						break;
					case (VariantType)8201:
						mstrVarTypeName = Conversions.ToString(Operators.ConcatenateObject(mvarArraySize, "D-Punkt"));
						break;
				}
				mblnReadOnly = vblnReadOnly;
				if (vvarDefault != null)
				{
					mblnDefaultByInit = true;
					mvarDefault = RuntimeHelpers.GetObjectValue(hwpDxf_SysVar.BkDXFSysVar_ConvertValue(mnumVarType, RuntimeHelpers.GetObjectValue(vvarDefault)));
					mstrDefaultString = hwpDxf_SysVar.BkDXFSysVar_StringValue(mnumVarType, RuntimeHelpers.GetObjectValue(mvarDefault));
				}
				else
				{
					mblnDefaultByInit = false;
					mvarDefault = null;
					mstrDefaultString = "-";
				}
				mvarBitValue = RuntimeHelpers.GetObjectValue(vvarBitValue);
				if (mvarBitValue != null)
				{
					object dvarBitValue = RuntimeHelpers.GetObjectValue(mvarBitValue);
					int dlngIdx3 = 1;
					while (Operators.ConditionalCompareObjectNotEqual(dvarBitValue, 0, TextCompare: false))
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.AndObject(dlngIdx3, dvarBitValue), dlngIdx3, TextCompare: false))
						{
							mstrBitValueString = mstrBitValueString + " " + Conversions.ToString(dlngIdx3);
							dvarBitValue = Operators.SubtractObject(dvarBitValue, dlngIdx3);
						}
						dlngIdx3 *= 2;
					}
					mstrBitValueString = Strings.LTrim(mstrBitValueString);
					vvarMaxValue = RuntimeHelpers.GetObjectValue(mvarBitValue);
				}
				else
				{
					mstrBitValueString = "-";
				}
				if (vvarLstValues != null)
				{
					object[] dvarLstValues = new object[Information.UBound((Array)vvarLstValues) + 1];
					int num = Information.LBound((Array)vvarLstValues);
					int num2 = Information.UBound((Array)vvarLstValues);
					for (int dlngIdx3 = num; dlngIdx3 <= num2; dlngIdx3++)
					{
						dvarLstValues[dlngIdx3] = RuntimeHelpers.GetObjectValue(hwpDxf_SysVar.BkDXFSysVar_ConvertValue(mnumVarType, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarLstValues, new object[1]
						{
						dlngIdx3
						}, null))));
						mstrLstValuesString = Operators.ConcatenateObject(Operators.ConcatenateObject(mstrLstValuesString, " "), hwpDxf_SysVar.BkDXFSysVar_StringValue(mnumVarType, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarLstValues, new object[1]
						{
						dlngIdx3
						}, null))));
					}
					mvarLstValues = Support.CopyArray(dvarLstValues);
					mstrLstValuesString = Strings.LTrim(Conversions.ToString(mstrLstValuesString));
					if ((mnumVarType == VariantType.Double) | (mnumVarType == VariantType.Decimal) | (mnumVarType == VariantType.Short) | (mnumVarType == VariantType.Integer))
					{
						object dvarMax = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
						{
						Information.LBound((Array)mvarLstValues)
						}, null));
						object dvarMin = RuntimeHelpers.GetObjectValue(dvarMax);
						int num3 = Information.LBound((Array)mvarLstValues);
						int num4 = Information.UBound((Array)mvarLstValues);
						for (int dlngIdx3 = num3; dlngIdx3 <= num4; dlngIdx3++)
						{
							if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
							{
							dlngIdx3
							}, null), dvarMax, TextCompare: false))
							{
								dvarMax = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
								{
								dlngIdx3
								}, null));
							}
							if (Operators.ConditionalCompareObjectLess(NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
							{
							dlngIdx3
							}, null), dvarMin, TextCompare: false))
							{
								dvarMin = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
								{
								dlngIdx3
								}, null));
							}
						}
						vvarMaxValue = RuntimeHelpers.GetObjectValue(dvarMax);
						vvarMinValue = RuntimeHelpers.GetObjectValue(dvarMin);
					}
				}
				else
				{
					mvarLstValues = RuntimeHelpers.GetObjectValue(vvarLstValues);
					mstrLstValuesString = "-";
				}
				if (vvarMinValue != null)
				{
					mvarMinValue = RuntimeHelpers.GetObjectValue(hwpDxf_SysVar.BkDXFSysVar_ConvertValue(mnumVarType, RuntimeHelpers.GetObjectValue(vvarMinValue)));
					mstrMinValueString = hwpDxf_SysVar.BkDXFSysVar_StringValue(mnumVarType, RuntimeHelpers.GetObjectValue(mvarMinValue));
				}
				else
				{
					mvarMinValue = null;
					mstrMinValueString = "-";
				}
				if (vvarMaxValue != null)
				{
					mvarMaxValue = RuntimeHelpers.GetObjectValue(hwpDxf_SysVar.BkDXFSysVar_ConvertValue(mnumVarType, RuntimeHelpers.GetObjectValue(vvarMaxValue)));
					mstrMaxValueString = hwpDxf_SysVar.BkDXFSysVar_StringValue(mnumVarType, RuntimeHelpers.GetObjectValue(mvarMaxValue));
				}
				else
				{
					mvarMaxValue = null;
					mstrMaxValueString = "-";
				}
				mnumSaveType = vnumSaveType;
				switch (mnumSaveType)
				{
					case hwpDxf_Enums.SAVE_TYPE.stUnknown:
						mstrSaveTypeName = "Unbekannt";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stNone:
						mstrSaveTypeName = "Nicht gespeichert";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stRegistry:
						mstrSaveTypeName = "Registrierdatenbank";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stDrawing:
						mstrSaveTypeName = "Zeichnung";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stViewport:
						mstrSaveTypeName = "Ansichtsfenster";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stDXFApp:
						mstrSaveTypeName = "DXF Applikation";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stDXFDoc:
						mstrSaveTypeName = "DXF Zeichnung";
						break;
					case hwpDxf_Enums.SAVE_TYPE.stDXFVport:
						mstrSaveTypeName = "DXF Ansichtsfenster";
						break;
				}
				mnumPrefTab = vnumPrefTab;
				switch (mnumPrefTab)
				{
					case hwpDxf_Enums.PREF_TAB.ptDisplay:
						mstrPrefTabName = "Anzeige";
						break;
					case hwpDxf_Enums.PREF_TAB.ptDrafting:
						mstrPrefTabName = "Entwurf";
						break;
					case hwpDxf_Enums.PREF_TAB.ptFiles:
						mstrPrefTabName = "Dateien";
						break;
					case hwpDxf_Enums.PREF_TAB.ptNone:
						mstrPrefTabName = "Keine";
						break;
					case hwpDxf_Enums.PREF_TAB.ptOpenSave:
						mstrPrefTabName = "Öffnen und Speichern";
						break;
					case hwpDxf_Enums.PREF_TAB.ptOutput:
						mstrPrefTabName = "Plot";
						break;
					case hwpDxf_Enums.PREF_TAB.ptProfile:
						mstrPrefTabName = "Profil";
						break;
					case hwpDxf_Enums.PREF_TAB.ptSelection:
						mstrPrefTabName = "Auswahl";
						break;
					case hwpDxf_Enums.PREF_TAB.ptSystem:
						mstrPrefTabName = "System";
						break;
					case hwpDxf_Enums.PREF_TAB.ptUnknown:
						mstrPrefTabName = "Unbekannt";
						break;
					case hwpDxf_Enums.PREF_TAB.ptUser:
						mstrPrefTabName = "Benutzereinstellungen";
						break;
				}
				mblnRunTimeErr = vblnRunTimeErr;
				mblnIsUnitsBase = vblnIsUnitsBase;
				mnumSymTable = vnumSymTable;
				switch (mnumSymTable)
				{
					case hwpDxf_Enums.SYMBOL_TABLE.symNone:
						mstrSymTableName = "Keine";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symAppid:
						mstrSymTableName = "APPID";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symBlock:
						mstrSymTableName = "BLOCK_RECORD";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symDimStyle:
						mstrSymTableName = "DIMSTYLE";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symLayer:
						mstrSymTableName = "LAYER";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symLType:
						mstrSymTableName = "LTYPE";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symStyle:
						mstrSymTableName = "STYLE";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symUcs:
						mstrSymTableName = "UCS";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symView:
						mstrSymTableName = "VIEW";
						break;
					case hwpDxf_Enums.SYMBOL_TABLE.symVPort:
						mstrSymTableName = "VPORT";
						break;
				}
				mblnIsColor = vblnIsColor;
				mvarEmptyValue = RuntimeHelpers.GetObjectValue(vvarEmptyValue);
				mblnIsDimValue = vblnIsDimValue;
				mvarHeaderCode = RuntimeHelpers.GetObjectValue(vvarHeaderCode);
				if (mvarHeaderCode != null)
				{
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(mvarHeaderCode))) == VariantType.Array)
					{
						int num5 = Information.LBound((Array)mvarHeaderCode);
						int num6 = Information.UBound((Array)mvarHeaderCode);
						for (int dlngIdx3 = num5; dlngIdx3 <= num6; dlngIdx3++)
						{
							mstrHeaderCodeString = Conversions.ToString(Operators.ConcatenateObject(mstrHeaderCodeString + ", ", NewLateBinding.LateIndexGet(mvarHeaderCode, new object[1]
							{
							dlngIdx3
							}, null)));
						}
						mstrHeaderCodeString = Strings.LTrim(Strings.Mid(mstrHeaderCodeString, 2));
					}
					else
					{
						mstrHeaderCodeString = Conversions.ToString(mvarHeaderCode);
					}
				}
				else
				{
					mstrHeaderCodeString = "-";
				}
				mvarHeaderPos = RuntimeHelpers.GetObjectValue(vvarHeaderPos);
				if (mvarHeaderPos != null)
				{
					mstrHeaderPosString = Conversions.ToString(mvarHeaderPos);
				}
				else
				{
					mstrHeaderPosString = "-";
				}
				mnumRefType = vnumRefType;
				switch (mnumRefType)
				{
					case hwpDxf_Enums.REF_TYPE.rtUnknown:
						mstrRefTypeName = "Unbekannt";
						break;
					case hwpDxf_Enums.REF_TYPE.rtApplication:
						mstrRefTypeName = "Applikation";
						break;
					case hwpDxf_Enums.REF_TYPE.rtDrawing:
						mstrRefTypeName = "Zeichnung";
						break;
					case hwpDxf_Enums.REF_TYPE.rtViewport:
						mstrRefTypeName = "Ansichtsfenster";
						break;
				}
				mstrDwgStartAcadVer = vstrDwgStartAcadVer;
				mstrDwgEndAcadVer = vstrDwgEndAcadVer;
				mstrDxfStartAcadVer = vstrDxfStartAcadVer;
				mstrDxfEndAcadVer = vstrDxfEndAcadVer;
			}
		}

		internal bool FriendCheckType(object vvarValue, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			return hwpDxf_SysVar.BkDXFSysVar_CheckType(mstrName, mnumVarType, RuntimeHelpers.GetObjectValue(mvarArraySize), RuntimeHelpers.GetObjectValue(vvarValue), ref nrstrErrMsg);
		}

		internal bool FriendCheckValue(object vvarValue, AcadTable vobjAcadTable, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			return InternCheckValue(RuntimeHelpers.GetObjectValue(vvarValue), vobjAcadTable, ref mdblObjectID, ref nrstrErrMsg);
		}

		internal object FriendConvertValue(object vvarValue)
		{
			return RuntimeHelpers.GetObjectValue(hwpDxf_SysVar.BkDXFSysVar_ConvertValue(mnumVarType, RuntimeHelpers.GetObjectValue(vvarValue)));
		}

		internal object FriendStringValue(object vvarValue)
		{
			return hwpDxf_SysVar.BkDXFSysVar_StringValue(mnumVarType, RuntimeHelpers.GetObjectValue(vvarValue));
		}

		private bool InternCheckValue(object vvarValue, AcadTable vobjAcadTable, ref double rdblObjectID, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			rdblObjectID = -1.0;
			bool dblnErr = default(bool);
			if (!InternCheckMin(RuntimeHelpers.GetObjectValue(vvarValue)))
			{
				if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
				{
					nrstrErrMsg += "\n";
				}
				nrstrErrMsg += "Variablenwert unterschreitet Minimalwert.";
				dblnErr = true;
			}
			if (!InternCheckMax(RuntimeHelpers.GetObjectValue(vvarValue)))
			{
				if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
				{
					nrstrErrMsg += "\n";
				}
				nrstrErrMsg += "Variablenwert übertschreitet Maximalwert.";
				dblnErr = true;
			}
			if (!InternCheckBit(RuntimeHelpers.GetObjectValue(vvarValue)))
			{
				if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
				{
					nrstrErrMsg += "\n";
				}
				nrstrErrMsg += "Variablenwert ist keine zulässiger Bitsumme.";
				dblnErr = true;
			}
			if (!InternCheckColor(RuntimeHelpers.GetObjectValue(vvarValue)))
			{
				if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
				{
					nrstrErrMsg += "\n";
				}
				nrstrErrMsg += "Variablenwert ist kein gültiger Farbwert.";
				dblnErr = true;
			}
			if ((mnumSymTable != hwpDxf_Enums.SYMBOL_TABLE.symNone) & (mvarLstValues != null))
			{
				if (!InternCheckLst(RuntimeHelpers.GetObjectValue(vvarValue)) & !InternCheckSymTable(RuntimeHelpers.GetObjectValue(vvarValue), vobjAcadTable, ref rdblObjectID))
				{
					if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
					{
						nrstrErrMsg += "\n";
					}
					nrstrErrMsg += "Variablenwert ist nicht Bestandteil der Werteliste oder Symboltabelle.";
					dblnErr = true;
				}
			}
			else
			{
				if (!InternCheckLst(RuntimeHelpers.GetObjectValue(vvarValue)))
				{
					if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
					{
						nrstrErrMsg += "\n";
					}
					nrstrErrMsg += "Variablenwert ist nicht Bestandteil der Werteliste.";
					dblnErr = true;
				}
				if (!InternCheckSymTable(RuntimeHelpers.GetObjectValue(vvarValue), vobjAcadTable, ref rdblObjectID))
				{
					if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
					{
						nrstrErrMsg += "\n";
					}
					nrstrErrMsg += "Variablenwert ist nicht Bestandteil der Symboltabelle.";
					dblnErr = true;
				}
			}
			if (Operators.CompareString(nrstrErrMsg, null, TextCompare: false) != 0)
			{
				nrstrErrMsg = mstrName + "\n" + nrstrErrMsg;
			}
			return !dblnErr;
		}

		private bool InternCheckMin(object vvarValue)
		{
			if (mvarMinValue != null)
			{
				return Operators.ConditionalCompareObjectGreaterEqual(vvarValue, mvarMinValue, TextCompare: false);
			}
			return true;
		}

		private bool InternCheckMax(object vvarValue)
		{
			if (mvarMaxValue != null)
			{
				return Operators.ConditionalCompareObjectLessEqual(vvarValue, mvarMaxValue, TextCompare: false);
			}
			return true;
		}

		private bool InternCheckLst(object vvarValue)
		{
			bool InternCheckLst = false;
			if (mvarLstValues != null)
			{
				int num = Information.LBound((Array)mvarLstValues);
				int num2 = Information.UBound((Array)mvarLstValues);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					if (Operators.ConditionalCompareObjectEqual(vvarValue, NewLateBinding.LateIndexGet(mvarLstValues, new object[1]
					{
					dlngIdx
					}, null), TextCompare: false))
					{
						InternCheckLst = true;
					}
				}
			}
			else
			{
				InternCheckLst = true;
			}
			return InternCheckLst;
		}

		private bool InternCheckBit(object vvarValue)
		{
			bool InternCheckBit = false;
			if (mvarBitValue != null)
			{
				return Operators.ConditionalCompareObjectEqual(Operators.AndObject(vvarValue, mvarBitValue), vvarValue, TextCompare: false);
			}
			return true;
		}

		private bool InternCheckColor(object vvarValue)
		{
			bool dblnValid = false;
			if (mblnIsColor)
			{
				if (mnumVarType == VariantType.String)
				{
					string dstrValue = Strings.UCase(Conversions.ToString(vvarValue));
					switch (dstrValue)
					{
						case "VONLAYER":
							dblnValid = true;
							break;
						case "VONBLOCK":
							dblnValid = true;
							break;
						case "BYLAYER":
							dblnValid = true;
							break;
						case "BYBLOCK":
							dblnValid = true;
							break;
						default:
							try
							{
								int dlngValue = Conversions.ToInteger(dstrValue);
								dblnValid = (dlngValue >= 0 && dlngValue <= 256);
							}
							catch (Exception ex2)
							{
								ProjectData.SetProjectError(ex2);
								Exception ex = ex2;
								ProjectData.ClearProjectError();
							}
							break;
					}
				}
			}
			else
			{
				dblnValid = true;
			}
			return dblnValid;
		}

		private bool InternCheckSymTable(object vvarValue, AcadTable vobjAcadTable, ref double rdblObjectID)
		{
			rdblObjectID = -1.0;
			bool dblnValid = default(bool);
			AcadBlocks dobjAcadBlocks2;
			AcadBlock dobjAcadBlock2;
			AcadUCSs dobjAcadUCSs2;
			AcadUCS dobjAcadUCS2;
			AcadTextStyles dobjAcadTextStyles2;
			AcadTextStyle dobjAcadTextStyle2;
			AcadLineTypes dobjAcadLineTypes2;
			AcadLineType dobjAcadLinetype2;
			AcadLayers dobjAcadLayers2;
			AcadLayer dobjAcadLayer2;
			AcadDimStyles dobjAcadDimStyles2;
			AcadDimStyle dobjAcadDimStyle2;
			AcadViewports dobjAcadViewports2;
			AcadViewport dobjAcadViewport2;
			AcadRegisteredApplications dobjAcadRegisteredApplications2;
			AcadRegisteredApplication dobjAcadRegisteredApplication2;
			AcadViews dobjAcadViews2;
			AcadView dobjAcadView2;
			if (vobjAcadTable == null)
			{
				dblnValid = true;
			}
			else
			{
				switch (SymTable)
				{
					case 0:
						dblnValid = true;
						break;
					case 2:
						dobjAcadBlocks2 = (AcadBlocks)vobjAcadTable;
						dobjAcadBlock2 = (AcadBlock)dobjAcadBlocks2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadBlock2 != null)
						{
							rdblObjectID = dobjAcadBlock2.ObjectID;
							dblnValid = true;
						}
						break;
					case 7:
						dobjAcadUCSs2 = (AcadUCSs)vobjAcadTable;
						dobjAcadUCS2 = (AcadUCS)dobjAcadUCSs2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadUCS2 != null)
						{
							rdblObjectID = dobjAcadUCS2.ObjectID;
							dblnValid = true;
						}
						break;
					case 6:
						dobjAcadTextStyles2 = (AcadTextStyles)vobjAcadTable;
						dobjAcadTextStyle2 = (AcadTextStyle)dobjAcadTextStyles2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadTextStyle2 != null)
						{
							rdblObjectID = dobjAcadTextStyle2.ObjectID;
							dblnValid = true;
						}
						break;
					case 5:
						dobjAcadLineTypes2 = (AcadLineTypes)vobjAcadTable;
						dobjAcadLinetype2 = (AcadLineType)dobjAcadLineTypes2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadLinetype2 != null)
						{
							rdblObjectID = dobjAcadLinetype2.ObjectID;
							dblnValid = true;
						}
						break;
					case 4:
						dobjAcadLayers2 = (AcadLayers)vobjAcadTable;
						dobjAcadLayer2 = (AcadLayer)dobjAcadLayers2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadLayer2 != null)
						{
							rdblObjectID = dobjAcadLayer2.ObjectID;
							dblnValid = true;
						}
						break;
					case 3:
						dobjAcadDimStyles2 = (AcadDimStyles)vobjAcadTable;
						dobjAcadDimStyle2 = (AcadDimStyle)dobjAcadDimStyles2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadDimStyle2 != null)
						{
							rdblObjectID = dobjAcadDimStyle2.ObjectID;
							dblnValid = true;
						}
						break;
					case 9:
						dobjAcadViewports2 = (AcadViewports)vobjAcadTable;
						dobjAcadViewport2 = (AcadViewport)dobjAcadViewports2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadViewport2 != null)
						{
							rdblObjectID = dobjAcadViewport2.ObjectID;
							dblnValid = true;
						}
						break;
					case 1:
						dobjAcadRegisteredApplications2 = (AcadRegisteredApplications)vobjAcadTable;
						dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)dobjAcadRegisteredApplications2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadRegisteredApplication2 != null)
						{
							rdblObjectID = dobjAcadRegisteredApplication2.ObjectID;
							dblnValid = true;
						}
						break;
					case 8:
						dobjAcadViews2 = (AcadViews)vobjAcadTable;
						dobjAcadView2 = (AcadView)dobjAcadViews2.FriendGetItem(RuntimeHelpers.GetObjectValue(vvarValue));
						if (dobjAcadView2 != null)
						{
							rdblObjectID = dobjAcadView2.ObjectID;
							dblnValid = true;
						}
						break;
				}
			}
			bool InternCheckSymTable = dblnValid;
			dobjAcadBlocks2 = null;
			dobjAcadBlock2 = null;
			dobjAcadUCSs2 = null;
			dobjAcadUCS2 = null;
			dobjAcadTextStyles2 = null;
			dobjAcadTextStyle2 = null;
			dobjAcadLineTypes2 = null;
			dobjAcadLinetype2 = null;
			dobjAcadLayers2 = null;
			dobjAcadLayer2 = null;
			dobjAcadDimStyles2 = null;
			dobjAcadDimStyle2 = null;
			dobjAcadViewports2 = null;
			dobjAcadViewport2 = null;
			dobjAcadRegisteredApplications2 = null;
			dobjAcadRegisteredApplication2 = null;
			dobjAcadViews2 = null;
			dobjAcadView2 = null;
			return InternCheckSymTable;
		}
	}
}
