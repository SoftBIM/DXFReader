using DXFLib.Acad;
using DXFLib.Basic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_Functions
	{
		private const short clngErrNumOverflow = 6;

		private const string clngErrMsgOverflow = "Überlauf";

		private const short clngErrNumInvalidType = 13;

		private const string clngErrMsgInvalidType = "Typen unverträglich";

		private const int clngMaxHexNumLen = 8;

		private const int clngMaxHexValue = 15;

		private const double cdblMinHexDbl = 0.0;

		private const double cdblMaxHexDbl = 4294967295.0;

		private const double cdblMaxHexFncDbl = 2147483647.0;

		public static bool BkDXF_ValidHexNum(string vstrHexNum, ref int nrlngErrNum, ref string nrstrErrMsg)
		{
			nrlngErrNum = 0;
			nrstrErrMsg = null;
			if (Operators.CompareString(vstrHexNum, null, TextCompare: false) == 0)
			{
				nrlngErrNum = 13;
				nrstrErrMsg = "Typen unverträglich";
			}
			else if (LikeOperator.LikeString(vstrHexNum, "*[!0123456789ABCDEF]*", CompareMethod.Binary))
			{
				nrlngErrNum = 13;
				nrstrErrMsg = "Typen unverträglich";
			}
			else
			{
				if (Strings.Len(vstrHexNum) <= 8)
				{
					return true;
				}
				nrlngErrNum = 6;
				nrstrErrMsg = "Überlauf";
			}
			bool BkDXF_ValidHexNum = default(bool);
			return BkDXF_ValidHexNum;
		}

		public static bool BkDXF_ValidHexDbl(double vdblDouble, ref int nrlngErrNum, ref string nrstrErrMsg)
		{
			nrlngErrNum = 0;
			nrstrErrMsg = null;
			if (Conversion.Fix(vdblDouble) != vdblDouble)
			{
				nrlngErrNum = 13;
				nrstrErrMsg = "Typen unverträglich";
			}
			else if (vdblDouble < 0.0)
			{
				nrlngErrNum = 6;
				nrstrErrMsg = "Überlauf";
			}
			else
			{
				if (!(vdblDouble > 4294967295.0))
				{
					return true;
				}
				nrlngErrNum = 6;
				nrstrErrMsg = "Überlauf";
			}
			bool BkDXF_ValidHexDbl = default(bool);
			return BkDXF_ValidHexDbl;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static double BkDXF_HexToDbl(string vstrHexNum)
		{
			double BkDXF_HexToDbl = 0.0;
			vstrHexNum = Strings.UCase(Strings.Trim(vstrHexNum));
			int dlngErrNum = default(int);
			string dstrErrMsg = default(string);
			if (!BkDXF_ValidHexNum(vstrHexNum, ref dlngErrNum, ref dstrErrMsg))
			{
				Information.Err().Raise(dlngErrNum, "BkDXF_HexToDbl", dstrErrMsg);
			}
			else
			{
				double ddblDouble = Conversions.ToDouble("&H" + vstrHexNum);
				if (ddblDouble < 0.0)
				{
					ddblDouble = 4294967296.0 + ddblDouble;
				}
				BkDXF_HexToDbl = ddblDouble;
			}
			return BkDXF_HexToDbl;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static string BkDXF_HexAdd(string vstrHexNum1, string vstrHexNum2)
		{
			vstrHexNum1 = Strings.UCase(Strings.Trim(vstrHexNum1));
			vstrHexNum2 = Strings.UCase(Strings.Trim(vstrHexNum2));
			checked
			{
				int dlngErrNum = default(int);
				string dstrErrMsg = default(string);
				if (!BkDXF_ValidHexNum(vstrHexNum1, ref dlngErrNum, ref dstrErrMsg))
				{
					Information.Err().Raise(dlngErrNum, "BkDXF_HexAdd", dstrErrMsg);
				}
				else
				{
					if (BkDXF_ValidHexNum(vstrHexNum2, ref dlngErrNum, ref dstrErrMsg))
					{
						int dlngLen1 = Strings.Len(vstrHexNum1);
						int dlngLen2 = Strings.Len(vstrHexNum2);
						int dlngMaxLen = Conversions.ToInteger(Interaction.IIf(dlngLen1 > dlngLen2, dlngLen1, dlngLen2));
						vstrHexNum1 = new string('0', dlngMaxLen - dlngLen1) + vstrHexNum1;
						vstrHexNum2 = new string('0', dlngMaxLen - dlngLen2) + vstrHexNum2;
						int dlngAdd = 0;
						int num = dlngMaxLen;
						string dstrHexNum = default(string);
						for (int dlngIdx = num; dlngIdx >= 1; dlngIdx += -1)
						{
							int dlngSep1 = Conversions.ToInteger("&H" + Strings.Mid(vstrHexNum1, dlngIdx, 1));
							int dlngSep2 = Conversions.ToInteger("&H" + Strings.Mid(vstrHexNum2, dlngIdx, 1));
							int dlngSepSum = dlngAdd + dlngSep1 + dlngSep2;
							if (dlngSepSum > 15)
							{
								dlngSepSum -= 16;
								dlngAdd = 1;
							}
							else
							{
								dlngAdd = 0;
							}
							dstrHexNum = Conversion.Hex(dlngSepSum) + dstrHexNum;
						}
						if (dlngAdd != 0)
						{
							if (Strings.Len(dstrHexNum) == 8)
							{
								Information.Err().Raise(6, "BkDXF_HexAdd", "Überlauf");
								goto IL_0199;
							}
							dstrHexNum = Conversion.Hex(dlngAdd) + dstrHexNum;
						}
						return dstrHexNum;
					}
					Information.Err().Raise(dlngErrNum, "BkDXF_HexAdd", dstrErrMsg);
				}
				goto IL_0199;
			}
		IL_0199:
			string BkDXF_HexAdd = default(string);
			return BkDXF_HexAdd;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static string BkDXF_DblToHex(double vdblDouble)
		{
			string BkDXF_DblToHex = "0";
			int dlngErrNum2 = default(int);
			string dstrErrMsg2 = default(string);
			if (!BkDXF_ValidHexDbl(vdblDouble, ref dlngErrNum2, ref dstrErrMsg2))
			{
				Information.Err().Raise(dlngErrNum2, "BkDXF_DblToHex", dstrErrMsg2);
			}
			else
			{
				string dstrHexNum;
				if (vdblDouble == 4294967295.0)
				{
					dstrHexNum = "FFFFFFFF";
				}
				else if (vdblDouble > 2147483647.0)
				{
					string dstrHexNum2 = Conversion.Hex(2147483647.0);
					string dstrHexNum3 = Conversion.Hex(vdblDouble - 2147483647.0);
					try
					{
						dstrHexNum = BkDXF_HexAdd(dstrHexNum2, dstrHexNum3);
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						dlngErrNum2 = 0;
						dstrErrMsg2 = ExceptionHelper.GetExceptionMessage(ex);
						Information.Err().Raise(dlngErrNum2, "BkDXF_DblToHex", dstrErrMsg2);
						ProjectData.ClearProjectError();
						return BkDXF_DblToHex;
					}
				}
				else
				{
					dstrHexNum = Conversion.Hex(vdblDouble);
				}
				BkDXF_DblToHex = dstrHexNum;
			}
			return BkDXF_DblToHex;
		}

		public static short BkDXF_DefaultAutosnap()
		{
			short dintValue6 = 0;
			bool flag = true;
			checked
			{
				dintValue6 = (short)(dintValue6 | 1);
				bool flag2 = true;
				dintValue6 = (short)(dintValue6 | 2);
				bool flag3 = true;
				dintValue6 = (short)(dintValue6 | 4);
				dintValue6 = (short)(dintValue6 | 8);
				dintValue6 = (short)(dintValue6 | 0x10);
				bool flag4 = true;
				return (short)(dintValue6 | 0x20);
			}
		}

		public static short BkDXF_DefaultTrackpath()
		{
			short dintValue = 0;
			bool flag = false;
			bool flag2 = false;
			return dintValue;
		}

		public static short BkDXF_DefaultShortcutmenu()
		{
			short dintValue = 0;
			bool flag = true;
			checked
			{
				if (hwpDxf_ConstMisc.pclngSCMDefaultMode == 1)
				{
					dintValue = (short)(dintValue | 1);
				}
				if (hwpDxf_ConstMisc.pclngSCMEditMode == 1)
				{
					dintValue = (short)(dintValue | 2);
				}
				switch (hwpDxf_ConstMisc.pclngSCMCommandMode)
				{
					case 2:
						dintValue = (short)(dintValue | 4);
						break;
					case 1:
						dintValue = (short)(dintValue | 8);
						break;
				}
				return dintValue;
			}
		}

		public static void BkDXF_MainDictionaries(ref object rvarMainDictionaries)
		{
			rvarMainDictionaries = new object[24]
			{
			"enu",
			"ena",
			"ens",
			"enz",
			"ca",
			"cs",
			"da",
			"nl",
			"nls",
			"fi",
			"fr",
			"fra",
			"de",
			"ded",
			"it",
			"no",
			"non",
			"pt",
			"ptb",
			"ru",
			"rui",
			"es",
			"esa",
			"sv"
			};
		}

		public static short BkDXF_BooleanToInteger(bool vblnValue, bool nvblnInvers = false)
		{
			if (nvblnInvers)
			{
				if (vblnValue)
				{
					return 0;
				}
				return 1;
			}
			if (vblnValue)
			{
				return 1;
			}
			return 0;
		}

		public static bool BkDXF_AddIDToDict(double vdblObjectID, int vlngCode, ref Dictionary<object, object> robjDict)
		{
			if (robjDict == null)
			{
				robjDict = new Dictionary<object, object>();
			}
			try
			{
				robjDict.Add(vdblObjectID, vlngCode);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				robjDict = null;
				bool BkDXF_AddIDToDict = false;
				ProjectData.ClearProjectError();
				return BkDXF_AddIDToDict;
			}
			if (robjDict.Count == 0)
			{
				robjDict = null;
			}
			return true;
		}

		public static bool BkDXF_RemoveIDFromDict(double vdblObjectID, ref Dictionary<object, object> robjDict)
		{
			bool BkDXF_RemoveIDFromDict2 = default(bool);
			if (robjDict != null)
			{
				try
				{
					robjDict.Remove(vdblObjectID);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					BkDXF_RemoveIDFromDict2 = false;
					ProjectData.ClearProjectError();
					return BkDXF_RemoveIDFromDict2;
				}
				if (robjDict.Count == 0)
				{
					robjDict = null;
				}
				return true;
			}
			return BkDXF_RemoveIDFromDict2;
		}

		public static string BkDXF_StringDict(Dictionary<object, object> vobjDict)
		{
			string dstrDicts = default(string);
			if (vobjDict != null)
			{
				object dvarKeys = RuntimeHelpers.GetObjectValue(BkDXF_KeyCollectionToArray(vobjDict.Keys));
				object dvarItems = RuntimeHelpers.GetObjectValue(BkDXF_ValueCollectionToArray(vobjDict.Values));
				int num = Information.LBound((Array)dvarKeys);
				int num2 = Information.UBound((Array)dvarKeys);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dstrDicts = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dstrDicts + "(", NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null)), " . "), NewLateBinding.LateIndexGet(dvarKeys, new object[1]
					{
					dlngIdx
					}, null)), ")"));
				}
			}
			return dstrDicts;
		}

		public static string BkDXF_LinetypeString(string vstrLinetype, bool nvblnGerman = false)
		{
			switch (Strings.UCase(vstrLinetype))
			{
				case "VONBLOCK":
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonBlock", "ByBlock"));
				case "VONLAYER":
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonLayer", "ByLayer"));
				case "BYBLOCK":
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonBlock", "ByBlock"));
				case "BYLAYER":
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonLayer", "ByLayer"));
				default:
					return vstrLinetype;
			}
		}

		public static string BkDXF_ColorLongToString(Enums.AcColor vnumColor, bool nvblnGerman = false, bool nvblnNamed = false)
		{
			switch (vnumColor)
			{
				case Enums.AcColor.acByBlock:
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonBlock", "ByBlock"));
				case Enums.AcColor.acByLayer:
					return Conversions.ToString(Interaction.IIf(nvblnGerman, "VonLayer", "ByLayer"));
				default:
					if (nvblnNamed)
					{
						switch (vnumColor)
						{
							case Enums.AcColor.acRed:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Rot", "Red"));
							case Enums.AcColor.acYellow:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Gelb", "Yellow"));
							case Enums.AcColor.acGreen:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Grün", "Green"));
							case Enums.AcColor.acCyan:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Cyan", "Cyan"));
							case Enums.AcColor.acBlue:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Blau", "Blue"));
							case Enums.AcColor.acMagenta:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Magenta", "Magenta"));
							case Enums.AcColor.acWhite:
								return Conversions.ToString(Interaction.IIf(nvblnGerman, "Weiss", "White"));
							default:
								return Strings.Trim(Conversions.ToString((int)vnumColor));
						}
					}
					return Strings.Trim(Conversions.ToString((int)vnumColor));
			}
		}

		public static int BkDXF_ColorStringToLong(string vstrColor)
		{
			string left = Strings.UCase(vstrColor);
			if (Operators.CompareString(left, Strings.UCase("ByBlock"), TextCompare: false) == 0)
			{
				return 0;
			}
			if (Operators.CompareString(left, Strings.UCase("ByLayer"), TextCompare: false) == 0)
			{
				return 256;
			}
			return Conversions.ToInteger(vstrColor);
		}

		public static bool BkDXF_DxfAcadVerCheckSupport(string vstrAcadVer)
		{
			int num = Information.LBound(hwpDxf_Vars.pvarSupportedAcadVer);
			int num2 = Information.UBound(hwpDxf_Vars.pvarSupportedAcadVer);
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				if (Operators.CompareString(vstrAcadVer, Strings.UCase(hwpDxf_Vars.pvarSupportedAcadVer[dlngIdx]), TextCompare: false) == 0)
				{
					return true;
				}
			}
			bool dblnFound = default(bool);
			return dblnFound;
		}

		public static string BkDXF_DxfAcadVerToRelease(string vstrAcadVer)
		{
			string left = Strings.UCase(vstrAcadVer);
			if (Operators.CompareString(left, Strings.UCase("AC1006"), TextCompare: false) == 0)
			{
				return "R10";
			}
			if (Operators.CompareString(left, Strings.UCase("AC1009"), TextCompare: false) == 0)
			{
				return "R11/R12";
			}
			if (Operators.CompareString(left, Strings.UCase("AC1012"), TextCompare: false) == 0)
			{
				return "R13";
			}
			if (Operators.CompareString(left, Strings.UCase("AC1014"), TextCompare: false) == 0)
			{
				return "R14";
			}
			if (Operators.CompareString(left, Strings.UCase("AC1015"), TextCompare: false) == 0)
			{
				return "AutoCAD 2000";
			}
			if (Operators.CompareString(left, Strings.UCase("AC1018"), TextCompare: false) == 0)
			{
				return "AutoCAD 2005";
			}
			return "Unbekannt";
		}

		public static string BkDXF_AttachmentPointString(Enums.AcAttachmentPoint vnumAttachmentPoint)
		{
			switch (vnumAttachmentPoint)
			{
				case Enums.AcAttachmentPoint.acAttachmentPointTopLeft:
					return "Oben Links";
				case Enums.AcAttachmentPoint.acAttachmentPointTopCenter:
					return "Oben Mitte";
				case Enums.AcAttachmentPoint.acAttachmentPointTopRight:
					return "Oben Rechts";
				case Enums.AcAttachmentPoint.acAttachmentPointMiddleLeft:
					return "Mitte Links";
				case Enums.AcAttachmentPoint.acAttachmentPointMiddleCenter:
					return "Mitte Mitte";
				case Enums.AcAttachmentPoint.acAttachmentPointMiddleRight:
					return "Mitte Rechts";
				case Enums.AcAttachmentPoint.acAttachmentPointBottomLeft:
					return "Unten Links";
				case Enums.AcAttachmentPoint.acAttachmentPointBottomCenter:
					return "Unten Mitte";
				case Enums.AcAttachmentPoint.acAttachmentPointBottomRight:
					return "Unten Rechts";
				default:
					{
						string dstrValue = default(string);
						return dstrValue;
					}
			}
		}

		public static string BkDXF_LineWeightString(Enums.AcLineWeight vnumLineweight)
		{
			switch (vnumLineweight)
			{
				case Enums.AcLineWeight.acLnWtByLayer:
					return "ByLayer";
				case Enums.AcLineWeight.acLnWtByBlock:
					return "ByBlock";
				case Enums.AcLineWeight.acLnWtByLwDefault:
					return "Default";
				default:
					{
						string dstrValue = Strings.Replace(Support.Format(Operators.DivideObject((double)vnumLineweight, Interaction.IIf(Expression: false, new decimal(100L), 100.0)), "#.##"), ",", ".");
						if (LikeOperator.LikeString(dstrValue, ".*", CompareMethod.Binary))
						{
							dstrValue = "0" + dstrValue;
						}
						if (Strings.Len(dstrValue) < 4)
						{
							dstrValue += new string('0', checked(4 - Strings.Len(dstrValue)));
						}
						return dstrValue + " mm";
					}
			}
		}

		public static string BkDXF_UCSOrthographicString(Enums.AcOrthoView vnumUCSOrthographic)
		{
			switch (vnumUCSOrthographic)
			{
				case Enums.AcOrthoView.acOvNone:
					return "Nicht orthogonal";
				case Enums.AcOrthoView.acOvTopView:
					return "Oben";
				case Enums.AcOrthoView.acOvBottomView:
					return "Unten";
				case Enums.AcOrthoView.acOvFrontView:
					return "Vorne";
				case Enums.AcOrthoView.acOvBackView:
					return "Hinten";
				case Enums.AcOrthoView.acOvLeftView:
					return "Links";
				case Enums.AcOrthoView.acOvRightView:
					return "Rechts";
				default:
					{
						string dstrValue = default(string);
						return dstrValue;
					}
			}
		}

		public static string BkDXF_DrawingDirectionString(Enums.AcDrawingDirection vnumDrawingDirection)
		{
			switch (vnumDrawingDirection)
			{
				case Enums.AcDrawingDirection.acLeftToRight:
					return "Von Links nach Rechts";
				case Enums.AcDrawingDirection.acRightToLeft:
					return "Von Rechts nach Links";
				case Enums.AcDrawingDirection.acTopToBottom:
					return "Von Oben nach Unten";
				case Enums.AcDrawingDirection.acBottomToTop:
					return "Von Unten nach Oben";
				case Enums.AcDrawingDirection.acByStyle:
					return "Nach Textstil";
				default:
					{
						string dstrValue = default(string);
						return dstrValue;
					}
			}
		}

		public static string BkDXF_SpacingStyleString(Enums.AcLineSpacingStyle vnumSpacingStyle)
		{
			switch (vnumSpacingStyle)
			{
				case Enums.AcLineSpacingStyle.acLineSpacingStyleAtLeast:
					return "Angenähert";
				case Enums.AcLineSpacingStyle.acLineSpacingStyleExactly:
					return "Exakt";
				default:
					{
						string dstrValue = default(string);
						return dstrValue;
					}
			}
		}

		public static string BkDXF_MergeStyleString(hwpDxf_Enums.MERGE_STYLE vnumMergeStyle)
		{
			switch (vnumMergeStyle)
			{
				case hwpDxf_Enums.MERGE_STYLE.msDrcNotApplicable:
					return "Entfällt";
				case hwpDxf_Enums.MERGE_STYLE.msDrcIgnore:
					return "Vorhandenen Datensatz beibehalten";
				case hwpDxf_Enums.MERGE_STYLE.msDrcReplace:
					return "<XRef>$0$<Name>";
				case hwpDxf_Enums.MERGE_STYLE.msDrcXrefMangleName:
					return "$0$<Name>";
				case hwpDxf_Enums.MERGE_STYLE.msDrcMangleName:
					return "Name zusammenführen";
				default:
					{
						string dstrValue = default(string);
						return dstrValue;
					}
			}
		}

		public static bool BkDXF_CheckVariantForValueReal(object vvarValue, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			VariantType dnumVarType = Information.VarType(RuntimeHelpers.GetObjectValue(vvarValue));
			if (((0 & ((dnumVarType != VariantType.Decimal) ? 1 : 0) & ((dnumVarType != VariantType.Double) ? 1 : 0)) | (1 & ((dnumVarType != VariantType.Double) ? 1 : 0))) != 0)
			{
				nrstrErrMsg = "Datentyp der Variable ist ungültig.";
				bool BkDXF_CheckVariantForValueReal = default(bool);
				return BkDXF_CheckVariantForValueReal;
			}
			return true;
		}

		public static bool BkDXF_CheckVariantForArrayReal(object vvarArray, int vlngLBound, int vlngUBound, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				if ((Information.VarType(RuntimeHelpers.GetObjectValue(vvarArray)) & VariantType.Array) != VariantType.Array)
				{
					nrstrErrMsg = "Variable ist kein Datenfeld.";
					dblnError = true;
				}
				else if (Information.LBound((Array)vvarArray) != vlngLBound)
				{
					nrstrErrMsg = "Untere Datenfeldgrenze der Variable ist ungültig.";
					dblnError = true;
				}
				else if (Information.UBound((Array)vvarArray) != vlngUBound)
				{
					nrstrErrMsg = "Obere Datenfeldgrenze der Variable ist ungültig.";
					dblnError = true;
				}
				else
				{
					int dlngCount = 0;
					for (int dlngIdx = vlngLBound; dlngIdx <= vlngUBound; dlngIdx++)
					{
						dlngCount++;
						object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarArray, new object[1]
						{
						dlngIdx
						}, null));
						string nrstrErrMsg2 = "";
						if (!BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg2))
						{
							nrstrErrMsg = "Datentyp des " + Conversions.ToString(dlngCount) + ". Datenfeldwertes der Variable ist ungültig.";
							dblnError = true;
							break;
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXF_SetArrayReal(ref object ravarArrayDec, ref object ravarArrayDbl, object vavarArray, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool flag = false;
			int dlngLBound = Information.LBound((Array)ravarArrayDbl);
			int dlngUBound = Information.UBound((Array)ravarArrayDbl);
			if (BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(vavarArray), dlngLBound, dlngUBound, ref nrstrErrMsg))
			{
				int num = dlngLBound;
				int num2 = dlngUBound;
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					bool flag2 = false;
					NewLateBinding.LateIndexSet(ravarArrayDbl, new object[2]
					{
					dlngIdx,
					NewLateBinding.LateIndexGet(vavarArray, new object[1]
					{
						dlngIdx
					}, null)
					}, null);
				}
				return true;
			}
			bool BkDXF_SetArrayReal = default(bool);
			return BkDXF_SetArrayReal;
		}

		public static bool BkDXF_SetValueReal(ref object rvarValueDec, ref object rvarValueDbl, object vvarValue, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			if (BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarValue), ref nrstrErrMsg))
			{
				bool flag = false;
				rvarValueDbl = RuntimeHelpers.GetObjectValue(vvarValue);
				return true;
			}
			bool BkDXF_SetValueReal = default(bool);
			return BkDXF_SetValueReal;
		}

		public static string BkDXF_SeperateFilePrefix(string vstrFile, ref string nrstrPre, ref string nrstrPost)
		{
			int dlngSlashPos = Strings.InStrRev(vstrFile, "\\");
			checked
			{
				if (dlngSlashPos > 0)
				{
					nrstrPre = Strings.Left(vstrFile, dlngSlashPos);
					vstrFile = Strings.Mid(vstrFile, dlngSlashPos + 1);
				}
				int dlngPointPos = Strings.InStrRev(vstrFile, ".");
				if (dlngPointPos > 0)
				{
					nrstrPost = Strings.Mid(vstrFile, dlngPointPos);
					vstrFile = Strings.Left(vstrFile, dlngPointPos - 1);
				}
				return vstrFile;
			}
		}

		public static void BkDXF_DebugPrint(string vstrMsg)
		{
			bool flag = false;
		}

		public static void BkDXF_DebugClassNotEmpty(OrderedDictionary vcolClass, object vstrClassName)
		{
			if ((((vcolClass.Count > 0) ? 1 : 0) & 0) != 0)
			{
				Debug.Print(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(vstrClassName, ": "), vcolClass.Count)));
			}
		}

		public static string BkDXF_ReadLine(StreamReader vobjStreamReader)
		{
			string dstrLine2 = vobjStreamReader.ReadLine();
			if (Strings.InStr(1, dstrLine2, "\r") != 0)
			{
				dstrLine2 = Strings.Replace(dstrLine2, "\r\n", "");
				dstrLine2 = Strings.Replace(dstrLine2, "\r", "");
				vobjStreamReader.ReadLine();
			}
			return dstrLine2;
		}

		public static bool BkDXF_OpenFile(string vstrFileName, ref string nrstrAcadVer, ref string nrstrErrMsg)
		{
			nrstrAcadVer = null;
			nrstrErrMsg = null;
			StreamReader dobjStreamReader2 = default(StreamReader);
			try
			{
				dobjStreamReader2 = new StreamReader(vstrFileName);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
			}
			bool BkDXF_OpenFile = default(bool);
			if (dobjStreamReader2 == null)
			{
				nrstrErrMsg = "Die Datei konnte nicht geöffnet werden.";
			}
			else
			{
				if (dobjStreamReader2.EndOfStream)
				{
					nrstrErrMsg = "Die Datei ist leer.";
				}
				else if (Operators.CompareString("AutoCAD Binary DXF", BkDXF_ReadLine(dobjStreamReader2), TextCompare: false) == 0)
				{
					nrstrErrMsg = "Die Datei ist binär.";
				}
				else
				{
					bool dblnStop = default(bool);
					string dstrAcadVer = default(string);
					while (!dobjStreamReader2.EndOfStream && !dblnStop)
					{
						string dstrLine = BkDXF_ReadLine(dobjStreamReader2);
						if (Operators.CompareString(Strings.UCase(dstrLine), Strings.UCase("$ACADVER"), TextCompare: false) == 0)
						{
							dblnStop = true;
							BkDXF_ReadLine(dobjStreamReader2);
							dstrAcadVer = Strings.UCase(BkDXF_ReadLine(dobjStreamReader2));
						}
					}
					if (!dblnStop)
					{
						nrstrErrMsg = "Die Datei enthält keinen gültigen Versionseintrag.";
					}
					else if (!BkDXF_DxfAcadVerCheckSupport(dstrAcadVer))
					{
						nrstrErrMsg = "Die DXF-Version '" + BkDXF_DxfAcadVerToRelease(dstrAcadVer) + "' wird nicht unterstützt.";
					}
					else
					{
						nrstrAcadVer = dstrAcadVer;
						BkDXF_OpenFile = true;
					}
				}
				dobjStreamReader2.Close();
			}
			dobjStreamReader2 = null;
			return BkDXF_OpenFile;
		}

		public static object BkDXF_ValueCollectionToArray(Dictionary<object, object>.ValueCollection vobjValueCollection)
		{
			if (vobjValueCollection.Count > 0)
			{
				object[] dvarValues = new object[checked(vobjValueCollection.Count - 1 + 1)];
				vobjValueCollection.CopyTo(dvarValues, 0);
				return dvarValues;
			}
			object[] dvarValues2 = default(object[]);
			Array.Resize(ref dvarValues2, 0);
			return dvarValues2;
		}

		public static object BkDXF_KeyCollectionToArray(Dictionary<object, object>.KeyCollection vobjKeyCollection)
		{
			if (vobjKeyCollection.Count > 0)
			{
				object[] dvarValues = new object[checked(vobjKeyCollection.Count - 1 + 1)];
				vobjKeyCollection.CopyTo(dvarValues, 0);
				return dvarValues;
			}
			object[] dvarValues2 = default(object[]);
			Array.Resize(ref dvarValues2, 0);
			return dvarValues2;
		}
	}
}
