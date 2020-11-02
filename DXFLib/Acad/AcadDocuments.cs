using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
	public class AcadDocuments : NodeObject
	{
		public delegate void ReadStartEventHandler(int Entries);

		public delegate void ReadEntryEventHandler(int Entry);

		public delegate void ReadEndEventHandler();

		private const string cstrClassName = "AcadDocuments";

		private const string cstrDocName = "Zeichng";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngNewNameIndex;

		private int mlngActiveDocumentIndex;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictIndex;

		private Dictionary<object, object> mobjDictName;

		private Dictionary<object, object> mobjDictFullName;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjDXFFile")]
		private DXFLib.DXF.File _mobjDXFFile;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadStartEventHandler ReadStartEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEntryEventHandler ReadEntryEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEndEventHandler ReadEndEvent;

		[field: AccessedThroughProperty("mobjDXFFile")]
		private DXFLib.DXF.File mobjDXFFile
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal AcadDocument FriendGetActiveDocument
		{
			get
			{
				if (mlngActiveDocumentIndex > -1)
				{
					return (AcadDocument)mcolClass["K" + Conversions.ToString(mlngActiveDocumentIndex)];
				}
				AcadDocument FriendGetActiveDocument = default(AcadDocument);
				return FriendGetActiveDocument;
			}
		}

		internal int FriendGetActiveDocumentIndex => mlngActiveDocumentIndex;

		internal int FriendLetActiveDocumentIndex
		{
			set
			{
				AcadDocument dobjAcadDocument2 = (AcadDocument)mcolClass["K" + Conversions.ToString(value)];
				InternActivateDocument(ref dobjAcadDocument2);
				dobjAcadDocument2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadDocument dobjDocument2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjDocument2 = (AcadDocument)enumerator.Current;
						dobjDocument2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjDocument2 = null;
			}
		}

		public AcadApplication Application
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public int Count => mcolClass.Count;

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

		private void mobjDXFFile_ReadStart(int Entries)
		{
			ReadStartEvent?.Invoke(Entries);
		}

		private void mobjDXFFile_ReadEntry(int Entry)
		{
			ReadEntryEvent?.Invoke(Entry);
		}

		private void mobjDXFFile_ReadEnd()
		{
			ReadEndEvent?.Invoke();
		}

		public AcadDocuments()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 105;
			base.FriendLetNodeImageDisabledID = 106;
			base.FriendLetNodeName = "Dokumente";
			base.FriendLetNodeText = "Dokumente";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngActiveDocumentIndex = -1;
			mlngNewNameIndex = 1;
			mcolClass = new OrderedDictionary();
			mobjDictIndex = new Dictionary<object, object>();
			mobjDictName = new Dictionary<object, object>();
			mobjDictFullName = new Dictionary<object, object>();
		}

		internal void FriendInit(string vstrAcadVer, int vlngNodeParentID, int vlngApplicationIndex)
		{
			base.FriendLetNodeParentID = vlngNodeParentID;
			mlngApplicationIndex = vlngApplicationIndex;
			if (!hwpDxf_Vars.pblnInitDocument)
			{
				InternAddDoc(vstrAcadVer, vblnRaiseEvent: false);
			}
		}

		~AcadDocuments()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				if (mobjDXFFile != null)
				{
					mobjDXFFile.FriendQuit();
				}
				InternClear();
				base.FriendQuit();
				mobjDictFullName.Clear();
				mobjDictName.Clear();
				mobjDictIndex.Clear();
				mobjDictFullName = null;
				mobjDictName = null;
				mobjDictIndex = null;
				mobjDXFFile = null;
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadDocuments");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadDocument dobjAcadDocument2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadDocument2 = (AcadDocument)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadDocument2.FriendGetDocumentIndex));
					dobjAcadDocument2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngDocumentIndex = -1;
			dobjAcadDocument2 = null;
		}

		public ICollection<AcadDocument> GetValues()
		{
			return (ICollection<AcadDocument>)mcolClass.Values;
		}

		internal void FriendSetNewDoc(ref AcadDocument robjAcadDocument)
		{
			InternRegDoc(ref robjAcadDocument);
			InternSetDoc(ref robjAcadDocument);
		}

		internal void FriendSDINewDoc(int vlngIndex)
		{
			Application.RaiseEventNewDrawing();
			AcadDocument dobjAcadDocument2 = (AcadDocument)mcolClass["K" + Conversions.ToString(vlngIndex)];
			dobjAcadDocument2.FriendReset("AC1018");
			dobjAcadDocument2.FriendSetFullName(InternGetNewName(), vblnDwgTitled: false);
			InternAddToAllDicts(ref dobjAcadDocument2);
			dobjAcadDocument2 = null;
		}

		internal bool FriendSDIOpenDoc(int vlngIndex, string vstrFileName, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			string dstrAcadVer = default(string);
			bool FriendSDIOpenDoc = default(bool);
			if (!InternCheckName(vstrFileName, ref nrstrErrMsg) && Operators.ConditionalCompareObjectNotEqual(vlngIndex, mobjDictFullName[vstrFileName], TextCompare: false))
			{
				AcadDocument dobjAcadDocument4 = null;
			}
			else if (hwpDxf_Functions.BkDXF_OpenFile(vstrFileName, ref dstrAcadVer, ref nrstrErrMsg))
			{
				AcadDocument dobjAcadDocument4 = (AcadDocument)mcolClass["K" + Conversions.ToString(vlngIndex)];
				hwpDxf_Vars.pblnReadDocument = true;
				dobjAcadDocument4.FriendReset(dstrAcadVer);
				bool dblnRead = InternReadFile(vstrFileName, ref dobjAcadDocument4, ref nrstrErrMsg);
				hwpDxf_Vars.pblnReadDocument = false;
				if (!dblnRead)
				{
					dobjAcadDocument4.FriendReset("AC1018");
					dobjAcadDocument4.FriendSetFullName(InternGetNewName(), vblnDwgTitled: false);
					InternAddToAllDicts(ref dobjAcadDocument4);
					dobjAcadDocument4 = null;
				}
				else
				{
					bool flag = true;
					dobjAcadDocument4.Database.FriendAddAndInitObjects();
					dobjAcadDocument4.FriendSetFullName(vstrFileName, vblnDwgTitled: true);
					InternAddToAllDicts(ref dobjAcadDocument4);
					FriendSDIOpenDoc = true;
					dobjAcadDocument4 = null;
				}
			}
			return FriendSDIOpenDoc;
		}

		internal bool FriendOpenDoc(string vstrFileName, ref AcadDocument robjAcadDocument, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			robjAcadDocument = null;
			string dstrAcadVer = default(string);
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 1, TextCompare: false))
			{
				nrstrErrMsg = "Diese Methode ist im SDI-Modus nicht erlaubt.";
			}
			else if (InternCheckName(vstrFileName, ref nrstrErrMsg) && hwpDxf_Functions.BkDXF_OpenFile(vstrFileName, ref dstrAcadVer, ref nrstrErrMsg))
			{
				hwpDxf_Vars.pblnReadDocument = true;
				robjAcadDocument = InternAddDoc(dstrAcadVer, vblnRaiseEvent: false, vstrFileName);
				bool dblnRead = InternReadFile(vstrFileName, ref robjAcadDocument, ref nrstrErrMsg);
				hwpDxf_Vars.pblnReadDocument = false;
				if (dblnRead)
				{
					bool flag = true;
					robjAcadDocument.Database.FriendAddAndInitObjects();
					return true;
				}
				FriendRemoveDoc(ref robjAcadDocument);
				robjAcadDocument = null;
			}
			bool FriendOpenDoc = default(bool);
			return FriendOpenDoc;
		}

		internal bool FriendAddDoc(string vstrAcadVer, ref AcadDocument robjAcadDocument, object nvvarReservedHandles = null, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			robjAcadDocument = null;
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 1, TextCompare: false))
			{
				nrstrErrMsg = "Diese Methode ist im SDI-Modus nicht erlaubt.";
				bool FriendAddDoc = default(bool);
				return FriendAddDoc;
			}
			robjAcadDocument = InternAddDoc(vstrAcadVer, vblnRaiseEvent: true, null, RuntimeHelpers.GetObjectValue(nvvarReservedHandles));
			return true;
		}

		internal bool FriendCloseAll(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			bool FriendCloseAll = default(bool);
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 1, TextCompare: false))
			{
				AcadDocument dobjAcadDocument3 = null;
				nrstrErrMsg = "Diese Methode ist im SDI-Modus nicht erlaubt.";
			}
			else
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadDocument dobjAcadDocument3;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadDocument3 = (AcadDocument)enumerator.Current;
						InternRemoveDoc(ref dobjAcadDocument3, nvblnActivateNext: false);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				AcadDocument robjAcadDocument = null;
				InternActivateDocument(ref robjAcadDocument);
				FriendCloseAll = true;
				dobjAcadDocument3 = null;
			}
			return FriendCloseAll;
		}

		internal void FriendRemoveDoc(ref AcadDocument robjAcadDocument)
		{
			InternRemoveDoc(ref robjAcadDocument);
		}

		internal AcadDocument FriendGetItem(object vvarIndex)
		{
			int dlngIndex = default(int);
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) == VariantType.String)
			{
				InternFindName(Conversions.ToString(vvarIndex), ref dlngIndex);
			}
			else
			{
				dlngIndex = Conversions.ToInteger(vvarIndex);
			}
			AcadDocument FriendGetItem = default(AcadDocument);
			try
			{
				FriendGetItem = (AcadDocument)mcolClass["K" + Conversions.ToString(dlngIndex)];
				return FriendGetItem;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
				return FriendGetItem;
			}
		}

		internal void FriendActivateDocument(ref AcadDocument robjAcadDocument)
		{
			InternActivateDocument(ref robjAcadDocument);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadDocument AddDoc(object nvvarReservedHandles = null)
		{
			string dstrErrMsg = default(string);
			AcadDocument AddDoc = default(AcadDocument);
			AcadDocument dobjAcadDocument3 = default(AcadDocument);
			if (!FriendAddDoc(Application.AcadVer, ref dobjAcadDocument3, RuntimeHelpers.GetObjectValue(nvvarReservedHandles), ref dstrErrMsg))
			{
				dobjAcadDocument3 = null;
				Information.Err().Raise(50000, "AcadDocuments", dstrErrMsg);
			}
			else
			{
				AddDoc = dobjAcadDocument3;
				dobjAcadDocument3 = null;
			}
			return AddDoc;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadDocument OpenDoc(string vstrFileName)
		{
			string dstrErrMsg = default(string);
			AcadDocument OpenDoc = default(AcadDocument);
			AcadDocument dobjAcadDocument3 = default(AcadDocument);
			if (!FriendOpenDoc(vstrFileName, ref dobjAcadDocument3, ref dstrErrMsg))
			{
				FriendRemoveDoc(ref dobjAcadDocument3);
				dobjAcadDocument3 = null;
				Information.Err().Raise(50000, "AcadDocuments", dstrErrMsg);
			}
			else
			{
				OpenDoc = dobjAcadDocument3;
				dobjAcadDocument3 = null;
			}
			return OpenDoc;
		}

		public AcadDocument Item(object vvarIndex)
		{
			int dlngIndex = default(int);
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) == VariantType.String)
			{
				InternFindName(Conversions.ToString(vvarIndex), ref dlngIndex);
			}
			else
			{
				dlngIndex = Conversions.ToInteger(vvarIndex);
			}
			return (AcadDocument)mcolClass["K" + Conversions.ToString(dlngIndex)];
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void CloseAll()
		{
			string dstrErrMsg = default(string);
			if (!FriendCloseAll(ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadDocuments", dstrErrMsg);
			}
		}

		private AcadDocument InternAddDoc(string vstrAcadVer, bool vblnRaiseEvent, string nvstrFileName = null, object nvvarReservedHandles = null)
		{
			if (vblnRaiseEvent)
			{
				Application.RaiseEventNewDrawing();
			}
			hwpDxf_Vars.pblnAddDocument = true;
			AcadDocument dobjAcadDocument2 = new AcadDocument();
			hwpDxf_Vars.pblnAddDocument = false;
			InternRegDoc(ref dobjAcadDocument2);
			dobjAcadDocument2.FriendInit(vstrAcadVer, base.NodeID, mlngApplicationIndex, RuntimeHelpers.GetObjectValue(nvvarReservedHandles));
			InternSetDoc(ref dobjAcadDocument2, nvstrFileName);
			AcadDocument InternAddDoc = dobjAcadDocument2;
			dobjAcadDocument2 = null;
			return InternAddDoc;
		}

		private void InternRegDoc(ref AcadDocument robjAcadDocument)
		{
			checked
			{
				mlngDocumentIndex++;
				robjAcadDocument.FriendLetDocumentIndex = mlngDocumentIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngDocumentIndex), robjAcadDocument);
				InternAddToAllDicts(ref robjAcadDocument, nvblnNew: true);
			}
		}

		private void InternSetDoc(ref AcadDocument robjAcadDocument, string nvstrFileName = null)
		{
			bool dblnTitled;
			if (Operators.CompareString(nvstrFileName, null, TextCompare: false) == 0)
			{
				nvstrFileName = InternGetNewName();
				dblnTitled = false;
			}
			else
			{
				string dstrFullName = nvstrFileName;
				dblnTitled = true;
			}
			robjAcadDocument.FriendSetFullName(nvstrFileName, dblnTitled);
		}

		private bool InternCheckName(string vstrFullFileName, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			if (mobjDictFullName.ContainsKey(vstrFullFileName))
			{
				nrstrErrMsg = "Die Datei ist bereits geöffnet.";
				bool InternCheckName = default(bool);
				return InternCheckName;
			}
			return true;
		}

		private string InternGetNewName()
		{
			checked
			{
				while (mobjDictName.ContainsKey(Strings.UCase(InternGetIndexName(mlngNewNameIndex))))
				{
					mlngNewNameIndex++;
				}
				return InternGetIndexName(mlngNewNameIndex);
			}
		}

		private string InternGetIndexName(int vlngIdx)
		{
			return "Zeichng" + Conversions.ToString(vlngIdx) + ".dxf";
		}

		private void InternRemoveFromAllDicts(int vlngIndex)
		{
			InternRemoveFromDict(vlngIndex, ref mobjDictFullName);
			InternRemoveFromDict(vlngIndex, ref mobjDictName);
			mobjDictIndex.Remove(vlngIndex);
		}

		private void InternRemoveFromDict(int vlngIndex, ref Dictionary<object, object> robjDict)
		{
			object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(robjDict.Keys));
			object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(robjDict.Values));
			int dlngIdx = Information.LBound((Array)dvarItems);
			bool dblnFound = false;
			while (dlngIdx <= Information.UBound((Array)dvarItems) && !dblnFound)
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(dvarItems, new object[1]
				{
				dlngIdx
				}, null), vlngIndex, TextCompare: false))
				{
					dblnFound = true;
				}
				else
				{
					dlngIdx = checked(dlngIdx + 1);
				}
			}
			if (dblnFound)
			{
				robjDict.Remove(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
				{
				dlngIdx
				}, null)));
			}
		}

		private void InternAddToAllDicts(ref AcadDocument robjAcadDocument, bool nvblnNew = false)
		{
			AcadDocument acadDocument = robjAcadDocument;
			int dlngIndex = acadDocument.FriendGetDocumentIndex;
			if (!nvblnNew)
			{
				InternRemoveFromAllDicts(dlngIndex);
			}
			if (Operators.CompareString(acadDocument.FullName, null, TextCompare: false) != 0)
			{
				mobjDictFullName.Add(acadDocument.FullName, dlngIndex);
			}
			string dstrName = Strings.UCase(acadDocument.Name);
			mobjDictIndex.Add(acadDocument.FriendGetDocumentIndex, dstrName);
			if (!mobjDictName.ContainsKey(dstrName))
			{
				mobjDictName.Add(dstrName, dlngIndex);
			}
			acadDocument = null;
			InternActivateDocument(ref robjAcadDocument);
		}

		private void InternRemoveDoc(ref AcadDocument robjAcadDocument, bool nvblnActivateNext = true)
		{
			if (robjAcadDocument != null)
			{
				int dlngIndex = robjAcadDocument.FriendGetDocumentIndex;
				robjAcadDocument.FriendQuit();
				InternRemoveFromAllDicts(dlngIndex);
				InternDeactivateDocument(dlngIndex, nvblnActivateNext);
				try
				{
					mcolClass.Remove("K" + Conversions.ToString(dlngIndex));
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
			}
		}

		private void InternDeactivateDocument(int vlngIndex, bool nvblnActivateNext = true)
		{
			AcadDocument dobjAcadDocument3 = default(AcadDocument);
			if (vlngIndex == mlngActiveDocumentIndex && vlngIndex != -1)
			{
				try
				{
					dobjAcadDocument3 = (AcadDocument)mcolClass["K" + Conversions.ToString(vlngIndex)];
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
				checked
				{
					if (dobjAcadDocument3 != null)
					{
						dobjAcadDocument3.FriendSetActiveState(vblnActive: false);
						if (nvblnActivateNext)
						{
							dobjAcadDocument3 = null;
							if (mcolClass.Count > 0)
							{
								dobjAcadDocument3 = (AcadDocument)mcolClass[mcolClass.Count - 1];
								if (!dobjAcadDocument3.FriendGetIsOpen)
								{
									dobjAcadDocument3 = null;
									if (mcolClass.Count > 1)
									{
										dobjAcadDocument3 = (AcadDocument)mcolClass[mcolClass.Count - 2];
									}
								}
							}
							InternActivateDocument(ref dobjAcadDocument3);
						}
					}
				}
			}
			dobjAcadDocument3 = null;
		}

		private void InternActivateDocument(ref AcadDocument robjAcadDocument)
		{
			if (robjAcadDocument != null)
			{
				InternDeactivateDocument(mlngActiveDocumentIndex, nvblnActivateNext: false);
				mlngActiveDocumentIndex = robjAcadDocument.FriendGetDocumentIndex;
				robjAcadDocument.FriendSetActiveState(vblnActive: true);
				Application.RaiseEventActiveDocumentChanged();
			}
			else
			{
				mlngActiveDocumentIndex = -1;
				Application.RaiseEventActiveDocumentChanged();
			}
		}

		private bool InternReadFile(string vstrFileName, ref AcadDocument robjAcadDocument, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			mobjDXFFile = new DXFLib.DXF.File();
			mobjDXFFile.Init(ref robjAcadDocument);
			bool InternReadFile = default(bool);
			if (!mobjDXFFile.ReadFile(vstrFileName, ref nrstrErrMsg))
			{
				mobjDXFFile = null;
			}
			else
			{
				InternReadFile = true;
				mobjDXFFile = null;
			}
			return InternReadFile;
		}

		private bool InternFindName(string vstrName, ref int rlngDocumentIndex)
		{
			vstrName = Strings.UCase(vstrName);
			object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictIndex.Values));
			rlngDocumentIndex = -1;
			for (int dlngCount = Information.LBound((Array)dvarItems); (dlngCount <= Information.UBound((Array)dvarItems)) & (rlngDocumentIndex == -1); dlngCount = checked(dlngCount + 1))
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(dvarItems, new object[1]
				{
				dlngCount
				}, null), vstrName, TextCompare: false))
				{
					object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(mobjDictIndex.Keys));
					rlngDocumentIndex = Conversions.ToInteger(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
					{
					dlngCount
					}, null));
				}
			}
			return rlngDocumentIndex != -1;
		}
	}
}
