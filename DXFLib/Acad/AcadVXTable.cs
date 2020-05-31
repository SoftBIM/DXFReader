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
	public class AcadVXTable : AcadObject
	{
		private const string cstrClassName = "AcadVXTable";

		private bool mblnOpened;

		private OrderedDictionary mcolClass;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadVXTableRecord dobjAcadVXTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadVXTableRecord2 = (AcadVXTableRecord)enumerator.Current;
						dobjAcadVXTableRecord2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadVXTableRecord2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadVXTableRecord dobjAcadVXTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadVXTableRecord2 = (AcadVXTableRecord)enumerator.Current;
						dobjAcadVXTableRecord2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadVXTableRecord2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadVXTableRecord dobjAcadVXTableRecord2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadVXTableRecord2 = (AcadVXTableRecord)enumerator.Current;
						dobjAcadVXTableRecord2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadVXTableRecord2 = null;
			}
		}

		public int Count => mcolClass.Count;

		public AcadVXTable()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 102;
			base.FriendLetNodeName = "VX-Liste";
			base.FriendLetNodeText = "VX-Liste";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mcolClass = new OrderedDictionary();
			base.FriendLetDXFName = "VXTABLE";
			base.FriendLetObjectName = "AcDbVXTable";
		}

		internal void FriendInit()
		{
		}

		~AcadVXTable()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadVXTable");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadVXTableRecord dobjAcadVXTableRecord2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadVXTableRecord2 = (AcadVXTableRecord)enumerator.Current;
					mcolClass.Remove(dobjAcadVXTableRecord2.Name);
					dobjAcadVXTableRecord2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadVXTableRecord2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadVXTableRecord FriendGetItem(object vvarIndex)
		{
			AcadVXTableRecord FriendGetItem = default(AcadVXTableRecord);
			try
			{
				if (Information.VarType(RuntimeHelpers.GetObjectValue(vvarIndex)) != VariantType.String)
				{
					FriendGetItem = (AcadVXTableRecord)mcolClass[checked(Conversions.ToInteger(vvarIndex) - 1)];
					return FriendGetItem;
				}
				FriendGetItem = (AcadVXTableRecord)mcolClass[Conversions.ToString(vvarIndex)];
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
			AcadVXTableRecord dobjAcadVXTableRecord4 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			if (dobjAcadVXTableRecord4 != null)
			{
				try
				{
					mcolClass.Remove(dobjAcadVXTableRecord4.Name);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					dobjAcadVXTableRecord4 = null;
					ProjectData.ClearProjectError();
					return;
				}
				dobjAcadVXTableRecord4.FriendQuit();
				dobjAcadVXTableRecord4 = null;
			}
			dobjAcadVXTableRecord4 = null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		internal AcadVXTableRecord FriendAddAcadObject(string vstrName, ref string nrstrErrMsg = "")
		{
			AcadVXTableRecord dobjAcadVXTableRecord4 = new AcadVXTableRecord();
			AcadVXTableRecord acadVXTableRecord = dobjAcadVXTableRecord4;
			acadVXTableRecord.FriendLetName = vstrName;
			acadVXTableRecord.FriendLetNodeParentID = base.NodeID;
			acadVXTableRecord.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadVXTableRecord.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadVXTableRecord.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadVXTableRecord.FriendLetOwnerID = base.ObjectID;
			AcadVXTableRecord acadVXTableRecord2 = acadVXTableRecord;
			double friendGetNextObjectID = base.Database.FriendGetNextObjectID;
			AcadObject nrobjAcadObject = dobjAcadVXTableRecord4;
			bool flag = acadVXTableRecord2.FriendSetObjectID(friendGetNextObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadVXTableRecord4 = (AcadVXTableRecord)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadVXTableRecord.ObjectName + ": " + nrstrErrMsg);
			}
			acadVXTableRecord = null;
			AcadVXTableRecord FriendAddAcadObject = default(AcadVXTableRecord);
			if (dblnValid)
			{
				try
				{
					mcolClass.Add(vstrName, dobjAcadVXTableRecord4);
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					dobjAcadVXTableRecord4.FriendQuit();
					dobjAcadVXTableRecord4 = null;
					Information.Err().Raise(50000, "AcadVXTable", "Element konnte nicht hinzugefügt werden.");
					ProjectData.ClearProjectError();
					return FriendAddAcadObject;
				}
				FriendAddAcadObject = dobjAcadVXTableRecord4;
			}
			dobjAcadVXTableRecord4 = null;
			return FriendAddAcadObject;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadVXTableRecord Item(object vvarIndex)
		{
			AcadVXTableRecord dobjAcadVXTableRecord3 = FriendGetItem(RuntimeHelpers.GetObjectValue(vvarIndex));
			AcadVXTableRecord Item = default(AcadVXTableRecord);
			if (dobjAcadVXTableRecord3 == null)
			{
				dobjAcadVXTableRecord3 = null;
				Information.Err().Raise(50000, "AcadVXTable", "Element existiert nicht.");
			}
			else
			{
				Item = dobjAcadVXTableRecord3;
				dobjAcadVXTableRecord3 = null;
			}
			return Item;
		}
	}

}
