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
	public class AcadPatternDefinitions : NodeObject
	{
		private const string cstrClassName = "AcadPatternDefinitions";

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
				IEnumerator<AcadPatternDefinition> enumerator = default(IEnumerator<AcadPatternDefinition>);
				AcadPatternDefinition dobjAcadPatternDefinition2;
				try
				{
					enumerator = (IEnumerator<AcadPatternDefinition>)mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefinition2 = (AcadPatternDefinition)enumerator.Current;
						dobjAcadPatternDefinition2.FriendLetDatabaseIndex = mlngDatabaseIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefinition2 = null;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPatternDefinition dobjAcadPatternDefinition2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefinition2 = (AcadPatternDefinition)enumerator.Current;
						dobjAcadPatternDefinition2.FriendLetDocumentIndex = mlngDocumentIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefinition2 = null;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadPatternDefinition dobjAcadPatternDefinition2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadPatternDefinition2 = (AcadPatternDefinition)enumerator.Current;
						dobjAcadPatternDefinition2.FriendLetApplicationIndex = mlngApplicationIndex;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadPatternDefinition2 = null;
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

		public AcadPatternDefinitions()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 267;
			base.FriendLetNodeImageDisabledID = 268;
			base.FriendLetNodeName = "Schraffurmuster-Definitionslinien";
			base.FriendLetNodeText = "Schraffurmuster-Definitionslinien";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngIndex = -1;
			mcolClass = new OrderedDictionary();
		}

		~AcadPatternDefinitions()
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
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadPatternDefinitions");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadPatternDefinition dobjAcadPatternDefinition2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadPatternDefinition2 = (AcadPatternDefinition)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadPatternDefinition2.Index));
					dobjAcadPatternDefinition2.FriendQuit();
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
			dobjAcadPatternDefinition2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadPatternDefinition FriendAdd()
		{
			checked
			{
				mlngIndex++;
				AcadPatternDefinition dobjAcadPatternDefinition2 = new AcadPatternDefinition();
				dobjAcadPatternDefinition2.FriendLetNodeParentID = base.NodeID;
				dobjAcadPatternDefinition2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadPatternDefinition2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadPatternDefinition2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				dobjAcadPatternDefinition2.FriendLetIndex = mlngIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), dobjAcadPatternDefinition2);
				AcadPatternDefinition FriendAdd = dobjAcadPatternDefinition2;
				dobjAcadPatternDefinition2 = null;
				return FriendAdd;
			}
		}

		public AcadPatternDefinition Item(int vlngIndex)
		{
			return (AcadPatternDefinition)mcolClass["K" + Conversions.ToString(vlngIndex)];
		}
	}

}
