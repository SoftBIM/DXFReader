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
	public class AcadHyperlinks
	{
		private const string cstrClassName = "AcadHyperlinks";

		private bool mblnOpened;

		public AcadHyperlinks()
		{
			mblnOpened = true;
		}

		~AcadHyperlinks()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mblnOpened = false;
			}
		}
	}
}
