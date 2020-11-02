using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Collections.Specialized;

namespace DXFLib.Acad
{
	class AcadGroup : AcadObject
	{
		private const string cstrClassName = "AcadGroup";

		private const int clngIsAnonymous = 1;

		private const int clngIsSelectable = 1;

		private bool mblnOpened;

		private string mstrName;

		private string mstrDescription;

		private bool mblnIsAnonymous;

		private bool mblnIsSelectable;

		private int mlngFlags70;

		private int mlngFlags71;

		private bool mblnFriendLetFlags;

		private OrderedDictionary mcolClass;

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				IsAnonymous = ((1 & mlngFlags70) == 1);
				mblnFriendLetFlags = false;
			}
		}

		internal int FriendLetFlags71
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags71 = value;
				IsSelectable = ((1 & mlngFlags71) == 1);
				mblnFriendLetFlags = false;
			}
		}

		internal string FriendGetObjectIDsString
		{
			get
			{
				IEnumerator enumerator = default(IEnumerator);
				string dstrObjectIDs = default(string);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dstrObjectIDs = dstrObjectIDs + ", " + Conversions.ToString(dobjAcadEntity2.ObjectID);
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				if (Operators.CompareString(dstrObjectIDs, null, TextCompare: false) != 0)
				{
					dstrObjectIDs = Strings.Mid(dstrObjectIDs, 3);
				}
				string FriendGetObjectIDsString = dstrObjectIDs;
				dobjAcadEntity2 = null;
				return FriendGetObjectIDsString;
			}
		}

		public Enums.AcColor Color
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.Color = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public string Layer
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.Layer = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public string Linetype
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.Linetype = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public object LinetypeScale
		{
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				AcadEntity dobjAcadEntity2;
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadGroup", dstrErrMsg);
				}
				else
				{
					IEnumerator enumerator = default(IEnumerator);
					try
					{
						enumerator = GetValues().GetEnumerator();
						while (enumerator.MoveNext())
						{
							dobjAcadEntity2 = (AcadEntity)enumerator.Current;
							dobjAcadEntity2.LinetypeScale = RuntimeHelpers.GetObjectValue(value);
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public Enums.AcLineWeight Lineweight
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.Lineweight = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public string PlotStyleName
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.PlotStyleName = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public bool Visible
		{
			set
			{
				IEnumerator enumerator = default(IEnumerator);
				AcadEntity dobjAcadEntity2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadEntity2 = (AcadEntity)enumerator.Current;
						dobjAcadEntity2.Visible = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadEntity2 = null;
			}
		}

		public int Count => mcolClass.Count;

		public string Name
		{
			get
			{
				return Strings.UCase(mstrName);
			}
			set
			{
				mstrName = value;
				base.FriendLetNodeText = mstrName;
			}
		}

		public string Description
		{
			get
			{
				return mstrDescription;
			}
			set
			{
				mstrDescription = value;
			}
		}

		public bool IsAnonymous
		{
			get
			{
				return mblnIsAnonymous;
			}
			set
			{
				mblnIsAnonymous = value;
				InternCalcFlags70();
			}
		}

		public bool IsSelectable
		{
			get
			{
				return mblnIsSelectable;
			}
			set
			{
				mblnIsSelectable = value;
				InternCalcFlags71();
			}
		}

		public int Flags70 => mlngFlags70;

		public int Flags71 => mlngFlags71;

		public AcadGroup()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 211;
			base.FriendLetNodeImageDisabledID = 212;
			base.FriendLetNodeName = "Gruppe";
			base.FriendLetNodeText = "Gruppe";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			mstrDescription = hwpDxf_Vars.pstrDescription;
			mblnIsAnonymous = hwpDxf_Vars.pblnIsAnonymous;
			mblnIsSelectable = hwpDxf_Vars.pblnIsSelectable;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcFlags71();
			mcolClass = new OrderedDictionary();
			base.FriendLetDXFName = "GROUP";
			base.FriendLetObjectName = "AcDbGroup";
		}

		~AcadGroup()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadGroup");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadEntity dobjAcadEntity2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadEntity2 = (AcadEntity)enumerator.Current;
					FriendRemoveItem(dobjAcadEntity2.Handle);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadEntity2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadEntity FriendGetItem(object vvarIndex)
		{
			AcadEntity FriendGetItem = default(AcadEntity);
			try
			{
				if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) != VariantType.String)
				{
					FriendGetItem = (AcadEntity)mcolClass[checked(Conversions.ToInteger(vvarIndex) - 1)];
					return FriendGetItem;
				}
				FriendGetItem = (AcadEntity)mcolClass[Conversions.ToString(vvarIndex)];
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

		internal AcadEntity FriendAddItem(AcadEntity vobjAcadEntity)
		{
			try
			{
				mcolClass.Add(vobjAcadEntity.Handle, vobjAcadEntity);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				AcadEntity FriendAddItem = null;
				ProjectData.ClearProjectError();
				return FriendAddItem;
			}
			hwpDxf_AcadEntity.BkAcadEntity_AddReactorsID(ref vobjAcadEntity, base.ObjectID, 330);
			return vobjAcadEntity;
		}

		internal AcadEntity FriendRemoveItem(object vvarIndex)
		{
			AcadEntity dobjAcadEntity2 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadEntity FriendRemoveItem;
			if (dobjAcadEntity2 == null)
			{
				FriendRemoveItem = null;
			}
			else
			{
				hwpDxf_AcadEntity.BkAcadEntity_RemoveReactorsID(ref dobjAcadEntity2, base.ObjectID);
				mcolClass.Remove(RuntimeHelpers.GetObjectValue(vvarIndex));
				FriendRemoveItem = dobjAcadEntity2;
			}
			dobjAcadEntity2 = null;
			return FriendRemoveItem;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadEntity Item(object vvarIndex)
		{
			AcadEntity dobjAcadEntity3 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadEntity Item;
			if (dobjAcadEntity3 == null)
			{
				dobjAcadEntity3 = null;
				Item = null;
				Information.Err().Raise(50000, "AcadGroup", "Element existiert nicht.");
			}
			else
			{
				Item = dobjAcadEntity3;
				dobjAcadEntity3 = null;
			}
			return Item;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void AppendItems(object vvarObjects)
		{
			int num = Information.LBound((Array)vvarObjects);
			int num2 = Information.UBound((Array)vvarObjects);
			AcadEntity dobjAcadEntity2;
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				dobjAcadEntity2 = (AcadEntity)NewLateBinding.LateIndexGet(vvarObjects, new object[1]
				{
				dlngIdx
				}, null);
				dobjAcadEntity2 = FriendAddItem(dobjAcadEntity2);
				if (dobjAcadEntity2 == null)
				{
					Information.Err().Raise(50000, "AcadGroup", "Element konnte nicht hinzugefügt werden.");
					return;
				}
			}
			dobjAcadEntity2 = null;
		}

		public void Highlight(bool vblnHighlightFlag)
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadEntity dobjAcadEntity2;
			try
			{
				enumerator = GetValues().GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadEntity2 = (AcadEntity)enumerator.Current;
					dobjAcadEntity2.Highlight(vblnHighlightFlag);
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadEntity2 = null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void RemoveItems(object vvarObjects)
		{
			int num = Information.LBound((Array)vvarObjects);
			int num2 = Information.UBound((Array)vvarObjects);
			AcadEntity dobjAcadEntity2;
			for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
			{
				dobjAcadEntity2 = (AcadEntity)NewLateBinding.LateIndexGet(vvarObjects, new object[1]
				{
				dlngIdx
				}, null);
				dobjAcadEntity2 = FriendRemoveItem(dobjAcadEntity2.Handle);
				if (dobjAcadEntity2 == null)
				{
					Information.Err().Raise(50000, "AcadGroup", "Element existiert nicht.");
					return;
				}
			}
			dobjAcadEntity2 = null;
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsAnonymous, 1, 0)));
			}
		}

		private void InternCalcFlags71()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags71 = 0;
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(IsSelectable, 1, 0)));
			}
		}
	}
}
