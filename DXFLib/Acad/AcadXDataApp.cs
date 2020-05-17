using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadXDataApp : NodeObject
	{
		private const string cstrClassName = "AcadXDataApp";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngXDataIndex;

		private string mstrAppName;

		private OrderedDictionary mcolClass;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataValue dobjAcadXDataValue2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataValue2 = (AcadXDataValue)enumerator.Current;
						dobjAcadXDataValue2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataValue2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataValue dobjAcadXDataValue2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataValue2 = (AcadXDataValue)enumerator.Current;
						dobjAcadXDataValue2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataValue2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataValue dobjAcadXDataValue2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataValue2 = (AcadXDataValue)enumerator.Current;
						dobjAcadXDataValue2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadXDataValue2 = null;
			}
		}

		internal string FriendLetAppName
		{
			set
			{
				mstrAppName = value;
				base.FriendLetNodeText = mstrAppName;
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

		public string AppName => mstrAppName;

		public int Count => mcolClass.Count;

		public AcadXDataApp()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 193;
			base.FriendLetNodeImageDisabledID = 194;
			base.FriendLetNodeName = "Erweiterungsapplikation";
			base.FriendLetNodeText = "Erweiterungsapplikation";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngXDataIndex = -1;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mstrAppName = hwpDxf_Vars.pstrAppName;
			mcolClass = new OrderedDictionary();
		}

		~AcadXDataApp()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				base.FriendQuit();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadXDataApp");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadXDataValue dobjAcadXDataValue2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadXDataValue2 = (AcadXDataValue)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadXDataValue2.XDataIndex));
					dobjAcadXDataValue2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngXDataIndex = -1;
			dobjAcadXDataValue2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadXDataValue FriendAdd(short vintXDataType, object vvarXDataValue)
		{
			AcadXDataValue dobjAcadXDataValue2 = new AcadXDataValue();
			dobjAcadXDataValue2.FriendLetXDataType = vintXDataType;
			dobjAcadXDataValue2.FriendLetXDataValue = RuntimeHelpers.GetObjectValue(vvarXDataValue);
			dobjAcadXDataValue2.FriendLetNodeParentID = base.NodeID;
			dobjAcadXDataValue2.FriendLetApplicationIndex = mlngApplicationIndex;
			dobjAcadXDataValue2.FriendLetDocumentIndex = mlngDocumentIndex;
			dobjAcadXDataValue2.FriendLetDatabaseIndex = mlngDatabaseIndex;
			checked
			{
				mlngXDataIndex++;
				dobjAcadXDataValue2.FriendLetXDataIndex = mlngXDataIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngXDataIndex), dobjAcadXDataValue2);
				AcadXDataValue FriendAdd = dobjAcadXDataValue2;
				dobjAcadXDataValue2 = null;
				return FriendAdd;
			}
		}

		public void GetXData(ref object rvarXDataType, ref object rvarXDataValue)
		{
			int dlngCount = mcolClass.Count;
			int dlngIdx2 = 0;
			checked
			{
				object[] davarXDataType = new object[dlngCount + dlngIdx2 + 1];
				object[] davarXDataValue = new object[dlngCount + dlngIdx2 + 1];
				davarXDataType[dlngIdx2] = (short)1001;
				davarXDataValue[dlngIdx2] = mstrAppName;
				dlngIdx2++;
				IEnumerator enumerator = default(IEnumerator);
				AcadXDataValue dobjAcadXDataValue2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadXDataValue2 = (AcadXDataValue)enumerator.Current;
						AcadXDataValue acadXDataValue = dobjAcadXDataValue2;
						davarXDataType[dlngIdx2] = acadXDataValue.XDataType;
						davarXDataValue[dlngIdx2] = RuntimeHelpers.GetObjectValue(acadXDataValue.XDataValue);
						acadXDataValue = null;
						dlngIdx2++;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				rvarXDataType = Support.CopyArray(davarXDataType);
				rvarXDataValue = Support.CopyArray(davarXDataValue);
				dobjAcadXDataValue2 = null;
			}
		}
	}
}
