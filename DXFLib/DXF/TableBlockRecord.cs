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
	public class TableBlockRecord
	{
		private const string cstrClassName = "TableBlockRecord";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadBlocks mobjAcadBlocks;

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

		public string Name => "BLOCK_RECORD";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableBlockRecord()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableBlockRecord()
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
				mobjAcadBlocks = null;
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
			mobjAcadBlocks = mobjAcadDatabase.Blocks;
			if (mobjAcadBlocks != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadBlocks acadBlocks = mobjAcadBlocks;
				InternAddToDictLine(ref rlngIdx, 2, acadBlocks.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadBlocks.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadBlocks.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadBlocks.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadBlocks.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadBlocks.Count);
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				acadBlocks.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
				hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				acadBlocks = null;
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
					mobjAcadBlocks = mobjAcadDatabase.FriendAddAcadObjectBlocks(ref nrstrErrMsg, ddblObjectID);
					if (mobjAcadBlocks == null)
					{
						nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
						dblnError = true;
					}
					else
					{
						mobjAcadBlocks.FriendSetDictXDictionary = dobjDictXDictionary2;
						mobjAcadBlocks.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
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
							else if (!InternReadBlockRecord(ddblObjectID, ref dlngIdx, ref mobjAcadBlocks, ref nrstrErrMsg))
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

		private bool InternReadBlockRecord(double vdblDefOwnerID, ref int rlngIdx, ref AcadBlocks robjAcadBlocks, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictPreviewIcon2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictBlkrefs2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadBlockRecord = default(bool);
				AcadBlock dobjAcadBlock2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "BLOCK_RECORD", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbBlockTableRecord", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 2, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Blockname in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 340, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Zeiger auf Layout-Objekt in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
						dblnError = true;
					}
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						double ddblLayoutObjectID = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						hwpDxf_ReadBas.BkDXFReadBas_PreviewIcon(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dobjDictPreviewIcon2);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_Blkrefs(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dobjDictBlkrefs2, ref nrstrErrMsg);
						if (!dblnError)
						{
							object dvarXDataType = default(object);
							object dvarXDataValue = default(object);
							dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
							if (!dblnError)
							{
								if (robjAcadBlocks.FriendNameExist(dstrName))
								{
									nrstrErrMsg = "Blockdefinition " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
									dblnError = true;
								}
								else
								{
									dobjAcadBlock2 = robjAcadBlocks.FriendAddAcadObject(ref nrstrErrMsg, dstrName, ddblObjectID);
									if (dobjAcadBlock2 == null)
									{
										nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
										dblnError = true;
									}
									else
									{
										AcadBlock acadBlock = dobjAcadBlock2;
										acadBlock.FriendLetLayoutObjectID = ddblLayoutObjectID;
										acadBlock.FriendSetDictReactors = dobjDictReactors2;
										acadBlock.FriendSetDictXDictionary = dobjDictXDictionary2;
										acadBlock.FriendSetDictPreviewIcon = dobjDictPreviewIcon2;
										acadBlock.FriendSetDictBlkrefs = dobjDictBlkrefs2;
										acadBlock.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
										acadBlock = null;
									}
								}
							}
						}
					}
					InternReadBlockRecord = !dblnError;
				}
				dobjDictBlkrefs2 = null;
				dobjDictPreviewIcon2 = null;
				dobjDictXDictionary2 = null;
				dobjDictReactors2 = null;
				dobjAcadBlock2 = null;
				return InternReadBlockRecord;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			AcadBlock dobjAcadBlock4 = (AcadBlock)mobjAcadBlocks.FriendGetItem("*Model_Space");
			if (dobjAcadBlock4 != null)
			{
				InternListBlock(ref rlngIdx, dobjAcadBlock4);
			}
			dobjAcadBlock4 = (AcadBlock)mobjAcadBlocks.FriendGetItem("*Paper_Space");
			int dlngCount = 0;
			while (dobjAcadBlock4 != null)
			{
				InternListBlock(ref rlngIdx, dobjAcadBlock4);
				dobjAcadBlock4 = (AcadBlock)mobjAcadBlocks.FriendGetItem("*Paper_Space" + Conversions.ToString(dlngCount));
				dlngCount = checked(dlngCount + 1);
			}
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = mobjAcadBlocks.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadBlock4 = (AcadBlock)enumerator.Current;
					string dstrName = dobjAcadBlock4.Name;
					if (!LikeOperator.LikeString(dstrName, "[*]Model_Space", CompareMethod.Binary) & !LikeOperator.LikeString(dstrName, "[*]Paper_Space*", CompareMethod.Binary))
					{
						InternListBlock(ref rlngIdx, dobjAcadBlock4);
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadBlock4 = null;
		}

		private void InternListBlock(ref int rlngIdx, AcadBlock vobjAcadBlock)
		{
			AcadBlock acadBlock = vobjAcadBlock;
			InternAddToDictLine(ref rlngIdx, 0, acadBlock.DXFName);
			InternAddToDictLine(ref rlngIdx, 5, acadBlock.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadBlock.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadBlock.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadBlock.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, acadBlock.SuperiorObjectName);
			InternAddToDictLine(ref rlngIdx, 100, acadBlock.ObjectName);
			InternAddToDictLine(ref rlngIdx, 2, acadBlock.Name);
			InternAddToDictLine(ref rlngIdx, 340, acadBlock.LayoutObjectID);
			hwpDxf_List.BkDXFList_PreviewIcon((Dictionary<object, object>)acadBlock.FriendGetDictPreviewIcon, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			hwpDxf_List.BkDXFList_Blkrefs((Dictionary<object, object>)acadBlock.FriendGetDictBlkrefs, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			object dvarXDataType = default(object);
			object dvarXDataValue = default(object);
			acadBlock.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
			hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			acadBlock = null;
		}
	}
}
