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
	public class AcadUCS : AcadTableRecord
	{
		private const string cstrClassName = "AcadUCS";

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private bool mblnDependend;

		private object mdecDepth;

		private double mdblDepth;

		private object[] madecOrigin;

		private double[] madblOrigin;

		private Enums.AcOrthoView mnumUCSOrthographic;

		private bool mblnResolved;

		private object[] madecXVector;

		private double[] madblXVector;

		private object[] madecYVector;

		private double[] madblYVector;

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

		internal object FriendLetDepth
		{
			set
			{
				ref object rvarValueDec = ref mdecDepth;
				ref double reference = ref mdblDepth;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal Enums.AcOrthoView FriendLetUCSOrthographic
		{
			set
			{
				mnumUCSOrthographic = value;
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

		public bool Dependend => mblnDependend;

		public object Depth => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecDepth), mdblDepth));

		public object Origin
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecOrigin, madblOrigin));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecOrigin;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblOrigin;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadUCS", dstrErrMsg);
				}
			}
		}

		public Enums.AcOrthoView UCSOrthographic => mnumUCSOrthographic;

		public bool Resolved => mblnResolved;

		public object XVector
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecXVector, madblXVector));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecXVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblXVector;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadUCS", dstrErrMsg);
				}
			}
		}

		public object YVector
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecYVector, madblYVector));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecYVector;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblYVector;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadUCS", dstrErrMsg);
				}
			}
		}

		public int Flags70 => mlngFlags70;

		public bool NoneUCSOrthographic => mnumUCSOrthographic == Enums.AcOrthoView.acOvNone;

		public AcadUCS()
		{
			madecOrigin = new object[3];
			madblOrigin = new double[3];
			madecXVector = new object[3];
			madblXVector = new double[3];
			madecYVector = new object[3];
			madblYVector = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 141;
			base.FriendLetNodeImageDisabledID = 142;
			base.FriendLetNodeName = "Benutzerkoordinatensystem";
			base.FriendLetNodeText = "Benutzerkoordinatensystem";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblDepth = hwpDxf_Vars.pdblDepth;
			madblOrigin[0] = hwpDxf_Vars.padblOrigin[0];
			madblOrigin[1] = hwpDxf_Vars.padblOrigin[1];
			madblOrigin[2] = hwpDxf_Vars.padblOrigin[2];
			madblXVector[0] = hwpDxf_Vars.padblXVector[0];
			madblXVector[1] = hwpDxf_Vars.padblXVector[1];
			madblXVector[2] = hwpDxf_Vars.padblXVector[2];
			madblYVector[0] = hwpDxf_Vars.padblYVector[0];
			madblYVector[1] = hwpDxf_Vars.padblYVector[1];
			madblYVector[2] = hwpDxf_Vars.padblYVector[2];
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mnumUCSOrthographic = hwpDxf_Vars.pnumUCSOrthographic;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "UCS";
			base.FriendLetObjectName = "AcDbUCSTableRecord";
		}

		~AcadUCS()
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

		public object GetUCSMatrix()
		{
			object GetUCSMatrix = default(object);
			return GetUCSMatrix;
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
