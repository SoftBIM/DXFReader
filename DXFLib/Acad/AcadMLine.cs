using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadMLine : AcadEntity
	{
		private const string cstrClassName = "AcadMLine";

		private bool mblnOpened;

		public AcadMLine()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 101;
			base.FriendLetNodeName = "Unbekannt";
			base.FriendLetNodeText = "Unbekannt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "MLINE";
			base.FriendLetObjectName = "AcDbMLine";
			base.FriendLetEntityType = Enums.AcEntityName.acMLine;
		}

		~AcadMLine()
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
