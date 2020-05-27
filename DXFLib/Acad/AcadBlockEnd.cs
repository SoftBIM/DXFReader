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
    public class AcadBlockEnd : AcadEntity
	{
		private const string cstrClassName = "AcadBlockEnd";

		private bool mblnOpened;

		private bool mblnIsPaperSpace;

		internal bool FriendLetIsPaperSpace
		{
			set
			{
				mblnIsPaperSpace = value;
			}
		}

		public bool IsPaperSpace => mblnIsPaperSpace;

		public AcadBlockEnd()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 161;
			base.FriendLetNodeImageDisabledID = 162;
			base.FriendLetNodeName = "Blockende";
			base.FriendLetNodeText = "C Blockende";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mblnIsPaperSpace = hwpDxf_Vars.pblnIsPaperSpace;
			base.Visible = hwpDxf_Vars.pblnBlkBegEndVisible;
			base.FriendLetDXFName = "BLOCKEND";
			base.FriendLetObjectName = "AcDbBlockEnd";
			base.FriendLetEntityType = Enums.AcEntityName.acBlockEnd;
		}

		~AcadBlockEnd()
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
