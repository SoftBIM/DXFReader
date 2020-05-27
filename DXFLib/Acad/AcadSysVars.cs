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

namespace DXFLib.Acad
{
	public class AcadSysVars : NodeObject
	{
		private const string cstrClassName = "AcadSysVars";

		private bool mblnOpened;

		private hwpDxf_Enums.REF_TYPE mnumRefType;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictNames;

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadSysVar dobjAcadSysVar2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadSysVar2 = (AcadSysVar)enumerator.Current;
						dobjAcadSysVar2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadSysVar2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadSysVar dobjAcadSysVar2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadSysVar2 = (AcadSysVar)enumerator.Current;
						dobjAcadSysVar2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadSysVar2 = null;
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

		public AcadSysVar this[object vvarIdxKey]
		{
			get
			{
				if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIdxKey)) == VariantType.String)
				{
					Type typeFromHandle = typeof(Strings);
					object[] obj = new object[1]
					{
					vvarIdxKey
					};
					object[] array = obj;
					bool[] obj2 = new bool[1]
					{
					true
					};
					bool[] array2 = obj2;
					object value = NewLateBinding.LateGet(null, typeFromHandle, "UCase", obj, null, null, obj2);
					if (array2[0])
					{
						vvarIdxKey = RuntimeHelpers.GetObjectValue(array[0]);
					}
					string dstrName = Conversions.ToString(value);
					return (AcadSysVar)mcolClass[dstrName];
				}
				return (AcadSysVar)mcolClass[checked(Conversions.ToInteger(vvarIdxKey) - 1)];
			}
		}

		internal void RaiseEventStartChange(string vstrSysvarName, object vvarNewValue, ref bool rblnCancel)
		{
		}

		internal void RaiseEventEndChange(string vstrSysvarName, object vvarNewValue)
		{
		}

		public AcadSysVars()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 111;
			base.FriendLetNodeImageDisabledID = 112;
			base.FriendLetNodeName = "Systemvariablen";
			base.FriendLetNodeText = "Systemvariablen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mcolClass = new OrderedDictionary();
			mobjDictNames = new Dictionary<object, object>();
		}

		~AcadSysVars()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadSysVars");
				mcolClass = null;
				mobjDictNames = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			//Discarded unreachable code: IL_00a0, IL_00da, IL_00dc, IL_00e3, IL_00e6, IL_00e7, IL_00f4, IL_0116
			int num2 = default(int);
			int num3 = default(int);
			try
			{
				int num = 1;
				IEnumerator enumerator = mcolClass.Values.GetEnumerator();
				AcadSysVar dobjAcadSysVar;
				while (enumerator.MoveNext())
				{
					dobjAcadSysVar = (AcadSysVar)enumerator.Current;
					num = 2;
					string dstrName = Strings.UCase(dobjAcadSysVar.Name);
					ProjectData.ClearProjectError();
					num2 = -2;
					num = 4;
					mcolClass.Remove(dstrName);
					num = 5;
					mobjDictNames.Remove(dstrName);
					ProjectData.ClearProjectError();
					num2 = 0;
					num = 7;
					dobjAcadSysVar.FriendQuit();
					num = 8;
				}
				num = 9;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
				num = 10;
				dobjAcadSysVar = null;
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num3 == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				/*Error near IL_0114: Could not find block for branch target IL_00dc*/
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

		internal void FriendOpen(hwpDxf_Enums.REF_TYPE vnumRefType)
		{
			mnumRefType = vnumRefType;
			string dstrAcadVer = ((hwpDxf_Enums.REF_TYPE.rtApplication & mnumRefType) == hwpDxf_Enums.REF_TYPE.rtApplication) ? Application.AcadVer : (((hwpDxf_Enums.REF_TYPE.rtDrawing & mnumRefType) == hwpDxf_Enums.REF_TYPE.rtDrawing) ? Document.AcadVer : (((hwpDxf_Enums.REF_TYPE.rtViewport & mnumRefType) == hwpDxf_Enums.REF_TYPE.rtViewport) ? Document.AcadVer : (((hwpDxf_Enums.REF_TYPE.rtDimension & mnumRefType) != hwpDxf_Enums.REF_TYPE.rtDimension) ? null : Document.AcadVer)));
			IEnumerator enumerator = default(IEnumerator);
			SysVar dobjSysVar2;
			try
			{
				enumerator = hwpDxf_Vars.pobjSysVars.GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjSysVar2 = (SysVar)enumerator.Current;
					SysVar sysVar = dobjSysVar2;
					hwpDxf_Enums.REF_TYPE dnumRefType = (hwpDxf_Enums.REF_TYPE)sysVar.RefType;
					string dstrDwgStartAcadVer = sysVar.DwgStartAcadVer;
					string dstrDwgEndAcadVer = sysVar.DwgEndAcadVer;
					sysVar = null;
					if ((dnumRefType & mnumRefType) == dnumRefType && ((Operators.CompareString(dstrDwgStartAcadVer, dstrAcadVer, TextCompare: false) <= 0) & (Operators.CompareString(dstrDwgEndAcadVer, dstrAcadVer, TextCompare: false) >= 0)))
					{
						InternAdd(dobjSysVar2);
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
			dobjSysVar2 = null;
		}

		internal object FriendAddXXX(string vstrName)
		{
			SysVar dobjSysVar2 = hwpDxf_Vars.pobjSysVars[Strings.UCase(vstrName)];
			object FriendAddXXX = InternAdd(dobjSysVar2);
			dobjSysVar2 = null;
			return FriendAddXXX;
		}

		internal AcadSysVar FriendGetItem(object vvarIdxKey)
		{
			AcadSysVar FriendGetItem = default(AcadSysVar);
			if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIdxKey)) == VariantType.String)
			{
				object[] array;
				bool[] array2;
				object value = NewLateBinding.LateGet(null, typeof(Strings), "UCase", array = new object[1]
				{
				vvarIdxKey
				}, null, null, array2 = new bool[1]
				{
				true
				});
				if (array2[0])
				{
					vvarIdxKey = RuntimeHelpers.GetObjectValue(array[0]);
				}
				string dstrName = Conversions.ToString(value);
				if (mobjDictNames.ContainsKey(dstrName))
				{
					try
					{
						FriendGetItem = (AcadSysVar)mcolClass[dstrName];
						return FriendGetItem;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex2 = ex3;
						ProjectData.ClearProjectError();
						return FriendGetItem;
					}
				}
				return FriendGetItem;
			}
			try
			{
				FriendGetItem = (AcadSysVar)mcolClass[checked(Conversions.ToInteger(vvarIdxKey) - 1)];
				return FriendGetItem;
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				Exception ex = ex4;
				ProjectData.ClearProjectError();
				return FriendGetItem;
			}
		}

		internal void FriendReset()
		{
			InternClear();
			FriendOpen(mnumRefType);
		}

		public void ResetDefault()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadSysVar dobjAcadSysVar2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadSysVar2 = (AcadSysVar)enumerator.Current;
					dobjAcadSysVar2.ResetDefault();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadSysVar2 = null;
		}

		private AcadSysVar InternAdd(SysVar dobjSysVar)
		{
			AcadSysVar dobjAcadSysVar2 = new AcadSysVar();
			dobjAcadSysVar2.FriendInit(ref dobjSysVar);
			dobjAcadSysVar2.FriendLetNodeParentID = base.NodeID;
			dobjAcadSysVar2.FriendLetApplicationIndex = mlngApplicationIndex;
			dobjAcadSysVar2.FriendLetDocumentIndex = mlngDocumentIndex;
			string dstrName = Strings.UCase(dobjAcadSysVar2.Name);
			mcolClass.Add(dstrName, dobjAcadSysVar2);
			mobjDictNames.Add(dstrName, dstrName);
			AcadSysVar InternAdd = dobjAcadSysVar2;
			dobjAcadSysVar2 = null;
			return InternAdd;
		}
	}
}
