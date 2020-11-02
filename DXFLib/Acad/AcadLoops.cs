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
	public class AcadLoops : NodeObject
	{
		private const string cstrClassName = "AcadLoops";

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
				IEnumerator<AcadLoop> enumerator = default(IEnumerator<AcadLoop>);
				AcadLoop dobjAcadLoop2;
				try
				{
					enumerator = (IEnumerator<AcadLoop>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoop2 = (AcadLoop)enumerator.Current;
						dobjAcadLoop2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoop2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLoop dobjAcadLoop2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoop2 = (AcadLoop)enumerator.Current;
						dobjAcadLoop2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoop2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLoop dobjAcadLoop2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoop2 = (AcadLoop)enumerator.Current;
						dobjAcadLoop2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoop2 = null;
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

		public AcadLoops()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 275;
			base.FriendLetNodeImageDisabledID = 276;
			base.FriendLetNodeName = "Schraffurkonturen";
			base.FriendLetNodeText = "Schraffurkonturen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadLoops()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadLoops");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadLoop dobjAcadLoop2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadLoop2 = (AcadLoop)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadLoop2.Index));
					dobjAcadLoop2.FriendQuit();
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
			dobjAcadLoop2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadLoop FriendAdd()
		{
			checked
			{
				mlngIndex++;
				AcadLoop dobjAcadLoop2 = new AcadLoop();
				dobjAcadLoop2.FriendLetNodeParentID = base.NodeID;
				dobjAcadLoop2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadLoop2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadLoop2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				dobjAcadLoop2.FriendLetIndex = mlngIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadLoop2);
				AcadLoop FriendAdd = dobjAcadLoop2;
				dobjAcadLoop2 = null;
				return FriendAdd;
			}
		}

		public AcadLoop Item(int vlngIndex)
		{
			return (AcadLoop)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}
}
