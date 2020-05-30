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
	public class AcadProxyObject : AcadObject
	{
		private const string cstrClassName = "AcadProxyObject";

		private bool mblnOpened;

		private string mstrApplicationDescription;

		private bool mblnAppWasAvailable;

		private string mstrOriginalClassName;

		private string mstrOriginalDXFName;

		private int mlngProxyFlags;

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

		public string ApplicationDescription => mstrApplicationDescription;

		public bool AppWasAvailable => mblnAppWasAvailable;

		public string OriginalClassName => mstrOriginalClassName;

		public string OriginalDXFName => mstrOriginalDXFName;

		public int ProxyFlags => mlngProxyFlags;

		public bool EraseAllowed => (1 & mlngProxyFlags) == 1;

		public bool CloningAllowed => (0x80 & mlngProxyFlags) == 128;

		public AcadProxyObject()
		{
			mblnOpened = true;
			mstrApplicationDescription = hwpDxf_Vars.pstrApplicationDescription;
			mblnAppWasAvailable = hwpDxf_Vars.pblnAppWasAvailable;
			mstrOriginalClassName = hwpDxf_Vars.pstrOriginalClassName;
			mstrOriginalDXFName = hwpDxf_Vars.pstrOriginalDXFName;
			mlngProxyFlags = hwpDxf_Vars.plngProxyFlags;
			base.FriendLetDXFName = "PROXYOBJECT";
			base.FriendLetObjectName = "AcDbProxyObject";
		}

		~AcadProxyObject()
		{
			FriendQuit();
			base.Finalize();
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
