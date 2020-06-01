using DXFLib.Acad;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class SecClasses
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecClasses";

		private const int clngAppWasAvailableTrue = 0;

		private const int clngAppWasAvailableFalse = 1;

		private bool mblnOpened;

		private string mstrAcadVer;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadClasses mobjAcadClasses;

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

		public SecClasses()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecClasses()
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
				mobjAcadClasses = null;
				mobjAcadDatabase = null;
				mblnOpened = false;
			}
		}

		public void Init(ref AcadDatabase robjAcadDatabase, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		{
			mstrAcadVer = robjAcadDatabase.Document.AcadVer;
			mobjAcadDatabase = robjAcadDatabase;
			mobjDictReadCodes = robjDictReadCodes;
			mobjDictReadValues = robjDictReadValues;
		}

		public bool Read(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			mobjAcadClasses = mobjAcadDatabase.Classes;
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
			mobjAcadClasses = mobjAcadDatabase.Classes;
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "CLASSES");
			if (mobjAcadClasses != null)
			{
				InternListSection(ref rlngIdx);
			}
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

		private bool InternReadSection(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			bool dblnError = default(bool);
			while (dlngIdx <= mlngSecEnd && !dblnError)
			{
				int dlngCode = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
				checked
				{
					if (dlngCode != 0)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Klassenbeginn in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(dvarValue, "CLASS", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Name für Klassenbeginn in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						InternIncreaseIndex(ref dlngIdx, 1);
						dblnError = !InternReadClass(ref dlngIdx, ref nrstrErrMsg);
					}
				}
			}
			return !dblnError;
		}

		private bool InternReadClass(ref int rlngIdx, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				int dlngStartIdx = rlngIdx * 2 - 1;
				bool dblnError = default(bool);
				AcadClass dobjAcadClass3;
				if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 1, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für DXF-Klassennamen in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Klassennamen in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 3, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Applikationsbeschreibung in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 90, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Proxy-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else
				{
					string dstrOriginalDXFName = Conversions.ToString(mobjDictReadValues[rlngIdx]);
					string dstrOriginalClassName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
					string dstrApplicationDescription = Conversions.ToString(mobjDictReadValues[rlngIdx + 2]);
					int dlngProxyFlags = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 3]);
					InternIncreaseIndex(ref rlngIdx, 4);
					int dlngInstanceCount = default(int);
					if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 91, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Instanzzählung für benutzerspezifische Klasse in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else
						{
							dlngInstanceCount = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
							InternIncreaseIndex(ref rlngIdx, 1);
						}
					}
					else
					{
						dlngInstanceCount = hwpDxf_Vars.plngInstanceCount;
					}
					if (!dblnError)
					{
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 280, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Applikationsladestatus in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 281, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Klassenableitung in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							int dlngAppWasAvailable = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
							int dlngProxyType = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 1]);
							InternIncreaseIndex(ref rlngIdx, 2);
							dobjAcadClass3 = mobjAcadClasses.FriendGetItemByOriginalClassName(dstrOriginalClassName);
							if (dobjAcadClass3 != null && dobjAcadClass3.ProxyFlags == dlngProxyFlags)
							{
								nrstrErrMsg = "Klasse " + dstrOriginalClassName + " ab Zeile " + Conversions.ToString(dlngStartIdx) + " existiert bereits.";
								dblnError = true;
							}
							if (!dblnError)
							{
								dobjAcadClass3 = mobjAcadClasses.FriendAdd(dstrOriginalClassName);
								AcadClass acadClass = dobjAcadClass3;
								acadClass.FriendLetAppWasAvailable = (dlngAppWasAvailable == 0);
								acadClass.FriendLetApplicationDescription = dstrApplicationDescription;
								acadClass.FriendLetOriginalDXFName = dstrOriginalDXFName;
								acadClass.FriendLetOriginalClassName = dstrOriginalClassName;
								acadClass.FriendLetProxyFlags = dlngProxyFlags;
								acadClass.FriendLetInstanceCount = dlngInstanceCount;
								acadClass.FriendLetProxyType = unchecked((hwpDxf_Enums.PROXY_TYPE)dlngProxyType);
								acadClass = null;
							}
						}
					}
				}
				bool InternReadClass = !dblnError;
				dobjAcadClass3 = null;
				return InternReadClass;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			int friendGetClassIndex = mobjAcadClasses.FriendGetClassIndex;
			AcadClass dobjAcadClass;
			for (int dlngIdx = 0; dlngIdx <= friendGetClassIndex; dlngIdx = checked(dlngIdx + 1))
			{
				dobjAcadClass = mobjAcadClasses.FriendGetItem(dlngIdx);
				if (dobjAcadClass == null)
				{
					continue;
				}
				bool dblnWrite = true;
				if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
				{
					string originalClassName = dobjAcadClass.OriginalClassName;
					if (Operators.CompareString(originalClassName, "AcDbLayout", TextCompare: false) != 0)
					{
						if (Operators.CompareString(originalClassName, "AcDbPlaceholder", TextCompare: false) == 0)
						{
							dblnWrite = false;
						}
					}
					else
					{
						dblnWrite = false;
					}
				}
				if (dblnWrite)
				{
					AcadClass acadClass = dobjAcadClass;
					InternAddToDictLine(ref rlngIdx, 0, acadClass.DXFName);
					InternAddToDictLine(ref rlngIdx, 1, acadClass.OriginalDXFName);
					InternAddToDictLine(ref rlngIdx, 2, acadClass.OriginalClassName);
					InternAddToDictLine(ref rlngIdx, 3, acadClass.ApplicationDescription);
					InternAddToDictLine(ref rlngIdx, 90, acadClass.ProxyFlags);
					if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
					{
						InternAddToDictLine(ref rlngIdx, 91, acadClass.InstanceCount);
					}
					InternAddToDictLine(ref rlngIdx, 280, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadClass.AppWasAvailable, 0, 1)));
					InternAddToDictLine(ref rlngIdx, 281, acadClass.ProxyType);
					acadClass = null;
				}
			}
			dobjAcadClass = null;
		}
	}
}
