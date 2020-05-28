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
	public class AcadMaterial : AcadObject
	{
		private const string cstrClassName = "AcadMaterial";

		private bool mblnOpened;

		private string mstrName;

		private string mstrDescription;

		private int mlngIndex;

		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
				base.FriendLetNodeText = mstrName;
			}
		}

		public string Description
		{
			get
			{
				return mstrDescription;
			}
			set
			{
				mstrDescription = value;
			}
		}

		public AcadMaterial()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 301;
			base.FriendLetNodeImageDisabledID = 302;
			base.FriendLetNodeName = "Material";
			base.FriendLetNodeText = "Material";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			mstrDescription = hwpDxf_Vars.pstrDescription;
			mlngIndex = -1;
			base.FriendLetDXFName = "MATERIAL";
			base.FriendLetObjectName = "AcDbMaterial";
		}

		~AcadMaterial()
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
