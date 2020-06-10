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
	public class AcadBlockBegin : AcadEntity
	{
		private const string cstrClassName = "AcadBlockBegin";

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

		public AcadBlockBegin()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 159;
			base.FriendLetNodeImageDisabledID = 160;
			base.FriendLetNodeName = "Blockbeginn";
			base.FriendLetNodeText = "A Blockbeginn";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mblnIsPaperSpace = hwpDxf_Vars.pblnIsPaperSpace;
			base.Visible = hwpDxf_Vars.pblnBlkBegEndVisible;
			base.FriendLetDXFName = "BLOCKBEGIN";
			base.FriendLetObjectName = "AcDbBlockBegin";
			base.FriendLetEntityType = Enums.AcEntityName.acBlockBegin;
		}

		~AcadBlockBegin()
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
