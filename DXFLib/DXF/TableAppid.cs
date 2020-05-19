using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
    public class TableAppid
	{
		private const string cstrClassName = "TableAppid";

		private bool mblnOpened;

		private int mlngTblBeg;

		private int mlngTblEnd;

		private Dictionary<object, object> mobjDictReadCodes;

		private Dictionary<object, object> mobjDictReadValues;

		private AcadDatabase mobjAcadDatabase;

		private AcadRegisteredApplications mobjAcadRegisteredApplications;

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

		public string Name => "APPID";

		public int StartLine => checked((mlngTblBeg - 1) * 2 + 1);

		public int EndLine => checked((mlngTblEnd + 1) * 2 + 2);

		private void Class_Initialize_Renamed()
		{
			mblnOpened = true;
		}

		public TableAppid()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			FriendQuit();
		}

		~TableAppid()
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
				mobjAcadRegisteredApplications = null;
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

		public bool Read(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			return InternReadTable(ref nrstrErrMsg);
		}

		public void ListTable(ref int rlngIdx)
		{
			mobjAcadRegisteredApplications = mobjAcadDatabase.RegisteredApplications;
			if (mobjAcadRegisteredApplications != null)
			{
				InternAddToDictLine(ref rlngIdx, 0, "TABLE");
				mlngTblBeg = rlngIdx;
				AcadRegisteredApplications acadRegisteredApplications = mobjAcadRegisteredApplications;
				InternAddToDictLine(ref rlngIdx, 2, acadRegisteredApplications.DXFName);
				InternAddToDictLine(ref rlngIdx, 5, acadRegisteredApplications.Handle);
				hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadRegisteredApplications.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
				InternAddToDictLine(ref rlngIdx, 330, acadRegisteredApplications.OwnerID);
				InternAddToDictLine(ref rlngIdx, 100, acadRegisteredApplications.SuperiorObjectName);
				InternAddToDictLine(ref rlngIdx, 70, acadRegisteredApplications.Count);
				acadRegisteredApplications = null;
				InternListTable(ref rlngIdx);
				mlngTblEnd = rlngIdx;
				InternAddToDictLine(ref rlngIdx, 0, "ENDTAB");
			}
		}

		private bool InternReadTable(ref string nrstrErrMsg = "")
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
				mobjAcadRegisteredApplications = mobjAcadDatabase.FriendAddAcadObjectRegisteredApplications(ddblObjectID, ref nrstrErrMsg);
				bool dblnError = default(bool);
				if (mobjAcadRegisteredApplications == null)
				{
					nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
					dblnError = true;
				}
				else
				{
					mobjAcadRegisteredApplications.FriendSetDictXDictionary = dobjDictXDictionary2;
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
						else if (!InternReadAppid(ddblObjectID, ref dlngIdx, ref mobjAcadRegisteredApplications, ref nrstrErrMsg))
						{
							dblnError = true;
						}
					}
				}
				InternReadTable = !dblnError;
			}
			dobjDictXDictionary2 = null;
			return InternReadTable;
		}

		private bool InternReadAppid(double vdblDefOwnerID, ref int rlngIdx, ref AcadRegisteredApplications robjAcadRegisteredApplications, ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			Dictionary<object, object> dobjDictReactors2 = new Dictionary<object, object>();
			Dictionary<object, object> dobjDictXDictionary2 = new Dictionary<object, object>();
			int dlngStartIdx = rlngIdx;
			checked
			{
				double ddblObjectID = default(double);
				double ddblOwnerID = default(double);
				bool InternReadAppid = default(bool);
				AcadRegisteredApplication dobjAcadRegisteredApplication2;
				if (hwpDxf_ReadRef.BkDXFReadRef_AcadSymbolTableRecord(mobjAcadDatabase, vdblDefOwnerID, "APPID", mobjDictReadCodes, mobjDictReadValues, ref rlngIdx, ref ddblObjectID, ref ddblOwnerID, ref dobjDictReactors2, ref dobjDictXDictionary2, ref nrstrErrMsg))
				{
					bool dblnError;
					if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadCodes[rlngIdx], 100, TextCompare: false))
					{
						nrstrErrMsg = "Ungültiger Gruppencode für Objektname in Zeile " + Conversions.ToString(rlngIdx * 2 + 1) + ".";
						dblnError = true;
					}
					else if (Operators.ConditionalCompareObjectNotEqual(mobjDictReadValues[rlngIdx], "AcDbRegAppTableRecord", TextCompare: false))
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
					else
					{
						string dstrName = Conversions.ToString(mobjDictReadValues[rlngIdx + 1]);
						int dlngCode70 = Conversions.ToInteger(mobjDictReadValues[rlngIdx + 2]);
						rlngIdx += 3;
						if (Operators.ConditionalCompareObjectEqual(mobjDictReadCodes[rlngIdx], 71, TextCompare: false))
						{
							rlngIdx++;
						}
						object dvarXDataType = default(object);
						object dvarXDataValue = default(object);
						dblnError = !hwpDxf_ReadBas.BkDXFReadBas_XData(ref rlngIdx, mobjDictReadCodes, mobjDictReadValues, ref dvarXDataType, ref dvarXDataValue, ref nrstrErrMsg);
						if (!dblnError)
						{
							if (robjAcadRegisteredApplications.FriendNameExist(dstrName))
							{
								nrstrErrMsg = "Anwendung " + dstrName + " ab Zeile " + Conversions.ToString(dlngStartIdx * 2 + 1) + " existiert bereits.";
								dblnError = true;
							}
							else
							{
								dobjAcadRegisteredApplication2 = robjAcadRegisteredApplications.FriendAddAcadObject(dstrName, ddblObjectID, ref nrstrErrMsg);
								if (dobjAcadRegisteredApplication2 == null)
								{
									nrstrErrMsg = "Das Objekt konnte nicht hinzugefügt werden.";
									dblnError = true;
								}
								else
								{
									AcadRegisteredApplication acadRegisteredApplication = dobjAcadRegisteredApplication2;
									acadRegisteredApplication.FriendLetFlags70 = dlngCode70;
									acadRegisteredApplication.FriendSetDictReactors = dobjDictReactors2;
									acadRegisteredApplication.FriendSetDictXDictionary = dobjDictXDictionary2;
									acadRegisteredApplication.SetXData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue));
									acadRegisteredApplication = null;
								}
							}
						}
					}
					InternReadAppid = !dblnError;
				}
				dobjDictReactors2 = null;
				dobjDictXDictionary2 = null;
				dobjAcadRegisteredApplication2 = null;
				return InternReadAppid;
			}
		}

		private void InternAddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue)
		{
			hwpDxf_List.BkDXFList_AddToDictLine(ref rlngIdx, vlngCode, RuntimeHelpers.GetObjectValue(vvarValue), ref mobjDictReadCodes, ref mobjDictReadValues);
		}

		private void InternListTable(ref int rlngIdx)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadRegisteredApplication dobjAcadRegisteredApplication2;
			try
			{
				enumerator = mobjAcadRegisteredApplications.GetValues().GetEnumerator();
				object dvarXDataType = default(object);
				object dvarXDataValue = default(object);
				while (enumerator.MoveNext())
				{
					dobjAcadRegisteredApplication2 = (AcadRegisteredApplication)enumerator.Current;
					AcadRegisteredApplication acadRegisteredApplication = dobjAcadRegisteredApplication2;
					InternAddToDictLine(ref rlngIdx, 0, acadRegisteredApplication.DXFName);
					InternAddToDictLine(ref rlngIdx, 5, acadRegisteredApplication.Handle);
					hwpDxf_List.BkDXFList_Reactors((Dictionary<object, object>)acadRegisteredApplication.DictReactors, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					hwpDxf_List.BkDXFList_XDictionary((Dictionary<object, object>)acadRegisteredApplication.DictXDictionaries, ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					InternAddToDictLine(ref rlngIdx, 330, acadRegisteredApplication.OwnerID);
					InternAddToDictLine(ref rlngIdx, 100, acadRegisteredApplication.SuperiorObjectName);
					InternAddToDictLine(ref rlngIdx, 100, acadRegisteredApplication.ObjectName);
					InternAddToDictLine(ref rlngIdx, 2, acadRegisteredApplication.Name);
					InternAddToDictLine(ref rlngIdx, 70, acadRegisteredApplication.Flags70);
					acadRegisteredApplication.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
					hwpDxf_List.BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref mobjDictReadCodes, ref mobjDictReadValues);
					acadRegisteredApplication = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadRegisteredApplication2 = null;
		}
	}
}
