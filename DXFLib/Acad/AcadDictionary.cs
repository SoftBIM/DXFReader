using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadDictionary : AcadObject
	{
		private const string cstrClassName = "AcadDictionary";

		private bool mblnOpened;

		private string mstrSuperiorObjectName;

		private string mstrName;

		private int mblnTreatElementsAsHard;

		private hwpDxf_Enums.MERGE_STYLE mnumMergeStyle;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictNames;

		private Dictionary<object, object> mobjDictKeyword;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadObject dobjAcadObject2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadObject2 = (AcadObject)enumerator.Current;
						hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref dobjAcadObject2, value);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadObject2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadObject dobjAcadObject2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadObject2 = (AcadObject)enumerator.Current;
						hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref dobjAcadObject2, value);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadObject2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadObject dobjAcadObject2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadObject2 = (AcadObject)enumerator.Current;
						hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref dobjAcadObject2, value);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadObject2 = null;
			}
		}

		internal string FriendLetName
		{
			set
			{
				mstrName = value;
			}
		}

		internal bool FriendLetTreatElementsAsHard
		{
			set
			{
				mblnTreatElementsAsHard = 0 - (value ? 1 : 0);
			}
		}

		internal hwpDxf_Enums.MERGE_STYLE FriendLetMergeStyle
		{
			set
			{
				mnumMergeStyle = value;
			}
		}

		public int Count => mcolClass.Count;

		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
				base.FriendLetNodeText = mstrName;
			}
		}

		public bool TreatElementsAsHard => mblnTreatElementsAsHard != 0;

		public int MergeStyle => (int)mnumMergeStyle;

		public string SuperiorObjectName => mstrSuperiorObjectName;

		public AcadDictionary()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 207;
			base.FriendLetNodeImageDisabledID = 208;
			base.FriendLetNodeName = "Wörterbuch";
			base.FriendLetNodeText = "Wörterbuch";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			mblnTreatElementsAsHard = 0 - (hwpDxf_Vars.pblnTreatElementsAsHard ? 1 : 0);
			mnumMergeStyle = hwpDxf_Vars.pnumMergeStyle;
			mcolClass = new OrderedDictionary();
			mobjDictNames = new Dictionary<object, object>();
			mobjDictKeyword = new Dictionary<object, object>();
			base.FriendLetDXFName = "DICTIONARY";
			mstrSuperiorObjectName = "AcDbDictionary";
			base.FriendLetObjectName = "AcDbDictionary";
		}

		~AcadDictionary()
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
				mobjDictKeyword = null;
				if (mcolClass.Count > 0)
				{
					hwpDxf_Functions.BkDXF_DebugPrint("AcadDictionary " + mstrName + ": " + Conversions.ToString(mcolClass.Count));
				}
				mcolClass = null;
				mobjDictNames = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			//Discarded unreachable code: IL_00c3, IL_00fd, IL_00ff, IL_0106, IL_0109, IL_010a, IL_0117, IL_0139
			int num2 = default(int);
			int num3 = default(int);
			try
			{
				int num = 1;
				IEnumerator enumerator = mcolClass.Values.GetEnumerator();
				AcadObject dobjAcadObject;
				while (enumerator.MoveNext())
				{
					dobjAcadObject = (AcadObject)enumerator.Current;
					ProjectData.ClearProjectError();
					num2 = -2;
					num = 3;
					string dstrName = Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(dobjAcadObject.ObjectID)]);
					num = 4;
					mcolClass.Remove(dstrName);
					num = 5;
					mobjDictNames.Remove(Strings.UCase(dstrName));
					ProjectData.ClearProjectError();
					num2 = 0;
					num = 7;
					hwpDxf_AcadObject.BkAcadObject_Quit(ref dobjAcadObject);
					num = 8;
				}
				num = 9;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				num = 10;
				dobjAcadObject = null;
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num3 == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				/*Error near IL_0137: Could not find block for branch target IL_00ff*/
				;
			}
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadObject FriendAdd(string vstrName, double vdblObjectID, ref AcadObject robjAcadObject)
		{
			hwpDxf_AcadObject.BkAcadObject_LetNodeParentID(ref robjAcadObject, base.NodeID);
			hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref robjAcadObject, base.FriendGetApplicationIndex);
			hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref robjAcadObject, base.FriendGetDocumentIndex);
			hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref robjAcadObject, base.FriendGetDatabaseIndex);
			hwpDxf_AcadObject.BkAcadObject_LetOwnerID(ref robjAcadObject, base.ObjectID);
			string dstrErrMsg = default(string);
			bool dblnValid = default(bool);
			if (hwpDxf_AcadObject.BkAcadObject_SetObjectID(ref robjAcadObject, vdblObjectID, ref dstrErrMsg))
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint("Dictionary FriendAdd: " + robjAcadObject.ObjectName + ": " + dstrErrMsg);
			}
			if (dblnValid && FriendAddItem(vstrName, robjAcadObject))
			{
				return robjAcadObject;
			}
			AcadObject FriendAdd = default(AcadObject);
			return FriendAdd;
		}

		internal AcadObject FriendGetItem(object vvarIndex)
		{
			AcadObject FriendGetItem = default(AcadObject);
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) == VariantType.String && mobjDictNames.ContainsKey(Strings.UCase(Conversions.ToString(vvarIndex))))
			{
				try
				{
					FriendGetItem = (AcadObject)mcolClass[Conversions.ToString(vvarIndex)];
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
			return FriendGetItem;
		}

		internal bool FriendAddItem(string vstrName, AcadObject vobjAcadObject)
		{
			string dstrName = Strings.UCase(vstrName);
			bool FriendAddItem2 = default(bool);
			if (!mobjDictNames.ContainsKey(dstrName))
			{
				try
				{
					mcolClass.Add(vstrName, vobjAcadObject);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					hwpDxf_AcadObject.BkAcadObject_Quit(ref vobjAcadObject);
					FriendAddItem2 = false;
					ProjectData.ClearProjectError();
					return FriendAddItem2;
				}
				mobjDictNames.Add(dstrName, vobjAcadObject.ObjectID);
				mobjDictKeyword.Add("K" + Conversions.ToString(vobjAcadObject.ObjectID), vstrName);
				return true;
			}
			return FriendAddItem2;
		}

		internal AcadObject FriendRemoveItem(object vvarIndex)
		{
			AcadObject dobjAcadObject2 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadObject FriendRemoveItem;
			if (dobjAcadObject2 == null)
			{
				FriendRemoveItem = null;
			}
			else
			{
				string dstrName = Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(dobjAcadObject2.ObjectID)]);
				mcolClass.Remove(RuntimeHelpers.GetObjectValue(vvarIndex));
				mobjDictNames.Remove(Strings.UCase(dstrName));
				mobjDictKeyword.Remove("K" + Conversions.ToString(dobjAcadObject2.ObjectID));
				hwpDxf_AcadObject.BkAcadObject_Quit(ref dobjAcadObject2);
				FriendRemoveItem = dobjAcadObject2;
			}
			dobjAcadObject2 = null;
			return FriendRemoveItem;
		}

		internal AcadObject FriendRemoveItemByObjectID(double vdblObjectID)
		{
			if (mobjDictKeyword.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				string dstrName = Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(vdblObjectID)]);
				if (Operators.CompareString(dstrName, null, TextCompare: false) != 0)
				{
					return FriendRemoveItem(dstrName);
				}
			}
			AcadObject FriendRemoveItemByObjectID = default(AcadObject);
			return FriendRemoveItemByObjectID;
		}

		internal AcadObject FriendGetItemByObjectID(double vdblObjectID)
		{
			if (mobjDictKeyword.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				string dstrName = Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(vdblObjectID)]);
				if (Operators.CompareString(dstrName, null, TextCompare: false) != 0)
				{
					return FriendGetItem(dstrName);
				}
			}
			AcadObject FriendGetItemByObjectID = default(AcadObject);
			return FriendGetItemByObjectID;
		}

		internal bool FriendObjectIDExist(double vdblObjectID)
		{
			return mobjDictKeyword.ContainsKey("K" + Conversions.ToString(vdblObjectID));
		}

		internal string FriendGetKeywordByObjectID(double vdblObjectID)
		{
			if (mobjDictKeyword.ContainsKey("K" + Conversions.ToString(vdblObjectID)))
			{
				return Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(vdblObjectID)]);
			}
			string FriendGetKeywordByObjectID = default(string);
			return FriendGetKeywordByObjectID;
		}

		public AcadObject AddObject(string vstrKeyword, string vstrObjectName)
		{
			AcadClasses dobjAcadClasses2 = base.Database.Classes;
			IEnumerator enumerator = default(IEnumerator);
			bool dblnFound = default(bool);
			AcadClass dobjAcadClass2;
			try
			{
				enumerator = dobjAcadClasses2.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadClass2 = (AcadClass)enumerator.Current;
					if (Operators.CompareString(dobjAcadClass2.OriginalClassName, vstrObjectName, TextCompare: false) == 0)
					{
						dblnFound = true;
						break;
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
			AcadObject AddObject = default(AcadObject);
			AcadObject dobjAcadObject2 = default(AcadObject);
			if (dblnFound)
			{
				bool dblnValid2 = false;
				try
				{
					dobjAcadObject2 = (AcadObject)Interaction.CreateObject(vstrObjectName);
					dblnValid2 = true;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
				if (dblnValid2)
				{
					dblnValid2 = false;
					hwpDxf_AcadObject.BkAcadObject_LetNodeParentID(ref dobjAcadObject2, base.NodeID);
					hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref dobjAcadObject2, base.FriendGetApplicationIndex);
					hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref dobjAcadObject2, base.FriendGetDocumentIndex);
					hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref dobjAcadObject2, base.FriendGetDatabaseIndex);
					hwpDxf_AcadObject.BkAcadObject_LetOwnerID(ref dobjAcadObject2, base.ObjectID);
					string dstrErrMsg = default(string);
					if (hwpDxf_AcadObject.BkAcadObject_SetObjectID(ref dobjAcadObject2, base.Database.FriendGetNextObjectID, ref dstrErrMsg))
					{
						dblnValid2 = true;
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint("Dictionary AddObject: " + dobjAcadObject2.ObjectName + ": " + dstrErrMsg);
					}
					if (dblnValid2 && FriendAddItem(vstrKeyword, dobjAcadObject2))
					{
						AddObject = dobjAcadObject2;
					}
				}
			}
			dobjAcadObject2 = null;
			dobjAcadClass2 = null;
			dobjAcadClasses2 = null;
			return AddObject;
		}

		public AcadXRecord AddXRecord(string vstrKeyword)
		{
			AcadXRecord AddXRecord = default(AcadXRecord);
			return AddXRecord;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public string GetName(AcadObject vobjObject)
		{
			double ddblObjectID = vobjObject.ObjectID;
			if (!mobjDictKeyword.ContainsKey("K" + Conversions.ToString(ddblObjectID)))
			{
				Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
				string GetName = default(string);
				return GetName;
			}
			return Conversions.ToString(mobjDictKeyword["K" + Conversions.ToString(ddblObjectID)]);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadObject GetObject_Renamed(string vstrName)
		{
			AcadObject dobjAcadObject3 = FriendGetItem(vstrName);
			AcadObject GetObject_Renamed;
			if (dobjAcadObject3 == null)
			{
				dobjAcadObject3 = null;
				GetObject_Renamed = null;
				Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
			}
			else
			{
				GetObject_Renamed = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return GetObject_Renamed;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadObject Item(object vvarIndex)
		{
			AcadObject dobjAcadObject3 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadObject Item;
			if (dobjAcadObject3 == null)
			{
				dobjAcadObject3 = null;
				Item = null;
				Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
			}
			else
			{
				Item = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return Item;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadObject Remove(string vstrName)
		{
			AcadObject dobjAcadObject3 = FriendRemoveItem(vstrName);
			AcadObject Remove;
			if (dobjAcadObject3 == null)
			{
				dobjAcadObject3 = null;
				Remove = null;
				Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
			}
			else
			{
				Remove = dobjAcadObject3;
				dobjAcadObject3 = null;
			}
			return Remove;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void Rename_Renamed(string vstrOldName, string vstrNewName)
		{
			AcadObject dobjAcadObject4;
			if (Operators.CompareString(vstrOldName, vstrNewName, TextCompare: false) != 0)
			{
				dobjAcadObject4 = FriendGetItem(vstrOldName);
				if (dobjAcadObject4 == null)
				{
					dobjAcadObject4 = null;
					Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
					return;
				}
				if (!FriendAddItem(vstrNewName, dobjAcadObject4))
				{
					dobjAcadObject4 = null;
					Information.Err().Raise(50000, "AcadDictionary", "Element konnte nicht hinzugefügt werden.");
					return;
				}
				FriendRemoveItem(vstrOldName);
			}
			dobjAcadObject4 = null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void Replace_Renamed(string vstrOldName, AcadObject vobjObject)
		{
			AcadObject dobjAcadObject3 = FriendGetItem(vstrOldName);
			if (dobjAcadObject3 == null)
			{
				dobjAcadObject3 = null;
				Information.Err().Raise(50000, "AcadDictionary", "Element existiert nicht.");
			}
			else
			{
				FriendRemoveItem(vstrOldName);
				FriendAddItem(vstrOldName, dobjAcadObject3);
				dobjAcadObject3 = null;
			}
		}
	}
}
