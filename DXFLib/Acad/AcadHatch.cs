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
	public class AcadHatch : AcadEntity
	{
		private const string cstrClassName = "AcadHatch";

		private bool mblnOpened;

		private object[] madecElevation;

		private double[] madblElevation;

		private object[] madecNormal;

		private double[] madblNormal;

		private string mstrPatternName;

		private bool mblnIsSolid;

		private bool mblnAssociativeHatch;

		private Enums.AcHatchStyle mnumHatchStyle;

		private Enums.AcPatternType mnumPatternType;

		private object mdecPatternAngle;

		private double mdblPatternAngle;

		private object mdecPatternScale;

		private double mdblPatternScale;

		private object mdecPatternSpace;

		private double mdblPatternSpace;

		private bool mblnPatternDouble;

		private object mdecPixelSize;

		private double mdblPixelSize;

		private AcadLoops mobjAcadLoops;

		private AcadPatternDefinitions mobjAcadPatternDefinitions;

		private AcadSeedPoints mobjAcadSeedPoints;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				mobjAcadLoops.FriendLetDatabaseIndex = value;
				if (mobjAcadPatternDefinitions != null)
				{
					mobjAcadPatternDefinitions.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadSeedPoints != null)
				{
					mobjAcadSeedPoints.FriendLetDatabaseIndex = value;
				}
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				mobjAcadLoops.FriendLetDocumentIndex = value;
				if (mobjAcadPatternDefinitions != null)
				{
					mobjAcadPatternDefinitions.FriendLetDocumentIndex = value;
				}
				if (mobjAcadSeedPoints != null)
				{
					mobjAcadSeedPoints.FriendLetDocumentIndex = value;
				}
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				mobjAcadLoops.FriendLetApplicationIndex = value;
				if (mobjAcadPatternDefinitions != null)
				{
					mobjAcadPatternDefinitions.FriendLetApplicationIndex = value;
				}
				if (mobjAcadSeedPoints != null)
				{
					mobjAcadSeedPoints.FriendLetApplicationIndex = value;
				}
			}
		}

		internal string FriendLetPatternName
		{
			set
			{
				mstrPatternName = value;
			}
		}

		internal bool FriendLetIsSolid
		{
			set
			{
				mblnIsSolid = value;
			}
		}

		internal Enums.AcPatternType FriendLetPatternType
		{
			set
			{
				mnumPatternType = value;
			}
		}

		internal object FriendLetPixelSize
		{
			set
			{
				ref object rvarValueDec = ref mdecPixelSize;
				ref double reference = ref mdblPixelSize;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal string FriendGetHatchStyleString
		{
			get
			{
				switch (mnumHatchStyle)
				{
					case Enums.AcHatchStyle.acHatchStyleNormal:
						return "Normal";
					case Enums.AcHatchStyle.acHatchStyleOuter:
						return "Äußere";
					case Enums.AcHatchStyle.acHatchStyleIgnore:
						return "Ignorieren";
					default:
						return "Unbekannt";
				}
			}
		}

		internal string FriendGetPatternTypeString
		{
			get
			{
				switch (mnumPatternType)
				{
					case Enums.AcPatternType.acHatchPatternTypeUserDefined:
						return "Benutzerdefiniert";
					case Enums.AcPatternType.acHatchPatternTypePreDefined:
						return "Vordefiniert";
					case Enums.AcPatternType.acHatchPatternTypeCustomDefined:
						return "Benutzerspezifisch";
					default:
						return "Unbekannt";
				}
			}
		}

		public AcadLoops Loops => mobjAcadLoops;

		public AcadPatternDefinitions PatternDefinitions
		{
			get
			{
				if (mobjAcadPatternDefinitions != null)
				{
					return mobjAcadPatternDefinitions;
				}
				AcadPatternDefinitions PatternDefinitions = default(AcadPatternDefinitions);
				return PatternDefinitions;
			}
		}

		public AcadSeedPoints SeedPoints
		{
			get
			{
				if (mobjAcadSeedPoints != null)
				{
					return mobjAcadSeedPoints;
				}
				AcadSeedPoints SeedPoints = default(AcadSeedPoints);
				return SeedPoints;
			}
		}

		public int NumberOfLoops => mobjAcadLoops.Count;

		public int NumberOfPatternDefinitions
		{
			get
			{
				if (mobjAcadPatternDefinitions != null)
				{
					return mobjAcadPatternDefinitions.Count;
				}
				return 0;
			}
		}

		public int NumberOfSeedPoints
		{
			get
			{
				if (mobjAcadSeedPoints != null)
				{
					return mobjAcadSeedPoints.Count;
				}
				return 0;
			}
		}

		public object Elevation
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecElevation, madblElevation));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadHatch", dstrErrMsg);
					return;
				}
				NewLateBinding.LateIndexSet(value, new object[2]
				{
				0,
				Interaction.IIf(Expression: false, 0m, 0.0)
				}, null);
				NewLateBinding.LateIndexSet(value, new object[2]
				{
				1,
				Interaction.IIf(Expression: false, 0m, 0.0)
				}, null);
				ref object[] reference = ref madecElevation;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblElevation;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		public object Normal
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecNormal, madblNormal));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecNormal;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblNormal;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadHatch", dstrErrMsg);
				}
			}
		}

		public string PatternName => mstrPatternName;

		public bool IsSolid => mblnIsSolid;

		public bool AssociativeHatch
		{
			get
			{
				return mblnAssociativeHatch;
			}
			set
			{
				mblnAssociativeHatch = value;
			}
		}

		public Enums.AcHatchStyle HatchStyle
		{
			get
			{
				return mnumHatchStyle;
			}
			set
			{
				mnumHatchStyle = value;
			}
		}

		public Enums.AcPatternType PatternType => mnumPatternType;

		public object PatternAngle
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPatternAngle), mdblPatternAngle));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecPatternAngle;
				ref double reference = ref mdblPatternAngle;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadHatch", dstrErrMsg);
				}
			}
		}

		public object PatternScale
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPatternScale), mdblPatternScale));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecPatternScale;
				ref double reference = ref mdblPatternScale;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadHatch", dstrErrMsg);
				}
			}
		}

		public object PatternSpace
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPatternSpace), mdblPatternSpace));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecPatternSpace;
				ref double reference = ref mdblPatternSpace;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadHatch", dstrErrMsg);
				}
			}
		}

		public bool PatternDouble
		{
			get
			{
				return mblnPatternDouble;
			}
			set
			{
				mblnPatternDouble = value;
			}
		}

		public object PixelSize => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPixelSize), mdblPixelSize));

		public AcadHatch()
		{
			madecElevation = new object[3];
			madblElevation = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 265;
			base.FriendLetNodeImageDisabledID = 266;
			base.FriendLetNodeName = "Schraffur";
			base.FriendLetNodeText = "Schraffur";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblElevation[0] = Conversions.ToDouble(hwpDxf_Vars.padblElevation[0]);
			madblElevation[1] = Conversions.ToDouble(hwpDxf_Vars.padblElevation[1]);
			madblElevation[2] = Conversions.ToDouble(hwpDxf_Vars.padblElevation[2]);
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mdblPatternAngle = hwpDxf_Vars.pdblPatternAngle;
			mdblPatternScale = hwpDxf_Vars.pdblPatternScale;
			mdblPatternSpace = hwpDxf_Vars.pdblPatternSpace;
			mdblPixelSize = Conversions.ToDouble(hwpDxf_Vars.pdblPixelSize);
			mstrPatternName = hwpDxf_Vars.pstrPatternName;
			mblnIsSolid = hwpDxf_Vars.pblnIsSolid;
			mblnAssociativeHatch = hwpDxf_Vars.pblnAssociativeHatch;
			mnumHatchStyle = hwpDxf_Vars.pnumHatchStyle;
			mnumPatternType = hwpDxf_Vars.pnumPatternType;
			mblnPatternDouble = hwpDxf_Vars.pblnPatternDouble;
			base.FriendLetDXFName = "HATCH";
			base.FriendLetObjectName = "AcDbHatch";
			base.FriendLetEntityType = Enums.AcEntityName.acHatch;
			mobjAcadLoops = new AcadLoops();
			mobjAcadLoops.FriendLetNodeParentID = base.NodeID;
			mobjAcadLoops.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			mobjAcadLoops.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			mobjAcadLoops.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
		}

		~AcadHatch()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadLoops.FriendQuit();
				if (mobjAcadPatternDefinitions != null)
				{
					mobjAcadPatternDefinitions.FriendQuit();
				}
				if (mobjAcadSeedPoints != null)
				{
					mobjAcadSeedPoints.FriendQuit();
				}
				base.FriendQuit();
				mobjAcadLoops = null;
				mobjAcadPatternDefinitions = null;
				mobjAcadSeedPoints = null;
				mblnOpened = false;
			}
		}

		internal AcadPatternDefinitions FriendAddPatternDefinitions()
		{
			return InternAddPatternDefinitions();
		}

		internal AcadSeedPoints FriendAddSeedPoints()
		{
			return InternAddSeedPoints();
		}

		private AcadPatternDefinitions InternAddPatternDefinitions()
		{
			if (mobjAcadPatternDefinitions == null)
			{
				mobjAcadPatternDefinitions = new AcadPatternDefinitions();
				mobjAcadPatternDefinitions.FriendLetNodeParentID = base.NodeID;
				mobjAcadPatternDefinitions.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				mobjAcadPatternDefinitions.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				mobjAcadPatternDefinitions.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			}
			return mobjAcadPatternDefinitions;
		}

		private AcadSeedPoints InternAddSeedPoints()
		{
			if (mobjAcadSeedPoints == null)
			{
				mobjAcadSeedPoints = new AcadSeedPoints();
				mobjAcadSeedPoints.FriendLetNodeParentID = base.NodeID;
				mobjAcadSeedPoints.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				mobjAcadSeedPoints.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				mobjAcadSeedPoints.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			}
			return mobjAcadSeedPoints;
		}
	}
}
