using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadLineType : AcadTableRecord
	{
		private const string cstrClassName = "AcadLineType";

		private const int clngDependend = 16;

		private const int clngResolved = 32;

		private bool mblnOpened;

		private bool mblnDependend;

		private string mstrDescription;

		private object mdecPatternLength;

		private double mdblPatternLength;

		private bool mblnResolved;

		private bool mblnScaledToFit;

		private int mlngFlags70;

		private bool mblnFriendLetFlags;

		private AcadLineTypeDashes mobjAcadLineTypeDashes;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				mobjAcadLineTypeDashes.FriendLetDatabaseIndex = value;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				mobjAcadLineTypeDashes.FriendLetDocumentIndex = value;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				mobjAcadLineTypeDashes.FriendLetApplicationIndex = value;
			}
		}

		internal override int FriendLetTableIndex
		{
			set
			{
				base.FriendLetTableIndex = value;
				mobjAcadLineTypeDashes.FriendLetTableIndex = value;
			}
		}

		public AcadLineTypeDashes Dashes => mobjAcadLineTypeDashes;

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

		internal object FriendLetPatternLength
		{
			set
			{
				ref object rvarValueDec = ref mdecPatternLength;
				ref double reference = ref mdblPatternLength;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal bool FriendLetScaledToFit
		{
			set
			{
				mblnScaledToFit = value;
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

		public string Description
		{
			get
			{
				return mstrDescription;
			}
			set
			{
				mstrDescription = value;
			}
		}

		public int NumDashes => mobjAcadLineTypeDashes.Count;

		public object PatternLength => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecPatternLength), mdblPatternLength));

		public bool Resolved => mblnResolved;

		public bool ScaledToFit => mblnScaledToFit;

		public int Flags70 => mlngFlags70;

		public AcadLineType()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 121;
			base.FriendLetNodeImageDisabledID = 122;
			base.FriendLetNodeName = "Linientyp";
			base.FriendLetNodeText = "Linientyp";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblPatternLength = hwpDxf_Vars.pdblPatternLength;
			mblnDependend = hwpDxf_Vars.pblnDependend;
			mstrDescription = hwpDxf_Vars.pstrDescription;
			mblnResolved = hwpDxf_Vars.pblnResolved;
			mblnScaledToFit = hwpDxf_Vars.pblnScaledToFit;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			base.FriendLetDXFName = "LTYPE";
			base.FriendLetObjectName = "AcDbLinetypeTableRecord";
			mobjAcadLineTypeDashes = new AcadLineTypeDashes();
			mobjAcadLineTypeDashes.FriendLetNodeParentID = base.NodeID;
			mobjAcadLineTypeDashes.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			mobjAcadLineTypeDashes.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			mobjAcadLineTypeDashes.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			mobjAcadLineTypeDashes.FriendLetTableIndex = base.TableIndex;
		}

		~AcadLineType()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjAcadLineTypeDashes.FriendQuit();
				base.FriendQuit();
				mobjAcadLineTypeDashes = null;
				mblnOpened = false;
			}
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
