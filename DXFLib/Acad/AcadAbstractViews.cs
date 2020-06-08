using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadAbstractViews : AcadTable
	{
		private const string cstrClassName = "AcadAbstractViews";

		private bool mblnOpened;

		public AcadAbstractViews()
		{
			mblnOpened = true;
			base.FriendLetDXFName = "ABSTRACTVIEW";
			base.FriendLetObjectName = "AcDbAbstractViewTable";
			base.FriendLetSubordinateObjectName = "AcDbAbstractViewTable";
		}

		~AcadAbstractViews()
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
