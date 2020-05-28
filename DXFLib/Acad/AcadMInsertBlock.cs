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
	public class AcadMInsertBlock : AcadBlockReference
	{
		private const string cstrClassName = "AcadMInsertBlock";

		private bool mblnOpened;

		private int mlngColumns;

		private int mlngRows;

		private object mdecColumnSpacing;

		private double mdblColumnSpacing;

		private object mdecRowSpacing;

		private double mdblRowSpacing;

		public object ColumnSpacing
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecColumnSpacing), mdblColumnSpacing));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecColumnSpacing;
				ref double reference = ref mdblColumnSpacing;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMInsertBlock", dstrErrMsg);
				}
			}
		}

		public object RowSpacing
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRowSpacing), mdblRowSpacing));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecRowSpacing;
				ref double reference = ref mdblRowSpacing;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadMInsertBlock", dstrErrMsg);
				}
			}
		}

		public int Columns
		{
			get
			{
				return mlngColumns;
			}
			set
			{
				mlngColumns = value;
			}
		}

		public int Rows
		{
			get
			{
				return mlngRows;
			}
			set
			{
				mlngRows = value;
			}
		}

		public AcadMInsertBlock()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 243;
			base.FriendLetNodeImageDisabledID = 244;
			base.FriendLetNodeName = "Blockanordnung";
			base.FriendLetNodeText = "Blockanordnung";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblColumnSpacing = hwpDxf_Vars.pdblColumnSpacing;
			mdblRowSpacing = hwpDxf_Vars.pdblRowSpacing;
			mlngColumns = hwpDxf_Vars.plngColumns;
			mlngRows = hwpDxf_Vars.plngRows;
			base.FriendLetDXFName = "INSERT";
			base.FriendLetObjectName = "AcDbMInsertBlock";
			base.FriendLetEntityType = Enums.AcEntityName.acMInsertBlock;
		}

		~AcadMInsertBlock()
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
	}

}
