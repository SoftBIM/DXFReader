using DXFLib.Acad;
using Microsoft.VisualBasic;
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
	class TableVPort
	{
		private const string cstrClassName = "TableVPort";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadViewports mobjAcadViewports;

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

		public string Name => "VPORT";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableVPort()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableVPort()
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
				mobjAcadViewports = null;
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
			mobjAcadViewports = mobjAcadDatabase.Viewports;
			if (mobjAcadViewports != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadViewports acadViewports = mobjAcadViewports;
				InternAddToDictLine(ref rlngIdx, 2, acadViewports.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadViewports.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadViewports.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadViewports.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadViewports.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadViewports.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadViewports.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadViewports = null;
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
					mobjAcadViewports = mobjAcadDatabase.FriendAddAcadObjectViewports(ref nrstrErrMsg, ddblObjectID);
					if (mobjAcadViewports == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadViewports.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadViewports.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadVPort(ddblObjectID, ref dlngIdx, ref mobjAcadViewports, ref nrstrErrMsg))
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

		private bool InternReadVPort(double vdblDefOwnerID, ref int rlngIdx, ref AcadViewports robjAcadViewports, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadVPort = default(bool);
				AcadViewport dobjAcadViewport2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "VPORT", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbViewportTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Applikationsname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Linke untere Ecke X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Linke untere Ecke Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rechte obere Ecke X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rechte obere Ecke Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 7], 12, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Mittelpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 8], 22, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Mittelpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 9], 13, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangbasispunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 10], 23, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangbasispunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 11], 14, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangwert X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 12], 24, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangwert Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 13], 15, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rasterpunktabstand X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 27) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 14], 25, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rasterpunktabstand Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 29) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 15], 16, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 31) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 16], 26, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 33) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 17], 36, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 35) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 18], 17, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 37) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 19], 27, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 39) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 20], 37, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 41) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 21], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Höhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 43) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 22], 41, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Seitenverhältnis in Zeile " + Conversions.ToString(rlngIdx * 2 + 45) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 23], 42, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Brennweite in Zeile " + Conversions.ToString(rlngIdx * 2 + 47) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 24], 43, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Abstand vordere Schnittebene in Zeile " + Conversions.ToString(rlngIdx * 2 + 49) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 25], 44, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Abstand hintere Schnittebene  in Zeile " + Conversions.ToString(rlngIdx * 2 + 51) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 26], 50, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangdrehwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 53) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 27], 51, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Drehwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 55) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 28], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ansichtsmodus in Zeile " + Conversions.ToString(rlngIdx * 2 + 57) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 29], 72, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Kreiszoomkomponente in Zeile " + Conversions.ToString(rlngIdx * 2 + 59) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 30], 73, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Schnellzoom in Zeile " + Conversions.ToString(rlngIdx * 2 + 61) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 31], 74, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für UCSICON in Zeile " + Conversions.ToString(rlngIdx * 2 + 63) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 32], 75, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fang in Zeile " + Conversions.ToString(rlngIdx * 2 + 65) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 33], 76, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Raster in Zeile " + Conversions.ToString(rlngIdx * 2 + 67) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 34], 77, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fangstil in Zeile " + Conversions.ToString(rlngIdx * 2 + 69) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 35], 78, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Fang-Isopaar in Zeile " + Conversions.ToString(rlngIdx * 2 + 71) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 36], 281, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rendermodus in Zeile " + Conversions.ToString(rlngIdx * 2 + 73) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 37], 65, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für BKS-Modus in Zeile " + Conversions.ToString(rlngIdx * 2 + 75) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 38], 110, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 77) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 39], 120, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 79) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 40], 130, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 81) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 41], 111, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 83) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 42], 121, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 85) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 43], 131, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 87) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 44], 112, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 89) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 45], 122, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 91) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 46], 132, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 93) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						bool flag = false;
						double ddblLowerLeftCornerX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
						double ddblLowerLeftCornerY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
						double ddblUpperRightCornerX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
						double ddblUpperRightCornerY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 6]);
						double ddblCenterX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 7]);
						double ddblCenterY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 8]);
						double ddblSnapBasePointX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 9]);
						double ddblSnapBasePointY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 10]);
						double ddblSnapSpacingX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 11]);
						double ddblSnapSpacingY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 12]);
						double ddblGridSpacingX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 13]);
						double ddblGridSpacingY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 14]);
						double ddblDirectionX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 15]);
						double ddblDirectionY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 16]);
						double ddblDirectionZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 17]);
						double ddblTargetX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 18]);
						double ddblTargetY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 19]);
						double ddblTargetZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 20]);
						double ddblHeight = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 21]);
						double ddblWidth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 22]);
						double ddblLensLength = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 23]);
						double ddblFrontClipDistance = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 24]);
						double ddblBackClipDistance = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 25]);
						double ddblSnapRotationAngleDegree = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 26]);
						double ddblViewTwistDegree = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 27]);
						int dlngCode71 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 28]);
						int dlngArcSmoothness = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 29]);
						int dlngFastZoomsEnabled = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 30]);
						int dlngCode72 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 31]);
						int dlngSnapOn = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 32]);
						int dlngGridOn = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 33]);
						int dlngIsometricSnapEnabled = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 34]);
						int dlngSnapPair = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 35]);
						int dlngRenderMode = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 36]);
						int dlngUCSSavedWithViewport = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 37]);
						bool flag2 = false;
						double ddblOriginX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 38]);
						double ddblOriginY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 39]);
						double ddblOriginZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 40]);
						double ddblXVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 41]);
						double ddblXVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 42]);
						double ddblXVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 43]);
						double ddblYVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 44]);
						double ddblYVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 45]);
						double ddblYVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 46]);
						rlngIdx += 47;
						double ddblAssociatedUcsObjectID;
						if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 345, TextCompare: false))
						{
							ddblAssociatedUcsObjectID = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							ddblAssociatedUcsObjectID = -1.0;
						}
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 79, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Typ der orthogonalen Ansicht in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 146, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Tiefe in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							int dlngUCSOrthographic = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
							bool flag3 = false;
							double ddblDepth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
							double ddblOrthographicUcsObjectID;
							if (dlngUCSOrthographic != 0)
							{
								if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 346, TextCompare: false))
								{
									ddblOrthographicUcsObjectID = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									ddblOrthographicUcsObjectID = -1.0;
								}
							}
							else
							{
								ddblOrthographicUcsObjectID = -1.0;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							unchecked
							{
								if (!dblnError)
								{
									dobjAcadViewport2 = robjAcadViewports.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
									if (dobjAcadViewport2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadViewport acadViewport = dobjAcadViewport2;
										acadViewport.FriendLetFlags70 = dlngCode70;
										bool flag4 = false;
										acadViewport.FriendLetLowerLeftCorner = new object[2]
										{
										ddblLowerLeftCornerX,
										ddblLowerLeftCornerY
										};
										acadViewport.FriendLetUpperRightCorner = new object[2]
										{
										ddblUpperRightCornerX,
										ddblUpperRightCornerY
										};
										acadViewport.Center = new object[2]
										{
										ddblCenterX,
										ddblCenterY
										};
										acadViewport.SnapBasePoint = new object[2]
										{
										ddblSnapBasePointX,
										ddblSnapBasePointY
										};
										acadViewport.FriendLetSnapSpacingX = ddblSnapSpacingX;
										acadViewport.FriendLetSnapSpacingY = ddblSnapSpacingY;
										acadViewport.FriendLetGridSpacingX = ddblGridSpacingX;
										acadViewport.FriendLetGridSpacingY = ddblGridSpacingY;
										acadViewport.Direction = new object[3]
										{
										ddblDirectionX,
										ddblDirectionY,
										ddblDirectionZ
										};
										acadViewport.Target = new object[3]
										{
										ddblTargetX,
										ddblTargetY,
										ddblTargetZ
										};
										acadViewport.Height = ddblHeight;
										acadViewport.Width = ddblWidth;
										acadViewport.FriendLetLensLength = ddblLensLength;
										acadViewport.FriendLetFrontClipDistance = ddblFrontClipDistance;
										acadViewport.FriendLetBackClipDistance = ddblBackClipDistance;
										acadViewport.SnapRotationAngleDegree = ddblSnapRotationAngleDegree;
										acadViewport.FriendLetViewTwistDegree = ddblViewTwistDegree;
										acadViewport.FriendLetFlags71 = dlngCode71;
										acadViewport.ArcSmoothness = dlngArcSmoothness;
										acadViewport.FriendLetFastZoomsEnabled = (dlngFastZoomsEnabled != 0);
										acadViewport.FriendLetFlags70 = dlngCode70;
										acadViewport.SnapOn = ((1 & dlngSnapOn) == 1);
										acadViewport.GridOn = ((1 & dlngGridOn) == 1);
										acadViewport.FriendLetIsometricSnapEnabled = ((1 & dlngIsometricSnapEnabled) == 1);
										acadViewport.FriendLetSnapPair = (hwpDxf_Enums.SNAP_PAIR)dlngSnapPair;
										acadViewport.FriendLetRenderMode = (hwpDxf_Enums.RENDER_MODE)dlngRenderMode;
										acadViewport.FriendLetUCSSavedWithViewport = ((1 & dlngUCSSavedWithViewport) == 1);
										bool flag5 = false;
										acadViewport.Origin = new object[3]
										{
										ddblOriginX,
										ddblOriginY,
										ddblOriginZ
										};
										acadViewport.XVector = new object[3]
										{
										ddblXVectorX,
										ddblXVectorY,
										ddblXVectorZ
										};
										acadViewport.YVector = new object[3]
										{
										ddblYVectorX,
										ddblYVectorY,
										ddblYVectorZ
										};
										acadViewport.FriendLetUCSOrthographic = (Enums.AcOrthoView)dlngUCSOrthographic;
										if (ddblAssociatedUcsObjectID != -1.0)
										{
											acadViewport.FriendLetAssociatedUcsObjectID = ddblAssociatedUcsObjectID;
										}
										if (acadViewport.UCSOrthographic != 0 && ddblOrthographicUcsObjectID != -1.0)
										{
											acadViewport.FriendLetOrthographicUcsObjectID = ddblOrthographicUcsObjectID;
										}
										acadViewport.FriendSetDictReactors = dobjDictReactors2;
										acadViewport.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadViewport.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadViewport = null;
									}
								}
							}
						}
					}
					InternReadVPort = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadViewport2 = null;
				return InternReadVPort;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadViewport dobjAcadViewport3;
			try
			{
				enumerator = mobjAcadViewports.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadViewport3 = (AcadViewport)enumerator.Current;
					string dstrName2 = dobjAcadViewport3.Name;
					if (Operators.CompareString(Strings.UCase(dstrName2), Strings.UCase("[*]Active"), TextCompare: false) != 0)
					{
						InternListAcadViewport(ref rlngIdx, dobjAcadViewport3);
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			IEnumerator enumerator2 = default(IEnumerator);
			try
			{
				enumerator2 = mobjAcadViewports.GetValues().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					dobjAcadViewport3 = (AcadViewport)enumerator2.Current;
					string dstrName2 = dobjAcadViewport3.Name;
					if (Operators.CompareString(Strings.UCase(dstrName2), Strings.UCase("[*]Active"), TextCompare: false) == 0)
					{
						InternListAcadViewport(ref rlngIdx, dobjAcadViewport3);
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			dobjAcadViewport3 = null;
		}

		private void InternListAcadViewport(ref int rlngIdx, AcadViewport vobjAcadViewport)
		{
			AcadViewport acadViewport = vobjAcadViewport;
			InternAddToDictLine(ref rlngIdx, 0, acadViewport.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadViewport.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadViewport.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadViewport.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadViewport.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadViewport.SuperiorObjectName);
			InternAddToDictLine(ref rlngIdx, 100, acadViewport.ObjectName);
			InternAddToDictLine(ref rlngIdx, 2, acadViewport.Name);
			InternAddToDictLine(ref rlngIdx, 70, acadViewport.Flags70);
			object dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.LowerLeftCorner);
			InternAddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.UpperRightCorner);
			InternAddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.Center);
			InternAddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.SnapBasePoint);
			InternAddToDictLine(ref rlngIdx, 13, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 23, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 14, RuntimeHelpers.GetObjectValue(acadViewport.SnapSpacingX));
			InternAddToDictLine(ref rlngIdx, 24, RuntimeHelpers.GetObjectValue(acadViewport.SnapSpacingY));
			InternAddToDictLine(ref rlngIdx, 15, RuntimeHelpers.GetObjectValue(acadViewport.GridSpacingX));
			InternAddToDictLine(ref rlngIdx, 25, RuntimeHelpers.GetObjectValue(acadViewport.GridSpacingY));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.Direction);
			InternAddToDictLine(ref rlngIdx, 16, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 26, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 36, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			2
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.Target);
			InternAddToDictLine(ref rlngIdx, 17, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 27, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 37, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			2
			}, null)));
			InternAddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadViewport.Height));
			InternAddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadViewport.Width));
			InternAddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadViewport.LensLength));
			InternAddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadViewport.FrontClipDistance));
			InternAddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadViewport.BackClipDistance));
			InternAddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadViewport.SnapRotationAngleDegree));
			InternAddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadViewport.ViewTwistDegree));
			InternAddToDictLine(ref rlngIdx, 71, acadViewport.Flags71);
			InternAddToDictLine(ref rlngIdx, 72, acadViewport.ArcSmoothness);
			InternAddToDictLine(ref rlngIdx, 73, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadViewport.FastZoomsEnabled, 1, 0)));
			InternAddToDictLine(ref rlngIdx, 74, acadViewport.Flags74);
			InternAddToDictLine(ref rlngIdx, 75, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadViewport.SnapOn, 1, 0)));
			InternAddToDictLine(ref rlngIdx, 76, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadViewport.GridOn, 1, 0)));
			InternAddToDictLine(ref rlngIdx, 77, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadViewport.IsometricSnapEnabled, 1, 0)));
			InternAddToDictLine(ref rlngIdx, 78, acadViewport.SnapPair);
			InternAddToDictLine(ref rlngIdx, 281, acadViewport.RenderMode);
			InternAddToDictLine(ref rlngIdx, 65, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadViewport.UCSSavedWithViewport, 1, 0)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.Origin);
			InternAddToDictLine(ref rlngIdx, 110, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 120, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 130, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			2
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.XVector);
			InternAddToDictLine(ref rlngIdx, 111, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 121, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 131, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			2
			}, null)));
			dvarPoint9 = RuntimeHelpers.GetObjectValue(acadViewport.YVector);
			InternAddToDictLine(ref rlngIdx, 112, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 122, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 132, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint9, new object[1]
			{
			2
			}, null)));
			if (acadViewport.UcsAssociatedToView)
			{
				InternAddToDictLine(ref rlngIdx, 345, acadViewport.AssociatedUcsObjectID);
			}
			InternAddToDictLine(ref rlngIdx, 79, acadViewport.UCSOrthographic);
			InternAddToDictLine(ref rlngIdx, 146, RuntimeHelpers.GetObjectValue(acadViewport.Depth));
			if (acadViewport.HasOrthographicUcs)
			{
				InternAddToDictLine(ref rlngIdx, 346, acadViewport.OrthographicUcsObjectID);
			}
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadViewport.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadViewport = null;
		}
	}
}
