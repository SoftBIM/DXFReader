using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadClass : NodeObject
	{
		private const string cstrClassName = "AcadClass";

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngClassIndex;

		private string mstrDXFName;

		private string mstrApplicationDescription;

		private bool mblnAppWasAvailable;

		private string mstrOriginalClassName;

		private string mstrOriginalDXFName;

		private int mlngProxyFlags;

		private int mlngInstanceCount;

		private hwpDxf_Enums.PROXY_TYPE mnumProxyType;

		internal int FriendLetClassIndex
		{
			set
			{
				mlngClassIndex = value;
			}
		}

		internal int FriendGetClassIndex => mlngClassIndex;

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
			}
		}

		internal string FriendLetApplicationDescription
		{
			set
			{
				mstrApplicationDescription = value;
			}
		}

		internal bool FriendLetAppWasAvailable
		{
			set
			{
				mblnAppWasAvailable = value;
			}
		}

		internal string FriendLetOriginalClassName
		{
			set
			{
				mstrOriginalClassName = value;
				base.FriendLetNodeText = value;
			}
		}

		internal string FriendLetOriginalDXFName
		{
			set
			{
				mstrOriginalDXFName = value;
			}
		}

		internal int FriendLetProxyFlags
		{
			set
			{
				mlngProxyFlags = value;
			}
		}

		internal int FriendLetInstanceCount
		{
			set
			{
				mlngInstanceCount = value;
			}
		}

		internal hwpDxf_Enums.PROXY_TYPE FriendLetProxyType
		{
			set
			{
				mnumProxyType = value;
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

		public string ApplicationDescription => mstrApplicationDescription;

		public bool AppWasAvailable => mblnAppWasAvailable;

		public string OriginalClassName => mstrOriginalClassName;

		public string OriginalDXFName => mstrOriginalDXFName;

		public int ProxyFlags => mlngProxyFlags;

		public int InstanceCount => mlngInstanceCount;

		public int ProxyType => (int)mnumProxyType;

		public bool EraseAllowed => (1 & mlngProxyFlags) == 1;

		public bool TransformAllowed => (2 & mlngProxyFlags) == 2;

		public bool ColorChangeAllowed => (4 & mlngProxyFlags) == 4;

		public bool LayerChangeAllowed => (8 & mlngProxyFlags) == 8;

		public bool LinetypeChangeAllowed => (0x10 & mlngProxyFlags) == 16;

		public bool LinetypeScaleChangeAllowed => (0x20 & mlngProxyFlags) == 32;

		public bool VisibilityChangeAllowed => (0x40 & mlngProxyFlags) == 64;

		public bool CloningAllowed => (0x80 & mlngProxyFlags) == 128;

		public bool LineweightChangeAllowed => (0x100 & mlngProxyFlags) == 256;

		public bool PlotStyleNameChangeAllowed => (0x200 & mlngProxyFlags) == 512;

		public bool R13Format => (0x8000 & mlngProxyFlags) == 32768;

		public string DXFName => mstrDXFName;

		public AcadClass()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 189;
			base.FriendLetNodeImageDisabledID = 190;
			base.FriendLetNodeName = "Klasse";
			base.FriendLetNodeText = "Klasse";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngClassIndex = -1;
			mstrApplicationDescription = hwpDxf_Vars.pstrApplicationDescription;
			mblnAppWasAvailable = hwpDxf_Vars.pblnAppWasAvailable;
			mstrOriginalClassName = hwpDxf_Vars.pstrOriginalClassName;
			mstrOriginalDXFName = hwpDxf_Vars.pstrOriginalDXFName;
			mlngProxyFlags = hwpDxf_Vars.plngProxyFlags;
			mlngInstanceCount = hwpDxf_Vars.plngInstanceCount;
			mnumProxyType = hwpDxf_Vars.pnumProxyType;
			mstrDXFName = "CLASS";
		}

		~AcadClass()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}
	}
}
