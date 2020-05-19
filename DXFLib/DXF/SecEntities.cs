using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class SecEntities
	{
		public delegate void ReadAddEntryEventHandler(int AddEntry);

		private const string cstrClassName = "SecEntities";

		private bool mblnOpened;

		private string mstrAcadVer;

		private int mlngSecBeg;

		private int mlngSecEnd;

		private int mlngLastEntry;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadModelSpace mobjAcadModelSpace;

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

		public SecEntities()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~SecEntities()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictReadCodes = null;
				mobjDictReadValues = null;
				mobjAcadModelSpace = null;
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

		public bool Read(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			mobjAcadModelSpace = mobjAcadDatabase.ModelSpace;
			checked
			{
				bool Read = default(bool);
				if (mobjAcadModelSpace == null)
				{
					nrstrErrMsg = "Kein Modellbereich definiert.";
				}
				else
				{
					mlngLastEntry = mlngSecBeg - 1;
					Read = InternReadSection(ref nrstrErrMsg);
					InternCheckIndex(mlngSecEnd + 2);
				}
				return Read;
			}
		}

		public void ListSection(ref int rlngIdx)
		{
			mobjAcadModelSpace = mobjAcadDatabase.ModelSpace;
			InternAddToDictLine(ref rlngIdx, 0, "SECTION");
			mlngSecBeg = rlngIdx;
			InternAddToDictLine(ref rlngIdx, 2, "ENTITIES");
			if (mobjAcadModelSpace != null)
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

		private bool InternReadSection(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			int dlngIdx = mlngSecBeg;
			InternIncreaseIndex(ref dlngIdx, 1);
			bool dblnError = default(bool);
			AcadPolyfaceMesh dobjAcadPolyfaceMesh = default(AcadPolyfaceMesh);
			AcadPolygonMesh dobjAcadPolygonMesh = default(AcadPolygonMesh);
			Acad3DPolyline dobjAcad3DPolyline = default(Acad3DPolyline);
			AcadPolyline dobjAcadPolyline = default(AcadPolyline);
			while (dlngIdx <= mlngSecEnd && !dblnError)
			{
				int dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
				object dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
				if (dlngCode2 != 0)
				{
					nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(checked(dlngIdx * 2 + 1)) + ".";
					dblnError = true;
					continue;
				}
				InternIncreaseIndex(ref dlngIdx, 1);
				object left = dvarValue2;
				if (Operators.ConditionalCompareObjectEqual(left, "ARC", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadArc(vobjAcadDatabase, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "CIRCLE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase2 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadCircle(vobjAcadDatabase2, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "LINE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase3 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadLine(vobjAcadDatabase3, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "POINT", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase4 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadPoint(vobjAcadDatabase4, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "XLINE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase5 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadXline(vobjAcadDatabase5, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "RAY", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase6 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadRay(vobjAcadDatabase6, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "LWPOLYLINE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase7 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadLWPolyline(vobjAcadDatabase7, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "POLYLINE", TextCompare: false))
				{
					int dlngAcadPolylineIdx = dlngIdx;
					AcadDatabase vobjAcadDatabase8 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadPolyline(ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, vobjAcadDatabase8, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
					if (dblnError)
					{
						continue;
					}
					bool dblnAcadPolyline = true;
					while (dlngIdx <= mlngSecEnd && !dblnError && dblnAcadPolyline)
					{
						dlngCode2 = Conversions.ToInteger(mobjDictReadCodes[dlngIdx]);
						dvarValue2 = RuntimeHelpers.GetObjectValue(mobjDictReadValues[dlngIdx]);
						if (dlngCode2 != 0)
						{
							nrstrErrMsg = "Fehlender Objektnamencode in Zeile " + Conversions.ToString(checked(dlngIdx * 2 + 1)) + ".";
							dblnError = true;
							continue;
						}
						InternIncreaseIndex(ref dlngIdx, 1);
						object left2 = dvarValue2;
						if (Operators.ConditionalCompareObjectEqual(left2, "VERTEX", TextCompare: false))
						{
							dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadVertex(mobjAcadDatabase, ref dlngIdx, ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
							InternCheckIndex(dlngIdx);
						}
						else if (Operators.ConditionalCompareObjectEqual(left2, "SEQEND", TextCompare: false))
						{
							AcadDatabase vobjAcadDatabase9 = mobjAcadDatabase;
							AcadBlockReference robjAcadBlockReference = null;
							AcadMInsertBlock robjAcadMInsertBlock = null;
							dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSequenceEnd(vobjAcadDatabase9, ref dlngIdx, ref robjAcadBlockReference, ref robjAcadMInsertBlock, ref dobjAcadPolyline, ref dobjAcad3DPolyline, ref dobjAcadPolygonMesh, ref dobjAcadPolyfaceMesh, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
							InternCheckIndex(dlngIdx);
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
					AcadDatabase vobjAcadDatabase10 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadMText(vobjAcadDatabase10, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "TEXT", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase11 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadText(vobjAcadDatabase11, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ATTDEF", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase12 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadAttributeDefinition(vobjAcadDatabase12, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "INSERT", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase13 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadBlockReference(vobjAcadDatabase13, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SHAPE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase14 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadShape(vobjAcadDatabase14, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "ELLIPSE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase15 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadEllipse(vobjAcadDatabase15, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "HATCH", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase16 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadHatch(vobjAcadDatabase16, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SPLINE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase17 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSpline(vobjAcadDatabase17, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "TRACE", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase18 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadTrace(vobjAcadDatabase18, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else if (Operators.ConditionalCompareObjectEqual(left, "SOLID", TextCompare: false))
				{
					AcadDatabase vobjAcadDatabase19 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadSolid(vobjAcadDatabase19, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
				else
				{
					int vlngSecEnd = mlngSecEnd;
					string vstrDXFName = Conversions.ToString(dvarValue2);
					AcadDatabase vobjAcadDatabase20 = mobjAcadDatabase;
					AcadBlock robjAcadBlock = null;
					dblnError = !hwpDxf_ReadEnt.BkDXFReadEnt_AcadUnknownEnt(vlngSecEnd, vstrDXFName, vobjAcadDatabase20, ref dlngIdx, ref robjAcadBlock, mobjDictReadCodes, mobjDictReadValues, ref nrstrErrMsg);
					InternCheckIndex(dlngIdx);
				}
			}
			bool InternReadSection = !dblnError;
			dobjAcadPolyfaceMesh = null;
			dobjAcadPolygonMesh = null;
			dobjAcad3DPolyline = null;
			dobjAcadPolyline = null;
			return InternReadSection;
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListSection(ref int rlngIdx)
		{
			hwpDxf_List.BkDXFList_AcadBlockEntities(mstrAcadVer, mobjAcadModelSpace.FriendGetAcadBlock(), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
		}
	}
}
