using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadApplications
	{
		private const string cstrClassName = "AcadApplications";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private OrderedDictionary mcolClass;

		public int Count => mcolClass.Count;

		public AcadApplications()
		{
			mblnOpened = true;
			mcolClass = new OrderedDictionary();
			mlngApplicationIndex = -1;
		}

		~AcadApplications()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadApplications");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator<AcadApplication> enumerator = default(IEnumerator<AcadApplication>);
			AcadApplication dobjAcadApplication2;
			try
			{
				enumerator = (IEnumerator<AcadApplication>)mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadApplication2 = (AcadApplication)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadApplication2.FriendGetApplicationIndex));
					dobjAcadApplication2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngApplicationIndex = -1;
			dobjAcadApplication2 = null;
		}

		internal AcadApplication FriendGetItem(int vlngIndex)
		{
			AcadApplication FriendGetItem = default(AcadApplication);
			try
			{
				FriendGetItem = (AcadApplication)mcolClass["K" + Conversions.ToString(vlngIndex)];
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

		public int Add(ref AcadApplication robjAcadApplication)
		{
			checked
			{
				mlngApplicationIndex++;
				mcolClass.Add("K" + Conversions.ToString(mlngApplicationIndex), robjAcadApplication);
				return mlngApplicationIndex;
			}
		}

		public AcadApplication Item(int vlngIndex)
		{
			return (AcadApplication)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}

		public void Remove(int vlngIndex)
		{
			//Discarded unreachable code: IL_0033, IL_0051, IL_0053, IL_005a, IL_005d, IL_005e, IL_006b, IL_008d
			int num = default(int);
			int num3 = default(int);
			try
			{
				ProjectData.ClearProjectError();
				num = -2;
				int num2 = 2;
				mcolClass.Remove("K" + Conversions.ToString(vlngIndex));
				ProjectData.ClearProjectError();
				num = 0;
			}
			catch (Exception obj) when (obj is Exception && num != 0 && num3 == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				/*Error near IL_008b: Could not find block for branch target IL_0053*/
				;
			}
			if (num3 != 0)
			{
				ProjectData.ClearProjectError();
			}
		}

		public ICollection<AcadApplication> GetValues()
		{
			return (ICollection<AcadApplication>)mcolClass.Values;
		}
	}
}
