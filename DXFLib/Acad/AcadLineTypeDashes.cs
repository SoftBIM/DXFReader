using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Collections.Specialized;

namespace DXFLib.Acad
{
	public class AcadLineTypeDashes : NodeObject
	{
		private const string cstrClassName = "AcadLineTypeDashes";

		private const int clngMaxEntries = 12;

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngTableIndex;

		private int mlngIndex;

		private object mdecPatternLength;

		private double mdblPatternLength;

		private OrderedDictionary mcolClass;

		internal int FriendGetTableIndex => mlngTableIndex;

		internal int FriendLetTableIndex
		{
			set
			{
				mlngTableIndex = value;
				IEnumerator<AcadLineTypeDash> enumerator = default(IEnumerator<AcadLineTypeDash>);
				AcadLineTypeDash dobjAcadLineTypeDash2;
				try
				{
					enumerator = (IEnumerator<AcadLineTypeDash>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
						dobjAcadLineTypeDash2.FriendLetTableIndex = mlngTableIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLineTypeDash2 = null;
			}
		}

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineTypeDash dobjAcadLineTypeDash2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
						dobjAcadLineTypeDash2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLineTypeDash2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineTypeDash dobjAcadLineTypeDash2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
						dobjAcadLineTypeDash2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLineTypeDash2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLineTypeDash dobjAcadLineTypeDash2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
						dobjAcadLineTypeDash2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLineTypeDash2 = null;
			}
		}

		public AcadLineType Linetype
		{
			get
			{
				if (mlngDatabaseIndex > -1 && mlngTableIndex > -1)
				{
					return (AcadLineType)hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex).Linetypes.Item(mlngTableIndex);
				}
				AcadLineType Linetype = default(AcadLineType);
				return Linetype;
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

		public int Count => mcolClass.Count;

		public AcadLineTypeDashes()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 151;
			base.FriendLetNodeImageDisabledID = 152;
			base.FriendLetNodeName = "Linientypelemente";
			base.FriendLetNodeText = "Linientypelemente";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblPatternLength = hwpDxf_Vars.pdblPatternLength;
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngTableIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadLineTypeDashes()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadLineTypeDashes");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadLineTypeDash dobjAcadLineTypeDash2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadLineTypeDash2 = (AcadLineTypeDash)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadLineTypeDash2.Index));
					dobjAcadLineTypeDash2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngIndex = -1;
			dobjAcadLineTypeDash2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadLineTypeDash FriendAdd(ref string nrstrErrMsg = "")
		{
			nrstrErrMsg = null;
			checked
			{
				AcadLineTypeDash FriendAdd = default(AcadLineTypeDash);
				if (mlngIndex + 1 == 12)
				{
					AcadLineTypeDash dobjAcadLineTypeDash3 = null;
					nrstrErrMsg = "Die maximal Anzahl von " + Conversions.ToString(12) + " Linientypelementen wird überschritten.";
				}
				else
				{
					mlngIndex++;
					AcadLineTypeDash dobjAcadLineTypeDash3 = new AcadLineTypeDash();
					dobjAcadLineTypeDash3.FriendLetNodeParentID = base.NodeID;
					dobjAcadLineTypeDash3.FriendLetApplicationIndex = mlngApplicationIndex;
					dobjAcadLineTypeDash3.FriendLetDocumentIndex = mlngDocumentIndex;
					dobjAcadLineTypeDash3.FriendLetDatabaseIndex = mlngDatabaseIndex;
					dobjAcadLineTypeDash3.FriendLetTableIndex = mlngTableIndex;
					dobjAcadLineTypeDash3.FriendLetIndex = mlngIndex;
					mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadLineTypeDash3);
					FriendAdd = dobjAcadLineTypeDash3;
					dobjAcadLineTypeDash3 = null;
				}
				return FriendAdd;
			}
		}

		internal void FriendChangePatternLength(object vvarOldLength, object vvarNewLength)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(vvarOldLength);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg);
			object objectValue2 = RuntimeHelpers.GetObjectValue(vvarNewLength);
			nrstrErrMsg = "";
			if (num & hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue2, ref nrstrErrMsg))
			{
				bool flag = false;
				mdblPatternLength = Conversions.ToDouble(Operators.AddObject(Operators.SubtractObject(mdblPatternLength, vvarOldLength), vvarNewLength));
			}
		}

		public AcadLineTypeDash Item(int vlngIndex)
		{
			return (AcadLineTypeDash)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}

}
