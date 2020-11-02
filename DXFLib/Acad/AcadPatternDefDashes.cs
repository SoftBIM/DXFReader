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
	public class AcadPatternDefDashes : NodeObject
	{
		private const string cstrClassName = "AcadPatternDefDashes";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngIndex;

		private OrderedDictionary mcolClass;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
				IEnumerator<AcadPatternDefDash> enumerator = default(IEnumerator<AcadPatternDefDash>);
				AcadPatternDefDash dobjAcadPatternDefDash2;
				try
				{
					enumerator = (IEnumerator<AcadPatternDefDash>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefDash2 = (AcadPatternDefDash)enumerator.Current;
						dobjAcadPatternDefDash2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefDash2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPatternDefDash dobjAcadPatternDefDash2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefDash2 = (AcadPatternDefDash)enumerator.Current;
						dobjAcadPatternDefDash2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefDash2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPatternDefDash dobjAcadPatternDefDash2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefDash2 = (AcadPatternDefDash)enumerator.Current;
						dobjAcadPatternDefDash2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefDash2 = null;
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

		public AcadPatternDefDashes()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 271;
			base.FriendLetNodeImageDisabledID = 272;
			base.FriendLetNodeName = "Schraffurmuster-Strichlängen";
			base.FriendLetNodeText = "Schraffurmuster-Strichlängen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadPatternDefDashes()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadPatternDefDashes");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadPatternDefDash dobjAcadPatternDefDash2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadPatternDefDash2 = (AcadPatternDefDash)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadPatternDefDash2.Index));
					dobjAcadPatternDefDash2.FriendQuit();
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
			dobjAcadPatternDefDash2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadPatternDefDash FriendAdd()
		{
			checked
			{
				mlngIndex++;
				AcadPatternDefDash dobjAcadPatternDefDash2 = new AcadPatternDefDash();
				dobjAcadPatternDefDash2.FriendLetNodeParentID = base.NodeID;
				dobjAcadPatternDefDash2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadPatternDefDash2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadPatternDefDash2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				dobjAcadPatternDefDash2.FriendLetIndex = mlngIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadPatternDefDash2);
				AcadPatternDefDash FriendAdd = dobjAcadPatternDefDash2;
				dobjAcadPatternDefDash2 = null;
				return FriendAdd;
			}
		}

		public AcadPatternDefDash Item(int vlngIndex)
		{
			return (AcadPatternDefDash)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}

}
