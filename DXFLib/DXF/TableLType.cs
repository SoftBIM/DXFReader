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
	public class TableLType
	{
		private const string cstrClassName = "TableLType";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadLineTypes mobjAcadLineTypes;

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

		public string Name => "LTYPE";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableLType()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableLType()
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
				mobjAcadLineTypes = null;
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
			mobjAcadLineTypes = mobjAcadDatabase.Linetypes;
			if (mobjAcadLineTypes != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadLineTypes acadLineTypes = mobjAcadLineTypes;
				InternAddToDictLine(ref rlngIdx, 2, acadLineTypes.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadLineTypes.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadLineTypes.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadLineTypes.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadLineTypes.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadLineTypes.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadLineTypes.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadLineTypes = null;
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
					mobjAcadLineTypes = mobjAcadDatabase.FriendAddAcadObjectLineTypes(ref nrstrErrMsg, ddblObjectID);
					if (mobjAcadLineTypes == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadLineTypes.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadLineTypes.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadLType(ddblObjectID, ref dlngIdx, ref mobjAcadLineTypes, ref nrstrErrMsg))
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

		private bool InternReadLType(double vdblDefOwnerID, ref int rlngIdx, ref AcadLineTypes robjAcadLineTypes, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadLType = default(bool);
				AcadLineType dobjAcadLinetype2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "LTYPE", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbLinetypeTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Linientypname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 3, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Beschreibung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 72, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ausrichtungscode in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 73, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Elementeanzahl in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Musterlänge in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						string dstrDescription = Conversions.ToString(mobjDictReadValues[rlngIdx + 3]);
						int dlngScaleToFit = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 4]);
						int dlngNumDashes = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 5]);
						bool flag = false;
						double ddblPatternLength = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 6]);
						rlngIdx += 7;
						if (robjAcadLineTypes.FriendNameExist(dstrName))
						{
							nrstrErrMsg = "Linientyp " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
							dblnError = true;
						}
						else
						{
							dobjAcadLinetype2 = robjAcadLineTypes.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
							if (dobjAcadLinetype2 == null)
							{
								nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
								dblnError = true;
							}
							else
							{
								AcadLineType acadLineType = dobjAcadLinetype2;
								acadLineType.FriendLetFlags70 = dlngCode70;
								acadLineType.Description = dstrDescription;
								acadLineType.FriendLetScaledToFit = (dlngScaleToFit == 83);
								bool flag2 = false;
								acadLineType.FriendLetPatternLength = ddblPatternLength;
								acadLineType.FriendSetDictReactors = dobjDictReactors2;
								acadLineType.FriendSetDictXDictionary = dobjDictXDictionary2;
								acadLineType = null;
								if (dlngNumDashes > 0)
								{
									if (!InternReadDashes(ref rlngIdx, ref dobjAcadLinetype2, ref nrstrErrMsg))
									{
										dblnError = true;
									}
									else if (dlngNumDashes != dobjAcadLinetype2.Dashes.Count)
									{
										nrstrErrMsg = "Ungültige Anzahl der Linientypeinträgen vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
								}
								if (!dblnError)
								{
									object dvarXDataType = default(object);
									object dvarXDataValue = default(object);
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadLinetype2.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									}
								}
							}
						}
					}
					InternReadLType = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadLinetype2 = null;
				return InternReadLType;
			}
		}

		private bool InternReadDashes(ref int rlngIdx, ref AcadLineType robjAcadLineType, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadLineTypeDashes dobjAcadLineTypeDashes = robjAcadLineType.Dashes;
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (rlngIdx <= mlngTblEnd && !dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]);
				if (dlngCode != 0 && dlngCode != 0 && dlngCode != 49)
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Tabelleneintrag/ende oder Linientypelement in Zeile " + Conversions.ToString(checked(rlngIdx * 2 + 1)) + ".";
					dblnError = true;
				}
				else if (Conversions.ToBoolean(dvarValue is string && Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dvarValue, "ENDTAB", TextCompare: false), Operators.CompareObjectEqual(dvarValue, "LTYPE", TextCompare: false)))))
				{
					dblnStop = true;
				}
				else if (!InternReadDash(ref rlngIdx, ref dobjAcadLineTypeDashes, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool InternReadDashes = !dblnError;
			dobjAcadLineTypeDashes = null;
			return InternReadDashes;
		}

		private bool InternReadDash(ref int rlngIdx, ref AcadLineTypeDashes robjAcadLineTypeDashes, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx = rlngIdx;
			checked
			{
				bool dblnError = default(bool);
				AcadLineTypeDash dobjAcadLineTypeDash2;
				if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 49, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Bereichslänge in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 74, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Elementtyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					double ddblLength = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
					int dlngCode74 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 1]);
					rlngIdx += 2;
					int dlngShapeNumber = default(int);
					int dlngShapeStyle = default(int);
					double ddblShapeScale = default(double);
					double ddblShapeRotationDegree = default(double);
					double ddblShapeOffsetX = default(double);
					double ddblShapeOffsetY = default(double);
					string dstrText = default(string);
					if (dlngCode74 > 0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 75, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Symbolnummer in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 340, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Zeiger auf STYLE-Objekt in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 46, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Skalierfaktor in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 50, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Drehung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 44, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für X-Versatz in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 45, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Y-Versatz in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
							dblnError = true;
						}
						else
						{
							dlngShapeNumber = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
							dlngShapeStyle = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 1]);
							bool flag2 = false;
							ddblShapeScale = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 2]);
							ddblShapeRotationDegree = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
							ddblShapeOffsetX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
							ddblShapeOffsetY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
							rlngIdx += 6;
							if ((2 & dlngCode74) == 2)
							{
								if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 9, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Zeichenfolge in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dstrText = Conversions.ToString(mobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
						}
					}
					if (!dblnError)
					{
						dobjAcadLineTypeDash2 = robjAcadLineTypeDashes.FriendAdd(ref nrstrErrMsg);
						if (dobjAcadLineTypeDash2 == null)
						{
							nrstrErrMsg = nrstrErrMsg + " Ab Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else
						{
							AcadLineTypeDash acadLineTypeDash = dobjAcadLineTypeDash2;
							bool flag3 = false;
							acadLineTypeDash.FriendLetLength = ddblLength;
							if (dlngCode74 > 0)
							{
								acadLineTypeDash.FriendLetFlags74 = dlngCode74;
								acadLineTypeDash.FriendLetShapeNumber = dlngShapeNumber;
								acadLineTypeDash.FriendLetShapeStyle = dlngShapeStyle;
								bool flag4 = false;
								acadLineTypeDash.FriendLetShapeScale = ddblShapeScale;
								acadLineTypeDash.FriendLetShapeRotationDegree = ddblShapeRotationDegree;
								acadLineTypeDash.FriendLetShapeOffsetX = ddblShapeOffsetX;
								acadLineTypeDash.FriendLetShapeOffsetY = ddblShapeOffsetY;
							}
							if ((2 & dlngCode74) == 2)
							{
								acadLineTypeDash.FriendLetText = dstrText;
							}
							acadLineTypeDash = null;
						}
					}
				}
				bool InternReadDash = !dblnError;
				dobjAcadLineTypeDash2 = null;
				return InternReadDash;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadLineType dobjAcadLinetype2;
			try
			{
				enumerator = mobjAcadLineTypes.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadLinetype2 = (AcadLineType)enumerator.Current;
					AcadLineType acadLineType = dobjAcadLinetype2;
					InternAddToDictLine(ref rlngIdx, 0, acadLineType.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadLineType.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadLineType.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadLineType.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadLineType.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadLineType.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadLineType.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadLineType.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadLineType.Flags70);
					InternAddToDictLine(ref rlngIdx, 3, acadLineType.Description);
					InternAddToDictLine(ref rlngIdx, 72, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadLineType.ScaledToFit, 83, 65)));
					InternAddToDictLine(ref rlngIdx, 73, acadLineType.NumDashes);
					InternAddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadLineType.PatternLength));
					acadLineType = null;
					InternListLinetypeDashes(ref rlngIdx, dobjAcadLinetype2);
					dobjAcadLinetype2.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadLinetype2 = null;
		}

		private void InternListLinetypeDashes(ref int rlngIdx, AcadLineType vobjAcadLineType)
		{
			AcadLineTypeDashes dobjAcadLineTypeDashes2 = vobjAcadLineType.Dashes;
			IEnumerator enumerator = default(IEnumerator);
			AcadLineTypeDash dobjAcadLineTypeDash2;
			try
			{
				enumerator = dobjAcadLineTypeDashes2.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
					AcadLineTypeDash acadLineTypeDash = dobjAcadLineTypeDash2;
					InternAddToDictLine(ref rlngIdx, 49, RuntimeHelpers.GetObjectValue(acadLineTypeDash.Length));
					int dlngCode74 = acadLineTypeDash.Flags74;
					InternAddToDictLine(ref rlngIdx, 74, dlngCode74);
					if (dlngCode74 > 0)
					{
						InternAddToDictLine(ref rlngIdx, 75, acadLineTypeDash.ShapeNumber);
						InternAddToDictLine(ref rlngIdx, 340, acadLineTypeDash.ShapeStyle);
						InternAddToDictLine(ref rlngIdx, 46, RuntimeHelpers.GetObjectValue(acadLineTypeDash.ShapeScale));
						InternAddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadLineTypeDash.ShapeRotationDegree));
						InternAddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadLineTypeDash.ShapeOffsetX));
						InternAddToDictLine(ref rlngIdx, 45, RuntimeHelpers.GetObjectValue(acadLineTypeDash.ShapeOffsetY));
					}
					if ((2 & dlngCode74) == 2)
					{
						InternAddToDictLine(ref rlngIdx, 9, acadLineTypeDash.Text);
					}
					acadLineTypeDash = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadLineTypeDash2 = null;
			dobjAcadLineTypeDashes2 = null;
		}
	}
}
