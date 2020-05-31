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
	public class AcadVXTableRecord : AcadObject
	{
		private const string cstrClassName = "AcadVXTableRecord";

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

		public AcadVXTableRecord()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 102;
			base.FriendLetNodeName = "VX-Element";
			base.FriendLetNodeText = "VX-Element";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			base.FriendLetDXFName = "VXTABLERECORD";
			base.FriendLetObjectName = "AcDbVXTableRecord";
		}

		~AcadVXTableRecord()
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
