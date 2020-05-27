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
	public class AcadLeader : AcadCurve
	{
		private const string cstrClassName = "AcadLeader";

		private bool mblnOpened;

		public AcadLeader()
		{
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveLeader;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 101;
			base.FriendLetNodeName = "Unbekannt";
			base.FriendLetNodeText = "Unbekannt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "LEADER";
			base.FriendLetObjectName = "AcDbLeader";
			base.FriendLetEntityType = Enums.AcEntityName.acLeader;
		}

		~AcadLeader()
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
