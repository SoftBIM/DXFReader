using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_Enums
	{
		public enum UNITS_BASE
		{
			unBritish,
			unMetric
		}

		public enum UNITS_METRIC
		{
			unmMillimeter,
			unmZentimeter,
			unmDezimeter,
			unmMeter,
			unmDekameter,
			unmHektometer,
			unmKilometer
		}

		public enum UNITS_BRITISCH
		{
			unbInch,
			unbFoot,
			unbYard,
			unbMile
		}

		public enum SAVE_TYPE
		{
			stUnknown = 0,
			stNone = 1,
			stRegistry = 2,
			stDrawing = 4,
			stViewport = 8,
			stDXFApp = 0x10,
			stDXFDoc = 0x20,
			stDXFVport = 0x40
		}

		public enum REF_TYPE
		{
			rtUnknown = 0,
			rtApplication = 1,
			rtDrawing = 2,
			rtViewport = 4,
			rtDimension = 8
		}

		public enum SYMBOL_TABLE
		{
			symNone,
			symAppid,
			symBlock,
			symDimStyle,
			symLayer,
			symLType,
			symStyle,
			symUcs,
			symView,
			symVPort
		}

		public enum PREF_TAB
		{
			ptNone,
			ptUnknown,
			ptFiles,
			ptDisplay,
			ptOpenSave,
			ptOutput,
			ptSystem,
			ptUser,
			ptDrafting,
			ptSelection,
			ptProfile
		}

		public enum DASH_TYPE
		{
			dtStandard = 0,
			dtText = 2,
			dtSymbol = 4
		}

		public enum RENDER_MODE
		{
			rm2D,
			rmWire,
			rmHided,
			rmFlatShaded,
			rmGouraudShaded,
			rmFlatShadedWire,
			rmGouraudShadedWire
		}

		public enum SNAP_PAIR
		{
			spLeft,
			spTop,
			spRight
		}

		public enum PROXY_TYPE
		{
			ptObject,
			ptEntity
		}

		public enum PROXY_PROPS
		{
			ppEraseAllowed = 1,
			ppTransformAllowed = 2,
			ppColorChangeAllowed = 4,
			ppLayerChangeAllowed = 8,
			ppLinetypeChangeAllowed = 0x10,
			ppLinetypeScaleChangeAllowed = 0x20,
			ppVisibilityChangeAllowed = 0x40,
			ppCloningAllowed = 0x80,
			ppLineweightChangeAllowed = 0x100,
			ppPlotStyleNameChangeAllowed = 0x200,
			ppR13Format = 0x8000
		}

		public enum APP_SHOWMODE
		{
			asNone = 0,
			asReadAndWrite = 1,
			asReadOnly = 2,
			asHidden = 4,
			asSystem = 8,
			asNodeProps = 0x10
		}

		public enum MERGE_STYLE
		{
			msDrcNotApplicable,
			msDrcIgnore,
			msDrcReplace,
			msDrcXrefMangleName,
			msDrcMangleName
		}
	}
}
