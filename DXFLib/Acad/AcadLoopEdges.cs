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
	public class AcadLoopEdges : NodeObject
	{
		private const string cstrClassName = "AcadLoopEdges";

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
				IEnumerator<AcadLoopEdge> enumerator = default(IEnumerator<AcadLoopEdge>);
				AcadLoopEdge dobjAcadLoopEdge2;
				try
				{
					enumerator = (IEnumerator<AcadLoopEdge>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoopEdge2 = (AcadLoopEdge)enumerator.Current;
						dobjAcadLoopEdge2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoopEdge2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLoopEdge dobjAcadLoopEdge2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoopEdge2 = (AcadLoopEdge)enumerator.Current;
						dobjAcadLoopEdge2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoopEdge2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadLoopEdge dobjAcadLoopEdge2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadLoopEdge2 = (AcadLoopEdge)enumerator.Current;
						dobjAcadLoopEdge2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadLoopEdge2 = null;
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

		public AcadLoopEdges()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 283;
			base.FriendLetNodeImageDisabledID = 284;
			base.FriendLetNodeName = "Schraffurkontur-Kanten";
			base.FriendLetNodeText = "Schraffurkontur-Kanten";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadLoopEdges()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadLoopEdges");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadLoopEdge dobjAcadLoopEdge2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadLoopEdge2 = (AcadLoopEdge)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadLoopEdge2.Index));
					dobjAcadLoopEdge2.FriendQuit();
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
			dobjAcadLoopEdge2 = null;
		}

		public ICollection<AcadLoopEdge> GetValues()
		{
			return (ICollection<AcadLoopEdge>)mcolClass.Values;
		}

		internal AcadLoopEdge FriendAdd()
		{
			checked
			{
				mlngIndex++;
				AcadLoopEdge dobjAcadLoopEdge2 = new AcadLoopEdge();
				dobjAcadLoopEdge2.FriendLetNodeParentID = base.NodeID;
				dobjAcadLoopEdge2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadLoopEdge2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadLoopEdge2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				dobjAcadLoopEdge2.FriendLetIndex = mlngIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadLoopEdge2);
				AcadLoopEdge FriendAdd = dobjAcadLoopEdge2;
				dobjAcadLoopEdge2 = null;
				return FriendAdd;
			}
		}

		public AcadLoopEdge Item(int vlngIndex)
		{
			return (AcadLoopEdge)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}
}
