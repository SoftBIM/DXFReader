using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Diagnostics;
using System.Threading;

namespace DXFLib.Acad
{
	public class AcadDocument : NodeObject
	{
		public delegate void ActivateEventHandler();

		public delegate void BeginCloseEventHandler();

		public delegate void BeginSaveEventHandler(string vstrFileName);

		public delegate void DeactivateEventHandler();

		public delegate void EndSaveEventHandler(string vstrFileName);

		public delegate void ReadStartEventHandler(int Entries);

		public delegate void ReadEntryEventHandler(int Entry);

		public delegate void ReadEndEventHandler();

		private const string cstrClassName = "AcadDocument";

		private bool mblnOpened;

		private string mstrAcadVer;

		private string mstrAcadRelease;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private bool mblnActive;

		private Enums.AcActiveSpace mnumActiveSpace;

		private object mdecElevationModelSpace;

		private double mdblElevationModelSpace;

		private object mdecElevationPaperSpace;

		private double mdblElevationPaperSpace;

		private string mstrFullName;

		private string mstrShortName;

		private object[] madecLimits;

		private double[] madblLimits;

		private bool mblnMSpace;

		private string mstrName;

		private bool mblnObjectSnapMode;

		private string mstrPath;

		private bool mblnSaved;

		private bool mblnTitled;

		private FileInfo mobjFileInfo;

		private AcadSysVars mobjAcadSysVars;

		private AcadDatabase mobjAcadDatabase;

		private AcadSummaryInfo mobjAcadSummaryInfo;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[AccessedThroughProperty("mobjAcadDocuments")]
		private AcadDocuments _mobjAcadDocuments;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ActivateEventHandler ActivateEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BeginCloseEventHandler BeginCloseEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private BeginSaveEventHandler BeginSaveEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private DeactivateEventHandler DeactivateEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EndSaveEventHandler EndSaveEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadStartEventHandler ReadStartEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEntryEventHandler ReadEntryEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadEndEventHandler ReadEndEvent;

		[field: AccessedThroughProperty("mobjAcadDocuments")]
		private AcadDocuments mobjAcadDocuments
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal double FriendGetMaxObjectID
		{
			get
			{
				InternCheckOpened("FriendGetMaxObjectID");
				return mobjAcadDatabase.FriendGetMaxObjectID;
			}
		}

		internal double FriendGetNextObjectID
		{
			get
			{
				InternCheckOpened("FriendGetNextObjectID");
				return mobjAcadDatabase.FriendGetNextObjectID;
			}
		}

		internal int FriendGetDatabaseIndex
		{
			get
			{
				InternCheckOpened("FriendGetDatabaseIndex");
				return mobjAcadDatabase.FriendGetDatabaseIndex;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				InternCheckOpened("FriendLetDocumentIndex");
				mlngDocumentIndex = value;
				if (mobjAcadSysVars != null)
				{
					mobjAcadSysVars.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && mobjAcadSummaryInfo != null)
				{
					mobjAcadSummaryInfo.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				if (mobjAcadDatabase != null)
				{
					mobjAcadDatabase.FriendLetDocumentIndex = mlngDocumentIndex;
				}
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

		internal int FriendLetApplicationIndex
		{
			set
			{
				InternCheckOpened("FriendLetApplicationIndex");
				mlngApplicationIndex = value;
				mobjAcadSysVars.FriendLetApplicationIndex = mlngApplicationIndex;
				if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && mobjAcadSummaryInfo != null)
				{
					mobjAcadSummaryInfo.FriendLetApplicationIndex = mlngApplicationIndex;
				}
				mobjAcadDatabase.FriendLetApplicationIndex = mlngApplicationIndex;
			}
		}

		internal bool FriendGetIsOpen => mblnOpened;

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

		public AcadDatabase Database
		{
			get
			{
				InternCheckOpened("Database");
				return mobjAcadDatabase;
			}
		}

		public AcadSummaryInfo SummaryInfo
		{
			get
			{
				InternCheckOpened("SummaryInfo");
				if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
				{
					return mobjAcadSummaryInfo;
				}
				AcadSummaryInfo SummaryInfo = default(AcadSummaryInfo);
				return SummaryInfo;
			}
		}

		public AcadClasses Classes
		{
			get
			{
				InternCheckOpened("Classes");
				return mobjAcadDatabase.Classes;
			}
		}

		public AcadDimStyle ActiveDimStyle
		{
			get
			{
				InternCheckOpened("ActiveDimStyle");
				AcadDimStyle ActiveDimStyle = default(AcadDimStyle);
				return ActiveDimStyle;
			}
			set
			{
				InternCheckOpened("ActiveDimStyle");
			}
		}

		public AcadLayer ActiveLayer
		{
			get
			{
				InternCheckOpened("ActiveLayer");
				AcadLayer ActiveLayer = default(AcadLayer);
				return ActiveLayer;
			}
			set
			{
				InternCheckOpened("ActiveLayer");
			}
		}

		public AcadLayout ActiveLayout
		{
			get
			{
				InternCheckOpened("ActiveLayout");
				AcadLayout ActiveLayout = default(AcadLayout);
				return ActiveLayout;
			}
			set
			{
				InternCheckOpened("ActiveLayout");
			}
		}

		public AcadLineType ActiveLinetype
		{
			get
			{
				InternCheckOpened("ActiveLinetype");
				AcadLineType ActiveLinetype = default(AcadLineType);
				return ActiveLinetype;
			}
			set
			{
				InternCheckOpened("ActiveLinetype");
			}
		}

		public AcadPViewport ActivePViewport
		{
			get
			{
				InternCheckOpened("ActivePViewport");
				AcadPViewport ActivePViewport = default(AcadPViewport);
				return ActivePViewport;
			}
			set
			{
				InternCheckOpened("ActivePViewport");
			}
		}

		public AcadSelectionSet ActiveSelectionSet
		{
			get
			{
				InternCheckOpened("ActiveSelectionSet");
				AcadSelectionSet ActiveSelectionSet = default(AcadSelectionSet);
				return ActiveSelectionSet;
			}
			set
			{
				InternCheckOpened("ActiveSelectionSet");
			}
		}

		public AcadTextStyle ActiveTextStyle
		{
			get
			{
				InternCheckOpened("ActiveTextStyle");
				AcadTextStyle ActiveTextStyle = default(AcadTextStyle);
				return ActiveTextStyle;
			}
			set
			{
				InternCheckOpened("ActiveTextStyle");
			}
		}

		public AcadUCS ActiveUCS
		{
			get
			{
				InternCheckOpened("ActiveUCS");
				AcadUCS ActiveUCS = default(AcadUCS);
				return ActiveUCS;
			}
			set
			{
				InternCheckOpened("ActiveUCS");
			}
		}

		public AcadViewport ActiveViewport
		{
			get
			{
				InternCheckOpened("ActiveViewport");
				AcadViewport ActiveViewport = default(AcadViewport);
				return ActiveViewport;
			}
			set
			{
				InternCheckOpened("ActiveViewport");
			}
		}

		public AcadBlocks Blocks
		{
			get
			{
				InternCheckOpened("Blocks");
				return mobjAcadDatabase.Blocks;
			}
		}

		public AcadModelSpace ModelSpace
		{
			get
			{
				InternCheckOpened("ModelSpace");
				return mobjAcadDatabase.ModelSpace;
			}
		}

		public AcadPaperSpace PaperSpace
		{
			get
			{
				InternCheckOpened("PaperSpace");
				return mobjAcadDatabase.PaperSpace;
			}
		}

		public AcadDimStyles DimStyles
		{
			get
			{
				InternCheckOpened("DimStyles");
				return mobjAcadDatabase.DimStyles;
			}
		}

		public AcadLayers Layers
		{
			get
			{
				InternCheckOpened("Layers");
				return mobjAcadDatabase.Layers;
			}
		}

		public AcadLineTypes Linetypes
		{
			get
			{
				InternCheckOpened("Linetypes");
				return mobjAcadDatabase.Linetypes;
			}
		}

		public AcadRegisteredApplications RegisteredApplications
		{
			get
			{
				InternCheckOpened("RegisteredApplications");
				return mobjAcadDatabase.RegisteredApplications;
			}
		}

		public AcadTextStyles TextStyles
		{
			get
			{
				InternCheckOpened("TextStyles");
				return mobjAcadDatabase.TextStyles;
			}
		}

		public AcadUCSs UserCoordinateSystems
		{
			get
			{
				InternCheckOpened("UserCoordinateSystems");
				return mobjAcadDatabase.UserCoordinateSystems;
			}
		}

		public AcadViewports Viewports
		{
			get
			{
				InternCheckOpened("Viewports");
				return mobjAcadDatabase.Viewports;
			}
		}

		public AcadViews Views
		{
			get
			{
				InternCheckOpened("Views");
				return mobjAcadDatabase.Views;
			}
		}

		public AcadDictionaries Dictionaries
		{
			get
			{
				InternCheckOpened("Dictionaries");
				return mobjAcadDatabase.Dictionaries;
			}
		}

		public AcadGroups Groups
		{
			get
			{
				InternCheckOpened("Groups");
				return mobjAcadDatabase.Groups;
			}
		}

		public AcadDictionaryWithDefault PlotStyleNames
		{
			get
			{
				InternCheckOpened("PlotStyleNames");
				return mobjAcadDatabase.PlotStyleNames;
			}
		}

		public AcadMLineStyles MlineStyles
		{
			get
			{
				InternCheckOpened("MlineStyles");
				return mobjAcadDatabase.MlineStyles;
			}
		}

		public AcadPlotConfigurations PlotConfigurations
		{
			get
			{
				InternCheckOpened("PlotConfigurations");
				return mobjAcadDatabase.PlotConfigurations;
			}
		}

		public AcadLayouts Layouts
		{
			get
			{
				InternCheckOpened("Layouts");
				return mobjAcadDatabase.Layouts;
			}
		}

		public AcadSelectionSet PickfirstSelectionSet
		{
			get
			{
				InternCheckOpened("PickfirstSelectionSet");
				AcadSelectionSet PickfirstSelectionSet = default(AcadSelectionSet);
				return PickfirstSelectionSet;
			}
		}

		public AcadPreferences Preferences
		{
			get
			{
				InternCheckOpened("Preferences");
				AcadPreferences Preferences = default(AcadPreferences);
				return Preferences;
			}
		}

		public AcadSelectionSets SelectionSets
		{
			get
			{
				InternCheckOpened("SelectionSets");
				AcadSelectionSets SelectionSets = default(AcadSelectionSets);
				return SelectionSets;
			}
		}

		public AcadUtility Utility
		{
			get
			{
				InternCheckOpened("Utility");
				AcadUtility Utility = default(AcadUtility);
				return Utility;
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

		public string AcadVer
		{
			get
			{
				InternCheckOpened("AcadVer");
				return mstrAcadVer;
			}
		}

		public string AcadRelease
		{
			get
			{
				InternCheckOpened("AcadRelease");
				return mstrAcadRelease;
			}
		}

		public bool Active
		{
			get
			{
				InternCheckOpened("Active");
				return mblnActive;
			}
		}

		public Enums.AcActiveSpace ActiveSpace
		{
			get
			{
				InternCheckOpened("ActiveSpace");
				return mnumActiveSpace;
			}
			set
			{
				InternCheckOpened("ActiveSpace");
				mnumActiveSpace = value;
			}
		}

		public object ElevationModelSpace
		{
			get
			{
				InternCheckOpened("ElevationModelSpace");
				return RuntimeHelpers.GetObjectValue(mobjAcadDatabase.ElevationModelSpace);
			}
			set
			{
				InternCheckOpened("ElevationModelSpace");
				mobjAcadDatabase.ElevationModelSpace = RuntimeHelpers.GetObjectValue(value);
			}
		}

		public object ElevationPaperSpace
		{
			get
			{
				InternCheckOpened("ElevationPaperSpace");
				return RuntimeHelpers.GetObjectValue(mobjAcadDatabase.ElevationPaperSpace);
			}
			set
			{
				InternCheckOpened("ElevationPaperSpace");
				mobjAcadDatabase.ElevationPaperSpace = RuntimeHelpers.GetObjectValue(value);
			}
		}

		public string FullName
		{
			get
			{
				InternCheckOpened("FullName");
				return mstrFullName;
			}
		}

		public string ShortName
		{
			get
			{
				InternCheckOpened("ShortName");
				return mstrShortName;
			}
		}

		public object Limits
		{
			get
			{
				InternCheckOpened("Limits");
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecLimits, madblLimits));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				InternCheckOpened("Limits");
				ref object[] reference = ref madecLimits;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblLimits;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
				}
			}
		}

		public bool MSpace
		{
			get
			{
				InternCheckOpened("MSpace");
				return mblnMSpace;
			}
			set
			{
				InternCheckOpened("MSpace");
				mblnMSpace = value;
			}
		}

		public string Name
		{
			get
			{
				InternCheckOpened("Name");
				return mstrName;
			}
		}

		public bool ObjectSnapMode
		{
			get
			{
				InternCheckOpened("ObjectSnapMode");
				return mblnObjectSnapMode;
			}
			set
			{
				InternCheckOpened("ObjectSnapMode");
				mblnObjectSnapMode = value;
			}
		}

		public string Path
		{
			get
			{
				InternCheckOpened("Path");
				return mstrPath;
			}
		}

		public bool Saved
		{
			get
			{
				InternCheckOpened("Saved");
				return mblnSaved;
			}
		}

		public bool Titled
		{
			get
			{
				InternCheckOpened("Titled");
				return mblnTitled;
			}
		}

		public int FileSize
		{
			get
			{
				InternCheckOpened("FileSize");
				if (mobjFileInfo != null)
				{
					return checked((int)mobjFileInfo.Length);
				}
				int FileSize = default(int);
				return FileSize;
			}
		}

		public DateTime FileCreated
		{
			get
			{
				InternCheckOpened("FileCreated");
				if (mobjFileInfo != null)
				{
					return mobjFileInfo.CreationTime;
				}
				DateTime FileCreated = default(DateTime);
				return FileCreated;
			}
		}

		public DateTime FileLastAccessed
		{
			get
			{
				InternCheckOpened("FileLastAccessed");
				if (mobjFileInfo != null)
				{
					return mobjFileInfo.LastAccessTime;
				}
				DateTime FileLastAccessed = default(DateTime);
				return FileLastAccessed;
			}
		}

		public DateTime FileLastModified
		{
			get
			{
				InternCheckOpened("FileLastModified");
				if (mobjFileInfo != null)
				{
					return mobjFileInfo.LastWriteTime;
				}
				DateTime FileLastModified = default(DateTime);
				return FileLastModified;
			}
		}

		public string FingerprintGUID
		{
			get
			{
				InternCheckOpened("FingerprintGUID");
				AcadSysVar dobjAcadSysVar2 = mobjAcadSysVars.FriendGetItem("FINGERPRINTGUID");
				string FingerprintGUID = default(string);
				if (dobjAcadSysVar2 != null)
				{
					object dvarValue = RuntimeHelpers.GetObjectValue(dobjAcadSysVar2.Value);
					if (dvarValue != null)
					{
						string dstrValue3 = Conversions.ToString(dvarValue);
						dstrValue3 = Strings.Replace(dstrValue3, "{", null);
						dstrValue3 = Strings.Replace(dstrValue3, "}", null);
						FingerprintGUID = Conversions.ToString(dvarValue);
					}
				}
				dobjAcadSysVar2 = null;
				return FingerprintGUID;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				InternCheckOpened("FingerprintGUID");
				string dstrMatch = "{????????-????-????-????-????????????}";
				dstrMatch = Strings.Replace(dstrMatch, "?", "[0123456789ABCDEF]");
				bool dblnDone = default(bool);
				AcadSysVar dobjAcadSysVar2;
				if (LikeOperator.LikeString(value, dstrMatch, CompareMethod.Binary))
				{
					dobjAcadSysVar2 = mobjAcadSysVars.FriendGetItem("FINGERPRINTGUID");
					if (dobjAcadSysVar2 != null && Operators.ConditionalCompareObjectEqual(dobjAcadSysVar2.Value, null, TextCompare: false))
					{
						dblnDone = true;
						AcadSysVar acadSysVar = dobjAcadSysVar2;
						string nrstrErrMsg = "";
						acadSysVar.FriendSetValue(value, vblnRaiseEvent: true, ref nrstrErrMsg);
					}
				}
				dobjAcadSysVar2 = null;
				if (!dblnDone)
				{
					Information.Err().Raise(50000, "AcadDocument", "Die Eigenschaft FingerprintGUID konnte nicht geändert werden.");
				}
			}
		}

		public string VersionGUID
		{
			get
			{
				InternCheckOpened("VersionGUID");
				AcadSysVar dobjAcadSysVar2 = mobjAcadSysVars.FriendGetItem("VERSIONGUID");
				string VersionGUID = default(string);
				if (dobjAcadSysVar2 != null)
				{
					object dvarValue = RuntimeHelpers.GetObjectValue(dobjAcadSysVar2.Value);
					if (dvarValue != null)
					{
						string dstrValue3 = Conversions.ToString(dvarValue);
						dstrValue3 = Strings.Replace(dstrValue3, "{", null);
						dstrValue3 = Strings.Replace(dstrValue3, "}", null);
						VersionGUID = Conversions.ToString(dvarValue);
					}
				}
				dobjAcadSysVar2 = null;
				return VersionGUID;
			}
		}

		public event ActivateEventHandler Activate
		{
			[CompilerGenerated]
			add
			{
				ActivateEventHandler activateEventHandler = ActivateEvent;
				ActivateEventHandler activateEventHandler2;
				do
				{
					activateEventHandler2 = activateEventHandler;
					ActivateEventHandler value2 = (ActivateEventHandler)Delegate.Combine(activateEventHandler2, value);
					activateEventHandler = Interlocked.CompareExchange(ref ActivateEvent, value2, activateEventHandler2);
				}
				while ((object)activateEventHandler != activateEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ActivateEventHandler activateEventHandler = ActivateEvent;
				ActivateEventHandler activateEventHandler2;
				do
				{
					activateEventHandler2 = activateEventHandler;
					ActivateEventHandler value2 = (ActivateEventHandler)Delegate.Remove(activateEventHandler2, value);
					activateEventHandler = Interlocked.CompareExchange(ref ActivateEvent, value2, activateEventHandler2);
				}
				while ((object)activateEventHandler != activateEventHandler2);
			}
		}

		public event BeginCloseEventHandler BeginClose
		{
			[CompilerGenerated]
			add
			{
				BeginCloseEventHandler beginCloseEventHandler = BeginCloseEvent;
				BeginCloseEventHandler beginCloseEventHandler2;
				do
				{
					beginCloseEventHandler2 = beginCloseEventHandler;
					BeginCloseEventHandler value2 = (BeginCloseEventHandler)Delegate.Combine(beginCloseEventHandler2, value);
					beginCloseEventHandler = Interlocked.CompareExchange(ref BeginCloseEvent, value2, beginCloseEventHandler2);
				}
				while ((object)beginCloseEventHandler != beginCloseEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				BeginCloseEventHandler beginCloseEventHandler = BeginCloseEvent;
				BeginCloseEventHandler beginCloseEventHandler2;
				do
				{
					beginCloseEventHandler2 = beginCloseEventHandler;
					BeginCloseEventHandler value2 = (BeginCloseEventHandler)Delegate.Remove(beginCloseEventHandler2, value);
					beginCloseEventHandler = Interlocked.CompareExchange(ref BeginCloseEvent, value2, beginCloseEventHandler2);
				}
				while ((object)beginCloseEventHandler != beginCloseEventHandler2);
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

		public event DeactivateEventHandler Deactivate
		{
			[CompilerGenerated]
			add
			{
				DeactivateEventHandler deactivateEventHandler = DeactivateEvent;
				DeactivateEventHandler deactivateEventHandler2;
				do
				{
					deactivateEventHandler2 = deactivateEventHandler;
					DeactivateEventHandler value2 = (DeactivateEventHandler)Delegate.Combine(deactivateEventHandler2, value);
					deactivateEventHandler = Interlocked.CompareExchange(ref DeactivateEvent, value2, deactivateEventHandler2);
				}
				while ((object)deactivateEventHandler != deactivateEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				DeactivateEventHandler deactivateEventHandler = DeactivateEvent;
				DeactivateEventHandler deactivateEventHandler2;
				do
				{
					deactivateEventHandler2 = deactivateEventHandler;
					DeactivateEventHandler value2 = (DeactivateEventHandler)Delegate.Remove(deactivateEventHandler2, value);
					deactivateEventHandler = Interlocked.CompareExchange(ref DeactivateEvent, value2, deactivateEventHandler2);
				}
				while ((object)deactivateEventHandler != deactivateEventHandler2);
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

		private void mobjAcadDocuments_ReadStart(int Entries)
		{
			ReadStartEvent?.Invoke(Entries);
		}

		private void mobjAcadDocuments_ReadEntry(int Entry)
		{
			ReadEntryEvent?.Invoke(Entry);
		}

		private void mobjAcadDocuments_ReadEnd()
		{
			ReadEndEvent?.Invoke();
		}

		internal void RaiseEventActivate()
		{
			ActivateEvent?.Invoke();
		}

		internal void RaiseEventBeginClose()
		{
			BeginCloseEvent?.Invoke();
		}

		internal void RaiseEventBeginSave(string vstrFileName)
		{
			Application.RaiseEventBeginSave(vstrFileName);
			BeginSaveEvent?.Invoke(vstrFileName);
		}

		internal void RaiseEventDeactivate()
		{
			DeactivateEvent?.Invoke();
		}

		internal void RaiseEventEndSave(string vstrFileName)
		{
			Application.RaiseEventBeginSave(vstrFileName);
			EndSaveEvent?.Invoke(vstrFileName);
		}

		private void InternPropSet()
		{
			bool flag = false;
			mdblElevationModelSpace = hwpDxf_Vars.pdblElevationModelSpace;
			mdblElevationPaperSpace = hwpDxf_Vars.pdblElevationPaperSpace;
			madblLimits[0] = hwpDxf_Vars.padblLimits[0];
			madblLimits[1] = hwpDxf_Vars.padblLimits[1];
			madblLimits[2] = hwpDxf_Vars.padblLimits[2];
			madblLimits[3] = hwpDxf_Vars.padblLimits[3];
			mblnActive = hwpDxf_Vars.pblnActive;
			mnumActiveSpace = hwpDxf_Vars.pnumActiveSpace;
			mstrFullName = hwpDxf_Vars.pstrFullName;
			mstrShortName = hwpDxf_Vars.pstrShortName;
			mblnMSpace = hwpDxf_Vars.pblnMSpace;
			mstrName = hwpDxf_Vars.pstrName;
			mblnObjectSnapMode = hwpDxf_Vars.pblnObjectSnapMode;
			mstrPath = hwpDxf_Vars.pstrAppPath;
			mblnSaved = hwpDxf_Vars.pblnSaved;
			mblnTitled = hwpDxf_Vars.pblnDwgTitled;
		}

		public AcadDocument()
		{
			madecLimits = new object[4];
			madblLimits = new double[4];
			hwpDxf_Init.BkDXF_InitDefObjValues();
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 107;
			base.FriendLetNodeImageDisabledID = 108;
			base.FriendLetNodeName = "Dokument";
			base.FriendLetNodeText = "Dokument";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			InternPropSet();
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			AcadApplication dobjAcadApplication2;
			if (!hwpDxf_Vars.pblnAddDocument)
			{
				hwpDxf_Vars.pblnInitDocument = true;
				dobjAcadApplication2 = new AcadApplication();
				hwpDxf_Vars.pblnInitDocument = false;
				AcadApplication acadApplication = dobjAcadApplication2;
				FriendInit(acadApplication.AcadVer, acadApplication.Documents.NodeID, acadApplication.FriendGetApplicationIndex);
				acadApplication = null;
				AcadDocuments documents = dobjAcadApplication2.Documents;
				AcadDocument robjAcadDocument = this;
				documents.FriendSetNewDoc(ref robjAcadDocument);
			}
			dobjAcadApplication2 = null;
		}

		internal void FriendInit(string vstrAcadVer, int vlngNodeParentID, int vlngApplicationIndex, object nvvarReservedHandles = null)
		{
			mstrAcadVer = vstrAcadVer;
			mstrAcadRelease = hwpDxf_Functions.BkDXF_DxfAcadVerToRelease(mstrAcadVer);
			base.FriendLetNodeParentID = vlngNodeParentID;
			mlngApplicationIndex = vlngApplicationIndex;
			mobjAcadSysVars = new AcadSysVars();
			mobjAcadSysVars.FriendLetNodeParentID = base.NodeID;
			mobjAcadSysVars.FriendLetApplicationIndex = mlngApplicationIndex;
			mobjAcadSysVars.FriendLetDocumentIndex = mlngDocumentIndex;
			mobjAcadSysVars.FriendOpen((hwpDxf_Enums.REF_TYPE)10);
			InternSetVarsByDefault();
			if (!hwpDxf_Vars.pblnInitDatabase)
			{
				hwpDxf_Vars.pblnAddDatabase = true;
				mobjAcadDatabase = new AcadDatabase();
				hwpDxf_Vars.pblnAddDatabase = false;
				mobjAcadDatabase.FriendInit(base.NodeID, mlngApplicationIndex, mlngDocumentIndex, nvblnNew: true, RuntimeHelpers.GetObjectValue(nvvarReservedHandles));
				FriendSetDatabase(ref mobjAcadDatabase);
			}
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
			{
				mobjAcadSummaryInfo = new AcadSummaryInfo();
				mobjAcadSummaryInfo.FriendLetNodeParentID = base.NodeID;
				mobjAcadSummaryInfo.FriendLetApplicationIndex = mlngApplicationIndex;
				mobjAcadSummaryInfo.FriendLetDocumentIndex = mlngDocumentIndex;
			}
			InternSetTableVarsByDefault();
		}

		internal void FriendReset(string vstrAcadVer)
		{
			InternCheckOpened("FriendReset");
			InternPropSet();
			mstrAcadVer = vstrAcadVer;
			mstrAcadRelease = hwpDxf_Functions.BkDXF_DxfAcadVerToRelease(mstrAcadVer);
			mobjAcadSysVars.FriendReset();
			InternSetVarsByDefault();
			mobjAcadDatabase.FriendReset();
			if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0)
			{
				if (mobjAcadSummaryInfo == null)
				{
					mobjAcadSummaryInfo = new AcadSummaryInfo();
					mobjAcadSummaryInfo.FriendLetNodeParentID = base.NodeID;
					mobjAcadSummaryInfo.FriendLetApplicationIndex = mlngApplicationIndex;
					mobjAcadSummaryInfo.FriendLetDocumentIndex = mlngDocumentIndex;
				}
				else
				{
					mobjAcadSummaryInfo.FriendReset();
				}
			}
			else if (mobjAcadSummaryInfo != null)
			{
				mobjAcadSummaryInfo.FriendQuit();
				mobjAcadSummaryInfo = null;
			}
			if (!hwpDxf_Vars.pblnReadDocument & !hwpDxf_Vars.pblnCleanDocument)
			{
				mobjAcadDatabase.FriendAddAndInitObjects();
				InternSetTableVarsByDefault();
			}
		}

		~AcadDocument()
		{
			FriendQuit();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				RaiseEventBeginClose();
				mobjAcadSysVars.FriendQuit();
				if (Operators.CompareString(mstrAcadVer, "AC1018", TextCompare: false) >= 0 && mobjAcadSummaryInfo != null)
				{
					mobjAcadSummaryInfo.FriendQuit();
				}
				mobjAcadDatabase.FriendQuit();
				base.FriendQuit();
				mobjFileInfo = null;
				mobjAcadSysVars = null;
				mobjAcadSummaryInfo = null;
				mobjAcadDatabase = null;
				mobjAcadDocuments = null;
				mblnOpened = false;
			}
		}

		internal void FriendSetDatabase(ref AcadDatabase robjAcadDatabase)
		{
			InternCheckOpened("FriendSetDatabase");
			mobjAcadDatabase = robjAcadDatabase;
		}

		internal AcadSysVar FriendFindVariable(string vstrName)
		{
			InternCheckOpened("FriendFindVariable");
			vstrName = Strings.UCase(vstrName);
			AcadSysVar dobjAcadSysVar2 = mobjAcadSysVars.FriendGetItem(vstrName);
			if (dobjAcadSysVar2 == null)
			{
				dobjAcadSysVar2 = Database.Viewports.FriendGetActiveViewport.FriendFindVariable(vstrName);
				if (dobjAcadSysVar2 == null)
				{
					dobjAcadSysVar2 = Application.FriendFindVariable(vstrName);
				}
			}
			AcadSysVar FriendFindVariable = dobjAcadSysVar2;
			dobjAcadSysVar2 = null;
			return FriendFindVariable;
		}

		internal object FriendGetVariable(string vstrName)
		{
			InternCheckOpened("FriendGetVariable");
			return RuntimeHelpers.GetObjectValue(FriendFindVariable(vstrName).Value);
		}

		internal void FriendSetVariable(string vstrName, object vvarValue)
		{
			InternCheckOpened("FriendSetVariable");
			object value = FriendFindVariable(vstrName).Value;
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

		internal void FriendSetActiveState(bool vblnActive)
		{
			if (mblnActive != vblnActive)
			{
				mblnActive = vblnActive;
				if (mblnActive)
				{
					RaiseEventActivate();
				}
				else
				{
					RaiseEventDeactivate();
				}
			}
		}

		internal void FriendSetFullName(string vstrFullName, bool vblnDwgTitled)
		{
			InternCheckOpened("FriendSetFullName");
			string nrstrPost = "";
			string dstrPath = default(string);
			string dstrName = hwpDxf_Functions.BkDXF_SeperateFilePrefix(vstrFullName, ref dstrPath, ref nrstrPost);
			InternSetDwgToAppVarDwgName(dstrName + ".dxf");
			checked
			{
				if (Operators.CompareString(dstrPath, null, TextCompare: false) != 0)
				{
					if (LikeOperator.LikeString(dstrPath, "*\\", CompareMethod.Binary))
					{
						dstrPath = Strings.Mid(dstrPath, 1, Strings.Len(dstrPath) - 1);
					}
					InternSetDwgToAppVarDwgPrefix(dstrPath);
					mstrFullName = mstrPath + "\\" + mstrName;
					mstrShortName = Strings.Mid(mstrName, 1, Strings.Len(mstrName) - 4);
					if (basAPI_FileSystem.API_FS_FileExists(mstrFullName))
					{
						mobjFileInfo = new FileInfo(mstrFullName);
					}
				}
				else
				{
					InternSetDwgToAppVarDwgPrefix(hwpDxf_Vars.pstrAppPath);
					mstrFullName = null;
					mstrShortName = null;
					mobjFileInfo = null;
				}
				InternSetDwgToAppVarDwgTitled(vblnDwgTitled);
				base.FriendLetNodeText = mstrName;
			}
		}

		internal bool FriendCloseDoc(ref string nrstrErrMsg, bool nvblnSaveChanges = true, string nvstrFileName = null)
		{
			nrstrErrMsg = null;
			bool FriendCloseDoc = default(bool);
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 1, TextCompare: false))
			{
				AcadApplication dobjApplication3 = null;
				nrstrErrMsg = "Diese Methode ist im SDI-Modus nicht erlaubt.";
			}
			else
			{
				AcadApplication dobjApplication3 = Application;
				AcadDocuments documents = dobjApplication3.Documents;
				AcadDocument robjAcadDocument = this;
				documents.FriendRemoveDoc(ref robjAcadDocument);
				FriendCloseDoc = true;
				dobjApplication3 = null;
			}
			return FriendCloseDoc;
		}

		internal bool FriendNewDoc(ref AcadDocument robjAcadDocument, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjAcadDocument = null;
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 0, TextCompare: false))
			{
				nrstrErrMsg = "Diese Methode ist nur im SDI-Modus erlaubt.";
				bool FriendNewDoc = default(bool);
				return FriendNewDoc;
			}
			Application.Documents.FriendSDINewDoc(mlngDocumentIndex);
			robjAcadDocument = this;
			return true;
		}

		internal bool FriendOpenDoc(string vstrFileName, ref AcadDocument robjAcadDocument, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjAcadDocument = null;
			bool FriendOpenDoc = default(bool);
			if (Operators.ConditionalCompareObjectEqual(Application.FriendGetVariable("SDI"), 0, TextCompare: false))
			{
				mobjAcadDocuments = null;
				nrstrErrMsg = "Diese Methode ist nur im SDI-Modus erlaubt.";
			}
			else
			{
				mobjAcadDocuments = Application.Documents;
				if (mobjAcadDocuments != null)
				{
					if (!mobjAcadDocuments.FriendSDIOpenDoc(mlngDocumentIndex, vstrFileName, ref nrstrErrMsg))
					{
						mobjAcadDocuments = null;
					}
					else
					{
						robjAcadDocument = this;
						FriendOpenDoc = true;
						mobjAcadDocuments = null;
					}
				}
			}
			return FriendOpenDoc;
		}

		internal bool FriendSave(string vstrFullFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			string dstrOldFileName = (Operators.CompareString(mstrFullName, null, TextCompare: false) != 0) ? mstrFullName : (mstrPath + "\\" + mstrName);
			string dstrNewFileName = (Operators.CompareString(vstrFullFileName, null, TextCompare: false) != 0) ? vstrFullFileName : (mstrPath + "\\" + mstrName);
			string dstrFullFileName = (Operators.CompareString(vstrFullFileName, null, TextCompare: false) != 0) ? vstrFullFileName : mstrName;
			RaiseEventBeginSave(dstrOldFileName);
			object dvarAcadDateLocal2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadDate());
			object dvarAcadDateGlobal2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadDate(nvblnGlobal: true));
			dvarAcadDateLocal2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, Conversions.ToDecimal(dvarAcadDateLocal2), Conversions.ToDouble(dvarAcadDateLocal2)));
			dvarAcadDateGlobal2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, Conversions.ToDecimal(dvarAcadDateGlobal2), Conversions.ToDouble(dvarAcadDateGlobal2)));
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("TDUPDATE");
			object objectValue = RuntimeHelpers.GetObjectValue(dvarAcadDateLocal2);
			string nrstrErrMsg2 = "";
			acadSysVar.FriendSetValue(objectValue, vblnRaiseEvent: true, ref nrstrErrMsg2);
			AcadSysVar acadSysVar2 = mobjAcadSysVars.FriendGetItem("TDUUPDATE");
			object objectValue2 = RuntimeHelpers.GetObjectValue(dvarAcadDateGlobal2);
			nrstrErrMsg2 = "";
			acadSysVar2.FriendSetValue(objectValue2, vblnRaiseEvent: true, ref nrstrErrMsg2);
			AcadSysVar dobjAcadSysVar3 = mobjAcadSysVars.FriendGetItem("FINGERPRINTGUID");
			if (Operators.ConditionalCompareObjectEqual(dobjAcadSysVar3.Value, null, TextCompare: false))
			{
				AcadSysVar acadSysVar3 = dobjAcadSysVar3;
				string vvarValue = Guid.NewGuid().ToString("B").ToUpper();
				nrstrErrMsg2 = "";
				acadSysVar3.FriendSetValue(vvarValue, vblnRaiseEvent: true, ref nrstrErrMsg2);
			}
			dobjAcadSysVar3 = mobjAcadSysVars.FriendGetItem("VERSIONGUID");
			if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(dobjAcadSysVar3.Value, null, TextCompare: false), Operators.CompareObjectNotEqual(mobjAcadSysVars.FriendGetItem("DBMOD").Value, 0, TextCompare: false))))
			{
				AcadSysVar acadSysVar4 = mobjAcadSysVars.FriendGetItem("VERSIONGUID");
				string vvarValue2 = Guid.NewGuid().ToString("B").ToUpper();
				nrstrErrMsg2 = "";
				acadSysVar4.FriendSetValue(vvarValue2, vblnRaiseEvent: true, ref nrstrErrMsg2);
			}
			AcadDocument robjAcadDocument = this;
			bool FriendSave = default(bool);
			if (InternWriteFile(dstrNewFileName, ref robjAcadDocument, ref nrstrErrMsg))
			{
				InternSetDwgToAppVarSaveName(vstrFullFileName);
				FriendSetFullName(dstrFullFileName, vblnDwgTitled: true);
				InternSetDwgToAppVarSaveFile(hwpDxf_Vars.pstrSaveFile);
				FriendSave = true;
				RaiseEventEndSave(dstrNewFileName);
			}
			dobjAcadSysVar3 = null;
			return FriendSave;
		}

		internal bool FriendSaveAs(string vstrFullFileName, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			if (FriendSave(vstrFullFileName, ref nrstrErrMsg))
			{
				return true;
			}
			bool FriendSaveAs = default(bool);
			return FriendSaveAs;
		}

		internal bool FriendHandleToObject(string vstrHandle, ref AcadObject robjAcadObject, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjAcadObject = null;
			if (!mobjAcadDatabase.FriendHandleToObject(vstrHandle, ref robjAcadObject, ref nrstrErrMsg))
			{
				robjAcadObject = null;
				bool FriendHandleToObject = default(bool);
				return FriendHandleToObject;
			}
			return true;
		}

		internal bool FriendObjectIdToObject(double vdblObjectID, ref AcadObject robjAcadObject, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjAcadObject = null;
			if (!mobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref robjAcadObject, ref nrstrErrMsg))
			{
				robjAcadObject = null;
				bool FriendObjectIdToObject = default(bool);
				return FriendObjectIdToObject;
			}
			return true;
		}

		public string NewFingerprintGUID()
		{
			AcadSysVar dobjAcadSysVar2 = mobjAcadSysVars.FriendGetItem("FINGERPRINTGUID");
			if (dobjAcadSysVar2 != null)
			{
				AcadSysVar acadSysVar = dobjAcadSysVar2;
				string vvarValue = Guid.NewGuid().ToString("B").ToUpper();
				string nrstrErrMsg = "";
				acadSysVar.FriendSetValue(vvarValue, vblnRaiseEvent: true, ref nrstrErrMsg);
			}
			string NewFingerprintGUID = FingerprintGUID;
			dobjAcadSysVar2 = null;
			return NewFingerprintGUID;
		}

		public void Activate_Renamed()
		{
			InternCheckOpened("Activate");
			AcadDocuments documents = Application.Documents;
			AcadDocument robjAcadDocument = this;
			documents.FriendActivateDocument(ref robjAcadDocument);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void CloseDoc(bool nvblnSaveChanges = true, string nvstrFileName = null)
		{
			InternCheckOpened("CloseDoc");
			string dstrErrMsg = default(string);
			if (!FriendCloseDoc(ref dstrErrMsg, nvblnSaveChanges, nvstrFileName))
			{
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
		}

		public object CopyObjects(ref object nrvarIdPairs, object vvarObjects, object nvvarOwner = null)
		{
			InternCheckOpened("CopyObjects");
			object CopyObjects = default(object);
			return CopyObjects;
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
				Information.Err().Raise(50000, "AcadDocument", "Die Systemvariable existiert nicht.");
			}
			else
			{
				GetVariable = RuntimeHelpers.GetObjectValue(dobjAcadSysVar2.Value);
				dobjAcadSysVar2 = null;
			}
			return GetVariable;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadDocument NewDoc()
		{
			InternCheckOpened("NewDoc");
			string dstrErrMsg = default(string);
			AcadDocument NewDoc = default(AcadDocument);
			AcadDocument dobjAcadDocument3 = default(AcadDocument);
			if (!FriendNewDoc(ref dobjAcadDocument3, ref dstrErrMsg))
			{
				dobjAcadDocument3 = null;
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
			else
			{
				NewDoc = dobjAcadDocument3;
				dobjAcadDocument3 = null;
			}
			return NewDoc;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadDocument OpenDoc(string vstrFileName)
		{
			InternCheckOpened("OpenDoc");
			string dstrErrMsg = default(string);
			AcadDocument OpenDoc = default(AcadDocument);
			AcadDocument dobjAcadDocument3 = default(AcadDocument);
			if (!FriendOpenDoc(vstrFileName, ref dobjAcadDocument3, ref dstrErrMsg))
			{
				dobjAcadDocument3 = null;
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
			else
			{
				OpenDoc = dobjAcadDocument3;
				dobjAcadDocument3 = null;
			}
			return OpenDoc;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void Save()
		{
			InternCheckOpened("Save");
			string dstrErrMsg = default(string);
			if (!FriendSave(mstrFullName, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SaveAs(string vstrFullFileName)
		{
			InternCheckOpened("SaveAs");
			string dstrErrMsg = default(string);
			if (!FriendSaveAs(vstrFullFileName, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object HandleToObject(string vstrHandle)
		{
			InternCheckOpened("HandleToObject");
			string dstrErrMsg = default(string);
			object HandleToObject = default(object);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendHandleToObject(vstrHandle, ref dobjAcadObject3, ref dstrErrMsg))
			{
				dobjAcadObject3 = null;
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
			else
			{
				HandleToObject = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return HandleToObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object ObjectIdToObject(double vdblObjectID)
		{
			InternCheckOpened("ObjectIdToObject");
			string dstrErrMsg = default(string);
			object ObjectIdToObject = default(object);
			AcadObject dobjAcadObject3 = default(AcadObject);
			if (!FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject3, ref dstrErrMsg))
			{
				dobjAcadObject3 = null;
				Information.Err().Raise(50000, "AcadDocument", dstrErrMsg);
			}
			else
			{
				ObjectIdToObject = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return ObjectIdToObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetVariable(string vstrName, object vvarValue)
		{
			InternCheckOpened("SetVariable");
			AcadSysVar dobjAcadSysVar3 = FriendFindVariable(vstrName);
			string dstrErrMsg = default(string);
			if (dobjAcadSysVar3 == null)
			{
				Information.Err().Raise(50000, "AcadDocument", "Die Systemvariable existiert nicht.");
			}
			else if (!dobjAcadSysVar3.FriendSetValue(RuntimeHelpers.GetObjectValue(vvarValue), vblnRaiseEvent: true, ref dstrErrMsg))
			{
				dobjAcadSysVar3 = null;
				Information.Err().Raise(50000, "AcadDocument", "Die Systemvariable konnte nicht gesetzt werden.\n" + dstrErrMsg);
			}
			else
			{
				dobjAcadSysVar3 = null;
			}
		}

		public void Clean()
		{
			InternCheckOpened("Clean");
			hwpDxf_Vars.pblnCleanDocument = true;
			FriendReset(mstrAcadVer);
			hwpDxf_Vars.pblnCleanDocument = false;
		}

		private void InternSetDwgToAppVarDwgName(string vstrName)
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("DWGNAME");
			string nrstrErrMsg = "";
			acadSysVar.FriendSetValue(vstrName, vblnRaiseEvent: true, ref nrstrErrMsg);
			mstrName = vstrName;
		}

		private void InternSetDwgToAppVarDwgPrefix(string vstrPath)
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("DWGPREFIX");
			string vvarValue = vstrPath + "\\";
			string nrstrErrMsg = "";
			acadSysVar.FriendSetValue(vvarValue, vblnRaiseEvent: true, ref nrstrErrMsg);
			mstrPath = vstrPath;
		}

		private void InternSetDwgToAppVarDwgTitled(bool vblnDwgTitled)
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("DWGTITLED");
			object objectValue = RuntimeHelpers.GetObjectValue(Interaction.IIf(vblnDwgTitled, 1, 0));
			string nrstrErrMsg = "";
			acadSysVar.FriendSetValue(objectValue, vblnRaiseEvent: true, ref nrstrErrMsg);
			mblnTitled = vblnDwgTitled;
		}

		private void InternSetDwgToAppVarSaveFile(string vstrSaveFile)
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("SAVEFILE");
			string nrstrErrMsg = "";
			acadSysVar.FriendSetValue(vstrSaveFile, vblnRaiseEvent: true, ref nrstrErrMsg);
		}

		private void InternSetDwgToAppVarSaveName(string vstrSaveName)
		{
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("SAVENAME");
			string nrstrErrMsg = "";
			acadSysVar.FriendSetValue(vstrSaveName, vblnRaiseEvent: true, ref nrstrErrMsg);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void InternCheckOpened(string vstrCommand)
		{
			if (!mblnOpened)
			{
				Information.Err().Raise(50000, "AcadDocument", vstrCommand + ": Der Aufruf ist für ein geschlossenes Objekt nicht erlaubt.");
			}
		}

		private void InternSetVarsByDefault()
		{
			object[] dadec3DArray = new object[3];
			double[] dadbl3DArray = new double[3];
			AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("ACADMAINTVER");
			object vvarAppDefault = 6;
			string rstrErrMsg = "";
			acadSysVar.FriendSetAppDefault(vvarAppDefault, ref rstrErrMsg);
			AcadSysVar acadSysVar2 = mobjAcadSysVars.FriendGetItem("DWGCODEPAGE");
			rstrErrMsg = "";
			acadSysVar2.FriendSetAppDefault("ANSI_1252", ref rstrErrMsg);
			bool flag = false;
			dadbl3DArray[0] = -1E+20;
			dadbl3DArray[1] = -1E+20;
			dadbl3DArray[2] = -1E+20;
			AcadSysVar acadSysVar3 = mobjAcadSysVars.FriendGetItem("EXTMAX");
			rstrErrMsg = "";
			acadSysVar3.FriendSetAppDefault(dadbl3DArray, ref rstrErrMsg);
			bool flag2 = false;
			dadbl3DArray[0] = 1E+20;
			dadbl3DArray[1] = 1E+20;
			dadbl3DArray[2] = 1E+20;
			AcadSysVar acadSysVar4 = mobjAcadSysVars.FriendGetItem("EXTMIN");
			rstrErrMsg = "";
			acadSysVar4.FriendSetAppDefault(dadbl3DArray, ref rstrErrMsg);
			object dvarAcadDateLocal2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadDate());
			object dvarAcadDateGlobal2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadDate(nvblnGlobal: true));
			dvarAcadDateLocal2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, Conversions.ToDecimal(dvarAcadDateLocal2), Conversions.ToDouble(dvarAcadDateLocal2)));
			dvarAcadDateGlobal2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, Conversions.ToDecimal(dvarAcadDateGlobal2), Conversions.ToDouble(dvarAcadDateGlobal2)));
			AcadSysVar acadSysVar5 = mobjAcadSysVars.FriendGetItem("TDCREATE");
			object objectValue = RuntimeHelpers.GetObjectValue(dvarAcadDateLocal2);
			rstrErrMsg = "";
			acadSysVar5.FriendSetAppDefault(objectValue, ref rstrErrMsg);
			AcadSysVar acadSysVar6 = mobjAcadSysVars.FriendGetItem("TDINDWG");
			object objectValue2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			rstrErrMsg = "";
			acadSysVar6.FriendSetAppDefault(objectValue2, ref rstrErrMsg);
			AcadSysVar acadSysVar7 = mobjAcadSysVars.FriendGetItem("TDUCREATE");
			object objectValue3 = RuntimeHelpers.GetObjectValue(dvarAcadDateGlobal2);
			rstrErrMsg = "";
			acadSysVar7.FriendSetAppDefault(objectValue3, ref rstrErrMsg);
			AcadSysVar acadSysVar8 = mobjAcadSysVars.FriendGetItem("TDUPDATE");
			object objectValue4 = RuntimeHelpers.GetObjectValue(dvarAcadDateLocal2);
			rstrErrMsg = "";
			acadSysVar8.FriendSetAppDefault(objectValue4, ref rstrErrMsg);
			AcadSysVar acadSysVar9 = mobjAcadSysVars.FriendGetItem("TDUSRTIMER");
			object objectValue5 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			rstrErrMsg = "";
			acadSysVar9.FriendSetAppDefault(objectValue5, ref rstrErrMsg);
			AcadSysVar acadSysVar10 = mobjAcadSysVars.FriendGetItem("TDUUPDATE");
			object objectValue6 = RuntimeHelpers.GetObjectValue(dvarAcadDateGlobal2);
			rstrErrMsg = "";
			acadSysVar10.FriendSetAppDefault(objectValue6, ref rstrErrMsg);
			AcadSysVar acadSysVar11 = mobjAcadSysVars.FriendGetItem("ACADVER");
			string vvarAppDefault2 = mstrAcadVer;
			rstrErrMsg = "";
			acadSysVar11.FriendSetAppDefault(vvarAppDefault2, ref rstrErrMsg);
			AcadSysVar acadSysVar12 = mobjAcadSysVars.FriendGetItem("AREA");
			object objectValue7 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			rstrErrMsg = "";
			acadSysVar12.FriendSetAppDefault(objectValue7, ref rstrErrMsg);
			AcadSysVar acadSysVar13 = mobjAcadSysVars.FriendGetItem("DISTANCE");
			object objectValue8 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			rstrErrMsg = "";
			acadSysVar13.FriendSetAppDefault(objectValue8, ref rstrErrMsg);
			AcadSysVar acadSysVar14 = mobjAcadSysVars.FriendGetItem("DWGNAME");
			string pstrName = hwpDxf_Vars.pstrName;
			rstrErrMsg = "";
			acadSysVar14.FriendSetAppDefault(pstrName, ref rstrErrMsg);
			AcadSysVar acadSysVar15 = mobjAcadSysVars.FriendGetItem("DWGPREFIX");
			string vvarAppDefault3 = hwpDxf_Vars.pstrAppPath + "\\";
			rstrErrMsg = "";
			acadSysVar15.FriendSetAppDefault(vvarAppDefault3, ref rstrErrMsg);
			AcadSysVar acadSysVar16 = mobjAcadSysVars.FriendGetItem("DWGTITLED");
			object objectValue9 = RuntimeHelpers.GetObjectValue(Interaction.IIf(hwpDxf_Vars.pblnDwgTitled, 1, 0));
			rstrErrMsg = "";
			acadSysVar16.FriendSetAppDefault(objectValue9, ref rstrErrMsg);
			AcadSysVar acadSysVar17 = mobjAcadSysVars.FriendGetItem("FULLOPEN");
			object objectValue10 = RuntimeHelpers.GetObjectValue(Interaction.IIf(hwpDxf_Vars.pblnFullOpen, 1, 0));
			rstrErrMsg = "";
			acadSysVar17.FriendSetAppDefault(objectValue10, ref rstrErrMsg);
			AcadSysVar acadSysVar18 = mobjAcadSysVars.FriendGetItem("MEASUREMENT");
			object objectValue11 = RuntimeHelpers.GetObjectValue(Application.FriendGetVariable("MEASUREINIT"));
			rstrErrMsg = "";
			acadSysVar18.FriendSetAppDefault(objectValue11, ref rstrErrMsg);
			AcadSysVar acadSysVar19 = mobjAcadSysVars.FriendGetItem("PERIMETER");
			object objectValue12 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			rstrErrMsg = "";
			acadSysVar19.FriendSetAppDefault(objectValue12, ref rstrErrMsg);
		}

		private void InternSetTableVarsByDefault()
		{
			AcadDimStyle dobjAcadDimStyle2;
			AcadDimStyles dobjAcadDimStyles2;
			if (!hwpDxf_Vars.pblnReadDocument && mobjAcadDatabase != null)
			{
				dobjAcadDimStyles2 = mobjAcadDatabase.DimStyles;
				if (dobjAcadDimStyles2.Count > 0)
				{
					dobjAcadDimStyle2 = (AcadDimStyle)dobjAcadDimStyles2.FriendGetItem(1);
					if (dobjAcadDimStyle2 != null)
					{
						AcadSysVar acadSysVar = mobjAcadSysVars.FriendGetItem("DIMSTYLE");
						string name = dobjAcadDimStyle2.Name;
						string rstrErrMsg = "";
						acadSysVar.FriendSetAppDefault(name, ref rstrErrMsg);
					}
				}
			}
			dobjAcadDimStyle2 = null;
			dobjAcadDimStyles2 = null;
		}

		private bool InternWriteFile(string vstrFileName, ref AcadDocument robjAcadDocument, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			DXFLib.DXF.File dobjDXFFile3 = new DXFLib.DXF.File();
			dobjDXFFile3.Init(ref robjAcadDocument);
			dobjDXFFile3.ListFile();
			bool InternWriteFile = default(bool);
			if (!dobjDXFFile3.WriteFile(vstrFileName, ref nrstrErrMsg))
			{
				dobjDXFFile3.FriendQuit();
				dobjDXFFile3 = null;
			}
			else
			{
				InternWriteFile = true;
				dobjDXFFile3.FriendQuit();
				dobjDXFFile3 = null;
			}
			return InternWriteFile;
		}
	}
}
