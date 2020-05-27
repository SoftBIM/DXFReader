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
	public class AcadLayout : AcadPlotConfiguration
	{
		private const string cstrClassName = "AcadLayout";

		private const int clngPsLtScale = 1;

		private const int clngLimCheck = 2;

		private bool mblnOpened;

		private string mstrName;

		private int mlngTabOrder;

		private object[] madecLimMin;

		private double[] madblLimMin;

		private object[] madecLimMax;

		private double[] madblLimMax;

		private object[] madecInsBase;

		private double[] madblInsBase;

		private object[] madecExtMin;

		private double[] madblExtMin;

		private object[] madecExtMax;

		private double[] madblExtMax;

		private object mdecElevation;

		private double mdblElevation;

		private object[] madecUCSOrigin;

		private double[] madblUCSOrigin;

		private object[] madecUCSXVector;

		private double[] madblUCSXVector;

		private object[] madecUCSYVector;

		private double[] madblUCSYVector;

		private Enums.AcOrthoView mnumUCSOrthographic;

		private double mdblPaperSpaceObjectID;

		private double mdblViewportObjectID;

		private double mdblNamedUcsObjectID;

		private double mdblReferencedUCSObjectID;

		private bool mblnPsLtScale;

		private bool mblnLimCheck;

		private string mlngFlags70;

		private bool mblnFriendLetFlags;

		internal int FriendLetPlotSettingsFlags70
		{
			set
			{
				base.FriendLetFlags70 = value;
			}
		}

		public string PlotSettingsName
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
			}
		}

		public int PlotSettingsFlags70 => base.Flags70;

		internal new int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = Conversions.ToString(value);
				FriendLetPsLtScale = ((1 & Conversions.ToLong(mlngFlags70)) == 1);
				FriendLetLimCheck = ((2 & Conversions.ToLong(mlngFlags70)) == 2);
				mblnFriendLetFlags = false;
			}
		}

		internal object FriendLetLimMin
		{
			set
			{
				ref object[] reference = ref madecLimMin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblLimMin;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetLimMax
		{
			set
			{
				ref object[] reference = ref madecLimMax;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblLimMax;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetInsBase
		{
			set
			{
				ref object[] reference = ref madecInsBase;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblInsBase;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetExtMin
		{
			set
			{
				ref object[] reference = ref madecExtMin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblExtMin;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetExtMax
		{
			set
			{
				ref object[] reference = ref madecExtMax;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblExtMax;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetElevation
		{
			set
			{
				ref object rvarValueDec = ref mdecElevation;
				ref double reference = ref mdblElevation;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetUCSOrigin
		{
			set
			{
				ref object[] reference = ref madecUCSOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblUCSOrigin;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetUCSXVector
		{
			set
			{
				ref object[] reference = ref madecUCSXVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblUCSXVector;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal object FriendLetUCSYVector
		{
			set
			{
				ref object[] reference = ref madecUCSYVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblUCSYVector;
				object ravarArrayDbl = reference2;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
			}
		}

		internal Enums.AcOrthoView FriendLetUCSOrthographic
		{
			set
			{
				mnumUCSOrthographic = value;
			}
		}

		internal double FriendLetPaperSpaceObjectID
		{
			set
			{
				mdblPaperSpaceObjectID = value;
			}
		}

		internal double FriendLetViewportObjectID
		{
			set
			{
				mdblViewportObjectID = value;
			}
		}

		internal double FriendLetNamedUCSObjectID
		{
			set
			{
				mdblNamedUcsObjectID = value;
			}
		}

		internal double FriendLetReferencedUCSObjectID
		{
			set
			{
				mdblReferencedUCSObjectID = value;
			}
		}

		internal bool FriendLetPsLtScale
		{
			set
			{
				mblnPsLtScale = value;
				InternCalcFlags70();
			}
		}

		internal bool FriendLetLimCheck
		{
			set
			{
				mblnLimCheck = value;
				InternCalcFlags70();
			}
		}

		public AcadBlock Block
		{
			get
			{
				AcadBlock Block = default(AcadBlock);
				return Block;
			}
		}

		public new string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
				base.FriendLetNodeText = value;
			}
		}

		public int TabOrder
		{
			get
			{
				return mlngTabOrder;
			}
			set
			{
				mlngTabOrder = value;
			}
		}

		public object LimMin => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecLimMin, madblLimMin));

		public object LimMax => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecLimMax, madblLimMax));

		public object InsBase => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecInsBase, madblInsBase));

		public object ExtMin => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecExtMin, madblExtMin));

		public object ExtMax => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecExtMax, madblExtMax));

		public object Elevation => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecElevation), mdblElevation));

		public object UCSOrigin => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecUCSOrigin, madblUCSOrigin));

		public object UCSXVector => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecUCSXVector, madblUCSXVector));

		public object UCSYVector => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecUCSYVector, madblUCSYVector));

		public Enums.AcOrthoView UCSOrthographic => mnumUCSOrthographic;

		public double PaperSpaceObjectID => mdblPaperSpaceObjectID;

		public string PaperSpaceReference
		{
			get
			{
				if (mdblPaperSpaceObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblPaperSpaceObjectID);
				}
				return null;
			}
		}

		public double ViewportObjectID => mdblViewportObjectID;

		public string ViewportReference
		{
			get
			{
				if (mdblViewportObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblViewportObjectID);
				}
				return null;
			}
		}

		public double NamedUCSObjectID => mdblNamedUcsObjectID;

		public string NamedUCSReference
		{
			get
			{
				if (mdblNamedUcsObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblNamedUcsObjectID);
				}
				return null;
			}
		}

		public double ReferencedUCSObjectID => mdblReferencedUCSObjectID;

		public string ReferencedUCSReference
		{
			get
			{
				if (mdblReferencedUCSObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblReferencedUCSObjectID);
				}
				return null;
			}
		}

		public bool PsLtScale => mblnPsLtScale;

		public bool LimCheck => mblnLimCheck;

		public new int Flags70 => Conversions.ToInteger(mlngFlags70);

		public AcadLayout()
		{
			madecLimMin = new object[2];
			madblLimMin = new double[2];
			madecLimMax = new object[2];
			madblLimMax = new double[2];
			madecInsBase = new object[3];
			madblInsBase = new double[3];
			madecExtMin = new object[3];
			madblExtMin = new double[3];
			madecExtMax = new object[3];
			madblExtMax = new double[3];
			madecUCSOrigin = new object[3];
			madblUCSOrigin = new double[3];
			madecUCSXVector = new object[3];
			madblUCSXVector = new double[3];
			madecUCSYVector = new object[3];
			madblUCSYVector = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 157;
			base.FriendLetNodeImageDisabledID = 158;
			base.FriendLetNodeName = "Layout";
			base.FriendLetNodeText = "Layout";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			madblLimMin[0] = hwpDxf_Vars.padblLayoutLimMin[0];
			madblLimMin[1] = hwpDxf_Vars.padblLayoutLimMin[1];
			madblLimMax[0] = hwpDxf_Vars.padblLayoutLimMax[0];
			madblLimMax[1] = hwpDxf_Vars.padblLayoutLimMax[1];
			madblInsBase[0] = hwpDxf_Vars.padblLayoutInsBase[0];
			madblInsBase[1] = hwpDxf_Vars.padblLayoutInsBase[1];
			madblInsBase[2] = hwpDxf_Vars.padblLayoutInsBase[2];
			madblExtMin[0] = hwpDxf_Vars.padblLayoutExtMin[0];
			madblExtMin[1] = hwpDxf_Vars.padblLayoutExtMin[1];
			madblExtMin[2] = hwpDxf_Vars.padblLayoutExtMin[2];
			madblExtMax[0] = hwpDxf_Vars.padblLayoutExtMax[0];
			madblExtMax[1] = hwpDxf_Vars.padblLayoutExtMax[1];
			madblExtMax[2] = hwpDxf_Vars.padblLayoutExtMax[2];
			mdblElevation = hwpDxf_Vars.pdblElevation;
			madblUCSOrigin[0] = hwpDxf_Vars.padblOrigin[0];
			madblUCSOrigin[1] = hwpDxf_Vars.padblOrigin[1];
			madblUCSOrigin[2] = hwpDxf_Vars.padblOrigin[2];
			madblUCSXVector[0] = hwpDxf_Vars.padblXVector[0];
			madblUCSXVector[1] = hwpDxf_Vars.padblXVector[1];
			madblUCSXVector[2] = hwpDxf_Vars.padblXVector[2];
			madblUCSYVector[0] = hwpDxf_Vars.padblYVector[0];
			madblUCSYVector[1] = hwpDxf_Vars.padblYVector[1];
			madblUCSYVector[2] = hwpDxf_Vars.padblYVector[2];
			mstrName = hwpDxf_Vars.pstrName;
			mlngTabOrder = hwpDxf_Vars.plngTabOrder;
			mnumUCSOrthographic = hwpDxf_Vars.pnumUCSOrthographic;
			mdblPaperSpaceObjectID = -1.0;
			mdblViewportObjectID = -1.0;
			mdblNamedUcsObjectID = -1.0;
			mdblReferencedUCSObjectID = -1.0;
			mblnPsLtScale = hwpDxf_Vars.pblnPsLtScale;
			mblnLimCheck = hwpDxf_Vars.pblnLimCheck;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "LAYOUT";
			base.FriendLetObjectName = "AcDbLayout";
		}

		~AcadLayout()
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
				mlngFlags70 = Conversions.ToString(0);
				mlngFlags70 = Conversions.ToString(Operators.OrObject(mlngFlags70, Interaction.IIf(PsLtScale, 1, 0)));
				mlngFlags70 = Conversions.ToString(Operators.OrObject(mlngFlags70, Interaction.IIf(LimCheck, 2, 0)));
			}
		}
	}

}
