using DXFLib.Acad;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Compatibility.VB6;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_ReadEnt
	{
		public static bool BkDXFReadEnt_CheckBlockAsOwner(AcadDatabase vobjAcadDatabase, ref AcadBlock robjAcadBlock, double vdblOwnerID, double vdblLineOwnerID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (robjAcadBlock == null)
			{
				string nrstrErrMsg2 = "";
				if (!vobjAcadDatabase.FriendObjectIdToObject(vdblOwnerID, ref dobjAcadObject2, ref nrstrErrMsg2))
				{
					nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt kann nicht gefunden werden.";
					dblnError = true;
				}
				else
				{
					try
					{
						robjAcadBlock = (AcadBlock)dobjAcadObject2;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt ist ungültig.";
						dblnError = true;
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (robjAcadBlock.ObjectID != vdblOwnerID)
			{
				nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".";
				dblnError = true;
			}
			bool BkDXFReadEnt_CheckBlockAsOwner = !dblnError;
			dobjAcadObject2 = null;
			return BkDXFReadEnt_CheckBlockAsOwner;
		}

		public static bool BkDXFReadEnt_CheckPolylineAsOwner(AcadDatabase vobjAcadDatabase, ref AcadPolyline robjAcadPolyline, double vdblOwnerID, double vdblLineOwnerID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (robjAcadPolyline == null)
			{
				string nrstrErrMsg2 = "";
				if (!vobjAcadDatabase.FriendObjectIdToObject(vdblOwnerID, ref dobjAcadObject2, ref nrstrErrMsg2))
				{
					nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt kann nicht gefunden werden.";
					dblnError = true;
				}
				else
				{
					try
					{
						robjAcadPolyline = (AcadPolyline)dobjAcadObject2;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt ist ungültig.";
						dblnError = true;
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (robjAcadPolyline.ObjectID != vdblOwnerID)
			{
				nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".";
				dblnError = true;
			}
			bool BkDXFReadEnt_CheckPolylineAsOwner = !dblnError;
			dobjAcadObject2 = null;
			return BkDXFReadEnt_CheckPolylineAsOwner;
		}

		public static bool BkDXFReadEnt_Check3DPolylineAsOwner(AcadDatabase vobjAcadDatabase, ref Acad3DPolyline robjAcad3DPolyline, double vdblOwnerID, double vdblLineOwnerID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (robjAcad3DPolyline == null)
			{
				string nrstrErrMsg2 = "";
				if (!vobjAcadDatabase.FriendObjectIdToObject(vdblOwnerID, ref dobjAcadObject2, ref nrstrErrMsg2))
				{
					nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt kann nicht gefunden werden.";
					dblnError = true;
				}
				else
				{
					try
					{
						robjAcad3DPolyline = (Acad3DPolyline)dobjAcadObject2;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt ist ungültig.";
						dblnError = true;
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (robjAcad3DPolyline.ObjectID != vdblOwnerID)
			{
				nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".";
				dblnError = true;
			}
			bool BkDXFReadEnt_Check3DPolylineAsOwner = !dblnError;
			dobjAcadObject2 = null;
			return BkDXFReadEnt_Check3DPolylineAsOwner;
		}

		public static bool BkDXFReadEnt_CheckPolygonMeshAsOwner(AcadDatabase vobjAcadDatabase, ref AcadPolygonMesh robjAcadPolygonMesh, double vdblOwnerID, double vdblLineOwnerID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (robjAcadPolygonMesh == null)
			{
				string nrstrErrMsg2 = "";
				if (!vobjAcadDatabase.FriendObjectIdToObject(vdblOwnerID, ref dobjAcadObject2, ref nrstrErrMsg2))
				{
					nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt kann nicht gefunden werden.";
					dblnError = true;
				}
				else
				{
					try
					{
						robjAcadPolygonMesh = (AcadPolygonMesh)dobjAcadObject2;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt ist ungültig.";
						dblnError = true;
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (robjAcadPolygonMesh.ObjectID != vdblOwnerID)
			{
				nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".";
				dblnError = true;
			}
			bool BkDXFReadEnt_CheckPolygonMeshAsOwner = !dblnError;
			dobjAcadObject2 = null;
			return BkDXFReadEnt_CheckPolygonMeshAsOwner;
		}

		public static bool BkDXFReadEnt_CheckPolyfaceMeshAsOwner(AcadDatabase vobjAcadDatabase, ref AcadPolyfaceMesh robjAcadPolyfaceMesh, double vdblOwnerID, double vdblLineOwnerID, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (robjAcadPolyfaceMesh == null)
			{
				string nrstrErrMsg2 = "";
				if (!vobjAcadDatabase.FriendObjectIdToObject(vdblOwnerID, ref dobjAcadObject2, ref nrstrErrMsg2))
				{
					nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt kann nicht gefunden werden.";
					dblnError = true;
				}
				else
				{
					try
					{
						robjAcadPolyfaceMesh = (AcadPolyfaceMesh)dobjAcadObject2;
					}
					catch (Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						Exception ex = ex2;
						nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".\nDas referenzierte Objekt ist ungültig.";
						dblnError = true;
						ProjectData.ClearProjectError();
					}
				}
			}
			else if (robjAcadPolyfaceMesh.ObjectID != vdblOwnerID)
			{
				nrstrErrMsg = "Ungültige Objekt-ID (Eigentümer) '" + Conversions.ToString(vdblOwnerID) + "' in Zeile " + Conversions.ToString(vdblLineOwnerID) + ".";
				dblnError = true;
			}
			bool BkDXFReadEnt_CheckPolyfaceMeshAsOwner = !dblnError;
			dobjAcadObject2 = null;
			return BkDXFReadEnt_CheckPolyfaceMeshAsOwner;
		}

		public static bool BkDXFReadEnt_AcadCircle(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarCenter = new object[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			double ddblLineOwnerID = default(double);
			int dlngPaperSpace = default(int);
			string dstrLayer = default(string);
			string dstrLineType = default(string);
			int dlngColor = default(int);
			object dvarLinetypeScale = default(object);
			int dlngVisible = default(int);
			int dlngRGB = default(int);
			Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
			string dstrPlotStyleNameReference = default(string);
			object dvarThickness = default(object);
			object dvarRadius = default(object);
			bool BkDXFReadEnt_AcadCircle = default(bool);
			AcadCircle dobjAcadCircle2;
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadCircle(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dvarThickness, ref davarCenter, ref dvarRadius, ref nrstrErrMsg))
			{
				bool dblnError = default(bool);
				checked
				{
					if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
					{
						bool flag = false;
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
							bool flag2 = false;
							dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
						}
					}
					else
					{
						bool flag3 = false;
						dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
						dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
						dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
					}
				}
				if (!dblnError)
				{
					object dvarXDataType = default(object);
					object dvarXDataValue = default(object);
					dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
					if (!dblnError)
					{
						dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
						if (!dblnError)
						{
							dobjAcadCircle2 = robjAcadBlock.FriendAddAcadObjectCircle(ddblObjectID, davarCenter, RuntimeHelpers.GetObjectValue(dvarRadius), ref nrstrErrMsg);
							if (dobjAcadCircle2 == null)
							{
								nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
								dblnError = true;
							}
							else
							{
								AcadCircle acadCircle = dobjAcadCircle2;
								acadCircle.FriendSetDictReactors = dobjDictReactors2;
								acadCircle.FriendSetDictXDictionary = dobjDictXDictionary2;
								acadCircle.Layer = dstrLayer;
								acadCircle.Linetype = dstrLineType;
								acadCircle.Color = (Enums.AcColor)dlngColor;
								acadCircle.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
								acadCircle.Visible = (dlngVisible == 0);
								acadCircle.FriendLetRGB = dlngRGB;
								acadCircle.Lineweight = dnumLineweight;
								acadCircle.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
								acadCircle.Thickness = RuntimeHelpers.GetObjectValue(dvarThickness);
								bool flag4 = false;
								acadCircle.Normal = Support.CopyArray(dadblNormal);
								acadCircle.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
								acadCircle = null;
							}
						}
					}
				}
				BkDXFReadEnt_AcadCircle = !dblnError;
			}
			dobjAcadCircle2 = null;
			dobjDictXDictionary2 = null;
			dobjDictReactors2 = null;
			return BkDXFReadEnt_AcadCircle;
		}

		public static bool BkDXFReadEnt_AcadArc(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarCenter = new object[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				object dvarThickness = default(object);
				object dvarRadius = default(object);
				bool BkDXFReadEnt_AcadArc = default(bool);
				AcadArc dobjAcadArc2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadCircle(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dvarThickness, ref davarCenter, ref dvarRadius, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbArc", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 50, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Startwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 51, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Endwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						double ddblStartAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						double ddblEndAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag2 = false;
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
								bool flag3 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag4 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
								if (!dblnError)
								{
									object ddecStartAngleDegree = default(object);
									object ddecEndAngleDegree = default(object);
									dobjAcadArc2 = robjAcadBlock.FriendAddAcadObjectArc(ddblObjectID, davarCenter, RuntimeHelpers.GetObjectValue(dvarRadius), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecStartAngleDegree), ddblStartAngleDegree)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecEndAngleDegree), ddblEndAngleDegree)), vblnAngleInDegree: true, ref nrstrErrMsg);
									if (dobjAcadArc2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadArc acadArc = dobjAcadArc2;
										acadArc.FriendSetDictReactors = dobjDictReactors2;
										acadArc.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadArc.Layer = dstrLayer;
										acadArc.Linetype = dstrLineType;
										acadArc.Color = unchecked((Enums.AcColor)dlngColor);
										acadArc.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
										acadArc.Visible = (dlngVisible == 0);
										acadArc.FriendLetRGB = dlngRGB;
										acadArc.Lineweight = dnumLineweight;
										acadArc.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
										acadArc.Thickness = RuntimeHelpers.GetObjectValue(dvarThickness);
										bool flag5 = false;
										acadArc.Normal = Support.CopyArray(dadblNormal);
										acadArc.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadArc = null;
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadArc = !dblnError;
				}
				dobjAcadArc2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadArc;
			}
		}

		public static bool BkDXFReadEnt_AcadLine(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecStartPoint = new object[3];
			double[] dadblStartPoint = new double[3];
			object[] dadecEndPoint = new object[3];
			double[] dadblEndPoint = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadLine = default(bool);
				AcadLine dobjAcadLine2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbLine", TextCompare: false))
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
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 11, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 21, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 31, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
							dblnError = true;
						}
						else
						{
							bool flag3 = false;
							dadblStartPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dadblStartPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							dadblStartPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
							dadblEndPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
							dadblEndPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
							dadblEndPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
							rlngIdx += 6;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag4 = false;
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
									bool flag5 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag6 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							if (!dblnError)
							{
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadLine2 = robjAcadBlock.FriendAddAcadObjectLine(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecStartPoint, dadblStartPoint)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecEndPoint, dadblEndPoint)), ref nrstrErrMsg);
										if (dobjAcadLine2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadLine acadLine = dobjAcadLine2;
											acadLine.FriendSetDictReactors = dobjDictReactors2;
											acadLine.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadLine.Layer = dstrLayer;
											acadLine.Linetype = dstrLineType;
											acadLine.Color = unchecked((Enums.AcColor)dlngColor);
											acadLine.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadLine.Visible = (dlngVisible == 0);
											acadLine.FriendLetRGB = dlngRGB;
											acadLine.Lineweight = dnumLineweight;
											acadLine.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											bool flag7 = false;
											acadLine.Thickness = ddblThickness;
											acadLine.Normal = Support.CopyArray(dadblNormal);
											acadLine.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadLine = null;
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadLine = !dblnError;
				}
				dobjAcadLine2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadLine;
			}
		}

		public static bool BkDXFReadEnt_AcadPoint(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadPoint = default(bool);
				AcadPoint dobjAcadPoint2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPoint", TextCompare: false))
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
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else
						{
							bool flag3 = false;
							dadblCoordinate[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dadblCoordinate[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							dadblCoordinate[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
							rlngIdx += 3;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag4 = false;
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
									bool flag5 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag6 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							if (!dblnError)
							{
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadPoint2 = robjAcadBlock.FriendAddAcadObjectPoint(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate)), ref nrstrErrMsg);
										if (dobjAcadPoint2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadPoint acadPoint = dobjAcadPoint2;
											acadPoint.FriendSetDictReactors = dobjDictReactors2;
											acadPoint.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadPoint.Layer = dstrLayer;
											acadPoint.Linetype = dstrLineType;
											acadPoint.Color = unchecked((Enums.AcColor)dlngColor);
											acadPoint.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadPoint.Visible = (dlngVisible == 0);
											acadPoint.FriendLetRGB = dlngRGB;
											acadPoint.Lineweight = dnumLineweight;
											acadPoint.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											bool flag7 = false;
											acadPoint.Thickness = ddblThickness;
											acadPoint.Normal = Support.CopyArray(dadblNormal);
											acadPoint.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadPoint = null;
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadPoint = !dblnError;
				}
				dobjAcadPoint2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadPoint;
			}
		}

		public static bool BkDXFReadEnt_AcadXline(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecBasePoint = new object[3];
			double[] dadblBasePoint = new double[3];
			object[] dadecDirectionVector = new object[3];
			double[] dadblDirectionVector = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadXline = default(bool);
				AcadXline dobjAcadXline2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbXline", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblBasePoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblBasePoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						dadblBasePoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						dadblDirectionVector[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						dadblDirectionVector[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						dadblDirectionVector[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
						rlngIdx += 7;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
							if (!dblnError)
							{
								bool flag2 = false;
								object dvarSecondPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(dadblBasePoint, dadblDirectionVector));
								dobjAcadXline2 = robjAcadBlock.FriendAddAcadObjectXline(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecBasePoint, dadblBasePoint)), RuntimeHelpers.GetObjectValue(dvarSecondPoint), ref nrstrErrMsg);
								if (dobjAcadXline2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadXline acadXline = dobjAcadXline2;
									acadXline.FriendSetDictReactors = dobjDictReactors2;
									acadXline.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadXline.Layer = dstrLayer;
									acadXline.Linetype = dstrLineType;
									acadXline.Color = unchecked((Enums.AcColor)dlngColor);
									acadXline.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
									acadXline.Visible = (dlngVisible == 0);
									acadXline.FriendLetRGB = dlngRGB;
									acadXline.Lineweight = dnumLineweight;
									acadXline.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
									acadXline.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadXline = null;
								}
							}
						}
					}
					BkDXFReadEnt_AcadXline = !dblnError;
				}
				dobjAcadXline2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadXline;
			}
		}

		public static bool BkDXFReadEnt_AcadRay(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecBasePoint = new object[3];
			double[] dadblBasePoint = new double[3];
			object[] dadecDirectionVector = new object[3];
			double[] dadblDirectionVector = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadRay = default(bool);
				AcadRay dobjAcadRay2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbRay", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung des Einheitsvektors Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblBasePoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblBasePoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						dadblBasePoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						dadblDirectionVector[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						dadblDirectionVector[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						dadblDirectionVector[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
						rlngIdx += 7;
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
							if (!dblnError)
							{
								bool flag2 = false;
								object dvarSecondPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(dadblBasePoint, dadblDirectionVector));
								dobjAcadRay2 = robjAcadBlock.FriendAddAcadObjectRay(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecBasePoint, dadblBasePoint)), RuntimeHelpers.GetObjectValue(dvarSecondPoint), ref nrstrErrMsg);
								if (dobjAcadRay2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadRay acadRay = dobjAcadRay2;
									acadRay.FriendSetDictReactors = dobjDictReactors2;
									acadRay.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadRay.Layer = dstrLayer;
									acadRay.Linetype = dstrLineType;
									acadRay.Color = unchecked((Enums.AcColor)dlngColor);
									acadRay.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
									acadRay.Visible = (dlngVisible == 0);
									acadRay.FriendLetRGB = dlngRGB;
									acadRay.Lineweight = dnumLineweight;
									acadRay.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
									acadRay.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadRay = null;
								}
							}
						}
					}
					BkDXFReadEnt_AcadRay = !dblnError;
				}
				dobjAcadRay2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadRay;
			}
		}

		public static bool BkDXFReadEnt_AcadLWPolyline(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadLWPolyline = default(bool);
				AcadLWPolyline dobjAcadLWPolyline2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPolyline", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 90, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Scheitelpunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else
					{
						int dlngNumVerts = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						double ddblConstantWidth;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 43, TextCompare: false))
						{
							bool flag = false;
							ddblConstantWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag2 = false;
							ddblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
						}
						double ddblElevation;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 38, TextCompare: false))
						{
							bool flag3 = false;
							ddblElevation = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag4 = false;
							ddblElevation = hwpDxf_Vars.pdblElevation;
						}
						double ddblThickness;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
						{
							bool flag5 = false;
							ddblThickness = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag6 = false;
							ddblThickness = hwpDxf_Vars.pdblThickness;
						}
						bool flag7 = false;
						double[] dadblVerticesList = new double[dlngNumVerts * 2 - 1 + 1];
						double[] dadblStartWidthList = new double[dlngNumVerts - 1 + 1];
						double[] dadblEndWidthList = new double[dlngNumVerts - 1 + 1];
						double[] dadblBulgeList = new double[dlngNumVerts - 1 + 1];
						int dlngVertexIdx2 = 0;
						while (unchecked(dlngVertexIdx2 < dlngNumVerts && !dblnError))
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Koordinaten des Scheitelpunkts X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
								continue;
							}
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Koordinaten des Scheitelpunkts Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
								continue;
							}
							bool flag8 = false;
							double ddblVertexX = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							double ddblVertexY = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
							double ddblStartWidth;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 40, TextCompare: false))
							{
								bool flag9 = false;
								ddblStartWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag10 = false;
								ddblStartWidth = ddblConstantWidth;
							}
							double ddblEndWidth;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
							{
								bool flag11 = false;
								ddblEndWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag12 = false;
								ddblEndWidth = ddblConstantWidth;
							}
							double ddblBulge;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
							{
								bool flag13 = false;
								ddblBulge = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag14 = false;
								ddblBulge = hwpDxf_Vars.pdblBulge;
							}
							bool flag15 = false;
							dadblVerticesList[dlngVertexIdx2 * 2] = ddblVertexX;
							dadblVerticesList[dlngVertexIdx2 * 2 + 1] = ddblVertexY;
							dadblStartWidthList[dlngVertexIdx2] = ddblStartWidth;
							dadblEndWidthList[dlngVertexIdx2] = ddblEndWidth;
							dadblBulgeList[dlngVertexIdx2] = ddblBulge;
							dlngVertexIdx2++;
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag16 = false;
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
									bool flag17 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag18 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							if (!dblnError)
							{
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										hwpDxf_Vars.pblnAddLWPolylineStopCalcSize = true;
										object[] dadecVerticesList = default(object[]);
										dobjAcadLWPolyline2 = robjAcadBlock.FriendAddAcadObjectLWPolyline(ref nrstrErrMsg, ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecVerticesList, dadblVerticesList)));
										if (dobjAcadLWPolyline2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadLWPolyline acadLWPolyline = dobjAcadLWPolyline2;
											acadLWPolyline.FriendCalcSizeStop = true;
											acadLWPolyline.FriendSetDictReactors = dobjDictReactors2;
											acadLWPolyline.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadLWPolyline.Layer = dstrLayer;
											acadLWPolyline.Linetype = dstrLineType;
											acadLWPolyline.Color = unchecked((Enums.AcColor)dlngColor);
											acadLWPolyline.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadLWPolyline.Visible = (dlngVisible == 0);
											acadLWPolyline.FriendLetRGB = dlngRGB;
											acadLWPolyline.Lineweight = dnumLineweight;
											acadLWPolyline.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											acadLWPolyline.FriendLetFlags70 = dlngCode70;
											bool flag19 = false;
											acadLWPolyline.ConstantWidth = ddblConstantWidth;
											acadLWPolyline.Elevation = ddblElevation;
											acadLWPolyline.Thickness = ddblThickness;
											acadLWPolyline.Normal = Support.CopyArray(dadblNormal);
											int num = dlngNumVerts - 1;
											for (dlngVertexIdx2 = 0; dlngVertexIdx2 <= num; dlngVertexIdx2++)
											{
												acadLWPolyline.SetWidth(dlngVertexIdx2, dadblStartWidthList[dlngVertexIdx2], dadblEndWidthList[dlngVertexIdx2]);
												acadLWPolyline.SetBulge(dlngVertexIdx2, dadblBulgeList[dlngVertexIdx2]);
											}
											acadLWPolyline.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadLWPolyline.FriendCalcSizeStop = false;
											acadLWPolyline.FriendCalcSize();
											acadLWPolyline = null;
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadLWPolyline = !dblnError;
				}
				dobjAcadLWPolyline2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadLWPolyline;
			}
		}

		public static bool BkDXFReadEnt_AcadPolyline(ref AcadPolyline robjAcadPolyline, ref Acad3DPolyline robjAcad3DPolyline, ref AcadPolygonMesh robjAcadPolygonMesh, ref AcadPolyfaceMesh robjAcadPolyfaceMesh, AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadPolyline = default(bool);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDb2dPolyline", TextCompare: false), Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDb3dPolyline", TextCompare: false)), Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPolygonMesh", TextCompare: false)), Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPolyFaceMesh", TextCompare: false))))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						string dstrObjectName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 66, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Flags66 in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Code10 in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Code20 in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Erhebung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else
						{
							int dlngFlags66 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							bool flag = false;
							double ddblCode10 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							double ddblCode11 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
							double ddblCode12 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
							double ddblElevation = ddblCode12;
							rlngIdx += 4;
							double ddblThickness = default(double);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDb2dPolyline", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Objekthöhe) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									bool flag2 = false;
									ddblThickness = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								bool flag3 = false;
								ddblThickness = hwpDxf_Vars.pdblThickness;
							}
							int dlngFlags67;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
							{
								dlngFlags67 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngFlags67 = 0;
							}
							double ddblStartWidth = default(double);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 40, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDb2dPolyline", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Startbreite) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									bool flag4 = false;
									ddblStartWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								bool flag5 = false;
								ddblStartWidth = hwpDxf_Vars.pdblStartWidth;
							}
							double ddblEndWidth = default(double);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDb2dPolyline", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Endbreite) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									bool flag6 = false;
									ddblEndWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								bool flag7 = false;
								ddblEndWidth = hwpDxf_Vars.pdblEndWidth;
							}
							int dlngMVertexCountNumberOfVertices = default(int);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 71, TextCompare: false))
							{
								if ((Operators.CompareString(dstrObjectName, "AcDbPolygonMesh", TextCompare: false) != 0) & (Operators.CompareString(dstrObjectName, "AcDbPolyFaceMesh", TextCompare: false) != 0))
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Anzahl Kontrollpunkte in M-Richtung/Anzahl Stützpunkte) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dlngMVertexCountNumberOfVertices = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								dlngMVertexCountNumberOfVertices = hwpDxf_Vars.plngMVertexCountNumberOfVertices;
							}
							int dlngNVertexCountNumberOfFaces = default(int);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 72, TextCompare: false))
							{
								if ((Operators.CompareString(dstrObjectName, "AcDbPolygonMesh", TextCompare: false) != 0) & (Operators.CompareString(dstrObjectName, "AcDbPolyFaceMesh", TextCompare: false) != 0))
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Anzahl Kontrollpunkte in N-Richtung/Anzahl Flächen) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dlngNVertexCountNumberOfFaces = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								dlngNVertexCountNumberOfFaces = hwpDxf_Vars.plngNVertexCountNumberOfFaces;
							}
							int dlngMDensity = default(int);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDbPolygonMesh", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Oberflächendichte in N-Richtung) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dlngMDensity = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								dlngMDensity = hwpDxf_Vars.plngMDensity;
							}
							int dlngNDensity = default(int);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 74, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDbPolygonMesh", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Oberflächendichte in N-Richtung) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dlngNDensity = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								dlngNDensity = hwpDxf_Vars.plngNDensity;
							}
							int dlngSplineType = default(int);
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 75, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDbPolyFaceMesh", TextCompare: false) == 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Kurventyp) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									dlngSplineType = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
							}
							else
							{
								dlngSplineType = 0;
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								if (Operators.CompareString(dstrObjectName, "AcDb2dPolyline", TextCompare: false) != 0)
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Extrusionsrichtung) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									bool flag8 = false;
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
										bool flag9 = false;
										dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
										rlngIdx += 2;
									}
								}
							}
							else
							{
								bool flag10 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							unchecked
							{
								if (!dblnError)
								{
									object dvarXDataType = default(object);
									object dvarXDataValue = default(object);
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
									if (!dblnError)
									{
										dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
										if (!dblnError)
										{
											switch (dstrObjectName)
											{
												case "AcDb2dPolyline":
													{
														hwpDxf_Vars.pblnAddPolylineStopCalcSize = true;
														robjAcadPolyline = robjAcadBlock.FriendAddAcadObjectPolyline(ref nrstrErrMsg, ddblObjectID, null);
														if (robjAcadPolyline == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadPolyline acadPolyline = robjAcadPolyline;
														acadPolyline.FriendCalcSizeStop = true;
														acadPolyline.FriendSetDictReactors = dobjDictReactors2;
														acadPolyline.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadPolyline.Layer = dstrLayer;
														acadPolyline.Linetype = dstrLineType;
														acadPolyline.Color = (Enums.AcColor)dlngColor;
														acadPolyline.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadPolyline.Visible = (dlngVisible == 0);
														acadPolyline.FriendLetRGB = dlngRGB;
														acadPolyline.Lineweight = dnumLineweight;
														acadPolyline.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadPolyline.FriendLetFlags66 = dlngFlags66;
														acadPolyline.SplineType = dlngSplineType;
														acadPolyline.FriendLetFlags70 = dlngFlags67;
														bool flag11 = false;
														acadPolyline.Elevation = ddblElevation;
														acadPolyline.Thickness = ddblThickness;
														acadPolyline.StartWidth = ddblStartWidth;
														acadPolyline.EndWidth = ddblEndWidth;
														acadPolyline.Normal = Support.CopyArray(dadblNormal);
														if (dlngFlags67 != acadPolyline.Flags70)
														{
															Debug.Print("Polyline Flag:    " + Conversions.ToString(dlngFlags67) + " -> " + Conversions.ToString(acadPolyline.Flags70));
														}
														if (dlngSplineType != acadPolyline.SplineType)
														{
															Debug.Print("Polyline SplineType:    " + Conversions.ToString(dlngSplineType) + " -> " + Conversions.ToString(acadPolyline.SplineType));
														}
														acadPolyline.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadPolyline = null;
														break;
													}
												case "AcDb3dPolyline":
													{
														hwpDxf_Vars.pblnAdd3DPolylineStopCalcSize = true;
														robjAcad3DPolyline = robjAcadBlock.FriendAddAcadObject3DPolyline(ref nrstrErrMsg, ddblObjectID, null);
														if (robjAcad3DPolyline == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														Acad3DPolyline acad3DPolyline = robjAcad3DPolyline;
														acad3DPolyline.FriendCalcSizeStop = true;
														acad3DPolyline.FriendSetDictReactors = dobjDictReactors2;
														acad3DPolyline.FriendSetDictXDictionary = dobjDictXDictionary2;
														acad3DPolyline.Layer = dstrLayer;
														acad3DPolyline.Linetype = dstrLineType;
														acad3DPolyline.Color = (Enums.AcColor)dlngColor;
														acad3DPolyline.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acad3DPolyline.Visible = (dlngVisible == 0);
														acad3DPolyline.FriendLetRGB = dlngRGB;
														acad3DPolyline.Lineweight = dnumLineweight;
														acad3DPolyline.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acad3DPolyline.FriendLetFlags66 = dlngFlags66;
														acad3DPolyline.SplineType = dlngSplineType;
														acad3DPolyline.FriendLetFlags70 = dlngFlags67;
														if (dlngFlags67 != acad3DPolyline.Flags70)
														{
															Debug.Print("3D-Polyline Flag: " + Conversions.ToString(dlngFlags67) + " -> " + Conversions.ToString(acad3DPolyline.Flags70));
														}
														if (dlngSplineType != acad3DPolyline.SplineType)
														{
															Debug.Print("3D-Polyline SplineType: " + Conversions.ToString(dlngSplineType) + " -> " + Conversions.ToString(acad3DPolyline.SplineType));
														}
														acad3DPolyline.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acad3DPolyline = null;
														break;
													}
												case "AcDbPolygonMesh":
													{
														robjAcadPolygonMesh = robjAcadBlock.FriendAddAcadObjectPolygonMesh(ref nrstrErrMsg, ddblObjectID, 0, 0, null);
														if (robjAcadPolygonMesh == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadPolygonMesh acadPolygonMesh = robjAcadPolygonMesh;
														acadPolygonMesh.FriendSetDictReactors = dobjDictReactors2;
														acadPolygonMesh.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadPolygonMesh.Layer = dstrLayer;
														acadPolygonMesh.Linetype = dstrLineType;
														acadPolygonMesh.Color = (Enums.AcColor)dlngColor;
														acadPolygonMesh.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadPolygonMesh.Visible = (dlngVisible == 0);
														acadPolygonMesh.FriendLetRGB = dlngRGB;
														acadPolygonMesh.Lineweight = dnumLineweight;
														acadPolygonMesh.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadPolygonMesh.FriendLetFlags66 = dlngFlags66;
														acadPolygonMesh.SplineType = dlngSplineType;
														acadPolygonMesh.FriendLetFlags70 = dlngFlags67;
														acadPolygonMesh.FriendLetMVertexCount = dlngMVertexCountNumberOfVertices;
														acadPolygonMesh.FriendLetNVertexCount = dlngNVertexCountNumberOfFaces;
														acadPolygonMesh.FriendLetMDensity = dlngMDensity;
														acadPolygonMesh.FriendLetNDensity = dlngNDensity;
														if (dlngFlags67 != acadPolygonMesh.Flags70)
														{
															Debug.Print("PolygonMesh Flag: " + Conversions.ToString(dlngFlags67) + " -> " + Conversions.ToString(acadPolygonMesh.Flags70));
														}
														if (dlngSplineType != acadPolygonMesh.SplineType)
														{
															Debug.Print("PolygonMesh SplineType: " + Conversions.ToString(dlngSplineType) + " -> " + Conversions.ToString(acadPolygonMesh.SplineType));
														}
														if (dlngMVertexCountNumberOfVertices != acadPolygonMesh.MVertexCount)
														{
															Debug.Print("PolygonMesh MVer: " + Conversions.ToString(dlngMVertexCountNumberOfVertices) + " -> " + Conversions.ToString(acadPolygonMesh.MVertexCount));
														}
														if (dlngNVertexCountNumberOfFaces != acadPolygonMesh.NVertexCount)
														{
															Debug.Print("PolygonMesh NVer: " + Conversions.ToString(dlngNVertexCountNumberOfFaces) + " -> " + Conversions.ToString(acadPolygonMesh.NVertexCount));
														}
														if (dlngMDensity != acadPolygonMesh.MDensity)
														{
															Debug.Print("PolygonMesh MDen: " + Conversions.ToString(dlngMDensity) + " -> " + Conversions.ToString(acadPolygonMesh.MDensity));
														}
														if (dlngNDensity != acadPolygonMesh.NDensity)
														{
															Debug.Print("PolygonMesh NDen: " + Conversions.ToString(dlngNDensity) + " -> " + Conversions.ToString(acadPolygonMesh.NDensity));
														}
														acadPolygonMesh.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadPolygonMesh = null;
														break;
													}
												case "AcDbPolyFaceMesh":
													{
														robjAcadPolyfaceMesh = robjAcadBlock.FriendAddAcadObjectPolyfaceMesh(ref nrstrErrMsg, ddblObjectID, null, null);
														if (robjAcadPolyfaceMesh == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadPolyfaceMesh acadPolyfaceMesh = robjAcadPolyfaceMesh;
														acadPolyfaceMesh.FriendSetDictReactors = dobjDictReactors2;
														acadPolyfaceMesh.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadPolyfaceMesh.Layer = dstrLayer;
														acadPolyfaceMesh.Linetype = dstrLineType;
														acadPolyfaceMesh.Color = (Enums.AcColor)dlngColor;
														acadPolyfaceMesh.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadPolyfaceMesh.Visible = (dlngVisible == 0);
														acadPolyfaceMesh.FriendLetRGB = dlngRGB;
														acadPolyfaceMesh.Lineweight = dnumLineweight;
														acadPolyfaceMesh.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadPolyfaceMesh.FriendLetFlags66 = dlngFlags66;
														acadPolyfaceMesh.FriendLetFlags70 = dlngFlags67;
														acadPolyfaceMesh.FriendLetNumberOfVertices = dlngMVertexCountNumberOfVertices;
														acadPolyfaceMesh.FriendLetNumberOfFaces = dlngNVertexCountNumberOfFaces;
														if (dlngFlags67 != acadPolyfaceMesh.Flags70)
														{
															Debug.Print("PolyfaceMesh Flag: " + Conversions.ToString(dlngFlags67) + " -> " + Conversions.ToString(acadPolyfaceMesh.Flags70));
														}
														if (dlngMVertexCountNumberOfVertices != acadPolyfaceMesh.NumberOfVertices)
														{
															Debug.Print("PolyfaceMesh Vert: " + Conversions.ToString(dlngMVertexCountNumberOfVertices) + " -> " + Conversions.ToString(acadPolyfaceMesh.NumberOfVertices));
														}
														if (dlngNVertexCountNumberOfFaces != acadPolyfaceMesh.NumberOfFaces)
														{
															Debug.Print("PolyfaceMesh Face: " + Conversions.ToString(dlngNVertexCountNumberOfFaces) + " -> " + Conversions.ToString(acadPolyfaceMesh.NumberOfFaces));
														}
														acadPolyfaceMesh.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadPolyfaceMesh = null;
														break;
													}
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadPolyline = !dblnError;
				}
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadPolyline;
			}
		}

		public static bool BkDXFReadEnt_AcadVertex(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadPolyline robjAcadPolyline, ref Acad3DPolyline robjAcad3DPolyline, ref AcadPolygonMesh robjAcadPolygonMesh, ref AcadPolyfaceMesh robjAcadPolyfaceMesh, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			object[] dadec2DHWVertex = new object[6];
			double[] dadbl2DHWVertex = new double[6];
			object[] dadec3DVertex = new object[4];
			double[] dadbl3DVertex = new double[4];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadVertex = default(bool);
				AcadFaceRecord dobjAcadFaceRecord2;
				AcadPolyfaceMeshVertex dobjAcadPolyfaceMeshVertex2;
				AcadPolygonMeshVertex dobjAcadPolygonMeshVertex2;
				Acad3DVertex dobjAcad3DVertex2;
				Acad2DVertex dobjAcad2DVertex2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						string dstrObjectName1 = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						string dstrObjectName2 = default(string);
						if (Operators.CompareString(dstrObjectName1, "AcDbVertex", TextCompare: false) != 0)
						{
							if (Operators.CompareString(dstrObjectName1, "AcDbFaceRecord", TextCompare: false) == 0)
							{
								if (robjAcadPolyfaceMesh == null)
								{
									nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
									dblnError = true;
								}
								else
								{
									dstrObjectName2 = dstrObjectName1;
								}
							}
							else
							{
								nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
								dblnError = true;
							}
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Conversions.ToBoolean(Operators.AndObject(robjAcadPolyline != null, Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDb2dVertex", TextCompare: false))))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (Conversions.ToBoolean(Operators.AndObject(robjAcad3DPolyline != null, Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDb3dPolylineVertex", TextCompare: false))))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (Conversions.ToBoolean(Operators.AndObject(robjAcadPolygonMesh != null, Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPolygonMeshVertex", TextCompare: false))))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (Conversions.ToBoolean(Operators.AndObject(robjAcadPolyfaceMesh != null, Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbPolyFaceMeshVertex", TextCompare: false))))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else
						{
							dstrObjectName2 = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
								dblnError = true;
							}
							else
							{
								bool flag = false;
								dadblCoordinate[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblCoordinate[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								dadblCoordinate[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
								rlngIdx += 3;
								double ddblStartWidth = default(double);
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 40, TextCompare: false))
								{
									if (Operators.CompareString(dstrObjectName2, "AcDb2dVertex", TextCompare: false) != 0)
									{
										nrstrErrMsg = "Nicht erlaubter Eintrag (Startbreite) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										bool flag2 = false;
										ddblStartWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
								}
								else
								{
									bool flag3 = false;
									ddblStartWidth = hwpDxf_Vars.pdblStartWidth;
								}
								double ddblEndWidth = default(double);
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
								{
									if (Operators.CompareString(dstrObjectName2, "AcDb2dVertex", TextCompare: false) != 0)
									{
										nrstrErrMsg = "Nicht erlaubter Eintrag (Endbreite) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										bool flag4 = false;
										ddblEndWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
								}
								else
								{
									bool flag5 = false;
									ddblEndWidth = hwpDxf_Vars.pdblEndWidth;
								}
								double ddblBulge = default(double);
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
								{
									if (Operators.CompareString(dstrObjectName2, "AcDb2dVertex", TextCompare: false) != 0)
									{
										nrstrErrMsg = "Nicht erlaubter Eintrag (Ausbuchtung) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										bool flag6 = false;
										ddblBulge = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
								}
								else
								{
									bool flag7 = false;
									ddblBulge = hwpDxf_Vars.pdblBulge;
								}
								int dlngFlags70;
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
								{
									dlngFlags70 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									dlngFlags70 = 0;
								}
								double ddblTangent = default(double);
								if ((2 & dlngFlags70) == 2)
								{
									if (Operators.CompareString(dstrObjectName2, "AcDb2dVertex", TextCompare: false) != 0)
									{
										nrstrErrMsg = "Ungültiger Wert für Flags (IsTangentUsed) für 3D-Polylinien vor Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
										dblnError = true;
									}
									else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Tangentenrichtung in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										bool flag8 = false;
										ddblTangent = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
								}
								else if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
								{
									nrstrErrMsg = "Nicht erlaubter Eintrag (Tangentenrichtung) ab Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else
								{
									bool flag9 = false;
									ddblTangent = hwpDxf_Vars.pdblTangent;
								}
								int dlngVertex1 = default(int);
								int dlngVertex2 = default(int);
								int dlngVertex3 = default(int);
								int dlngVertex4 = default(int);
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 71, TextCompare: false))
								{
									if (Operators.CompareString(dstrObjectName2, "AcDbFaceRecord", TextCompare: false) != 0)
									{
										nrstrErrMsg = "Nicht erlaubter Eintrag (1. Stützpunkt) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										dlngVertex1 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 72, TextCompare: false))
										{
											dlngVertex2 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
											rlngIdx++;
											if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
											{
												dlngVertex3 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
												rlngIdx++;
												if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 74, TextCompare: false))
												{
													dlngVertex4 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
													rlngIdx++;
												}
												else
												{
													dlngVertex4 = hwpDxf_Vars.plngVertex1To4;
												}
											}
											else
											{
												dlngVertex3 = hwpDxf_Vars.plngVertex1To4;
												dlngVertex4 = hwpDxf_Vars.plngVertex1To4;
											}
										}
										else
										{
											dlngVertex2 = hwpDxf_Vars.plngVertex1To4;
											dlngVertex3 = hwpDxf_Vars.plngVertex1To4;
											dlngVertex4 = hwpDxf_Vars.plngVertex1To4;
										}
									}
								}
								else
								{
									dlngVertex1 = hwpDxf_Vars.plngVertex1To4;
									dlngVertex2 = hwpDxf_Vars.plngVertex1To4;
									dlngVertex3 = hwpDxf_Vars.plngVertex1To4;
									dlngVertex4 = hwpDxf_Vars.plngVertex1To4;
								}
								unchecked
								{
									if (!dblnError)
									{
										object dvarXDataType = default(object);
										object dvarXDataValue = default(object);
										dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
										if (!dblnError)
										{
											switch (dstrObjectName2)
											{
												case "AcDb2dVertex":
													{
														dblnError = !BkDXFReadEnt_CheckPolylineAsOwner(vobjAcadDatabase, ref robjAcadPolyline, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
														if (dblnError)
														{
															break;
														}
														bool flag12 = false;
														dadbl2DHWVertex[0] = dadblCoordinate[0];
														dadbl2DHWVertex[1] = dadblCoordinate[1];
														dadbl2DHWVertex[2] = dadblCoordinate[2];
														dadbl2DHWVertex[3] = ddblBulge;
														dadbl2DHWVertex[4] = ddblStartWidth;
														dadbl2DHWVertex[5] = ddblEndWidth;
														dobjAcad2DVertex2 = robjAcadPolyline.FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadec2DHWVertex, dadbl2DHWVertex)), ref nrstrErrMsg);
														if (dobjAcad2DVertex2 == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														Acad2DVertex acad2DVertex = dobjAcad2DVertex2;
														acad2DVertex.FriendSetDictReactors = dobjDictReactors2;
														acad2DVertex.FriendSetDictXDictionary = dobjDictXDictionary2;
														acad2DVertex.Layer = dstrLayer;
														acad2DVertex.Linetype = dstrLineType;
														acad2DVertex.Color = (Enums.AcColor)dlngColor;
														acad2DVertex.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acad2DVertex.Visible = (dlngVisible == 0);
														acad2DVertex.FriendLetRGB = dlngRGB;
														acad2DVertex.Lineweight = dnumLineweight;
														acad2DVertex.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acad2DVertex.FriendLetFlags70 = dlngFlags70;
														object ddecTangent = default(object);
														acad2DVertex.FriendLetTangent = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecTangent), ddblTangent));
														if (dlngFlags70 != acad2DVertex.Flags70)
														{
															Debug.Print("2D-Vertex Flag: " + Conversions.ToString(dlngFlags70) + " -> " + Conversions.ToString(acad2DVertex.Flags70));
														}
														acad2DVertex.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acad2DVertex = null;
														break;
													}
												case "AcDb3dPolylineVertex":
													{
														dblnError = !BkDXFReadEnt_Check3DPolylineAsOwner(vobjAcadDatabase, ref robjAcad3DPolyline, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
														if (dblnError)
														{
															break;
														}
														bool flag10 = false;
														dadbl3DVertex[0] = dadblCoordinate[0];
														dadbl3DVertex[1] = dadblCoordinate[1];
														dadbl3DVertex[2] = dadblCoordinate[2];
														dobjAcad3DVertex2 = robjAcad3DPolyline.FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadec3DVertex, dadbl3DVertex)), ref nrstrErrMsg);
														if (dobjAcad3DVertex2 == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														Acad3DVertex acad3DVertex = dobjAcad3DVertex2;
														acad3DVertex.FriendSetDictReactors = dobjDictReactors2;
														acad3DVertex.FriendSetDictXDictionary = dobjDictXDictionary2;
														acad3DVertex.Layer = dstrLayer;
														acad3DVertex.Linetype = dstrLineType;
														acad3DVertex.Color = (Enums.AcColor)dlngColor;
														acad3DVertex.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acad3DVertex.Visible = (dlngVisible == 0);
														acad3DVertex.FriendLetRGB = dlngRGB;
														acad3DVertex.Lineweight = dnumLineweight;
														acad3DVertex.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acad3DVertex.FriendLetFlags70 = dlngFlags70;
														if (dlngFlags70 != acad3DVertex.Flags70)
														{
															Debug.Print("3D-Vertex Flag: " + Conversions.ToString(dlngFlags70) + " -> " + Conversions.ToString(acad3DVertex.Flags70));
														}
														acad3DVertex.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acad3DVertex = null;
														break;
													}
												case "AcDbPolygonMeshVertex":
													{
														dblnError = !BkDXFReadEnt_CheckPolygonMeshAsOwner(vobjAcadDatabase, ref robjAcadPolygonMesh, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
														if (dblnError)
														{
															break;
														}
														bool flag13 = false;
														dadbl3DVertex[0] = dadblCoordinate[0];
														dadbl3DVertex[1] = dadblCoordinate[1];
														dadbl3DVertex[2] = dadblCoordinate[2];
														dobjAcadPolygonMeshVertex2 = robjAcadPolygonMesh.FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadec3DVertex, dadbl3DVertex)), ref nrstrErrMsg);
														if (dobjAcadPolygonMeshVertex2 == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadPolygonMeshVertex acadPolygonMeshVertex = dobjAcadPolygonMeshVertex2;
														acadPolygonMeshVertex.FriendSetDictReactors = dobjDictReactors2;
														acadPolygonMeshVertex.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadPolygonMeshVertex.Layer = dstrLayer;
														acadPolygonMeshVertex.Linetype = dstrLineType;
														acadPolygonMeshVertex.Color = (Enums.AcColor)dlngColor;
														acadPolygonMeshVertex.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadPolygonMeshVertex.Visible = (dlngVisible == 0);
														acadPolygonMeshVertex.FriendLetRGB = dlngRGB;
														acadPolygonMeshVertex.Lineweight = dnumLineweight;
														acadPolygonMeshVertex.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadPolygonMeshVertex.FriendLetFlags70 = dlngFlags70;
														if (dlngFlags70 != acadPolygonMeshVertex.Flags70)
														{
															Debug.Print("PM-Vertex Flag: " + Conversions.ToString(dlngFlags70) + " -> " + Conversions.ToString(acadPolygonMeshVertex.Flags70));
														}
														acadPolygonMeshVertex.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadPolygonMeshVertex = null;
														break;
													}
												case "AcDbPolyFaceMeshVertex":
													{
														dblnError = !BkDXFReadEnt_CheckPolyfaceMeshAsOwner(vobjAcadDatabase, ref robjAcadPolyfaceMesh, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
														if (dblnError)
														{
															break;
														}
														bool flag11 = false;
														dadbl3DVertex[0] = dadblCoordinate[0];
														dadbl3DVertex[1] = dadblCoordinate[1];
														dadbl3DVertex[2] = dadblCoordinate[2];
														dobjAcadPolyfaceMeshVertex2 = robjAcadPolyfaceMesh.FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadec3DVertex, dadbl3DVertex)), ref nrstrErrMsg);
														if (dobjAcadPolyfaceMeshVertex2 == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadPolyfaceMeshVertex acadPolyfaceMeshVertex = dobjAcadPolyfaceMeshVertex2;
														acadPolyfaceMeshVertex.FriendSetDictReactors = dobjDictReactors2;
														acadPolyfaceMeshVertex.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadPolyfaceMeshVertex.Layer = dstrLayer;
														acadPolyfaceMeshVertex.Linetype = dstrLineType;
														acadPolyfaceMeshVertex.Color = (Enums.AcColor)dlngColor;
														acadPolyfaceMeshVertex.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadPolyfaceMeshVertex.Visible = (dlngVisible == 0);
														acadPolyfaceMeshVertex.FriendLetRGB = dlngRGB;
														acadPolyfaceMeshVertex.Lineweight = dnumLineweight;
														acadPolyfaceMeshVertex.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadPolyfaceMeshVertex.FriendLetFlags70 = dlngFlags70;
														if (dlngFlags70 != acadPolyfaceMeshVertex.Flags70)
														{
															Debug.Print("FM-Vertex Flag: " + Conversions.ToString(dlngFlags70) + " -> " + Conversions.ToString(acadPolyfaceMeshVertex.Flags70));
														}
														acadPolyfaceMeshVertex.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadPolyfaceMeshVertex = null;
														break;
													}
												case "AcDbFaceRecord":
													{
														dblnError = !BkDXFReadEnt_CheckPolyfaceMeshAsOwner(vobjAcadDatabase, ref robjAcadPolyfaceMesh, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
														if (dblnError)
														{
															break;
														}
														dobjAcadFaceRecord2 = robjAcadPolyfaceMesh.FriendAppendFace(ddblObjectID, dlngVertex1, dlngVertex2, dlngVertex3, dlngVertex4, ref nrstrErrMsg);
														if (dobjAcadFaceRecord2 == null)
														{
															nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
															dblnError = true;
															break;
														}
														AcadFaceRecord acadFaceRecord = dobjAcadFaceRecord2;
														acadFaceRecord.FriendSetDictReactors = dobjDictReactors2;
														acadFaceRecord.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadFaceRecord.Layer = dstrLayer;
														acadFaceRecord.Linetype = dstrLineType;
														acadFaceRecord.Color = (Enums.AcColor)dlngColor;
														acadFaceRecord.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
														acadFaceRecord.Visible = (dlngVisible == 0);
														acadFaceRecord.FriendLetRGB = dlngRGB;
														acadFaceRecord.Lineweight = dnumLineweight;
														acadFaceRecord.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
														acadFaceRecord.FriendLetFlags70 = dlngFlags70;
														if (dlngFlags70 != acadFaceRecord.Flags70)
														{
															Debug.Print("FM-Face Flag: " + Conversions.ToString(dlngFlags70) + " -> " + Conversions.ToString(acadFaceRecord.Flags70));
														}
														acadFaceRecord.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadFaceRecord = null;
														break;
													}
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadVertex = !dblnError;
				}
				dobjAcadFaceRecord2 = null;
				dobjAcadPolyfaceMeshVertex2 = null;
				dobjAcadPolygonMeshVertex2 = null;
				dobjAcad3DVertex2 = null;
				dobjAcad2DVertex2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadVertex;
			}
		}

		public static bool BkDXFReadEnt_AcadMText(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecInsertionPoint = new object[3];
			double[] dadblInsertionPoint = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			object[] dadecDirection = new object[3];
			double[] dadblDirection = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadMText = default(bool);
				AcadMText dobjAcadMText2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbMText", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Nominale Texthöhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 41, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Breite des referenzierten Rechtecks in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anschlußpunkt in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 72, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zeichnungsrichtung in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblInsertionPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblInsertionPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						dadblInsertionPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						double ddblHeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						double ddblWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						int dlngAttachmentPoint = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 6]);
						int dlngDrawingDirection = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 7]);
						rlngIdx += 8;
						object left = vobjDictReadCodes[rlngIdx];
						string dstrTextString = default(string);
						if (Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: false))
						{
							dstrTextString = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else if (Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: false))
						{
							dstrTextString = null;
							while (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 3, TextCompare: false))
							{
								dstrTextString = Conversions.ToString(Operators.ConcatenateObject(dstrTextString, vobjDictReadValues[rlngIdx]));
								rlngIdx++;
							}
						}
						else
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Zeichenfolge in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						if (!dblnError)
						{
							string dstrTextStyle;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 7, TextCompare: false))
							{
								dstrTextStyle = Conversions.ToString(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dstrTextStyle = hwpDxf_Vars.pstrTextStyleName;
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag2 = false;
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
									bool flag3 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag4 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							if (!dblnError)
							{
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 11, TextCompare: false))
								{
									bool flag5 = false;
									dadblDirection[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
									if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 21, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Richtungsvektor Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 31, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Richtungsvektor Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
										dblnError = true;
									}
									else
									{
										bool flag6 = false;
										dadblDirection[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										dadblDirection[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
										rlngIdx += 2;
									}
								}
								else
								{
									bool flag7 = false;
									dadblDirection[0] = hwpDxf_Vars.padblDirection[0];
									dadblDirection[1] = hwpDxf_Vars.padblDirection[1];
									dadblDirection[2] = hwpDxf_Vars.padblDirection[2];
								}
								if (!dblnError)
								{
									double ddblActualWidth;
									if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
									{
										bool flag8 = false;
										ddblActualWidth = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
									else
									{
										bool flag9 = false;
										ddblActualWidth = hwpDxf_Vars.pdblActualWidth;
									}
									double ddblActualHeight;
									if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 43, TextCompare: false))
									{
										bool flag10 = false;
										ddblActualHeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
									else
									{
										bool flag11 = false;
										ddblActualHeight = hwpDxf_Vars.pdblActualHeight;
									}
									double ddblRotationDegree;
									if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
									{
										bool flag12 = false;
										ddblRotationDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
									}
									else
									{
										bool flag13 = false;
										ddblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
									}
									if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Stil für Zeilenabstand in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										int dlngLineSpacingStyle = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										double ddblLineSpacingFactor;
										if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 44, TextCompare: false))
										{
											bool flag14 = false;
											ddblLineSpacingFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
											rlngIdx++;
										}
										else
										{
											bool flag15 = false;
											ddblLineSpacingFactor = hwpDxf_Vars.pdblLineSpacingFactor;
										}
										int dlngBackgroundMode = default(int);
										int dlngBackgroundFillColor = default(int);
										int dlngBackgroundFillRGB = default(int);
										double ddblBackgroundBorderOffsetFactor = default(double);
										int dlngBackgroundCode441 = default(int);
										if (Operators.CompareString(dstrAcadVer, "AC1018", TextCompare: false) >= 0)
										{
											if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 90, TextCompare: false))
											{
												if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 63, TextCompare: false))
												{
													nrstrErrMsg = "Ungültiger Gruppencode für Hintergrund-Füllfarbe in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
													dblnError = true;
												}
												else
												{
													dlngBackgroundMode = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
													dlngBackgroundFillColor = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
													rlngIdx += 2;
													if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 421, TextCompare: false))
													{
														dlngBackgroundFillRGB = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
														rlngIdx++;
													}
													else
													{
														dlngBackgroundFillRGB = hwpDxf_Vars.plngBackgroundFillRGB;
													}
												}
												if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 45, TextCompare: false))
												{
													nrstrErrMsg = "Ungültiger Gruppencode für Hintergrund-Randversatzfaktor in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
													dblnError = true;
												}
												else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 441, TextCompare: false))
												{
													nrstrErrMsg = "Ungültiger Gruppencode für Hintergrund-Code441 in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
													dblnError = true;
												}
												else
												{
													bool flag16 = false;
													ddblBackgroundBorderOffsetFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
													dlngBackgroundCode441 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
													rlngIdx += 2;
												}
											}
											else
											{
												dlngBackgroundMode = hwpDxf_Vars.plngBackgroundMode;
												dlngBackgroundFillColor = unchecked((int)hwpDxf_Vars.pnumBackgroundFillColor);
												dlngBackgroundFillRGB = hwpDxf_Vars.plngBackgroundFillRGB;
												object ddecBackgroundBorderOffsetFactor2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecBackgroundBorderOffsetFactor);
												ddblBackgroundBorderOffsetFactor = hwpDxf_Vars.pdblBackgroundBorderOffsetFactor;
												dlngBackgroundCode441 = hwpDxf_Vars.plngBackgroundCode441;
											}
										}
										else
										{
											dlngBackgroundMode = hwpDxf_Vars.plngBackgroundMode;
											dlngBackgroundFillColor = unchecked((int)hwpDxf_Vars.pnumBackgroundFillColor);
											dlngBackgroundFillRGB = hwpDxf_Vars.plngBackgroundFillRGB;
											object ddecBackgroundBorderOffsetFactor2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecBackgroundBorderOffsetFactor);
											ddblBackgroundBorderOffsetFactor = hwpDxf_Vars.pdblBackgroundBorderOffsetFactor;
											dlngBackgroundCode441 = hwpDxf_Vars.plngBackgroundCode441;
										}
										if (!dblnError)
										{
											object dvarXDataType = default(object);
											object dvarXDataValue = default(object);
											dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
											if (!dblnError)
											{
												dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
												if (!dblnError)
												{
													object ddecWidth = default(object);
													dobjAcadMText2 = robjAcadBlock.FriendAddAcadObjectMText(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecInsertionPoint, dadblInsertionPoint)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecWidth), ddblWidth)), dstrTextString, ref nrstrErrMsg);
													if (dobjAcadMText2 == null)
													{
														nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
														dblnError = true;
													}
													else
													{
														AcadMText acadMText = dobjAcadMText2;
														acadMText.FriendSetDictReactors = dobjDictReactors2;
														acadMText.FriendSetDictXDictionary = dobjDictXDictionary2;
														acadMText.Layer = dstrLayer;
														acadMText.Linetype = dstrLineType;
														unchecked
														{
															acadMText.Color = (Enums.AcColor)dlngColor;
															acadMText.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
															acadMText.Visible = (dlngVisible == 0);
															acadMText.FriendLetRGB = dlngRGB;
															acadMText.Lineweight = dnumLineweight;
															acadMText.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
															bool flag17 = false;
															acadMText.Height = ddblHeight;
															acadMText.AttachmentPoint = (Enums.AcAttachmentPoint)dlngAttachmentPoint;
															acadMText.DrawingDirection = (Enums.AcDrawingDirection)dlngDrawingDirection;
															acadMText.TextStyle = dstrTextStyle;
															bool flag18 = false;
															acadMText.Normal = Support.CopyArray(dadblNormal);
															acadMText.FriendLetDirection = Support.CopyArray(dadblDirection);
															acadMText.FriendLetActualWidth = ddblActualWidth;
															acadMText.FriendLetActualHeight = ddblActualHeight;
															acadMText.RotationDegree = ddblRotationDegree;
															acadMText.LineSpacingStyle = (Enums.AcLineSpacingStyle)dlngLineSpacingStyle;
															bool flag19 = false;
															acadMText.LineSpacingFactor = ddblLineSpacingFactor;
															acadMText.BackgroundMode = dlngBackgroundMode;
															acadMText.BackgroundFillColor = (Enums.AcColor)dlngBackgroundFillColor;
															acadMText.BackgroundFillRGB = dlngBackgroundFillRGB;
															acadMText.BackgroundCode441 = dlngBackgroundCode441;
															bool flag20 = false;
														}
														acadMText.BackgroundCode441 = (int)Math.Round(ddblBackgroundBorderOffsetFactor);
														acadMText.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
														acadMText = null;
													}
												}
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadMText = !dblnError;
				}
				dobjAcadMText2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadMText;
			}
		}

		public static bool BkDXFReadEnt_AcadText(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarInsertionPoint2 = new object[3];
			object[] davarTextAlignmentPoint2 = new object[3];
			object[] davarNormal2 = new object[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadText = default(bool);
				AcadText dobjAcadText2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					object ravarInsertionPoint = davarInsertionPoint2;
					object ravarTextAlignmentPoint = davarTextAlignmentPoint2;
					object ravarNormal = davarNormal2;
					object dvarThickness = default(object);
					object dvarHeight = default(object);
					string dstrTextString = default(string);
					object dvarRotationDegree = default(object);
					object dvarScaleFactor = default(object);
					object dvarObliqueAngleDegree = default(object);
					string dstrTextStyle = default(string);
					int dlngTextGenerationFlag = default(int);
					int dlngHorizontalAlignment = default(int);
					bool flag = hwpDxf_ReadRef.BkDXFReadRef_AcadText(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dvarThickness, ref ravarInsertionPoint, ref dvarHeight, ref dstrTextString, ref dvarRotationDegree, ref dvarScaleFactor, ref dvarObliqueAngleDegree, ref dstrTextStyle, ref dlngTextGenerationFlag, ref dlngHorizontalAlignment, ref ravarTextAlignmentPoint, ref ravarNormal, ref nrstrErrMsg);
					davarNormal2 = (object[])ravarNormal;
					davarTextAlignmentPoint2 = (object[])ravarTextAlignmentPoint;
					davarInsertionPoint2 = (object[])ravarInsertionPoint;
					if (flag)
					{
						bool dblnError;
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
							int dlngVerticalAlignment;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
							{
								dlngVerticalAlignment = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngVerticalAlignment = 0;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							unchecked
							{
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadText2 = robjAcadBlock.FriendAddAcadObjectText(ddblObjectID, dstrTextString, davarInsertionPoint2, RuntimeHelpers.GetObjectValue(dvarHeight), ref nrstrErrMsg);
										if (dobjAcadText2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadText acadText = dobjAcadText2;
											acadText.FriendSetDictReactors = dobjDictReactors2;
											acadText.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadText.Layer = dstrLayer;
											acadText.Linetype = dstrLineType;
											acadText.Color = (Enums.AcColor)dlngColor;
											acadText.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadText.Visible = (dlngVisible == 0);
											acadText.FriendLetRGB = dlngRGB;
											acadText.Lineweight = dnumLineweight;
											acadText.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											acadText.Thickness = RuntimeHelpers.GetObjectValue(dvarThickness);
											acadText.RotationDegree = RuntimeHelpers.GetObjectValue(dvarRotationDegree);
											acadText.ScaleFactor = RuntimeHelpers.GetObjectValue(dvarScaleFactor);
											acadText.ObliqueAngleDegree = RuntimeHelpers.GetObjectValue(dvarObliqueAngleDegree);
											acadText.TextStyle = dstrTextStyle;
											acadText.TextGenerationFlag = (Enums.AcTextGenerationFlag)dlngTextGenerationFlag;
											acadText.HorizontalAlignment = (Enums.AcHorizontalAlignment)dlngHorizontalAlignment;
											acadText.TextAlignmentPoint = Support.CopyArray(davarTextAlignmentPoint2);
											acadText.Normal = Support.CopyArray(davarNormal2);
											acadText.VerticalAlignment = (Enums.AcVerticalAlignment)dlngVerticalAlignment;
											acadText.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadText = null;
										}
									}
								}
							}
						}
						BkDXFReadEnt_AcadText = !dblnError;
					}
				}
				dobjAcadText2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadText;
			}
		}

		public static bool BkDXFReadEnt_AcadAttributeDefinition(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarInsertionPoint2 = new object[3];
			object[] davarTextAlignmentPoint2 = new object[3];
			object[] davarNormal2 = new object[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadAttributeDefinition = default(bool);
				AcadAttribute dobjAcadAttribute2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					object ravarInsertionPoint = davarInsertionPoint2;
					object ravarTextAlignmentPoint = davarTextAlignmentPoint2;
					object ravarNormal = davarNormal2;
					object dvarThickness = default(object);
					object dvarHeight = default(object);
					string dstrTextString = default(string);
					object dvarRotationDegree = default(object);
					object dvarScaleFactor = default(object);
					object dvarObliqueAngleDegree = default(object);
					string dstrTextStyle = default(string);
					int dlngTextGenerationFlag = default(int);
					int dlngHorizontalAlignment = default(int);
					bool flag = hwpDxf_ReadRef.BkDXFReadRef_AcadText(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dvarThickness, ref ravarInsertionPoint, ref dvarHeight, ref dstrTextString, ref dvarRotationDegree, ref dvarScaleFactor, ref dvarObliqueAngleDegree, ref dstrTextStyle, ref dlngTextGenerationFlag, ref dlngHorizontalAlignment, ref ravarTextAlignmentPoint, ref ravarNormal, ref nrstrErrMsg);
					davarNormal2 = (object[])ravarNormal;
					davarTextAlignmentPoint2 = (object[])ravarTextAlignmentPoint;
					davarInsertionPoint2 = (object[])ravarInsertionPoint;
					if (flag)
					{
						bool dblnError;
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbAttributeDefinition", TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 3, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Befehlsfolge in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 2, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Bezeichner in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else
						{
							string dstrPromptString = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
							string dstrTagString = Conversions.ToString(vobjDictReadValues[rlngIdx + 2]);
							rlngIdx += 3;
							int dlngAttribFlags;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
							{
								dlngAttribFlags = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngAttribFlags = hwpDxf_Vars.plngAttribFlags;
							}
							int dlngFieldLength;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
							{
								dlngFieldLength = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngFieldLength = hwpDxf_Vars.plngFieldLength;
							}
							int dlngVerticalAlignment;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 74, TextCompare: false))
							{
								dlngVerticalAlignment = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngVerticalAlignment = 0;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							unchecked
							{
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										dobjAcadAttribute2 = robjAcadBlock.FriendAddAcadObjectAttribute(ddblObjectID, RuntimeHelpers.GetObjectValue(dvarHeight), (Enums.AcAttributeMode)dlngAttribFlags, dstrPromptString, davarInsertionPoint2, dstrTagString, dstrTextString, ref nrstrErrMsg);
										if (dobjAcadAttribute2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadAttribute acadAttribute = dobjAcadAttribute2;
											acadAttribute.FriendSetDictReactors = dobjDictReactors2;
											acadAttribute.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadAttribute.Layer = dstrLayer;
											acadAttribute.Linetype = dstrLineType;
											acadAttribute.Color = (Enums.AcColor)dlngColor;
											acadAttribute.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadAttribute.Visible = (dlngVisible == 0);
											acadAttribute.FriendLetRGB = dlngRGB;
											acadAttribute.Lineweight = dnumLineweight;
											acadAttribute.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											acadAttribute.Thickness = RuntimeHelpers.GetObjectValue(dvarThickness);
											acadAttribute.RotationDegree = RuntimeHelpers.GetObjectValue(dvarRotationDegree);
											acadAttribute.ScaleFactor = RuntimeHelpers.GetObjectValue(dvarScaleFactor);
											acadAttribute.ObliqueAngleDegree = RuntimeHelpers.GetObjectValue(dvarObliqueAngleDegree);
											acadAttribute.TextStyle = dstrTextStyle;
											acadAttribute.TextGenerationFlag = (Enums.AcTextGenerationFlag)dlngTextGenerationFlag;
											acadAttribute.HorizontalAlignment = (Enums.AcHorizontalAlignment)dlngHorizontalAlignment;
											acadAttribute.TextAlignmentPoint = Support.CopyArray(davarTextAlignmentPoint2);
											acadAttribute.Normal = Support.CopyArray(davarNormal2);
											acadAttribute.FriendLetFieldLength = dlngFieldLength;
											acadAttribute.VerticalAlignment = (Enums.AcVerticalAlignment)dlngVerticalAlignment;
											acadAttribute.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadAttribute = null;
										}
									}
								}
							}
						}
						BkDXFReadEnt_AcadAttributeDefinition = !dblnError;
					}
				}
				dobjAcadAttribute2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadAttributeDefinition;
			}
		}

		public static bool BkDXFReadEnt_AcadBlockReference(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecInsertionPoint = new object[3];
			double[] dadblInsertionPoint = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadBlockReference = default(bool);
				AcadBlockReference dobjAcadBlockReference2 = default(AcadBlockReference);
				AcadMInsertBlock dobjAcadMInsertBlock2 = default(AcadMInsertBlock);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbBlockReference", TextCompare: false), Operators.CompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbMInsertBlock", TextCompare: false))))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						string dstrObjectName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						bool dblnIsMInsert = Operators.CompareString(dstrObjectName, "AcDbMInsertBlock", TextCompare: false) == 0;
						bool dblnHasAttributes;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 66, TextCompare: false))
						{
							dblnHasAttributes = Conversions.ToBoolean(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							dblnHasAttributes = hwpDxf_Vars.pblnHasAttributes;
						}
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 2, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Blockname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Einfügepunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else
						{
							string dstrName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
							bool flag = false;
							dadblInsertionPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							dadblInsertionPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
							dadblInsertionPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
							rlngIdx += 4;
							double ddblXScaleFactor;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
							{
								bool flag2 = false;
								ddblXScaleFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag3 = false;
								ddblXScaleFactor = hwpDxf_Vars.pdblXScaleFactor;
							}
							double ddblYScaleFactor;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
							{
								bool flag4 = false;
								ddblYScaleFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag5 = false;
								ddblYScaleFactor = hwpDxf_Vars.pdblYScaleFactor;
							}
							double ddblZScaleFactor;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 43, TextCompare: false))
							{
								bool flag6 = false;
								ddblZScaleFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag7 = false;
								ddblZScaleFactor = hwpDxf_Vars.pdblZScaleFactor;
							}
							double ddblRotationDegree;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
							{
								bool flag8 = false;
								ddblRotationDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag9 = false;
								ddblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
							}
							int dlngColumns = default(int);
							int dlngRows = default(int);
							double ddblColumnSpacing = default(double);
							double ddblRowSpacing = default(double);
							if (dblnIsMInsert)
							{
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
								{
									dlngColumns = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									dlngColumns = hwpDxf_Vars.plngColumns;
								}
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 71, TextCompare: false))
								{
									dlngRows = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									dlngRows = hwpDxf_Vars.plngRows;
								}
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 44, TextCompare: false))
								{
									bool flag10 = false;
									ddblColumnSpacing = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									bool flag11 = false;
									ddblColumnSpacing = hwpDxf_Vars.pdblColumnSpacing;
								}
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 45, TextCompare: false))
								{
									bool flag12 = false;
									ddblRowSpacing = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									bool flag13 = false;
									ddblRowSpacing = hwpDxf_Vars.pdblRowSpacing;
								}
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag14 = false;
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
									bool flag15 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag16 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							unchecked
							{
								if (!dblnError)
								{
									object dvarXDataType = default(object);
									object dvarXDataValue = default(object);
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
									if (!dblnError)
									{
										dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
										if (!dblnError)
										{
											object ddecXScaleFactor = default(object);
											object ddecYScaleFactor = default(object);
											object ddecZScaleFactor = default(object);
											object ddecRotationDegree = default(object);
											if (dblnIsMInsert & (dlngColumns != hwpDxf_Vars.plngColumns) & (dlngRows != hwpDxf_Vars.plngRows))
											{
												object ddecRowSpacing = default(object);
												object ddecColumnSpacing = default(object);
												dobjAcadMInsertBlock2 = robjAcadBlock.FriendAddAcadObjectMInsertBlock(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecInsertionPoint, dadblInsertionPoint)), dstrName, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecXScaleFactor), ddblXScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecYScaleFactor), ddblYScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecZScaleFactor), ddblZScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecRotationDegree), ddblRotationDegree)), dlngRows, dlngColumns, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecRowSpacing), ddblRowSpacing)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecColumnSpacing), ddblColumnSpacing)), ref nrstrErrMsg);
											}
											else
											{
												dobjAcadBlockReference2 = robjAcadBlock.FriendAddAcadObjectInsertBlock(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecInsertionPoint, dadblInsertionPoint)), dstrName, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecXScaleFactor), ddblXScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecYScaleFactor), ddblYScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecZScaleFactor), ddblZScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecRotationDegree), ddblRotationDegree)), ref nrstrErrMsg);
											}
											if (dblnIsMInsert)
											{
												if (dobjAcadMInsertBlock2 == null)
												{
													nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
													dblnError = true;
												}
												else
												{
													AcadMInsertBlock acadMInsertBlock = dobjAcadMInsertBlock2;
													acadMInsertBlock.FriendSetDictReactors = dobjDictReactors2;
													acadMInsertBlock.FriendSetDictXDictionary = dobjDictXDictionary2;
													acadMInsertBlock.Layer = dstrLayer;
													acadMInsertBlock.Linetype = dstrLineType;
													acadMInsertBlock.Color = (Enums.AcColor)dlngColor;
													acadMInsertBlock.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
													acadMInsertBlock.Visible = (dlngVisible == 0);
													acadMInsertBlock.FriendLetRGB = dlngRGB;
													acadMInsertBlock.Lineweight = dnumLineweight;
													acadMInsertBlock.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
													acadMInsertBlock.FriendLetHasAttributes = dblnHasAttributes;
													bool flag17 = false;
													acadMInsertBlock.Normal = Support.CopyArray(dadblNormal);
													acadMInsertBlock.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
													acadMInsertBlock = null;
												}
											}
											else if (dobjAcadBlockReference2 == null)
											{
												nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
												dblnError = true;
											}
											else
											{
												AcadBlockReference acadBlockReference = dobjAcadBlockReference2;
												acadBlockReference.FriendSetDictReactors = dobjDictReactors2;
												acadBlockReference.FriendSetDictXDictionary = dobjDictXDictionary2;
												acadBlockReference.Layer = dstrLayer;
												acadBlockReference.Linetype = dstrLineType;
												acadBlockReference.Color = (Enums.AcColor)dlngColor;
												acadBlockReference.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
												acadBlockReference.Visible = (dlngVisible == 0);
												acadBlockReference.FriendLetRGB = dlngRGB;
												acadBlockReference.Lineweight = dnumLineweight;
												acadBlockReference.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
												acadBlockReference.FriendLetHasAttributes = dblnHasAttributes;
												bool flag18 = false;
												acadBlockReference.Normal = Support.CopyArray(dadblNormal);
												acadBlockReference.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
												acadBlockReference = null;
											}
											if (!dblnError && dblnHasAttributes)
											{
												dblnError = !BkDXFReadEnt_AcadBlockRefAttributes(vobjAcadDatabase, ref rlngIdx, ref dobjAcadBlockReference2, ref dobjAcadMInsertBlock2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadBlockReference = !dblnError;
				}
				dobjAcadBlockReference2 = null;
				dobjAcadMInsertBlock2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadBlockReference;
			}
		}

		public static bool BkDXFReadEnt_AcadBlockRefAttributes(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlockReference robjAcadBlockReference, ref AcadMInsertBlock robjAcadMInsertBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			bool dblnStop = default(bool);
			bool dblnError = default(bool);
			while (!dblnStop && !dblnError)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				checked
				{
					if (dlngCode != 0)
					{
						nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
						continue;
					}
					rlngIdx++;
					object left = dvarValue;
					if (Operators.ConditionalCompareObjectEqual(left, "ATTRIB", TextCompare: false))
					{
						dblnError = !BkDXFReadEnt_AcadAttributeReference(vobjAcadDatabase, ref rlngIdx, ref robjAcadBlockReference, ref robjAcadMInsertBlock, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
					}
					else if (Operators.ConditionalCompareObjectEqual(left, "SEQEND", TextCompare: false))
					{
						dblnStop = true;
						AcadPolyline robjAcadPolyline = null;
						Acad3DPolyline robjAcad3DPolyline = null;
						AcadPolygonMesh robjAcadPolygonMesh = null;
						AcadPolyfaceMesh robjAcadPolyfaceMesh = null;
						dblnError = !BkDXFReadEnt_AcadSequenceEnd(vobjAcadDatabase, ref rlngIdx, ref robjAcadBlockReference, ref robjAcadMInsertBlock, ref robjAcadPolyline, ref robjAcad3DPolyline, ref robjAcadPolygonMesh, ref robjAcadPolyfaceMesh, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
					}
					else
					{
						nrstrErrMsg = "Ungültiger DXF-Name in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
				}
			}
			return !dblnError;
		}

		public static bool BkDXFReadEnt_AcadAttributeReference(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlockReference robjAcadBlockReference, ref AcadMInsertBlock robjAcadMInsertBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] davarInsertionPoint2 = new object[3];
			object[] davarTextAlignmentPoint2 = new object[3];
			object[] davarNormal2 = new object[3];
			nrstrErrMsg = null;
			if (robjAcadMInsertBlock != null)
			{
				double ddblRefObjectID = robjAcadMInsertBlock.ObjectID;
			}
			else if (robjAcadBlockReference != null)
			{
				double ddblRefObjectID = robjAcadBlockReference.ObjectID;
			}
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadAttributeReference = default(bool);
				AcadAttributeReference dobjAcadAttributeReference2 = default(AcadAttributeReference);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					object ravarInsertionPoint = davarInsertionPoint2;
					object ravarTextAlignmentPoint = davarTextAlignmentPoint2;
					object ravarNormal = davarNormal2;
					object dvarThickness = default(object);
					object dvarHeight = default(object);
					string dstrTextString = default(string);
					object dvarRotationDegree = default(object);
					object dvarScaleFactor = default(object);
					object dvarObliqueAngleDegree = default(object);
					string dstrTextStyle = default(string);
					int dlngTextGenerationFlag = default(int);
					int dlngHorizontalAlignment = default(int);
					bool flag = hwpDxf_ReadRef.BkDXFReadRef_AcadText(vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dvarThickness, ref ravarInsertionPoint, ref dvarHeight, ref dstrTextString, ref dvarRotationDegree, ref dvarScaleFactor, ref dvarObliqueAngleDegree, ref dstrTextStyle, ref dlngTextGenerationFlag, ref dlngHorizontalAlignment, ref ravarTextAlignmentPoint, ref ravarNormal, ref nrstrErrMsg);
					davarNormal2 = (object[])ravarNormal;
					davarTextAlignmentPoint2 = (object[])ravarTextAlignmentPoint;
					davarInsertionPoint2 = (object[])ravarInsertionPoint;
					if (flag)
					{
						bool dblnError;
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbAttribute", TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Bezeichner in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							string dstrTagString = Conversions.ToString(vobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
							int dlngAttribFlags;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
							{
								dlngAttribFlags = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngAttribFlags = hwpDxf_Vars.plngAttribFlags;
							}
							int dlngFieldLength;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 73, TextCompare: false))
							{
								dlngFieldLength = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngFieldLength = hwpDxf_Vars.plngFieldLength;
							}
							int dlngVerticalAlignment;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 74, TextCompare: false))
							{
								dlngVerticalAlignment = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								dlngVerticalAlignment = 0;
							}
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							unchecked
							{
								if (!dblnError)
								{
									if (robjAcadMInsertBlock != null)
									{
										dobjAcadAttributeReference2 = robjAcadMInsertBlock.FriendAddAcadObjectAttributeReference(ddblObjectID, RuntimeHelpers.GetObjectValue(dvarHeight), (Enums.AcAttributeMode)dlngAttribFlags, davarInsertionPoint2, dstrTagString, dstrTextString, ref nrstrErrMsg);
									}
									else if (robjAcadBlockReference != null)
									{
										dobjAcadAttributeReference2 = robjAcadBlockReference.FriendAddAcadObjectAttributeReference(ddblObjectID, RuntimeHelpers.GetObjectValue(dvarHeight), (Enums.AcAttributeMode)dlngAttribFlags, davarInsertionPoint2, dstrTagString, dstrTextString, ref nrstrErrMsg);
									}
									if (dobjAcadAttributeReference2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadAttributeReference acadAttributeReference = dobjAcadAttributeReference2;
										acadAttributeReference.FriendSetDictReactors = dobjDictReactors2;
										acadAttributeReference.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadAttributeReference.Layer = dstrLayer;
										acadAttributeReference.Linetype = dstrLineType;
										acadAttributeReference.Color = (Enums.AcColor)dlngColor;
										acadAttributeReference.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
										acadAttributeReference.Visible = (dlngVisible == 0);
										acadAttributeReference.FriendLetRGB = dlngRGB;
										acadAttributeReference.Lineweight = dnumLineweight;
										acadAttributeReference.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
										acadAttributeReference.Thickness = RuntimeHelpers.GetObjectValue(dvarThickness);
										acadAttributeReference.RotationDegree = RuntimeHelpers.GetObjectValue(dvarRotationDegree);
										acadAttributeReference.ScaleFactor = RuntimeHelpers.GetObjectValue(dvarScaleFactor);
										acadAttributeReference.ObliqueAngleDegree = RuntimeHelpers.GetObjectValue(dvarObliqueAngleDegree);
										acadAttributeReference.TextStyle = dstrTextStyle;
										acadAttributeReference.TextGenerationFlag = (Enums.AcTextGenerationFlag)dlngTextGenerationFlag;
										acadAttributeReference.HorizontalAlignment = (Enums.AcHorizontalAlignment)dlngHorizontalAlignment;
										acadAttributeReference.TextAlignmentPoint = Support.CopyArray(davarTextAlignmentPoint2);
										acadAttributeReference.Normal = Support.CopyArray(davarNormal2);
										acadAttributeReference.FriendLetFieldLength = dlngFieldLength;
										acadAttributeReference.VerticalAlignment = (Enums.AcVerticalAlignment)dlngVerticalAlignment;
										acadAttributeReference.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadAttributeReference = null;
									}
								}
							}
						}
						BkDXFReadEnt_AcadAttributeReference = !dblnError;
					}
				}
				dobjAcadAttributeReference2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadAttributeReference;
			}
		}

		public static bool BkDXFReadEnt_AcadSequenceEnd(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlockReference robjAcadBlockReference, ref AcadMInsertBlock robjAcadMInsertBlock, ref AcadPolyline robjAcadPolyline, ref Acad3DPolyline robjAcad3DPolyline, ref AcadPolygonMesh robjAcadPolygonMesh, ref AcadPolyfaceMesh robjAcadPolyfaceMesh, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			if (robjAcadPolyfaceMesh != null)
			{
				double ddblRefObjectID6 = robjAcadPolyfaceMesh.ObjectID;
			}
			else if (robjAcadPolygonMesh != null)
			{
				double ddblRefObjectID6 = robjAcadPolygonMesh.ObjectID;
			}
			else if (robjAcad3DPolyline != null)
			{
				double ddblRefObjectID6 = robjAcad3DPolyline.ObjectID;
			}
			else if (robjAcadPolyline != null)
			{
				double ddblRefObjectID6 = robjAcadPolyline.ObjectID;
			}
			else if (robjAcadMInsertBlock != null)
			{
				double ddblRefObjectID6 = robjAcadMInsertBlock.ObjectID;
			}
			else if (robjAcadBlockReference != null)
			{
				double ddblRefObjectID6 = robjAcadBlockReference.ObjectID;
			}
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			double ddblLineOwnerID = default(double);
			bool BkDXFReadEnt_AcadSequenceEnd = default(bool);
			AcadSequenceEnd dobjAcadSequenceEnd2 = default(AcadSequenceEnd);
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
			{
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool dblnError = default(bool);
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					if (robjAcadPolyfaceMesh != null)
					{
						dobjAcadSequenceEnd2 = robjAcadPolyfaceMesh.FriendAddAcadObjectSequenceEnd(ddblObjectID, nvblnWithoutObjectID: false, ref nrstrErrMsg);
					}
					else if (robjAcadPolygonMesh != null)
					{
						dobjAcadSequenceEnd2 = robjAcadPolygonMesh.FriendAddAcadObjectSequenceEnd(ddblObjectID, nvblnWithoutObjectID: false, ref nrstrErrMsg);
					}
					else if (robjAcad3DPolyline != null)
					{
						dobjAcadSequenceEnd2 = robjAcad3DPolyline.FriendAddAcadObjectSequenceEnd(ref nrstrErrMsg, ddblObjectID, nvblnWithoutObjectID: false);
					}
					else if (robjAcadPolyline != null)
					{
						dobjAcadSequenceEnd2 = robjAcadPolyline.FriendAddAcadObjectSequenceEnd(ddblObjectID, nvblnWithoutObjectID: false, ref nrstrErrMsg);
					}
					else if (robjAcadMInsertBlock != null)
					{
						dobjAcadSequenceEnd2 = robjAcadMInsertBlock.FriendAddAcadObjectSequenceEnd(ref nrstrErrMsg, ddblObjectID, nvblnWithoutObjectID: false);
					}
					else if (robjAcadBlockReference != null)
					{
						dobjAcadSequenceEnd2 = robjAcadBlockReference.FriendAddAcadObjectSequenceEnd(ref nrstrErrMsg, ddblObjectID, nvblnWithoutObjectID: false);
					}
					if (dobjAcadSequenceEnd2 == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						AcadSequenceEnd acadSequenceEnd = dobjAcadSequenceEnd2;
						acadSequenceEnd.Layer = dstrLayer;
						acadSequenceEnd.FriendSetDictReactors = dobjDictReactors2;
						acadSequenceEnd = null;
					}
				}
				BkDXFReadEnt_AcadSequenceEnd = !dblnError;
			}
			dobjAcadSequenceEnd2 = null;
			dobjDictXDictionary2 = null;
			dobjDictReactors2 = null;
			return BkDXFReadEnt_AcadSequenceEnd;
		}

		public static bool BkDXFReadEnt_AcadShape(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecInsertionPoint = new object[3];
			double[] dadblInsertionPoint = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadShape = default(bool);
				AcadShape dobjAcadShape2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbShape", TextCompare: false))
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
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 40, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Höhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 2, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Symbolname in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
							dblnError = true;
						}
						else
						{
							bool flag3 = false;
							dadblInsertionPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							dadblInsertionPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
							dadblInsertionPoint[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
							double ddblHeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
							string dstrName = Conversions.ToString(vobjDictReadValues[rlngIdx + 4]);
							rlngIdx += 5;
							double ddblRotationDegree;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 50, TextCompare: false))
							{
								bool flag4 = false;
								ddblRotationDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag5 = false;
								ddblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
							}
							double ddblScaleFactor;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
							{
								bool flag6 = false;
								ddblScaleFactor = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag7 = false;
								ddblScaleFactor = hwpDxf_Vars.pdblScaleFactor;
							}
							double ddblObliqueAngleDegree;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 51, TextCompare: false))
							{
								bool flag8 = false;
								ddblObliqueAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag9 = false;
								ddblObliqueAngleDegree = Conversions.ToDouble(hwpDxf_Vars.pdecObliqueAngleDegree);
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
							{
								bool flag10 = false;
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
									bool flag11 = false;
									dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
								}
							}
							else
							{
								bool flag12 = false;
								dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
								dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
								dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
							}
							if (!dblnError)
							{
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										object ddecScaleFactor = default(object);
										object ddecRotationDegree = default(object);
										dobjAcadShape2 = robjAcadBlock.FriendAddAcadObjectShape(ddblObjectID, dstrName, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecInsertionPoint, dadblInsertionPoint)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecScaleFactor), ddblScaleFactor)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecRotationDegree), ddblRotationDegree)), ref nrstrErrMsg);
										if (dobjAcadShape2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadShape acadShape = dobjAcadShape2;
											acadShape.FriendSetDictReactors = dobjDictReactors2;
											acadShape.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadShape.Layer = dstrLayer;
											acadShape.Linetype = dstrLineType;
											acadShape.Color = unchecked((Enums.AcColor)dlngColor);
											acadShape.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadShape.Visible = (dlngVisible == 0);
											acadShape.FriendLetRGB = dlngRGB;
											acadShape.Lineweight = dnumLineweight;
											acadShape.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											bool flag13 = false;
											acadShape.Height = ddblHeight;
											bool flag14 = false;
											acadShape.ObliqueAngleDegree = ddblObliqueAngleDegree;
											acadShape.Thickness = ddblThickness;
											acadShape.Normal = Support.CopyArray(dadblNormal);
											acadShape.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadShape = null;
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadShape = !dblnError;
				}
				dobjAcadShape2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadShape;
			}
		}

		public static bool BkDXFReadEnt_AcadEllipse(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCenter = new object[3];
			double[] dadblCenter = new double[3];
			object[] dadecMajorAxis = new object[3];
			double[] dadblMajorAxis = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadEllipse = default(bool);
				AcadEllipse dobjAcadEllipse2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbEllipse", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zentrumspunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt der Hauptachse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt der Hauptachse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt der Hauptachse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblCenter[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblCenter[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						dadblCenter[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						dadblMajorAxis[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						dadblMajorAxis[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						dadblMajorAxis[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
						rlngIdx += 7;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag2 = false;
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
								bool flag3 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag4 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 40, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Verhältins Nebenachse zu Hauptachse in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 41, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Startparameter in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 42, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Endparameter in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
								dblnError = true;
							}
							else
							{
								bool flag5 = false;
								double ddblRadiusRatio = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								double ddblStartParameter = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								double ddblEndParameter = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
								rlngIdx += 3;
								object dvarXDataType = default(object);
								object dvarXDataValue = default(object);
								dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
								if (!dblnError)
								{
									dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
									if (!dblnError)
									{
										object ddecRadiusRatio = default(object);
										dobjAcadEllipse2 = robjAcadBlock.FriendAddAcadObjectEllipse(ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCenter, dadblCenter)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecMajorAxis, dadblMajorAxis)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecRadiusRatio), ddblRadiusRatio)), ref nrstrErrMsg);
										if (dobjAcadEllipse2 == null)
										{
											nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
											dblnError = true;
										}
										else
										{
											AcadEllipse acadEllipse = dobjAcadEllipse2;
											acadEllipse.FriendSetDictReactors = dobjDictReactors2;
											acadEllipse.FriendSetDictXDictionary = dobjDictXDictionary2;
											acadEllipse.Layer = dstrLayer;
											acadEllipse.Linetype = dstrLineType;
											acadEllipse.Color = unchecked((Enums.AcColor)dlngColor);
											acadEllipse.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
											acadEllipse.Visible = (dlngVisible == 0);
											acadEllipse.FriendLetRGB = dlngRGB;
											acadEllipse.Lineweight = dnumLineweight;
											acadEllipse.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
											bool flag6 = false;
											acadEllipse.Normal = Support.CopyArray(dadblNormal);
											acadEllipse.StartParameter = ddblStartParameter;
											acadEllipse.EndParameter = ddblEndParameter;
											acadEllipse.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
											acadEllipse = null;
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadEllipse = !dblnError;
				}
				dobjAcadEllipse2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadEllipse;
			}
		}

		public static bool BkDXFReadEnt_AcadHatch(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecElevation = new object[3];
			double[] dadblElevation = new double[3];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadHatch = default(bool);
				AcadHatch dobjAcadHatch2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbHatch", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblElevation[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblElevation[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						dadblElevation[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						rlngIdx += 4;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag2 = false;
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
								bool flag3 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag4 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 2, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Schraffurmustername in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 70, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Flag für Flächenfüllung in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 71, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Flag für Assoziativität in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 91, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Schraffurkonturen in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
								dblnError = true;
							}
							else
							{
								string dstrPatternName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
								int dlngIsSolid = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
								bool dblnIsSolid = dlngIsSolid == 1;
								int dlngAssociativeHatch = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
								bool dblnAssociativeHatch = dlngAssociativeHatch == 1;
								int dlngNumberOfLoops = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
								rlngIdx += 4;
								dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
								if (!dblnError)
								{
									dobjAcadHatch2 = robjAcadBlock.FriendAddAcadObjectHatch(ddblObjectID, unchecked((int)hwpDxf_Vars.pnumPatternType), dstrPatternName, dblnAssociativeHatch, ref nrstrErrMsg);
									if (dobjAcadHatch2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										if (dlngNumberOfLoops > 0)
										{
											if (!BkDXFReadEnt_AcadHatchLoops(ref rlngIdx, ref dobjAcadHatch2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
											{
												dblnError = true;
											}
											else if (dlngNumberOfLoops != dobjAcadHatch2.NumberOfLoops)
											{
												nrstrErrMsg = "Ungültige Anzahl der Schraffurkonturen vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
												dblnError = true;
											}
										}
										if (!dblnError)
										{
											if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 75, TextCompare: false))
											{
												nrstrErrMsg = "Ungültiger Gruppencode für Inselerkennungstil in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
												dblnError = true;
											}
											else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 76, TextCompare: false))
											{
												nrstrErrMsg = "Ungültiger Gruppencode für Typ des Schraffurmusters in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
												dblnError = true;
											}
											else
											{
												Enums.AcHatchStyle dnumHatchStyle;
												Enums.AcPatternType dnumPatternType;
												unchecked
												{
													dnumHatchStyle = (Enums.AcHatchStyle)Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
													dnumPatternType = (Enums.AcPatternType)Conversions.ToInteger(vobjDictReadValues[checked(rlngIdx + 1)]);
												}
												rlngIdx += 2;
												double ddblPatternAngle = default(double);
												double ddblPatternScale = default(double);
												double ddblPatternSpace = default(double);
												bool dblnPatternDouble = default(bool);
												if (!dblnIsSolid)
												{
													if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 52, TextCompare: false))
													{
														nrstrErrMsg = "Ungültiger Gruppencode für Winkel des Schraffurmusters in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
														dblnError = true;
													}
													else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 41, TextCompare: false))
													{
														nrstrErrMsg = "Ungültiger Gruppencode für Skalierung oder Abstand des Schraffurmusters in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
														dblnError = true;
													}
													else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 77, TextCompare: false))
													{
														nrstrErrMsg = "Ungültiger Gruppencode für Flag für doppeltes Schraffurmuster in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
														dblnError = true;
													}
													else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 78, TextCompare: false))
													{
														nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Definitionslinien im Muster in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
														dblnError = true;
													}
													else
													{
														bool flag5 = false;
														ddblPatternAngle = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
														ddblPatternScale = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
														ddblPatternSpace = ddblPatternScale;
														bool dlngPatternDouble = Conversions.ToBoolean(vobjDictReadValues[rlngIdx + 2]);
														dblnPatternDouble = (unchecked(0 - (dlngPatternDouble ? 1 : 0)) == 1);
														int dlngNumberOfPatternDefinitions = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
														rlngIdx += 4;
														if (dlngNumberOfPatternDefinitions > 0)
														{
															if (!BkDXFReadEnt_AcadHatchPatternDefinitions(ref rlngIdx, ref dobjAcadHatch2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
															{
																dblnError = true;
															}
															else if (dlngNumberOfPatternDefinitions != dobjAcadHatch2.NumberOfPatternDefinitions)
															{
																nrstrErrMsg = "Ungültige Anzahl der Definitionslinien vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
																dblnError = true;
															}
														}
													}
												}
												if (!dblnError)
												{
													double ddblPixelSize;
													if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 47, TextCompare: false))
													{
														bool flag6 = false;
														ddblPixelSize = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
														rlngIdx++;
													}
													else
													{
														bool flag7 = false;
														ddblPixelSize = Conversions.ToDouble(hwpDxf_Vars.pdblPixelSize);
													}
													if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 98, TextCompare: false))
													{
														nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Schraffurkontur-Saatpunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
														dblnError = true;
													}
													else
													{
														int dlngNumberOfSeedPoints = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
														rlngIdx++;
														if (dlngNumberOfSeedPoints > 0)
														{
															if (!BkDXFReadEnt_AcadHatchSeedPoints(ref rlngIdx, ref dobjAcadHatch2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
															{
																dblnError = true;
															}
															else if (dlngNumberOfSeedPoints != dobjAcadHatch2.NumberOfSeedPoints)
															{
																nrstrErrMsg = "Ungültige Anzahl der Schraffurkontur-Saatpunkte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
																dblnError = true;
															}
														}
														int pclngGrpAbstufung = 450;
														int pclngGrpReserviert = 451;
														int pclngGrpDrehwinkel = 460;
														int pclngGrpMuster = 461;
														int pclngGrpArt = 452;
														int pclngGrpFärbungswert = 462;
														int pclngGrpAnzahl = 453;
														int pclngGrpFarbnummer = 463;
														int pclngGrpFarbwertACI = 63;
														int pclngGrpFarbwertRGB = 421;
														int pclngGrpString = 470;
														int plngAbstufung = 0;
														int plngReserviert = 0;
														object pdecDrehwinkel = 0m;
														double pdblDrehwinkel = 0.0;
														object pdecMuster = 0m;
														double pdblMuster = 0.0;
														int plngArt = 0;
														object pdecFärbungswert = 0m;
														double pdblFärbungswert = 0.0;
														int plngAnzahl = 0;
														object pdecFarbnummer1 = 0m;
														double pdblFarbnummer1 = 0.0;
														int plngFarbwertACI1 = 5;
														int plngFarbwertRGB1 = 255;
														object pdecFarbnummer2 = 1m;
														double pdblFarbnummer2 = 1.0;
														int plngFarbwertACI2 = 7;
														int plngFarbwertRGB2 = 16777215;
														string pstrString = null;
														if (!dblnError)
														{
															if (Operators.CompareString(dstrAcadVer, "AC1018", TextCompare: false) >= 0)
															{
																if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], pclngGrpAbstufung, TextCompare: false))
																{
																	int dlngAbstufung3 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
																	rlngIdx++;
																	if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], pclngGrpReserviert, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für reservierten Eintrag in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
																		dblnError = true;
																	}
																	else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], pclngGrpDrehwinkel, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für Drehwinkel der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
																		dblnError = true;
																	}
																	else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], pclngGrpMuster, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für Muster der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
																		dblnError = true;
																	}
																	else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], pclngGrpArt, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für Art der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
																		dblnError = true;
																	}
																	else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], pclngGrpFärbungswert, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für Färbungswert der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
																		dblnError = true;
																	}
																	else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], pclngGrpAnzahl, TextCompare: false))
																	{
																		nrstrErrMsg = "Ungültiger Gruppencode für Farbanzahl der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
																		dblnError = true;
																	}
																	else
																	{
																		int dlngReserviert3 = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
																		bool flag8 = false;
																		double ddblDrehwinkel3 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
																		double ddblMuster3 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
																		int dlngArt3 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
																		bool flag9 = false;
																		double ddblFärbungswert3 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
																		int dlngAnzahl3 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 5]);
																		rlngIdx += 6;
																		if (dlngAnzahl3 > 0)
																		{
																			if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], pclngGrpFarbnummer, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 1. Farbnummer der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
																				dblnError = true;
																			}
																			else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], pclngGrpFarbwertACI, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 1. ACI-Farbwert der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
																				dblnError = true;
																			}
																			else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], pclngGrpFarbwertRGB, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 1. RGB-Farbwert der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
																				dblnError = true;
																			}
																			else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], pclngGrpFarbnummer, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 2. Farbnummer der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
																				dblnError = true;
																			}
																			else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], pclngGrpFarbwertACI, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 2. ACI-Farbwert der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
																				dblnError = true;
																			}
																			else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], pclngGrpFarbwertRGB, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für 2. RGB-Farbwert der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
																				dblnError = true;
																			}
																			else
																			{
																				bool flag10 = false;
																				double ddblFarbnummer4 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
																				int dlngFarbwertACI4 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
																				int dlngFarbwertRGB4 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
																				bool flag11 = false;
																				double ddblFarbnummer8 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
																				int dlngFarbwertACI8 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 4]);
																				int dlngFarbwertRGB8 = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 5]);
																				rlngIdx += 6;
																			}
																		}
																		else
																		{
																			bool flag12 = false;
																			double ddblFarbnummer4 = pdblFarbnummer1;
																			int dlngFarbwertACI4 = plngFarbwertACI1;
																			int dlngFarbwertRGB4 = plngFarbwertRGB1;
																			bool flag13 = false;
																			double ddblFarbnummer8 = pdblFarbnummer2;
																			int dlngFarbwertACI8 = plngFarbwertACI2;
																			int dlngFarbwertRGB8 = plngFarbwertRGB2;
																		}
																		if (!dblnError)
																		{
																			if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], pclngGrpString, TextCompare: false))
																			{
																				nrstrErrMsg = "Ungültiger Gruppencode für Bezeichnung der Abstufung in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
																				dblnError = true;
																			}
																			else
																			{
																				string dstrString3 = Conversions.ToString(vobjDictReadValues[rlngIdx]);
																				rlngIdx++;
																			}
																		}
																	}
																}
																else
																{
																	int dlngAbstufung3 = plngAbstufung;
																	int dlngReserviert3 = plngReserviert;
																	bool flag14 = false;
																	double ddblDrehwinkel3 = pdblDrehwinkel;
																	double ddblMuster3 = pdblMuster;
																	int dlngArt3 = plngArt;
																	bool flag15 = false;
																	double ddblFärbungswert3 = pdblFärbungswert;
																	int dlngAnzahl3 = plngAnzahl;
																	bool flag16 = false;
																	double ddblFarbnummer4 = pdblFarbnummer1;
																	int dlngFarbwertACI4 = plngFarbwertACI1;
																	int dlngFarbwertRGB4 = plngFarbwertRGB1;
																	bool flag17 = false;
																	double ddblFarbnummer8 = pdblFarbnummer2;
																	int dlngFarbwertACI8 = plngFarbwertACI2;
																	int dlngFarbwertRGB8 = plngFarbwertRGB2;
																	string dstrString3 = pstrString;
																}
															}
															else
															{
																int dlngAbstufung3 = plngAbstufung;
																int dlngReserviert3 = plngReserviert;
																bool flag18 = false;
																double ddblDrehwinkel3 = pdblDrehwinkel;
																double ddblMuster3 = pdblMuster;
																int dlngArt3 = plngArt;
																bool flag19 = false;
																double ddblFärbungswert3 = pdblFärbungswert;
																int dlngAnzahl3 = plngAnzahl;
																bool flag20 = false;
																double ddblFarbnummer4 = pdblFarbnummer1;
																int dlngFarbwertACI4 = plngFarbwertACI1;
																int dlngFarbwertRGB4 = plngFarbwertRGB1;
																bool flag21 = false;
																double ddblFarbnummer8 = pdblFarbnummer2;
																int dlngFarbwertACI8 = plngFarbwertACI2;
																int dlngFarbwertRGB8 = plngFarbwertRGB2;
																string dstrString3 = pstrString;
															}
															if (!dblnError)
															{
																object dvarXDataType = default(object);
																object dvarXDataValue = default(object);
																dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
																if (!dblnError)
																{
																	AcadHatch acadHatch = dobjAcadHatch2;
																	acadHatch.FriendSetDictReactors = dobjDictReactors2;
																	acadHatch.FriendSetDictXDictionary = dobjDictXDictionary2;
																	acadHatch.Layer = dstrLayer;
																	acadHatch.Linetype = dstrLineType;
																	acadHatch.Color = unchecked((Enums.AcColor)dlngColor);
																	acadHatch.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
																	acadHatch.Visible = (dlngVisible == 0);
																	acadHatch.FriendLetRGB = dlngRGB;
																	acadHatch.Lineweight = dnumLineweight;
																	acadHatch.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
																	bool flag22 = false;
																	acadHatch.Elevation = Support.CopyArray(dadblElevation);
																	acadHatch.Normal = Support.CopyArray(dadblNormal);
																	acadHatch.FriendLetIsSolid = dblnIsSolid;
																	acadHatch.HatchStyle = dnumHatchStyle;
																	acadHatch.FriendLetPatternType = dnumPatternType;
																	if (!dblnIsSolid)
																	{
																		bool flag23 = false;
																		acadHatch.PatternAngle = ddblPatternAngle;
																		acadHatch.PatternScale = ddblPatternScale;
																		acadHatch.PatternSpace = ddblPatternSpace;
																		acadHatch.PatternDouble = dblnPatternDouble;
																	}
																	bool flag24 = false;
																	acadHatch.FriendLetPixelSize = ddblPixelSize;
																	acadHatch.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
																	acadHatch = null;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadHatch = !dblnError;
				}
				dobjAcadHatch2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadHatch;
			}
		}

		private static bool BkDXFReadEnt_AcadHatchLoops(ref int rlngIdx, ref AcadHatch robjAcadHatch, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadLoops dobjAcadLoops2 = robjAcadHatch.Loops;
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (!dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				if (dlngCode != 92)
				{
					dblnStop = true;
				}
				else if (!BkDXFReadEnt_AcadHatchLoop(ref rlngIdx, ref dobjAcadLoops2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool BkDXFReadEnt_AcadHatchLoops = !dblnError;
			dobjAcadLoops2 = null;
			return BkDXFReadEnt_AcadHatchLoops;
		}

		private static bool BkDXFReadEnt_AcadHatchLoop(ref int rlngIdx, ref AcadLoops robjAcadLoops, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				Dictionary<object, object> dobjDictAssocObjectIDs2;
				AcadLoop dobjAcadLoop2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 92, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Flag für Schraffurkonturtyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					Enums.AcLoopType dnumLoopType = unchecked((Enums.AcLoopType)Conversions.ToInteger(vobjDictReadValues[rlngIdx]));
					rlngIdx++;
					dobjAcadLoop2 = robjAcadLoops.FriendAdd();
					AcadLoop acadLoop = dobjAcadLoop2;
					acadLoop.FriendLetLoopType = dnumLoopType;
					acadLoop = null;
					if (dobjAcadLoop2.IsPolyline)
					{
						dblnError = !BkDXFReadEnt_AcGePolyline2d(ref rlngIdx, ref dobjAcadLoop2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 93, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Schraffurkontur-Kanten in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						int dlngNumberOfEdges = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						if (dlngNumberOfEdges > 0)
						{
							if (!BkDXFReadEnt_AcadHatchLoopEdges(ref rlngIdx, ref dobjAcadLoop2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
							{
								dblnError = true;
							}
							else if (dlngNumberOfEdges != dobjAcadLoop2.NumberOfEdges)
							{
								nrstrErrMsg = "Ungültige Anzahl der Schraffurkontur-Kanten vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
						}
					}
					if (!dblnError)
					{
						if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 97, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Objekt-IDs der Schraffurkontur-Quellobjekte in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else
						{
							int dlngAssocObjectIDs = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (dlngAssocObjectIDs > 0)
							{
								dobjDictAssocObjectIDs2 = new Dictionary<object, object>();
								int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
								while (unchecked(dlngCode == 330 && !dblnError))
								{
									double ddblObjectID = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									try
									{
										dobjDictAssocObjectIDs2.Add(ddblObjectID, dlngCode);
									}
									catch (Exception ex2)
									{
										ProjectData.SetProjectError(ex2);
										Exception ex = ex2;
										nrstrErrMsg = "Ungültige oder doppelte Objekt-ID für Schraffurkontor-Quellobjekte in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
										dblnError = true;
										ProjectData.ClearProjectError();
									}
									if (!dblnError)
									{
										rlngIdx++;
										dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									}
								}
								if (!dblnError)
								{
									if (dlngAssocObjectIDs != dobjDictAssocObjectIDs2.Count)
									{
										nrstrErrMsg = "Ungültige Anzahl der Objekt-IDs der Schraffurkontur-Quellobjekte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else
									{
										AcadLoop acadLoop2 = dobjAcadLoop2;
										acadLoop2.FriendSetAssocObjects = dobjDictAssocObjectIDs2;
										acadLoop2 = null;
									}
								}
							}
						}
					}
				}
				bool BkDXFReadEnt_AcadHatchLoop = !dblnError;
				dobjDictAssocObjectIDs2 = null;
				dobjAcadLoop2 = null;
				return BkDXFReadEnt_AcadHatchLoop;
			}
		}

		private static bool BkDXFReadEnt_AcadHatchLoopEdges(ref int rlngIdx, ref AcadLoop robjAcadLoop, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadLoopEdges dobjAcadLoopEdges2 = robjAcadLoop.FriendAddLoopEdges();
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (!dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				if (dlngCode != 72)
				{
					dblnStop = true;
				}
				else if (!BkDXFReadEnt_AcadHatchLoopEdge(ref rlngIdx, ref dobjAcadLoopEdges2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool BkDXFReadEnt_AcadHatchLoopEdges = !dblnError;
			dobjAcadLoopEdges2 = null;
			return BkDXFReadEnt_AcadHatchLoopEdges;
		}

		private static bool BkDXFReadEnt_AcadHatchLoopEdge(ref int rlngIdx, ref AcadLoopEdges robjAcadLoopEdges, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError;
				AcadLoopEdge dobjAcadLoopEdge2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 72, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Schraffurkontur-Kantentyp in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					Enums.AcLoopEdgeType dnumEdgeType = unchecked((Enums.AcLoopEdgeType)Conversions.ToInteger(vobjDictReadValues[rlngIdx]));
					rlngIdx++;
					dobjAcadLoopEdge2 = robjAcadLoopEdges.FriendAdd();
					AcadLoopEdge acadLoopEdge = dobjAcadLoopEdge2;
					acadLoopEdge.FriendLetEdgeType = dnumEdgeType;
					acadLoopEdge = null;
					switch (dnumEdgeType)
					{
						case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeLine:
							dblnError = !BkDXFReadEnt_AcGeLinSeg2d(ref rlngIdx, ref dobjAcadLoopEdge2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
							break;
						case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeCirArc:
							dblnError = !BkDXFReadEnt_AcGeCircArc2d(ref rlngIdx, ref dobjAcadLoopEdge2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
							break;
						case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeEllArc:
							dblnError = !BkDXFReadEnt_AcGeEllipArc2d(ref rlngIdx, ref dobjAcadLoopEdge2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
							break;
						case Enums.AcLoopEdgeType.acHatchLoopEdgeTypeSpline:
							dblnError = !BkDXFReadEnt_AcGeNurbCurve2d(ref rlngIdx, ref dobjAcadLoopEdge2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg);
							break;
						default:
							nrstrErrMsg = "Unbekannter Schraffurkontur-Kantentyp ab Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
							dblnError = true;
							break;
					}
				}
				bool BkDXFReadEnt_AcadHatchLoopEdge = !dblnError;
				dobjAcadLoopEdge2 = null;
				return BkDXFReadEnt_AcadHatchLoopEdge;
			}
		}

		private static bool BkDXFReadEnt_AcGePolyline2d(ref int rlngIdx, ref AcadLoop robjAcadLoop, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcGePolyline2d dobjAcGePolyline2d2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 72, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Flag 'Mit Ausbuchtung' in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 73, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Flag 'Geschlossen' in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 93, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Kontrollpunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else
				{
					int dlngBulged = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
					bool dblnBulged = dlngBulged == 1;
					int dlngClosed = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
					bool dblnClosed = dlngClosed == 1;
					int dlngNumberOfVertices = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
					rlngIdx += 3;
					dobjAcGePolyline2d2 = robjAcadLoop.FriendAddAcGePolyline2d();
					AcGePolyline2d acGePolyline2d = dobjAcGePolyline2d2;
					acGePolyline2d.FriendLetClosed = dblnClosed;
					acGePolyline2d = null;
					if (dlngNumberOfVertices > 0)
					{
						int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						while (unchecked(dlngCode == 10 && !dblnError))
						{
							bool flag = false;
							double ddblCoordX = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 20, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Schraffurkontur-Kontrollpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
								continue;
							}
							bool flag2 = false;
							double ddblCoordY = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							double ddblBulge;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
							{
								bool flag3 = false;
								ddblBulge = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag4 = false;
								ddblBulge = hwpDxf_Vars.pdblBulge;
							}
							bool flag5 = false;
							dobjAcGePolyline2d2.FriendAddVertex(ddblCoordX, ddblCoordY, ddblBulge);
							dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						}
						if (!dblnError && dlngNumberOfVertices != dobjAcGePolyline2d2.NumberOfVertices)
						{
							nrstrErrMsg = "Ungültige Anzahl der Schraffurkontur-Kontrollpunkte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
					}
				}
				bool BkDXFReadEnt_AcGePolyline2d = !dblnError;
				dobjAcGePolyline2d2 = null;
				return BkDXFReadEnt_AcGePolyline2d;
			}
		}

		private static bool BkDXFReadEnt_AcGeLinSeg2d(ref int rlngIdx, ref AcadLoopEdge robjAcadLoopEdge, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecStartPoint = new object[2];
			double[] dadblStartPoint = new double[2];
			object[] dadecEndPoint = new object[2];
			double[] dadblEndPoint = new double[2];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcGeLinSeg2d dobjAcGeLinSeg2d2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Startpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 11, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 21, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					dadblStartPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					dadblStartPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
					dadblEndPoint[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
					dadblEndPoint[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
					rlngIdx += 4;
					dobjAcGeLinSeg2d2 = (AcGeLinSeg2d)robjAcadLoopEdge.FriendAddEdgeObject();
					AcGeLinSeg2d acGeLinSeg2d = dobjAcGeLinSeg2d2;
					bool flag2 = false;
					acGeLinSeg2d.FriendLetStartPoint = Support.CopyArray(dadblStartPoint);
					acGeLinSeg2d.FriendLetEndPoint = Support.CopyArray(dadblEndPoint);
					acGeLinSeg2d = null;
				}
				bool BkDXFReadEnt_AcGeLinSeg2d = !dblnError;
				dobjAcGeLinSeg2d2 = null;
				return BkDXFReadEnt_AcGeLinSeg2d;
			}
		}

		private static bool BkDXFReadEnt_AcGeCircArc2d(ref int rlngIdx, ref AcadLoopEdge robjAcadLoopEdge, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCenter = new object[2];
			double[] dadblCenter = new double[2];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcGeCircArc2d dobjAcGeCircArc2d2;
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
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 40, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Radius in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 50, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Startwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 51, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 73, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Flag 'Gegen den Uhrzeigersinn' in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					dadblCenter[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					dadblCenter[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
					double ddblRadius = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
					double ddblStartAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
					double ddblEndAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
					int dlngIsClockWise = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 5]);
					bool dblnIsClockWise = dlngIsClockWise == 1;
					rlngIdx += 6;
					dobjAcGeCircArc2d2 = (AcGeCircArc2d)robjAcadLoopEdge.FriendAddEdgeObject();
					AcGeCircArc2d acGeCircArc2d = dobjAcGeCircArc2d2;
					bool flag2 = false;
					acGeCircArc2d.FriendLetCenter = Support.CopyArray(dadblCenter);
					acGeCircArc2d.FriendLetRadius = ddblRadius;
					acGeCircArc2d.FriendLetStartAngleDegree = ddblStartAngleDegree;
					acGeCircArc2d.FriendLetEndAngleDegree = ddblEndAngleDegree;
					acGeCircArc2d.FriendLetIsClockWise = dblnIsClockWise;
					acGeCircArc2d = null;
				}
				bool BkDXFReadEnt_AcGeCircArc2d = !dblnError;
				dobjAcGeCircArc2d2 = null;
				return BkDXFReadEnt_AcGeCircArc2d;
			}
		}

		private static bool BkDXFReadEnt_AcGeEllipArc2d(ref int rlngIdx, ref AcadLoopEdge robjAcadLoopEdge, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCenter = new object[2];
			double[] dadblCenter = new double[2];
			object[] dadecMajorAxis = new object[2];
			double[] dadblMajorAxis = new double[2];
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcGeEllipArc2d dobjAcGeEllipArc2d2;
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
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 11, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt der Hauptachse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 21, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endpunkt der Hauptachse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 40, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für prozentuale Länge der Nebenachse in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 50, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Startwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 51, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Endwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 73, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Flag 'Gegen den Uhrzeigersinn' in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					dadblCenter[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					dadblCenter[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
					dadblMajorAxis[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
					dadblMajorAxis[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
					double ddblRadiusRatio = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
					double ddblStartAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
					double ddblEndAngleDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
					int dlngIsClockWise = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 7]);
					bool dblnIsClockWise = dlngIsClockWise == 1;
					rlngIdx += 8;
					dobjAcGeEllipArc2d2 = (AcGeEllipArc2d)robjAcadLoopEdge.FriendAddEdgeObject();
					AcGeEllipArc2d acGeEllipArc2d = dobjAcGeEllipArc2d2;
					bool flag2 = false;
					acGeEllipArc2d.FriendLetCenter = Support.CopyArray(dadblCenter);
					acGeEllipArc2d.FriendLetMajorAxis = Support.CopyArray(dadblMajorAxis);
					acGeEllipArc2d.FriendLetRadiusRatio = ddblRadiusRatio;
					acGeEllipArc2d.FriendLetStartAngleDegree = ddblStartAngleDegree;
					acGeEllipArc2d.FriendLetEndAngleDegree = ddblEndAngleDegree;
					acGeEllipArc2d.FriendLetIsClockWise = dblnIsClockWise;
					acGeEllipArc2d = null;
				}
				bool BkDXFReadEnt_AcGeEllipArc2d = !dblnError;
				dobjAcGeEllipArc2d2 = null;
				return BkDXFReadEnt_AcGeEllipArc2d;
			}
		}

		private static bool BkDXFReadEnt_AcGeNurbCurve2d(ref int rlngIdx, ref AcadLoopEdge robjAcadLoopEdge, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcGeNurbCurve2d dobjAcGeNurbCurve2d2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 94, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Kurvengrad in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 73, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Rational in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 74, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Periodisch in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 95, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Knoten in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 96, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Kontrollpunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					double ddblDegree = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					int dlngIsRational = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
					bool dblnIsRational = dlngIsRational == 1;
					int dlngIsPeriodic = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
					bool dblnIsPeriodic = dlngIsPeriodic == 1;
					int dlngNumberOfKnots = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
					int dlngNumberOfControlPoints = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 4]);
					rlngIdx += 5;
					dobjAcGeNurbCurve2d2 = (AcGeNurbCurve2d)robjAcadLoopEdge.FriendAddEdgeObject();
					AcGeNurbCurve2d acGeNurbCurve2d = dobjAcGeNurbCurve2d2;
					bool flag2 = false;
					acGeNurbCurve2d.FriendLetDegree = (int)Math.Round(ddblDegree);
					acGeNurbCurve2d.FriendLetIsRational = dblnIsRational;
					acGeNurbCurve2d.FriendLetIsPeriodic = dblnIsPeriodic;
					acGeNurbCurve2d = null;
					if (dlngNumberOfKnots > 0)
					{
						int dlngCode2 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						while (unchecked(dlngCode2 == 40 && !dblnError))
						{
							bool flag3 = false;
							double ddblKnot = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							bool flag4 = false;
							dobjAcGeNurbCurve2d2.FriendAddKnot(ddblKnot);
							dlngCode2 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						}
						if (!dblnError && dlngNumberOfKnots != dobjAcGeNurbCurve2d2.NumberOfKnots)
						{
							nrstrErrMsg = "Ungültige Anzahl der Knoten vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
					}
					if (!dblnError && dlngNumberOfControlPoints > 0)
					{
						int dlngCode2 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						while (unchecked(dlngCode2 == 10 && !dblnError))
						{
							bool flag5 = false;
							double ddblCoordX = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 20, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Kontrollpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
								continue;
							}
							bool flag6 = false;
							double ddblCoordY = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
							double ddblWeight;
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 42, TextCompare: false))
							{
								bool flag7 = false;
								ddblWeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								rlngIdx++;
							}
							else
							{
								bool flag8 = false;
								ddblWeight = hwpDxf_Vars.pdblWeight;
							}
							bool flag9 = false;
							dobjAcGeNurbCurve2d2.FriendAddControlPoint(ddblCoordX, ddblCoordY, ddblWeight);
							dlngCode2 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
						}
						if (!dblnError && dlngNumberOfControlPoints != dobjAcGeNurbCurve2d2.NumberOfControlPoints)
						{
							nrstrErrMsg = "Ungültige Anzahl der Kontrollpunkte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
					}
				}
				bool BkDXFReadEnt_AcGeNurbCurve2d = !dblnError;
				dobjAcGeNurbCurve2d2 = null;
				return BkDXFReadEnt_AcGeNurbCurve2d;
			}
		}

		private static bool BkDXFReadEnt_AcadHatchPatternDefinitions(ref int rlngIdx, ref AcadHatch robjAcadHatch, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadPatternDefinitions dobjAcadPatternDefinitions2 = robjAcadHatch.FriendAddPatternDefinitions();
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (!dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				if (dlngCode != 53)
				{
					dblnStop = true;
				}
				else if (!BkDXFReadEnt_AcadHatchPatternDefinition(ref rlngIdx, ref dobjAcadPatternDefinitions2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool BkDXFReadEnt_AcadHatchPatternDefinitions = !dblnError;
			dobjAcadPatternDefinitions2 = null;
			return BkDXFReadEnt_AcadHatchPatternDefinitions;
		}

		private static bool BkDXFReadEnt_AcadHatchPatternDefinition(ref int rlngIdx, ref AcadPatternDefinitions robjAcadPatternDefinitions, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcadPatternDefinition dobjAcadPatternDefinition2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 53, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Winkel der Definitionslinie in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 43, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt X-Wert der Definitionslinie in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 44, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Y-Wert der Definitionslinie in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 45, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Versatz X-Wert der Definitionslinie in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 46, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Versatz Y-Wert der Definitionslinie in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 79, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Schraffurmuster-Strichlängen in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					double ddblAngle = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					double ddblBaseX = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
					double ddblBaseY = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
					double ddblOffsetX = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
					double ddblOffsetY = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
					int dlngNumberOfDashes = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 5]);
					rlngIdx += 6;
					dobjAcadPatternDefinition2 = robjAcadPatternDefinitions.FriendAdd();
					if (dlngNumberOfDashes > 0)
					{
						if (!BkDXFReadEnt_AcadHatchPatternDefDashes(ref rlngIdx, ref dobjAcadPatternDefinition2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
						{
							dblnError = true;
						}
						else if (dlngNumberOfDashes != dobjAcadPatternDefinition2.NumberOfDashes)
						{
							nrstrErrMsg = "Ungültige Anzahl der Schraffurmuster-Strichlängen vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
					}
					if (!dblnError)
					{
						AcadPatternDefinition acadPatternDefinition = dobjAcadPatternDefinition2;
						bool flag2 = false;
						acadPatternDefinition.FriendLetAngleDegree = ddblAngle;
						acadPatternDefinition.FriendLetBaseX = ddblBaseX;
						acadPatternDefinition.FriendLetBaseY = ddblBaseY;
						acadPatternDefinition.FriendLetOffsetX = ddblOffsetX;
						acadPatternDefinition.FriendLetOffsetY = ddblOffsetY;
						acadPatternDefinition = null;
					}
				}
				bool BkDXFReadEnt_AcadHatchPatternDefinition = !dblnError;
				dobjAcadPatternDefinition2 = null;
				return BkDXFReadEnt_AcadHatchPatternDefinition;
			}
		}

		private static bool BkDXFReadEnt_AcadHatchPatternDefDashes(ref int rlngIdx, ref AcadPatternDefinition robjAcadPatternDefinition, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadPatternDefDashes dobjAcadPatternDefDashes2 = robjAcadPatternDefinition.Dashes;
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (!dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				if (dlngCode != 49)
				{
					dblnStop = true;
				}
				else if (!BkDXFReadEnt_AcadHatchPatternDefDash(ref rlngIdx, ref dobjAcadPatternDefDashes2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool BkDXFReadEnt_AcadHatchPatternDefDashes = !dblnError;
			dobjAcadPatternDefDashes2 = null;
			return BkDXFReadEnt_AcadHatchPatternDefDashes;
		}

		private static bool BkDXFReadEnt_AcadHatchPatternDefDash(ref int rlngIdx, ref AcadPatternDefDashes robjAcadPatternDefDashes, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcadPatternDefDash dobjAcadPatternDefDash2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 49, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Strichlänge in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					double ddblLength = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					rlngIdx++;
					dobjAcadPatternDefDash2 = robjAcadPatternDefDashes.FriendAdd();
					AcadPatternDefDash acadPatternDefDash = dobjAcadPatternDefDash2;
					bool flag2 = false;
					acadPatternDefDash.FriendLetLength = ddblLength;
					acadPatternDefDash = null;
				}
				bool BkDXFReadEnt_AcadHatchPatternDefDash = !dblnError;
				dobjAcadPatternDefDash2 = null;
				return BkDXFReadEnt_AcadHatchPatternDefDash;
			}
		}

		private static bool BkDXFReadEnt_AcadHatchSeedPoints(ref int rlngIdx, ref AcadHatch robjAcadHatch, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			AcadSeedPoints dobjAcadSeedPoints2 = robjAcadHatch.FriendAddSeedPoints();
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			while (!dblnError && !dblnStop)
			{
				int dlngCode = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]);
				if (dlngCode != 10)
				{
					dblnStop = true;
				}
				else if (!BkDXFReadEnt_AcadHatchSeedPoint(ref rlngIdx, ref dobjAcadSeedPoints2, vobjDictReadCodes, vobjDictReadValues, ref nrstrErrMsg))
				{
					dblnError = true;
				}
			}
			bool BkDXFReadEnt_AcadHatchSeedPoints = !dblnError;
			dobjAcadSeedPoints2 = null;
			return BkDXFReadEnt_AcadHatchSeedPoints;
		}

		private static bool BkDXFReadEnt_AcadHatchSeedPoint(ref int rlngIdx, ref AcadSeedPoints robjAcadSeedPoints, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			checked
			{
				bool dblnError = default(bool);
				AcadSeedPoint dobjAcadSeedPoint2;
				if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 10, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Schraffurkontur-Saatpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Schraffurkontur-Saatpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
					dblnError = true;
				}
				else
				{
					bool flag = false;
					double ddblCoordX = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
					double ddblCoordY = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
					rlngIdx += 2;
					dobjAcadSeedPoint2 = robjAcadSeedPoints.FriendAdd();
					AcadSeedPoint acadSeedPoint = dobjAcadSeedPoint2;
					bool flag2 = false;
					acadSeedPoint.FriendLetCoordX = ddblCoordX;
					acadSeedPoint.FriendLetCoordY = ddblCoordY;
					acadSeedPoint = null;
				}
				bool BkDXFReadEnt_AcadHatchSeedPoint = !dblnError;
				dobjAcadSeedPoint2 = null;
				return BkDXFReadEnt_AcadHatchSeedPoint;
			}
		}

		public static bool BkDXFReadEnt_AcadSpline(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			object[] dadecStartTangent = new object[3];
			double[] dadblStartTangent = new double[3];
			object[] dadecEndTangent = new object[3];
			double[] dadblEndTangent = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadSpline = default(bool);
				AcGePoint3d dobjAcGePoint3d3;
				Dictionary<object, object> dobjDictFitPoints2 = default(Dictionary<object, object>);
				AcGeCtrlPoint3d dobjAcGeCtrlPoint3d3;
				Dictionary<object, object> dobjDictControlPoints2 = default(Dictionary<object, object>);
				Dictionary<object, object> dobjDictKnots2 = default(Dictionary<object, object>);
				AcadSpline dobjAcadSpline2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbSpline", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						rlngIdx++;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag = false;
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
								bool flag2 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag3 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 70, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Spline-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 71, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Kurvengrad in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 72, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Knoten in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 73, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Kontrollpunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 74, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Anzahl der Angleichungspunkte in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 42, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Knotentoleranz in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 43, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Kontrollpunkttoleranz in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
								dblnError = true;
							}
							else
							{
								int dlngSplineFlags = Conversions.ToInteger(vobjDictReadValues[rlngIdx]);
								int dlngDegree = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 1]);
								int dlngNumberOfKnots = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 2]);
								int dlngNumberOfControlPoints = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 3]);
								int dlngNumberOfFitPoints = Conversions.ToInteger(vobjDictReadValues[rlngIdx + 4]);
								bool flag4 = false;
								double ddblKnotTolerance = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
								double ddblControlPointTolerance = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 6]);
								rlngIdx += 7;
								double ddblFitTolerance;
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 44, TextCompare: false))
								{
									bool flag5 = false;
									ddblFitTolerance = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									bool flag6 = false;
									ddblFitTolerance = hwpDxf_Vars.pdblFitTolerance;
								}
								bool dblnHasStartTangent = default(bool);
								if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 12, TextCompare: false))
								{
									bool flag7 = false;
									dadblStartTangent[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
									rlngIdx++;
									if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 22, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Starttangente Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
									else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 32, TextCompare: false))
									{
										nrstrErrMsg = "Ungültiger Gruppencode für Starttangente Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
										dblnError = true;
									}
									else
									{
										bool flag8 = false;
										dadblStartTangent[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										dadblStartTangent[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
										dblnHasStartTangent = true;
										rlngIdx += 2;
									}
								}
								else
								{
									bool flag9 = false;
									dadblStartTangent[0] = hwpDxf_Vars.padblStartTangent[0];
									dadblStartTangent[1] = hwpDxf_Vars.padblStartTangent[1];
									dadblStartTangent[2] = hwpDxf_Vars.padblStartTangent[2];
									dblnHasStartTangent = false;
								}
								bool dblnHasEndTangent = default(bool);
								if (!dblnError)
								{
									if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 13, TextCompare: false))
									{
										bool flag10 = false;
										dadblEndTangent[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 23, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Endtangente Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
											dblnError = true;
										}
										else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 33, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Endtangente Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
											dblnError = true;
										}
										else
										{
											bool flag11 = false;
											dadblEndTangent[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
											dadblEndTangent[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
											dblnHasEndTangent = true;
											rlngIdx += 2;
										}
									}
									else
									{
										bool flag12 = false;
										dadblEndTangent[0] = hwpDxf_Vars.padblEndTangent[0];
										dadblEndTangent[1] = hwpDxf_Vars.padblEndTangent[1];
										dadblEndTangent[2] = hwpDxf_Vars.padblEndTangent[2];
										dblnHasEndTangent = false;
									}
								}
								if (!dblnError && dlngNumberOfKnots > 0)
								{
									dobjDictKnots2 = new Dictionary<object, object>();
									int dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									int dlngCount4 = 0;
									while (unchecked(dlngCode3 == 40 && !dblnError))
									{
										bool flag13 = false;
										double ddblKnot = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										dlngCount4++;
										bool flag14 = false;
										dobjDictKnots2.Add(dlngCount4, ddblKnot);
										dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									}
									if (!dblnError && dlngNumberOfKnots != dobjDictKnots2.Count)
									{
										nrstrErrMsg = "Ungültige Anzahl der Knoten vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
								}
								if (!dblnError && dlngNumberOfControlPoints > 0)
								{
									dobjDictControlPoints2 = new Dictionary<object, object>();
									int dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									int dlngCount4 = 0;
									double ddblCoordY2 = default(double);
									double ddblCoordZ2 = default(double);
									while (unchecked(dlngCode3 == 10 && !dblnError))
									{
										bool flag15 = false;
										double ddblCoordX2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 20, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Kontrollpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
											dblnError = true;
										}
										else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 30, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Kontrollpunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
											dblnError = true;
										}
										else
										{
											bool flag16 = false;
											ddblCoordY2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
											ddblCoordZ2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
											rlngIdx += 2;
										}
										double ddblWeight;
										if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 41, TextCompare: false))
										{
											bool flag17 = false;
											ddblWeight = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
											rlngIdx++;
										}
										else
										{
											bool flag18 = false;
											ddblWeight = hwpDxf_Vars.pdblWeight;
										}
										dlngCount4++;
										dobjAcGeCtrlPoint3d3 = new AcGeCtrlPoint3d();
										AcGeCtrlPoint3d acGeCtrlPoint3d = dobjAcGeCtrlPoint3d3;
										bool flag19 = false;
										acGeCtrlPoint3d.FriendLetWeight = ddblWeight;
										acGeCtrlPoint3d.FriendLetCoordX = ddblCoordX2;
										acGeCtrlPoint3d.FriendLetCoordY = ddblCoordY2;
										acGeCtrlPoint3d.FriendLetCoordZ = ddblCoordZ2;
										acGeCtrlPoint3d = null;
										bool flag20 = false;
										dobjDictControlPoints2.Add(dlngCount4, dobjAcGeCtrlPoint3d3);
										dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									}
									if (!dblnError && dlngNumberOfControlPoints != dobjDictControlPoints2.Count)
									{
										nrstrErrMsg = "Ungültige Anzahl der Kontrollpunkte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
								}
								if (!dblnError && dlngNumberOfFitPoints > 0)
								{
									dobjDictFitPoints2 = new Dictionary<object, object>();
									int dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									int dlngCount4 = 0;
									while (unchecked(dlngCode3 == 11 && !dblnError))
									{
										bool flag21 = false;
										double ddblCoordX2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										rlngIdx++;
										if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 21, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Angleichungspunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
											dblnError = true;
											continue;
										}
										if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 31, TextCompare: false))
										{
											nrstrErrMsg = "Ungültiger Gruppencode für Angleichungspunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
											dblnError = true;
											continue;
										}
										bool flag22 = false;
										double ddblCoordY2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
										double ddblCoordZ2 = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
										rlngIdx += 2;
										dlngCount4++;
										dobjAcGePoint3d3 = new AcGePoint3d();
										AcGePoint3d acGePoint3d = dobjAcGePoint3d3;
										bool flag23 = false;
										acGePoint3d.FriendLetCoordX = ddblCoordX2;
										acGePoint3d.FriendLetCoordY = ddblCoordY2;
										acGePoint3d.FriendLetCoordZ = ddblCoordZ2;
										acGePoint3d = null;
										bool flag24 = false;
										dobjDictFitPoints2.Add(dlngCount4, dobjAcGePoint3d3);
										dlngCode3 = Conversions.ToInteger(vobjDictReadCodes[rlngIdx]);
									}
									if (!dblnError && dlngNumberOfFitPoints != dobjDictFitPoints2.Count)
									{
										nrstrErrMsg = "Ungültige Anzahl der Angleichungspunkte vor Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
										dblnError = true;
									}
								}
								if (!dblnError)
								{
									object dvarXDataType = default(object);
									object dvarXDataValue = default(object);
									dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
									if (!dblnError)
									{
										object[] dvarPointsArray;
										if (dlngNumberOfFitPoints == 0)
										{
											dvarPointsArray = new object[1];
										}
										else
										{
											dvarPointsArray = new object[dobjDictFitPoints2.Count * 3 - 1 + 1];
											object dvarItems3 = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictFitPoints2.Values));
											int dlngCount4 = 0;
											int num = Information.LBound((Array)dvarItems3);
											int num2 = Information.UBound((Array)dvarItems3);
											for (int dlngIndex3 = num; dlngIndex3 <= num2; dlngIndex3++)
											{
												dobjAcGePoint3d3 = (AcGePoint3d)NewLateBinding.LateIndexGet(dvarItems3, new object[1]
												{
												dlngIndex3
												}, null);
												dvarPointsArray[dlngCount4] = RuntimeHelpers.GetObjectValue(dobjAcGePoint3d3.CoordX);
												dvarPointsArray[dlngCount4 + 1] = RuntimeHelpers.GetObjectValue(dobjAcGePoint3d3.CoordY);
												dvarPointsArray[dlngCount4 + 2] = RuntimeHelpers.GetObjectValue(dobjAcGePoint3d3.CoordZ);
												dlngCount4 += 3;
											}
										}
										dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
										if (!dblnError)
										{
											dobjAcadSpline2 = robjAcadBlock.FriendAddAcadObjectSpline(ddblObjectID, dvarPointsArray, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecStartTangent, dadblStartTangent)), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecEndTangent, dadblEndTangent)), ref nrstrErrMsg);
											if (dobjAcadSpline2 == null)
											{
												nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
												dblnError = true;
											}
											else
											{
												AcadSpline acadSpline = dobjAcadSpline2;
												acadSpline.FriendSetDictReactors = dobjDictReactors2;
												acadSpline.FriendSetDictXDictionary = dobjDictXDictionary2;
												acadSpline.Layer = dstrLayer;
												acadSpline.Linetype = dstrLineType;
												acadSpline.Color = unchecked((Enums.AcColor)dlngColor);
												acadSpline.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
												acadSpline.Visible = (dlngVisible == 0);
												acadSpline.FriendLetRGB = dlngRGB;
												acadSpline.Lineweight = dnumLineweight;
												acadSpline.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
												bool flag25 = false;
												acadSpline.Normal = Support.CopyArray(dadblNormal);
												acadSpline.FriendLetSplineFlags = dlngSplineFlags;
												acadSpline.FriendLetDegree = dlngDegree;
												acadSpline.FriendLetHasStartTangent = dblnHasStartTangent;
												acadSpline.FriendLetHasEndTangent = dblnHasEndTangent;
												bool flag26 = false;
												acadSpline.KnotTolerance = ddblKnotTolerance;
												acadSpline.ControlPointTolerance = ddblControlPointTolerance;
												acadSpline.FitTolerance = ddblFitTolerance;
												if (dobjDictKnots2 != null && dobjDictKnots2.Count > 0)
												{
													object dvarItems3 = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictKnots2.Values));
													int num3 = Information.LBound((Array)dvarItems3);
													int num4 = Information.UBound((Array)dvarItems3);
													for (int dlngIndex3 = num3; dlngIndex3 <= num4; dlngIndex3++)
													{
														acadSpline.FriendAddKnot(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems3, new object[1]
														{
														dlngIndex3
														}, null)));
													}
												}
												if (dobjDictControlPoints2 != null && dobjDictControlPoints2.Count > 0)
												{
													object dvarItems3 = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictControlPoints2.Values));
													int num5 = Information.LBound((Array)dvarItems3);
													int num6 = Information.UBound((Array)dvarItems3);
													for (int dlngIndex3 = num5; dlngIndex3 <= num6; dlngIndex3++)
													{
														dobjAcGeCtrlPoint3d3 = (AcGeCtrlPoint3d)NewLateBinding.LateIndexGet(dvarItems3, new object[1]
														{
														dlngIndex3
														}, null);
														acadSpline.FriendAddControlPoint(RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d3.CoordX), RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d3.CoordY), RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d3.CoordZ), RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d3.Weight));
													}
												}
												acadSpline.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
												acadSpline = null;
											}
										}
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadSpline = !dblnError;
				}
				dobjAcGePoint3d3 = null;
				dobjDictFitPoints2 = null;
				dobjAcGeCtrlPoint3d3 = null;
				dobjDictControlPoints2 = null;
				dobjDictKnots2 = null;
				dobjAcadSpline2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadSpline;
			}
		}

		public static bool BkDXFReadEnt_AcadUnknownEnt(int vlngSecEnd, string vstrDXFName, AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictCodes2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictValues2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadUnknownEnt = default(bool);
				AcadUnknownEnt dobjAcadUnknownEnt2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						string dstrObjectName = Conversions.ToString(vobjDictReadValues[rlngIdx]);
						rlngIdx++;
						int dlngIndex = 0;
						bool dblnStop = default(bool);
						while (unchecked(rlngIdx <= vlngSecEnd && !dblnStop))
						{
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 1001, TextCompare: false))
							{
								dblnStop = true;
								continue;
							}
							if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 0, TextCompare: false))
							{
								dblnStop = true;
								continue;
							}
							dobjDictCodes2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadCodes[rlngIdx]));
							dobjDictValues2.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vobjDictReadValues[rlngIdx]));
							dlngIndex++;
							rlngIdx++;
						}
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
							if (!dblnError)
							{
								dobjAcadUnknownEnt2 = robjAcadBlock.FriendAddAcadObjectUnknownEnt(ddblObjectID, dobjDictCodes2, dobjDictValues2, ref nrstrErrMsg);
								if (dobjAcadUnknownEnt2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadUnknownEnt acadUnknownEnt = dobjAcadUnknownEnt2;
									acadUnknownEnt.FriendLetDXFName = vstrDXFName;
									acadUnknownEnt.FriendLetObjectName = dstrObjectName;
									acadUnknownEnt.FriendSetDictReactors = dobjDictReactors2;
									acadUnknownEnt.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadUnknownEnt.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadUnknownEnt = null;
									hwpDxf_Functions.BkDXF_DebugPrint("Unbekanntes Entity: " + vstrDXFName + " " + dstrObjectName);
								}
							}
						}
					}
					BkDXFReadEnt_AcadUnknownEnt = !dblnError;
				}
				dobjAcadUnknownEnt2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				dobjDictValues2 = null;
				dobjDictCodes2 = null;
				return BkDXFReadEnt_AcadUnknownEnt;
			}
		}

		public static bool BkDXFReadEnt_AcadTrace(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCoordinates = new object[12];
			double[] dadblCoordinates = new double[12];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadTrace = default(bool);
				AcadTrace dobjAcadTrace2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbTrace", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 12, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 8], 22, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 9], 32, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 10], 13, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 11], 23, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 12], 33, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblCoordinates[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblCoordinates[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						double ddblElevation = dadblCoordinates[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						dadblCoordinates[3] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						dadblCoordinates[4] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						dadblCoordinates[5] = ddblElevation;
						dadblCoordinates[6] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 7]);
						dadblCoordinates[7] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 8]);
						dadblCoordinates[8] = ddblElevation;
						dadblCoordinates[9] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 10]);
						dadblCoordinates[10] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 11]);
						dadblCoordinates[11] = ddblElevation;
						rlngIdx += 13;
						double ddblThickness;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
						{
							bool flag2 = false;
							ddblThickness = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag3 = false;
							ddblThickness = hwpDxf_Vars.pdblThickness;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag4 = false;
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
								bool flag5 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag6 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
								if (!dblnError)
								{
									dobjAcadTrace2 = robjAcadBlock.FriendAddAcadObjectTrace(ref nrstrErrMsg, ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinates, dadblCoordinates)));
									if (dobjAcadTrace2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadTrace acadTrace = dobjAcadTrace2;
										acadTrace.FriendSetDictReactors = dobjDictReactors2;
										acadTrace.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadTrace.Layer = dstrLayer;
										acadTrace.Linetype = dstrLineType;
										acadTrace.Color = unchecked((Enums.AcColor)dlngColor);
										acadTrace.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
										acadTrace.Visible = (dlngVisible == 0);
										acadTrace.FriendLetRGB = dlngRGB;
										acadTrace.Lineweight = dnumLineweight;
										acadTrace.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
										bool flag7 = false;
										acadTrace.Elevation = ddblElevation;
										acadTrace.Thickness = ddblThickness;
										acadTrace.Normal = Support.CopyArray(dadblNormal);
										acadTrace.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadTrace = null;
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadTrace = !dblnError;
				}
				dobjAcadTrace2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadTrace;
			}
		}

		public static bool BkDXFReadEnt_AcadSolid(AcadDatabase vobjAcadDatabase, ref int rlngIdx, ref AcadBlock robjAcadBlock, Dictionary<object, object> vobjDictReadCodes, Dictionary<object, object> vobjDictReadValues, ref string nrstrErrMsg)
		{
			object[] dadecCoordinates = new object[12];
			double[] dadblCoordinates = new double[12];
			object[] dadecNormal = new object[3];
			double[] dadblNormal = new double[3];
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			string dstrAcadVer = vobjAcadDatabase.Document.AcadVer;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				double ddblLineOwnerID = default(double);
				int dlngPaperSpace = default(int);
				string dstrLayer = default(string);
				string dstrLineType = default(string);
				int dlngColor = default(int);
				object dvarLinetypeScale = default(object);
				int dlngVisible = default(int);
				int dlngRGB = default(int);
				Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
				string dstrPlotStyleNameReference = default(string);
				bool BkDXFReadEnt_AcadSolid = default(bool);
				AcadSolid dobjAcadSolid2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadObject(vobjAcadDatabase, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref ddblLineOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg) && hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(dstrAcadVer, vobjDictReadCodes, vobjDictReadValues, ref rlngIdx, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadValues[rlngIdx], "AcDbTrace", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 1], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 2], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 3], 30, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 1. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 4], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 5], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 6], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 2. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 7], 12, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 8], 22, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 9], 32, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 3. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 10], 13, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 11], 23, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(vobjDictReadCodes[rlngIdx + 12], 33, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für 4. Koordinate Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
						dblnError = true;
					}
					else
					{
						bool flag = false;
						dadblCoordinates[0] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
						dadblCoordinates[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 2]);
						double ddblElevation = dadblCoordinates[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 3]);
						dadblCoordinates[3] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 4]);
						dadblCoordinates[4] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 5]);
						dadblCoordinates[5] = ddblElevation;
						dadblCoordinates[6] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 7]);
						dadblCoordinates[7] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 8]);
						dadblCoordinates[8] = ddblElevation;
						dadblCoordinates[9] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 10]);
						dadblCoordinates[10] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 11]);
						dadblCoordinates[11] = ddblElevation;
						rlngIdx += 13;
						double ddblThickness;
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 39, TextCompare: false))
						{
							bool flag2 = false;
							ddblThickness = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
							rlngIdx++;
						}
						else
						{
							bool flag3 = false;
							ddblThickness = hwpDxf_Vars.pdblThickness;
						}
						if (Operators.ConditionalCompareObjectEqual(vobjDictReadCodes[rlngIdx], 210, TextCompare: false))
						{
							bool flag4 = false;
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
								bool flag5 = false;
								dadblNormal[1] = Conversions.ToDouble(vobjDictReadValues[rlngIdx]);
								dadblNormal[2] = Conversions.ToDouble(vobjDictReadValues[rlngIdx + 1]);
								rlngIdx += 2;
							}
						}
						else
						{
							bool flag6 = false;
							dadblNormal[0] = hwpDxf_Vars.padblNormal[0];
							dadblNormal[1] = hwpDxf_Vars.padblNormal[1];
							dadblNormal[2] = hwpDxf_Vars.padblNormal[2];
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, vobjDictReadCodes, vobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								dblnError = !BkDXFReadEnt_CheckBlockAsOwner(vobjAcadDatabase, ref robjAcadBlock, ddblOwnerID, ddblLineOwnerID, ref nrstrErrMsg);
								if (!dblnError)
								{
									dobjAcadSolid2 = robjAcadBlock.FriendAddAcadObjectSolid(ref nrstrErrMsg, ddblObjectID, RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinates, dadblCoordinates)));
									if (dobjAcadSolid2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadSolid acadSolid = dobjAcadSolid2;
										acadSolid.FriendSetDictReactors = dobjDictReactors2;
										acadSolid.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadSolid.Layer = dstrLayer;
										acadSolid.Linetype = dstrLineType;
										acadSolid.Color = unchecked((Enums.AcColor)dlngColor);
										acadSolid.LinetypeScale = RuntimeHelpers.GetObjectValue(dvarLinetypeScale);
										acadSolid.Visible = (dlngVisible == 0);
										acadSolid.FriendLetRGB = dlngRGB;
										acadSolid.Lineweight = dnumLineweight;
										acadSolid.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
										bool flag7 = false;
										acadSolid.Elevation = ddblElevation;
										acadSolid.Thickness = ddblThickness;
										acadSolid.Normal = Support.CopyArray(dadblNormal);
										acadSolid.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadSolid = null;
									}
								}
							}
						}
					}
					BkDXFReadEnt_AcadSolid = !dblnError;
				}
				dobjAcadSolid2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				return BkDXFReadEnt_AcadSolid;
			}
		}
	}
}
