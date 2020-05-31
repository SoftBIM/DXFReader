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
    public class AcadTableRecord : AcadObject
	{
		private const string cstrClassName = "AcadTableRecord";

		private bool mblnOpened;

		private string mstrName;

		private int mlngTableIndex;

		private string mstrSuperiorObjectName;

		internal virtual int FriendLetTableIndex
		{
			set
			{
				if (mlngTableIndex == -1)
				{
					mlngTableIndex = value;
				}
			}
		}

		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
			}
		}

		public int TableIndex => mlngTableIndex;

		public string SuperiorObjectName => mstrSuperiorObjectName;

		public AcadTableRecord()
		{
			mblnOpened = true;
			base.FriendLetDXFName = "TABLE_RECORD";
			mstrSuperiorObjectName = "AcDbSymbolTableRecord";
			base.FriendLetObjectName = "AcDbSymbolTableRecord";
			mstrName = hwpDxf_Vars.pstrName;
			mlngTableIndex = -1;
		}

		~AcadTableRecord()
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
