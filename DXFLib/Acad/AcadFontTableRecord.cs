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
	public class AcadFontTableRecord : AcadObject
	{
		private const string cstrClassName = "AcadFontTableRecord";

		private bool mblnOpened;

		private string mstrName;

		internal string FriendLetName
		{
			set
			{
				mstrName = value;
			}
		}

		public string Name => mstrName;

		public AcadFontTableRecord()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 203;
			base.FriendLetNodeImageDisabledID = 204;
			base.FriendLetNodeName = "Schriftdatei";
			base.FriendLetNodeText = "Schriftdatei";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			base.FriendLetDXFName = "FONTTABLERECORD";
			base.FriendLetObjectName = "AcDbFontTableRecord";
		}

		~AcadFontTableRecord()
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
