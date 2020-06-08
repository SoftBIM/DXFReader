using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadAttribute : AcadText
	{
		private const string cstrClassName = "AcadAttribute";

		private bool mblnOpened;

		private string mstrPromptString;

		private string mstrTagString;

		private Enums.AcAttributeMode mnumAttribFlags;

		private bool mblnInvisible;

		private bool mblnConstant;

		private bool mblnVerify;

		private bool mblnPreset;

		private int mlngFieldLength;

		private bool mblnFriendLetFlags;

		internal Enums.AcAttributeMode FriendLetAttribFlags
		{
			set
			{
				mblnFriendLetFlags = true;
				mnumAttribFlags = value;
				Invisible = ((Enums.AcAttributeMode.acAttributeModeInvisible & mnumAttribFlags) == Enums.AcAttributeMode.acAttributeModeInvisible);
				Constant = ((Enums.AcAttributeMode.acAttributeModeConstant & mnumAttribFlags) == Enums.AcAttributeMode.acAttributeModeConstant);
				Verify = ((Enums.AcAttributeMode.acAttributeModeVerify & mnumAttribFlags) == Enums.AcAttributeMode.acAttributeModeVerify);
				Preset = ((Enums.AcAttributeMode.acAttributeModePreset & mnumAttribFlags) == Enums.AcAttributeMode.acAttributeModePreset);
				mblnFriendLetFlags = false;
			}
		}

		internal int FriendLetFieldLength
		{
			set
			{
				mlngFieldLength = value;
			}
		}

		public string PromptString
		{
			get
			{
				return mstrPromptString;
			}
			set
			{
				mstrPromptString = value;
			}
		}

		public string TagString
		{
			get
			{
				return mstrTagString;
			}
			set
			{
				mstrTagString = value;
			}
		}

		public Enums.AcAttributeMode AttribFlags => mnumAttribFlags;

		public bool Invisible
		{
			get
			{
				return mblnInvisible;
			}
			set
			{
				mblnInvisible = value;
				InternCalcAttribFlags();
			}
		}

		public bool Constant
		{
			get
			{
				return mblnConstant;
			}
			set
			{
				mblnConstant = value;
				InternCalcAttribFlags();
			}
		}

		public bool Verify
		{
			get
			{
				return mblnVerify;
			}
			set
			{
				mblnVerify = value;
				InternCalcAttribFlags();
			}
		}

		public bool Preset
		{
			get
			{
				return mblnPreset;
			}
			set
			{
				mblnPreset = value;
				InternCalcAttribFlags();
			}
		}

		public int FieldLength => mlngFieldLength;

		public AcadAttribute()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 247;
			base.FriendLetNodeImageDisabledID = 248;
			base.FriendLetNodeName = "Attributdefinition";
			base.FriendLetNodeText = "Attributdefinition";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrPromptString = hwpDxf_Vars.pstrPromptString;
			mstrTagString = hwpDxf_Vars.pstrTagString;
			mblnInvisible = hwpDxf_Vars.pblnInvisible;
			mblnConstant = hwpDxf_Vars.pblnConstant;
			mblnVerify = hwpDxf_Vars.pblnVerify;
			mblnPreset = hwpDxf_Vars.pblnPreset;
			mlngFieldLength = hwpDxf_Vars.plngFieldLength;
			mblnFriendLetFlags = false;
			InternCalcAttribFlags();
			base.FriendLetDXFName = "ATTDEF";
			base.FriendLetObjectName = "AcDbAttributeDefinition";
			base.FriendLetEntityType = Enums.AcEntityName.acAttribute;
		}

		~AcadAttribute()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}

		private void InternCalcAttribFlags()
		{
			if (!mblnFriendLetFlags)
			{
				mnumAttribFlags = (Enums.AcAttributeMode)Conversions.ToInteger(Interaction.IIf(Invisible, Enums.AcAttributeMode.acAttributeModeInvisible, 0));
				mnumAttribFlags = (Enums.AcAttributeMode)Conversions.ToInteger(Operators.OrObject(mnumAttribFlags, Interaction.IIf(Constant, Enums.AcAttributeMode.acAttributeModeConstant, 0)));
				mnumAttribFlags = (Enums.AcAttributeMode)Conversions.ToInteger(Operators.OrObject(mnumAttribFlags, Interaction.IIf(Verify, Enums.AcAttributeMode.acAttributeModeVerify, 0)));
				mnumAttribFlags = (Enums.AcAttributeMode)Conversions.ToInteger(Operators.OrObject(mnumAttribFlags, Interaction.IIf(Preset, Enums.AcAttributeMode.acAttributeModePreset, 0)));
			}
		}
	}
}
