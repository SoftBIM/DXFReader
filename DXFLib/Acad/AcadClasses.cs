using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadClasses : NodeObject
	{
		private const string cstrClassName = "AcadClasses";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngClassIndex;

		private string mstrDXFName;

		private AcadClass mobjAcDbDictionaryWithDefault;

		private AcadClass mobjAcDbPlaceHolder;

		private AcadClass mobjAcDbLayout;

		private OrderedDictionary mcolClass;

		internal int FriendGetDatabaseIndex
		{
			get
			{
				InternCheckOpened("FriendGetDatabaseIndex");
				return mlngDatabaseIndex;
			}
		}

		internal int FriendLetDatabaseIndex
		{
			set
			{
				InternCheckOpened("FriendLetDatabaseIndex");
				mlngDatabaseIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadClass dobjAcadClass2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadClass2 = (AcadClass)enumerator.Current;
						dobjAcadClass2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadClass2 = null;
			}
		}

		internal int FriendGetDocumentIndex
		{
			get
			{
				InternCheckOpened("FriendGetDocumentIndex");
				return mlngDocumentIndex;
			}
		}

		internal int FriendLetDocumentIndex
		{
			set
			{
				InternCheckOpened("FriendLetDocumentIndex");
				mlngDocumentIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadClass dobjAcadClass2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadClass2 = (AcadClass)enumerator.Current;
						dobjAcadClass2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadClass2 = null;
			}
		}

		internal int FriendGetApplicationIndex
		{
			get
			{
				InternCheckOpened("FriendGetApplicationIndex");
				return mlngApplicationIndex;
			}
		}

		internal int FriendLetApplicationIndex
		{
			set
			{
				InternCheckOpened("FriendLetApplicationIndex");
				mlngApplicationIndex = value;
				IEnumerator enumerator = default(IEnumerator);
				AcadClass dobjAcadClass2;
				try
				{
					enumerator = mcolClass.Values.GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadClass2 = (AcadClass)enumerator.Current;
						dobjAcadClass2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadClass2 = null;
			}
		}

		internal int FriendGetClassIndex
		{
			get
			{
				InternCheckOpened("FriendGetClassIndex");
				return mlngClassIndex;
			}
		}

		public AcadDatabase Database
		{
			get
			{
				InternCheckOpened("Database");
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
				InternCheckOpened("Document");
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
				InternCheckOpened("Application");
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public AcadClass AcDbDictionaryWithDefault => FriendAddAcDbDictionaryWithDefault();

		public AcadClass AcDbPlaceHolder => FriendAddAcDbPlaceholder();

		public AcadClass AcDbLayout => FriendAddAcDbLayout();

		public int Count
		{
			get
			{
				InternCheckOpened("Count");
				return mcolClass.Count;
			}
		}

		public string DXFName => mstrDXFName;

		public AcadClasses()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 187;
			base.FriendLetNodeImageDisabledID = 188;
			base.FriendLetNodeName = "Klassen";
			base.FriendLetNodeText = "Klassen";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngClassIndex = -1;
			mcolClass = new OrderedDictionary();
			mstrDXFName = "CLASSES";
		}

		internal void FriendInit()
		{
			FriendAddAcDbDictionaryWithDefault();
			FriendAddAcDbPlaceholder();
			FriendAddAcDbLayout();
		}

		internal AcadClass FriendAddAcDbDictionaryWithDefault()
		{
			if (mobjAcDbDictionaryWithDefault == null)
			{
				mobjAcDbDictionaryWithDefault = FriendGetItemByOriginalClassName("AcDbDictionaryWithDefault");
				if (mobjAcDbDictionaryWithDefault == null)
				{
					mobjAcDbDictionaryWithDefault = FriendAdd("AcDbDictionaryWithDefault");
					AcadClass acadClass = mobjAcDbDictionaryWithDefault;
					acadClass.FriendLetAppWasAvailable = true;
					acadClass.FriendLetApplicationDescription = Document.AcadRelease;
					acadClass.FriendLetOriginalDXFName = "ACDBDICTIONARYWDFLT";
					acadClass = null;
				}
			}
			return mobjAcDbDictionaryWithDefault;
		}

		internal AcadClass FriendAddAcDbPlaceholder()
		{
			if (mobjAcDbPlaceHolder == null)
			{
				mobjAcDbPlaceHolder = FriendGetItemByOriginalClassName("AcDbPlaceholder");
				if (mobjAcDbPlaceHolder == null)
				{
					mobjAcDbPlaceHolder = FriendAdd("AcDbPlaceholder");
					AcadClass acadClass = mobjAcDbPlaceHolder;
					acadClass.FriendLetAppWasAvailable = true;
					acadClass.FriendLetApplicationDescription = Document.AcadRelease;
					acadClass.FriendLetOriginalDXFName = "ACDBPLACEHOLDER";
					acadClass = null;
				}
			}
			return mobjAcDbPlaceHolder;
		}

		internal AcadClass FriendAddAcDbLayout()
		{
			if (mobjAcDbLayout == null)
			{
				mobjAcDbLayout = FriendGetItemByOriginalClassName("AcDbLayout");
				if (mobjAcDbLayout == null)
				{
					mobjAcDbLayout = FriendAdd("AcDbLayout");
					AcadClass acadClass = mobjAcDbLayout;
					acadClass.FriendLetAppWasAvailable = true;
					acadClass.FriendLetApplicationDescription = Document.AcadRelease;
					acadClass.FriendLetOriginalDXFName = "LAYOUT";
					acadClass = null;
				}
			}
			return mobjAcDbLayout;
		}

		~AcadClasses()
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
				mobjAcDbDictionaryWithDefault = null;
				mobjAcDbPlaceHolder = null;
				mobjAcDbLayout = null;
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadClasses");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadClass dobjAcadClass2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadClass2 = (AcadClass)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadClass2.FriendGetClassIndex));
					dobjAcadClass2.FriendQuit();
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			mlngClassIndex = -1;
			dobjAcadClass2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal AcadClass FriendAdd(string vstrOriginalClassName)
		{
			InternCheckOpened("FriendAdd");
			AcadClass dobjAcadClass2 = new AcadClass();
			dobjAcadClass2.FriendLetOriginalClassName = vstrOriginalClassName;
			checked
			{
				mlngClassIndex++;
				dobjAcadClass2.FriendLetClassIndex = mlngClassIndex;
				dobjAcadClass2.FriendLetNodeParentID = base.NodeID;
				dobjAcadClass2.FriendLetApplicationIndex = mlngApplicationIndex;
				dobjAcadClass2.FriendLetDocumentIndex = mlngDocumentIndex;
				dobjAcadClass2.FriendLetDatabaseIndex = mlngDatabaseIndex;
				mcolClass.Add("K" + Conversions.ToString(mlngClassIndex), dobjAcadClass2);
				AcadClass FriendAdd = dobjAcadClass2;
				dobjAcadClass2 = null;
				return FriendAdd;
			}
		}

		internal AcadClass FriendGetItem(int vlngIndex)
		{
			InternCheckOpened("FriendGetItem");
			AcadClass FriendGetItem = default(AcadClass);
			try
			{
				FriendGetItem = (AcadClass)mcolClass["K" + Conversions.ToString(vlngIndex)];
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

		internal AcadClass FriendGetItemByOriginalClassName(string vstrOriginalClassName)
		{
			InternCheckOpened("FriendGetItemByOriginalClassName");
			vstrOriginalClassName = Strings.UCase(vstrOriginalClassName);
			IEnumerator enumerator = default(IEnumerator);
			AcadClass FriendGetItemByOriginalClassName = default(AcadClass);
			AcadClass dobjAcadClass2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadClass2 = (AcadClass)enumerator.Current;
					if (Operators.CompareString(vstrOriginalClassName, Strings.UCase(dobjAcadClass2.OriginalClassName), TextCompare: false) == 0)
					{
						FriendGetItemByOriginalClassName = dobjAcadClass2;
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadClass2 = null;
			return FriendGetItemByOriginalClassName;
		}

		internal void FriendRemove(int vlngIndex)
		{
			InternCheckOpened("FriendRemove");
			AcadClass dobjAcadClass3 = FriendGetItem(vlngIndex);
			if (dobjAcadClass3 != null)
			{
				mcolClass.Remove("K" + Conversions.ToString(vlngIndex));
				dobjAcadClass3.FriendQuit();
				dobjAcadClass3 = null;
			}
			dobjAcadClass3 = null;
		}

		public AcadClass Item(int vintIndex)
		{
			InternCheckOpened("Item");
			return (AcadClass)mcolClass[checked(vintIndex - 1)];
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private void InternCheckOpened(string vstrCommand)
		{
			if (!mblnOpened)
			{
				Information.Err().Raise(50000, "AcadClasses", vstrCommand + ": Der Aufruf ist für ein geschlossenes Objekt nicht erlaubt.");
			}
		}
	}
}
