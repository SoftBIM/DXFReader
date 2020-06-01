using DXFLib.Acad;
using Microsoft.VisualBasic;
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
	public class TableView
	{
		private const string cstrClassName = "TableView";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadViews mobjAcadViews;

		internal int TblBeg
		{
			get
			{
				return mlngTblBeg;
			}
			set
			{
				mlngTblBeg = value;
			}
		}

		internal int TblEnd
		{
			get
			{
				return mlngTblEnd;
			}
			set
			{
				mlngTblEnd = value;
			}
		}

		public string Name => "VIEW";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableView()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableView()
		{
			Class_Terminate_Renamed();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjAcadViews = null;
				mobjAcadDatabase = null;
				mblnOpened = false;
			}
		}

		public void Init(ref AcadDatabase robjAcadDatabase, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		{
			mobjAcadDatabase = robjAcadDatabase;
			mobjDictReadCodes = robjDictReadCodes;
			mobjDictReadValues = robjDictReadValues;
		}

		public bool Read(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			return InternReadTable(ref nrstrErrMsg);
		}

		public void ListTable(ref int rlngIdx)
		{
			mobjAcadViews = mobjAcadDatabase.Views;
			if (mobjAcadViews != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadViews acadViews = mobjAcadViews;
				InternAddToDictLine(ref rlngIdx, 2, acadViews.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadViews.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadViews.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadViews.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadViews.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadViews.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadViews.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadViews = null;
				InternListTable(ref rlngIdx);
				mlngTblEnd = rlngIdx;
				InternAddToDictLine(ref rlngIdx, 0, "ENDTAB");
			}
		}

		private bool InternReadTable(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx = checked(mlngTblBeg + 1);
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			int dlngCount = default(int);
			bool InternReadTable = default(bool);
			if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTable(mobjAcadDatabase, mobjDictReadCodes, mobjDictReadValues, ref dlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dlngCount, ref dobjDictXDictionary2, ref nrstrErrMsg))
			{
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				bool dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref dlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
				if (!dblnError)
				{
					mobjAcadViews = mobjAcadDatabase.FriendAddAcadObjectViews(ddblObjectID, ref nrstrErrMsg);
					if (mobjAcadViews == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadViews.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadViews.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
						bool dblnStop = default(bool);
						while (dlngIdx <= mlngTblEnd && !dblnError && !dblnStop)
						{
							int dlngCode = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
							object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
							if (dlngCode != 0 && dlngCode != 0)
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Tabelleneintrag/ende in Zeile " + Conversions.ToString(checked(dlngIdx * 2 + 1)) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectEqual(dvarValue, "ENDTAB", TextCompare: false))
							{
								dlngIdx = checked(dlngIdx + 1);
								dblnStop = true;
							}
							else if (!InternReadView(ddblObjectID, ref dlngIdx, ref mobjAcadViews, ref nrstrErrMsg))
							{
								dblnError = true;
							}
						}
					}
				}
				InternReadTable = !dblnError;
			}
			dobjDictXDictionary2 = null;
			return InternReadTable;
		}

		private bool InternReadView(double vdblDefOwnerID, ref int rlngIdx, ref AcadViews robjAcadViews, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadView = default(bool);
				AcadView dobjAcadView2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "VIEW", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError = default(bool);
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbViewTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Applikationsname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 40, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Höhe in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 10, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Mittelpunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 20, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Mittelpunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 41, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Breite in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 7], 11, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 8], 21, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 9], 31, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Richtung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 19) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 10], 12, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 21) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 11], 22, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 23) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 12], 32, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ziel Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 25) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 13], 42, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Brennweite in Zeile " + Conversions.ToString(rlngIdx * 2 + 27) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 14], 43, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Abstand vordere Schnittebene in Zeile " + Conversions.ToString(rlngIdx * 2 + 29) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 15], 44, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Abstand hintere Schnittebene  in Zeile " + Conversions.ToString(rlngIdx * 2 + 31) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 16], 50, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Drehwinkel in Zeile " + Conversions.ToString(rlngIdx * 2 + 33) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 17], 71, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Ansichtsmodus in Zeile " + Conversions.ToString(rlngIdx * 2 + 35) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 18], 281, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Rendermodus in Zeile " + Conversions.ToString(rlngIdx * 2 + 37) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 19], 72, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für BKS-Modus in Zeile " + Conversions.ToString(rlngIdx * 2 + 39) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						bool flag = false;
						double ddblHeight = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
						double ddblCenterX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
						double ddblCenterY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
						double ddblWidth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 6]);
						double ddblDirectionX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 7]);
						double ddblDirectionY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 8]);
						double ddblDirectionZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 9]);
						double ddblTargetX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 10]);
						double ddblTargetY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 11]);
						double ddblTargetZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 12]);
						double ddblLensLength = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 13]);
						double ddblFrontClipDistance = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 14]);
						double ddblBackClipDistance = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 15]);
						double ddblViewTwistDegree = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 16]);
						int dlngCode71 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 17]);
						int dlngRenderMode = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 18]);
						int dlngUcsAssociatedToView = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 19]);
						rlngIdx += 20;
						double ddblAssociatedUcsObjectID = default(double);
						int dlngUCSOrthographic = default(int);
						double ddblOrthographicUcsObjectID = default(double);
						if (dlngUcsAssociatedToView == 1)
						{
							if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 110, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Ursprung X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 120, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 130, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Ursprung Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 111, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für X-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 121, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 5], 131, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für X-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 11) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 6], 112, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 13) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 7], 122, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 15) + ".";
								dblnError = true;
							}
							else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 8], 132, TextCompare: false))
							{
								nrstrErrMsg = "Ungültiger Gruppencode für Y-Achse Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 17) + ".";
								dblnError = true;
							}
							else
							{
								bool flag2 = false;
								double ddblOriginX = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
								double ddblOriginY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 1]);
								double ddblOriginZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 2]);
								double ddblXVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 3]);
								double ddblXVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 4]);
								double ddblXVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 5]);
								double ddblYVectorX = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 6]);
								double ddblYVectorY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 7]);
								double ddblYVectorZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 8]);
								rlngIdx += 9;
								if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 345, TextCompare: false))
								{
									ddblAssociatedUcsObjectID = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
									rlngIdx++;
								}
								else
								{
									ddblAssociatedUcsObjectID = -1.0;
								}
								if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 79, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Typ der orthogonalen Ansicht in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 146, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Tiefe in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
									dblnError = true;
								}
								else
								{
									dlngUCSOrthographic = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
									bool flag3 = false;
									double ddblDepth = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 1]);
									rlngIdx += 2;
									if (dlngUCSOrthographic != 0)
									{
										if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 346, TextCompare: false))
										{
											ddblOrthographicUcsObjectID = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
											rlngIdx++;
										}
										else
										{
											ddblOrthographicUcsObjectID = -1.0;
										}
									}
									else
									{
										ddblOrthographicUcsObjectID = -1.0;
									}
								}
							}
						}
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								if (robjAcadViews.FriendNameExist(dstrName))
								{
									nrstrErrMsg = "Ansicht " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
									dblnError = true;
								}
								else
								{
									dobjAcadView2 = robjAcadViews.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
									if (dobjAcadView2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadView acadView = dobjAcadView2;
										acadView.FriendLetFlags70 = dlngCode70;
										bool flag4 = false;
										acadView.Height = ddblHeight;
										acadView.Center = new object[2]
										{
										ddblCenterX,
										ddblCenterY
										};
										acadView.Width = ddblWidth;
										acadView.Direction = new object[3]
										{
										ddblDirectionX,
										ddblDirectionY,
										ddblDirectionZ
										};
										acadView.Target = new object[3]
										{
										ddblTargetX,
										ddblTargetY,
										ddblTargetZ
										};
										acadView.FriendLetLensLength = ddblLensLength;
										acadView.FriendLetFrontClipDistance = ddblFrontClipDistance;
										acadView.FriendLetBackClipDistance = ddblBackClipDistance;
										acadView.FriendLetViewTwistDegree = ddblViewTwistDegree;
										acadView.FriendLetFlags71 = dlngCode71;
										acadView.FriendLetRenderMode = unchecked((hwpDxf_Enums.RENDER_MODE)dlngRenderMode);
										acadView.FriendLetAssociatedUcsObjectID = ddblAssociatedUcsObjectID;
										if (acadView.UcsAssociatedToView && dlngUCSOrthographic != 0)
										{
											acadView.FriendLetOrthographicUcsObjectID = ddblOrthographicUcsObjectID;
										}
										acadView.FriendSetDictReactors = dobjDictReactors2;
										acadView.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadView.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadView = null;
									}
								}
							}
						}
					}
					InternReadView = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadView2 = null;
				return InternReadView;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadUCS dobjAcadUCS2;
			AcadView dobjAcadView2;
			try
			{
				enumerator = mobjAcadViews.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadView2 = (AcadView)enumerator.Current;
					AcadView acadView = dobjAcadView2;
					InternAddToDictLine(ref rlngIdx, 0, acadView.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadView.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadView.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadView.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadView.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadView.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadView.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadView.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadView.Flags70);
					InternAddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadView.Height));
					object dvarPoint6 = RuntimeHelpers.GetObjectValue(acadView.Center);
					InternAddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadView.Width));
					dvarPoint6 = RuntimeHelpers.GetObjectValue(acadView.Direction);
					InternAddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					2
					}, null)));
					dvarPoint6 = RuntimeHelpers.GetObjectValue(acadView.Target);
					InternAddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					0
					}, null)));
					InternAddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					1
					}, null)));
					InternAddToDictLine(ref rlngIdx, 32, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
					{
					2
					}, null)));
					InternAddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadView.LensLength));
					InternAddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadView.FrontClipDistance));
					InternAddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadView.BackClipDistance));
					InternAddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadView.ViewTwistDegree));
					InternAddToDictLine(ref rlngIdx, 71, acadView.Flags71);
					InternAddToDictLine(ref rlngIdx, 281, acadView.RenderMode);
					InternAddToDictLine(ref rlngIdx, 72, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadView.UcsAssociatedToView, 1, 0)));
					acadView = null;
					if (dobjAcadView2.UcsAssociatedToView)
					{
						dobjAcadUCS2 = dobjAcadView2.AssociatedUcs;
						AcadUCS acadUCS = dobjAcadUCS2;
						dvarPoint6 = RuntimeHelpers.GetObjectValue(acadUCS.Origin);
						InternAddToDictLine(ref rlngIdx, 110, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						0
						}, null)));
						InternAddToDictLine(ref rlngIdx, 120, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						1
						}, null)));
						InternAddToDictLine(ref rlngIdx, 130, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						2
						}, null)));
						dvarPoint6 = RuntimeHelpers.GetObjectValue(acadUCS.XVector);
						InternAddToDictLine(ref rlngIdx, 111, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						0
						}, null)));
						InternAddToDictLine(ref rlngIdx, 121, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						1
						}, null)));
						InternAddToDictLine(ref rlngIdx, 131, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						2
						}, null)));
						dvarPoint6 = RuntimeHelpers.GetObjectValue(acadUCS.YVector);
						InternAddToDictLine(ref rlngIdx, 112, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						0
						}, null)));
						InternAddToDictLine(ref rlngIdx, 122, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						1
						}, null)));
						InternAddToDictLine(ref rlngIdx, 132, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint6, new object[1]
						{
						2
						}, null)));
						InternAddToDictLine(ref rlngIdx, 345, dobjAcadView2.AssociatedUcsObjectID);
						InternAddToDictLine(ref rlngIdx, 79, acadUCS.UCSOrthographic);
						InternAddToDictLine(ref rlngIdx, 146, RuntimeHelpers.GetObjectValue(acadUCS.Depth));
						acadUCS = null;
						AcadView acadView2 = dobjAcadView2;
						if (acadView2.HasOrthographicUcs)
						{
							InternAddToDictLine(ref rlngIdx, 346, acadView2.OrthographicUcsObjectID);
						}
						acadView2 = null;
					}
					AcadView acadView3 = dobjAcadView2;
					acadView3.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadView3 = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadUCS2 = null;
			dobjAcadView2 = null;
		}
	}
}
