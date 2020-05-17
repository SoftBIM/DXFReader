using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadSysVar : NodeObject
	{
		public delegate void StartChangeEventHandler(object vvarNewValue, ref bool rblnCancel);

		public delegate void EndChangeEventHandler(object vvarNewValue);

		private const string cstrClassName = "AcadSysVar";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private hwpDxf_Enums.UNITS_BASE mnumUnitsBase;

		private hwpDxf_Enums.UNITS_METRIC mnumUnitsMetric;

		private hwpDxf_Enums.UNITS_BRITISCH mnumUnitsBritish;

		private object mdecUnitsInvFac;

		private double mdblUnitsInvFac;

		private object mvarAppDefault;

		private string mstrAppDefaultString;

		private object mvarValue;

		private string mstrValueString;

		private SysVar mobjSysVar;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private StartChangeEventHandler StartChangeEvent;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private EndChangeEventHandler EndChangeEvent;

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
			}
		}

		internal string FriendGetAppDefaultString => mstrAppDefaultString;

		internal object FriendGetBitValueString => RuntimeHelpers.GetObjectValue(mobjSysVar.FriendGetBitValueString);

		internal string FriendGetDefaultString => mobjSysVar.FriendGetDefaultString;

		internal string FriendGetHeaderCodeString => mobjSysVar.FriendGetHeaderCodeString;

		internal string FriendGetHeaderPosString => mobjSysVar.FriendGetHeaderPosString;

		internal string FriendGetLstValuesString => mobjSysVar.FriendGetLstValuesString;

		internal object FriendGetMaxValueString => RuntimeHelpers.GetObjectValue(mobjSysVar.FriendGetMaxValueString);

		internal string FriendGetMinValueString => mobjSysVar.FriendGetMinValueString;

		internal string FriendGetPrefTabName => mobjSysVar.FriendGetPrefTabName;

		internal string FriendGetRefTypeName => mobjSysVar.FriendGetRefTypeName;

		internal bool FriendGetRunTimeErr => mobjSysVar.FriendGetRunTimeErr;

		internal string FriendGetSaveTypeName => mobjSysVar.FriendGetSaveTypeName;

		internal string FriendGetSymTableName => mobjSysVar.FriendGetSymTableName;

		internal string FriendGetValueString
		{
			get
			{
				InternCheckCurrentValue();
				return mstrValueString;
			}
		}

		internal string FriendGetVarTypeName => mobjSysVar.FriendGetVarTypeName;

		internal int UnitsBase => (int)mnumUnitsBase;

		internal int UnitsBritish => (int)mnumUnitsBritish;

		internal int UnitsMetric => (int)mnumUnitsMetric;

		internal string FriendGetArraySize
		{
			get
			{
				if (mobjSysVar.ArraySize == null)
				{
					return "-";
				}
				return Conversions.ToString(mobjSysVar.ArraySize);
			}
		}

		internal string FriendGetEmptyValue
		{
			get
			{
				if (mobjSysVar.EmptyValue == null)
				{
					return null;
				}
				return Conversions.ToString(mobjSysVar.EmptyValue);
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
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

		public object AppDefault => RuntimeHelpers.GetObjectValue(mvarAppDefault);

		public object ArraySize => RuntimeHelpers.GetObjectValue(mobjSysVar.ArraySize);

		public object BitValue => RuntimeHelpers.GetObjectValue(mobjSysVar.BitValue);

		public object Default_Renamed => RuntimeHelpers.GetObjectValue(mobjSysVar.Default_Renamed);

		public bool DefaultByInit => mobjSysVar.DefaultByInit;

		public string Description => mobjSysVar.Description;

		public object EmptyValue => RuntimeHelpers.GetObjectValue(mobjSysVar.EmptyValue);

		public object HeaderCode => RuntimeHelpers.GetObjectValue(mobjSysVar.HeaderCode);

		public object HeaderPos => RuntimeHelpers.GetObjectValue(mobjSysVar.HeaderPos);

		public bool IsBoolean => mobjSysVar.IsBoolean;

		public bool IsColor => mobjSysVar.IsColor;

		public bool IsDimValue => mobjSysVar.IsDimValue;

		public bool IsUnitsBase => mobjSysVar.IsUnitsBase;

		public object LstValues => RuntimeHelpers.GetObjectValue(mobjSysVar.LstValues);

		public object MaxValue => RuntimeHelpers.GetObjectValue(mobjSysVar.MaxValue);

		public object MinValue => RuntimeHelpers.GetObjectValue(mobjSysVar.MinValue);

		public string Name
		{
			get
			{
				if (mobjSysVar == null)
				{
					return null;
				}
				return mobjSysVar.Name;
			}
		}

		public int PrefTab => mobjSysVar.PrefTab;

		public int RefType => mobjSysVar.RefType;

		public bool ReadOnly_Renamed => mobjSysVar.ReadOnly_Renamed;

		public int SaveType => mobjSysVar.SaveType;

		public int SymTable => mobjSysVar.SymTable;

		public bool UnitsRef => mobjSysVar.UnitsRef;

		public object Value
		{
			get
			{
				InternCheckCurrentValue();
				return RuntimeHelpers.GetObjectValue(mvarValue);
			}
		}

		public VariantType VarType_Renamed => mobjSysVar.VarType_Renamed;

		public string DwgStartAcadVer => mobjSysVar.DwgStartAcadVer;

		public string DwgEndAcadVer => mobjSysVar.DwgEndAcadVer;

		public string DxfStartAcadVer => mobjSysVar.DxfStartAcadVer;

		public string DxfEndAcadVer => mobjSysVar.DxfEndAcadVer;

		public event StartChangeEventHandler StartChange
		{
			[CompilerGenerated]
			add
			{
				StartChangeEventHandler startChangeEventHandler = StartChangeEvent;
				StartChangeEventHandler startChangeEventHandler2;
				do
				{
					startChangeEventHandler2 = startChangeEventHandler;
					StartChangeEventHandler value2 = (StartChangeEventHandler)Delegate.Combine(startChangeEventHandler2, value);
					startChangeEventHandler = Interlocked.CompareExchange(ref StartChangeEvent, value2, startChangeEventHandler2);
				}
				while ((object)startChangeEventHandler != startChangeEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				StartChangeEventHandler startChangeEventHandler = StartChangeEvent;
				StartChangeEventHandler startChangeEventHandler2;
				do
				{
					startChangeEventHandler2 = startChangeEventHandler;
					StartChangeEventHandler value2 = (StartChangeEventHandler)Delegate.Remove(startChangeEventHandler2, value);
					startChangeEventHandler = Interlocked.CompareExchange(ref StartChangeEvent, value2, startChangeEventHandler2);
				}
				while ((object)startChangeEventHandler != startChangeEventHandler2);
			}
		}

		public event EndChangeEventHandler EndChange
		{
			[CompilerGenerated]
			add
			{
				EndChangeEventHandler endChangeEventHandler = EndChangeEvent;
				EndChangeEventHandler endChangeEventHandler2;
				do
				{
					endChangeEventHandler2 = endChangeEventHandler;
					EndChangeEventHandler value2 = (EndChangeEventHandler)Delegate.Combine(endChangeEventHandler2, value);
					endChangeEventHandler = Interlocked.CompareExchange(ref EndChangeEvent, value2, endChangeEventHandler2);
				}
				while ((object)endChangeEventHandler != endChangeEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EndChangeEventHandler endChangeEventHandler = EndChangeEvent;
				EndChangeEventHandler endChangeEventHandler2;
				do
				{
					endChangeEventHandler2 = endChangeEventHandler;
					EndChangeEventHandler value2 = (EndChangeEventHandler)Delegate.Remove(endChangeEventHandler2, value);
					endChangeEventHandler = Interlocked.CompareExchange(ref EndChangeEvent, value2, endChangeEventHandler2);
				}
				while ((object)endChangeEventHandler != endChangeEventHandler2);
			}
		}

		internal void RaiseEventStartChange(object vvarNewValue, ref bool rblnCancel)
		{
			StartChangeEvent?.Invoke(RuntimeHelpers.GetObjectValue(vvarNewValue), ref rblnCancel);
		}

		internal void RaiseEventEndChange(object vvarNewValue)
		{
			Application.RaiseEventSysVarChanged(Name, RuntimeHelpers.GetObjectValue(vvarNewValue));
			EndChangeEvent?.Invoke(RuntimeHelpers.GetObjectValue(vvarNewValue));
		}

		public AcadSysVar()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 113;
			base.FriendLetNodeImageDisabledID = 114;
			base.FriendLetNodeName = "Systemvariable";
			base.FriendLetNodeText = "Systemvariable";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mvarValue = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pvarValue);
			mstrValueString = hwpDxf_Vars.pstrValueString;
			mvarAppDefault = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pvarAppDefault);
			mstrAppDefaultString = hwpDxf_Vars.pstrAppDefaultString;
			mnumUnitsBase = (hwpDxf_Enums.UNITS_BASE)hwpDxf_ConstMisc.pcnumUnitsBase;
			mnumUnitsMetric = (hwpDxf_Enums.UNITS_METRIC)hwpDxf_ConstMisc.pcnumUnitsMetric;
			mnumUnitsBritish = (hwpDxf_Enums.UNITS_BRITISCH)hwpDxf_ConstMisc.pcnumUnitsBritish;
			object dvarUnitsInvFac = RuntimeHelpers.GetObjectValue(hwpDxf_Unit.BkDXFUnit_ScaleInvFac((hwpDxf_Enums.UNITS_BASE)hwpDxf_ConstMisc.pcnumUnitsBase, hwpDxf_Enums.UNITS_METRIC.unmMeter, (hwpDxf_Enums.UNITS_METRIC)hwpDxf_ConstMisc.pcnumUnitsMetric, hwpDxf_Enums.UNITS_BRITISCH.unbInch, (hwpDxf_Enums.UNITS_BRITISCH)hwpDxf_ConstMisc.pcnumUnitsBritish));
			bool flag = false;
			mdblUnitsInvFac = Conversions.ToDouble(dvarUnitsInvFac);
		}

		~AcadSysVar()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjSysVar.FriendQuit();
				base.FriendQuit();
				mobjSysVar = null;
				mblnOpened = false;
			}
		}

		internal void FriendSetValueSilent(object value)
		{
			mvarValue = RuntimeHelpers.GetObjectValue(value);
		}

		internal void FriendInit(ref SysVar robjSysVar)
		{
			mobjSysVar = robjSysVar;
			base.FriendLetNodeText = mobjSysVar.Name;
			mvarValue = RuntimeHelpers.GetObjectValue(mobjSysVar.Default_Renamed);
			mstrValueString = mobjSysVar.FriendGetDefaultString;
		}

		internal bool FriendCheckType(object vvarValue, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			return mobjSysVar.FriendCheckType(RuntimeHelpers.GetObjectValue(vvarValue), ref nrstrErrMsg);
		}

		internal bool FriendCheckValue(object vvarValue, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			AcadTable dobjAcadTable2 = InternGetTable();
			bool FriendCheckValue = mobjSysVar.FriendCheckValue(RuntimeHelpers.GetObjectValue(vvarValue), dobjAcadTable2, ref nrstrErrMsg);
			dobjAcadTable2 = null;
			return FriendCheckValue;
		}

		internal object FriendConvertValue(object vvarValue)
		{
			return RuntimeHelpers.GetObjectValue(mobjSysVar.FriendConvertValue(RuntimeHelpers.GetObjectValue(vvarValue)));
		}

		internal bool FriendSetValue(object vvarValue, bool vblnRaiseEvent = true, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			bool FriendSetValue = default(bool);
			AcadTable dobjAcadTable2;
			if (mobjSysVar.FriendCheckType(RuntimeHelpers.GetObjectValue(vvarValue), ref nrstrErrMsg))
			{
				vvarValue = RuntimeHelpers.GetObjectValue(mobjSysVar.FriendConvertValue(RuntimeHelpers.GetObjectValue(vvarValue)));
				dobjAcadTable2 = InternGetTable();
				if (mobjSysVar.FriendCheckValue(RuntimeHelpers.GetObjectValue(vvarValue), dobjAcadTable2, ref nrstrErrMsg))
				{
					bool dblnChanged = default(bool);
					if (mvarValue == null)
					{
						dblnChanged = true;
					}
					else if ((VariantType.Array & VarType_Renamed) == VariantType.Array)
					{
						int num = Information.LBound((Array)mvarValue);
						int num2 = Information.UBound((Array)mvarValue);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
						{
							if (!dblnChanged)
							{
								dblnChanged = Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarValue, new object[1]
								{
								dlngIdx
								}, null), NewLateBinding.LateIndexGet(vvarValue, new object[1]
								{
								dlngIdx
								}, null), TextCompare: false);
							}
						}
					}
					else
					{
						dblnChanged = Operators.ConditionalCompareObjectNotEqual(mvarValue, vvarValue, TextCompare: false);
					}
					if (!dblnChanged)
					{
						FriendSetValue = true;
					}
					else
					{
						string name = Name;
						bool dblnError = default(bool);
						if (Operators.CompareString(name, "SDI", TextCompare: false) == 0 && Operators.ConditionalCompareObjectEqual(vvarValue, 1, TextCompare: false) && Application.Documents.Count > 1)
						{
							nrstrErrMsg = "Die SDI-Variable kann nur zurückgesetzt werden, wenn nicht mehr als eine Zeichnung geöffnet ist.";
							dblnError = true;
						}
						if (!dblnError)
						{
							bool dblnCancel = default(bool);
							if (vblnRaiseEvent)
							{
								RaiseEventStartChange(RuntimeHelpers.GetObjectValue(vvarValue), ref dblnCancel);
							}
							if (dblnCancel)
							{
								nrstrErrMsg = "Interner Abbruch beim Setzen der Systemvariable.";
							}
							else
							{
								mvarValue = RuntimeHelpers.GetObjectValue(vvarValue);
								mstrValueString = Conversions.ToString(mobjSysVar.FriendStringValue(RuntimeHelpers.GetObjectValue(vvarValue)));
								FriendSetValue = true;
								if (vblnRaiseEvent)
								{
									RaiseEventEndChange(RuntimeHelpers.GetObjectValue(vvarValue));
								}
							}
						}
					}
				}
			}
			dobjAcadTable2 = null;
			return FriendSetValue;
		}

		internal bool FriendSetAppDefault(object vvarAppDefault, ref string rstrErrMsg = "")
		{
			rstrErrMsg = null;
			bool FriendSetAppDefault = default(bool);
			AcadTable dobjAcadTable2;
			if (mobjSysVar.DefaultByInit)
			{
				rstrErrMsg = "Für die Systemvariable existiert bereits ein Vorgabewert.";
			}
			else if (mobjSysVar.FriendCheckType(RuntimeHelpers.GetObjectValue(vvarAppDefault), ref rstrErrMsg))
			{
				vvarAppDefault = RuntimeHelpers.GetObjectValue(mobjSysVar.FriendConvertValue(RuntimeHelpers.GetObjectValue(vvarAppDefault)));
				dobjAcadTable2 = InternGetTable();
				if (mobjSysVar.FriendCheckValue(RuntimeHelpers.GetObjectValue(vvarAppDefault), dobjAcadTable2, ref rstrErrMsg))
				{
					mvarAppDefault = RuntimeHelpers.GetObjectValue(vvarAppDefault);
					mstrAppDefaultString = Conversions.ToString(mobjSysVar.FriendStringValue(RuntimeHelpers.GetObjectValue(vvarAppDefault)));
					mvarValue = RuntimeHelpers.GetObjectValue(mvarAppDefault);
					mstrValueString = mstrAppDefaultString;
					FriendSetAppDefault = true;
				}
			}
			dobjAcadTable2 = null;
			return FriendSetAppDefault;
		}

		public void ResetDefault()
		{
			object dvarValue;
			string dstrValueString;
			if (mvarAppDefault != null)
			{
				dvarValue = RuntimeHelpers.GetObjectValue(mvarAppDefault);
				dstrValueString = mstrAppDefaultString;
			}
			else if (mobjSysVar.DefaultByInit)
			{
				dvarValue = RuntimeHelpers.GetObjectValue(mobjSysVar.Default_Renamed);
				dstrValueString = mobjSysVar.FriendGetDefaultString;
			}
			else
			{
				dvarValue = null;
				dstrValueString = "-";
			}
			bool dblnChanged = default(bool);
			if (dvarValue != null && !(mvarValue == null && dvarValue == null))
			{
				if (mvarValue == null != (dvarValue == null))
				{
					dblnChanged = true;
				}
				else if ((VariantType.Array & VarType_Renamed) == VariantType.Array)
				{
					int num = Information.LBound((Array)mvarValue);
					int num2 = Information.UBound((Array)mvarValue);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						if (!dblnChanged)
						{
							dblnChanged = Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarValue, new object[1]
							{
							dlngIdx
							}, null), NewLateBinding.LateIndexGet(dvarValue, new object[1]
							{
							dlngIdx
							}, null), TextCompare: false);
						}
					}
				}
				else
				{
					dblnChanged = Operators.ConditionalCompareObjectNotEqual(mvarValue, dvarValue, TextCompare: false);
				}
			}
			if (dblnChanged)
			{
				bool dblnCancel = default(bool);
				RaiseEventStartChange(RuntimeHelpers.GetObjectValue(dvarValue), ref dblnCancel);
				if (!dblnCancel)
				{
					mvarValue = RuntimeHelpers.GetObjectValue(dvarValue);
					mstrValueString = dstrValueString;
					RaiseEventEndChange(RuntimeHelpers.GetObjectValue(dvarValue));
				}
			}
		}

		public object GetDefault()
		{
			if (mvarAppDefault != null)
			{
				return RuntimeHelpers.GetObjectValue(mvarAppDefault);
			}
			if (mobjSysVar.DefaultByInit)
			{
				return RuntimeHelpers.GetObjectValue(mobjSysVar.Default_Renamed);
			}
			return null;
		}

		private AcadTable InternGetTable()
		{
			AcadTable dobjAcadTable2 = default(AcadTable);
			if (FriendGetDocumentIndex > -1)
			{
				switch (SymTable)
				{
					case 2:
						dobjAcadTable2 = Document.Blocks;
						break;
					case 7:
						dobjAcadTable2 = Document.UserCoordinateSystems;
						break;
					case 6:
						dobjAcadTable2 = Document.TextStyles;
						break;
					case 5:
						dobjAcadTable2 = Document.Linetypes;
						break;
					case 4:
						dobjAcadTable2 = Document.Layers;
						break;
					case 3:
						dobjAcadTable2 = Document.DimStyles;
						break;
					case 9:
						dobjAcadTable2 = Document.Viewports;
						break;
					case 1:
						dobjAcadTable2 = Document.RegisteredApplications;
						break;
					case 8:
						dobjAcadTable2 = Document.Views;
						break;
				}
			}
			AcadTable InternGetTable = dobjAcadTable2;
			dobjAcadTable2 = null;
			return InternGetTable;
		}

		private void InternCheckCurrentValue()
		{
			switch (Name)
			{
				case "CDATE":
					mvarValue = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadCDate());
					mstrValueString = Conversions.ToString(mobjSysVar.FriendStringValue(RuntimeHelpers.GetObjectValue(mvarValue)));
					break;
				case "DATE":
					mvarValue = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilTime.NowAcadDate());
					mstrValueString = Conversions.ToString(mobjSysVar.FriendStringValue(RuntimeHelpers.GetObjectValue(mvarValue)));
					break;
				case "HANDSEED":
					mvarValue = hwpDxf_Functions.BkDXF_DblToHex(Document.FriendGetMaxObjectID);
					mstrValueString = Conversions.ToString(mobjSysVar.FriendStringValue(RuntimeHelpers.GetObjectValue(mvarValue)));
					break;
			}
		}
	}
}
