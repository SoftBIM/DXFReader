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
    public class SysVars
	{
		private const string cstrClassName = "SysVars";

		private bool mblnOpened;

		private object mvarDimBlkArray;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictHeaderPos;

		public int Count => mcolClass.Count;

		public SysVar this[object vvarIdxKey]
		{
			get
			{
				if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIdxKey)) == VariantType.String)
				{
					return (SysVar)mcolClass[Strings.UCase(Conversions.ToString(vvarIdxKey))];
				}
				return (SysVar)mcolClass[checked(Conversions.ToInteger(vvarIdxKey) - 1)];
			}
		}

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
			mvarDimBlkArray = new object[20]
			{
			"",
			"Dot",
			"DotSmall",
			"DotBlank",
			"Origin",
			"Origin2",
			"Open",
			"Open90",
			"Open30",
			"Closed",
			"Small",
			"None",
			"Oblique",
			"BoxFilled",
			"BoxBlank",
			"ClosedBlank",
			"DatumFilled",
			"DatumBlank",
			"Integral",
			"ArchTick"
			};
			mcolClass = new OrderedDictionary();
			SysVarsAddNoneRO();
			SysVarsAddNoneUnitRO();
			SysVarsAddNoneStd();
			SysVarsAddNoneUnit();
			SysVarsAddRegOptionsRO();
			SysVarsAddRegOptionsStd();
			SysVarsAddRegOptionsUnit();
			SysVarsAddRegRO();
			SysVarsAddRegStd();
			SysVarsAddRegDwg();
			SysVarsAddRegUnit();
			SysVarsAddDwgOptionsStd();
			SysVarsAddDwgRO();
			SysVarsAddDwgStd();
			SysVarsAddDwgUnit();
			SysVarsAddDwgDimRO();
			SysVarsAddDwgDimStd();
			SysVarsAddDwgDimUnit();
			SysVarsAddVPortRO();
			SysVarsAddVPortStd();
			SysVarsAddVPortUnit();
			SysVarsAddDXFAppStd();
			SysVarsAddDXFDwgRO();
			SysVarsAddDXFDwgStd();
			SysVarsAddDXFVportRO();
			SysVarsAddDXFVportUnit();
		}

		public SysVars()
		{
			mobjDictHeaderPos = new Dictionary<object, object>();
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SysVars()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "SysVars");
				mcolClass = null;
				mobjDictHeaderPos = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			SysVar dobjSysVar2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjSysVar2 = (SysVar)enumerator.Current;
					mcolClass.Remove(Strings.UCase(dobjSysVar2.Name));
					dobjSysVar2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjSysVar2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		private void SysVarsAddNoneRO()
		{
			InternAddString("ACADVER", "Speichert die AutoCAD-Versionsnummer.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 1, 1, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DBMOD", "Gibt den Änderungszustand der Zeichnung mit Hilfe eines Bitcodes an.", VariantType.Short, null, vblnReadOnly: true, 0, 0, null, null, 29, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("DWGNAME", "Nimmt den vom Benutzer eingegebenen Zeichnungsnamen auf.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("DWGPREFIX", "Nimmt das Laufwerk-/Verzeichnis-Präfix für die Zeichnung auf.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DWGTITLED", "Zeigt an, ob der aktuellen Zeichnung ein Name zugeordnet wurde.", VariantType.Short, null, vblnReadOnly: true, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "FULLOPEN", "Zeigt an, ob die aktuelle Zeichnung teilweise geöffnet wurde.", VariantType.Short, null, vblnReadOnly: true, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("REFEDITNAME", "Zeigt an, ob die Referenzen einer Zeichnung gerade bearbeitet werden, und speichert den Dateinamen der Referenz.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("SAVENAME", "Enthält den Dateinamen und den Verzeichnispfad der aktuellen Zeichnung (nach dem Speichern).", vblnReadOnly: true, hwpDxf_Vars.pstrSaveName, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag = false;
			InternAddArrayDbl(vblnUnitsRef: false, "SCREENSIZE", "Speichert die Größe des aktuellen Ansichtsfensters in Pixeln (X und Y).", 2, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UNDOCTL", "Speichert einen Bitcode, der den Status für die Optionen Auto und Steuern des Befehls ZURÜCK anzeigt.", VariantType.Short, null, vblnReadOnly: true, 5, 0, null, null, 15, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UNDOMARKS", "Speichert die Anzahl der Markierungen, die in der Steuerfolge des Befehls ZURÜCK durch die Option Markierung abgelegt wurden.", VariantType.Short, null, vblnReadOnly: true, 0, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "WORLDUCS", "Gibt an, ob das BKS mit dem WKS übereinstimmt.", VariantType.Short, null, vblnReadOnly: true, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "WRITESTAT", "Zeigt an, ob eine Zeichnungsdatei schreibgeschützt ist oder nicht. Für Entwickler, die den Schreibstatus über AutoLISP ermitteln möchten.", VariantType.Short, null, vblnReadOnly: true, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("_LINFO", "Undokumentiert", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("_PKSER", "Undokumentiert", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "_SERVER", "Undokumentiert", VariantType.Short, null, vblnReadOnly: true, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("_VERNUM", "Undokumentiert", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("ACADPREFIX", "Speichert den Verzeichnispfad (falls vorhanden), der durch die Umgebungsvariable ACAD bestimmt wird; gegebenenfalls werden Pfadtrennzeichen verwendet.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ADCSTATE", "Undokumentiert", VariantType.Short, null, vblnReadOnly: true, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: false, "CDATE", "Setzt das Kalenderdatum und die Zeit (Lokale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CMDACTIVE", "Speichert den Bitcode, der anzeigt, ob ein normaler Befehl, ein transparenter Befehl, ein Skript oder ein Dialogfeld aktiv ist.", VariantType.Short, null, vblnReadOnly: true, null, 0, null, null, 31, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("CMDNAMES", "Zeigt den Namen der aktiven und transparenten Befehle an.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: false, "CPUTICKS", "Undokumentiert", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag4 = false;
			InternAdd(vblnUnitsRef: false, "DATE", "Speichert Datum und Uhrzeit (Lokale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DBCSTATE", "Undokumentiert", VariantType.Short, null, vblnReadOnly: true, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIASTAT", "Speichert die Methode, die beim Verlassen des zuletzt benutzten Dialogfelds verwendet wurde.", VariantType.Short, null, vblnReadOnly: true, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("LASTPROMPT", "Speichert die letzte in der Befehlszeile zurückgegebene Zeichenfolge.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("LOCALE", "Zeigt den ISO-Sprachcode des aktuell verwendeten AutoCAD-Release an.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("LOGINNAME", "Zeigt den Benutzernamen so an, wie er beim Laden von AutoCAD konfiguriert oder eingegeben wurde.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag5 = false;
			InternAdd(vblnUnitsRef: false, "MILLISECS", "Undokumentiert", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OPMSTATE", "Undokumentiert", VariantType.Short, null, vblnReadOnly: true, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PFACEVMAX", "Bestimmt die maximale Anzahl von Scheitelpunkten pro Fläche.", VariantType.Short, null, vblnReadOnly: true, 4, 3, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("PLATFORM", "Zeigt an, welche AutoCAD-Plattform verwendet wird.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "POPUPS", "Zeigt den Status des aktuell konfigurierten Bildschirmtreibers an.", VariantType.Short, null, vblnReadOnly: true, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("PRODUCT", "Gibt den Produktnamen zurück.", vblnReadOnly: true, "AutoCAD", null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("PROGRAM", "Gibt den Programmnamen zurück.", vblnReadOnly: true, "acad", null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SCREENBOXES", "Speichert die Anzahl der Felder im Bildschirmmenü des Zeichenbereichs.", VariantType.Short, null, vblnReadOnly: true, null, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SCREENMODE", "Speichert einen Bitcode, der den Grafik-/Text-Status des AutoCAD-Bildschirms bestimmt.", VariantType.Short, null, vblnReadOnly: true, null, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("SYSCODEPAGE", "Zeigt die System-Zeichenumsetzungstabelle aus der Datei acad.xmf an.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddNoneUnitRO()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: true, "AREA", "Speichert die Fläche, die zuletzt mit dem Befehl FLÄCHE, LISTE oder DBLISTE berechnet wurde.", VariantType.Double, null, vblnReadOnly: true, null, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: true, "DISTANCE", "Speichert den vom Befehl ABSTAND errechneten Abstand.", VariantType.Double, null, vblnReadOnly: true, null, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: true, "LASTANGLE", "Speichert den Endwinkel des zuletzt eingegebenen Bogens.", VariantType.Double, null, vblnReadOnly: true, 0.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag4 = false;
			InternAdd(vblnUnitsRef: true, "PERIMETER", "Speichert den Umfang, der zuletzt mit dem Befehl FLÄCHE, LISTE oder DBLISTE berechnet wurde.", VariantType.Double, null, vblnReadOnly: true, null, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddNoneStd()
		{
			InternAdd(vblnUnitsRef: false, "BINDTYPE", "Steuert die Behandlung von XRef-Namen beim Zuordnen von XRefs sowie beim direkten Bearbeiten von XRefs.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "COMPASS", "Legt fest, ob der 3D-Kompaß im aktuellen Ansichtsfenster aktiviert oder deaktiviert ist.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CMDECHO", "Legt fest, ob AutoCAD während der Ausführung der AutoLISP-Funktion (command) Eingabeaufforderungen und Eingaben protokolliert.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HPDOUBLE", "Bestimmt die Verdoppelung von Schraffurmustern bei benutzerdefinierten Mustern.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("HPNAME", "Legt einen Vorgabenamen für das Schraffurmuster fest.", vblnReadOnly: false, "ANSI31", null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("INSNAME", "Legt einen Vorgabe-Blocknamen für den Befehl EINFÜGE fest.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symBlock, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "PHANDLE", "Undokumentiert", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 4294967295.0, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "POLYSIDES", "Bestimmt die vorgegebene Anzahl der Seiten für den Befehl POLYGON.", VariantType.Short, null, vblnReadOnly: false, 4, 3, 1024, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("SHPNAME", "Bestimmt den vorgegebenen Symbolnamen.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TABMODE", "Steuert die Verwendung des Tabletts.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TEXTQLTY", "Steuert die Auflösung für die Tesselation von Textumrissen für TrueType-Schriften bei der Plotausgabe, beim Export mit dem Befehl PSOUT und beim Rendern.", VariantType.Short, null, vblnReadOnly: false, 50, 0, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TSPACETYPE", "Steuert den Typ des Zeilenabstands für Absatztext.", VariantType.Short, null, vblnReadOnly: false, 1, 1, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			int dlngIdx = 1;
			do
			{
				InternAddString("USERS" + Conversions.ToString(dlngIdx), "Dient zum Speichern und Abrufen von Textzeichenfolgen.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
				dlngIdx = checked(dlngIdx + 1);
			}
			while (dlngIdx <= 5);
			InternAdd(vblnUnitsRef: false, "WMFBKGND", "Steuert den Hintergrund und den Rahmen der ausgegebenen WMF-Datei aus dem Befehl WMFOUT.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "USEACIS", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ACISOUTVER", "Steuert die ACIS-Version von SAT-Dateien, die mit dem Befehl ACISOUT erstellt wurden.", VariantType.Short, null, vblnReadOnly: false, 40, null, null, new object[8]
			{
			15,
			16,
			17,
			18,
			20,
			21,
			30,
			40
			}, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "AFLAGS", "Setzt Attributflags für Bitcode aus ATTDEF.", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 15, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CHAMMODE", "Setzt die Eingabemethode, mit der AutoCAD Fasen erstellt.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ERRNO", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "EXPERT", "Steuert, ob bestimmte Eingabeaufforderungen ausgegeben werden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 5, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "EXPLMODE", "Steuert, ob der Befehl URSPRUNG uneinheitlich skalierte (NUS-) Blöcke unterstützt.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "FACETRATIO", "Steuert das Seitenverhältnis bei Facetten für zylindrische und konische ACIS-Objekte.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HIDEPRECISION", "Steuert die Genauigkeit beim Verdecken und Schattieren.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HIGHLIGHT", "Steuert die Hervorhebung von Objekten; mit Griffen ausgewählte Objekte werden hiervon nicht beeinflußt.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HPBOUND", "Steuert den Objekttyp, der mit den Befehlen GSCHRAFFUR und UMGRENZUNG erstellt wird.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MENUECHO", "Setzt Steuerbits für Menürückmeldungen und Eingabeaufforderungen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 15, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("MODEMACRO", "Zeigt in der Statuszeile eine Zeichenfolge an.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "NOMUTT", "Unterdrückt die Anzeige von Meldungen, wenn die Meldungen ansonsten nicht unterdrückt würden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "RE-INIT", "Initialisiert das Digitalisiergerät, den Anschluß des Digitalisiergeräts und die Datei acad.pgp neu.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 21, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SOLIDCHECK", "Aktiviert und deaktiviert die Prüfung der Volumenkörper für die aktuelle AutoCAD-Sitzung.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TEXTEVAL", "Steuert die Auswertungsmethode von Zeichenfolgen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddNoneUnit()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: true, "CIRCLERAD", "Bestimmt den vorgegebenen Kreisradius.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: true, "DONUTID", "Bestimmt den Vorgabewert für den Innendurchmesser eines Ringes.", VariantType.Double, null, vblnReadOnly: false, 0.5, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: true, "DONUTOD", "Bestimmt den Vorgabewert für den Außendurchmesser eines Ringes.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag4 = false;
			InternAdd(vblnUnitsRef: true, "HPANG", "Bestimmt den Winkel des Schraffurmusters.", VariantType.Double, null, vblnReadOnly: false, 0.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag5 = false;
			InternAdd(vblnUnitsRef: true, "HPSCALE", "Legt den Skalierfaktor für das Schraffurmuster fest.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag6 = false;
			InternAdd(vblnUnitsRef: true, "HPSPACE", "Legt für benutzerdefinierte Schraffurmuster den Abstand der Schraffurlinien fest.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag7 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "LASTPOINT", "Speichert den zuletzt eingegebenen Punkt.", 3, vblnReadOnly: false, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag8 = false;
			InternAdd(vblnUnitsRef: true, "OFFSETDIST", "Bestimmt den Vorgabeabstand.", VariantType.Double, null, vblnReadOnly: false, 1.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag9 = false;
			InternAdd(vblnUnitsRef: true, "TSPACEFAC", "Steuert den Zeilenabstand für Absatztexte (relativ zur Texthöhe).", VariantType.Double, null, vblnReadOnly: false, 1.0, 0.25, 4.0, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag10 = false;
			InternAdd(vblnUnitsRef: true, "PSVPSCALE", "Legt den Anzeige-Skalierungsfaktor für die neu erstellten Ansichtsfenster fest.", VariantType.Double, null, vblnReadOnly: false, hwpDxf_Vars.pdblPSVPScale, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stNone, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 200, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddRegOptionsRO()
		{
			InternAddString("TEMPPREFIX", "Enthält den Namen des Verzeichnisses für temporäre Dateien.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("NODENAME", "Undokumentiert", vblnReadOnly: true, "ac$", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegOptionsStd()
		{
			InternAdd(vblnUnitsRef: false, "CURSORSIZE", "Bestimmt die Größe des Fadenkreuzes als Prozentsatz der Bildschirmgröße.", VariantType.Short, null, vblnReadOnly: false, 5, 1, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			short dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "IMAGEHLT", "Legt fest, ob das gesamte Rasterbild oder lediglich der Rahmen des Rasterbilds hervorgehoben werden soll.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false, nvblnInvers: true);
			InternAdd(vblnUnitsRef: false, "RTDISPLAY", "Steuert die Anzeige von Rasterbildern beim ZOOM und PAN in Echtzeit.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "XFADECTL", "Steuert die Ausblendintensität für direkt zu bearbeitende Referenzen.", VariantType.Short, null, vblnReadOnly: false, 50, 0, 90, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "APBOX", "Aktiviert oder deaktiviert die AutoSnap-Pickbox.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "APERTURE", "Bestimmt die Zielhöhe des Objektfangs in Pixeln.", VariantType.Short, null, vblnReadOnly: false, 10, 1, 50, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_DefaultAutosnap();
			InternAdd(vblnUnitsRef: false, "AUTOSNAP", "Steuert die Markierung, die QuickInfo und den Magneten von AutoSnap.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, null, null, 63, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_DefaultTrackpath();
			InternAdd(vblnUnitsRef: false, "TRACKPATH", "Steuert die Anzeige von Ausrichtungspfaden für Polarfang und Objektfangspuren.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("DCTCUST", "Zeigt den aktuellen Pfad und Dateinamen für das benutzerspezifische Wörterbuch an.", vblnReadOnly: false, "", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			object dvarValue = default(object);
			hwpDxf_Functions.BkDXF_MainDictionaries(ref dvarValue);
			InternAddString("DCTMAIN", "Zeigt den Dateinamen für das aktuelle Hauptwörterbuch an.", vblnReadOnly: false, null, RuntimeHelpers.GetObjectValue(dvarValue), hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("FONTALT", "Bestimmt die Alternativschrift, die verwendet wird, wenn die angegebene Schriftart nicht gefunden werden kann.", vblnReadOnly: false, "simplex.shx", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("FONTMAP", "Bestimmt die Schriftzuordnungsdatei, die verwendet wird, wenn die angegebene Schrift nicht gefunden werden kann.", vblnReadOnly: false, "acad.fmp", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("INETLOCATION", "Speichert die Internet-Adresse aus dem Befehl BROWSER und dem Dialogfeld Im Internet suchen.", vblnReadOnly: false, "www.autodesk.com/acaduser", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("LOGFILEPATH", "Legt den Pfad der Protokolldateien für alle Zeichnungen in einer Sitzung fest.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("MTEXTED", "Legt den primären und sekundären Texteditor für Absatztextobjekte fest.", vblnReadOnly: false, "Intern", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("PSPROLOG", "Bestimmt einen Namen für einen Prologabschnitt, der mit dem Befehl PSOUT aus der Datei acad.psf eingelesen werden soll.", vblnReadOnly: false, "", null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("SAVEFILEPATH", "Bestimmt den Pfad für die Dateien aus der automatischen Speicherung für die AutoCAD-Sitzung.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("XLOADPATH", "Erzeugt einen Pfad für die Speicherung temporärer Kopien bedarfsweise geladener externer Referenzdateien.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptFiles, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DEMANDLOAD", "Legt fest, ob und wann AutoCAD bei Bedarf Anwendungen von Drittanbietern lädt, falls eine Zeichnung benutzerspezifische Objekte enthält, die mit dieser Anwendung erstellt wurden.", VariantType.Short, null, vblnReadOnly: false, 3, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "ISAVEBAK", "Beschleunigt besonders bei größeren Zeichnungen die Geschwindigkeit von inkrementellen Speichervorgängen.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ISAVEPERCENT", "Legt den Wert von nicht genutztem Platz fest, der in einer Zeichungsdatei toleriert wird.", VariantType.Short, null, vblnReadOnly: false, 50, 0, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "LOGFILEMODE", "Legt fest, ob die Inhalte des Textfensters in eine Protokolldatei kopiert werden sollen.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "PROXYNOTICE", "Zeigt eine Meldung an, wenn Sie eine Zeichnung öffnen, die ein benutzerdefiniertes Objekt enthält, welches von einer momentan nicht verfügbaren Anwendung erzeugt wurde.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PROXYSHOW", "Steuert die Anzeige von Proxy-Objekten in einer Zeichnung.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngProxyImage, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "RASTERPREVIEW", "Steuert, ob BMP-Voransichtsbilder mit der Zeichnung gespeichert werden.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SAVETIME", "Stellt das automatische Speicherintervall (in Minuten) ein.", VariantType.Short, null, vblnReadOnly: false, 120, 0, 600, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "XLOADCTL", "Aktiviert und deaktiviert das Laden nach Bedarf von externen Referenzen und steuert, ob die Originalzeichnung oder eine Kopie geöffnet werden soll.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngXRefDemandLoad, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DEFLPLSTYLE", "Legt den vorgegebenen Plotstil für neue Layer fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DEFPLSTYLE", "Legt den vorgegebenen Plotstil für neue Objekte fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OLEQUALITY", "Steuert die vorgegebene Qualität der eingebetteten OLE-Objekte.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngOLEQuality, 0, 4, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "PAPERUPDATE", "Steuert die Anzeige einer Warnung, wenn Sie versuchen, ein Layout nicht mit dem vorgegebenen Papierformat aus der Plotterkonfigurationsdatei zu drucken.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PSTYLEPOLICY", "Legt fest, ob die Farbeigenschaft eines Objekts mit dem Plotstil verbunden werden soll.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngPlotPolicy, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "GRIPBLOCK", "Steuert die Zuweisung von Griffen in Blöcken.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "GRIPCOLOR", "Steuert die Farbe von nichtgewählten Griffen (als Rechteckumrisse gezeichnet).", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngGripColorUnselected, 1, 255, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: true, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "GRIPHOT", "Steuert die Farbe von gewählten Griffen (als gefüllte Rechtecke gezeichnet).", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngGripColorSelected, 1, 255, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: true, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "GRIPS", "Steuert die Verwendung von Auswahlsatz-Griffen für die Modi Strecken, Verschieben, Drehen und Spiegeln.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "GRIPSIZE", "Gibt die Größe des Griffes in Pixel an.", VariantType.Short, null, vblnReadOnly: false, 3, 1, 255, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "PICKADD", "Legt fest, ob nachfolgende Auswahlvorgänge den aktuellen Auswahlsatz ersetzen oder zu ihm hinzugefügt werden.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "PICKAUTO", "Steuert die automatische Fenstertechnik bei der Eingabeaufforderung Objekte wählen.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PICKBOX", "Bestimmt die Zielhöhe der Objektwahl in Pixeln.", VariantType.Short, null, vblnReadOnly: false, 3, 0, 50, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "PICKDRAG", "Steuert die Methode, mit der ein Auswahlfenster gezeichnet wird.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "PICKFIRST", "Steuert, ob Objekte vor oder nach der Eingabe eines Befehls ausgewählt werden sollen.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: true);
			InternAdd(vblnUnitsRef: false, "PICKSTYLE", "Steuert den Gebrauch von Gruppenauswahl und assoziativer Schraffurauswahl.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSelection, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_BooleanToInteger(vblnValue: false);
			InternAdd(vblnUnitsRef: false, "ACADLSPASDOC", "Legt fest, ob AutoCAD die Datei acad.lsp in jede Zeichnung laden soll oder nur in die Zeichnung, die in einer AutoCAD-Sitzung jeweils zuerst geöffnet wird.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSystem, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SDI", "Legt fest, ob nur ein oder mehrere Dokumente gleichzeitig in AutoCAD geöffnet werden können.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptSystem, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OSNAPCOORD", "Steuert, ob in der Befehlszeile eingegebene Koordinaten fortlaufende Objektfangmodi überschreiben.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_ConstMisc.pclngKeyboardPriority, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			dintValue19 = hwpDxf_Functions.BkDXF_DefaultShortcutmenu();
			InternAdd(vblnUnitsRef: false, "SHORTCUTMENU", "Legt fest, ob die Kontextmenüs für Vorgabe-Modus, Bearbeiten-Modus und Befehl-Modus im Zeichenbereich zur Verfügung stehen.", VariantType.Short, null, vblnReadOnly: false, dintValue19, 0, null, null, 15, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegOptionsUnit()
		{
			InternAdd(vblnUnitsRef: false, "INSUNITSDEFSOURCE", "Legt den Einheitenwert für die Quellinhalte fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "INSUNITSDEFTARGET", "Legt den Einheitenwert für die Zielzeichnung fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegRO()
		{
			InternAddString("SAVEFILE", "Speichert den Namen der aktuellen automatischen Sicherungsdatei.", vblnReadOnly: true, hwpDxf_Vars.pstrSaveFile, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CPROFILE", "Speichert den Namen des aktuellen Profils.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("MENUNAME", "Speichert den Namen und den Pfad der Menüdatei.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegStd()
		{
			InternAdd(vblnUnitsRef: false, "AUXSTAT", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, -32768, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "ACGIDUMPMODE", "Undokumentiert", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 4294967295.0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ATTDIA", "Steuert, ob der Befehl EINFÜGE für die Eingabe von Attributwerten ein Dialogfeld verwendet.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ATTREQ", "Legt fest, ob beim Befehl EINFÜGE die vorgegebenen Attributeinstellungen für das Einfügen von Blöcken verwendet werden sollen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "AUDITCTL", "Legt fest, ob der Befehl PRÜFUNG einen Prüfbericht erstellt (ADT-Datei).", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "BLIPMODE", "Steuert die Sichtbarkeit von Markierungspunkten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CMDDIA", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "COORDS", "Steuert, wann Koordinaten in der Statuszeile aktualisiert werden.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DELOBJ", "Steuert, ob Objekte, die zur Erstellung weiterer Objekte verwendet werden, erhalten bleiben oder aus der Zeichnungsdatenbank gelöscht werden.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DRAGMODE", "Steuert die Anzeige von Objekten, die gezogen werden.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DRAGP1", "Setzt die Bildregenerationsrate für das Ziehen.", VariantType.Short, null, vblnReadOnly: false, 10, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DRAGP2", "Setzt hohe Bildregenerationsrate für das Ziehen.", VariantType.Short, null, vblnReadOnly: false, 25, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DWGCHECK", "Ermittelt, ob eine Zeichnung zuletzt mit einem anderen Programm bearbeitet wurde.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "EDGEMODE", "Legt fest, auf welche Weise die Befehle STUTZEN und DEHNEN die Schnitt- und Grenzkanten bestimmen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ENTEXTS", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "FILEDIA", "Unterdrückt die Anzeige der Datei-Dialogfelder.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: false, "FORCE_PAGING", "Undokumentiert", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 4294967295.0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "GLOBCHECK", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LAZYLOAD", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LISPINIT", "Wenn die Schnittstelle für einzelne Dokumente aktiviert ist, legt diese Variable fest, ob die AutoLISP-definierten Funktionen und Variablen beim Öffnen einer neuen Zeichnung beibehalten werden oder nur für die aktuelle Zeichensitzung gelten sollen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MACROTRACE", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MAXOBJMEM", "Undokumentiert", VariantType.Integer, null, vblnReadOnly: false, 0, 0, int.MaxValue, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MAXSORT", "Bestimmt die maximale Anzahl der Symbol- oder Blocknamen, die mit Listen-Befehlen sortiert werden.", VariantType.Short, null, vblnReadOnly: false, 200, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MBUTTONPAN", "Steuert das Verhalten der dritten Taste oder des Rades am Zeigegerät.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MENUCTL", "Steuert die Seitenumschaltung im Bildschirmmenü.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OFFSETGAPTYPE", "Steuert den Versatz einer Polylinie, wenn eine Lücke beim Versetzen der einzelnen Polyliniensegmente entstanden ist.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OLEHIDE", "Steuert die Anzeige von OLE-Objekten in AutoCAD.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OSMODE", "Bestimmt die Objektfangmodi anhand von Bitcodes.", VariantType.Short, null, vblnReadOnly: false, 4133, 0, null, null, 16383, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PLINETYPE", "Bestimmt, ob AutoCAD optimierte zweidimensionale Polylinien verwendet.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("PLOTID", "Veraltet", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PLOTTER", "Veraltet", VariantType.Short, null, vblnReadOnly: false, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PLQUIET", "Steuert die Anzeige optionaler Dialogfelder und nicht schwerwiegender Fehler für Stapelplotten und Skripten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAddString("POLARADDANG", "Enthält benutzerdefinierte Polarwinkel.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: false, "POLARANG", "Legt das Polarwinkelinkrement fest.", VariantType.Double, null, vblnReadOnly: false, 90.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "POLARMODE", "Steuert die Einstellungen für Polarfang und Objektfangspuren.", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 15, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PROJMODE", "Setzt den aktuellen Projektionsmodus für Operationen zum Stutzen oder Dehnen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PSQUALITY", "Steuert die Renderqualität von PostScript-Bildern.", VariantType.Short, null, vblnReadOnly: false, 75, -32768, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "QAFLAGS", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 255, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "QAUCSLOCK", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SNAPTYPE", "Setzt den Fangstil für das aktuelle Ansichtsfenster.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TEXTFILL", "Steuert das Ausfüllen von TrueType-Schriften bei der Plotausgabe, beim Export mit dem Befehl PSOUT und beim Rendern.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TOOLTIPS", "Steuert die Anzeige von QuickInfos.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TREEMAX", "Beschränkt den Speicherverbrauch während der Regeneration von Zeichnungen durch Beschränkung der Anzahl von Verzweigungsknoten im Raumindex (Octree).", VariantType.Integer, null, vblnReadOnly: false, 10000000, 0, int.MaxValue, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TRIMMODE", "Steuert, ob AutoCAD ausgewählte Kanten für Fasen und Abrundungen stutzt.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSAXISANG", "Speichert den vorgegebenen Winkel, wenn Sie das BKS mit der Option X, Y oder Z des Befehls BKS um eine der Achsen drehen.", VariantType.Short, null, vblnReadOnly: false, 90, null, null, new object[9]
			{
			5,
			10,
			15,
			18,
			22.5,
			30,
			45,
			90,
			180
			}, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSORTHO", "Bestimmt, ob die zugehörige Einstellung für das orthogonale BKS automatisch wiederhergestellt werden soll, wenn Sie eine orthogonale Ansicht wiederherstellen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSVIEW", "Bestimmt, ob das aktuelle BKS mit einem benannten Ausschnitt gespeichert werden soll.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "WHIPARC", "Legt fest, ob die Anzeige von Kreisen und Bogen geglättet werden soll.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "XREFCTL", "Controls whether AutoCAD writes external reference log (XLG) files.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ZOOMFACTOR", "Steuert die schrittweise Änderung beim Drehen des Rads (vorwärts und rückwärts).", VariantType.Short, null, vblnReadOnly: false, 10, 3, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegDwg()
		{
			InternAdd(vblnUnitsRef: false, "PLOTROTMODE", "Steuert die Ausrichtung von Plots.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddRegUnit()
		{
			InternAdd(vblnUnitsRef: false, "LWUNITS", "Steuert, ob die Einheiten für die Linienstärke in Zoll oder in Millimeter dargestellt werden.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: true, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MEASUREINIT", "Stellt die anfänglichen Zeichnungseinheiten auf Britisch oder Metrisch ein.", VariantType.Short, null, vblnReadOnly: false, hwpDxf_Vars.pnumUnitsBase, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: true, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "POLARDIST", "Legt den Fangwert fest, wenn die Systemvariable SNAPSTYL auf 1 gesetzt ist (Polarfang).", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stRegistry, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtApplication, "", "_", "", "_");
		}

		private void SysVarsAddDwgOptionsStd()
		{
			InternAdd(vblnUnitsRef: false, "DISPSILH", "Steuert im Drahtmodellmodus die Anzeige der Umrißkurven von Volumenkörpern.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 24, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "FACETRES", "Bewirkt eine Anpassung der Glätte von gerenderten und schattierten Objekten sowie von Objekten, bei denen ausgeblendete Linien entfernt wurden.", VariantType.Double, null, vblnReadOnly: false, 0.5, 0.01, 10.0, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "FILLMODE", "Legt fest, ob Multilinien, Bänder, Volumenkörper, Schraffuren (auch Volumenkörperschraffuren) und breite Polylinien ausgefüllt werden.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 12, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ISOLINES", "Bestimmt auf Objekten die Zahl der Isolinien pro Oberfläche.", VariantType.Short, null, vblnReadOnly: false, 4, 0, 2047, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "QTEXTMODE", "Steuert, wie Text angezeigt wird.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 13, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SPLINESEGS", "Bestimmt die Anzahl der Liniensegmente, die für jede Spline-angepaßte Polylinie erstellt werden.", VariantType.Short, null, vblnReadOnly: false, 8, -32768, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptDisplay, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 122, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "VISRETAIN", "Steuert die Plotstile (falls PSTYLEPOLICY auf 0 gesetzt ist), die Sichtbarkeit, die Farbe, den Linientyp und die Linienstärke für XRef-abhängige Layer; legt fest, ob Änderungen am Pfad einer verschachtelten XRef gespeichert werden sollen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 177, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "XEDIT", "Steuert, ob die aktuelle Zeichnung direkt bearbeitet werden kann, wenn sie von einer anderen Zeichnung referenziert wird.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptOpenSave, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 193, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OLESTARTUP", "Steuert, ob die Quellanwendungen von eingebetteten OLE-Objekten beim Plotten geladen werden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptOutput, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 201, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "EXTNAMES", "Legt die Parameter für die Namen von benannten Objekten fest (beispielsweise Linientypen und Layern), die in Symboltabellen gespeichert werden.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptSystem, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 199, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MAXACTVP", "Definiert die maximale Anzahl der Ansichtsfenster, die zur gleichen Zeit in der Anzeige aktiv sein können.", VariantType.Short, null, vblnReadOnly: false, 64, 2, 64, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptUnknown, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 169, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LWDEFAULT", "Bestimmt den Wert für die vorgegebene Linienstärke.", VariantType.Short, null, vblnReadOnly: false, 25, null, null, new object[24]
			{
			0,
			5,
			9,
			13,
			15,
			18,
			20,
			25,
			30,
			35,
			40,
			50,
			53,
			60,
			70,
			80,
			90,
			100,
			106,
			120,
			140,
			158,
			200,
			211
			}, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LWDISPLAY", "Steuert, ob die Linienstärke in der Registerkarte Modell und der Layout-Registerkarte angezeigt wird.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 189, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SORTENTS", "Steuert die Vorgänge zur Sortierung von Objekten mit dem Befehl OPTIONEN (Registerkarte Objektwahl).", VariantType.Short, null, vblnReadOnly: false, 96, 0, null, null, 127, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptUser, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 202, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
		}

		private void SysVarsAddDwgRO()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "BACKZ", "Speichert für das aktuelle Ansichtsfenster den Abstand zwischen der hinteren Schnittfläche und der Zielebene.", VariantType.Double, null, vblnReadOnly: true, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CPLOTSTYLE", "Steuert den aktuellen Plotstil für neue Objekte.", vblnReadOnly: true, "ByLayer", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("DWGCODEPAGE", "Speichert aus Kompatibilitätsgründen denselben Wert in die Systemvariable SYSCODEPAGE.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 3, 3, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: false, "ENTMODS", "Undokumemtiert", VariantType.Double, null, vblnReadOnly: true, null, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag3 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "EXTMAX", "Speichert den rechten oberen Punkt der Zeichnungsabmessungen.", 3, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 7, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag4 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "EXTMIN", "Speichert den linken unteren Punkt der Zeichnungsabmessungen.", 3, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 6, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag5 = false;
			InternAdd(vblnUnitsRef: false, "FRONTZ", "Speichert für das aktuelle Ansichtsfenster den Abstand zwischen der vorderen Schnittfläche und der Zielebene.", VariantType.Double, null, vblnReadOnly: true, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HANDLES", "Meldet, ob Objektreferenzen aktiviert sind und Anwendungen darauf zugreifen können.", VariantType.Short, null, vblnReadOnly: true, 1, 1, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag6 = false;
			InternAdd(vblnUnitsRef: false, "LENSLENGTH", "Speichert die Brennweite (in Millimeter), die in perspektivischen Ansichten für das aktuelle Ansichtsfenster verwendet wird.", VariantType.Double, null, vblnReadOnly: true, 50.0, 1E-09, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("LOGFILENAME", "Legt den Pfad und den Namen der Protokolldatei fest.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PSTYLEMODE", "Zeigt an, ob die aktuelle Zeichnung den Modus Farbabhängiger Plotstil oder Benannter Plotstil aufweist.", VariantType.Short, null, vblnReadOnly: true, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 196, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag7 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "TARGET", "Speichert die Position des Zielpunkts für das aktuelle Ansichtsfenster.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag8 = false;
			InternAdd(vblnUnitsRef: false, "TDCREATE", "Speichert Zeit und Datum der Zeichnungserstellung (Lokale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 108, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag9 = false;
			InternAdd(vblnUnitsRef: false, "TDINDWG", "Speichert die Gesamtbearbeitungszeit.", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 112, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag10 = false;
			InternAdd(vblnUnitsRef: false, "TDUCREATE", "Speichert Zeit und Datum der Zeichnungserstellung (Globale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 109, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag11 = false;
			InternAdd(vblnUnitsRef: false, "TDUPDATE", "Speichert Zeit und Datum des letzten Aktualisierungs-/Speichervorgangs (Lokale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 110, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag12 = false;
			InternAdd(vblnUnitsRef: false, "TDUSRTIMER", "Speichert den Stand der Benutzer-Stoppuhr.", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 113, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag13 = false;
			InternAdd(vblnUnitsRef: false, "TDUUPDATE", "Speichert Zeit und Datum des letzten Aktualisierungs-/Speichervorgangs (Globale Angaben).", VariantType.Double, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 111, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag14 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "VIEWCTR", "Speichert den Ansichtsmittelpunkt des aktuellen Ansichtsfensters.", 3, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag15 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "VIEWDIR", "Speichert die Ansichtsrichtung des aktuellen Ansichtsfensters.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			1.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "VIEWMODE", "Steuert den Ansichtsmodus für das aktuelle Ansichtsfenster als Bitcode.", VariantType.Short, null, vblnReadOnly: true, 0, 0, null, null, 31, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag16 = false;
			InternAdd(vblnUnitsRef: false, "VIEWSIZE", "Speichert die Höhe der Ansicht im aktuellen Ansichtsfenster.", VariantType.Double, null, vblnReadOnly: true, null, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag17 = false;
			InternAdd(vblnUnitsRef: false, "VIEWTWIST", "Speichert den Ansichtsdrehwinkel für das aktuelle Ansichtsfenster.", VariantType.Double, null, vblnReadOnly: true, 0.0, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag18 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "VSMAX", "Speichert die rechte obere Ecke des virtuellen Bildschirms im aktuellen Ansichtsfenster.", 3, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag19 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "VSMIN", "Speichert die linke untere Ecke des virtuellen Bildschirms im aktuellen Ansichtsfenster.", 3, vblnReadOnly: true, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddDwgStd()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "ANGBASE", "Setzt den Basiswinkel auf 0 bezogen auf das aktuelle BKS.", VariantType.Double, null, vblnReadOnly: false, 0.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 50, 115, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ANGDIR", "Bestimmt die positive Winkelrichtung ausgehend vom Winkel 0, bezogen auf das aktuelle BKS.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 116, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ATTMODE", "Steuert die Anzeige von Attributen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 16, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "AUNITS", "Bestimmt die Winkeleinheiten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 4, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 96, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "AUPREC", "Legt die Anzahl der Dezimalstellen für die Winkeleinheiten fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 97, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CECOLOR", "Setzt die Farbe für neue Objekte.", vblnReadOnly: false, "ByLayer", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: true, null, vblnIsDimValue: false, 62, 22, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CELTYPE", "Setzt den Linientyp für neue Objekte.", vblnReadOnly: false, "ByLayer", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symLType, vblnIsColor: false, null, vblnIsDimValue: false, 6, 21, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CELWEIGHT", "Setzt die Linienstärke für neue Objekte.", VariantType.Short, null, vblnReadOnly: false, -1, null, null, new object[27]
			{
			-3,
			-2,
			-1,
			0,
			5,
			9,
			13,
			15,
			18,
			20,
			25,
			30,
			35,
			40,
			50,
			53,
			60,
			70,
			80,
			90,
			100,
			106,
			120,
			140,
			158,
			200,
			211
			}, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 370, 186, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CLAYER", "Setzt den aktuellen Layer.", vblnReadOnly: false, "0", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symLayer, vblnIsColor: false, null, vblnIsDimValue: false, 8, 20, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CMLJUST", "Legt die Ausrichtung für Multilinien fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 182, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CMLSTYLE", "Setzt den Multilinienstil.", vblnReadOnly: false, "Standard", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 2, 181, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CTAB", "Gibt den Namen der aktuellen Registerkarte in der Zeichnung zurück (Modell oder Layout). Diese Systemvariable unterstützt Sie bei der Ermittlung der aktiven Registerkarte.", vblnReadOnly: false, "Model", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "CVPORT", "Setzt die Kennummer des aktuellen Ansichtsfensters.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symVPort, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMASSOC", "Steuert die Assoziativität von Bemaßungsobjekten.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 211, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "FLATLAND", "Undokumentiert", VariantType.Short, null, vblnReadOnly: true, 0, 0, 0, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "GRIDMODE", "Legt fest, ob das Raster aktiviert oder deaktiviert ist.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "HALOGAP", "Gibt den Abstand an, der angezeigt wird, wenn ein Objekt durch ein anderes verdeckt wird.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 206, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "HIDETEXT", "Legt fest, ob mit den Befehlen TEXT, DTEXT oder MTEXT erstellte Textobjekte verarbeitet werden können, während der Befehl VERDECKT aktiv ist.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 204, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAddString("HYPERLINKBASE", "Legt den Pfad für alle relativen Hyperlinks in der Zeichnung fest.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, 1, 191, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "INDEXCTL", "Steuert, ob Layerindizes und Raumindizes erzeugt und in Zeichnungsdateien gespeichert werden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 203, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "INTERSECTIONCOLOR", "Legt die Farbe von Flächenschnittpunkten fest.", VariantType.Short, null, vblnReadOnly: false, 257, 0, 257, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 210, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "INTERSECTIONDISPLAY", "Legt die Anzeige von Flächenschnittpunkten fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 209, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "LIMCHECK", "Steuert die Erzeugung von Objekten außerhalb der Zeichnungslimiten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 102, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LUNITS", "Bestimmt lineare Einheiten.", VariantType.Short, null, vblnReadOnly: false, 2, 1, 5, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 92, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "LUPREC", "Legt die Anzahl der Dezimalstellen für die linearen Einheiten fest.", VariantType.Short, null, vblnReadOnly: false, 4, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 93, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "MIRRTEXT", "Legt fest, auf welche Weise der Befehl SPIEGELN einen Text darstellt.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 14, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "OBSCOLOR", "OBSCUREDCOLOR, Legt die Farbe von verdeckten Linien fest.", VariantType.Short, null, vblnReadOnly: false, 257, 0, 257, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 207, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "OBSLTYPE", "OBSCUREDLTYPE, Legt den Linientyp von verdeckten Linien fest.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 11, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 208, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "ORTHOMODE", "Beschränkt Cursorbewegungen auf die Lotrechte.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 10, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PDMODE", "Steuert, wie Punktobjekte angezeigt werden.", VariantType.Short, null, vblnReadOnly: false, 0, null, null, new object[20]
			{
			0,
			1,
			2,
			3,
			4,
			32,
			33,
			34,
			35,
			36,
			64,
			65,
			66,
			67,
			68,
			96,
			97,
			98,
			99,
			100
			}, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 117, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PELLIPSE", "Undokumentiert", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PLINEGEN", "Bestimmt, wie Linientypmuster in der Umgebung der Kontrollpunkte einer zweidimensionalen Polylinie erzeugt werden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 178, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("PROJECTNAME", "Weist der aktuellen Zeichnung einen Projektnamen zu.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, 1, 212, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			InternAdd(vblnUnitsRef: false, "PROXYGRAPHICS", "Bestimmt, ob grafische Darstellungen von Proxy-Objekten in die Zeichnung aufgenommen werden sollen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 184, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PSLTSCALE", "Steuert die Skalierung von Linientypen im Papierbereich.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 179, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("PUCSBASE", "Speichert den Namen des BKS, mit dem der Ursprung und die Ausrichtung für die orthogonalen BKS-Einstellungen festgelegt werden (nur Papierbereich).", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: false, 2, 142, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "REGENMODE", "Steuert die automatische Regenerierung von Zeichnungen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 11, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SHADEDGE", "Steuert das Schattieren von Kanten bei einem Rendering.", VariantType.Short, null, vblnReadOnly: false, 3, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 166, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SHADEDIF", "Bestimmt das Verhältnis des diffusen Reflexionslichts zum Umgebungslicht.", VariantType.Short, null, vblnReadOnly: false, 70, 0, 100, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 167, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SKPOLY", "Legt fest, ob mit dem Befehl SKIZZE Linien oder Polylinien erstellt werden.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 107, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: false, "SNAPANG", "Setzt den Fang- und Rasterdrehwinkel für das aktuelle Ansichtsfenster.", VariantType.Double, null, vblnReadOnly: false, 0.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SNAPISOPAIR", "Steuert die isometrische Ebene für das aktuelle Ansichtsfenster.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SNAPMODE", "Aktiviert und deaktiviert den Fangmodus.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SNAPSTYL", "Setzt den Fangstil für das aktuelle Ansichtsfenster.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SPLFRAME", "Steuert die Anzeige von kurvenangeglichenen Polylinien.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 120, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SPLINETYPE", "Legt den Typ der Kurve fest, die mit der Option Spline des Befehls PEDIT erstellt wird.", VariantType.Short, null, vblnReadOnly: false, 6, 5, 6, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 121, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SURFTAB1", "Setzt die Anzahl der Tabellationen, die für die Befehle REGELOB and TABOB erstellt werden sollen.", VariantType.Short, null, vblnReadOnly: false, 6, 2, 32766, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 124, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SURFTAB2", "Legt die Netzdichte in N-Richtung für die Befehle ROTOB und KANTOB fest.", VariantType.Short, null, vblnReadOnly: false, 6, 2, 32766, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 125, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SURFTYPE", "Steuert den Typ der Oberfläche, die mit der Option Oberfläche glätten des Befehls PEDIT geglättet werden soll.", VariantType.Short, null, vblnReadOnly: false, 6, null, null, new object[3]
			{
			5,
			6,
			8
			}, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 126, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SURFU", "Bestimmt die Oberflächendichte in M-Richtung für die Option Oberfläche glätten im Befehl PEDIT.", VariantType.Short, null, vblnReadOnly: false, 6, 2, 200, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 127, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "SURFV", "Bestimmt die Oberflächendichte in N-Richtung für die Option Oberfläche glätten im Befehl PEDIT.", VariantType.Short, null, vblnReadOnly: false, 6, 2, 200, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 128, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("TEXTSTYLE", "Definiert den Namen des aktuellen Textstils.", vblnReadOnly: false, hwpDxf_Vars.pstrTextStyleName, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symStyle, vblnIsColor: false, null, vblnIsDimValue: false, 7, 19, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TILEMODE", "Macht die Registerkarte Modell oder die letzte Layout-Registerkarte zur aktuellen Registerkarte.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 168, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TREEDEPTH", "Legt die maximale Tiefe fest, d. h. wie oft sich der baumartig strukturierte Raumindex verzweigen darf.", VariantType.Short, null, vblnReadOnly: false, 3020, -32768, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 180, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TSTACKALIGN", "Steuert die vertikale Ausrichtung von gestapeltem Text.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "TSTACKSIZE", "Steuert den Prozentsatz der Höhe für den gestapelten Text relativ zur aktuellen Höhe des ausgewählten Textes.", VariantType.Short, null, vblnReadOnly: false, 70, 25, 125, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("UCSBASE", "Speichert den Namen des BKS, mit dem der Ursprung und die Ausrichtung für die orthogonalen BKS-Einstellungen festgelegt werden.", vblnReadOnly: false, null, new object[1]
			{
			""
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symUcs, vblnIsColor: false, ".", vblnIsDimValue: false, 2, 129, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UNITMODE", "Steuert das Anzeigeformat für Einheiten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 176, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			int dlngIdx2 = 1;
			checked
			{
				do
				{
					InternAdd(vblnUnitsRef: false, "USERI" + Conversions.ToString(dlngIdx2), "Dient zum Speichern und Abrufen von Ganzzahlwerten.", VariantType.Short, null, vblnReadOnly: false, 0, -32768, 32767, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 154 + dlngIdx2, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
					dlngIdx2++;
				}
				while (dlngIdx2 <= 5);
				dlngIdx2 = 1;
				do
				{
					bool flag3 = false;
					InternAdd(vblnUnitsRef: false, "USERR" + Conversions.ToString(dlngIdx2), "Dient zum Speichern und Abrufen von reellen Zahlen.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 159 + dlngIdx2, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
					dlngIdx2++;
				}
				while (dlngIdx2 <= 5);
				InternAdd(vblnUnitsRef: false, "WORLDVIEW", "Bestimmt, ob die Eingabe für die Befehle 3DORBIT, DANSICHT und APUNKT relativ zum WKS (Vorgabeeinstellung), zum aktuellen BKS oder zum BKS aus der Systemvariablen UCSBASE erfolgen soll.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 165, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
				InternAdd(vblnUnitsRef: false, "XCLIPFRAME", "Steuert die Sichtbarkeit der Zuschneide-Umgrenzung externer Referenzen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 290, 205, hwpDxf_Enums.REF_TYPE.rtDrawing, "AC1018", "_", "AC1018", "_");
			}
		}

		private void SysVarsAddDwgUnit()
		{
			bool flag = false;
			InternAddArrayDbl(vblnUnitsRef: true, "AXISUNIT", "Undokumentiert", 2, vblnReadOnly: false, new object[2]
			{
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: true, "CELTSCALE", "Legt den Linientyp-Skalierfaktor für das aktuelle Objekt fest.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 23, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: true, "CHAMFERA", "Setzt den ersten Fasenabstand.", VariantType.Double, null, vblnReadOnly: false, 0.5, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 103, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag4 = false;
			InternAdd(vblnUnitsRef: true, "CHAMFERB", "Setzt den zweiten Fasenabstand.", VariantType.Double, null, vblnReadOnly: false, 0.5, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 104, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag5 = false;
			InternAdd(vblnUnitsRef: true, "CHAMFERC", "Setzt die Fasenlänge.", VariantType.Double, null, vblnReadOnly: false, 1.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 105, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag6 = false;
			InternAdd(vblnUnitsRef: false, "CHAMFERD", "Setzt den Fasenwinkel.", VariantType.Double, null, vblnReadOnly: false, 0.0, -5729577951.0, 5729577951.0, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 106, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag7 = false;
			InternAdd(vblnUnitsRef: true, "CMLSCALE", "Steuert die Gesamtbreite einer Multilinie.", VariantType.Double, null, vblnReadOnly: false, 1.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 183, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag8 = false;
			InternAdd(vblnUnitsRef: true, "FILLETRAD", "Speichert den aktuellen Abrundungsradius.", VariantType.Double, null, vblnReadOnly: false, 0.5, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 95, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag9 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "GRIDUNIT", "Legt den Rasterpunkt-Abstand (X und Y) für das aktuelle Ansichtsfenster fest.", 2, vblnReadOnly: false, new object[2]
			{
			0.5,
			0.5
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag10 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "INSBASE", "Speichert den mit BASIS gesetzten Basispunkt.", 3, vblnReadOnly: false, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 5, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: true, "INSUNITS", "Legt einen Wert für die Zeichnungseinheiten fest, wenn Sie einen Block aus AutoCAD DesignCenter ziehen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 20, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 190, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag11 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "LIMMAX", "Speichert die oberen rechten Zeichnungslimiten des aktuellen Bereichs.", 2, vblnReadOnly: false, new object[2]
			{
			12.0,
			9.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[2]
			{
			10,
			20
			}, 9, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag12 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "LIMMIN", "Speichert die unteren linken Zeichnungslimiten des aktuellen Bereichs.", 2, vblnReadOnly: false, new object[2]
			{
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[2]
			{
			10,
			20
			}, 8, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag13 = false;
			InternAdd(vblnUnitsRef: true, "LTSCALE", "Setzt den globalen Skalierfaktor für Linientypen.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 15, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: true, "MEASUREMENT", "Bestimmt die Zeichnungseinheiten für die aktuelle Zeichnung (Britisch oder Metrisch).", VariantType.Short, null, vblnReadOnly: false, null, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: true, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 185, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag14 = false;
			InternAdd(vblnUnitsRef: true, "PDSIZE", "Bestimmt die Anzeigegröße für Punktobjekte.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 118, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag15 = false;
			InternAdd(vblnUnitsRef: true, "PLINEWID", "Speichert die Vorgabebreite für Polylinien.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 119, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag16 = false;
			InternAdd(vblnUnitsRef: true, "SKETCHINC", "Bestimmt die Skizziergenauigkeit für SKIZZE.", VariantType.Double, null, vblnReadOnly: false, 0.1, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 94, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag17 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "SNAPBASE", "Bestimmt den Fang- und Rasterursprungspunkt für das aktuelle Ansichtsfenster relativ zum aktuellen BKS.", 2, vblnReadOnly: false, new object[2]
			{
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag18 = false;
			InternAddArrayDbl(vblnUnitsRef: true, "SNAPUNIT", "Legt den Fangwert für das aktuelle Ansichtsfenster fest.", 2, vblnReadOnly: false, new object[2]
			{
			0.5,
			0.5
			}, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, null, null, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag19 = false;
			InternAdd(vblnUnitsRef: true, "TEXTSIZE", "Setzt die Vorgabehöhe für neue Textobjekte, die mit dem aktuellen Textstil gezeichnet werden.", VariantType.Double, null, vblnReadOnly: false, 0.2, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 17, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag20 = false;
			InternAdd(vblnUnitsRef: true, "THICKNESS", "Setzt die aktuelle 3D-Objekthöhe für Festkörper.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 101, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag21 = false;
			InternAdd(vblnUnitsRef: true, "TRACEWID", "Setzt die Vorgabe-Bandbreite.", VariantType.Double, null, vblnReadOnly: false, 0.05, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 18, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddDwgDimRO()
		{
			InternAddString("DIMSTYLE", "Zeigt den aktuellen Bemaßungsstil an.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symDimStyle, vblnIsColor: false, null, vblnIsDimValue: true, 2, 61, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
		}

		private void SysVarsAddDwgDimStd()
		{
			InternAdd(vblnUnitsRef: false, "DIMADEC", "Steuert die Anzahl der angezeigten Genauigkeitsstellen bei Winkelbemaßungen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 81, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALT", "Steuert die Anzeige von Bemaßungen mit Alternativeinheiten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 50, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALTD", "Steuert die Anzahl der Dezimalstellen für Alternativeinheiten.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 51, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag = false;
			InternAdd(vblnUnitsRef: false, "DIMALTF", "Steuert den Multiplikator für Alternativeinheiten.", VariantType.Double, null, vblnReadOnly: false, 25.4, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 52, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: false, "DIMALTRND", "Bestimmt das Runden von Alternativeinheiten.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 82, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALTTD", "Setzt die Anzahl der Dezimalstellen für die Toleranzwerte einer Bemaßung mit Alternativeinheiten.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 78, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALTTZ", "Schaltet die Unterdrückung von Nullen in Toleranzangaben um.", VariantType.Short, null, vblnReadOnly: false, 2, 0, 12, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 73, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALTU", "Setzt das Einheitenformat für Alternativeinheiten bezüglich aller Bemaßungsstilarten außer Winkel.", VariantType.Short, null, vblnReadOnly: false, 2, 1, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 77, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMALTZ", "Aktiviert bzw. deaktiviert das Unterdrücken von Nullen für Alternativeinheiten-Bemaßungswerte.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 15, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 72, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMAPOST", "Definiert ein Textpräfix und/oder Textsuffix für die Bemaßung mit Alternativeinheiten bei allen Bemaßungstypen, mit Ausnahme der Winkelbemaßung.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 49, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMASO", "Steuert die Assoziativität von Bemaßungsobjekten.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 46, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag3 = false;
			InternAdd(vblnUnitsRef: false, "DIMASZ", "Steuert die Größe der Pfeilspitzen von Maß- und Führungslinien.", VariantType.Double, null, vblnReadOnly: false, 0.18, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 26, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMATFIT", "Legt fest, auf welche Weise der Maßtext und die Pfeile angeordnet werden sollen, wenn ausreichend Platz für alle Elemente zwischen den Hilfslinien verfügbar ist.", VariantType.Short, null, vblnReadOnly: false, 3, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 85, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMAUNIT", "Setzt das Einheitenformat für Winkelbemaßungen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 80, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMAZIN", "Unterdrückt Nullen bei Winkelbemaßungen.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 83, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMBLK", "Bestimmt den Pfeilspitzenblock, der an den Enden der Maßlinien oder Führungslinien angezeigt wird.", vblnReadOnly: false, null, RuntimeHelpers.GetObjectValue(mvarDimBlkArray), hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symBlock, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 45, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMBLK1", "Legt die Pfeilspitze für das erste Ende der Maßlinie fest, wenn die Systemvariable DIMSAH aktiviert ist.", vblnReadOnly: false, null, RuntimeHelpers.GetObjectValue(mvarDimBlkArray), hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symBlock, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 59, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMBLK2", "Legt die Pfeilspitze für das zweite Ende der Maßlinie fest, wenn die Systemvariable DIMSAH aktiviert ist.", vblnReadOnly: false, null, RuntimeHelpers.GetObjectValue(mvarDimBlkArray), hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symBlock, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 60, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag4 = false;
			InternAdd(vblnUnitsRef: false, "DIMCEN", "Steuert mit den Maßbefehlen BEMMITTELP, BEMDURCHM und BEMRADIUS das Zeichnen von Zentrumspunkten und Mittellinien bei Kreisen und Bogen.", VariantType.Double, null, vblnReadOnly: false, 0.09, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 35, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMCLRD", "Weist Maßlinien, Pfeilspitzen und Führungslinien Farben zu.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 256, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 62, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMCLRE", "Weist den Hilfslinien eine Farbe zu.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 256, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 63, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMCLRT", "Weist Maßtexten Farben zu.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 256, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 64, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMDEC", "Legt die Anzahl der angezeigten Dezimalstellen für die Bemaßung mit Primäreinheiten fest.", VariantType.Short, null, vblnReadOnly: false, 4, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 75, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag5 = false;
			InternAdd(vblnUnitsRef: false, "DIMDLE", "Verlängert die Maßlinie um den angegebenen Betrag über die Hilfslinie hinaus, wenn Schrägstriche anstelle der Pfeilspitzen gezeichnet werden.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 30, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag6 = false;
			InternAdd(vblnUnitsRef: false, "DIMDLI", "Steuert die Abstände von Maßlinien in Basislinieneinheiten.", VariantType.Double, null, vblnReadOnly: false, 0.38, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 28, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddChar("DIMDSEP", "Definiert ein Dezimaltrennzeichen (ein einzelnes Zeichen), das bei Bemaßungen mit dezimalem Einheitenformat verwendet werden soll.", vblnReadOnly: false, ".", null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 84, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag7 = false;
			InternAdd(vblnUnitsRef: false, "DIMEXE", "Gibt an, wie weit eine Hilfslinie über die Maßlinie hinausreichen soll.", VariantType.Double, null, vblnReadOnly: false, 0.18, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 31, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag8 = false;
			InternAdd(vblnUnitsRef: false, "DIMEXO", "Bestimmt, in welchem Abstand von den Ursprungspunkten Hilfslinien gezeichnet werden.", VariantType.Double, null, vblnReadOnly: false, 0.0625, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 27, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMFIT", "Veraltet", VariantType.Short, null, vblnReadOnly: false, 3, 0, 5, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, null, null, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMFRAC", "Legt die Bruchschreibweise fest, wenn DIMLUNIT auf 4 bzw. 5 eingestellt wurde.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 86, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag9 = false;
			InternAdd(vblnUnitsRef: false, "DIMGAP", "Setzt den Abstand um den Maßtext, der verwendet wird, wenn Maßtext in eine hierfür unterbrochene Maßlinie eingesetzt wird.", VariantType.Double, null, vblnReadOnly: false, 0.09, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 66, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMJUST", "Steuert die horizontale Positionierung von Maßtext.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 4, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 67, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMLDRBLK", "Legt den Typ der Pfeilspitze für Führungen fest.", vblnReadOnly: false, null, RuntimeHelpers.GetObjectValue(mvarDimBlkArray), hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symBlock, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 87, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMLIM", "Maßgrenzen werden als Vorgabetext erzeugt.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 38, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMLUNIT", "Legt Einheiten für alle Bemaßungstypen fest, mit Ausnahme der Winkelbemaßungen.", VariantType.Short, null, vblnReadOnly: false, 2, 1, 6, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 88, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMLWD", "Weist Maßlinien eine Linienstärke zu.", VariantType.Short, null, vblnReadOnly: false, -2, -3, 211, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 89, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMLWE", "Weist Hilfslinien eine Linienstärke zu.", VariantType.Short, null, vblnReadOnly: false, -2, -3, 211, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 90, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMPOST", "Legt für die Bemaßung ein Text-Präfix und/oder -Suffix fest.", vblnReadOnly: false, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, ".", vblnIsDimValue: true, 1, 48, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag10 = false;
			InternAdd(vblnUnitsRef: false, "DIMRND", "Rundet alle Maßabstände auf den angegebenen Wert auf bzw. ab.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 29, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSAH", "Steuert die Anzeige von Pfeilspitzenblöcken für Maßlinien.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 58, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSD1", "Steuert die Unterdrückung der ersten Maßlinie.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 68, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSD2", "Steuert die Unterdrückung der zweiten Maßlinie.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 69, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSE1", "Unterdrückt die Anzeige der ersten Hilfslinie.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 41, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSE2", "Unterdrückt die Anzeige der zweiten Hilfslinie.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 42, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSHO", "Steuert die Neudefinition von Bemaßungsobjekten beim Ziehen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 47, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMSOXD", "Unterdrückt das Zeichnen von Maßlinien außerhalb der Hilfslinien.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 57, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTAD", "Steuert die vertikale Position von Text in bezug auf eine Maßlinie.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 43, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTDEC", "Legt die Anzahl der anzuzeigenden Dezimalstellen für Toleranzwertebemaßung mit Primäreinheiten fest.", VariantType.Short, null, vblnReadOnly: false, 4, 0, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 76, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag11 = false;
			InternAdd(vblnUnitsRef: false, "DIMTFAC", "Bestimmt einen Skalierfaktor für die Berechnung der Texthöhe von Brüchen und Toleranzen.", VariantType.Double, null, vblnReadOnly: false, 1.0, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 65, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTIH", "Steuert die Position von Maßtext innerhalb der Hilfslinien für alle Bemaßungstypen außer Koordinatenbemaßungen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 39, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTIX", "Zeichnet Text zwischen den Hilfslinien.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 56, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag12 = false;
			InternAdd(vblnUnitsRef: false, "DIMTM", "Setzt die Minimaltoleranzgrenze (untere Toleranzgrenze) für Maßtext, wenn DIMTOL oder DIMLIM aktiviert ist.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 33, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTMOVE", "Setzt die Regeln für die Verschiebung von Maßtext.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 91, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTOFL", "Steuert, ob zwischen den Hilfslinien eine Maßlinie gezeichnet werden soll, wenn der Text außerhalb der Hilfslinien plaziert wird.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 54, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTOH", "Steuert die Position des Maßtexts außerhalb der Hilfslinien.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 40, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTOL", "Fügt dem Maßtext Toleranzen hinzu.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 37, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTOLJ", "Setzt für Toleranzwerte die vertikale Ausrichtung relativ zum nominalen Maßtext.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 2, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 70, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag13 = false;
			InternAdd(vblnUnitsRef: false, "DIMTP", "Setzt die Maximaltoleranzgrenze (obere Toleranzgrenze) für Maßtext, wenn DIMTOL oder DIMLIM aktiviert ist.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 32, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag14 = false;
			InternAdd(vblnUnitsRef: false, "DIMTSZ", "Legt die Größe der Schrägstriche fest, die statt Pfeilspitzen für Linear-, Radius- und Durchmesserbemaßungen gezeichnet werden.", VariantType.Double, null, vblnReadOnly: false, 0.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 36, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag15 = false;
			InternAdd(vblnUnitsRef: false, "DIMTVP", "Steuert die vertikale Position von Maßtext oberhalb oder unterhalb der Maßlinie.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 55, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAddString("DIMTXSTY", "Bestimmt den Textstil der Bemaßung.", vblnReadOnly: false, hwpDxf_Vars.pstrTextStyleName, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symStyle, vblnIsColor: false, null, vblnIsDimValue: false, 7, 79, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag16 = false;
			InternAdd(vblnUnitsRef: false, "DIMTXT", "Legt die Höhe des Maßtexts fest, außer wenn der aktuelle Textstil eine feste Höhe besitzt.", VariantType.Double, null, vblnReadOnly: false, 0.18, 1E-99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 34, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMTZIN", "Steuert die Unterdrückung von Nullen in Toleranzwerten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 15, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 71, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMUNIT", "Veraltet", VariantType.Short, null, vblnReadOnly: false, 2, 1, 8, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: true, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, null, null, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMUPT", "Steuert die Optionen für vom Benutzer positionierten Text.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 74, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "DIMZIN", "Steuert die Unterdrückung von Nullen im Primäreinheitenwert.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 15, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 70, 44, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
		}

		private void SysVarsAddDwgDimUnit()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: true, "DIMLFAC", "Setzt einen Skalierfaktor für lineare Bemaßungen.", VariantType.Double, null, vblnReadOnly: false, 1.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 53, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
			bool flag2 = false;
			InternAdd(vblnUnitsRef: true, "DIMSCALE", "Bestimmt den globalen Skalierfaktor für Bemaßungsvariablen, die Größen und Abstände festlegen.", VariantType.Double, null, vblnReadOnly: false, 1.0, 0.0, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDrawing, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: true, 40, 25, hwpDxf_Enums.REF_TYPE.rtDimension, "", "_", "", "_");
		}

		private void SysVarsAddVPortRO()
		{
			InternAddString("UCSNAME", "Speichert den Namen des aktuellen Koordinatensystems für den aktuellen Bereich.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 2, 130, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORG", "Speichert den Ursprungspunkt des aktuellen Koordinatensystems für den aktuellen Bereich.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 131, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag2 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSXDIR", "Speichert die X-Richtung des aktuellen BKS im aktuellen Ansichtsfenster im aktuellen Bereich.", 3, vblnReadOnly: true, new object[3]
			{
			1.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 132, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag3 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSYDIR", "Speichert die Y-Richtung des aktuellen BKS im aktuellen Ansichtsfenster im aktuellen Bereich.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			1.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 133, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
		}

		private void SysVarsAddVPortStd()
		{
			InternAdd(vblnUnitsRef: false, "UCSFOLLOW", "Erzeugt bei jedem Wechsel von einem BKS zu einem anderen eine Draufsicht.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSICON", "Zeigt das BKS-Symbol im aktuellen Ansichtsfenster an.", VariantType.Short, null, vblnReadOnly: false, 3, 0, null, null, 3, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSVP", "Bestimmt, ob das BKS in den aktiven Ansichtsfenstern unverändert bleibt oder Änderungen am BKS des aktuellen Ansichtsfensters übernommen werden sollen.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, null, null, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
		}

		private void SysVarsAddVPortUnit()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: true, "ELEVATION", "Speichert die aktuelle Erhebung relativ zum aktuellen BKS des aktuellen Ansichtsfensters im aktuellen Bereich.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stViewport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 99, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
		}

		private void SysVarsAddDXFAppStd()
		{
			InternAddString("MENU", "DXF: Name der Menüdatei.", vblnReadOnly: false, hwpDxf_Vars.pstrMenu, null, hwpDxf_Enums.SAVE_TYPE.stDXFApp, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 1, 98, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddDXFDwgRO()
		{
			InternAdd(vblnUnitsRef: false, "ACADMAINTVER", "DXF: Wartungsversionsnummer.", VariantType.Short, null, vblnReadOnly: true, null, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 2, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("FINGERPRINTGUID", "DXF: Dient zur eindeutigen Identifizierung der Zeichnung. Wird beim ersten Speichern der Zeichnung erzeugt.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 2, 197, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("HANDSEED", "DXF: Nächste verfügbare Referenz.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 5, 123, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("STYLESHEET", "DXF: Undokumentiert", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 1, 192, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("VERSIONGUID", "DXF: Dient zur eindeutigen Identifizierung einer Version einer Zeichnung. Wird im beim ersten Speichern der Zeichnung oder beim Speichern veränderter Zeichnungen erzeugt.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 2, 198, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddDXFDwgStd()
		{
			InternAdd(vblnUnitsRef: false, "CEPSNTYPE", "DXF: Plotstiltyp für neue Objekte.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 380, 194, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAddString("CEPSNID", "DXF: Plotstiltyp-Referenz für neue Objekte.", vblnReadOnly: true, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 390, 195, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "ENDCAPS", "DXF: Einstellung für die Linienstärke der Linienendstücke bei neuen Objekten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 187, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "JOINSTYLE", "DXF: Einstellung für die Linienstärke der Linienverbindungsstücke bei neuen Objekten.", VariantType.Short, null, vblnReadOnly: false, 0, 0, 3, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 280, 188, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PINSBASE", "DXF: Einfügebasispunkt im Papierbereich.", 3, vblnReadOnly: false, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 170, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PLIMCHECK", "DXF: Limitenprüfung im Papierbereich bei Werten ungleich Null.", VariantType.Short, null, vblnReadOnly: false, 0, null, null, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 171, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag2 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PLIMMAX", "DXF: Maximale X- und Y-Limiten im Papierbereich.", 2, vblnReadOnly: false, new object[2]
			{
			420.0,
			297.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[2]
			{
			10,
			20
			}, 175, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			bool flag3 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PLIMMIN", "DXF: Minimale X- und Y-Limiten im Papierbereich.", 2, vblnReadOnly: false, new object[2]
			{
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[2]
			{
			10,
			20
			}, 174, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "USRTIMER", "DXF: Stoppuhr.", VariantType.Short, null, vblnReadOnly: false, 1, 0, 1, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 114, hwpDxf_Enums.REF_TYPE.rtDrawing, "", "_", "", "_");
		}

		private void SysVarsAddDXFVportRO()
		{
			bool flag = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PEXTMAX", "DXF: Maximale X-, Y- und Z-Grenzen für Papierbereich.", 3, vblnReadOnly: true, new object[3]
			{
			-1E+20,
			-1E+20,
			-1E+20
			}, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 173, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag2 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PEXTMIN", "DXF: Minimale X-, Y- und Z-Grenzen für Papierbereich.", 3, vblnReadOnly: true, new object[3]
			{
			1E+20,
			1E+20,
			1E+20
			}, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 172, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAddString("PUCSNAME", "DXF: Name des aktuellen BKS im Papierbereich.", vblnReadOnly: true, null, new object[1]
			{
			""
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symUcs, vblnIsColor: false, null, vblnIsDimValue: false, 2, 143, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag3 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORG", "DXF: Ursprung des aktuellen BKS im Papierbereich.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 144, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag4 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSXDIR", "DXF: X-Achse des aktuellen BKS im Papierbereich.", 3, vblnReadOnly: true, new object[3]
			{
			1.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 145, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag5 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSYDIR", "DXF: Y-Achse des aktuellen BKS im Papierbereich.", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			1.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 146, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag6 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGBACK", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'HINTEN' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 154, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag7 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGBOTTOM", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'UNTEN' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 150, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag8 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGFRONT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'VORNE' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 153, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag9 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGLEFT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'LINKS' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 151, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag10 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGRIGHT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'RECHTS' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 152, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag11 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "PUCSORGTOP", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Papierbereich auf 'OBEN' ändern (falls PUCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 149, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAddString("PUCSORTHOREF", "DXF: Wenn im Papierbereich ein orthogonales BKS vorliegt (PUCSORTHOVIEW ungleich Null), ist dies der Name des BKS, auf das sich das orthogonale BKS bezieht. Wenn diese Variable keinen Wert aufweist, entspricht das BKS dem Weltkoordinatensystem (WELT).", vblnReadOnly: true, null, new object[1]
			{
			""
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symUcs, vblnIsColor: false, null, vblnIsDimValue: false, 2, 147, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "PUCSORTHOVIEW", "DXF: Typ der orthogonalen Ansicht im BKS des Papierbereichs.", VariantType.Short, null, vblnReadOnly: true, 0, 0, 6, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 148, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag12 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGBACK", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'HINTEN' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 141, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag13 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGBOTTOM", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'UNTEN' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 137, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag14 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGFRONT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'VORNE' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 140, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag15 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGLEFT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'LINKS' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 138, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag16 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGRIGHT", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'RECHTS' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 139, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			bool flag17 = false;
			InternAddArrayDbl(vblnUnitsRef: false, "UCSORGTOP", "DXF: Punkt, der zum neuen Ursprung des BKS wird, wenn Sie das BKS im Modellbereich auf 'OBEN' ändern (falls UCSBASE auf WELT gesetzt ist).", 3, vblnReadOnly: true, new object[3]
			{
			0.0,
			0.0,
			0.0
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, new object[3]
			{
			10,
			20,
			30
			}, 136, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAddString("UCSORTHOREF", "DXF: Wenn im Modellbereich ein orthogonales BKS vorliegt (UCSORTHOVIEW ungleich Null), ist dies der Name des BKS, auf das sich das orthogonale BKS bezieht. Wenn diese Variable keinen Wert aufweist, entspricht das BKS dem Weltkoordinatensystem (WELT).", vblnReadOnly: true, null, new object[1]
			{
			""
			}, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, hwpDxf_Enums.SYMBOL_TABLE.symUcs, vblnIsColor: false, null, vblnIsDimValue: false, 2, 134, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
			InternAdd(vblnUnitsRef: false, "UCSORTHOVIEW", "DXF: Typ der orthogonalen Ansicht im BKS des Modellbereichs.", VariantType.Short, null, vblnReadOnly: true, 0, 0, 6, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFVport, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 70, 135, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
		}

		private void SysVarsAddDXFVportUnit()
		{
			bool flag = false;
			InternAdd(vblnUnitsRef: true, "PELEVATION", "DXF: Aktuelle Objekthöhe im Papierbereich.", VariantType.Double, null, vblnReadOnly: false, 0.0, -1E+99, 1E+99, null, null, hwpDxf_Enums.SAVE_TYPE.stDXFDoc, hwpDxf_Enums.PREF_TAB.ptNone, vblnRunTimeErr: false, vblnIsUnitsBase: false, hwpDxf_Enums.SYMBOL_TABLE.symNone, vblnIsColor: false, null, vblnIsDimValue: false, 40, 100, hwpDxf_Enums.REF_TYPE.rtViewport, "", "_", "", "_");
		}

		private void InternAddChar(string vstrName, string vstrDescription, bool vblnReadOnly, object vvarDefault, object vvarLstValues, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, hwpDxf_Enums.SYMBOL_TABLE vnumSymTable, bool vblnIsColor, object vvarEmptyValue, bool vblnIsDimValue, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			bool dblnUnitsRef = false;
			VariantType dnumVarType = VariantType.Char;
			object dvarArraySize = null;
			object dvarMinValue = null;
			object dvarMaxValue = null;
			object dvarBitValue = null;
			bool dblnIsUnitsBase = false;
			InternAdd(dblnUnitsRef, vstrName, vstrDescription, dnumVarType, RuntimeHelpers.GetObjectValue(dvarArraySize), vblnReadOnly, RuntimeHelpers.GetObjectValue(vvarDefault), RuntimeHelpers.GetObjectValue(dvarMinValue), RuntimeHelpers.GetObjectValue(dvarMaxValue), RuntimeHelpers.GetObjectValue(vvarLstValues), RuntimeHelpers.GetObjectValue(dvarBitValue), vnumSaveType, vnumPrefTab, vblnRunTimeErr, dblnIsUnitsBase, vnumSymTable, vblnIsColor, RuntimeHelpers.GetObjectValue(vvarEmptyValue), vblnIsDimValue, RuntimeHelpers.GetObjectValue(vvarHeaderCode), RuntimeHelpers.GetObjectValue(vvarHeaderPos), vnumRefType, vstrDwgStartAcadVer, vstrDwgEndAcadVer, vstrDxfStartAcadVer, vstrDxfEndAcadVer);
		}

		private void InternAddString(string vstrName, string vstrDescription, bool vblnReadOnly, object vvarDefault, object vvarLstValues, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, hwpDxf_Enums.SYMBOL_TABLE vnumSymTable, bool vblnIsColor, object vvarEmptyValue, bool vblnIsDimValue, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			bool dblnUnitsRef = false;
			VariantType dnumVarType = VariantType.String;
			object dvarArraySize = null;
			object dvarMinValue = null;
			object dvarMaxValue = null;
			object dvarBitValue = null;
			bool dblnIsUnitsBase = false;
			InternAdd(dblnUnitsRef, vstrName, vstrDescription, dnumVarType, RuntimeHelpers.GetObjectValue(dvarArraySize), vblnReadOnly, RuntimeHelpers.GetObjectValue(vvarDefault), RuntimeHelpers.GetObjectValue(dvarMinValue), RuntimeHelpers.GetObjectValue(dvarMaxValue), RuntimeHelpers.GetObjectValue(vvarLstValues), RuntimeHelpers.GetObjectValue(dvarBitValue), vnumSaveType, vnumPrefTab, vblnRunTimeErr, dblnIsUnitsBase, vnumSymTable, vblnIsColor, RuntimeHelpers.GetObjectValue(vvarEmptyValue), vblnIsDimValue, RuntimeHelpers.GetObjectValue(vvarHeaderCode), RuntimeHelpers.GetObjectValue(vvarHeaderPos), vnumRefType, vstrDwgStartAcadVer, vstrDwgEndAcadVer, vstrDxfStartAcadVer, vstrDxfEndAcadVer);
		}

		private void InternAddArrayDec(bool vblnUnitsRef, string vstrName, string vstrDescription, object vvarArraySize, bool vblnReadOnly, object vvarDefault, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			VariantType dnumVarType = (VariantType)8201;
			object dvarMinValue = null;
			object dvarMaxValue = null;
			object dvarLstValues = null;
			object dvarBitValue = null;
			bool dblnIsUnitsBase = false;
			hwpDxf_Enums.SYMBOL_TABLE dnumSymTable = hwpDxf_Enums.SYMBOL_TABLE.symNone;
			bool dblnIsColor = false;
			object dvarEmptyValue = null;
			bool dblnIsDimValue = false;
			InternAdd(vblnUnitsRef, vstrName, vstrDescription, dnumVarType, RuntimeHelpers.GetObjectValue(vvarArraySize), vblnReadOnly, RuntimeHelpers.GetObjectValue(vvarDefault), RuntimeHelpers.GetObjectValue(dvarMinValue), RuntimeHelpers.GetObjectValue(dvarMaxValue), RuntimeHelpers.GetObjectValue(dvarLstValues), RuntimeHelpers.GetObjectValue(dvarBitValue), vnumSaveType, vnumPrefTab, vblnRunTimeErr, dblnIsUnitsBase, dnumSymTable, dblnIsColor, RuntimeHelpers.GetObjectValue(dvarEmptyValue), dblnIsDimValue, RuntimeHelpers.GetObjectValue(vvarHeaderCode), RuntimeHelpers.GetObjectValue(vvarHeaderPos), vnumRefType, vstrDwgStartAcadVer, vstrDwgEndAcadVer, vstrDxfStartAcadVer, vstrDxfEndAcadVer);
		}

		private void InternAddArrayDbl(bool vblnUnitsRef, string vstrName, string vstrDescription, object vvarArraySize, bool vblnReadOnly, object vvarDefault, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			VariantType dnumVarType = (VariantType)8201;
			object dvarMinValue = null;
			object dvarMaxValue = null;
			object dvarLstValues = null;
			object dvarBitValue = null;
			bool dblnIsUnitsBase = false;
			hwpDxf_Enums.SYMBOL_TABLE dnumSymTable = hwpDxf_Enums.SYMBOL_TABLE.symNone;
			bool dblnIsColor = false;
			object dvarEmptyValue = null;
			bool dblnIsDimValue = false;
			InternAdd(vblnUnitsRef, vstrName, vstrDescription, dnumVarType, RuntimeHelpers.GetObjectValue(vvarArraySize), vblnReadOnly, RuntimeHelpers.GetObjectValue(vvarDefault), RuntimeHelpers.GetObjectValue(dvarMinValue), RuntimeHelpers.GetObjectValue(dvarMaxValue), RuntimeHelpers.GetObjectValue(dvarLstValues), RuntimeHelpers.GetObjectValue(dvarBitValue), vnumSaveType, vnumPrefTab, vblnRunTimeErr, dblnIsUnitsBase, dnumSymTable, dblnIsColor, RuntimeHelpers.GetObjectValue(dvarEmptyValue), dblnIsDimValue, RuntimeHelpers.GetObjectValue(vvarHeaderCode), RuntimeHelpers.GetObjectValue(vvarHeaderPos), vnumRefType, vstrDwgStartAcadVer, vstrDwgEndAcadVer, vstrDxfStartAcadVer, vstrDxfEndAcadVer);
		}

		private void InternAdd(bool vblnUnitsRef, string vstrName, string vstrDescription, VariantType vnumVarType, object vvarArraySize, bool vblnReadOnly, object vvarDefault, object vvarMinValue, object vvarMaxValue, object vvarLstValues, object vvarBitValue, hwpDxf_Enums.SAVE_TYPE vnumSaveType, hwpDxf_Enums.PREF_TAB vnumPrefTab, bool vblnRunTimeErr, bool vblnIsUnitsBase, hwpDxf_Enums.SYMBOL_TABLE vnumSymTable, bool vblnIsColor, object vvarEmptyValue, bool vblnIsDimValue, object vvarHeaderCode, object vvarHeaderPos, hwpDxf_Enums.REF_TYPE vnumRefType, string vstrDwgStartAcadVer, string vstrDwgEndAcadVer, string vstrDxfStartAcadVer, string vstrDxfEndAcadVer)
		{
			if (vvarHeaderPos != null)
			{
				string dstrKey2 = Conversions.ToString(vvarHeaderPos);
				dstrKey2 = "K" + new string('0', checked(3 - Strings.Len(dstrKey2))) + dstrKey2;
				if (mobjDictHeaderPos.ContainsKey(dstrKey2))
				{
					Debug.Print(Conversions.ToString(vvarHeaderPos));
				}
				else
				{
					mobjDictHeaderPos.Add(dstrKey2, vstrName);
				}
			}
			SysVar dobjSysVar2 = new SysVar();
			dobjSysVar2.FriendInit(vblnUnitsRef, vstrName, vstrDescription, vnumVarType, RuntimeHelpers.GetObjectValue(vvarArraySize), vblnReadOnly, RuntimeHelpers.GetObjectValue(vvarDefault), RuntimeHelpers.GetObjectValue(vvarMinValue), RuntimeHelpers.GetObjectValue(vvarMaxValue), RuntimeHelpers.GetObjectValue(vvarLstValues), RuntimeHelpers.GetObjectValue(vvarBitValue), vnumSaveType, vnumPrefTab, vblnRunTimeErr, vblnIsUnitsBase, vnumSymTable, vblnIsColor, RuntimeHelpers.GetObjectValue(vvarEmptyValue), vblnIsDimValue, RuntimeHelpers.GetObjectValue(vvarHeaderCode), RuntimeHelpers.GetObjectValue(vvarHeaderPos), vnumRefType, vstrDwgStartAcadVer, vstrDwgEndAcadVer, vstrDxfStartAcadVer, vstrDxfEndAcadVer);
			mcolClass.Add(Strings.UCase(dobjSysVar2.Name), dobjSysVar2);
			dobjSysVar2 = null;
		}
	}
}
