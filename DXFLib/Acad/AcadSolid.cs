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
	public class AcadSolid : AcadEntity
	{
		private const string cstrClassName = "AcadSolid";

		private bool mblnOpened;

		private object[] madecCoordinates;

		private double[] madblCoordinates;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mdecThickness;

		private double mdblThickness;

		private object mdecElevation;

		private double mdblElevation;

		public object Coordinates
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCoordinates, madblCoordinates));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 11, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadSolid", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblElevation = 0.0;
				int num = Information.LBound((Array)value);
				int num2 = Information.UBound((Array)value);
				checked
				{
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 3)
					{
						bool flag2 = false;
						madblCoordinates[dlngIdx] = Conversions.ToDouble(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx
						}, null));
						madblCoordinates[dlngIdx + 1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 1
						}, null));
						madblCoordinates[dlngIdx + 2] = mdblElevation;
					}
				}
			}
		}

		public object Coordinate
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(InternGetCoordinate(vlngIndex));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (!(vlngIndex >= 0 && vlngIndex <= 3))
				{
					return;
				}
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadSolid", dstrErrMsg);
					return;
				}
				int dlngIdx = 0;
				checked
				{
					do
					{
						bool flag = false;
						madblCoordinates[vlngIndex * 3 + dlngIdx] = Conversions.ToDouble(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx
						}, null));
						dlngIdx++;
					}
					while (dlngIdx <= 3);
				}
			}
		}

		public object Elevation
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecElevation), mdblElevation));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecElevation;
				ref double reference = ref mdblElevation;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadSolid", dstrErrMsg);
					return;
				}
				bool flag = false;
				madblCoordinates[2] = mdblElevation;
				madblCoordinates[5] = mdblElevation;
				madblCoordinates[8] = mdblElevation;
				madblCoordinates[11] = mdblElevation;
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
					Information.Err().Raise(50000, "AcadSolid", dstrErrMsg);
				}
			}
		}

		public object Thickness
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecThickness), mdblThickness));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecThickness;
				ref double reference = ref mdblThickness;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadSolid", dstrErrMsg);
				}
			}
		}

		public bool Is2DWorld => Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		0
		}, null), 0m, TextCompare: false), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		1
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		2
		}, null), 1m, TextCompare: false)), Operators.CompareObjectEqual(Elevation, 0m, TextCompare: false)), Operators.CompareObjectEqual(Thickness, 0m, TextCompare: false)));

		public AcadSolid()
		{
			madecCoordinates = new object[12];
			madblCoordinates = new double[12];
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 349;
			base.FriendLetNodeImageDisabledID = 350;
			base.FriendLetNodeName = "Solid";
			base.FriendLetNodeText = "Solid";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblElevation = hwpDxf_Vars.pdblElevation;
			int num = Information.LBound(madblCoordinates);
			int num2 = Information.UBound(madblCoordinates);
			checked
			{
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 3)
				{
					madblCoordinates[dlngIdx] = hwpDxf_Vars.padblCoordinate[0];
					madblCoordinates[dlngIdx + 1] = hwpDxf_Vars.padblCoordinate[1];
					madblCoordinates[dlngIdx + 2] = mdblElevation;
				}
				madblNormal[0] = hwpDxf_Vars.padblNormal[0];
				madblNormal[1] = hwpDxf_Vars.padblNormal[1];
				madblNormal[2] = hwpDxf_Vars.padblNormal[2];
				mdblThickness = hwpDxf_Vars.pdblThickness;
				base.FriendLetDXFName = "SOLID";
				base.FriendLetObjectName = "AcDbTrace";
				base.FriendLetEntityType = Enums.AcEntityName.acSolid;
			}
		}

		~AcadSolid()
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

		public object GetCoordinate(int vlngIndex)
		{
			return RuntimeHelpers.GetObjectValue(InternGetCoordinate(vlngIndex));
		}

		private object InternGetCoordinate(int vlngIndex)
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			if (vlngIndex >= 0 && vlngIndex <= 3)
			{
				bool flag = false;
				checked
				{
					dadblCoordinate[0] = madblCoordinates[vlngIndex * 3];
					dadblCoordinate[1] = madblCoordinates[vlngIndex * 3 + 1];
					dadblCoordinate[2] = madblCoordinates[vlngIndex * 3 + 2];
					return Support.CopyArray(dadblCoordinate);
				}
			}
			object InternGetCoordinate = default(object);
			return InternGetCoordinate;
		}
	}

}
