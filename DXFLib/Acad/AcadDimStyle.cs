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
	public class AcadDimStyle : AcadTableRecord
	{
		private const string cstrClassName = "AcadDimStyle";

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private bool mblnDependend;

		private bool mblnResolved;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		private AcadSysVars mobjAcadSysVars;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				mobjAcadSysVars.FriendLetDocumentIndex = value;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				mobjAcadSysVars.FriendLetApplicationIndex = value;
			}
		}

		internal AcadSysVars FriendGetAcadSysVars => mobjAcadSysVars;

		internal bool FriendLetDependend
		{
			set
			{
				mblnDependend = value;
				InternCalcFlags70();
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
				FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		public AcadSysVars Variables => mobjAcadSysVars;

		public bool Dependend => mblnDependend;

		public bool Resolved => mblnResolved;

		public int Flags70 => mlngFlags70;

		public AcadDimStyle()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 137;
			base.FriendLetNodeImageDisabledID = 138;
			base.FriendLetNodeName = "Bemassungsstil";
			base.FriendLetNodeText = "Bemassungsstil";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "DIMSTYLE";
			base.FriendLetObjectName = "AcDbDimStyleTableRecord";
			mobjAcadSysVars = new AcadSysVars();
			mobjAcadSysVars.FriendLetNodeParentID = base.NodeID;
			mobjAcadSysVars.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			mobjAcadSysVars.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			mobjAcadSysVars.FriendAddXXX("DIMTXSTY");
		}

		~AcadDimStyle()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadSysVars.FriendQuit();
				base.FriendQuit();
				mobjAcadSysVars = null;
				mblnOpened = false;
			}
		}

		public void CopyFrom(object vobjStyleSource)
		{
		}

		internal AcadSysVar FriendFindVariable(string vstrName)
		{
			return mobjAcadSysVars.FriendGetItem(Strings.UCase(vstrName));
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Resolved, 32, 0)));
			}
		}
	}
}
