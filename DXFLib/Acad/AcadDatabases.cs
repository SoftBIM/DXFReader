using System;
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
	public class AcadDatabases
	{
		private const string cstrClassName = "AcadDatabases";

		private bool mblnOpened;

		private int mlngDatabaseIndex;

		private OrderedDictionary mcolClass;

		public int Count
		{
			get
			{
				InternCheckOpened("Count");
				return mcolClass.Count;
			}
		}

		public bool Opened => mblnOpened;

		public AcadDatabases()
		{
			mblnOpened = true;
			mcolClass = new OrderedDictionary();
			mlngDatabaseIndex = -1;
		}

		~AcadDatabases()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadDatabases");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadDatabase dobjAcadDatabase2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadDatabase2 = (AcadDatabase)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadDatabase2.FriendGetDatabaseIndex));
					dobjAcadDatabase2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngDatabaseIndex = -1;
			dobjAcadDatabase2 = null;
		}

		internal AcadDatabase FriendGetItem(int vlngIndex)
		{
			AcadDatabase FriendGetItem = default(AcadDatabase);
			try
			{
				FriendGetItem = (AcadDatabase)mcolClass["K" + Conversions.ToString(vlngIndex)];
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

		public int Add(ref AcadDatabase robjAcadDatabase)
		{
			InternCheckOpened("Add");
			checked
			{
				mlngDatabaseIndex++;
				mcolClass.Add("K" + Conversions.ToString(mlngDatabaseIndex), robjAcadDatabase);
				return mlngDatabaseIndex;
			}
		}

		public AcadDatabase Item(int vlngIndex)
		{
			InternCheckOpened("Item");
			return (AcadDatabase)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}

		public void Remove(int vlngIndex)
		{
			InternCheckOpened("Remove");
			mcolClass.Remove("K" + Conversions.ToString(vlngIndex));
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void InternCheckOpened(string vstrCommand)
		{
			if (!mblnOpened)
			{
				Information.Err().Raise(50000, "AcadDatabases", vstrCommand + ": Der Aufruf ist für ein geschlossenes Objekt nicht erlaubt.");
			}
		}
	}
}
