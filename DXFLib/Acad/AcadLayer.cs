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
	public class AcadLayer : AcadTableRecord
	{
		private const string cstrClassName = "AcadLayer";

		private const int clngFreeze = 1;

		private const int clngViewportDefault = 2;

		private const int clngLocked = 4;

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private Enums.AcColor mnumColor;

		private bool mblnDependend;

		private bool mblnFreeze;

		private bool mblnLayerOn;

		private string mstrLinetype;

		private double mdblLinetypeObjectID;

		private Enums.AcLineWeight mnumLineweight;

		private bool mblnLocked;

		private bool mblnPlottable;

		private bool mblnResolved;

		private bool mblnViewportDefault;

		private int mlngFlags70;

		private double mdblPlotStyleNameObjectID;

		private bool mblnFriendLetFlags;

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

		internal double FriendLetPlotStyleNameObjectID
		{
			set
			{
				if (value > 0.0)
				{
					mdblPlotStyleNameObjectID = value;
				}
			}
		}

		internal string FriendLetPlotStyleNameReference
		{
			set
			{
				if (Operators.CompareString(value, null, TextCompare: false) != 0)
				{
					double ddblPlotStyleNameObjectID = FriendLetPlotStyleNameObjectID = hwpDxf_Functions.BkDXF_HexToDbl(value);
				}
			}
		}

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = (value & -65);
				Freeze = ((1 & mlngFlags70) == 1);
				ViewportDefault = ((2 & mlngFlags70) == 2);
				Locked = ((4 & mlngFlags70) == 4);
				FriendLetDependend = ((0x10 & mlngFlags70) == 16);
				FriendLetResolved = ((0x20 & mlngFlags70) == 32);
				mblnFriendLetFlags = false;
			}
		}

		public Enums.AcColor Color
		{
			get
			{
				return mnumColor;
			}
			set
			{
				mnumColor = value;
			}
		}

		public bool Dependend => mblnDependend;

		public bool Freeze
		{
			get
			{
				return mblnFreeze;
			}
			set
			{
				mblnFreeze = value;
				InternCalcFlags70();
			}
		}

		public bool LayerOn
		{
			get
			{
				return mblnLayerOn;
			}
			set
			{
				mblnLayerOn = value;
			}
		}

		public double LinetypeObjectID => mdblLinetypeObjectID;

		public string LinetypeReference
		{
			get
			{
				if (mdblLinetypeObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblLinetypeObjectID);
				}
				return null;
			}
		}

		public string Linetype
		{
			get
			{
				AcadLineType dobjAcadLinetype2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (mdblLinetypeObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblLinetypeObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbLinetypeTableRecord", TextCompare: false) == 0)
					{
						dobjAcadLinetype2 = (AcadLineType)dobjAcadObject2;
						mstrLinetype = dobjAcadLinetype2.Name;
					}
				}
				string Linetype = mstrLinetype;
				dobjAcadLinetype2 = null;
				dobjAcadObject2 = null;
				return Linetype;
			}
			set
			{
				AcadLineType dobjAcadLinetype2 = (AcadLineType)base.Database.Linetypes.FriendGetItem(hwpDxf_Functions.BkDXF_LinetypeString(value));
				if (dobjAcadLinetype2 != null)
				{
					mstrLinetype = dobjAcadLinetype2.Name;
					mdblLinetypeObjectID = dobjAcadLinetype2.ObjectID;
				}
				else
				{
					mstrLinetype = value;
					mdblLinetypeObjectID = -1.0;
					hwpDxf_Functions.BkDXF_DebugPrint("AcadLayer: Linientyp '" + value + "' konnte nicht gefunden werden.");
				}
				dobjAcadLinetype2 = null;
			}
		}

		public Enums.AcLineWeight Lineweight
		{
			get
			{
				return mnumLineweight;
			}
			set
			{
				mnumLineweight = value;
			}
		}

		public bool Locked
		{
			get
			{
				return mblnLocked;
			}
			set
			{
				mblnLocked = value;
				InternCalcFlags70();
			}
		}

		public string PlotStyleName
		{
			get
			{
				string PlotStyleName = default(string);
				AcadPlaceholder dobjAcadPlaceholder2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (mdblPlotStyleNameObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblPlotStyleNameObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbPlaceholder", TextCompare: false) == 0)
					{
						dobjAcadPlaceholder2 = (AcadPlaceholder)dobjAcadObject2;
						PlotStyleName = dobjAcadPlaceholder2.Name;
					}
				}
				dobjAcadPlaceholder2 = null;
				dobjAcadObject2 = null;
				return PlotStyleName;
			}
			set
			{
				AcadPlaceholder dobjAcadPlaceholder2 = (AcadPlaceholder)base.Database.Dictionaries.PlotStyleNames.FriendGetItem(value);
				if (dobjAcadPlaceholder2 != null)
				{
					mdblPlotStyleNameObjectID = dobjAcadPlaceholder2.ObjectID;
				}
				dobjAcadPlaceholder2 = null;
			}
		}

		public bool Plottable
		{
			get
			{
				return mblnPlottable;
			}
			set
			{
				mblnPlottable = value;
			}
		}

		public bool Resolved => mblnResolved;

		public bool ViewportDefault
		{
			get
			{
				return mblnViewportDefault;
			}
			set
			{
				mblnViewportDefault = value;
				InternCalcFlags70();
			}
		}

		public double PlotStyleNameObjectID => mdblPlotStyleNameObjectID;

		public string PlotStyleNameReference
		{
			get
			{
				if (mdblPlotStyleNameObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblPlotStyleNameObjectID);
				}
				return null;
			}
		}

		public int Flags70 => mlngFlags70;

		public AcadLayer()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 125;
			base.FriendLetNodeImageDisabledID = 126;
			base.FriendLetNodeName = "Layer";
			base.FriendLetNodeText = "Layer";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mnumColor = hwpDxf_Vars.pnumLayerColor;
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mblnFreeze = hwpDxf_Vars.pblnFreeze;
			mblnLayerOn = hwpDxf_Vars.pblnLayerOn;
			mstrLinetype = hwpDxf_Vars.pstrLayerLinetype;
			mdblLinetypeObjectID = -1.0;
			mnumLineweight = hwpDxf_Vars.pnumLayerLineweight;
			mblnLocked = hwpDxf_Vars.pblnLocked;
			mblnPlottable = hwpDxf_Vars.pblnPlottable;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnViewportDefault = hwpDxf_Vars.pblnViewportDefault;
			mdblPlotStyleNameObjectID = -1.0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "LAYER";
			base.FriendLetObjectName = "AcDbLayerTableRecord";
		}

		~AcadLayer()
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
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Freeze, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(ViewportDefault, 2, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Locked, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Dependend, 16, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Resolved, 32, 0)));
			}
		}
	}

}
