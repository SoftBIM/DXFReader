using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using Microsoft.VisualBasic.Compatibility.VB6;

namespace DXFLib.Acad
{
	public class AcadXData : NodeObject
	{
		private const string cstrClassName = "AcadXData";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private double mdblOwnerID;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictNames;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataApp dobjAcadXDataApp2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataApp2 = (AcadXDataApp)enumerator.Current;
						dobjAcadXDataApp2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataApp2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataApp dobjAcadXDataApp2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataApp2 = (AcadXDataApp)enumerator.Current;
						dobjAcadXDataApp2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataApp2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataApp dobjAcadXDataApp2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataApp2 = (AcadXDataApp)enumerator.Current;
						dobjAcadXDataApp2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataApp2 = null;
			}
		}

		internal double FriendLetOwnerID
		{
			set
			{
				mdblOwnerID = value;
			}
		}

		public AcadDatabase Database
		{
			get
			{
				if (mlngDatabaseIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex);
				}
				AcadDatabase Database = default(AcadDatabase);
				return Database;
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
			}
		}

		public AcadApplication Application
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public int Count => mcolClass.Count;

		public double OwnerID => mdblOwnerID;

		public string OwnerHandle => hwpDxf_Functions.BkDXF_DblToHex(mdblOwnerID);

		public AcadXData()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 191;
			base.FriendLetNodeImageDisabledID = 192;
			base.FriendLetNodeName = "Erweiterungsdaten";
			base.FriendLetNodeText = "- Erweiterungsdaten";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mdblOwnerID = -1.0;
			mcolClass = new OrderedDictionary();
			mobjDictNames = new Dictionary<object, object>();
		}

		~AcadXData()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				base.FriendQuit();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadXData");
				mcolClass = null;
				mobjDictNames = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadXDataApp dobjAcadXDataApp2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadXDataApp2 = (AcadXDataApp)enumerator.Current;
					string dstrName = Strings.UCase(dobjAcadXDataApp2.AppName);
					mcolClass.Remove(dstrName);
					mobjDictNames.Remove(dstrName);
					dobjAcadXDataApp2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadXDataApp2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		public void GetXData(string vstrAppName, ref object rvarXDataType, ref object rvarXDataValue)
		{
			rvarXDataType = null;
			rvarXDataValue = null;
			if (Operators.CompareString(vstrAppName, null, TextCompare: false) == 0)
			{
				InternGetAllXData(ref rvarXDataType, ref rvarXDataValue);
			}
			else
			{
				InternGetOneXData(vstrAppName, ref rvarXDataType, ref rvarXDataValue);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetXData(object vvarXDataType, object vvarXDataValue)
		{
			string dstrErrMsg = default(string);
			AcadXDataApp dobjOldAcadXDataApp4 = default(AcadXDataApp);
			AcadXDataApp dobjNewAcadXDataApp4 = default(AcadXDataApp);
			OrderedDictionary dcolClass2;
			Dictionary<object, object> dobjDictNames2;
			if (vvarXDataType == null && vvarXDataValue == null)
			{
				IEnumerator enumerator = default(IEnumerator);
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjOldAcadXDataApp4 = (AcadXDataApp)enumerator.Current;
						dobjOldAcadXDataApp4.FriendQuit();
						dobjOldAcadXDataApp4 = null;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				mcolClass = new OrderedDictionary();
				mobjDictNames = new Dictionary<object, object>();
			}
			else
			{
				if (!hwpDxf_XData.BkDXFXData_Check(RuntimeHelpers.GetObjectValue(vvarXDataType), RuntimeHelpers.GetObjectValue(vvarXDataValue), ref dstrErrMsg, nvblnWithAppName: true, nvblnExtCoords: false))
				{
					goto IL_0328;
				}
				dcolClass2 = new OrderedDictionary();
				dobjDictNames2 = new Dictionary<object, object>();
				int num = Information.LBound((Array)vvarXDataType);
				int num2 = Information.UBound((Array)vvarXDataType);
				checked
				{
					for (int dlngIdx2 = num; dlngIdx2 <= num2; dlngIdx2++)
					{
						short dintXDataType = Conversions.ToShort(NewLateBinding.LateIndexGet(vvarXDataType, new object[1]
						{
						dlngIdx2
						}, null));
						object dvarXDataValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarXDataValue, new object[1]
						{
						dlngIdx2
						}, null));
						if (dintXDataType == 1001)
						{
							string dstrName2;
							if (dobjNewAcadXDataApp4 != null)
							{
								dstrName2 = Strings.UCase(dobjNewAcadXDataApp4.AppName);
								dcolClass2.Add(dstrName2, dobjNewAcadXDataApp4);
								dobjDictNames2.Add(dstrName2, dstrName2);
								dobjNewAcadXDataApp4 = null;
							}
							string dstrAppName = Conversions.ToString(dvarXDataValue);
							dstrName2 = Strings.UCase(dstrAppName);
							if (dobjDictNames2.ContainsKey(dstrName2))
							{
								try
								{
									dobjNewAcadXDataApp4 = (AcadXDataApp)dcolClass2[dstrName2];
								}
								catch (Exception ex3)
								{
									ProjectData.SetProjectError(ex3);
									Exception ex = ex3;
									ProjectData.ClearProjectError();
								}
							}
							else
							{
								dobjNewAcadXDataApp4 = null;
							}
							if (dobjNewAcadXDataApp4 == null)
							{
								dobjNewAcadXDataApp4 = new AcadXDataApp();
								dobjNewAcadXDataApp4.FriendLetAppName = dstrAppName;
							}
							InternAddAcadObjectRegisteredApplication(dstrName2);
							continue;
						}
						if (dobjNewAcadXDataApp4 != null)
						{
							dobjNewAcadXDataApp4.FriendAdd(dintXDataType, RuntimeHelpers.GetObjectValue(dvarXDataValue));
							continue;
						}
						goto IL_01ca;
					}
					if (dobjNewAcadXDataApp4 != null)
					{
						string dstrName2 = Strings.UCase(dobjNewAcadXDataApp4.AppName);
						dcolClass2.Add(dstrName2, dobjNewAcadXDataApp4);
						dobjDictNames2.Add(dstrName2, dstrName2);
						dobjNewAcadXDataApp4 = null;
					}
					int count = dcolClass2.Count;
					for (int dlngIdx2 = 1; dlngIdx2 <= count; dlngIdx2++)
					{
						dobjNewAcadXDataApp4 = (AcadXDataApp)dcolClass2[dlngIdx2 - 1];
						string dstrAppName = dobjNewAcadXDataApp4.AppName;
						string dstrName2 = Strings.UCase(dstrAppName);
						if (mobjDictNames.ContainsKey(dstrName2))
						{
							try
							{
								dobjOldAcadXDataApp4 = (AcadXDataApp)mcolClass[dstrName2];
							}
							catch (Exception ex4)
							{
								ProjectData.SetProjectError(ex4);
								Exception ex2 = ex4;
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							dobjOldAcadXDataApp4 = null;
						}
						if (dobjOldAcadXDataApp4 != null)
						{
							mcolClass.Remove(dstrName2);
							mobjDictNames.Remove(dstrName2);
							dobjOldAcadXDataApp4 = null;
						}
						dobjNewAcadXDataApp4.FriendLetNodeParentID = base.NodeID;
						dobjNewAcadXDataApp4.FriendLetApplicationIndex = mlngApplicationIndex;
						dobjNewAcadXDataApp4.FriendLetDocumentIndex = mlngDocumentIndex;
						dobjNewAcadXDataApp4.FriendLetDatabaseIndex = mlngDatabaseIndex;
						mcolClass.Add(dstrName2, dobjNewAcadXDataApp4);
						mobjDictNames.Add(dstrName2, dstrName2);
					}
				}
			}
			goto IL_034e;
		IL_01ca:
			dstrErrMsg = "Fehlender Applikationsname.";
			goto IL_0328;
		IL_034e:
			dobjOldAcadXDataApp4 = null;
			dobjNewAcadXDataApp4 = null;
			dcolClass2 = null;
			dobjDictNames2 = null;
			return;
		IL_0328:
			Information.Err().Raise(50000, "AcadXData", "Ungültige erweiterte Daten.\n" + dstrErrMsg);
			goto IL_034e;
		}

		private void InternAddAcadObjectRegisteredApplication(string vstrName)
		{
			AcadRegisteredApplications dobjAcadRegisteredApplications = Document.RegisteredApplications;
			if (dobjAcadRegisteredApplications != null)
			{
				AcadRegisteredApplication dobjAcadRegisteredApplication = (AcadRegisteredApplication)dobjAcadRegisteredApplications.FriendGetItem(vstrName);
				if (dobjAcadRegisteredApplication == null)
				{
					double friendGetNextObjectID = Database.FriendGetNextObjectID;
					string nrstrErrMsg = "";
					dobjAcadRegisteredApplications.FriendAddAcadObject(vstrName, friendGetNextObjectID, ref nrstrErrMsg);
				}
			}
		}

		private void InternGetAllXData(ref object rvarXDataType, ref object rvarXDataValue)
		{
			rvarXDataType = null;
			rvarXDataValue = null;
			int dlngCount = -1;
			checked
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataApp dobjAcadXDataApp3;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataApp3 = (AcadXDataApp)enumerator.Current;
						dlngCount = dlngCount + dobjAcadXDataApp3.Count + 1;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (dlngCount > -1)
				{
					int dlngIdx = 0;
					object[] davarXDataType = new object[dlngCount + dlngIdx + 1];
					object[] davarXDataValue = new object[dlngCount + dlngIdx + 1];
					IEnumerator enumerator2 = default(IEnumerator);
					try
					{
						enumerator2 = mcolClass.Values.GetEnumerator();
						object[] dvarAppXDataType = default(object[]);
						object[] dvarAppXDataValue = default(object[]);
						while (enumerator2.MoveNext())
						{
							dobjAcadXDataApp3 = (AcadXDataApp)enumerator2.Current;
							AcadXDataApp acadXDataApp = dobjAcadXDataApp3;
							object rvarXDataType2 = dvarAppXDataType;
							object rvarXDataValue2 = dvarAppXDataValue;
							acadXDataApp.GetXData(ref rvarXDataType2, ref rvarXDataValue2);
							dvarAppXDataValue = (object[])rvarXDataValue2;
							dvarAppXDataType = (object[])rvarXDataType2;
							int num = Information.LBound(dvarAppXDataType);
							int num2 = Information.UBound(dvarAppXDataType);
							for (int dlngAppIdx = num; dlngAppIdx <= num2; dlngAppIdx++)
							{
								davarXDataType[dlngIdx] = RuntimeHelpers.GetObjectValue(dvarAppXDataType[dlngAppIdx]);
								davarXDataValue[dlngIdx] = RuntimeHelpers.GetObjectValue(dvarAppXDataValue[dlngAppIdx]);
								dlngIdx++;
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
					rvarXDataType = Support.CopyArray(davarXDataType);
					rvarXDataValue = Support.CopyArray(davarXDataValue);
				}
				dobjAcadXDataApp3 = null;
			}
		}

		private void InternGetOneXData(string vstrAppName, ref object rvarXDataType, ref object rvarXDataValue)
		{
			rvarXDataType = null;
			rvarXDataValue = null;
			string dstrName = Strings.UCase(vstrAppName);
			AcadXDataApp dobjAcadXDataApp2 = default(AcadXDataApp);
			if (mobjDictNames.ContainsKey(dstrName))
			{
				try
				{
					dobjAcadXDataApp2 = (AcadXDataApp)mcolClass[dstrName];
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
				dobjAcadXDataApp2?.GetXData(ref rvarXDataType, ref rvarXDataValue);
			}
			dobjAcadXDataApp2 = null;
		}
	}
}
