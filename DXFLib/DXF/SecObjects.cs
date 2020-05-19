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
    public class SecObjects
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecObjects";

		private bool mblnOpened;

		private string mstrAcadVer;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadDictionaries mobjAcadDictionaries;

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

		public SecObjects()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecObjects()
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
				mobjAcadDictionaries = null;
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
			mobjAcadDictionaries = mobjAcadDatabase.Dictionaries;
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "OBJECTS");
			if (mobjAcadDictionaries != null)
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

		private bool InternReadSection(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			bool dblnError;
			if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[dlngIdx], 0, TextCompare: false))
			{
				nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(checked(dlngIdx * 2 + 1)) + ".";
				dblnError = true;
			}
			else
			{
				InternIncreaseIndex(ref dlngIdx, 1);
				if (!hwpDxf_ReadObj.BkDXFReadObj_AcadNamedObjectDictionary(mobjAcadDatabase, ref dlngIdx, ref mobjAcadDatabase, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else
				{
					InternCheckIndex(dlngIdx);
					mobjAcadDictionaries = mobjAcadDatabase.Dictionaries;
					dblnError = !InternReadDictionaries(ref dlngIdx, ref nrstrErrMsg);
				}
			}
			return !dblnError;
		}

		private bool InternReadDictionaries(ref int rlngIdx, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			bool dblnRead = default(bool);
			AcadDictionary dobjAcadDictionary;
			AcadGroups dobjAcadGroups;
			AcadMLineStyles dobjAcadMLineStyles;
			AcadLayouts dobjAcadLayouts;
			AcadDictionaryWithDefault dobjAcadPlotStyleNames;
			while (rlngIdx <= mlngSecEnd && !dblnError)
			{
				int dlngCode = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]);
				if (dlngCode != 0)
				{
					nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(checked(rlngIdx * 2 + 1)) + ".";
					dblnError = true;
					continue;
				}
				InternIncreaseIndex(ref rlngIdx, 1);
				object left = dvarValue;
				if (Operators.ConditionalCompareObjectEqual(left, "DICTIONARY", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadDictionary(mobjAcadDatabase, mobjAcadDictionaries.ObjectID, ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, vblnWithDefault: false, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ACDBDICTIONARYWDFLT", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadDictionary(mobjAcadDatabase, mobjAcadDictionaries.ObjectID, ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, vblnWithDefault: true, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ACDBPLACEHOLDER", TextCompare: false))
				{
					dobjAcadPlotStyleNames = mobjAcadDictionaries.PlotStyleNames;
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadPlaceholder(mobjAcadDatabase, dobjAcadPlotStyleNames.ObjectID, ref rlngIdx, dobjAcadPlotStyleNames, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "LAYOUT", TextCompare: false))
				{
					dobjAcadLayouts = mobjAcadDictionaries.Layouts;
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadLayout(mobjAcadDatabase, dobjAcadLayouts.ObjectID, ref rlngIdx, ref dobjAcadLayouts, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "MLINESTYLE", TextCompare: false))
				{
					dobjAcadMLineStyles = mobjAcadDictionaries.MlineStyles;
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadMLineStyle(mobjAcadDatabase, dobjAcadMLineStyles.ObjectID, ref rlngIdx, ref dobjAcadMLineStyles, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "GROUP", TextCompare: false))
				{
					dobjAcadGroups = mobjAcadDictionaries.Groups;
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadGroup(mobjAcadDatabase, dobjAcadGroups.ObjectID, ref rlngIdx, ref dobjAcadGroups, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "DICTIONARYVAR", TextCompare: false))
				{
					dobjAcadDictionary = (AcadDictionary)mobjAcadDictionaries.FriendGetItem("AcDbVariableDictionary");
					if (dobjAcadDictionary == null)
					{
						dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadDictionaryEntry(mlngSecEnd, Conversions.ToString(dvarValue), mobjAcadDatabase, ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
						InternCheckIndex(rlngIdx);
					}
					else
					{
						dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadDictionaryVar(mobjAcadDatabase, dobjAcadDictionary.ObjectID, ref rlngIdx, dobjAcadDictionary, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
						InternCheckIndex(rlngIdx);
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "OBJECT_PTR", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadObjectPointer(mlngSecEnd, Conversions.ToString(dvarValue), mobjAcadDatabase, ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (!dblnRead)
				{
					dblnError = !hwpDxf_ReadObj.BkDXFReadObj_AcadDictionaryEntry(mlngSecEnd, Conversions.ToString(dvarValue), mobjAcadDatabase, ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
			}
			bool InternReadDictionaries = !dblnError;
			dobjAcadDictionary = null;
			dobjAcadGroups = null;
			dobjAcadMLineStyles = null;
			dobjAcadLayouts = null;
			dobjAcadPlotStyleNames = null;
			return InternReadDictionaries;
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			InternListDictionary(mobjAcadDictionaries, ref rlngIdx);
			IEnumerator enumerator = default(IEnumerator);
			AcadDictionary dobjAcadDictionary3;
			try
			{
				enumerator = mobjAcadDictionaries.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadDictionary3 = (AcadDictionary)enumerator.Current;
					InternListDictionary(dobjAcadDictionary3, ref rlngIdx);
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
				enumerator2 = mobjAcadDictionaries.GetValues().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					dobjAcadDictionary3 = (AcadDictionary)enumerator2.Current;
					InternListEntries(dobjAcadDictionary3, ref rlngIdx);
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			dobjAcadDictionary3 = null;
		}

		private void InternListDictionary(AcadDictionary vobjAcadDictionary, ref int rlngIdx)
		{
			AcadDictionary acadDictionary = vobjAcadDictionary;
			InternAddToDictLine(ref rlngIdx, 0, acadDictionary.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadDictionary.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadDictionary.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadDictionary.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadDictionary.SuperiorObjectName);
			double ddblGrpSoftHardOwnerID;
			if (0 - (acadDictionary.TreatElementsAsHard ? 1 : 0) != 0)
			{
				InternAddToDictLine(ref rlngIdx, 280, acadDictionary.TreatElementsAsHard);
				ddblGrpSoftHardOwnerID = 360.0;
			}
			else
			{
				ddblGrpSoftHardOwnerID = 350.0;
			}
			InternAddToDictLine(ref rlngIdx, 281, acadDictionary.MergeStyle);
			acadDictionary = null;
			checked
			{
				AcadPlotConfiguration dobjAcadPlotConfiguration2;
				AcadPlotConfigurations dobjAcadPlotConfigurations2;
				AcadMLineStyle dobjAcadMLineStyle2;
				AcadMLineStyles dobjAcadMLineStyles2;
				AcadGroup dobjAcadGroup2;
				AcadGroups dobjAcadGroups2;
				AcadLayout dobjAcadLayout2;
				AcadLayouts dobjAcadLayouts2;
				AcadPlaceholder dobjAcadPlaceholder2;
				AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2;
				AcadDictionaryVar dobjAcadDictionaryVar2;
				AcadDictionary dobjAcadDictionary2;
				AcadDictionaries dobjAcadDictionaries2;
				switch (vobjAcadDictionary.ObjectName)
				{
					case "AcDbDictionaries":
						{
							dobjAcadDictionaries2 = (AcadDictionaries)vobjAcadDictionary;
							IEnumerator enumerator = default(IEnumerator);
							try
							{
								enumerator = dobjAcadDictionaries2.GetValues().GetEnumerator();
								while (enumerator.MoveNext())
								{
									dobjAcadDictionary2 = (AcadDictionary)enumerator.Current;
									AcadDictionary acadDictionary2 = dobjAcadDictionary2;
									InternAddToDictLine(ref rlngIdx, 3, dobjAcadDictionaries2.FriendGetKeywordByObjectID(acadDictionary2.ObjectID));
									InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadDictionary2.ObjectID);
									acadDictionary2 = null;
								}
							}
							finally
							{
								if (enumerator is IDisposable)
								{
									(enumerator as IDisposable).Dispose();
								}
							}
							break;
						}
					case "AcDbGroups":
						{
							dobjAcadGroups2 = (AcadGroups)vobjAcadDictionary;
							IEnumerator enumerator7 = default(IEnumerator);
							try
							{
								enumerator7 = dobjAcadGroups2.GetValues().GetEnumerator();
								while (enumerator7.MoveNext())
								{
									dobjAcadGroup2 = (AcadGroup)enumerator7.Current;
									AcadGroup acadGroup = dobjAcadGroup2;
									InternAddToDictLine(ref rlngIdx, 3, dobjAcadGroups2.FriendGetKeywordByObjectID(acadGroup.ObjectID));
									InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadGroup.ObjectID);
									acadGroup = null;
								}
							}
							finally
							{
								if (enumerator7 is IDisposable)
								{
									(enumerator7 as IDisposable).Dispose();
								}
							}
							break;
						}
					case "AcDbMlineStyles":
						{
							dobjAcadMLineStyles2 = (AcadMLineStyles)vobjAcadDictionary;
							IEnumerator enumerator6 = default(IEnumerator);
							try
							{
								enumerator6 = dobjAcadMLineStyles2.GetValues().GetEnumerator();
								while (enumerator6.MoveNext())
								{
									dobjAcadMLineStyle2 = (AcadMLineStyle)enumerator6.Current;
									AcadMLineStyle acadMLineStyle = dobjAcadMLineStyle2;
									InternAddToDictLine(ref rlngIdx, 3, dobjAcadMLineStyles2.FriendGetKeywordByObjectID(acadMLineStyle.ObjectID));
									InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadMLineStyle.ObjectID);
									acadMLineStyle = null;
								}
							}
							finally
							{
								if (enumerator6 is IDisposable)
								{
									(enumerator6 as IDisposable).Dispose();
								}
							}
							break;
						}
					case "AcDbPlotSettingsTable":
						{
							dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)vobjAcadDictionary;
							IEnumerator enumerator4 = default(IEnumerator);
							try
							{
								enumerator4 = dobjAcadPlotConfigurations2.GetValues().GetEnumerator();
								while (enumerator4.MoveNext())
								{
									dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)enumerator4.Current;
									AcadPlotConfiguration acadPlotConfiguration = dobjAcadPlotConfiguration2;
									InternAddToDictLine(ref rlngIdx, 3, dobjAcadPlotConfigurations2.FriendGetKeywordByObjectID(acadPlotConfiguration.ObjectID));
									InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadPlotConfiguration.ObjectID);
									acadPlotConfiguration = null;
								}
							}
							finally
							{
								if (enumerator4 is IDisposable)
								{
									(enumerator4 as IDisposable).Dispose();
								}
							}
							break;
						}
					case "AcDbLayouts":
						{
							dobjAcadLayouts2 = (AcadLayouts)vobjAcadDictionary;
							IEnumerator enumerator3 = default(IEnumerator);
							try
							{
								enumerator3 = dobjAcadLayouts2.GetValues().GetEnumerator();
								while (enumerator3.MoveNext())
								{
									dobjAcadLayout2 = (AcadLayout)enumerator3.Current;
									AcadLayout acadLayout = dobjAcadLayout2;
									InternAddToDictLine(ref rlngIdx, 3, dobjAcadLayouts2.FriendGetKeywordByObjectID(acadLayout.ObjectID));
									InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadLayout.ObjectID);
									acadLayout = null;
								}
							}
							finally
							{
								if (enumerator3 is IDisposable)
								{
									(enumerator3 as IDisposable).Dispose();
								}
							}
							break;
						}
					case "AcDbDictionaryWithDefault":
						{
							dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)vobjAcadDictionary;
							string name2 = dobjAcadDictionaryWithDefault2.Name;
							if (Operators.CompareString(name2, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
							{
								IEnumerator enumerator5 = default(IEnumerator);
								try
								{
									enumerator5 = dobjAcadDictionaryWithDefault2.GetValues().GetEnumerator();
									while (enumerator5.MoveNext())
									{
										dobjAcadPlaceholder2 = (AcadPlaceholder)enumerator5.Current;
										AcadPlaceholder acadPlaceholder = dobjAcadPlaceholder2;
										InternAddToDictLine(ref rlngIdx, 3, dobjAcadDictionaryWithDefault2.FriendGetKeywordByObjectID(acadPlaceholder.ObjectID));
										InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadPlaceholder.ObjectID);
										acadPlaceholder = null;
									}
								}
								finally
								{
									if (enumerator5 is IDisposable)
									{
										(enumerator5 as IDisposable).Dispose();
									}
								}
								AcadDictionaryWithDefault acadDictionaryWithDefault = dobjAcadDictionaryWithDefault2;
								InternAddToDictLine(ref rlngIdx, 100, acadDictionaryWithDefault.ObjectName);
								InternAddToDictLine(ref rlngIdx, 340, acadDictionaryWithDefault.DefaultID);
								acadDictionaryWithDefault = null;
							}
							else
							{
								hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - B Dictionary Unbekannt: " + dobjAcadDictionaryWithDefault2.Name);
							}
							break;
						}
					case "AcDbDictionary":
						{
							dobjAcadDictionary2 = vobjAcadDictionary;
							string name = dobjAcadDictionary2.Name;
							if (Operators.CompareString(name, "AcDbVariableDictionary", TextCompare: false) == 0)
							{
								IEnumerator enumerator2 = default(IEnumerator);
								try
								{
									enumerator2 = dobjAcadDictionary2.GetValues().GetEnumerator();
									while (enumerator2.MoveNext())
									{
										dobjAcadDictionaryVar2 = (AcadDictionaryVar)enumerator2.Current;
										AcadDictionaryVar acadDictionaryVar = dobjAcadDictionaryVar2;
										InternAddToDictLine(ref rlngIdx, 3, dobjAcadDictionary2.FriendGetKeywordByObjectID(acadDictionaryVar.ObjectID));
										InternAddToDictLine(ref rlngIdx, (int)Math.Round(ddblGrpSoftHardOwnerID), acadDictionaryVar.ObjectID);
										acadDictionaryVar = null;
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
							else
							{
								hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - B Dictionary Unbekannt: " + dobjAcadDictionary2.Name);
							}
							break;
						}
					default:
						{
							bool dblnList = default(bool);
							if (!dblnList)
							{
								hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - A Dictionary Unbekannt: " + vobjAcadDictionary.ObjectName);
							}
							break;
						}
				}
				AcadDictionary acadDictionary3 = vobjAcadDictionary;
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadDictionary3.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadDictionary3 = null;
				dobjAcadPlotConfiguration2 = null;
				dobjAcadPlotConfigurations2 = null;
				dobjAcadMLineStyle2 = null;
				dobjAcadMLineStyles2 = null;
				dobjAcadGroup2 = null;
				dobjAcadGroups2 = null;
				dobjAcadLayout2 = null;
				dobjAcadLayouts2 = null;
				dobjAcadPlaceholder2 = null;
				dobjAcadDictionaryWithDefault2 = null;
				dobjAcadDictionaryVar2 = null;
				dobjAcadDictionary2 = null;
				dobjAcadDictionaries2 = null;
			}
		}

		private void InternListEntries(AcadDictionary vobjAcadDictionary, ref int rlngIdx)
		{
			AcadDictionaryVar dobjAcadDictionaryVar2;
			AcadDictionary dobjAcadDictionary2;
			AcadPlaceholder dobjAcadPlaceholder2;
			AcadDictionaryWithDefault dobjAcadDictionaryWithDefault2;
			AcadLayout dobjAcadLayout2;
			AcadLayouts dobjAcadLayouts2;
			AcadPlotConfiguration dobjAcadPlotConfiguration2;
			AcadPlotConfigurations dobjAcadPlotConfigurations2;
			AcadMLineStyle dobjAcadMLineStyle2;
			AcadMLineStyles dobjAcadMLineStyles2;
			AcadGroup dobjAcadGroup2;
			AcadGroups dobjAcadGroups2;
			switch (vobjAcadDictionary.ObjectName)
			{
				case "AcDbGroups":
					{
						dobjAcadGroups2 = (AcadGroups)vobjAcadDictionary;
						IEnumerator enumerator = default(IEnumerator);
						try
						{
							enumerator = dobjAcadGroups2.GetValues().GetEnumerator();
							while (enumerator.MoveNext())
							{
								dobjAcadGroup2 = (AcadGroup)enumerator.Current;
								InternListGroup(dobjAcadGroup2, ref rlngIdx);
							}
						}
						finally
						{
							if (enumerator is IDisposable)
							{
								(enumerator as IDisposable).Dispose();
							}
						}
						break;
					}
				case "AcDbMlineStyles":
					{
						dobjAcadMLineStyles2 = (AcadMLineStyles)vobjAcadDictionary;
						IEnumerator enumerator6 = default(IEnumerator);
						try
						{
							enumerator6 = dobjAcadMLineStyles2.GetValues().GetEnumerator();
							while (enumerator6.MoveNext())
							{
								dobjAcadMLineStyle2 = (AcadMLineStyle)enumerator6.Current;
								InternListMLineStyle(dobjAcadMLineStyle2, ref rlngIdx);
							}
						}
						finally
						{
							if (enumerator6 is IDisposable)
							{
								(enumerator6 as IDisposable).Dispose();
							}
						}
						break;
					}
				case "AcDbPlotSettingsTable":
					{
						dobjAcadPlotConfigurations2 = (AcadPlotConfigurations)vobjAcadDictionary;
						IEnumerator enumerator4 = default(IEnumerator);
						try
						{
							enumerator4 = dobjAcadPlotConfigurations2.GetValues().GetEnumerator();
							while (enumerator4.MoveNext())
							{
								dobjAcadPlotConfiguration2 = (AcadPlotConfiguration)enumerator4.Current;
								InternListPlotConfiguration(dobjAcadPlotConfiguration2, ref rlngIdx);
							}
						}
						finally
						{
							if (enumerator4 is IDisposable)
							{
								(enumerator4 as IDisposable).Dispose();
							}
						}
						break;
					}
				case "AcDbLayouts":
					{
						dobjAcadLayouts2 = (AcadLayouts)vobjAcadDictionary;
						IEnumerator enumerator3 = default(IEnumerator);
						try
						{
							enumerator3 = dobjAcadLayouts2.GetValues().GetEnumerator();
							while (enumerator3.MoveNext())
							{
								dobjAcadLayout2 = (AcadLayout)enumerator3.Current;
								InternListLayout(dobjAcadLayout2, ref rlngIdx);
							}
						}
						finally
						{
							if (enumerator3 is IDisposable)
							{
								(enumerator3 as IDisposable).Dispose();
							}
						}
						break;
					}
				case "AcDbDictionaryWithDefault":
					{
						dobjAcadDictionaryWithDefault2 = (AcadDictionaryWithDefault)vobjAcadDictionary;
						string name2 = dobjAcadDictionaryWithDefault2.Name;
						if (Operators.CompareString(name2, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
						{
							IEnumerator enumerator5 = default(IEnumerator);
							try
							{
								enumerator5 = dobjAcadDictionaryWithDefault2.GetValues().GetEnumerator();
								while (enumerator5.MoveNext())
								{
									dobjAcadPlaceholder2 = (AcadPlaceholder)enumerator5.Current;
									InternListPlaceholder(dobjAcadPlaceholder2, ref rlngIdx);
								}
							}
							finally
							{
								if (enumerator5 is IDisposable)
								{
									(enumerator5 as IDisposable).Dispose();
								}
							}
						}
						else
						{
							hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - B Eintrag Unbekannt: " + dobjAcadDictionaryWithDefault2.Name);
						}
						break;
					}
				case "AcDbDictionary":
					{
						dobjAcadDictionary2 = vobjAcadDictionary;
						string name = dobjAcadDictionary2.Name;
						if (Operators.CompareString(name, "AcDbVariableDictionary", TextCompare: false) == 0)
						{
							IEnumerator enumerator2 = default(IEnumerator);
							try
							{
								enumerator2 = dobjAcadDictionary2.GetValues().GetEnumerator();
								while (enumerator2.MoveNext())
								{
									dobjAcadDictionaryVar2 = (AcadDictionaryVar)enumerator2.Current;
									InternListDictionaryVar(dobjAcadDictionaryVar2, ref rlngIdx);
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
						else
						{
							hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - B Eintrag Unbekannt: " + dobjAcadDictionary2.Name);
						}
						break;
					}
				default:
					{
						bool dblnList = default(bool);
						if (!dblnList)
						{
							hwpDxf_Functions.BkDXF_DebugPrint("List Objekt - A Eintrag Unbekannt: " + vobjAcadDictionary.ObjectName);
						}
						break;
					}
			}
			dobjAcadDictionaryVar2 = null;
			dobjAcadDictionary2 = null;
			dobjAcadPlaceholder2 = null;
			dobjAcadDictionaryWithDefault2 = null;
			dobjAcadLayout2 = null;
			dobjAcadLayouts2 = null;
			dobjAcadPlotConfiguration2 = null;
			dobjAcadPlotConfigurations2 = null;
			dobjAcadMLineStyle2 = null;
			dobjAcadMLineStyles2 = null;
			dobjAcadGroup2 = null;
			dobjAcadGroups2 = null;
		}

		private void InternListGroup(AcadGroup vobjAcadGroup, ref int rlngIdx)
		{
			AcadGroup acadGroup = vobjAcadGroup;
			InternAddToDictLine(ref rlngIdx, 0, acadGroup.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadGroup.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadGroup.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadGroup.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadGroup.ObjectName);
			InternAddToDictLine(ref rlngIdx, 300, acadGroup.Description);
			InternAddToDictLine(ref rlngIdx, 70, acadGroup.Flags70);
			InternAddToDictLine(ref rlngIdx, 71, acadGroup.Flags71);
			IEnumerator enumerator = default(IEnumerator);
			AcadEntity dobjAcadEntity2;
			try
			{
				enumerator = vobjAcadGroup.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadEntity2 = (AcadEntity)enumerator.Current;
					InternAddToDictLine(ref rlngIdx, 340, dobjAcadEntity2.ObjectID);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadGroup.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadGroup = null;
			dobjAcadEntity2 = null;
		}

		private void InternListMaterial(AcadMaterial vobjAcadMaterial, ref int rlngIdx)
		{
		}

		private void InternListMLineStyle(AcadMLineStyle vobjAcadMLineStyle, ref int rlngIdx)
		{
			AcadMLineStyle acadMLineStyle = vobjAcadMLineStyle;
			InternAddToDictLine(ref rlngIdx, 0, acadMLineStyle.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadMLineStyle.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadMLineStyle.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadMLineStyle.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadMLineStyle.ObjectName);
			InternAddToDictLine(ref rlngIdx, 2, acadMLineStyle.Name);
			InternAddToDictLine(ref rlngIdx, 70, acadMLineStyle.Flags70);
			InternAddToDictLine(ref rlngIdx, 3, acadMLineStyle.Description);
			InternAddToDictLine(ref rlngIdx, 62, acadMLineStyle.Color);
			InternAddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadMLineStyle.StartAngleDegree));
			InternAddToDictLine(ref rlngIdx, 52, RuntimeHelpers.GetObjectValue(acadMLineStyle.EndAngleDegree));
			AcadMLineStyleElements dobjAcadMLineStyleElements2 = vobjAcadMLineStyle.Elements;
			InternAddToDictLine(ref rlngIdx, 71, dobjAcadMLineStyleElements2.Count);
			IEnumerator enumerator = default(IEnumerator);
			AcadMLineStyleElement dobjAcadMLineStyleElement2;
			try
			{
				enumerator = dobjAcadMLineStyleElements2.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadMLineStyleElement2 = (AcadMLineStyleElement)enumerator.Current;
					InternAddToDictLine(ref rlngIdx, 49, RuntimeHelpers.GetObjectValue(dobjAcadMLineStyleElement2.Offset));
					InternAddToDictLine(ref rlngIdx, 62, dobjAcadMLineStyleElement2.Color);
					InternAddToDictLine(ref rlngIdx, 6, Strings.UCase(dobjAcadMLineStyleElement2.Linetype));
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadMLineStyle.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadMLineStyle = null;
			dobjAcadMLineStyleElement2 = null;
			dobjAcadMLineStyleElements2 = null;
		}

		private void InternListPlotConfiguration(AcadPlotConfiguration vobjAcadPlotConfiguration, ref int rlngIdx)
		{
			hwpDxf_Functions.BkDXF_DebugPrint("ListPlotConfiguration");
		}

		private void InternListLayout(AcadLayout vobjAcadLayout, ref int rlngIdx)
		{
			AcadLayout acadLayout = vobjAcadLayout;
			InternAddToDictLine(ref rlngIdx, 0, acadLayout.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadLayout.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadLayout.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadLayout.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadLayout.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadLayout.SuperiorObjectName);
			InternAddToDictLine(ref rlngIdx, 1, acadLayout.PlotSettingsName);
			InternAddToDictLine(ref rlngIdx, 2, acadLayout.ConfigName);
			InternAddToDictLine(ref rlngIdx, 4, acadLayout.CanonicalMediaName);
			InternAddToDictLine(ref rlngIdx, 6, acadLayout.ViewToPlot);
			object dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.PaperMarginLowerLeft);
			InternAddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.PaperMarginUpperRight);
			InternAddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadLayout.PaperWidth));
			InternAddToDictLine(ref rlngIdx, 45, RuntimeHelpers.GetObjectValue(acadLayout.PaperHeight));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.PlotOrigin);
			InternAddToDictLine(ref rlngIdx, 46, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 47, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.WindowToPlotLowerLeft);
			InternAddToDictLine(ref rlngIdx, 48, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 49, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.WindowToPlotUpperRight);
			InternAddToDictLine(ref rlngIdx, 140, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 141, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 142, RuntimeHelpers.GetObjectValue(acadLayout.CustomScaleNumerator));
			InternAddToDictLine(ref rlngIdx, 143, RuntimeHelpers.GetObjectValue(acadLayout.CustomScaleDenominator));
			InternAddToDictLine(ref rlngIdx, 70, acadLayout.PlotSettingsFlags70);
			InternAddToDictLine(ref rlngIdx, 72, acadLayout.PaperUnits);
			InternAddToDictLine(ref rlngIdx, 73, acadLayout.PlotRotation);
			InternAddToDictLine(ref rlngIdx, 74, acadLayout.PlotType);
			InternAddToDictLine(ref rlngIdx, 7, acadLayout.StyleSheet);
			InternAddToDictLine(ref rlngIdx, 75, acadLayout.StandardScale);
			InternAddToDictLine(ref rlngIdx, 147, RuntimeHelpers.GetObjectValue(acadLayout.ScaleFactor));
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
			{
				InternAddToDictLine(ref rlngIdx, 76, acadLayout.ShadePlotMode);
				InternAddToDictLine(ref rlngIdx, 77, acadLayout.ShadePlotResolutionLevel);
				InternAddToDictLine(ref rlngIdx, 78, acadLayout.ShadePlotCustomDPI);
			}
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.PaperImageOrigin);
			InternAddToDictLine(ref rlngIdx, 148, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 149, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 100, acadLayout.ObjectName);
			InternAddToDictLine(ref rlngIdx, 1, acadLayout.Name);
			InternAddToDictLine(ref rlngIdx, 70, acadLayout.Flags70);
			InternAddToDictLine(ref rlngIdx, 71, acadLayout.TabOrder);
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.LimMin);
			InternAddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.LimMax);
			InternAddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.InsBase);
			InternAddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 32, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.ExtMin);
			InternAddToDictLine(ref rlngIdx, 14, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 24, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 34, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.ExtMax);
			InternAddToDictLine(ref rlngIdx, 15, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 25, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 35, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			InternAddToDictLine(ref rlngIdx, 146, RuntimeHelpers.GetObjectValue(acadLayout.Elevation));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.UCSOrigin);
			InternAddToDictLine(ref rlngIdx, 13, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 23, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 33, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.UCSXVector);
			InternAddToDictLine(ref rlngIdx, 16, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 26, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 36, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			dvarPoint14 = RuntimeHelpers.GetObjectValue(acadLayout.UCSYVector);
			InternAddToDictLine(ref rlngIdx, 17, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 27, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 37, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint14, new object[1]
			{
			2
			}, null)));
			InternAddToDictLine(ref rlngIdx, 76, acadLayout.UCSOrthographic);
			InternAddToDictLine(ref rlngIdx, 330, acadLayout.PaperSpaceObjectID);
			if (acadLayout.ViewportObjectID != -1.0)
			{
				InternAddToDictLine(ref rlngIdx, 331, acadLayout.ViewportObjectID);
			}
			if (acadLayout.NamedUCSObjectID != -1.0)
			{
				InternAddToDictLine(ref rlngIdx, 345, acadLayout.NamedUCSObjectID);
			}
			if (acadLayout.ReferencedUCSObjectID != -1.0)
			{
				InternAddToDictLine(ref rlngIdx, 346, acadLayout.ReferencedUCSObjectID);
			}
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadLayout.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadLayout = null;
		}

		private void InternListPlaceholder(AcadPlaceholder vobjAcadPlaceholder, ref int rlngIdx)
		{
			AcadPlaceholder acadPlaceholder = vobjAcadPlaceholder;
			InternAddToDictLine(ref rlngIdx, 0, acadPlaceholder.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadPlaceholder.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadPlaceholder.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadPlaceholder.OwnerID);
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadPlaceholder.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadPlaceholder = null;
		}

		private void InternListDictionaryVar(AcadDictionaryVar vobjAcadDictionaryVar, ref int rlngIdx)
		{
			AcadDictionaryVar acadDictionaryVar = vobjAcadDictionaryVar;
			InternAddToDictLine(ref rlngIdx, 0, acadDictionaryVar.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadDictionaryVar.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadDictionaryVar.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadDictionaryVar.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadDictionaryVar.ObjectName);
			InternAddToDictLine(ref rlngIdx, 280, acadDictionaryVar.ObjectSchemaNumber);
			InternAddToDictLine(ref rlngIdx, 1, acadDictionaryVar.FriendGetValueString);
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadDictionaryVar.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadDictionaryVar = null;
		}
	}
}
