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
	class TableUCS
	{
		private const string cstrClassName = "TableUCS";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadUCSs mobjAcadUCSs;

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

		public string Name => "UCS";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableUCS()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableUCS()
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
				mobjAcadUCSs = null;
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
			mobjAcadUCSs = mobjAcadDatabase.UserCoordinateSystems;
			if (mobjAcadUCSs != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadUCSs acadUCSs = mobjAcadUCSs;
				InternAddToDictLine(ref rlngIdx, 2, acadUCSs.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadUCSs.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadUCSs.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadUCSs.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadUCSs.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadUCSs.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadUCSs.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadUCSs = null;
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
					mobjAcadUCSs = mobjAcadDatabase.FriendAddAcadObjectUCSs(ref nrstrErrMsg, ddblObjectID);
					if (mobjAcadUCSs == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadUCSs.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadUCSs.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadUCS(ddblObjectID, ref dlngIdx, ref mobjAcadUCSs, ref nrstrErrMsg))
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

		private bool InternReadUCS(double vdblDefOwnerID, ref int rlngIdx, ref AcadUCSs robjAcadUCSs, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadUCS = default(bool);
				AcadUCS dobjAcadUCS2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "UCS", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbUCSTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Benutzerkoordinatensystemname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 7], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 8], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 9], 12, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 10], 22, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 11], 32, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 12], 79, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Typ der orthogonalen Ansicht in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 13], 146, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Tiefe in Zeile " + Conversions.ToString(rlngIdx * 2 + 27) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						bool flag = false;
						double ddblOriginX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
						double ddblOriginY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
						double ddblOriginZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
						double ddblXVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 6]);
						double ddblXVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 7]);
						double ddblXVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 8]);
						double ddblYVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 9]);
						double ddblYVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 10]);
						double ddblYVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 11]);
						int dlngUCSOrthographic = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 12]);
						bool flag2 = false;
						double ddblDepth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 13]);
						rlngIdx += 14;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							if (robjAcadUCSs.FriendNameExist(dstrName))
							{
								nrstrErrMsg = "Benutzerkoordinatensystem " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
								dblnError = true;
							}
							else
							{
								dobjAcadUCS2 = robjAcadUCSs.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
								if (dobjAcadUCS2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadUCS acadUCS = dobjAcadUCS2;
									acadUCS.FriendLetFlags70 = dlngCode70;
									bool flag3 = false;
									acadUCS.Origin = new object[3]
									{
									ddblOriginX,
									ddblOriginY,
									ddblOriginZ
									};
									acadUCS.XVector = new object[3]
									{
									ddblXVectorX,
									ddblXVectorY,
									ddblXVectorZ
									};
									acadUCS.YVector = new object[3]
									{
									ddblYVectorX,
									ddblYVectorY,
									ddblYVectorZ
									};
									acadUCS.FriendLetUCSOrthographic = unchecked((Enums.AcOrthoView)dlngUCSOrthographic);
									bool flag4 = false;
									acadUCS.FriendLetDepth = ddblDepth;
									acadUCS.FriendSetDictReactors = dobjDictReactors2;
									acadUCS.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadUCS.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadUCS = null;
								}
							}
						}
					}
					InternReadUCS = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadUCS2 = null;
				return InternReadUCS;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadUCS dobjAcadUCS2;
			try
			{
				enumerator = mobjAcadUCSs.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadUCS2 = (AcadUCS)enumerator.Current;
					AcadUCS acadUCS = dobjAcadUCS2;
					InternAddToDictLine(ref rlngIdx, 0, acadUCS.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadUCS.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadUCS.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadUCS.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadUCS.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadUCS.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadUCS.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadUCS.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadUCS.Flags70);
					object dvarPoint3 = RuntimeHelpers.GetObjectValue(acadUCS.Origin);
					InternAddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					2
					}, null)));
					dvarPoint3 = RuntimeHelpers.GetObjectValue(acadUCS.XVector);
					InternAddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					2
					}, null)));
					dvarPoint3 = RuntimeHelpers.GetObjectValue(acadUCS.YVector);
					InternAddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 32, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint3, new object[1]
					{
					2
					}, null)));
					InternAddToDictLine(ref rlngIdx, 79, acadUCS.UCSOrthographic);
					InternAddToDictLine(ref rlngIdx, 146, RuntimeHelpers.GetObjectValue(acadUCS.Depth));
					acadUCS.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadUCS = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadUCS2 = null;
		}
	}
}
