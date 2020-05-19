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
    public class SecHeader
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecHeader";

		private bool mblnOpened;

		private string mstrAcadVer;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDocument mobjAcadDocument;

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

		public SecHeader()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecHeader()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjAcadDocument = null;
				mblnOpened = false;
			}
		}

		public void Init(ref AcadDocument robjAcadDocument, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		{
			mstrAcadVer = robjAcadDocument.AcadVer;
			mobjAcadDocument = robjAcadDocument;
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
			mlngLastEntry = -1;
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "HEADER");
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
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			AcadSummaryInfo dobjAcadSummaryInfo = mobjAcadDocument.SummaryInfo;
			bool dblnError = default(bool);
			bool dblnTitle = default(bool);
			bool dblnSubject = default(bool);
			bool dblnAuthor = default(bool);
			bool dblnKeywords = default(bool);
			bool dblnComments = default(bool);
			bool dblnLastSavedBy = default(bool);
			bool dblnRevisionNumber = default(bool);
			AcadSysVar dobjAcadSysVar;
			AcadSummaryInfoField dobjAcadSummaryInfoField = default(AcadSummaryInfoField);
			while (dlngIdx <= mlngSecEnd && !dblnError)
			{
				string dstrVarName1 = Conversions.ToString(mobjDictReadValues[dlngIdx]);
				string dstrVarName2 = Strings.Mid(dstrVarName1, 2);
				int dlngCode1 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
				checked
				{
					if (dlngCode1 != 9)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Variable in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						dblnError = true;
						continue;
					}
					if (!LikeOperator.LikeString(dstrVarName1, "$*", CompareMethod.Binary))
					{
						nrstrErrMsg = "Ungültiger Variablenprefix in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
						dblnError = true;
						continue;
					}
					object dvarValue5;
					if (dobjAcadSummaryInfoField != null)
					{
						int dlngCode5 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx + 1]);
						if (Operators.CompareString(Strings.UCase(dstrVarName2), Strings.UCase("CUSTOMPROPERTY"), TextCompare: false) != 0)
						{
							nrstrErrMsg = "Datei-Info: Ungültiger Bezeichner für den Wert einer benutzerdefinierten Eigenschaft in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (dlngCode5 != 1)
						{
							nrstrErrMsg = "Datei-Info: Ungültiger Gruppencode für den Wert einer benutzerdefinierten Eigenschaft in Zeile " + Conversions.ToString(dlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							dvarValue5 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx + 1]);
							dobjAcadSummaryInfoField.Value = Conversions.ToString(dvarValue5);
							InternIncreaseIndex(ref dlngIdx, 2);
						}
						dobjAcadSummaryInfoField = null;
						continue;
					}
					if (InternCheckIsSummaryInfo(dstrVarName2))
					{
						int dlngCode5 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx + 1]);
						if (dlngCode5 != 1)
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Datei-Info in Zeile " + Conversions.ToString(dlngIdx * 2 + 3) + ".";
							dblnError = true;
							continue;
						}
						dvarValue5 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx + 1]);
						string left = Strings.UCase(dstrVarName2);
						if (Operators.CompareString(left, Strings.UCase("TITLE"), TextCompare: false) == 0)
						{
							if (dblnTitle)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnTitle = true;
								dobjAcadSummaryInfo.Title = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("SUBJECT"), TextCompare: false) == 0)
						{
							if (dblnSubject)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnSubject = true;
								dobjAcadSummaryInfo.Subject = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("AUTHOR"), TextCompare: false) == 0)
						{
							if (dblnAuthor)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnAuthor = true;
								dobjAcadSummaryInfo.Author = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("KEYWORDS"), TextCompare: false) == 0)
						{
							if (dblnKeywords)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnKeywords = true;
								dobjAcadSummaryInfo.Keywords = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("COMMENTS"), TextCompare: false) == 0)
						{
							if (dblnComments)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnComments = true;
								dobjAcadSummaryInfo.Comments = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("LASTSAVEDBY"), TextCompare: false) == 0)
						{
							if (dblnLastSavedBy)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnLastSavedBy = true;
								dobjAcadSummaryInfo.FriendLetLastSavedBy = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("REVISIONNUMBER"), TextCompare: false) == 0)
						{
							if (dblnRevisionNumber)
							{
								nrstrErrMsg = "Doppelter Datei-Info-Eintrag in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
							else
							{
								dblnRevisionNumber = true;
								dobjAcadSummaryInfo.FriendLetRevisionNumber = Conversions.ToString(dvarValue5);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("CUSTOMPROPERTYTAG"), TextCompare: false) == 0)
						{
							dvarValue5 = Strings.Trim(Conversions.ToString(dvarValue5));
							if (Operators.ConditionalCompareObjectEqual(dvarValue5, null, TextCompare: false))
							{
								nrstrErrMsg = "Datei-Info: Ungültiger Name einer benutzerdefinierten Eigenschaft in Zeile " + Conversions.ToString(dlngIdx * 2 + 4) + ".";
								dblnError = true;
							}
							else if (dobjAcadSummaryInfo.CustomExistsByKey(Conversions.ToString(dvarValue5)) != 0)
							{
								nrstrErrMsg = "Datei-Info: Der Name einer benutzerdefinierten Eigenschaft ist bereits vergeben, in Zeile " + Conversions.ToString(dlngIdx * 2 + 4) + ".";
								dblnError = true;
							}
							else
							{
								dobjAcadSummaryInfoField = dobjAcadSummaryInfo.Fields.Add(Conversions.ToString(dvarValue5), null);
								InternIncreaseIndex(ref dlngIdx, 2);
							}
						}
						else if (Operators.CompareString(left, Strings.UCase("CUSTOMPROPERTY"), TextCompare: false) == 0)
						{
							nrstrErrMsg = "Datei-Info: Wert einer benutzerdefinierten Eigenschaft ohne Namen in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						continue;
					}
					dobjAcadSysVar = mobjAcadDocument.FriendFindVariable(dstrVarName2);
					if (dobjAcadSysVar == null)
					{
						nrstrErrMsg = "Ungültiger Variablenname '" + dstrVarName2 + "' in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
						hwpDxf_Functions.BkDXF_DebugPrint(nrstrErrMsg);
						dblnError = true;
						continue;
					}
					object dvarHeaderCode = RuntimeHelpers.GetObjectValue(dobjAcadSysVar.HeaderCode);
					if (dobjAcadSysVar.ArraySize == null)
					{
						int dlngCode5 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx + 1]);
						if (Operators.ConditionalCompareObjectNotEqual(dlngCode5, dvarHeaderCode, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Variablenwert in Zeile " + Conversions.ToString(dlngIdx * 2 + 3) + ".";
							dblnError = true;
							continue;
						}
						dvarValue5 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx + 1]);
						switch (dobjAcadSysVar.Name)
						{
							case "CECOLOR":
								dvarValue5 = hwpDxf_Functions.BkDXF_ColorLongToString(unchecked((Enums.AcColor)Conversions.ToInteger(dvarValue5)));
								break;
							case "DIMDSEP":
								dvarValue5 = Strings.Chr(Conversions.ToInteger(dvarValue5));
								break;
							case "FINGERPRINTGUID":
								dvarValue5 = Strings.Trim(Conversions.ToString(dvarValue5));
								if (Operators.ConditionalCompareObjectEqual(dvarValue5, null, TextCompare: false))
								{
									dvarValue5 = Guid.NewGuid().ToString().ToUpper();
								}
								break;
							case "VERSIONGUID":
								dvarValue5 = Strings.Trim(Conversions.ToString(dvarValue5));
								if (Operators.ConditionalCompareObjectEqual(dvarValue5, null, TextCompare: false))
								{
									dvarValue5 = Guid.NewGuid().ToString().ToUpper();
								}
								break;
						}
						if (!dobjAcadSysVar.FriendSetValue(RuntimeHelpers.GetObjectValue(dvarValue5), vblnRaiseEvent: true, ref nrstrErrMsg))
						{
							nrstrErrMsg = nrstrErrMsg + " Ab Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else
						{
							InternIncreaseIndex(ref dlngIdx, 2);
						}
						continue;
					}
					int dlngLBound = Information.LBound((Array)dvarHeaderCode);
					int dlngArraySize = Conversions.ToInteger(dobjAcadSysVar.ArraySize);
					VariantType varType_Renamed = dobjAcadSysVar.VarType_Renamed;
					dvarValue5 = ((varType_Renamed != (VariantType)8201) ? new object[dlngArraySize - 1 + 1] : new object[dlngArraySize - 1 + 1]);
					int dlngCount = 0;
					while (unchecked(dlngCount < dlngArraySize && !dblnError))
					{
						int dlngCode5 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx + dlngCount + 1]);
						if (Operators.ConditionalCompareObjectNotEqual(dlngCode5, NewLateBinding.LateIndexGet(dvarHeaderCode, new object[1]
						{
						dlngLBound
						}, null), TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Variablenwert in Zeile " + Conversions.ToString((dlngIdx + dlngCount + 1) * 2 + 1) + ".";
							dblnError = true;
						}
						else
						{
							NewLateBinding.LateIndexSet(dvarValue5, new object[2]
							{
							dlngCount,
							mobjDictReadValues[dlngIdx + dlngCount + 1]
							}, null);
							dlngLBound++;
							dlngCount++;
						}
					}
					if (!dblnError)
					{
						if (!dobjAcadSysVar.FriendSetValue(RuntimeHelpers.GetObjectValue(dvarValue5), vblnRaiseEvent: true, ref nrstrErrMsg))
						{
							nrstrErrMsg = nrstrErrMsg + " Ab Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else
						{
							InternIncreaseIndex(ref dlngIdx, dlngArraySize + 1);
						}
					}
				}
			}
			bool InternReadSection = !dblnError;
			dobjAcadSysVar = null;
			dobjAcadSummaryInfoField = null;
			dobjAcadSummaryInfo = null;
			return InternReadSection;
		}

		private bool InternCheckIsSummaryInfo(string vstrVarName)
		{
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
			{
				string left = Strings.UCase(vstrVarName);
				if (Operators.CompareString(left, Strings.UCase("TITLE"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("SUBJECT"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("AUTHOR"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("KEYWORDS"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("COMMENTS"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("LASTSAVEDBY"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("REVISIONNUMBER"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("CUSTOMPROPERTYTAG"), TextCompare: false) == 0)
				{
					return true;
				}
				if (Operators.CompareString(left, Strings.UCase("CUSTOMPROPERTY"), TextCompare: false) == 0)
				{
					return true;
				}
			}
			bool dblnValid = default(bool);
			return dblnValid;
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			SysVars dobjSysVars2 = new SysVars();
			Dictionary<object, object> dobjDictPos2 = new Dictionary<object, object>();
			IEnumerator enumerator = default(IEnumerator);
			int dlngMaxPos = default(int);
			try
			{
				enumerator = dobjSysVars2.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					SysVar dobjSysVar2 = (SysVar)enumerator.Current;
					SysVar sysVar = dobjSysVar2;
					if (dobjSysVar2.HeaderPos != null)
					{
						int dlngPos = Conversions.ToInteger(sysVar.HeaderPos);
						if (dlngMaxPos < dlngPos)
						{
							dlngMaxPos = dlngPos;
						}
						dobjDictPos2.Add(dlngPos, sysVar.Name);
					}
					sysVar = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			int num = dlngMaxPos;
			checked
			{
				string dstrName = default(string);
				bool dblnSummaryInfo = default(bool);
				IEnumerator enumerator2 = default(IEnumerator);
				AcadSummaryInfoField dobjAcadSummaryInfoField;
				AcadSummaryInfo dobjAcadSummaryInfo;
				AcadSysVar dobjAcadSysVar;
				for (int dlngIndex = 1; dlngIndex <= num; dlngIndex++)
				{
					bool dblnValid = false;
					try
					{
						dstrName = Conversions.ToString(dobjDictPos2[dlngIndex]);
						dblnValid = true;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						ProjectData.ClearProjectError();
					}
					if (!dblnValid || Operators.CompareString(dstrName, null, TextCompare: false) == 0)
					{
						continue;
					}
					dobjAcadSysVar = mobjAcadDocument.FriendFindVariable(dstrName);
					if (dobjAcadSysVar != null)
					{
						AcadSysVar acadSysVar = dobjAcadSysVar;
						object dvarValue2 = RuntimeHelpers.GetObjectValue(acadSysVar.Value);
						object dvarArraySize = RuntimeHelpers.GetObjectValue(acadSysVar.ArraySize);
						object dvarHeaderCode = RuntimeHelpers.GetObjectValue(acadSysVar.HeaderCode);
						acadSysVar = null;
						if (dvarValue2 != null)
						{
							if (Operators.CompareString(dstrName, "DIMDSEP", TextCompare: false) != 0)
							{
								if (Operators.CompareString(dstrName, "CECOLOR", TextCompare: false) == 0)
								{
									dvarValue2 = hwpDxf_Functions.BkDXF_ColorStringToLong(Conversions.ToString(dvarValue2));
								}
							}
							else
							{
								Type typeFromHandle = typeof(Strings);
								object[] obj = new object[1]
								{
								dvarValue2
								};
								object[] array = obj;
								bool[] obj2 = new bool[1]
								{
								true
								};
								bool[] array2 = obj2;
								object obj3 = NewLateBinding.LateGet(null, typeFromHandle, "Asc", obj, null, null, obj2);
								if (array2[0])
								{
									dvarValue2 = RuntimeHelpers.GetObjectValue(array[0]);
								}
								dvarValue2 = RuntimeHelpers.GetObjectValue(obj3);
							}
							InternAddToDictLine(ref rlngIdx, 9, "$" + dstrName);
							if (dvarArraySize != null)
							{
								int num2 = Conversions.ToInteger(Operators.SubtractObject(dvarArraySize, 1));
								for (int dlngArrayIdx = 0; dlngArrayIdx <= num2; dlngArrayIdx++)
								{
									InternAddToDictLine(ref rlngIdx, Conversions.ToInteger(NewLateBinding.LateIndexGet(dvarHeaderCode, new object[1]
									{
									dlngArrayIdx
									}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarValue2, new object[1]
									{
									dlngArrayIdx
									}, null)));
								}
							}
							else
							{
								InternAddToDictLine(ref rlngIdx, Conversions.ToInteger(dvarHeaderCode), RuntimeHelpers.GetObjectValue(dvarValue2));
							}
						}
						else
						{
							hwpDxf_Functions.BkDXF_DebugPrint("Header Systemvariablen Wert ist Null: " + dstrName);
						}
					}
					if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && !dblnSummaryInfo && Operators.CompareString(Strings.UCase(dstrName), Strings.UCase("DWGCODEPAGE"), TextCompare: false) == 0)
					{
						dblnSummaryInfo = true;
						dobjAcadSummaryInfo = mobjAcadDocument.SummaryInfo;
						AcadSummaryInfo acadSummaryInfo = dobjAcadSummaryInfo;
						if (Operators.CompareString(acadSummaryInfo.Title, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$TITLE");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.Title);
						}
						if (Operators.CompareString(acadSummaryInfo.Subject, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$SUBJECT");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.Subject);
						}
						if (Operators.CompareString(acadSummaryInfo.Author, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$AUTHOR");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.Author);
						}
						if (Operators.CompareString(acadSummaryInfo.Keywords, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$KEYWORDS");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.Keywords);
						}
						if (Operators.CompareString(acadSummaryInfo.Comments, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$COMMENTS");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.Comments);
						}
						if (Operators.CompareString(acadSummaryInfo.LastSavedBy, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$LASTSAVEDBY");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.LastSavedBy);
						}
						if (Operators.CompareString(acadSummaryInfo.RevisionNumber, null, TextCompare: false) != 0)
						{
							InternAddToDictLine(ref rlngIdx, 9, "$REVISIONNUMBER");
							InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfo.RevisionNumber);
						}
						acadSummaryInfo = null;
						try
						{
							enumerator2 = dobjAcadSummaryInfo.Fields.GetValues().GetEnumerator();
							while (enumerator2.MoveNext())
							{
								dobjAcadSummaryInfoField = (AcadSummaryInfoField)enumerator2.Current;
								AcadSummaryInfoField acadSummaryInfoField = dobjAcadSummaryInfoField;
								InternAddToDictLine(ref rlngIdx, 9, "$CUSTOMPROPERTYTAG");
								InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfoField.Key);
								InternAddToDictLine(ref rlngIdx, 9, "$CUSTOMPROPERTY");
								InternAddToDictLine(ref rlngIdx, 1, acadSummaryInfoField.Value);
								acadSummaryInfoField = null;
							}
						}
						finally
						{
							if (enumerator2 is IDisposable)
							{
								(enumerator2 as IDisposable).Dispose();
							}
						}
					}
				}
				dobjAcadSummaryInfoField = null;
				dobjAcadSummaryInfo = null;
				dobjAcadSysVar = null;
				dobjDictPos2 = null;
				SysVar dobjSysVar2 = null;
				dobjSysVars2 = null;
			}
		}
	}
}
