using DXFLib.Acad;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	class TableStyle
	{
		private const string cstrClassName = "TableStyle";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadTextStyles mobjAcadTextStyles;

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

		public string Name => "STYLE";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableStyle()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableStyle()
		{
			Class_Terminate_Renamed();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjAcadTextStyles = null;
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

		public bool Read(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			return InternReadTable(ref nrstrErrMsg);
		}

		public void ListTable(ref int rlngIdx)
		{
			mobjAcadTextStyles = mobjAcadDatabase.TextStyles;
			if (mobjAcadTextStyles != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadTextStyles acadTextStyles = mobjAcadTextStyles;
				InternAddToDictLine(ref rlngIdx, 2, acadTextStyles.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadTextStyles.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadTextStyles.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadTextStyles.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadTextStyles.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadTextStyles.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadTextStyles.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadTextStyles = null;
				InternListTable(ref rlngIdx);
				mlngTblEnd = rlngIdx;
				InternAddToDictLine(ref rlngIdx, 0, "ENDTAB");
			}
		}

		private bool InternReadTable(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx = checked(mlngTblBeg + 1);
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			int dlngCount = default(int);
			bool InternReadTable = default(bool);
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTable(mobjAcadDatabase, mobjDictReadCodes, mobjDictReadValues, ref dlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dlngCount, ref dobjDictXDictionary2, ref nrstrErrMsg))
			{
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				bool dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref dlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
				if (!dblnError)
				{
					mobjAcadTextStyles = mobjAcadDatabase.FriendAddAcadObjectTextStyles(ddblObjectID, ref nrstrErrMsg);
					if (mobjAcadTextStyles == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadTextStyles.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadTextStyles.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadStyle(ddblObjectID, ref dlngIdx, ref mobjAcadTextStyles, ref nrstrErrMsg))
							{
								dblnError = true;
							}
						}
					}
				}
				InternReadTable = !dblnError;
			}
			dobjDictXDictionary2 = null;
			return InternReadTable;
		}

		private bool InternReadStyle(double vdblDefOwnerID, ref int rlngIdx, ref AcadTextStyles robjAcadTextStyles, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadStyle = default(bool);
				AcadTextStyle dobjAcadTextStyle2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "STYLE", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbTextStyleTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Textstilname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für feste Texthöhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 41, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Breitenfaktor in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 50, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Neigungswinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Flag-Werte für Texterstellung in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 7], 42, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für zuletzt verwendete Höhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 8], 3, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Dateiname der Primärschrift in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 9], 4, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Dateiname des Big Fonts in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						bool flag = false;
						double ddblHeight = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
						double ddblWidth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
						double ddblObliqueAngleDegree = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
						int dlngTextGenerationFlag = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 6]);
						bool flag2 = false;
						double ddblLastHeight = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 7]);
						string dstrFontFile = Conversions.ToString(mobjDictReadValues[rlngIdx + 8]);
						string dstrBigFontFile = Conversions.ToString(mobjDictReadValues[rlngIdx + 9]);
						rlngIdx += 10;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							if (robjAcadTextStyles.FriendNameExist(dstrName))
							{
								nrstrErrMsg = "Textstil " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
								dblnError = true;
							}
							else
							{
								dobjAcadTextStyle2 = robjAcadTextStyles.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
								if (dobjAcadTextStyle2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadTextStyle acadTextStyle = dobjAcadTextStyle2;
									acadTextStyle.FriendLetFlags70 = dlngCode70;
									bool flag3 = false;
									acadTextStyle.Height = ddblHeight;
									acadTextStyle.Width = ddblWidth;
									acadTextStyle.ObliqueAngleDegree = ddblObliqueAngleDegree;
									acadTextStyle.TextGenerationFlag = unchecked((Enums.AcTextGenerationFlag)dlngTextGenerationFlag);
									bool flag4 = false;
									acadTextStyle.LastHeight = ddblLastHeight;
									acadTextStyle.FontFile = dstrFontFile;
									acadTextStyle.BigFontFile = dstrBigFontFile;
									acadTextStyle.FriendSetDictReactors = dobjDictReactors2;
									acadTextStyle.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadTextStyle.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadTextStyle = null;
								}
							}
						}
					}
					InternReadStyle = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadTextStyle2 = null;
				return InternReadStyle;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadTextStyle dobjAcadTextStyle2;
			try
			{
				enumerator = mobjAcadTextStyles.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadTextStyle2 = (AcadTextStyle)enumerator.Current;
					AcadTextStyle acadTextStyle = dobjAcadTextStyle2;
					InternAddToDictLine(ref rlngIdx, 0, acadTextStyle.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadTextStyle.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadTextStyle.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadTextStyle.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadTextStyle.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadTextStyle.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadTextStyle.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadTextStyle.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadTextStyle.Flags70);
					InternAddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadTextStyle.Height));
					InternAddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadTextStyle.Width));
					InternAddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadTextStyle.ObliqueAngleDegree));
					InternAddToDictLine(ref rlngIdx, 71, acadTextStyle.TextGenerationFlag);
					InternAddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadTextStyle.LastHeight));
					InternAddToDictLine(ref rlngIdx, 3, acadTextStyle.FontFile);
					InternAddToDictLine(ref rlngIdx, 4, acadTextStyle.BigFontFile);
					acadTextStyle.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadTextStyle = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadTextStyle2 = null;
		}
	}
}
