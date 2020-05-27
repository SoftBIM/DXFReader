using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	class AcadApplication : NodeObject
	{
		public delegate void ActiveDocumentChangedEventHandler();

		public delegate void BeginOpenEventHandler(string vstrFileName);

		public delegate void BeginQuitEventHandler(ref bool rblnCancel);

		public delegate void BeginSaveEventHandler(string vstrFileName);

		public delegate void EndOpenEventHandler(string vstrFileName);

		public delegate void EndSaveEventHandler(string vstrFileName);

		public delegate void NewDrawingEventHandler();

		public delegate void SysVarChangedEventHandler(string vstrSysvarName, object vvarNewValue);

		private const string cstrClassName = "AcadApplication";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private string mstrAppPath;

		private string mstrAppVersion;

		private int mlngShowMode;

		private bool mblnToolbarVisible;

		private string mstrAcadVer;

		private AcadSysVars mobjAcadSysVars;

		private AcadDocuments mobjAcadDocuments;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ActiveDocumentChangedEventHandler ActiveDocumentChangedEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BeginOpenEventHandler BeginOpenEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BeginQuitEventHandler BeginQuitEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BeginSaveEventHandler BeginSaveEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EndOpenEventHandler EndOpenEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EndSaveEventHandler EndSaveEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private NewDrawingEventHandler NewDrawingEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SysVarChangedEventHandler SysVarChangedEvent;

		public AcadDocument ActiveDocument
		{
			get
			{
				InternCheckOpened("ActiveDocument");
				return mobjAcadDocuments.FriendGetActiveDocument;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				InternCheckOpened("ActiveDocument");
				if (value.FriendGetApplicationIndex != mlngApplicationIndex)
				{
					Information.Err().Raise(50000, "AcadApplication", "Die Zeichnung referenziert eine andere Applikation.");
				}
				else
				{
					mobjAcadDocuments.FriendLetActiveDocumentIndex = value.FriendGetDocumentIndex;
				}
			}
		}

		public AcadDocuments Documents
		{
			get
			{
				InternCheckOpened("Documents");
				return mobjAcadDocuments;
			}
		}

		public AcadApplication Application
		{
			get
			{
				InternCheckOpened("Application");
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public AcadSysVars Variables
		{
			get
			{
				InternCheckOpened("Variables");
				return mobjAcadSysVars;
			}
		}

		internal int FriendGetActiveDocumentIndex
		{
			get
			{
				InternCheckOpened("FriendGetActiveDocumentIndex");
				return mobjAcadDocuments.FriendGetActiveDocumentIndex;
			}
		}

		internal int FriendLetActiveDocumentIndex
		{
			set
			{
				InternCheckOpened("FriendLetActiveDocumentIndex");
				mobjAcadDocuments.FriendLetActiveDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex
		{
			get
			{
				InternCheckOpened("FriendGetApplicationIndex");
				return mlngApplicationIndex;
			}
		}

		public string AcadVer
		{
			get
			{
				InternCheckOpened("AcadVer");
				return mstrAcadVer;
			}
		}

		public string Path
		{
			get
			{
				InternCheckOpened("Path");
				return mstrAppPath;
			}
		}

		public string Version
		{
			get
			{
				InternCheckOpened("Version");
				return mstrAppVersion;
			}
		}

		public int ShowMode
		{
			get
			{
				InternCheckOpened("ShowMode");
				return mlngShowMode;
			}
			set
			{
				InternCheckOpened("ShowMode");
				mlngShowMode = value;
			}
		}

		public bool ToolbarVisible
		{
			get
			{
				InternCheckOpened("ToolbarVisible");
				return mblnToolbarVisible;
			}
			set
			{
				InternCheckOpened("ToolbarVisible");
				mblnToolbarVisible = value;
			}
		}

		public bool Opened => mblnOpened;

		public event ActiveDocumentChangedEventHandler ActiveDocumentChanged
		{
			[CompilerGenerated]
			add
			{
				ActiveDocumentChangedEventHandler activeDocumentChangedEventHandler = ActiveDocumentChangedEvent;
				ActiveDocumentChangedEventHandler activeDocumentChangedEventHandler2;
				do
				{
					activeDocumentChangedEventHandler2 = activeDocumentChangedEventHandler;
					ActiveDocumentChangedEventHandler value2 = (ActiveDocumentChangedEventHandler)Delegate.Combine(activeDocumentChangedEventHandler2, value);
					activeDocumentChangedEventHandler = Interlocked.CompareExchange(ref ActiveDocumentChangedEvent, value2, activeDocumentChangedEventHandler2);
				}
				while ((object)activeDocumentChangedEventHandler != activeDocumentChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ActiveDocumentChangedEventHandler activeDocumentChangedEventHandler = ActiveDocumentChangedEvent;
				ActiveDocumentChangedEventHandler activeDocumentChangedEventHandler2;
				do
				{
					activeDocumentChangedEventHandler2 = activeDocumentChangedEventHandler;
					ActiveDocumentChangedEventHandler value2 = (ActiveDocumentChangedEventHandler)Delegate.Remove(activeDocumentChangedEventHandler2, value);
					activeDocumentChangedEventHandler = Interlocked.CompareExchange(ref ActiveDocumentChangedEvent, value2, activeDocumentChangedEventHandler2);
				}
				while ((object)activeDocumentChangedEventHandler != activeDocumentChangedEventHandler2);
			}
		}

		public event BeginOpenEventHandler BeginOpen
		{
			[CompilerGenerated]
			add
			{
				BeginOpenEventHandler beginOpenEventHandler = BeginOpenEvent;
				BeginOpenEventHandler beginOpenEventHandler2;
				do
				{
					beginOpenEventHandler2 = beginOpenEventHandler;
					BeginOpenEventHandler value2 = (BeginOpenEventHandler)Delegate.Combine(beginOpenEventHandler2, value);
					beginOpenEventHandler = Interlocked.CompareExchange(ref BeginOpenEvent, value2, beginOpenEventHandler2);
				}
				while ((object)beginOpenEventHandler != beginOpenEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				BeginOpenEventHandler beginOpenEventHandler = BeginOpenEvent;
				BeginOpenEventHandler beginOpenEventHandler2;
				do
				{
					beginOpenEventHandler2 = beginOpenEventHandler;
					BeginOpenEventHandler value2 = (BeginOpenEventHandler)Delegate.Remove(beginOpenEventHandler2, value);
					beginOpenEventHandler = Interlocked.CompareExchange(ref BeginOpenEvent, value2, beginOpenEventHandler2);
				}
				while ((object)beginOpenEventHandler != beginOpenEventHandler2);
			}
		}

		public event BeginQuitEventHandler BeginQuit
		{
			[CompilerGenerated]
			add
			{
				BeginQuitEventHandler beginQuitEventHandler = BeginQuitEvent;
				BeginQuitEventHandler beginQuitEventHandler2;
				do
				{
					beginQuitEventHandler2 = beginQuitEventHandler;
					BeginQuitEventHandler value2 = (BeginQuitEventHandler)Delegate.Combine(beginQuitEventHandler2, value);
					beginQuitEventHandler = Interlocked.CompareExchange(ref BeginQuitEvent, value2, beginQuitEventHandler2);
				}
				while ((object)beginQuitEventHandler != beginQuitEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				BeginQuitEventHandler beginQuitEventHandler = BeginQuitEvent;
				BeginQuitEventHandler beginQuitEventHandler2;
				do
				{
					beginQuitEventHandler2 = beginQuitEventHandler;
					BeginQuitEventHandler value2 = (BeginQuitEventHandler)Delegate.Remove(beginQuitEventHandler2, value);
					beginQuitEventHandler = Interlocked.CompareExchange(ref BeginQuitEvent, value2, beginQuitEventHandler2);
				}
				while ((object)beginQuitEventHandler != beginQuitEventHandler2);
			}
		}

		public event BeginSaveEventHandler BeginSave
		{
			[CompilerGenerated]
			add
			{
				BeginSaveEventHandler beginSaveEventHandler = BeginSaveEvent;
				BeginSaveEventHandler beginSaveEventHandler2;
				do
				{
					beginSaveEventHandler2 = beginSaveEventHandler;
					BeginSaveEventHandler value2 = (BeginSaveEventHandler)Delegate.Combine(beginSaveEventHandler2, value);
					beginSaveEventHandler = Interlocked.CompareExchange(ref BeginSaveEvent, value2, beginSaveEventHandler2);
				}
				while ((object)beginSaveEventHandler != beginSaveEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				BeginSaveEventHandler beginSaveEventHandler = BeginSaveEvent;
				BeginSaveEventHandler beginSaveEventHandler2;
				do
				{
					beginSaveEventHandler2 = beginSaveEventHandler;
					BeginSaveEventHandler value2 = (BeginSaveEventHandler)Delegate.Remove(beginSaveEventHandler2, value);
					beginSaveEventHandler = Interlocked.CompareExchange(ref BeginSaveEvent, value2, beginSaveEventHandler2);
				}
				while ((object)beginSaveEventHandler != beginSaveEventHandler2);
			}
		}

		public event EndOpenEventHandler EndOpen
		{
			[CompilerGenerated]
			add
			{
				EndOpenEventHandler endOpenEventHandler = EndOpenEvent;
				EndOpenEventHandler endOpenEventHandler2;
				do
				{
					endOpenEventHandler2 = endOpenEventHandler;
					EndOpenEventHandler value2 = (EndOpenEventHandler)Delegate.Combine(endOpenEventHandler2, value);
					endOpenEventHandler = Interlocked.CompareExchange(ref EndOpenEvent, value2, endOpenEventHandler2);
				}
				while ((object)endOpenEventHandler != endOpenEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EndOpenEventHandler endOpenEventHandler = EndOpenEvent;
				EndOpenEventHandler endOpenEventHandler2;
				do
				{
					endOpenEventHandler2 = endOpenEventHandler;
					EndOpenEventHandler value2 = (EndOpenEventHandler)Delegate.Remove(endOpenEventHandler2, value);
					endOpenEventHandler = Interlocked.CompareExchange(ref EndOpenEvent, value2, endOpenEventHandler2);
				}
				while ((object)endOpenEventHandler != endOpenEventHandler2);
			}
		}

		public event EndSaveEventHandler EndSave
		{
			[CompilerGenerated]
			add
			{
				EndSaveEventHandler endSaveEventHandler = EndSaveEvent;
				EndSaveEventHandler endSaveEventHandler2;
				do
				{
					endSaveEventHandler2 = endSaveEventHandler;
					EndSaveEventHandler value2 = (EndSaveEventHandler)Delegate.Combine(endSaveEventHandler2, value);
					endSaveEventHandler = Interlocked.CompareExchange(ref EndSaveEvent, value2, endSaveEventHandler2);
				}
				while ((object)endSaveEventHandler != endSaveEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EndSaveEventHandler endSaveEventHandler = EndSaveEvent;
				EndSaveEventHandler endSaveEventHandler2;
				do
				{
					endSaveEventHandler2 = endSaveEventHandler;
					EndSaveEventHandler value2 = (EndSaveEventHandler)Delegate.Remove(endSaveEventHandler2, value);
					endSaveEventHandler = Interlocked.CompareExchange(ref EndSaveEvent, value2, endSaveEventHandler2);
				}
				while ((object)endSaveEventHandler != endSaveEventHandler2);
			}
		}

		public event NewDrawingEventHandler NewDrawing
		{
			[CompilerGenerated]
			add
			{
				NewDrawingEventHandler newDrawingEventHandler = NewDrawingEvent;
				NewDrawingEventHandler newDrawingEventHandler2;
				do
				{
					newDrawingEventHandler2 = newDrawingEventHandler;
					NewDrawingEventHandler value2 = (NewDrawingEventHandler)Delegate.Combine(newDrawingEventHandler2, value);
					newDrawingEventHandler = Interlocked.CompareExchange(ref NewDrawingEvent, value2, newDrawingEventHandler2);
				}
				while ((object)newDrawingEventHandler != newDrawingEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				NewDrawingEventHandler newDrawingEventHandler = NewDrawingEvent;
				NewDrawingEventHandler newDrawingEventHandler2;
				do
				{
					newDrawingEventHandler2 = newDrawingEventHandler;
					NewDrawingEventHandler value2 = (NewDrawingEventHandler)Delegate.Remove(newDrawingEventHandler2, value);
					newDrawingEventHandler = Interlocked.CompareExchange(ref NewDrawingEvent, value2, newDrawingEventHandler2);
				}
				while ((object)newDrawingEventHandler != newDrawingEventHandler2);
			}
		}

		public event SysVarChangedEventHandler SysVarChanged
		{
			[CompilerGenerated]
			add
			{
				SysVarChangedEventHandler sysVarChangedEventHandler = SysVarChangedEvent;
				SysVarChangedEventHandler sysVarChangedEventHandler2;
				do
				{
					sysVarChangedEventHandler2 = sysVarChangedEventHandler;
					SysVarChangedEventHandler value2 = (SysVarChangedEventHandler)Delegate.Combine(sysVarChangedEventHandler2, value);
					sysVarChangedEventHandler = Interlocked.CompareExchange(ref SysVarChangedEvent, value2, sysVarChangedEventHandler2);
				}
				while ((object)sysVarChangedEventHandler != sysVarChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				SysVarChangedEventHandler sysVarChangedEventHandler = SysVarChangedEvent;
				SysVarChangedEventHandler sysVarChangedEventHandler2;
				do
				{
					sysVarChangedEventHandler2 = sysVarChangedEventHandler;
					SysVarChangedEventHandler value2 = (SysVarChangedEventHandler)Delegate.Remove(sysVarChangedEventHandler2, value);
					sysVarChangedEventHandler = Interlocked.CompareExchange(ref SysVarChangedEvent, value2, sysVarChangedEventHandler2);
				}
				while ((object)sysVarChangedEventHandler != sysVarChangedEventHandler2);
			}
		}

		internal void RaiseEventActiveDocumentChanged()
		{
			ActiveDocumentChangedEvent?.Invoke();
		}

		internal void RaiseEventBeginOpen(string vstrFileName)
		{
			BeginOpenEvent?.Invoke(vstrFileName);
		}

		internal void RaiseEventBeginQuit(ref bool rblnCancel)
		{
			BeginQuitEvent?.Invoke(ref rblnCancel);
		}

		internal void RaiseEventBeginSave(string vstrFileName)
		{
			BeginSaveEvent?.Invoke(vstrFileName);
		}

		internal void RaiseEventEndOpen(string vstrFileName)
		{
			EndOpenEvent?.Invoke(vstrFileName);
		}

		internal void RaiseEventEndSave(string vstrFileName)
		{
			EndSaveEvent?.Invoke(vstrFileName);
		}

		internal void RaiseEventNewDrawing()
		{
			NewDrawingEvent?.Invoke();
		}

		internal void RaiseEventSysVarChanged(string vstrSysvarName, object vvarNewValue)
		{
			SysVarChangedEvent?.Invoke(vstrSysvarName, RuntimeHelpers.GetObjectValue(vvarNewValue));
		}

		~AcadApplication()
		{
			FriendQuit(nvblnTerminate: true);
			base.Finalize();
		}

		internal void FriendOpen(string nvstrAcadVer = "AC1018")
		{
			if (mblnOpened)
			{
				return;
			}
			string left = Strings.UCase(nvstrAcadVer);
			if (Operators.CompareString(left, "AC1015", TextCompare: false) != 0)
			{
				if (Operators.CompareString(left, "AC1018", TextCompare: false) == 0)
				{
					mstrAcadVer = "AC1018";
				}
				else
				{
					mstrAcadVer = "AC1018";
				}
			}
			else
			{
				mstrAcadVer = "AC1015";
			}
			string left2 = mstrAcadVer;
			if (Operators.CompareString(left2, "AC1015", TextCompare: false) != 0)
			{
				if (Operators.CompareString(left2, "AC1018", TextCompare: false) == 0)
				{
					hwpDxf_Vars.pvarSupportedAcadVer = new string[2]
					{
					"AC1015",
					"AC1018"
					};
				}
			}
			else
			{
				hwpDxf_Vars.pvarSupportedAcadVer = new string[1]
				{
				"AC1015"
				};
			}
			hwpDxf_Init.BkDXF_InitDefObjValues();
			hwpDxf_Vars.pobjSysVars = new SysVars();
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 103;
			base.FriendLetNodeImageDisabledID = 104;
			base.FriendLetNodeName = "Applikation";
			base.FriendLetNodeText = "Applikation";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			hwpDxf_Vars.pblnAddDocument = false;
			hwpDxf_Vars.pblnAddDatabase = false;
			AcadApplications pobjAcadApplications = hwpDxf_Vars.pobjAcadApplications;
			AcadApplication robjAcadApplication = this;
			mlngApplicationIndex = pobjAcadApplications.Add(ref robjAcadApplication);
			mstrAppPath = hwpDxf_Vars.pstrAppPath;
			mstrAppVersion = hwpDxf_Vars.pstrAppVersion;
			mlngShowMode = 31;
			mblnToolbarVisible = true;
			mobjAcadSysVars = new AcadSysVars();
			mobjAcadSysVars.FriendLetNodeParentID = base.NodeID;
			mobjAcadSysVars.FriendLetApplicationIndex = mlngApplicationIndex;
			mobjAcadSysVars.FriendOpen(hwpDxf_Enums.REF_TYPE.rtApplication);
			InternSetVarsByDefault();
			mobjAcadDocuments = new AcadDocuments();
			mobjAcadDocuments.FriendInit(mstrAcadVer, base.NodeID, mlngApplicationIndex);
		}

		internal void FriendQuit(bool nvblnTerminate = false)
		{
			if (mblnOpened)
			{
				bool dblnCancel = default(bool);
				RaiseEventBeginQuit(ref dblnCancel);
				if (nvblnTerminate || !dblnCancel)
				{
					mobjAcadSysVars.FriendQuit();
					mobjAcadDocuments.FriendQuit();
					hwpDxf_Vars.pobjAcadApplications.Remove(mlngApplicationIndex);
					base.FriendQuit();
					mobjAcadSysVars = null;
					mobjAcadDocuments = null;
					mblnOpened = false;
				}
			}
		}

		internal AcadSysVar FriendFindVariable(string vstrName)
		{
			InternCheckOpened("FriendFindVariable");
			return mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName));
		}

		internal object FriendGetVariable(string vstrName)
		{
			InternCheckOpened("FriendGetVariable");
			return RuntimeHelpers.GetObjectValue(mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName)).Value);
		}

		internal void FriendSetVariable(string vstrName, object vvarValue)
		{
			InternCheckOpened("FriendSetVariable");
			object value = mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName)).Value;
			object[] obj = new object[1]
			{
			vvarValue
			};
			object[] array = obj;
			bool[] obj2 = new bool[1]
			{
			true
			};
			bool[] array2 = obj2;
			NewLateBinding.LateCall(value, null, "FriendSetValueSilent", obj, null, null, obj2, IgnoreReturn: true);
			if (array2[0])
			{
				vvarValue = RuntimeHelpers.GetObjectValue(array[0]);
			}
		}

		public void Start(string nvstrAcadVer = "AC1018")
		{
			FriendOpen(nvstrAcadVer);
		}

		public void Quit()
		{
			InternCheckOpened("Quit");
			FriendQuit();
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object GetVariable(string vstrName)
		{
			InternCheckOpened("GetVariable");
			AcadSysVar dobjAcadSysVar2 = FriendFindVariable(vstrName);
			object GetVariable;
			if (dobjAcadSysVar2 == null)
			{
				GetVariable = null;
				Information.Err().Raise(50000, "AcadApplication", "Die Systemvariable existiert nicht.");
			}
			else
			{
				GetVariable = RuntimeHelpers.GetObjectValue(dobjAcadSysVar2.Value);
				dobjAcadSysVar2 = null;
			}
			return GetVariable;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetVariable(string vstrName, object vvarValue)
		{
			InternCheckOpened("SetVariable");
			AcadSysVar dobjAcadSysVar3 = FriendFindVariable(vstrName);
			string dstrErrMsg = default(string);
			if (dobjAcadSysVar3 == null)
			{
				Information.Err().Raise(50000, "AcadApplication", "Die Systemvariable existiert nicht.");
			}
			else if (!dobjAcadSysVar3.FriendSetValue(RuntimeHelpers.GetObjectValue(vvarValue), vblnRaiseEvent: true, ref dstrErrMsg))
			{
				dobjAcadSysVar3 = null;
				Information.Err().Raise(50000, "AcadApplication", "Die Systemvariable konnte nicht gesetzt werden.\n" + dstrErrMsg);
			}
			else
			{
				dobjAcadSysVar3 = null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void InternCheckOpened(string vstrCommand)
		{
			if (!mblnOpened)
			{
				Information.Err().Raise(50000, "AcadApplication", vstrCommand + ": Der Aufruf ist für ein geschlossenes Objekt nicht erlaubt.");
			}
		}

		private void InternSetVarsByDefault()
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("CMDACTIVE");
			object vvarAppDefault = 0;
			string rstrErrMsg = "";
			acadSysVar.FriendSetAppDefault(vvarAppDefault, ref rstrErrMsg);
			AcadSysVar acadSysVar2 = mobjAcadSysVars.FriendGetItem("CMDNAMES");
			rstrErrMsg = "";
			acadSysVar2.FriendSetAppDefault(null, ref rstrErrMsg);
			AcadSysVar acadSysVar3 = mobjAcadSysVars.FriendGetItem("CPROFILE");
			rstrErrMsg = "";
			acadSysVar3.FriendSetAppDefault("<<Unbenanntes Profil>>", ref rstrErrMsg);
			AcadSysVar acadSysVar4 = mobjAcadSysVars.FriendGetItem("DCTMAIN");
			rstrErrMsg = "";
			acadSysVar4.FriendSetAppDefault("de", ref rstrErrMsg);
			AcadSysVar acadSysVar5 = mobjAcadSysVars.FriendGetItem("DIASTAT");
			object vvarAppDefault2 = 1;
			rstrErrMsg = "";
			acadSysVar5.FriendSetAppDefault(vvarAppDefault2, ref rstrErrMsg);
			AcadSysVar acadSysVar6 = mobjAcadSysVars.FriendGetItem("LOCALE");
			rstrErrMsg = "";
			acadSysVar6.FriendSetAppDefault("DEU", ref rstrErrMsg);
			AcadSysVar acadSysVar7 = mobjAcadSysVars.FriendGetItem("POPUPS");
			object vvarAppDefault3 = 1;
			rstrErrMsg = "";
			acadSysVar7.FriendSetAppDefault(vvarAppDefault3, ref rstrErrMsg);
			AcadSysVar acadSysVar8 = mobjAcadSysVars.FriendGetItem("SCREENBOXES");
			object vvarAppDefault4 = 0;
			rstrErrMsg = "";
			acadSysVar8.FriendSetAppDefault(vvarAppDefault4, ref rstrErrMsg);
			AcadSysVar acadSysVar9 = mobjAcadSysVars.FriendGetItem("SCREENMODE");
			object vvarAppDefault5 = 1;
			rstrErrMsg = "";
			acadSysVar9.FriendSetAppDefault(vvarAppDefault5, ref rstrErrMsg);
		}
	}

}
