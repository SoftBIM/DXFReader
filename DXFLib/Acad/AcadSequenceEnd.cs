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
	public class AcadSequenceEnd : AcadEntity
	{
		private const string cstrClassName = "AcadSequenceEnd";

		private bool mblnOpened;

		public AcadSequenceEnd()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 249;
			base.FriendLetNodeImageDisabledID = 250;
			base.FriendLetNodeName = "Sequenzende";
			base.FriendLetNodeText = "B Sequenzende";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.Visible = hwpDxf_Vars.pblnSequenceEndVisible;
			base.FriendLetDXFName = "SEQEND";
			base.FriendLetObjectName = "AcDbSequenceEnd";
			base.FriendLetEntityType = Enums.AcEntityName.acSequenceEnd;
		}

		~AcadSequenceEnd()
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
