using DXFLib.Acad;
using DXFLib.Basic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class File
	{
		private enum DXFCODETYPE
		{
			dxfCodeTypeNone,
			dxfCodeTypeStringLong,
			dxfCodeTypeStringShort,
			dxfCodeTypeStringHexRef,
			dxfCodeTypeStringHexBin,
			dxfCodeTypeStringHexID,
			dxfCodeTypeIntegerBoolean,
			dxfCodeTypeInteger8Bit,
			dxfCodeTypeInteger16Bit,
			dxfCodeTypeInteger32Bit,
			dxfCodeTypeLong,
			dxfCodeTypeDouble,
			dxfCodeTypeDecimal,
			dxfCodeType3DPoint
		}

		public delegate void ReadStartEventHandler(int Entries);

		public delegate void ReadEntryEventHandler(int Entry);

		public delegate void ReadEndEventHandler();

		private const string cstrClassName = "File";

		private bool mblnOpened;

		private string mstrAcadVer;

		private string mstrFileName;

		private int mlngEntry;

		private int mlngEntries;

		private int mlngLastCodeType;

		private string mstrLastSecName;

		private int mlngSecBeg;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private Dictionary<object, object> mobjDictWriteCodes;

		private Dictionary<object, object> mobjDictWriteValues;

		private AcadDocument mobjAcadDocument;

		private AcadDatabase mobjAcadDatabase;

		private StreamReader mobjStreamReader;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecBlocks")]
		private SecBlocks _mobjSecBlocks;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecClasses")]
		private SecClasses _mobjSecClasses;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecEntities")]
		private SecEntities _mobjSecEntities;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecHeader")]
		private SecHeader _mobjSecHeader;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecObjects")]
		private SecObjects _mobjSecObjects;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecTables")]
		private SecTables _mobjSecTables;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjSecThumbnail")]
		private SecThumbnail _mobjSecThumbnail;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadStartEventHandler ReadStartEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEntryEventHandler ReadEntryEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEndEventHandler ReadEndEvent;

		[field: AccessedThroughProperty("mobjSecBlocks")]
		private SecBlocks mobjSecBlocks
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecClasses")]
		private SecClasses mobjSecClasses
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecEntities")]
		private SecEntities mobjSecEntities
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecHeader")]
		private SecHeader mobjSecHeader
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecObjects")]
		private SecObjects mobjSecObjects
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecTables")]
		private SecTables mobjSecTables
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		[field: AccessedThroughProperty("mobjSecThumbnail")]
		private SecThumbnail mobjSecThumbnail
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		public string FileName => mstrFileName;

		public event ReadStartEventHandler ReadStart
		{
			[CompilerGenerated]
			add
			{
				ReadStartEventHandler readStartEventHandler = ReadStartEvent;
				ReadStartEventHandler readStartEventHandler2;
				do
				{
					readStartEventHandler2 = readStartEventHandler;
					ReadStartEventHandler value2 = (ReadStartEventHandler)Delegate.Combine(readStartEventHandler2, value);
					readStartEventHandler = Interlocked.CompareExchange(ref ReadStartEvent, value2, readStartEventHandler2);
				}
				while ((object)readStartEventHandler != readStartEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ReadStartEventHandler readStartEventHandler = ReadStartEvent;
				ReadStartEventHandler readStartEventHandler2;
				do
				{
					readStartEventHandler2 = readStartEventHandler;
					ReadStartEventHandler value2 = (ReadStartEventHandler)Delegate.Remove(readStartEventHandler2, value);
					readStartEventHandler = Interlocked.CompareExchange(ref ReadStartEvent, value2, readStartEventHandler2);
				}
				while ((object)readStartEventHandler != readStartEventHandler2);
			}
		}

		public event ReadEntryEventHandler ReadEntry
		{
			[CompilerGenerated]
			add
			{
				ReadEntryEventHandler readEntryEventHandler = ReadEntryEvent;
				ReadEntryEventHandler readEntryEventHandler2;
				do
				{
					readEntryEventHandler2 = readEntryEventHandler;
					ReadEntryEventHandler value2 = (ReadEntryEventHandler)Delegate.Combine(readEntryEventHandler2, value);
					readEntryEventHandler = Interlocked.CompareExchange(ref ReadEntryEvent, value2, readEntryEventHandler2);
				}
				while ((object)readEntryEventHandler != readEntryEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ReadEntryEventHandler readEntryEventHandler = ReadEntryEvent;
				ReadEntryEventHandler readEntryEventHandler2;
				do
				{
					readEntryEventHandler2 = readEntryEventHandler;
					ReadEntryEventHandler value2 = (ReadEntryEventHandler)Delegate.Remove(readEntryEventHandler2, value);
					readEntryEventHandler = Interlocked.CompareExchange(ref ReadEntryEvent, value2, readEntryEventHandler2);
				}
				while ((object)readEntryEventHandler != readEntryEventHandler2);
			}
		}

		public event ReadEndEventHandler ReadEnd
		{
			[CompilerGenerated]
			add
			{
				ReadEndEventHandler readEndEventHandler = ReadEndEvent;
				ReadEndEventHandler readEndEventHandler2;
				do
				{
					readEndEventHandler2 = readEndEventHandler;
					ReadEndEventHandler value2 = (ReadEndEventHandler)Delegate.Combine(readEndEventHandler2, value);
					readEndEventHandler = Interlocked.CompareExchange(ref ReadEndEvent, value2, readEndEventHandler2);
				}
				while ((object)readEndEventHandler != readEndEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ReadEndEventHandler readEndEventHandler = ReadEndEvent;
				ReadEndEventHandler readEndEventHandler2;
				do
				{
					readEndEventHandler2 = readEndEventHandler;
					ReadEndEventHandler value2 = (ReadEndEventHandler)Delegate.Remove(readEndEventHandler2, value);
					readEndEventHandler = Interlocked.CompareExchange(ref ReadEndEvent, value2, readEndEventHandler2);
				}
				while ((object)readEndEventHandler != readEndEventHandler2);
			}
		}

		private void mobjSecBlocks_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecClasses_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecEntities_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecHeader_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecObjects_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecTables_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		private void mobjSecThumbnail_ReadAddEntry(int AddEntry)
		{
			checked
			{
				mlngEntry += AddEntry;
				ReadEntryEvent?.Invoke(mlngEntry);
			}
		}

		public File()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~File()
		{
			Class_Terminate_Renamed();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				mobjStreamReader = null;
				mobjAcadDatabase = null;
				mobjAcadDocument = null;
				mblnOpened = false;
			}
		}

		public void Init(ref AcadDocument robjAcadDocument)
		{
			mobjAcadDocument = robjAcadDocument;
			mobjAcadDatabase = mobjAcadDocument.Database;
			mstrAcadVer = mobjAcadDocument.AcadVer;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public bool ReadFile(string vstrFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			InternClear();
			if (Operators.CompareString(FileSystem.Dir(vstrFileName), null, TextCompare: false) == 0)
			{
				nrstrErrMsg = "Die Datei existiert nicht.";
				InternClear();
			}
			else if (!InternIsValidFileName(vstrFileName))
			{
				nrstrErrMsg = "Ungültiger Dateityp.";
				InternClear();
			}
			else if (!InternReadFile(vstrFileName, ref nrstrErrMsg))
			{
				InternClear();
			}
			else if (!InternGetSections(ref nrstrErrMsg))
			{
				InternClear();
			}
			else if (!InternCheckSections(ref nrstrErrMsg))
			{
				InternClear();
			}
			else
			{
				if (InternReadSections(ref nrstrErrMsg))
				{
					mstrFileName = vstrFileName;
					return true;
				}
				InternClear();
			}
			bool ReadFile = default(bool);
			return ReadFile;
		}

		public void ListFile()
		{
			InternListSections();
		}

		public bool WriteFile(string vstrFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			if (!InternIsValidFileName(vstrFileName))
			{
				nrstrErrMsg = "Ungültiger Dateityp.";
			}
			else if (InternWriteFile(vstrFileName, ref nrstrErrMsg))
			{
				mstrFileName = vstrFileName;
				return true;
			}
			bool WriteFile = default(bool);
			return WriteFile;
		}

		private void InternClear()
		{
			InternClearRead();
			InternClearWrite();
			mstrFileName = null;
			if (mobjSecBlocks != null)
			{
				mobjSecBlocks.FriendQuit();
			}
			if (mobjSecClasses != null)
			{
				mobjSecClasses.FriendQuit();
			}
			if (mobjSecEntities != null)
			{
				mobjSecEntities.FriendQuit();
			}
			if (mobjSecHeader != null)
			{
				mobjSecHeader.FriendQuit();
			}
			if (mobjSecObjects != null)
			{
				mobjSecObjects.FriendQuit();
			}
			if (mobjSecTables != null)
			{
				mobjSecTables.FriendQuit();
			}
			if (mobjSecThumbnail != null)
			{
				mobjSecThumbnail.FriendQuit();
			}
			mobjSecBlocks = null;
			mobjSecClasses = null;
			mobjSecEntities = null;
			mobjSecHeader = null;
			mobjSecObjects = null;
			mobjSecTables = null;
			mobjSecThumbnail = null;
		}

		private void InternClearRead()
		{
			if (mobjDictReadCodes != null)
			{
				mobjDictReadCodes.Clear();
			}
			if (mobjDictReadValues != null)
			{
				mobjDictReadValues.Clear();
			}
			mobjDictReadCodes = null;
			mobjDictReadValues = null;
		}

		private void InternClearWrite()
		{
			if (mobjDictWriteCodes != null)
			{
				mobjDictWriteCodes.Clear();
			}
			if (mobjDictWriteValues != null)
			{
				mobjDictWriteValues.Clear();
			}
			mobjDictWriteCodes = null;
			mobjDictWriteValues = null;
		}

		private bool InternIsValidFileName(string vstrFileName)
		{
			return LikeOperator.LikeString(Strings.UCase(vstrFileName), Strings.UCase("*.dxf"), CompareMethod.Binary);
		}

		private bool InternReadFile(string vstrFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			try
			{
				mobjStreamReader = new StreamReader(vstrFileName);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
			}
			bool InternReadFile = default(bool);
			if (mobjStreamReader != null)
			{
				mobjDictReadCodes = new Dictionary<object, object>();
				mobjDictReadValues = new Dictionary<object, object>();
				int dlngCount = 0;
				bool dblnCode = true;
				string dstrLine3 = hwpDxf_Functions.BkDXF_ReadLine(mobjStreamReader);
				bool dblnAdded = InternAddLineToDict(ref dblnCode, ref dlngCount, dstrLine3, ref nrstrErrMsg);
				bool dblnStop = default(bool);
				while (!mobjStreamReader.EndOfStream && dblnAdded && !dblnStop)
				{
					dstrLine3 = hwpDxf_Functions.BkDXF_ReadLine(mobjStreamReader);
					dblnAdded = InternAddLineToDict(ref dblnCode, ref dlngCount, dstrLine3, ref nrstrErrMsg);
					dblnStop = (dblnCode && dlngCount == 4);
				}
				if (dblnAdded)
				{
					while (!mobjStreamReader.EndOfStream && dblnAdded)
					{
						dstrLine3 = hwpDxf_Functions.BkDXF_ReadLine(mobjStreamReader);
						dblnAdded = InternAddLineToDict(ref dblnCode, ref dlngCount, dstrLine3, ref nrstrErrMsg);
					}
				}
				if (dblnAdded)
				{
					if (mobjDictReadCodes.Count != mobjDictReadValues.Count)
					{
						nrstrErrMsg = "Die Zeilenanzahl der Datei ist ungültig.";
					}
					else
					{
						mlngEntry = 1;
						mlngEntries = mobjDictReadCodes.Count;
						InternReadFile = true;
					}
				}
				mobjStreamReader.Close();
			}
			mobjStreamReader = null;
			return InternReadFile;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private bool InternWriteFile(string vstrFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx2 = 0;
			int dlngCount = mobjDictReadCodes.Count;
			checked
			{
				string[] dastrLines = new string[dlngCount * 2 - 1 + 1];
				bool dblnError = default(bool);
				string dstrValue = default(string);
				for (; unchecked(dlngIdx2 < mobjDictReadCodes.Count && !dblnError); dlngIdx2++)
				{
					int dlngCode = Conversions.ToInteger(mobjDictReadCodes[dlngIdx2]);
					string dstrCode = Conversions.ToString(dlngCode);
					if (Strings.Len(dstrCode) < 3)
					{
						dstrCode = Strings.Space(3 - Strings.Len(dstrCode)) + dstrCode;
					}
					int dlngCodeType = InternGetCodeTypeNew(dlngCode);
					if (dlngCodeType == 0)
					{
						nrstrErrMsg = "Ungültiger Code.";
						dblnError = true;
						continue;
					}
					object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx2]);
					if (!InternValueToLine(RuntimeHelpers.GetObjectValue(dvarValue), dlngCodeType, ref dstrValue))
					{
						nrstrErrMsg = "Ungültiger Wert.";
						dblnError = true;
					}
					else
					{
						dastrLines[dlngIdx2 * 2] = dstrCode;
						dastrLines[dlngIdx2 * 2 + 1] = dstrValue;
					}
				}
				bool InternWriteFile2 = default(bool);
				if (!dblnError)
				{
					int dlngFileNumber = FileSystem.FreeFile();
					try
					{
						FileSystem.FileOpen(dlngFileNumber, vstrFileName, OpenMode.Output);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Die Datei konnte nicht geöffnet werden.\n" + ExceptionHelper.GetExceptionMessage(ex);
						InternWriteFile2 = false;
						ProjectData.ClearProjectError();
						return InternWriteFile2;
					}
					int num = Information.LBound(dastrLines);
					int num2 = Information.UBound(dastrLines);
					for (dlngIdx2 = num; dlngIdx2 <= num2; dlngIdx2++)
					{
						FileSystem.PrintLine(dlngFileNumber, dastrLines[dlngIdx2]);
					}
					FileSystem.FileClose(dlngFileNumber);
					return true;
				}
				return InternWriteFile2;
			}
		}

		private bool InternAddLineToDict(ref bool rblnCode, ref int rlngCount, string vstrLine, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			vstrLine = Strings.Trim(vstrLine);
			checked
			{
				if (rblnCode)
				{
					int dlngCode = default(int);
					if (InternLineToCode(vstrLine, ref dlngCode))
					{
						mobjDictReadCodes.Add(rlngCount, dlngCode);
						rblnCode = false;
						goto IL_00c0;
					}
					nrstrErrMsg = "Ungültiger Gruppencode in Zeile " + Conversions.ToString(rlngCount * 2 + 1) + ".";
				}
				else
				{
					object dvarValue = default(object);
					if (InternLineToValue(vstrLine, mlngLastCodeType, ref dvarValue))
					{
						mobjDictReadValues.Add(rlngCount, RuntimeHelpers.GetObjectValue(dvarValue));
						rlngCount++;
						rblnCode = true;
						goto IL_00c0;
					}
					nrstrErrMsg = "Ungültiger Wert in Zeile " + Conversions.ToString(rlngCount * 2 + 2) + ".";
				}
				bool InternAddLineToDict = default(bool);
				return InternAddLineToDict;
			}
		IL_00c0:
			return true;
		}

		private bool InternLineToCode(string vstrLine, ref int rlngCode)
		{
			rlngCode = -1;
			bool InternLineToCode2 = default(bool);
			try
			{
				rlngCode = Conversions.ToInteger(vstrLine);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				InternLineToCode2 = false;
				ProjectData.ClearProjectError();
				return InternLineToCode2;
			}
			mlngLastCodeType = InternGetCodeTypeNew(rlngCode);
			if (mlngLastCodeType != 0)
			{
				return true;
			}
			return InternLineToCode2;
		}

		private int InternGetCodeTypeNew(int vlngCode)
		{
			if ((vlngCode >= 0 && vlngCode <= 4) || (vlngCode >= 6 && vlngCode <= 9) || (vlngCode >= 300 && vlngCode <= 309) || (vlngCode >= 410 && vlngCode <= 419) || vlngCode == 999 || (vlngCode >= 1000 && vlngCode <= 1003) || (vlngCode >= 1006 && vlngCode <= 1009))
			{
				return 1;
			}
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && ((vlngCode >= 430 && vlngCode <= 439) || (vlngCode >= 470 && vlngCode <= 479)))
			{
				return 1;
			}
			if (vlngCode == 100 || vlngCode == 102 || vlngCode == 278)
			{
				return 2;
			}
			if (vlngCode == 5 || vlngCode == 105 || (vlngCode >= 320 && vlngCode <= 329) || (vlngCode >= 390 && vlngCode <= 399) || vlngCode == 1005)
			{
				return 3;
			}
			if ((vlngCode >= 310 && vlngCode <= 319) || vlngCode == 1004)
			{
				return 4;
			}
			if (vlngCode >= 330 && vlngCode <= 369)
			{
				return 5;
			}
			if (vlngCode >= 290 && vlngCode <= 299)
			{
				return 6;
			}
			if ((vlngCode >= 280 && vlngCode <= 289) || (vlngCode >= 370 && vlngCode <= 379) || (vlngCode >= 380 && vlngCode <= 389))
			{
				return 7;
			}
			if ((vlngCode >= 60 && vlngCode <= 79) || (vlngCode >= 170 && vlngCode <= 179) || (vlngCode >= 270 && vlngCode <= 277) || vlngCode == 279 || (vlngCode >= 400 && vlngCode <= 409) || (vlngCode >= 1060 && vlngCode <= 1070))
			{
				return 8;
			}
			if ((vlngCode >= 90 && vlngCode <= 99) || vlngCode == 1071)
			{
				return 9;
			}
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && ((vlngCode >= 420 && vlngCode <= 429) || (vlngCode >= 440 && vlngCode <= 449)))
			{
				return 9;
			}
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && vlngCode >= 450 && vlngCode <= 459)
			{
				return 10;
			}
			if ((1 & ((vlngCode == 19 || vlngCode == 29 || (vlngCode >= 38 && vlngCode <= 59) || (vlngCode >= 1014 && vlngCode <= 1019) || (vlngCode >= 1024 && vlngCode <= 1029) || (vlngCode >= 1034 && vlngCode <= 1059)) ? 1 : 0)) != 0)
			{
				return 11;
			}
			if ((0 & ((vlngCode == 19 || vlngCode == 29 || (vlngCode >= 1014 && vlngCode <= 1019) || (vlngCode >= 1024 && vlngCode <= 1029)) ? 1 : 0)) != 0)
			{
				return 11;
			}
			if ((1 & ((vlngCode >= 140 && vlngCode <= 149) ? 1 : 0)) != 0)
			{
				return 12;
			}
			if ((0 & (((vlngCode >= 38 && vlngCode <= 59) || (vlngCode >= 140 && vlngCode <= 149) || (vlngCode >= 1034 && vlngCode <= 1059)) ? 1 : 0)) != 0)
			{
				return 12;
			}
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && vlngCode >= 460 && vlngCode <= 469)
			{
				return 12;
			}
			if ((vlngCode >= 10 && vlngCode <= 18) || (vlngCode >= 20 && vlngCode <= 28) || (vlngCode >= 30 && vlngCode <= 37) || (vlngCode >= 110 && vlngCode <= 112) || (vlngCode >= 120 && vlngCode <= 122) || (vlngCode >= 130 && vlngCode <= 132) || (vlngCode >= 210 && vlngCode <= 213) || (vlngCode >= 220 && vlngCode <= 223) || (vlngCode >= 230 && vlngCode <= 233) || (vlngCode >= 1010 && vlngCode <= 1013) || (vlngCode >= 1020 && vlngCode <= 1023) || (vlngCode >= 1030 && vlngCode <= 1033))
			{
				return 13;
			}
			return 0;
		}

		private bool InternValueToLine(object vvarValue, int vlngCodeType, ref string rstrLine)
		{
			rstrLine = null;
			switch (vlngCodeType)
			{
				case 1:
					rstrLine = Conversions.ToString(vvarValue);
					goto IL_012a;
				case 2:
					rstrLine = Conversions.ToString(vvarValue);
					goto IL_012a;
				case 3:
					rstrLine = Conversions.ToString(vvarValue);
					goto IL_012a;
				case 4:
					rstrLine = Conversions.ToString(vvarValue);
					goto IL_012a;
				case 5:
					rstrLine = hwpDxf_Functions.BkDXF_DblToHex(Conversions.ToDouble(vvarValue));
					goto IL_012a;
				case 6:
					rstrLine = InternIntegerToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				case 7:
					rstrLine = InternIntegerToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				case 8:
					rstrLine = InternIntegerToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				case 9:
					rstrLine = InternIntegerToLine(RuntimeHelpers.GetObjectValue(vvarValue), 9);
					goto IL_012a;
				case 10:
					rstrLine = InternIntegerToLine(RuntimeHelpers.GetObjectValue(vvarValue), 9);
					goto IL_012a;
				case 11:
					rstrLine = InternDoubleToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				case 12:
					rstrLine = InternDecimalToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				case 13:
					rstrLine = InternDecimalToLine(RuntimeHelpers.GetObjectValue(vvarValue));
					goto IL_012a;
				default:
					{
						bool InternValueToLine = default(bool);
						return InternValueToLine;
					}
				IL_012a:
					return true;
			}
		}

		private string InternIntegerToLine(object vvarValue, int nvlngLen = 6)
		{
			string dstrLine = Conversions.ToString(vvarValue);
			if (Strings.Len(dstrLine) < nvlngLen)
			{
				dstrLine = Strings.Space(checked(nvlngLen - Strings.Len(dstrLine))) + dstrLine;
			}
			return dstrLine;
		}

		private string InternDoubleToLine(object vvarValue)
		{
			string dstrLine3 = Conversions.ToString(vvarValue);
			dstrLine3 = Strings.Replace(dstrLine3, ",", ".");
			checked
			{
				if (LikeOperator.LikeString(dstrLine3, "*E*", CompareMethod.Binary))
				{
					string dstrSign;
					if (!LikeOperator.LikeString(dstrLine3, "#*", CompareMethod.Binary))
					{
						dstrSign = Strings.Left(dstrLine3, 1);
						dstrLine3 = Strings.Mid(dstrLine3, 2);
					}
					else
					{
						dstrSign = null;
					}
					int dlngPos2 = Strings.InStr(1, dstrLine3, "E");
					string dstrNumber = Strings.Left(dstrLine3, dlngPos2 - 1);
					dstrLine3 = Strings.Mid(dstrLine3, dlngPos2);
					dlngPos2 = Strings.InStr(1, dstrNumber, ".");
					string dstrPreNumber;
					string dstrPostNumber;
					if (dlngPos2 == 0)
					{
						dstrPreNumber = dstrNumber;
						dstrPostNumber = new string('0', 15);
					}
					else
					{
						dstrPreNumber = Strings.Left(dstrNumber, dlngPos2 - 1);
						dstrPostNumber = Strings.Mid(dstrNumber, dlngPos2 + 1);
						int dlngLen = Strings.Len(dstrPostNumber);
						if (dlngLen < 15)
						{
							dstrPostNumber += new string('0', 15 - dlngLen);
						}
					}
					dstrLine3 = dstrSign + dstrPreNumber + "." + dstrPostNumber + dstrLine3;
				}
				else if (!LikeOperator.LikeString(dstrLine3, "*.*", CompareMethod.Binary))
				{
					dstrLine3 += ".0";
				}
				return dstrLine3;
			}
		}

		private string InternDecimalToLine(object vvarValue)
		{
			string dstrLineDec6 = Conversions.ToString(Conversions.ToDecimal(vvarValue));
			string dstrLinedbl = Conversions.ToString(Conversions.ToDouble(vvarValue));
			checked
			{
				if (LikeOperator.LikeString(dstrLinedbl, "*E*", CompareMethod.Binary))
				{
					if (LikeOperator.LikeString(dstrLinedbl, "*E-16", CompareMethod.Binary))
					{
						dstrLineDec6 = Strings.Replace(dstrLineDec6, ",", ".");
					}
					else
					{
						dstrLineDec6 = dstrLinedbl;
						dstrLineDec6 = Strings.Replace(dstrLineDec6, ",", ".");
						string dstrSign;
						if (!LikeOperator.LikeString(dstrLineDec6, "#*", CompareMethod.Binary))
						{
							dstrSign = Strings.Left(dstrLineDec6, 1);
							dstrLineDec6 = Strings.Mid(dstrLineDec6, 2);
						}
						else
						{
							dstrSign = null;
						}
						int dlngPos2 = Strings.InStr(1, dstrLineDec6, "E");
						string dstrNumber = Strings.Left(dstrLineDec6, dlngPos2 - 1);
						dstrLineDec6 = Strings.Mid(dstrLineDec6, dlngPos2);
						dlngPos2 = Strings.InStr(1, dstrNumber, ".");
						string dstrPreNumber;
						string dstrPostNumber;
						if (dlngPos2 == 0)
						{
							dstrPreNumber = dstrNumber;
							dstrPostNumber = new string('0', 15);
						}
						else
						{
							dstrPreNumber = Strings.Left(dstrNumber, dlngPos2 - 1);
							dstrPostNumber = Strings.Mid(dstrNumber, dlngPos2 + 1);
							int dlngLen = Strings.Len(dstrPostNumber);
							if (dlngLen < 15)
							{
								dstrPostNumber += new string('0', 15 - dlngLen);
							}
						}
						dstrLineDec6 = dstrSign + dstrPreNumber + "." + dstrPostNumber + dstrLineDec6;
					}
				}
				else
				{
					Type typeFromHandle = typeof(Math);
					object[] obj = new object[2]
					{
					vvarValue,
					15
					};
					object[] array = obj;
					bool[] obj2 = new bool[2]
					{
					true,
					false
					};
					bool[] array2 = obj2;
					object value = NewLateBinding.LateGet(null, typeFromHandle, "Round", obj, null, null, obj2);
					if (array2[0])
					{
						vvarValue = RuntimeHelpers.GetObjectValue(array[0]);
					}
					dstrLineDec6 = Conversions.ToString(value);
					dstrLineDec6 = Strings.Replace(dstrLineDec6, ",", ".");
					if (!LikeOperator.LikeString(dstrLineDec6, "*.*", CompareMethod.Binary))
					{
						dstrLineDec6 += ".0";
					}
				}
				return dstrLineDec6;
			}
		}

		private bool InternLineToValue(string vstrLine, int vlngCodeType, ref object rvarValue)
		{
			rvarValue = null;
			short dintValue = default(short);
			int dlngValue = default(int);
			double ddblValue = default(double);
			bool InternLineToValue2 = default(bool);
			switch (vlngCodeType)
			{
				case 1:
					rvarValue = vstrLine;
					goto IL_01df;
				case 2:
					if (Strings.Len(vstrLine) > 255)
					{
						break;
					}
					rvarValue = vstrLine;
					goto IL_01df;
				case 3:
					rvarValue = vstrLine;
					goto IL_01df;
				case 4:
					rvarValue = vstrLine;
					goto IL_01df;
				case 5:
					try
					{
						dlngValue = checked((int)Math.Round(hwpDxf_Functions.BkDXF_HexToDbl(vstrLine)));
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						InternLineToValue2 = false;
						ProjectData.ClearProjectError();
						return InternLineToValue2;
					}
					rvarValue = dlngValue;
					goto IL_01df;
				case 6:
					if (!InternLineToInteger(vstrLine, ref dintValue))
					{
						break;
					}
					rvarValue = dintValue;
					goto IL_01df;
				case 7:
					if (!InternLineToInteger(vstrLine, ref dintValue))
					{
						break;
					}
					rvarValue = dintValue;
					goto IL_01df;
				case 8:
					if (!InternLineToInteger(vstrLine, ref dintValue))
					{
						break;
					}
					rvarValue = dintValue;
					goto IL_01df;
				case 9:
					if (!InternLineToLong(vstrLine, ref dlngValue))
					{
						break;
					}
					rvarValue = dlngValue;
					goto IL_01df;
				case 10:
					if (!InternLineToLong(vstrLine, ref dlngValue))
					{
						break;
					}
					rvarValue = dlngValue;
					goto IL_01df;
				case 11:
					if (!InternLineToDouble(vstrLine, ref ddblValue))
					{
						break;
					}
					rvarValue = ddblValue;
					goto IL_01df;
				case 12:
					{
						bool flag2 = false;
						if (!InternLineToDouble(vstrLine, ref ddblValue))
						{
							break;
						}
						rvarValue = ddblValue;
						goto IL_01df;
					}
				case 13:
					{
						bool flag = false;
						if (!InternLineToDouble(vstrLine, ref ddblValue))
						{
							break;
						}
						rvarValue = ddblValue;
						goto IL_01df;
					}
				IL_01df:
					return true;
			}
			return InternLineToValue2;
		}

		private bool InternLineToInteger(string vstrLine, ref short rintValue)
		{
			vstrLine = Strings.UCase(vstrLine);
			short dintValue;
			bool InternLineToInteger2 = default(bool);
			try
			{
				dintValue = Conversions.ToShort(vstrLine);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				InternLineToInteger2 = false;
				ProjectData.ClearProjectError();
				return InternLineToInteger2;
			}
			if (Operators.CompareString(Conversions.ToString((int)dintValue), vstrLine, TextCompare: false) == 0)
			{
				rintValue = dintValue;
				return true;
			}
			return InternLineToInteger2;
		}

		private bool InternLineToLong(string vstrLine, ref int rlngValue)
		{
			vstrLine = Strings.UCase(vstrLine);
			int dlngValue;
			bool InternLineToLong2 = default(bool);
			try
			{
				dlngValue = Conversions.ToInteger(vstrLine);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				InternLineToLong2 = false;
				ProjectData.ClearProjectError();
				return InternLineToLong2;
			}
			if (Operators.CompareString(Conversions.ToString(dlngValue), vstrLine, TextCompare: false) == 0)
			{
				rlngValue = dlngValue;
				return true;
			}
			return InternLineToLong2;
		}

		private bool InternLineToDouble(string vstrLine, ref double rdblValue)
		{
			vstrLine = Strings.UCase(vstrLine);
			vstrLine = Strings.Replace(vstrLine, ".", ",");
			double ddblValue;
			bool InternLineToDouble2 = default(bool);
			try
			{
				ddblValue = Conversions.ToDouble(vstrLine);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				InternLineToDouble2 = false;
				ProjectData.ClearProjectError();
				return InternLineToDouble2;
			}
			vstrLine = InternLineForDouble(vstrLine);
			if (Operators.CompareString(Conversions.ToString(ddblValue), vstrLine, TextCompare: false) == 0)
			{
				rdblValue = Conversions.ToDouble(vstrLine);
				return true;
			}
			return InternLineToDouble2;
		}

		private string InternLineForDouble(string vstrLine)
		{
			vstrLine = Strings.Trim(Strings.UCase(vstrLine));
			vstrLine = Strings.Replace(vstrLine, ".", ",");
			bool dblnMinus = default(bool);
			if (LikeOperator.LikeString(vstrLine, "-*", CompareMethod.Binary))
			{
				vstrLine = Strings.Mid(vstrLine, 2);
				dblnMinus = true;
			}
			else if (LikeOperator.LikeString(vstrLine, "+*", CompareMethod.Binary))
			{
				vstrLine = Strings.Mid(vstrLine, 2);
			}
			if (LikeOperator.LikeString(vstrLine, ",*", CompareMethod.Binary))
			{
				vstrLine = "0" + vstrLine;
			}
			int dlngPos2 = Strings.InStr(1, vstrLine, "E");
			int dlngExp = default(int);
			checked
			{
				if (dlngPos2 > 0)
				{
					try
					{
						dlngExp = Conversions.ToInteger(Strings.Mid(vstrLine, dlngPos2 + 1));
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						dlngExp = 0;
						ProjectData.ClearProjectError();
					}
					vstrLine = Strings.Mid(vstrLine, 1, dlngPos2 - 1);
					if (dlngExp != 0)
					{
						dlngPos2 = Strings.InStr(1, vstrLine, ",");
						string dstrLeft;
						string dstrRight;
						if (dlngPos2 > 0)
						{
							dstrLeft = Strings.Mid(vstrLine, 1, dlngPos2 - 1);
							dstrRight = Strings.Mid(vstrLine, dlngPos2 + 1);
						}
						else
						{
							dstrLeft = vstrLine;
							dstrRight = null;
						}
						if (Math.Abs(dlngExp) >= 15)
						{
							dstrRight = Strings.Left(dstrRight, 9);
						}
						else if (dlngExp >= 0)
						{
							int num = dlngExp;
							for (int dlngIdx2 = 1; dlngIdx2 <= num; dlngIdx2++)
							{
								string dstrChar2 = Strings.Left(dstrRight, 1);
								if (Operators.CompareString(dstrChar2, null, TextCompare: false) == 0)
								{
									dstrChar2 = "0";
								}
								if (Operators.CompareString(dstrRight, null, TextCompare: false) != 0)
								{
									dstrRight = Strings.Mid(dstrRight, 2);
								}
								dstrLeft += dstrChar2;
							}
						}
						else
						{
							int num2 = Math.Abs(dlngExp);
							for (int dlngIdx2 = 1; dlngIdx2 <= num2; dlngIdx2++)
							{
								string dstrChar2 = Strings.Right(dstrLeft, 1);
								if (Operators.CompareString(dstrChar2, null, TextCompare: false) == 0)
								{
									dstrChar2 = "0";
								}
								if (Operators.CompareString(dstrLeft, null, TextCompare: false) != 0)
								{
									dstrLeft = Strings.Mid(dstrLeft, 1, Strings.Len(dstrLeft) - 1);
								}
								dstrRight = dstrChar2 + dstrRight;
							}
							if (Operators.CompareString(dstrLeft, null, TextCompare: false) == 0)
							{
								dstrLeft = "0";
							}
						}
						vstrLine = dstrLeft + "," + dstrRight;
					}
				}
				while (LikeOperator.LikeString(vstrLine, "*0", CompareMethod.Binary))
				{
					vstrLine = Strings.Left(vstrLine, Strings.Len(vstrLine) - 1);
				}
				if (LikeOperator.LikeString(vstrLine, "*,", CompareMethod.Binary))
				{
					vstrLine = Strings.Left(vstrLine, Strings.Len(vstrLine) - 1);
				}
				if (LikeOperator.LikeString(vstrLine, "*,*", CompareMethod.Binary))
				{
					vstrLine = Conversions.ToString(Conversions.ToDouble(vstrLine));
				}
			}
			if (dlngExp >= 15)
			{
				vstrLine = vstrLine + "E+" + Conversions.ToString(dlngExp);
			}
			else if (dlngExp > 0 && dlngExp <= 15)
			{
				vstrLine = vstrLine + "E" + Conversions.ToString(dlngExp);
			}
			if (dblnMinus)
			{
				vstrLine = "-" + vstrLine;
			}
			return vstrLine;
		}

		private bool InternLineToDecimal(string vstrLine, ref object rdecValue)
		{
			bool dblnErrOccured = false;
			vstrLine = Strings.UCase(vstrLine);
			vstrLine = Strings.Replace(vstrLine, ".", ",");
			object ddecValue;
			bool InternLineToDecimal2 = default(bool);
			try
			{
				ddecValue = Conversions.ToDecimal(vstrLine);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				InternLineToDecimal2 = true;
				ProjectData.ClearProjectError();
				return InternLineToDecimal2;
			}
			vstrLine = InternLineForDecimal(vstrLine);
			string dstrVale = Conversions.ToString(ddecValue);
			if (Operators.CompareString(dstrVale, vstrLine, TextCompare: false) == 0)
			{
				rdecValue = RuntimeHelpers.GetObjectValue(ddecValue);
				return true;
			}
			return InternLineToDecimal2;
		}

		private string InternLineForDecimal(string vstrLine)
		{
			vstrLine = Strings.Trim(Strings.UCase(vstrLine));
			vstrLine = Strings.Replace(vstrLine, ".", ",");
			bool dblnMinus = default(bool);
			if (LikeOperator.LikeString(vstrLine, "-*", CompareMethod.Binary))
			{
				vstrLine = Strings.Mid(vstrLine, 2);
				dblnMinus = true;
			}
			else if (LikeOperator.LikeString(vstrLine, "+*", CompareMethod.Binary))
			{
				vstrLine = Strings.Mid(vstrLine, 2);
			}
			if (LikeOperator.LikeString(vstrLine, ",*", CompareMethod.Binary))
			{
				vstrLine = "0" + vstrLine;
			}
			int dlngPos2 = Strings.InStr(1, vstrLine, "E");
			checked
			{
				if (dlngPos2 > 0)
				{
					int dlngExp;
					try
					{
						dlngExp = Conversions.ToInteger(Strings.Mid(vstrLine, dlngPos2 + 1));
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						dlngExp = 0;
						ProjectData.ClearProjectError();
					}
					vstrLine = Strings.Mid(vstrLine, 1, dlngPos2 - 1);
					if (dlngExp != 0)
					{
						dlngPos2 = Strings.InStr(1, vstrLine, ",");
						string dstrLeft;
						string dstrRight;
						if (dlngPos2 > 0)
						{
							dstrLeft = Strings.Mid(vstrLine, 1, dlngPos2 - 1);
							dstrRight = Strings.Mid(vstrLine, dlngPos2 + 1);
						}
						else
						{
							dstrLeft = vstrLine;
							dstrRight = null;
						}
						if (dlngExp >= 0)
						{
							int num = dlngExp;
							for (int dlngIdx2 = 1; dlngIdx2 <= num; dlngIdx2++)
							{
								string dstrChar2 = Strings.Left(dstrRight, 1);
								if (Operators.CompareString(dstrChar2, null, TextCompare: false) == 0)
								{
									dstrChar2 = "0";
								}
								if (Operators.CompareString(dstrRight, null, TextCompare: false) != 0)
								{
									dstrRight = Strings.Mid(dstrRight, 2);
								}
								dstrLeft += dstrChar2;
							}
						}
						else
						{
							int num2 = Math.Abs(dlngExp);
							for (int dlngIdx2 = 1; dlngIdx2 <= num2; dlngIdx2++)
							{
								string dstrChar2 = Strings.Right(dstrLeft, 1);
								if (Operators.CompareString(dstrChar2, null, TextCompare: false) == 0)
								{
									dstrChar2 = "0";
								}
								if (Operators.CompareString(dstrLeft, null, TextCompare: false) != 0)
								{
									dstrLeft = Strings.Mid(dstrLeft, 1, Strings.Len(dstrLeft) - 1);
								}
								dstrRight = dstrChar2 + dstrRight;
							}
							if (Operators.CompareString(dstrLeft, null, TextCompare: false) == 0)
							{
								dstrLeft = "0";
							}
						}
						vstrLine = dstrLeft + "," + dstrRight;
					}
				}
				if (dblnMinus)
				{
					vstrLine = "-" + vstrLine;
				}
				return vstrLine;
			}
		}

		private bool InternGetSections(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngCount = 1;
			bool dblnStart = false;
			checked
			{
				int num = mobjDictReadCodes.Count - 1;
				int dlngIdx = 0;
				while (true)
				{
					if (dlngIdx <= num)
					{
						if (Conversions.ToInteger(mobjDictReadCodes[dlngIdx]) == 0)
						{
							string dstrBracket = Conversions.ToString(mobjDictReadValues[dlngIdx]);
							if (InternCreateSection(dlngIdx, dstrBracket, ref dblnStart, ref dlngCount, ref nrstrErrMsg))
							{
								break;
							}
						}
						else if (!dblnStart)
						{
							nrstrErrMsg = "Fehlende Startklammer in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
							break;
						}
						dlngIdx++;
						continue;
					}
					if (dblnStart)
					{
						nrstrErrMsg = "Fehlende Endklammer in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						break;
					}
					return true;
				}
				bool InternGetSections = default(bool);
				return InternGetSections;
			}
		}

		private bool InternCreateSection(int vlngIdx, string vstrBracket, ref bool rblnStart, ref int rlngCount, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				if (Operators.CompareString(vstrBracket, "SECTION", TextCompare: false) != 0)
				{
					if (Operators.CompareString(vstrBracket, "ENDSEC", TextCompare: false) == 0)
					{
						if (!rblnStart)
						{
							nrstrErrMsg = "Doppelte Endklammer in Zeile " + Conversions.ToString(vlngIdx * 2 + 2) + ".";
							return true;
						}
						int dlngSecEnd = vlngIdx - 1;
						switch (mstrLastSecName)
						{
							case "HEADER":
								if (rlngCount == 1)
								{
									InternCreateSecHeader(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "CLASSES":
								if (rlngCount == 2)
								{
									InternCreateSecClasses(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "TABLES":
								if (rlngCount == 3)
								{
									InternCreateSecTables(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "BLOCKS":
								if (rlngCount == 4)
								{
									InternCreateSecBlocks(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "ENTITIES":
								if (rlngCount == 5)
								{
									InternCreateSecEntities(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "OBJECTS":
								if (rlngCount == 6)
								{
									InternCreateSecObjects(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
							case "THUMNAILIMAGE":
								if (rlngCount == 7)
								{
									InternCreateSecThumbnail(mlngSecBeg, dlngSecEnd);
									rlngCount++;
									break;
								}
								nrstrErrMsg = "Ungültige Abschnittsreihenfolge ab Zeile " + Conversions.ToString(mlngSecBeg * 2 + 1) + ".";
								return true;
						}
						rblnStart = false;
					}
				}
				else
				{
					if (rblnStart)
					{
						nrstrErrMsg = "Doppelte Startklammer in Zeile " + Conversions.ToString(vlngIdx * 2 + 2) + ".";
						return true;
					}
					int dlngCode = Conversions.ToInteger(mobjDictReadCodes[vlngIdx + 1]);
					if (dlngCode != 2)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Abschnitt in Zeile " + Conversions.ToString((vlngIdx + 1) * 2 + 1) + ".";
						return true;
					}
					mstrLastSecName = Conversions.ToString(mobjDictReadValues[vlngIdx + 1]);
					if (!InternCheckSecName(mstrLastSecName))
					{
						nrstrErrMsg = "Ungültiger Name für Abschnitt in Zeile " + Conversions.ToString((vlngIdx + 1) * 2 + 2) + ".";
						return true;
					}
					mlngSecBeg = vlngIdx + 1;
					rblnStart = true;
				}
				bool InternCreateSection = default(bool);
				return InternCreateSection;
			}
		}

		private bool InternCheckSecName(string vstrSecName)
		{
			switch (vstrSecName)
			{
				case "HEADER":
					return true;
				case "CLASSES":
					return true;
				case "TABLES":
					return true;
				case "BLOCKS":
					return true;
				case "ENTITIES":
					return true;
				case "OBJECTS":
					return true;
				case "THUMNAILIMAGE":
					return true;
				default:
					{
						bool dblnValid = default(bool);
						return dblnValid;
					}
			}
		}

		private void InternCreateSecBlocks(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecBlocks = new SecBlocks();
			mobjSecBlocks.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecBlocks.SecBeg = vlngSecBeg;
			mobjSecBlocks.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecClasses(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecClasses = new SecClasses();
			mobjSecClasses.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecClasses.SecBeg = vlngSecBeg;
			mobjSecClasses.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecEntities(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecEntities = new SecEntities();
			mobjSecEntities.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecEntities.SecBeg = vlngSecBeg;
			mobjSecEntities.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecHeader(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecHeader = new SecHeader();
			mobjSecHeader.Init(ref mobjAcadDocument, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecHeader.SecBeg = vlngSecBeg;
			mobjSecHeader.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecObjects(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecObjects = new SecObjects();
			mobjSecObjects.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecObjects.SecBeg = vlngSecBeg;
			mobjSecObjects.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecTables(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecTables = new SecTables();
			mobjSecTables.Init(ref mobjAcadDatabase, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecTables.SecBeg = vlngSecBeg;
			mobjSecTables.SecEnd = vlngSecEnd;
		}

		private void InternCreateSecThumbnail(int vlngSecBeg, int vlngSecEnd)
		{
			mobjSecThumbnail = new SecThumbnail();
			mobjSecThumbnail.Init(ref mobjAcadDocument, ref mobjDictReadCodes, ref mobjDictReadValues);
			mobjSecThumbnail.SecBeg = vlngSecBeg;
			mobjSecThumbnail.SecEnd = vlngSecEnd;
		}

		private bool InternCheckSections(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			if (mobjSecHeader == null)
			{
				nrstrErrMsg = "Der Abschnitt HEADER fehlt.";
			}
			else if (mobjSecClasses == null)
			{
				nrstrErrMsg = "Der Abschnitt CLASSES fehlt.";
			}
			else if (mobjSecTables == null)
			{
				nrstrErrMsg = "Der Abschnitt TABLES fehlt.";
			}
			else if (mobjSecBlocks == null)
			{
				nrstrErrMsg = "Der Abschnitt BLOCKS fehlt.";
			}
			else if (mobjSecEntities == null)
			{
				nrstrErrMsg = "Der Abschnitt ENTITIES fehlt.";
			}
			else
			{
				if (mobjSecObjects != null)
				{
					return true;
				}
				nrstrErrMsg = "Der Abschnitt OBJECTS fehlt.";
			}
			bool InternCheckSections = default(bool);
			return InternCheckSections;
		}

		private bool InternReadSections(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			ReadStartEvent?.Invoke(mlngEntries);
			bool dblnError = default(bool);
			if (!mobjSecClasses.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!mobjSecTables.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!mobjSecHeader.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!mobjSecBlocks.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!mobjSecEntities.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (!mobjSecObjects.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			else if (mobjSecThumbnail != null && !mobjSecThumbnail.Read(ref nrstrErrMsg))
			{
				dblnError = true;
			}
			ReadEndEvent?.Invoke();
			return !dblnError;
		}

		private void InternListSections()
		{
			InternClearWrite();
			mobjDictReadCodes = new Dictionary<object, object>();
			mobjDictReadValues = new Dictionary<object, object>();
			InternCreateSecHeader(-1, -1);
			InternCreateSecClasses(-1, -1);
			InternCreateSecTables(-1, -1);
			InternCreateSecBlocks(-1, -1);
			InternCreateSecEntities(-1, -1);
			InternCreateSecObjects(-1, -1);
			InternCreateSecThumbnail(-1, -1);
			int dlngIdx = 0;
			mobjSecHeader.ListSection(ref dlngIdx);
			mobjSecClasses.ListSection(ref dlngIdx);
			mobjSecTables.ListSection(ref dlngIdx);
			mobjSecBlocks.ListSection(ref dlngIdx);
			mobjSecEntities.ListSection(ref dlngIdx);
			mobjSecObjects.ListSection(ref dlngIdx);
			InternAddToDictLine(ref dlngIdx, 0, "EOF");
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}
	}
}
