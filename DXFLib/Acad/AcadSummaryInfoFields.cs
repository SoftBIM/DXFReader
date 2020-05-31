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
	public class AcadSummaryInfoFields : NodeObject
	{
		private const string cstrClassName = "AcadSummaryInfoFields";

		private bool mblnOpened;

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
				AcadSummaryInfoField dobjAcadSummaryInfoField2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)enumerator.Current;
						dobjAcadSummaryInfoField2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadSummaryInfoField2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadSummaryInfoField dobjAcadSummaryInfoField2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)enumerator.Current;
						dobjAcadSummaryInfoField2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadSummaryInfoField2 = null;
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

		public AcadSummaryInfoFields()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 295;
			base.FriendLetNodeImageDisabledID = 296;
			base.FriendLetNodeName = "Datei-Infofelder";
			base.FriendLetNodeText = "Datei-Infofelder";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mcolClass = new OrderedDictionary();
			mobjDictNames = new Dictionary<object, object>();
		}

		~AcadSummaryInfoFields()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendReset()
		{
			InternClear();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				base.FriendQuit();
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadSummaryInfoFields");
				mcolClass = null;
				mobjDictNames = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadSummaryInfoField dobjAcadSummaryInfoField3;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadSummaryInfoField3 = (AcadSummaryInfoField)enumerator.Current;
					string dstrUKey = Strings.UCase(dobjAcadSummaryInfoField3.Key);
					mcolClass.Remove(dstrUKey);
					mobjDictNames.Remove(dstrUKey);
					dobjAcadSummaryInfoField3.FriendQuit();
					dobjAcadSummaryInfoField3 = null;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mcolClass = null;
			mobjDictNames = null;
			mcolClass = new OrderedDictionary();
			mobjDictNames = new Dictionary<object, object>();
			dobjAcadSummaryInfoField3 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		public AcadSummaryInfoField Add(string vstrKey, string vstrValue)
		{
			vstrKey = Strings.Trim(vstrKey);
			string dstrUKey = Strings.UCase(vstrKey);
			AcadSummaryInfoField Add = default(AcadSummaryInfoField);
			AcadSummaryInfoField dobjAcadSummaryInfoField2;
			if (Operators.CompareString(vstrKey, null, TextCompare: false) != 0 && !mobjDictNames.ContainsKey(dstrUKey))
			{
				dobjAcadSummaryInfoField2 = new AcadSummaryInfoField();
				dobjAcadSummaryInfoField2.FriendLetNodeParentID = base.NodeID;
				dobjAcadSummaryInfoField2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadSummaryInfoField2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadSummaryInfoField2.FriendLetIndex = mcolClass.Count;
				dobjAcadSummaryInfoField2.FriendLetKey = vstrKey;
				dobjAcadSummaryInfoField2.Value = vstrValue;
				mcolClass.Add(dstrUKey, dobjAcadSummaryInfoField2);
				mobjDictNames.Add(dstrUKey, dobjAcadSummaryInfoField2.Index);
				Add = dobjAcadSummaryInfoField2;
			}
			dobjAcadSummaryInfoField2 = null;
			return Add;
		}

		public void GetByIndex(int vintIndex, ref string rstrKey, ref string rstrValue)
		{
			rstrKey = null;
			rstrValue = null;
			AcadSummaryInfoField dobjAcadSummaryInfoField2;
			if ((vintIndex >= 0) & (vintIndex < mcolClass.Count))
			{
				dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)mcolClass[checked(vintIndex - 1)];
				rstrKey = dobjAcadSummaryInfoField2.Key;
				rstrValue = dobjAcadSummaryInfoField2.Value;
			}
			dobjAcadSummaryInfoField2 = null;
		}

		public void GetByKey(string vstrKey, ref string rstrValue)
		{
			rstrValue = null;
			vstrKey = Strings.Trim(vstrKey);
			string dstrUKey = Strings.UCase(vstrKey);
			AcadSummaryInfoField dobjAcadSummaryInfoField2;
			if (!mobjDictNames.ContainsKey(dstrUKey))
			{
				dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)mcolClass[dstrUKey];
				rstrValue = dobjAcadSummaryInfoField2.Value;
			}
			dobjAcadSummaryInfoField2 = null;
		}

		public void RemoveByIndex(int vintIndex)
		{
			AcadSummaryInfoField dobjAcadSummaryInfoField3;
			if ((vintIndex >= 0) & (vintIndex < mcolClass.Count))
			{
				dobjAcadSummaryInfoField3 = (AcadSummaryInfoField)mcolClass[checked(vintIndex - 1)];
				string dstrKey = dobjAcadSummaryInfoField3.Key;
				dobjAcadSummaryInfoField3 = null;
				RemoveByKey(dstrKey);
			}
			dobjAcadSummaryInfoField3 = null;
		}

		public void RemoveByKey(string vstrKey)
		{
			vstrKey = Strings.Trim(vstrKey);
			string dstrUKey = Strings.UCase(vstrKey);
			AcadSummaryInfoField dobjAcadSummaryInfoField4;
			if (!mobjDictNames.ContainsKey(dstrUKey))
			{
				dobjAcadSummaryInfoField4 = (AcadSummaryInfoField)mcolClass[dstrUKey];
				mcolClass.Remove(dstrUKey);
				mobjDictNames.Remove(dstrUKey);
				dobjAcadSummaryInfoField4.FriendQuit();
				dobjAcadSummaryInfoField4 = null;
				int dlngIndex = 0;
				IEnumerator enumerator = default(IEnumerator);
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadSummaryInfoField4 = (AcadSummaryInfoField)enumerator.Current;
						dobjAcadSummaryInfoField4.FriendLetIndex = dlngIndex;
						dlngIndex = checked(dlngIndex + 1);
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
			dobjAcadSummaryInfoField4 = null;
		}

		public void SetByIndex(int vintIndex, ref string rstrKey, string vstrValue)
		{
			rstrKey = null;
			AcadSummaryInfoField dobjAcadSummaryInfoField2;
			if ((vintIndex >= 0) & (vintIndex < mcolClass.Count))
			{
				dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)mcolClass[checked(vintIndex - 1)];
				rstrKey = dobjAcadSummaryInfoField2.Key;
				dobjAcadSummaryInfoField2.Value = vstrValue;
			}
			dobjAcadSummaryInfoField2 = null;
		}

		public void SetByKey(string vstrKey, string vstrValue)
		{
			vstrKey = Strings.Trim(vstrKey);
			string dstrUKey = Strings.UCase(vstrKey);
			AcadSummaryInfoField dobjAcadSummaryInfoField2;
			if (!mobjDictNames.ContainsKey(dstrUKey))
			{
				dobjAcadSummaryInfoField2 = (AcadSummaryInfoField)mcolClass[dstrUKey];
				dobjAcadSummaryInfoField2.Value = vstrValue;
			}
			dobjAcadSummaryInfoField2 = null;
		}

		public bool ExistsByKey(string vstrKey)
		{
			return mobjDictNames.ContainsKey(Strings.UCase(Strings.Trim(vstrKey)));
		}

		public bool ExistsByIndex(int vlngIndex)
		{
			return (vlngIndex >= 0) & (vlngIndex < mcolClass.Count);
		}
	}

}
