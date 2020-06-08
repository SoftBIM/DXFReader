using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class Acad3DSolid : AcadEntity
	{
		private const string cstrClassName = "Acad3DSolid";

		private bool mblnOpened;

		public Acad3DSolid()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 101;
			base.FriendLetNodeName = "Unbekannt";
			base.FriendLetNodeText = "Unbekannt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "3DSOLID";
			base.FriendLetObjectName = "AcDb3dSolid";
			base.FriendLetEntityType = Enums.AcEntityName.ac3dSolid;
		}

		~Acad3DSolid()
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
