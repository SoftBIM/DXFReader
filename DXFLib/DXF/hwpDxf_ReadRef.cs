using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class hwpDxf_ReadRef
	{
		public static bool BkDXFReadRef_AcadObject(AcadDatabase vobjAcadDatabase, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref double rdblObjectID, ref double rdblOwnerID, ref double rdblLineOwnerID, ref Dictionary<object, object> robjDictReactors, ref Dictionary<object, object> robjDictXDictionary, ref string nrstrErrMsg = "", bool nvblnDoNotCheckObjectID = false)
		{
			nrstrErrMsg = null;
			robjDictReactors.Clear();
			if (robjDictXDictionary != null)
			{
				robjDictXDictionary.Clear();
			}
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 5, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Referenz in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					rdblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(vobjDictReadValues[rlngIdx]));
					rlngIdx++;
					if (!nvblnDoNotCheckObjectID && !vobjAcadDatabase.FriendValidObjectID(rdblObjectID, ref nrstrErrMsg))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString(rlngIdx * 2) + " ist ungültig.\n" + nrstrErrMsg;
						dblnError = true;
						double vdblObjectID = rdblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject.ObjectName);
						}
						dobjObjectIDAcadObject = null;
					}
					if (!dblnError)
					{
						while (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(vobjDictReadCodes[rlngIdx], 102, TextCompare: false), !dblnError)))
						{
							object left = vobjDictReadValues[rlngIdx];
							if (Operators.ConditionalCompareObjectEqual(left, "{ACAD_REACTORS", TextCompare: false))
							{
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_Reactors(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictReactors, ref nrstrErrMsg);
							}
							else if (Operators.ConditionalCompareObjectEqual(left, "{ACAD_XDICTIONARY", TextCompare: false))
							{
								if (robjDictXDictionary == null)
								{
									nrstrErrMsg = "Ungültige Anwendungsgruppe in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
									dblnError = true;
								}
								else
								{
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XDictionary(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictXDictionary, ref nrstrErrMsg);
								}
							}
							else
							{
								nrstrErrMsg = "Unbekannter Anfang einer Anwendungsgruppe in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
								dblnError = true;
							}
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 330, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else
							{
								rdblOwnerID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
								rdblLineOwnerID = rlngIdx * 2;
							}
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadEntity(string vstrAcadVer, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref int rlngPaperSpace, ref string rstrLayer, ref string rstrLinetype, ref int rlngColor, ref object rvarLinetypeScale, ref int rlngVisible, ref int rlngRGB, ref Enums.AcLineWeight rnumLineweight, ref string rstrPlotStyleNameReference, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbEntity", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else
				{
					rlngIdx++;
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 67, TextCompare: false))
					{
						rlngPaperSpace = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
					}
					else
					{
						rlngPaperSpace = hwpDxf_Vars.plngPaperSpace;
					}
					string pstrAppLayoutName = null;
					int pclngGrpAppLayoutName = 410;
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], pclngGrpAppLayoutName, TextCompare: false))
					{
						string rstrAppLayoutName2 = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
					}
					else
					{
						string rstrAppLayoutName2 = pstrAppLayoutName;
					}
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 8, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Layername in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						rstrLayer = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 6, TextCompare: false))
						{
							rstrLinetype = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rstrLinetype = hwpDxf_Vars.pstrEntityLinetype;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 62, TextCompare: false))
						{
							rlngColor = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rlngColor = unchecked((int)hwpDxf_Vars.pnumEntityColor);
						}
						if (Operators.CompareString(vstrAcadVer, "AC1018", TextCompare: false) >= 0)
						{
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 420, TextCompare: false))
							{
								rlngRGB = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								rlngRGB = hwpDxf_Vars.plngRGB;
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 430, TextCompare: false))
							{
								string rstrDictColor2 = Conversions.ToString(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								string rstrDictColor2 = hwpDxf_Vars.pstrDictColor;
							}
							int pclngGrpTransparence = 440;
							object pdecTransparence = 0m;
							double pdblTransparence = 0.0;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], pclngGrpTransparence, TextCompare: false))
							{
								bool flag = false;
								double rdblTransparence2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag2 = false;
								double rdblTransparence2 = pdblTransparence;
							}
						}
						double ddblLinetypeScale;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 48, TextCompare: false))
						{
							bool flag3 = false;
							ddblLinetypeScale = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag4 = false;
							ddblLinetypeScale = hwpDxf_Vars.pdblLinetypeScale;
						}
						bool flag5 = false;
						rvarLinetypeScale = ddblLinetypeScale;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 60, TextCompare: false))
						{
							rlngVisible = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rlngVisible = Conversions.ToInteger(Interaction.IIf(hwpDxf_Vars.pblnVisible, 0, 1));
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 370, TextCompare: false))
						{
							rnumLineweight = unchecked((Enums.AcLineWeight)Conversions.ToInteger(vobjDictReadValues[rlngIdx]));
							rlngIdx++;
						}
						else
						{
							rnumLineweight = hwpDxf_Vars.pnumEntityLineweight;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], "390", TextCompare: false))
						{
							rstrPlotStyleNameReference = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rstrPlotStyleNameReference = null;
						}
						int plngBytesCount = 0;
						int pclngGrpBytesCount = 92;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], pclngGrpBytesCount, TextCompare: false))
						{
							int rlngBytesCount2 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							int pclngGrpBytes = 310;
							while (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], pclngGrpBytes, TextCompare: false))
							{
								string dstrBytes = Conversions.ToString(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
						}
						else
						{
							int rlngBytesCount2 = plngBytesCount;
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadSymbolTable(AcadDatabase vobjAcadDatabase, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref double rdblObjectID, ref double rdblOwnerID, ref int rlngCount, ref Dictionary<object, object> robjDictXDictionary, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 5, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Referenz in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					rdblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(vobjDictReadValues[rlngIdx]));
					rlngIdx++;
					if (!vobjAcadDatabase.FriendValidObjectID(rdblObjectID, ref nrstrErrMsg))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString(rlngIdx * 2) + " ist ungültig.\n" + nrstrErrMsg;
						dblnError = true;
						double vdblObjectID = rdblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject.ObjectName);
						}
						dobjObjectIDAcadObject = null;
					}
					else
					{
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XDictionary(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictXDictionary, ref nrstrErrMsg);
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 330, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else
							{
								rdblOwnerID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
								if (rdblOwnerID != 0.0)
								{
									nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbSymbolTable", TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 70, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Anzahl in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
									dblnError = true;
								}
								else
								{
									rlngCount = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadSymbolTableRecord(AcadDatabase vobjAcadDatabase, double vdblDefOwnerID, string vstrDXFName, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref double rdblObjectID, ref double rdblOwnerID, ref Dictionary<object, object> robjDictReactors, ref Dictionary<object, object> robjDictXDictionary, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			int dlngGrpHandle = (Operators.CompareString(vstrDXFName, "DIMSTYLE", TextCompare: false) != 0) ? 5 : 105;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 0, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für DXF-Name in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], vstrDXFName, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger DXF-Name in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], dlngGrpHandle, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Referenz in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else
				{
					rdblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(vobjDictReadValues[rlngIdx + 1]));
					rlngIdx += 2;
					if (!vobjAcadDatabase.FriendValidObjectID(rdblObjectID, ref nrstrErrMsg))
					{
						nrstrErrMsg = "Referenz in Zeile " + Conversions.ToString(rlngIdx * 2) + " ist ungültig.\n" + nrstrErrMsg;
						dblnError = true;
						double vdblObjectID = rdblObjectID;
						string nrstrErrMsg2 = "";
						AcadObject dobjObjectIDAcadObject2 = default(AcadObject);
						if (vobjAcadDatabase.FriendObjectIdToObject(vdblObjectID, ref dobjObjectIDAcadObject2, ref nrstrErrMsg2))
						{
							hwpDxf_Functions.BkDXF_DebugPrint(dobjObjectIDAcadObject2.ObjectName);
						}
						dobjObjectIDAcadObject2 = null;
					}
					else
					{
						while (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(vobjDictReadCodes[rlngIdx], 102, TextCompare: false), !dblnError)))
						{
							object left = vobjDictReadValues[rlngIdx];
							if (Operators.ConditionalCompareObjectEqual(left, "{ACAD_REACTORS", TextCompare: false))
							{
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_Reactors(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictReactors, ref nrstrErrMsg);
								continue;
							}
							if (Operators.ConditionalCompareObjectEqual(left, "{ACAD_XDICTIONARY", TextCompare: false))
							{
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XDictionary(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref robjDictXDictionary, ref nrstrErrMsg);
								continue;
							}
							nrstrErrMsg = "Unbekannter Anfang einer Anwendungsgruppe in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 330, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else
							{
								rdblOwnerID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
								if (rdblOwnerID != vdblDefOwnerID)
								{
									nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbSymbolTableRecord", TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
									dblnError = true;
								}
								else
								{
									rlngIdx++;
								}
							}
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadDictionary(Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref int rlngTreatElementsAsHard, ref int rlngMergeStyle, ref Dictionary<object, object> robjDictEntryName, ref Dictionary<object, object> robjDictEntryObjectID, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			robjDictEntryName.Clear();
			robjDictEntryObjectID.Clear();
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbDictionary", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else
				{
					rlngIdx++;
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 280, TextCompare: false))
					{
						rlngTreatElementsAsHard = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
					}
					else
					{
						rlngTreatElementsAsHard = 0;
					}
					double ddblGrpSoftHardOwnerID = Conversions.ToDouble(Interaction.IIf(rlngTreatElementsAsHard == 0, 350, 360));
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 281, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Misch-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						rlngMergeStyle = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						int dlngCount = 1;
						while (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(vobjDictReadCodes[rlngIdx], 3, TextCompare: false), !dblnError)))
						{
							string dstrEntryName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], ddblGrpSoftHardOwnerID, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
								continue;
							}
							double ddblEntryObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							robjDictEntryName.Add(dlngCount, dstrEntryName);
							robjDictEntryObjectID.Add(dlngCount, ddblEntryObjectID);
							dlngCount++;
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadPlotConfiguration(string vstrAcadVer, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref string rstrPlotSettingsName, ref string rstrConfigName, ref string rstrCanonicalMediaName, ref string rstrViewToPlot, ref object[] ravarPaperMarginLowerLeft, ref object[] ravarPaperMarginUpperRight, ref object rvarPaperWidth, ref object rvarPaperHeight, ref object[] ravarPlotOrigin, ref object[] ravarWindowToPlotLowerLeft, ref object[] ravarWindowToPlotUpperRight, ref object rvarCustomScaleNumerator, ref object rvarCustomScaleDenominator, ref int rlngPlotCode70, ref int rlngPaperUnits, ref int rlngPlotRotation, ref int rlngPlotType, ref string rstrStyleSheet, ref int rlngStandardScale, ref object rvarScaleFactor, ref int rlngShadePlotMode, ref int rlngShadePlotResolutionLevel, ref int rlngShadePlotCustomDPI, ref object[] ravarPaperImageOrigin, ref string nrstrErrMsg = "")
		{
			object[] dadecPaperMarginLowerLeft = new object[2];
			double[] dadblPaperMarginLowerLeft = new double[2];
			object[] dadecPaperMarginUpperRight = new object[2];
			double[] dadblPaperMarginUpperRight = new double[2];
			object[] dadecPlotOrigin = new object[2];
			double[] dadblPlotOrigin = new double[2];
			object[] dadecWindowToPlotLowerLeft = new object[2];
			double[] dadblWindowToPlotLowerLeft = new double[2];
			object[] dadecWindowToPlotUpperRight = new object[2];
			double[] dadblWindowToPlotUpperRight = new double[2];
			object[] dadecPaperImageOrigin = new object[2];
			double[] dadblPaperImageOrigin = new double[2];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPlotSettings", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 1, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Name der Ploteinstellungen in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 2, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Druckername in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 4, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierformat in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 6, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Name der Plotansicht in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 40, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Unten Links X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 41, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Unten Links Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 42, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Oben Rechts X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 8], 43, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Oben Rechts Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 9], 44, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Breite des Papiers in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 10], 45, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papierrand Höhe des Papiers in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 11], 46, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotursprung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 12], 47, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotursprung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 13], 48, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotfensterbereich Unten Links X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 27) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 14], 49, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotfensterbereich Unten Links Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 29) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 15], 140, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotfensterbereich Oben Rechts X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 31) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 16], 141, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotfensterbereich Oben Rechts Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 33) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 17], 142, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Druckmaßstab-Zähler in Zeile " + Conversions.ToString(rlngIdx * 2 + 35) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 18], 143, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Druckmaßstab-Nenner in Zeile " + Conversions.ToString(rlngIdx * 2 + 37) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 19], 70, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plot-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 39) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 20], 72, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Papiereinheiten in Zeile " + Conversions.ToString(rlngIdx * 2 + 41) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 21], 73, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plotdrehung in Zeile " + Conversions.ToString(rlngIdx * 2 + 43) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 22], 74, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Plottyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 45) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 23], 7, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Aktuelle Druckvorschrift in Zeile " + Conversions.ToString(rlngIdx * 2 + 47) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 24], 75, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Vorgabeskalierungstyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 49) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 25], 147, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Skalierfaktor in Zeile " + Conversions.ToString(rlngIdx * 2 + 51) + ".";
					dblnError = true;
				}
				else
				{
					rstrPlotSettingsName = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
					rstrConfigName = Conversions.ToString(vobjDictReadValues[rlngIdx + 2]);
					rstrCanonicalMediaName = Conversions.ToString(vobjDictReadValues[rlngIdx + 3]);
					rstrViewToPlot = Conversions.ToString(vobjDictReadValues[rlngIdx + 4]);
					bool flag = false;
					dadblPaperMarginLowerLeft[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
					dadblPaperMarginLowerLeft[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
					dadblPaperMarginUpperRight[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 7]);
					dadblPaperMarginUpperRight[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 8]);
					double ddblPaperWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 9]);
					double ddblPaperHeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 10]);
					dadblPlotOrigin[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 11]);
					dadblPlotOrigin[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 12]);
					dadblWindowToPlotLowerLeft[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 13]);
					dadblWindowToPlotLowerLeft[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 14]);
					dadblWindowToPlotUpperRight[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 15]);
					dadblWindowToPlotUpperRight[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 16]);
					double ddblCustomScaleNumerator = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 17]);
					double ddblCustomScaleDenominator = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 18]);
					ravarPaperMarginLowerLeft[0] = dadblPaperMarginLowerLeft[0];
					ravarPaperMarginLowerLeft[1] = dadblPaperMarginLowerLeft[1];
					ravarPaperMarginUpperRight[0] = dadblPaperMarginUpperRight[0];
					ravarPaperMarginUpperRight[1] = dadblPaperMarginUpperRight[1];
					rvarPaperWidth = ddblPaperWidth;
					rvarPaperHeight = ddblPaperHeight;
					ravarPlotOrigin[0] = dadblPlotOrigin[0];
					ravarPlotOrigin[1] = dadblPlotOrigin[1];
					ravarWindowToPlotLowerLeft[0] = dadblWindowToPlotLowerLeft[0];
					ravarWindowToPlotLowerLeft[1] = dadblWindowToPlotLowerLeft[1];
					ravarWindowToPlotUpperRight[0] = dadblWindowToPlotUpperRight[0];
					ravarWindowToPlotUpperRight[1] = dadblWindowToPlotUpperRight[1];
					rvarCustomScaleNumerator = ddblCustomScaleNumerator;
					rvarCustomScaleDenominator = ddblCustomScaleDenominator;
					rlngPlotCode70 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 19]);
					rlngPaperUnits = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 20]);
					rlngPlotRotation = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 21]);
					rlngPlotType = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 22]);
					rstrStyleSheet = Conversions.ToString(vobjDictReadValues[rlngIdx + 23]);
					rlngStandardScale = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 24]);
					bool flag2 = false;
					double ddblScaleFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 25]);
					rvarScaleFactor = ddblScaleFactor;
					rlngIdx += 26;
					if (Operators.CompareString(vstrAcadVer, "AC1018", TextCompare: false) >= 0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 76, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Modus für das Plotten von Schattierungen in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 77, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Auflösungsstufe für das Plotten von Schattierungen in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 78, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für benuzterdefinierte Auflösung für das Plotten von Schattierungen in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else
						{
							rlngShadePlotMode = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngShadePlotResolutionLevel = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
							rlngShadePlotCustomDPI = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
							rlngIdx += 3;
						}
					}
					else
					{
						rlngShadePlotMode = hwpDxf_Vars.plngShadePlotMode;
						rlngShadePlotResolutionLevel = hwpDxf_Vars.plngShadePlotResolutionLevel;
						rlngShadePlotCustomDPI = hwpDxf_Vars.plngShadePlotCustomDPI;
					}
					if (!dblnError)
					{
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 148, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Ursprung des Papierbilds X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 149, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Ursprung des Papierbilds Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							bool flag3 = false;
							dadblPaperImageOrigin[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dadblPaperImageOrigin[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							ravarPaperImageOrigin[0] = dadblPaperImageOrigin[0];
							ravarPaperImageOrigin[1] = dadblPaperImageOrigin[1];
							rlngIdx += 2;
						}
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadCircle(Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref object rvarThickness, ref object[] ravarCenter, ref object rvarRadius, ref string nrstrErrMsg = "")
		{
			object[] dadecCenter = new object[3];
			double[] dadblCenter = new double[3];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbCircle", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else
				{
					rlngIdx++;
					double ddblThickness;
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
					{
						bool flag = false;
						ddblThickness = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
					}
					else
					{
						bool flag2 = false;
						ddblThickness = hwpDxf_Vars.pdblThickness;
					}
					bool flag3 = false;
					rvarThickness = ddblThickness;
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Radius in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else
					{
						bool flag4 = false;
						dadblCenter[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
						dadblCenter[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblCenter[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						double ddblRadius = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						ravarCenter[0] = dadblCenter[0];
						ravarCenter[1] = dadblCenter[1];
						ravarCenter[2] = dadblCenter[2];
						rvarRadius = ddblRadius;
						rlngIdx += 4;
					}
				}
				return !dblnError;
			}
		}

		public static bool BkDXFReadRef_AcadText(Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref int rlngIdx, ref object rvarThickness, ref object ravarInsertionPoint, ref object rvarHeight, ref string rstrTextString, ref object rvarRotationDegree, ref object rvarScaleFactor, ref object rvarObliqueAngleDegree, ref string rstrTextStyle, ref int rlngTextGenerationFlag, ref int rlngHorizontalAlignment, ref object ravarTextAlignmentPoint, ref object ravarNormal, ref string nrstrErrMsg = "")
		{
			object[] dadecInsertionPoint = new object[3];
			double[] dadblInsertionPoint = new double[3];
			object[] dadecTextAlignmentPoint = new object[3];
			double[] dadblTextAlignmentPoint = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbText", TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
					dblnError = true;
				}
				else
				{
					rlngIdx++;
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
					{
						bool flag = false;
						double ddblThickness2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
						rvarThickness = ddblThickness2;
						rlngIdx++;
					}
					else
					{
						bool flag2 = false;
						double ddblThickness2 = hwpDxf_Vars.pdblThickness;
						rvarThickness = ddblThickness2;
					}
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Texthöhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 1, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zeichenfolge in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else
					{
						bool flag3 = false;
						dadblInsertionPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
						dadblInsertionPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblInsertionPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						double ddblHeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						NewLateBinding.LateIndexSet(ravarInsertionPoint, new object[2]
						{
						0,
						dadblInsertionPoint[0]
						}, null);
						NewLateBinding.LateIndexSet(ravarInsertionPoint, new object[2]
						{
						1,
						dadblInsertionPoint[1]
						}, null);
						NewLateBinding.LateIndexSet(ravarInsertionPoint, new object[2]
						{
						2,
						dadblInsertionPoint[2]
						}, null);
						rvarHeight = ddblHeight;
						rstrTextString = Conversions.ToString(vobjDictReadValues[rlngIdx + 4]);
						rlngIdx += 5;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
						{
							bool flag4 = false;
							double ddblRotationDegree2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rvarRotationDegree = ddblRotationDegree2;
							rlngIdx++;
						}
						else
						{
							bool flag5 = false;
							double ddblRotationDegree2 = hwpDxf_Vars.pdblRotationDegree;
							rvarRotationDegree = ddblRotationDegree2;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
						{
							bool flag6 = false;
							double ddblScaleFactor2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rvarScaleFactor = ddblScaleFactor2;
							rlngIdx++;
						}
						else
						{
							bool flag7 = false;
							double ddblScaleFactor2 = hwpDxf_Vars.pdblScaleFactor;
							rvarScaleFactor = ddblScaleFactor2;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 51, TextCompare: false))
						{
							bool flag8 = false;
							double ddblObliqueAngleDegree2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rvarObliqueAngleDegree = ddblObliqueAngleDegree2;
							rlngIdx++;
						}
						else
						{
							bool flag9 = false;
							double ddblObliqueAngleDegree2 = hwpDxf_Vars.pdblObliqueAngleDegree;
							rvarObliqueAngleDegree = ddblObliqueAngleDegree2;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 7, TextCompare: false))
						{
							rstrTextStyle = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rstrTextStyle = hwpDxf_Vars.pstrTextStyleName;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 71, TextCompare: false))
						{
							rlngTextGenerationFlag = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rlngTextGenerationFlag = unchecked((int)hwpDxf_Vars.pnumTextGenerationFlag);
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 72, TextCompare: false))
						{
							rlngHorizontalAlignment = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							rlngHorizontalAlignment = 0;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 11, TextCompare: false))
						{
							bool flag10 = false;
							dadblTextAlignmentPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 21, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Ausrichtungspunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 31, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Ausrichtungspunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else
							{
								bool flag11 = false;
								dadblTextAlignmentPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblTextAlignmentPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
								{
								0,
								dadblTextAlignmentPoint[0]
								}, null);
								NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
								{
								1,
								dadblTextAlignmentPoint[1]
								}, null);
								NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
								{
								2,
								dadblTextAlignmentPoint[2]
								}, null);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag12 = false;
							dadblTextAlignmentPoint[0] = hwpDxf_Vars.padblTextAlignmentPoint[0];
							dadblTextAlignmentPoint[1] = hwpDxf_Vars.padblTextAlignmentPoint[1];
							dadblTextAlignmentPoint[2] = hwpDxf_Vars.padblTextAlignmentPoint[2];
							NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
							{
							0,
							dadblTextAlignmentPoint[0]
							}, null);
							NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
							{
							1,
							dadblTextAlignmentPoint[1]
							}, null);
							NewLateBinding.LateIndexSet(ravarTextAlignmentPoint, new object[2]
							{
							2,
							dadblTextAlignmentPoint[2]
							}, null);
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag13 = false;
								dadblNormal[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
								if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 220, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Extrusionsrichtung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 230, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Extrusionsrichtung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
									dblnError = true;
								}
								else
								{
									bool flag14 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									NewLateBinding.LateIndexSet(ravarNormal, new object[2]
									{
									0,
									dadblNormal[0]
									}, null);
									NewLateBinding.LateIndexSet(ravarNormal, new object[2]
									{
									1,
									dadblNormal[1]
									}, null);
									NewLateBinding.LateIndexSet(ravarNormal, new object[2]
									{
									2,
									dadblNormal[2]
									}, null);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag15 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
								NewLateBinding.LateIndexSet(ravarNormal, new object[2]
								{
								0,
								dadblNormal[0]
								}, null);
								NewLateBinding.LateIndexSet(ravarNormal, new object[2]
								{
								1,
								dadblNormal[1]
								}, null);
								NewLateBinding.LateIndexSet(ravarNormal, new object[2]
								{
								2,
								dadblNormal[2]
								}, null);
							}
						}
					}
				}
				return !dblnError;
			}
		}
	}
}
