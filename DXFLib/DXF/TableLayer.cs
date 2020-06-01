using DXFLib.Acad;
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
	public class TableLayer
	{
		private const string cstrClassName = "TableLayer";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadLayers mobjAcadLayers;

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

		public string Name => "LAYER";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableLayer()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableLayer()
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
				mobjAcadLayers = null;
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
			mobjAcadLayers = mobjAcadDatabase.Layers;
			if (mobjAcadLayers != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadLayers acadLayers = mobjAcadLayers;
				InternAddToDictLine(ref rlngIdx, 2, acadLayers.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadLayers.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadLayers.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadLayers.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadLayers.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadLayers.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadLayers.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadLayers = null;
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
					mobjAcadLayers = mobjAcadDatabase.FriendAddAcadObjectLayers(ddblObjectID, ref nrstrErrMsg);
					if (mobjAcadLayers == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadLayers.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadLayers.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadLayer(ddblObjectID, ref dlngIdx, ref mobjAcadLayers, ref nrstrErrMsg))
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

		private bool InternReadLayer(double vdblDefOwnerID, ref int rlngIdx, ref AcadLayers robjAcadLayers, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadLayer = default(bool);
				AcadLayer dobjAcadLayer2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "LAYER", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbLayerTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Layername in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 62, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Farbnummer in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 6, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Linientypname in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode3 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						int dlngCode2 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 3]);
						string dstrLineType = Conversions.ToString(mobjDictReadValues[rlngIdx + 4]);
						rlngIdx += 5;
						int dlngCode = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
						bool dblnCode290 = dlngCode == 290;
						if (dblnCode290)
						{
							rlngIdx++;
						}
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 370, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Linienstärke in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], "390", TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Plotstilreferenz in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else
						{
							bool dblnPlottable = !dblnCode290 || Operators.ConditionalCompareObjectEqual(mobjDictReadValues[rlngIdx - 1], 1, TextCompare: false);
							Enums.AcLineWeight dnumLineweight = unchecked((Enums.AcLineWeight)Conversions.ToInteger(mobjDictReadValues[rlngIdx]));
							string dstrPlotStyleNameReference = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
							rlngIdx += 2;
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								if (robjAcadLayers.FriendNameExist(dstrName))
								{
									nrstrErrMsg = "Layer " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
									dblnError = true;
								}
								else
								{
									dobjAcadLayer2 = robjAcadLayers.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
									if (dobjAcadLayer2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadLayer acadLayer = dobjAcadLayer2;
										acadLayer.FriendLetFlags70 = dlngCode3;
										acadLayer.Color = unchecked((Enums.AcColor)Math.Abs(dlngCode2));
										acadLayer.LayerOn = ((double)acadLayer.Color == (double)dlngCode2);
										acadLayer.Linetype = dstrLineType;
										acadLayer.Plottable = dblnPlottable;
										acadLayer.Lineweight = dnumLineweight;
										acadLayer.FriendLetPlotStyleNameReference = dstrPlotStyleNameReference;
										acadLayer.FriendSetDictReactors = dobjDictReactors2;
										acadLayer.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadLayer.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadLayer = null;
									}
								}
							}
						}
					}
					InternReadLayer = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadLayer2 = null;
				return InternReadLayer;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadLayer dobjAcadLayer2;
			try
			{
				enumerator = mobjAcadLayers.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadLayer2 = (AcadLayer)enumerator.Current;
					AcadLayer acadLayer = dobjAcadLayer2;
					InternAddToDictLine(ref rlngIdx, 0, acadLayer.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadLayer.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadLayer.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadLayer.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadLayer.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadLayer.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadLayer.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadLayer.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadLayer.Flags70);
					int dlngColor = (int)acadLayer.Color;
					if (!acadLayer.LayerOn)
					{
						dlngColor = checked(dlngColor * -1);
					}
					InternAddToDictLine(ref rlngIdx, 62, dlngColor);
					InternAddToDictLine(ref rlngIdx, 6, acadLayer.Linetype);
					if (!acadLayer.Plottable)
					{
						InternAddToDictLine(ref rlngIdx, 290, hwpDxf_Functions.BkDXF_BooleanToInteger(acadLayer.Plottable));
					}
					InternAddToDictLine(ref rlngIdx, 370, acadLayer.Lineweight);
					InternAddToDictLine(ref rlngIdx, Conversions.ToInteger("390"), acadLayer.PlotStyleNameReference);
					acadLayer.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadLayer = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadLayer2 = null;
		}
	}
}
