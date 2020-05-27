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
	class AcadHyperlink
	{
		private const string cstrClassName = "AcadHyperlink";

		private bool mblnOpened;

		public AcadHyperlink()
		{
			mblnOpened = true;
		}

		~AcadHyperlink()
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
