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
	public class AcadView : AcadAbstractView
	{
		private const string cstrClassName = "AcadView";

		private const int clngPaperSpaceView = 1;

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private const int clngPerspectiveEnabled = 1;

		private const int clngFrontClipEnabled = 2;

		private const int clngBackClipEnabled = 4;

		private bool mblnOpened;

		private bool mblnPaperSpaceView;

		private int mlngFlags70;

		private int mlngFlags71;

		private double mdblAssociatedUcsObjectID;

		private double mdblOrthographicUcsObjectID;

		private bool mblnFriendLetFlags;

		public AcadUCS AssociatedUcs
		{
			get
			{
				AcadUCS AssociatedUcs = default(AcadUCS);
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (UcsAssociatedToView)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblAssociatedUcsObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbUCSTableRecord", TextCompare: false) == 0)
					{
						AssociatedUcs = (AcadUCS)dobjAcadObject2;
					}
				}
				dobjAcadObject2 = null;
				return AssociatedUcs;
			}
		}

		public AcadUCS OrthographicUcs
		{
			get
			{
				AcadUCS OrthographicUcs = default(AcadUCS);
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (HasOrthographicUcs)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblOrthographicUcsObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbUCSTableRecord", TextCompare: false) == 0)
					{
						OrthographicUcs = (AcadUCS)dobjAcadObject2;
					}
				}
				dobjAcadObject2 = null;
				return OrthographicUcs;
			}
		}

		internal bool FriendLetPaperSpaceView
		{
			set
			{
				mblnPaperSpaceView = value;
				InternCalcFlags70();
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = (value & -65);
				FriendLetPaperSpaceView = ((1 & mlngFlags70) == 1);
				base.FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				base.FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		internal int FriendLetFlags71
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags71 = value;
				base.FriendLetPerspectiveEnabled = ((1 & mlngFlags71) == 1);
				base.FriendLetFrontClipEnabled = ((2 & mlngFlags71) == 2);
				base.FriendLetBackClipEnabled = ((4 & mlngFlags71) == 4);
				mblnFriendLetFlags = false;
			}
		}

		internal double FriendLetAssociatedUcsObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblAssociatedUcsObjectID = value;
				}
			}
		}

		internal double FriendLetOrthographicUcsObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblOrthographicUcsObjectID = value;
				}
			}
		}

		public bool PaperSpaceView => mblnPaperSpaceView;

		public bool UcsAssociatedToView => mdblAssociatedUcsObjectID > 0.0;

		public int Flags70 => mlngFlags70;

		public int Flags71 => mlngFlags71;

		public double AssociatedUcsObjectID => mdblAssociatedUcsObjectID;

		public string AssociatedUcsReference
		{
			get
			{
				if (UcsAssociatedToView)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblAssociatedUcsObjectID);
				}
				return null;
			}
		}

		public double OrthographicUcsObjectID => mdblOrthographicUcsObjectID;

		public string OrthographicUcsReference
		{
			get
			{
				if (HasOrthographicUcs)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblOrthographicUcsObjectID);
				}
				return null;
			}
		}

		public Enums.AcOrthoView UCSOrthographic
		{
			get
			{
				Enums.AcOrthoView UCSOrthographic = default(Enums.AcOrthoView);
				AcadUCS dobjAcadUCS2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (UcsAssociatedToView)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblAssociatedUcsObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbUCSTableRecord", TextCompare: false) == 0)
					{
						dobjAcadUCS2 = (AcadUCS)dobjAcadObject2;
						UCSOrthographic = dobjAcadUCS2.UCSOrthographic;
					}
				}
				else
				{
					UCSOrthographic = Enums.AcOrthoView.acOvNone;
				}
				dobjAcadUCS2 = null;
				dobjAcadObject2 = null;
				return UCSOrthographic;
			}
		}

		public bool HasOrthographicUcs => (UCSOrthographic != Enums.AcOrthoView.acOvNone) & (mdblOrthographicUcsObjectID > 0.0);

		public AcadView()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 133;
			base.FriendLetNodeImageDisabledID = 134;
			base.FriendLetNodeName = "Ansicht";
			base.FriendLetNodeText = "Ansicht";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mblnPaperSpaceView = hwpDxf_Vars.pblnPaperSpaceView;
			mdblAssociatedUcsObjectID = -1.0;
			mdblOrthographicUcsObjectID = -1.0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcFlags71();
			base.FriendLetDXFName = "VIEW";
			base.FriendLetObjectName = "AcDbViewTableRecord";
		}

		~AcadView()
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
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(PaperSpaceView, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(base.Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(base.Resolved, 32, 0)));
			}
		}

		private void InternCalcFlags71()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags71 = 0;
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.PerspectiveEnabled, 1, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.FrontClipEnabled, 2, 0)));
				mlngFlags71 = Conversions.ToInteger(Operators.OrObject(mlngFlags71, Interaction.IIf(base.BackClipEnabled, 4, 0)));
			}
		}
	}
}
