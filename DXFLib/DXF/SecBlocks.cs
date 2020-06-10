using DXFLib.Acad;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class SecBlocks
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecBlocks";

		private bool mblnOpened;

		private string mstrAcadVer;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadBlocks mobjAcadBlocks;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ReadAddEntryEventHandler ReadAddEntryEvent;

		internal int SecBeg
		{
			get
			{
				return mlngSecBeg;
			}
			set
			{
				mlngSecBeg = value;
			}
		}

		internal int SecEnd
		{
			get
			{
				return mlngSecEnd;
			}
			set
			{
				mlngSecEnd = value;
			}
		}

		public string Name => "ENTITIES";

		public int StartLine => checked((mlngSecBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngSecEnd + 1) * 2 + 2);

		public event ReadAddEntryEventHandler ReadAddEntry
		{
			[CompilerGenerated]
			add
			{
				ReadAddEntryEventHandler readAddEntryEventHandler = ReadAddEntryEvent;
				ReadAddEntryEventHandler readAddEntryEventHandler2;
				do
				{
					readAddEntryEventHandler2 = readAddEntryEventHandler;
					ReadAddEntryEventHandler value2 = (ReadAddEntryEventHandler)Delegate.Combine(readAddEntryEventHandler2, value);
					readAddEntryEventHandler = Interlocked.CompareExchange(ref ReadAddEntryEvent, value2, readAddEntryEventHandler2);
				}
				while ((object)readAddEntryEventHandler != readAddEntryEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ReadAddEntryEventHandler readAddEntryEventHandler = ReadAddEntryEvent;
				ReadAddEntryEventHandler readAddEntryEventHandler2;
				do
				{
					readAddEntryEventHandler2 = readAddEntryEventHandler;
					ReadAddEntryEventHandler value2 = (ReadAddEntryEventHandler)Delegate.Remove(readAddEntryEventHandler2, value);
					readAddEntryEventHandler = Interlocked.CompareExchange(ref ReadAddEntryEvent, value2, readAddEntryEventHandler2);
				}
				while ((object)readAddEntryEventHandler != readAddEntryEventHandler2);
			}
		}

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public SecBlocks()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecBlocks()
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
			mstrAcadVer = robjAcadDatabase.Document.AcadVer;
			mobjAcadDatabase = robjAcadDatabase;
			mobjDictReadCodes = robjDictReadCodes;
			mobjDictReadValues = robjDictReadValues;
		}

		public bool Read(ref string nrstrErrMsg)
		{
			mobjAcadBlocks = mobjAcadDatabase.Blocks;
			nrstrErrMsg = null;
			checked
			{
				mlngLastEntry = mlngSecBeg - 1;
				bool Read = InternReadSection(ref nrstrErrMsg);
				InternCheckIndex(mlngSecEnd + 2);
				return Read;
			}
		}

		public void ListSection(ref int rlngIdx)
		{
			mobjAcadBlocks = mobjAcadDatabase.Blocks;
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "BLOCKS");
			if (mobjAcadBlocks != null)
			{
				InternListSection(ref rlngIdx);
			}
			mlngSecEnd = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 0, "ENDSEC");
		}

		private void InternIncreaseIndex(ref int rlngIdx, int vlngAdd)
		{
			checked
			{
				rlngIdx += vlngAdd;
				InternCheckIndex(rlngIdx);
			}
		}

		private void InternCheckIndex(int vlngIdx)
		{
			int dlngAdd = checked(vlngIdx - mlngLastEntry);
			mlngLastEntry = vlngIdx;
			if (dlngAdd > 0)
			{
				ReadAddEntryEvent?.Invoke(dlngAdd);
			}
		}

		private bool InternReadSection(ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			bool dblnError = default(bool);
			while (dlngIdx <= mlngSecEnd && !dblnError)
			{
				int dlngCode = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
				object dvarValue = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
				checked
				{
					if (dlngCode != 0)
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Blockabschnittsbeginn in Zeile " + Conversions.ToString(dlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(dvarValue, "BLOCK", TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Name für Blockabschnittsbegin in Zeile " + Conversions.ToString(dlngIdx * 2 + 2) + ".";
						dblnError = true;
					}
					else
					{
						InternIncreaseIndex(ref dlngIdx, 1);
						dblnError = !InternReadOneBlock(ref dlngIdx, ref nrstrErrMsg);
					}
				}
			}
			return !dblnError;
		}

		private bool InternReadOneBlock(ref int rlngIdx, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors = new Dictionary<object, object>();
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			double ddblObjectID = default(double);
			double ddblOwnerID = default(double);
			int dlngPaperSpace = default(int);
			string dstrLayer = default(string);
			string dstrLineType = default(string);
			int dlngColor = default(int);
			object dvarLinetypeScale = default(object);
			int dlngVisible = default(int);
			int dlngRGB = default(int);
			Enums.AcLineWeight dnumLineweight = default(Enums.AcLineWeight);
			string dstrPlotStyleNameReference = default(string);
			AcadBlock dobjAcadBlock = default(AcadBlock);
			while (rlngIdx <= mlngSecEnd && !dblnError && !dblnStop)
			{
				if (!InternReadBlockBeginOrEnd("AcDbBlockBegin", ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref dobjDictReactors, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else if (!InternReadBlockData(ref rlngIdx, ref dobjAcadBlock, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else if (!InternAddAcadObjectBlockBegin(ref dobjAcadBlock, ddblObjectID, ddblOwnerID, dlngPaperSpace, dstrLayer, dstrLineType, dlngColor, RuntimeHelpers.GetObjectValue(dvarLinetypeScale), dlngVisible, dlngRGB, dnumLineweight, dstrPlotStyleNameReference, dobjDictReactors, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else if (!InternReadBlockEntities(ref rlngIdx, ref dobjAcadBlock, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else if (!InternReadBlockBeginOrEnd("AcDbBlockEnd", ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dlngPaperSpace, ref dstrLayer, ref dstrLineType, ref dlngColor, ref dvarLinetypeScale, ref dlngVisible, ref dlngRGB, ref dnumLineweight, ref dstrPlotStyleNameReference, ref dobjDictReactors, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else if (!InternAddAcadObjectBlockEnd(ref dobjAcadBlock, ddblObjectID, ddblOwnerID, dlngPaperSpace, dstrLayer, dstrLineType, dlngColor, RuntimeHelpers.GetObjectValue(dvarLinetypeScale), dlngVisible, dlngRGB, dnumLineweight, dstrPlotStyleNameReference, dobjDictReactors, ref nrstrErrMsg))
				{
					dblnError = true;
				}
				else
				{
					dblnStop = true;
				}
			}
			bool InternReadOneBlock = !dblnError;
			dobjAcadBlock = null;
			return InternReadOneBlock;
		}

		private bool InternAddAcadObjectBlockBegin(ref AcadBlock robjAcadBlock, double vdblObjectID, double vdblOwnerID, int vlngPaperSpace, string vstrLayer, string vstrLinetype, int vlngColor, object vvarLinetypeScale, int vlngVisible, int vlngRGB, Enums.AcLineWeight vnumLineweight, string vstrPlotStyleNameReference, Dictionary<object, object> vobjDictReactors, ref string nrstrErrMsg)
		{
			AcadBlockBegin dobjAcadBlockBegin2 = robjAcadBlock.FriendAddAcadObjectBlockBegin(ref nrstrErrMsg, vdblObjectID, nvblnWithoutObjectID: false);
			bool InternAddAcadObjectBlockBegin = default(bool);
			if (dobjAcadBlockBegin2 == null)
			{
				nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
			}
			else
			{
				AcadBlockBegin acadBlockBegin = dobjAcadBlockBegin2;
				acadBlockBegin.FriendLetIsPaperSpace = (vlngPaperSpace == 1);
				acadBlockBegin.Layer = vstrLayer;
				acadBlockBegin.Linetype = vstrLinetype;
				acadBlockBegin.Color = (Enums.AcColor)vlngColor;
				acadBlockBegin.LinetypeScale = RuntimeHelpers.GetObjectValue(vvarLinetypeScale);
				acadBlockBegin.Visible = (vlngVisible == 0);
				acadBlockBegin.FriendLetRGB = vlngRGB;
				acadBlockBegin.Lineweight = vnumLineweight;
				acadBlockBegin.FriendLetPlotStyleNameReference = vstrPlotStyleNameReference;
				acadBlockBegin.FriendSetDictReactors = vobjDictReactors;
				acadBlockBegin = null;
				InternAddAcadObjectBlockBegin = true;
			}
			dobjAcadBlockBegin2 = null;
			return InternAddAcadObjectBlockBegin;
		}

		private bool InternAddAcadObjectBlockEnd(ref AcadBlock robjAcadBlock, double vdblObjectID, double vdblOwnerID, int vlngPaperSpace, string vstrLayer, string vstrLinetype, int vlngColor, object vvarLinetypeScale, int vlngVisible, int vlngRGB, Enums.AcLineWeight vnumLineweight, string vstrPlotStyleNameReference, Dictionary<object, object> vobjDictReactors, ref string nrstrErrMsg)
		{
			AcadBlockEnd dobjAcadBlockEnd2 = robjAcadBlock.FriendAddAcadObjectBlockEnd(ref nrstrErrMsg, vdblObjectID, nvblnWithoutObjectID: false);
			bool InternAddAcadObjectBlockEnd = default(bool);
			if (dobjAcadBlockEnd2 == null)
			{
				nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
			}
			else
			{
				AcadBlockEnd acadBlockEnd = dobjAcadBlockEnd2;
				acadBlockEnd.FriendLetIsPaperSpace = (vlngPaperSpace == 1);
				acadBlockEnd.Layer = vstrLayer;
				acadBlockEnd.Linetype = vstrLinetype;
				acadBlockEnd.Color = (Enums.AcColor)vlngColor;
				acadBlockEnd.LinetypeScale = RuntimeHelpers.GetObjectValue(vvarLinetypeScale);
				acadBlockEnd.Visible = (vlngVisible == 0);
				acadBlockEnd.FriendLetRGB = vlngRGB;
				acadBlockEnd.Lineweight = vnumLineweight;
				acadBlockEnd.FriendLetPlotStyleNameReference = vstrPlotStyleNameReference;
				acadBlockEnd.FriendSetDictReactors = vobjDictReactors;
				acadBlockEnd = null;
				InternAddAcadObjectBlockEnd = true;
			}
			dobjAcadBlockEnd2 = null;
			return InternAddAcadObjectBlockEnd;
		}

		private bool InternReadBlockData(ref int rlngIdx, ref AcadBlock robjAcadBlock, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjAcadBlock = null;
			checked
			{
				bool dblnError = default(bool);
				if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 2, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Blockname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx]);
					InternIncreaseIndex(ref rlngIdx, 1);
					robjAcadBlock = (AcadBlock)mobjAcadBlocks.FriendGetItem(dstrName);
					if (robjAcadBlock == null)
					{
						nrstrErrMsg = "Ungültiger Blockname in Zeile " + Conversions.ToString(rlngIdx * 2) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 70, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Standard-Flag-Werte in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else
					{
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
						InternIncreaseIndex(ref rlngIdx, 1);
						if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 71, TextCompare: false))
						{
							int dlngCode71 = Conversions.ToInteger(mobjDictReadValues[rlngIdx]);
							InternIncreaseIndex(ref rlngIdx, 1);
						}
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 10, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt X-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 1], 20, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Y-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 3) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 2], 30, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Basispunkt Z-Wert in Zeile " + Conversions.ToString(rlngIdx * 2 + 5) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 3], 3, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Blockname in Zeile " + Conversions.ToString(rlngIdx * 2 + 7) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx + 3], dstrName, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Blockname in Zeile " + Conversions.ToString(rlngIdx * 2 + 8) + ".";
							dblnError = true;
						}
						else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx + 4], 1, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für XRef-Pfadname in Zeile " + Conversions.ToString(rlngIdx * 2 + 9) + ".";
							dblnError = true;
						}
						else
						{
							bool flag = false;
							double ddblOriginX = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
							double ddblOriginY = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 1]);
							double ddblOriginZ = Conversions.ToDouble(mobjDictReadValues[rlngIdx + 2]);
							string dstrPathName = Conversions.ToString(mobjDictReadValues[rlngIdx + 4]);
							InternIncreaseIndex(ref rlngIdx, 5);
							string dstrComment;
							if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 4, TextCompare: false))
							{
								dstrComment = Conversions.ToString(mobjDictReadValues[rlngIdx]);
								InternIncreaseIndex(ref rlngIdx, 1);
							}
							else
							{
								dstrComment = null;
							}
							AcadBlock acadBlock = robjAcadBlock;
							bool flag2 = false;
							acadBlock.Origin = new object[3]
							{
							ddblOriginX,
							ddblOriginY,
							ddblOriginZ
							};
							acadBlock.Comment = dstrComment;
							acadBlock.FriendLetPathName = dstrPathName;
							acadBlock.FriendLetFlags70 = dlngCode70;
							acadBlock = null;
						}
					}
				}
				return !dblnError;
			}
		}

		private bool InternReadBlockEntities(ref int rlngIdx, ref AcadBlock robjAcadBlock, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			bool dblnError = default(bool);
			bool dblnStop = default(bool);
			AcadPolyfaceMesh dobjAcadPolyfaceMesh = default(AcadPolyfaceMesh);
			AcadPolygonMesh dobjAcadPolygonMesh = default(AcadPolygonMesh);
			Acad3DPolyline dobjAcad3DPolyline = default(Acad3DPolyline);
			AcadPolyline dobjAcadPolyline = default(AcadPolyline);
			while (rlngIdx <= mlngSecEnd && !dblnError && !dblnStop)
			{
				int dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
				object dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]);
				if (dlngCode2 == 0 && Operators.ConditionalCompareObjectEqual(dvarValue2, "ENDBLK", TextCompare: false))
				{
					dblnStop = true;
				}
				InternIncreaseIndex(ref rlngIdx, 1);
				if (dblnStop)
				{
					continue;
				}
				object left = dvarValue2;
				if (Operators.ConditionalCompareObjectEqual(left, "ARC", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadArc(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "CIRCLE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadCircle(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "LINE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadLine(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "POINT", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadPoint(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "XLINE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadXline(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "RAY", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadRay(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "LWPOLYLINE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadLWPolyline(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "POLYLINE", TextCompare: false))
				{
					int dlngAcadPolylineIdx = rlngIdx;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadPolyline(ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
					if (dblnError)
					{
						continue;
					}
					bool dblnAcadPolyline = true;
					while (rlngIdx <= mlngSecEnd && !dblnError && dblnAcadPolyline)
					{
						dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[rlngIdx]);
						dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[rlngIdx]);
						if (dlngCode2 != 0)
						{
							nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(checked(rlngIdx * 2 + 1)) + ".";
							dblnError = true;
							continue;
						}
						InternIncreaseIndex(ref rlngIdx, 1);
						object left2 = dvarValue2;
						if (Operators.ConditionalCompareObjectEqual(left2, "VERTEX", TextCompare: false))
						{
							dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadVertex(mobjAcadDatabase, ref rlngIdx, ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
							InternCheckIndex(rlngIdx);
						}
						else if (Operators.ConditionalCompareObjectEqual(left2, "SEQEND", TextCompare: false))
						{
							AcadDatabase vobjAcadDatabase = mobjAcadDatabase;
							AcadBlockReference robjAcadBlockReference = null;
							AcadMInsertBlock robjAcadMInsertBlock = null;
							dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSequenceEnd(vobjAcadDatabase, ref rlngIdx, ref robjAcadBlockReference, ref robjAcadMInsertBlock, ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
							InternCheckIndex(rlngIdx);
							dblnAcadPolyline = false;
							dobjAcadPolyline?.FriendCalcSize();
							dobjAcad3DPolyline?.FriendCalcSize();
							dobjAcadPolyline = null;
							dobjAcad3DPolyline = null;
							dobjAcadPolygonMesh = null;
							dobjAcadPolyfaceMesh = null;
						}
						else
						{
							nrstrErrMsg = "Polylinie ohne Sequenzende ab Zeile " + Conversions.ToString(dlngAcadPolylineIdx) + ".";
							dblnError = true;
						}
					}
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "MTEXT", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadMText(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "TEXT", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadText(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ATTDEF", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadAttributeDefinition(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "INSERT", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadBlockReference(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SHAPE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadShape(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ELLIPSE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadEllipse(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "HATCH", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadHatch(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SPLINE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSpline(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "TRACE", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadTrace(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SOLID", TextCompare: false))
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSolid(mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
				else
				{
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadUnknownEnt(mlngSecEnd, Conversions.ToString(dvarValue2), mobjAcadDatabase, ref rlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
				}
			}
			bool InternReadBlockEntities = !dblnError;
			dobjAcadPolyfaceMesh = null;
			dobjAcadPolygonMesh = null;
			dobjAcad3DPolyline = null;
			dobjAcadPolyline = null;
			return InternReadBlockEntities;
		}

		private bool InternReadBlockBeginOrEnd(string vstrObjectName, ref int rlngIdx, ref double rdblObjectID, ref double rdblOwnerID, ref int rlngPaperSpace, ref string rstrLayer, ref string rstrLinetype, ref int rlngColor, ref object rvarLinetypeScale, ref int rlngVisible, ref int rlngRGB, ref Enums.AcLineWeight rnumLineweight, ref string rstrPlotStyleNameReference, ref Dictionary<object, object> robjDictReactors, ref string nrstrErrMsg)
		{
			nrstrErrMsg = null;
			robjDictReactors.Clear();
			checked
			{
				bool dblnError;
				if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 5, TextCompare: false))
				{
					nrstrErrMsg = "Ungültiger Gruppencode für Referenz in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
					dblnError = true;
				}
				else
				{
					rdblObjectID = hwpDxf_Functions.BkDXF_HexToDbl(Conversions.ToString(mobjDictReadValues[rlngIdx]));
					InternIncreaseIndex(ref rlngIdx, 1);
					dblnError = !hwpDxf_ReadBas.BkDXFReadBas_Reactors(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref robjDictReactors, ref nrstrErrMsg);
					InternCheckIndex(rlngIdx);
					if (!dblnError)
					{
						if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 330, TextCompare: false))
						{
							nrstrErrMsg = "Ungültiger Gruppencode für Objekt-ID (Eigentümer) in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
							dblnError = true;
						}
						else
						{
							rdblOwnerID = Conversions.ToDouble(mobjDictReadValues[rlngIdx]);
							InternIncreaseIndex(ref rlngIdx, 1);
							if (hwpDxf_ReadRef.BkDXFReadRef_AcadEntity(mstrAcadVer, mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref rlngPaperSpace, ref rstrLayer, ref rstrLinetype, ref rlngColor, ref rvarLinetypeScale, ref rlngVisible, ref rlngRGB, ref rnumLineweight, ref rstrPlotStyleNameReference, ref nrstrErrMsg))
							{
								if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
									dblnError = true;
								}
								else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], vstrObjectName, TextCompare: false))
								{
									nrstrErrMsg = "Ungültiger Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 2) + ".";
									dblnError = true;
								}
								else
								{
									InternIncreaseIndex(ref rlngIdx, 1);
								}
							}
						}
					}
				}
				return !dblnError;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			AcadBlock dobjAcadBlock4 = (AcadBlock)mobjAcadBlocks.Item("*Model_Space");
			InternListBlockBegin(dobjAcadBlock4.BlockBegin, ref rlngIdx);
			InternListBlockData(dobjAcadBlock4, ref rlngIdx);
			InternListBlockEnd(dobjAcadBlock4.BlockEnd, ref rlngIdx);
			IEnumerator enumerator = default(IEnumerator);
			try
			{
				enumerator = mobjAcadBlocks.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadBlock4 = (AcadBlock)enumerator.Current;
					if (LikeOperator.LikeString(dobjAcadBlock4.Name, "[*]Paper_Space*", CompareMethod.Binary))
					{
						InternListBlockBegin(dobjAcadBlock4.BlockBegin, ref rlngIdx);
						InternListBlockData(dobjAcadBlock4, ref rlngIdx);
						hwpDxf_List.BkDXFList_AcadBlockEntities(mstrAcadVer, dobjAcadBlock4, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
						InternListBlockEnd(dobjAcadBlock4.BlockEnd, ref rlngIdx);
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
			IEnumerator enumerator2 = default(IEnumerator);
			try
			{
				enumerator2 = mobjAcadBlocks.GetValues().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					dobjAcadBlock4 = (AcadBlock)enumerator2.Current;
					if (!LikeOperator.LikeString(dobjAcadBlock4.Name, "[*]Model_Space", CompareMethod.Binary) & !LikeOperator.LikeString(dobjAcadBlock4.Name, "[*]Paper_Space*", CompareMethod.Binary))
					{
						InternListBlockBegin(dobjAcadBlock4.BlockBegin, ref rlngIdx);
						InternListBlockData(dobjAcadBlock4, ref rlngIdx);
						hwpDxf_List.BkDXFList_AcadBlockEntities(mstrAcadVer, dobjAcadBlock4, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
						InternListBlockEnd(dobjAcadBlock4.BlockEnd, ref rlngIdx);
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			dobjAcadBlock4 = null;
		}

		private void InternListBlockBegin(AcadBlockBegin vobjAcadBlockBegin, ref int rlngIdx)
		{
			AcadBlockBegin acadBlockBegin = vobjAcadBlockBegin;
			InternAddToDictLine(ref rlngIdx, 0, "BLOCK");
			InternAddToDictLine(ref rlngIdx, 5, acadBlockBegin.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadBlockBegin.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadBlockBegin.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, "AcDbEntity");
			if (acadBlockBegin.IsPaperSpace)
			{
				InternAddToDictLine(ref rlngIdx, 67, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadBlockBegin.IsPaperSpace, 1, 0)));
			}
			InternAddToDictLine(ref rlngIdx, 8, acadBlockBegin.Layer);
			if (Operators.CompareString(acadBlockBegin.Linetype, hwpDxf_Vars.pstrEntityLinetype, TextCompare: false) != 0)
			{
				InternAddToDictLine(ref rlngIdx, 6, acadBlockBegin.Linetype);
			}
			if (acadBlockBegin.Color != hwpDxf_Vars.pnumEntityColor)
			{
				InternAddToDictLine(ref rlngIdx, 62, acadBlockBegin.Color);
			}
			if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockBegin.LinetypeScale, hwpDxf_Vars.pdecLinetypeScale, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockBegin.LinetypeScale, hwpDxf_Vars.pdblLinetypeScale, TextCompare: false)))))
			{
				InternAddToDictLine(ref rlngIdx, 48, RuntimeHelpers.GetObjectValue(acadBlockBegin.LinetypeScale));
			}
			if ((double)acadBlockBegin.Lineweight != (double)hwpDxf_ConstMisc.pclngLineweight)
			{
				InternAddToDictLine(ref rlngIdx, 370, acadBlockBegin.Lineweight);
			}
			if (acadBlockBegin.PlotStyleNameObjectID != -1.0)
			{
				InternAddToDictLine(ref rlngIdx, Conversions.ToInteger("390"), acadBlockBegin.PlotStyleNameReference);
			}
			InternAddToDictLine(ref rlngIdx, 100, acadBlockBegin.ObjectName);
			acadBlockBegin = null;
		}

		private void InternListBlockEnd(AcadBlockEnd vobjAcadBlockEnd, ref int rlngIdx)
		{
			AcadBlockEnd acadBlockEnd = vobjAcadBlockEnd;
			InternAddToDictLine(ref rlngIdx, 0, "ENDBLK");
			InternAddToDictLine(ref rlngIdx, 5, acadBlockEnd.Handle);
			hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadBlockEnd.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
			InternAddToDictLine(ref rlngIdx, 330, acadBlockEnd.OwnerID);
			InternAddToDictLine(ref rlngIdx, 100, "AcDbEntity");
			if (acadBlockEnd.IsPaperSpace)
			{
				InternAddToDictLine(ref rlngIdx, 67, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadBlockEnd.IsPaperSpace, 1, 0)));
			}
			InternAddToDictLine(ref rlngIdx, 8, acadBlockEnd.Layer);
			if (Operators.CompareString(acadBlockEnd.Linetype, hwpDxf_Vars.pstrEntityLinetype, TextCompare: false) != 0)
			{
				InternAddToDictLine(ref rlngIdx, 6, acadBlockEnd.Linetype);
			}
			if (acadBlockEnd.Color != hwpDxf_Vars.pnumEntityColor)
			{
				InternAddToDictLine(ref rlngIdx, 62, acadBlockEnd.Color);
			}
			if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockEnd.LinetypeScale, hwpDxf_Vars.pdecLinetypeScale, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockEnd.LinetypeScale, hwpDxf_Vars.pdblLinetypeScale, TextCompare: false)))))
			{
				InternAddToDictLine(ref rlngIdx, 48, RuntimeHelpers.GetObjectValue(acadBlockEnd.LinetypeScale));
			}
			if ((double)acadBlockEnd.Lineweight != (double)hwpDxf_ConstMisc.pclngLineweight)
			{
				InternAddToDictLine(ref rlngIdx, 370, acadBlockEnd.Lineweight);
			}
			if (acadBlockEnd.PlotStyleNameObjectID != -1.0)
			{
				InternAddToDictLine(ref rlngIdx, Conversions.ToInteger("390"), acadBlockEnd.PlotStyleNameReference);
			}
			InternAddToDictLine(ref rlngIdx, 100, acadBlockEnd.ObjectName);
			acadBlockEnd = null;
		}

		private void InternListBlockData(AcadBlock vobjAcadBlock, ref int rlngIdx)
		{
			AcadBlock acadBlock = vobjAcadBlock;
			InternAddToDictLine(ref rlngIdx, 2, acadBlock.Name);
			InternAddToDictLine(ref rlngIdx, 70, acadBlock.Flags70);
			object dvarPoint = RuntimeHelpers.GetObjectValue(acadBlock.Origin);
			InternAddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
			{
			0
			}, null)));
			InternAddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
			{
			1
			}, null)));
			InternAddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
			{
			2
			}, null)));
			InternAddToDictLine(ref rlngIdx, 3, acadBlock.Name);
			InternAddToDictLine(ref rlngIdx, 1, acadBlock.PathName);
			if (Operators.CompareString(acadBlock.Comment, null, TextCompare: false) != 0)
			{
				InternAddToDictLine(ref rlngIdx, 4, acadBlock.Comment);
			}
			acadBlock = null;
		}
	}
}
