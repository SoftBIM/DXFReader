using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using Microsoft.VisualBasic;

namespace DXFLib.Acad
{
	public class AcadTable : AcadObject
	{
		private const string cstrClassName = "AcadTable";

		private bool mblnOpened;

		private string mstrSuperiorObjectName;

		private string mstrSubordinateObjectName;

		private int mlngTableIndex;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictObjectID;

		private Dictionary<object, object> mobjDictNames;

		private Dictionary<object, object> mobjDictViewports;

		internal string FriendLetSubordinateObjectName
		{
			set
			{
				mstrSubordinateObjectName = value;
			}
		}

		public int Count => mcolClass.Count;

		public string SuperiorObjectName => mstrSuperiorObjectName;

		public string SubordinateObjectName => mstrSubordinateObjectName;

		public AcadTable()
		{
			mblnOpened = true;
			base.FriendLetDXFName = "TABLE";
			mstrSuperiorObjectName = "AcDbSymbolTable";
			mstrSubordinateObjectName = "AcDbSymbolTable";
			base.FriendLetObjectName = "AcDbSymbolTable";
			mcolClass = new OrderedDictionary();
			mobjDictObjectID = new Dictionary<object, object>();
			mobjDictNames = new Dictionary<object, object>();
			mobjDictViewports = new Dictionary<object, object>();
			mlngTableIndex = -1;
		}

		~AcadTable()
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
				mobjDictObjectID = null;
				mobjDictNames = null;
				mobjDictViewports = null;
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadTable");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private object InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadTableRecord dobjAcadTableRecord4;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadTableRecord4 = (AcadTableRecord)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadTableRecord4.TableIndex));
					AcadObject robjAcadObject = dobjAcadTableRecord4;
					hwpDxf_AcadObject.BkAcadObject_Quit(ref robjAcadObject);
					dobjAcadTableRecord4 = (AcadTableRecord)robjAcadObject;
					dobjAcadTableRecord4 = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngTableIndex = -1;
			dobjAcadTableRecord4 = null;
			object InternClear = default(object);
			return InternClear;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal bool FriendNameExist(string vstrName)
		{
			return mobjDictNames.ContainsKey(Strings.UCase(vstrName));
		}

		internal AcadTableRecord FriendGetItem(object vvarIndex)
		{
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) == VariantType.String)
			{
				return InternGetItemByName(Conversions.ToString(vvarIndex));
			}
			AcadTableRecord FriendGetItem = default(AcadTableRecord);
			try
			{
				FriendGetItem = (AcadTableRecord)mcolClass[checked(Conversions.ToInteger(vvarIndex) - 1)];
				return FriendGetItem;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
				return FriendGetItem;
			}
		}

		internal AcadTableRecord FriendGetItemByObjectID(double vdblObjectID)
		{
			AcadTableRecord FriendGetItemByObjectID = default(AcadTableRecord);
			AcadTableRecord dobjAcadTableRecord3 = default(AcadTableRecord);
			if (mobjDictObjectID.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				AcadDatabase database = base.Database;
				AcadObject robjAcadObject = dobjAcadTableRecord3;
				string nrstrErrMsg = "";
				bool flag = database.FriendObjectIdToObject(vdblObjectID, ref robjAcadObject, ref nrstrErrMsg);
				dobjAcadTableRecord3 = (AcadTableRecord)robjAcadObject;
				if (flag)
				{
					FriendGetItemByObjectID = dobjAcadTableRecord3;
				}
			}
			dobjAcadTableRecord3 = null;
			return FriendGetItemByObjectID;
		}

		internal AcadTableRecord FriendGetItemByTableIndex(int vlngTableIndex)
		{
			AcadTableRecord FriendGetItemByTableIndex = default(AcadTableRecord);
			try
			{
				FriendGetItemByTableIndex = (AcadTableRecord)mcolClass["K" + Conversions.ToString(vlngTableIndex)];
				return FriendGetItemByTableIndex;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
				return FriendGetItemByTableIndex;
			}
		}

		internal AcadTableRecord FriendRemove(string vstrName)
		{
			AcadTableRecord dobjAcadTableRecord3 = FriendGetItem(vstrName);
			AcadTableRecord FriendRemove = default(AcadTableRecord);
			if (dobjAcadTableRecord3 != null)
			{
				if (!InternRemove(dobjAcadTableRecord3))
				{
					dobjAcadTableRecord3 = null;
					FriendRemove = null;
					goto IL_002d;
				}
				FriendRemove = dobjAcadTableRecord3;
			}
			dobjAcadTableRecord3 = null;
			goto IL_002d;
		IL_002d:
			return FriendRemove;
		}

		internal AcadTableRecord FriendRemoveByObjectID(double vdblObjectID)
		{
			AcadTableRecord dobjAcadTableRecord4 = FriendGetItemByObjectID(vdblObjectID);
			AcadTableRecord FriendRemoveByObjectID = default(AcadTableRecord);
			if (dobjAcadTableRecord4 != null)
			{
				if (!InternRemove(dobjAcadTableRecord4))
				{
					dobjAcadTableRecord4 = null;
					FriendRemoveByObjectID = null;
					goto IL_0040;
				}
				AcadObject robjAcadObject = dobjAcadTableRecord4;
				hwpDxf_AcadObject.BkAcadObject_Quit(ref robjAcadObject);
				dobjAcadTableRecord4 = (AcadTableRecord)robjAcadObject;
				FriendRemoveByObjectID = dobjAcadTableRecord4;
			}
			dobjAcadTableRecord4 = null;
			goto IL_0040;
		IL_0040:
			return FriendRemoveByObjectID;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void Add(ref AcadTableRecord robjAcadTableRecord, string vstrName)
		{
			if (Operators.CompareString(SubordinateObjectName, "AcDbTextStyleTable", TextCompare: false) != 0 && Operators.CompareString(vstrName, null, TextCompare: false) == 0)
			{
				Information.Err().Raise(50000, "AcadTable", "Ungültiger Name.");
				return;
			}
			checked
			{
				mlngTableIndex++;
				robjAcadTableRecord.FriendLetTableIndex = mlngTableIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngTableIndex), robjAcadTableRecord);
				mobjDictObjectID.Add("K" + Conversions.ToString(robjAcadTableRecord.ObjectID), robjAcadTableRecord.ObjectID);
				if (Operators.CompareString(SubordinateObjectName, "AcDbViewportTable", TextCompare: false) == 0)
				{
					mobjDictViewports.Add("K" + Conversions.ToString(robjAcadTableRecord.ObjectID), mlngTableIndex);
				}
				else
				{
					mobjDictNames.Add(Strings.UCase(vstrName), mlngTableIndex);
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadTableRecord Item(object vvarIndex)
		{
			AcadTableRecord dobjAcadTableRecord3 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadTableRecord Item;
			if (dobjAcadTableRecord3 == null)
			{
				dobjAcadTableRecord3 = null;
				Item = dobjAcadTableRecord3;
				Information.Err().Raise(50000, "AcadTable", "Element existiert nicht.");
			}
			else
			{
				Item = dobjAcadTableRecord3;
				dobjAcadTableRecord3 = null;
			}
			return Item;
		}

		private AcadTableRecord InternGetItemByName(string vstrName)
		{
			vstrName = Strings.UCase(vstrName);
			if (Operators.CompareString(SubordinateObjectName, "AcDbViewportTable", TextCompare: false) == 0)
			{
				if (mobjDictViewports.Count > 0)
				{
					int dlngTableIndex = Conversions.ToInteger(NewLateBinding.LateIndexGet(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictViewports.Values), new object[1]
					{
					0
					}, null));
					return FriendGetItemByTableIndex(dlngTableIndex);
				}
			}
			else if (mobjDictNames.ContainsKey(vstrName))
			{
				int dlngTableIndex = Conversions.ToInteger(mobjDictNames[vstrName]);
				return FriendGetItemByTableIndex(dlngTableIndex);
			}
			AcadTableRecord InternGetItemByName = default(AcadTableRecord);
			return InternGetItemByName;
		}

		internal bool InternRemove(AcadTableRecord vobjAcadTableRecord)
		{
			int dlngIndex = vobjAcadTableRecord.TableIndex;
			try
			{
				mcolClass.Remove("K" + Conversions.ToString(dlngIndex));
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				bool InternRemove = false;
				ProjectData.ClearProjectError();
				return InternRemove;
			}
			mobjDictObjectID.Remove("K" + Conversions.ToString(vobjAcadTableRecord.ObjectID));
			if (Operators.CompareString(SubordinateObjectName, "AcDbViewportTable", TextCompare: false) == 0)
			{
				mobjDictViewports.Remove("K" + Conversions.ToString(vobjAcadTableRecord.ObjectID));
			}
			else
			{
				mobjDictNames.Remove(Strings.UCase(vobjAcadTableRecord.Name));
			}
			return true;
		}
	}

}
