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
	public class AcadRegisteredApplication : AcadTableRecord
	{
		private const string cstrClassName = "AcadRegisteredApplication";

		private const int clngR12XDataSave = 1;

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private bool mblnDependend;

		private bool mblnR12XdataSave;

		private bool mblnResolved;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		internal bool FriendLetDependend
		{
			set
			{
				mblnDependend = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetR12XDataSave
		{
			set
			{
				mblnR12XdataSave = value;
			}
		}

		internal bool FriendLetResolved
		{
			set
			{
				mblnResolved = value;
				InternCalcFlags70();
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = (value & -65);
				FriendLetR12XDataSave = ((1 & mlngFlags70) == 1);
				FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		public bool Dependend => mblnDependend;

		public bool R12XDataSave => mblnR12XdataSave;

		public bool Resolved => mblnResolved;

		public int Flags70 => mlngFlags70;

		public AcadRegisteredApplication()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 145;
			base.FriendLetNodeImageDisabledID = 146;
			base.FriendLetNodeName = "Anwendung";
			base.FriendLetNodeText = "Anwendung";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mblnR12XdataSave = hwpDxf_Vars.pblnR12XdataSave;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "APPID";
			base.FriendLetObjectName = "AcDbRegAppTableRecord";
		}

		~AcadRegisteredApplication()
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

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(R12XDataSave, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Resolved, 32, 0)));
			}
		}
	}

}
