using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class SecTables
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecTables";

		private bool mblnOpened;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private bool mblnFirstActive;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private TableAppid mobjTableAppid;

		private TableBlockRecord mobjTableBlockRecord;

		private TableDimStyle mobjTableDimStyle;

		private TableLayer mobjTableLayer;

		private TableLType mobjTableLType;

		private TableStyle mobjTableStyle;

		private TableUCS mobjTableUCS;

		private TableView mobjTableView;

		private TableVPort mobjTableVPort;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadAddEntryEventHandler ReadAddEntryEvent;

		internal int SecBeg
		{
			get
			{
				return mlngSecBeg;
			}
			set
			{
				mlngSecBeg = value;
			}
		}

		internal int SecEnd
		{
			get
			{
				return mlngSecEnd;
			}
			set
			{
				mlngSecEnd = value;
			}
		}

		public string Name => "ENTITIES";

		public int StartLine => checked((mlngSecBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngSecEnd + 1) * 2 + 2);

		public event ReadAddEntryEventHandler ReadAddEntry
		{
			[CompilerGenerated]
			add
			{
				ReadAddEntryEventHandler readAddEntryEventHandler = ReadAddEntryEvent;
				ReadAddEntryEventHandler readAddEntryEventHandler2;
				do
				{
					readAddEntryEventHandler2 = readAddEntryEventHandler;
					ReadAddEntryEventHandler value2 = (ReadAddEntryEventHandler)Delegate.Combine(readAddEntryEventHandler2, value);
					readAddEntryEventHandler = Interlocked.CompareExchange(ref ReadAddEntryEvent, value2, readAddEntryEventHandler2);
				}
				while ((object)readAddEntryEventHandler != readAddEntryEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ReadAddEntryEventHandler readAddEntryEventHandler = ReadAddEntryEvent;
				ReadAddEntryEventHandler readAddEntryEventHandler2;
				do
				{
					readAddEntryEventHandler2 = readAddEntryEventHandler;
					ReadAddEntryEventHandler value2 = (ReadAddEntryEventHandler)Delegate.Remove(readAddEntryEventHandler2, value);
					readAddEntryEventHandler = Interlocked.CompareExchange(ref ReadAddEntryEvent, value2, readAddEntryEventHandler2);
				}
				while ((object)readAddEntryEventHandler != readAddEntryEventHandler2);
			}
		}

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public SecTables()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecTables()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				if (mobjTableAppid != null)
				{
					mobjTableAppid.FriendQuit();
				}
				if (mobjTableBlockRecord != null)
				{
					mobjTableBlockRecord.FriendQuit();
				}
				if (mobjTableDimStyle != null)
				{
					mobjTableDimStyle.FriendQuit();
				}
				if (mobjTableLayer != null)
				{
					mobjTableLayer.FriendQuit();
				}
				if (mobjTableLType != null)
				{
					mobjTableLType.FriendQuit();
				}
				if (mobjTableStyle != null)
				{
					mobjTableStyle.FriendQuit();
				}
				if (mobjTableUCS != null)
				{
					mobjTableUCS.FriendQuit();
				}
				if (mobjTableView != null)
				{
					mobjTableView.FriendQuit();
				}
				if (mobjTableVPort != null)
				{
					mobjTableVPort.FriendQuit();
				}
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjTableAppid = null;
				mobjTableBlockRecord = null;
				mobjTableDimStyle = null;
				mobjTableLayer = null;
				mobjTableLType = null;
				mobjTableStyle = null;
				mobjTableUCS = null;
				mobjTableView = null;
				mobjTableVPort = null;
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
			checked
			{
				mlngLastEntry = mlngSecBeg - 1;
				bool Read = InternReadSection(ref nrstrErrMsg);
				InternCheckIndex(mlngSecEnd + 2);
				return Read;
			}
		}

		public void ListSection(ref int rlngIdx)
		{
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "TABLES");
			InternListSection(ref rlngIdx);
			mlngSecEnd = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 0, "ENDSEC");
		}

		private void InternIncreaseIndex(ref int rlngIdx, int vlngAdd)
		{
			checked
			{
				rlngIdx += vlngAdd;
				InternCheckIndex(rlngIdx);
			}
		}

		private void InternCheckIndex(int vlngIdx)
		{
			int dlngAdd = checked(vlngIdx - mlngLastEntry);
			mlngLastEntry = vlngIdx;
			if (dlngAdd > 0)
			{
				ReadAddEntryEvent?.Invoke(dlngAdd);
			}
		}

		private bool InternReadSection(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			mobjTableAppid = null;
			mobjTableBlockRecord = null;
			mobjTableDimStyle = null;
			mobjTableLayer = null;
			mobjTableLType = null;
			mobjTableStyle = null;
			mobjTableUCS = null;
			mobjTableView = null;
			mobjTableVPort = null;
			bool dblnError = default(bool);
			if (!InternGetTables(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!InternCheckTables(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!InternReadTables(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			return !dblnError;
		}

		private bool InternGetTables(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			int dlngCount = 1;
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			bool dblnError = default(bool);
			while (dlngIdx <= mlngSecEnd && !dblnError)
			{
				int dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
				object dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
				checked
				{
					if (dlngCode2 != 0)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Tabellenabschnittsbeginn in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						dblnError = true;
						continue;
					}
					if (Operators.ConditionalCompareObjectNotEqual(dvarValue2, "TABLE", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Name für Tabellenabschnittsbegin in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
						dblnError = true;
						continue;
					}
					InternIncreaseIndex(ref dlngIdx, 1);
					dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
					dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
					if (dlngCode2 != 2)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Tabellentyp in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						dblnError = true;
						continue;
					}
					InternIncreaseIndex(ref dlngIdx, 1);
					object left = dvarValue2;
					if (Operators.ConditionalCompareObjectEqual(left, "VPORT", TextCompare: false))
					{
						if (dlngCount == 1)
						{
							mobjTableVPort = new TableVPort();
							mobjTableVPort.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableVPort.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "LTYPE", TextCompare: false))
					{
						if (dlngCount == 2)
						{
							mobjTableLType = new TableLType();
							mobjTableLType.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableLType.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "LAYER", TextCompare: false))
					{
						if (dlngCount == 3)
						{
							mobjTableLayer = new TableLayer();
							mobjTableLayer.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableLayer.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "STYLE", TextCompare: false))
					{
						if (dlngCount == 4)
						{
							mobjTableStyle = new TableStyle();
							mobjTableStyle.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableStyle.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "VIEW", TextCompare: false))
					{
						if (dlngCount == 5)
						{
							mobjTableView = new TableView();
							mobjTableView.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableView.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "UCS", TextCompare: false))
					{
						if (dlngCount == 6)
						{
							mobjTableUCS = new TableUCS();
							mobjTableUCS.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableUCS.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "APPID", TextCompare: false))
					{
						if (dlngCount == 7)
						{
							mobjTableAppid = new TableAppid();
							mobjTableAppid.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableAppid.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "DIMSTYLE", TextCompare: false))
					{
						if (dlngCount == 8)
						{
							mobjTableDimStyle = new TableDimStyle();
							mobjTableDimStyle.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableDimStyle.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "BLOCK_RECORD", TextCompare: false))
					{
						if (dlngCount == 9)
						{
							mobjTableBlockRecord = new TableBlockRecord();
							mobjTableBlockRecord.TblBeg = dlngIdx - 1;
							InternGetOneTable(ref dlngIdx);
							mobjTableBlockRecord.TblEnd = dlngIdx - 2;
							dlngCount++;
						}
						else
						{
							nrstrErrMsg = "Ungültige Tabellenreihenfolge ab Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
							dblnError = true;
						}
					}
					else
					{
						nrstrErrMsg = "Ungültiger Name für Tabellentyp in Zeile " + Conversions.ToString(dlngIdx * 2) + ".";
						dblnError = true;
					}
				}
			}
			return !dblnError;
		}

		private void InternGetOneTable(ref int rlngIdx)
		{
			bool dblnStop = default(bool);
			while (rlngIdx <= mlngSecEnd && !dblnStop)
			{
				if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 0, TextCompare: false) && Operators.ConditionalCompareObjectEqual(mobjDictReadValues[rlngIdx], "ENDTAB", TextCompare: false))
				{
					dblnStop = true;
				}
				InternIncreaseIndex(ref rlngIdx, 1);
			}
		}

		private bool InternCheckTables(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			if (mobjTableVPort == null)
			{
				nrstrErrMsg = "Tabelle VPORT fehlt.";
			}
			else if (mobjTableLType == null)
			{
				nrstrErrMsg = "Tabelle LTYPE fehlt.";
			}
			else if (mobjTableLayer == null)
			{
				nrstrErrMsg = "Tabelle LAYER fehlt.";
			}
			else if (mobjTableStyle == null)
			{
				nrstrErrMsg = "Tabelle STYLE fehlt.";
			}
			else if (mobjTableView == null)
			{
				nrstrErrMsg = "Tabelle VIEW fehlt.";
			}
			else if (mobjTableUCS == null)
			{
				nrstrErrMsg = "Tabelle UCS fehlt.";
			}
			else if (mobjTableAppid == null)
			{
				nrstrErrMsg = "Tabelle APPID fehlt.";
			}
			else if (mobjTableDimStyle == null)
			{
				nrstrErrMsg = "Tabelle DIMSTYLE fehlt.";
			}
			else
			{
				if (mobjTableBlockRecord != null)
				{
					return true;
				}
				nrstrErrMsg = "Tabelle BLOCK_RECORD fehlt.";
			}
			bool InternCheckTables = default(bool);
			return InternCheckTables;
		}

		private bool InternReadTables(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			mobjTableVPort.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableLType.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableLayer.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableStyle.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableView.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableUCS.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableAppid.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableDimStyle.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableBlockRecord.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			if (mobjTableAppid.Read(ref nrstrErrMsg) && mobjTableLType.Read(ref nrstrErrMsg) && mobjTableStyle.Read(ref nrstrErrMsg) && mobjTableUCS.Read(ref nrstrErrMsg) && mobjTableLayer.Read(ref nrstrErrMsg) && mobjTableBlockRecord.Read(ref nrstrErrMsg) && mobjTableDimStyle.Read(ref nrstrErrMsg) && mobjTableVPort.Read(ref nrstrErrMsg) && mobjTableView.Read(ref nrstrErrMsg))
			{
				return true;
			}
			bool InternReadTables = default(bool);
			return InternReadTables;
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			mobjTableVPort = null;
			mobjTableLType = null;
			mobjTableLayer = null;
			mobjTableStyle = null;
			mobjTableView = null;
			mobjTableUCS = null;
			mobjTableAppid = null;
			mobjTableDimStyle = null;
			mobjTableBlockRecord = null;
			mobjTableVPort = new TableVPort();
			mobjTableLType = new TableLType();
			mobjTableLayer = new TableLayer();
			mobjTableStyle = new TableStyle();
			mobjTableView = new TableView();
			mobjTableUCS = new TableUCS();
			mobjTableAppid = new TableAppid();
			mobjTableDimStyle = new TableDimStyle();
			mobjTableBlockRecord = new TableBlockRecord();
			mobjTableVPort.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableLType.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableLayer.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableStyle.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableView.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableUCS.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableAppid.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableDimStyle.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableBlockRecord.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjTableVPort.ListTable(ref rlngIdx);
			mobjTableLType.ListTable(ref rlngIdx);
			mobjTableLayer.ListTable(ref rlngIdx);
			mobjTableStyle.ListTable(ref rlngIdx);
			mobjTableView.ListTable(ref rlngIdx);
			mobjTableUCS.ListTable(ref rlngIdx);
			mobjTableAppid.ListTable(ref rlngIdx);
			mobjTableDimStyle.ListTable(ref rlngIdx);
			mobjTableBlockRecord.ListTable(ref rlngIdx);
		}
	}
}
