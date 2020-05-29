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
	public class AcadPlaceholder : AcadObject
	{
		private const string cstrClassName = "AcadPlaceholder";

		private bool mblnOpened;

		private string mstrName;

		internal string FriendLetName
		{
			set
			{
				mstrName = value;
				base.FriendLetNodeText = mstrName;
			}
		}

		public string Name => mstrName;

		public AcadPlaceholder()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 227;
			base.FriendLetNodeImageDisabledID = 228;
			base.FriendLetNodeName = "Platzhalter";
			base.FriendLetNodeText = "Platzhalter";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			base.FriendLetDXFName = "ACDBPLACEHOLDER";
			base.FriendLetObjectName = "AcDbPlaceholder";
		}

		~AcadPlaceholder()
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
