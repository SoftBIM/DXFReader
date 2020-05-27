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
	public class AcadFontTable : AcadObject
	{
		private const string cstrClassName = "AcadFontTable";

		private bool mblnOpened;

		private OrderedDictionary mcolClass;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadFontTableRecord dobjAcadFontTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadFontTableRecord2 = (AcadFontTableRecord)enumerator.Current;
						dobjAcadFontTableRecord2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadFontTableRecord2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadFontTableRecord dobjAcadFontTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadFontTableRecord2 = (AcadFontTableRecord)enumerator.Current;
						dobjAcadFontTableRecord2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadFontTableRecord2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadFontTableRecord dobjAcadFontTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadFontTableRecord2 = (AcadFontTableRecord)enumerator.Current;
						dobjAcadFontTableRecord2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadFontTableRecord2 = null;
			}
		}

		public int Count => mcolClass.Count;

		public AcadFontTable()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 201;
			base.FriendLetNodeImageDisabledID = 202;
			base.FriendLetNodeName = "Schriftdateien";
			base.FriendLetNodeText = "Schriftdateien";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mcolClass = new OrderedDictionary();
			base.FriendLetDXFName = "FONTTABLE";
			base.FriendLetObjectName = "AcDbFontTable";
		}

		internal void FriendInit()
		{
		}

		~AcadFontTable()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadFontTable");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadFontTableRecord dobjAcadFontTableRecord2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadFontTableRecord2 = (AcadFontTableRecord)enumerator.Current;
					mcolClass.Remove(dobjAcadFontTableRecord2.Name);
					dobjAcadFontTableRecord2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadFontTableRecord2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadFontTableRecord FriendGetItem(object vvarIndex)
		{
			AcadFontTableRecord FriendGetItem = default(AcadFontTableRecord);
			try
			{
				if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) != VariantType.String)
				{
					FriendGetItem = (AcadFontTableRecord)mcolClass[checked(Conversions.ToInteger(vvarIndex) - 1)];
					return FriendGetItem;
				}
				FriendGetItem = (AcadFontTableRecord)mcolClass[Conversions.ToString(vvarIndex)];
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

		internal void FriendRemove(object vvarIndex)
		{
			AcadFontTableRecord dobjAcadFontTableRecord4 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			if (dobjAcadFontTableRecord4 != null)
			{
				try
				{
					mcolClass.Remove(dobjAcadFontTableRecord4.Name);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					dobjAcadFontTableRecord4 = null;
					ProjectData.ClearProjectError();
					return;
				}
				dobjAcadFontTableRecord4.FriendQuit();
				dobjAcadFontTableRecord4 = null;
			}
			dobjAcadFontTableRecord4 = null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		internal AcadFontTableRecord FriendAddAcadObject(string vstrName, ref string nrstrErrMsg = "")
		{
			AcadFontTableRecord dobjAcadFontTableRecord4 = new AcadFontTableRecord();
			AcadFontTableRecord acadFontTableRecord = dobjAcadFontTableRecord4;
			acadFontTableRecord.FriendLetName = vstrName;
			acadFontTableRecord.FriendLetNodeParentID = base.NodeID;
			acadFontTableRecord.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadFontTableRecord.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadFontTableRecord.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadFontTableRecord.FriendLetOwnerID = base.ObjectID;
			AcadFontTableRecord acadFontTableRecord2 = acadFontTableRecord;
			double friendGetNextObjectID = base.Database.FriendGetNextObjectID;
			AcadObject nrobjAcadObject = dobjAcadFontTableRecord4;
			bool flag = acadFontTableRecord2.FriendSetObjectID(friendGetNextObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadFontTableRecord4 = (AcadFontTableRecord)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadFontTableRecord.ObjectName + ": " + nrstrErrMsg);
			}
			acadFontTableRecord = null;
			AcadFontTableRecord FriendAddAcadObject = default(AcadFontTableRecord);
			if (dblnValid)
			{
				try
				{
					mcolClass.Add(vstrName, dobjAcadFontTableRecord4);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					dobjAcadFontTableRecord4.FriendQuit();
					dobjAcadFontTableRecord4 = null;
					Information.Err().Raise(50000, "AcadFontTable", "Element konnte nicht hinzugefügt werden.");
					ProjectData.ClearProjectError();
					return FriendAddAcadObject;
				}
				FriendAddAcadObject = dobjAcadFontTableRecord4;
			}
			dobjAcadFontTableRecord4 = null;
			return FriendAddAcadObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadFontTableRecord Item(object vvarIndex)
		{
			AcadFontTableRecord dobjAcadFontTableRecord3 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadFontTableRecord Item = default(AcadFontTableRecord);
			if (dobjAcadFontTableRecord3 == null)
			{
				dobjAcadFontTableRecord3 = null;
				Information.Err().Raise(50000, "AcadFontTable", "Element existiert nicht.");
			}
			else
			{
				Item = dobjAcadFontTableRecord3;
				dobjAcadFontTableRecord3 = null;
			}
			return Item;
		}
	}
}
