using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_Unit
	{
		public static object BkDXFUnit_ScaleInvFac(hwpDxf_Enums.UNITS_BASE vnumUnitsBase, hwpDxf_Enums.UNITS_METRIC vnumOldUnitsMetric, hwpDxf_Enums.UNITS_METRIC vnumNewUnitsMetric, hwpDxf_Enums.UNITS_BRITISCH vnumOldUnitsBritish, hwpDxf_Enums.UNITS_BRITISCH vnumNewUnitsBritish)
		{
			object dvarFac2 = RuntimeHelpers.GetObjectValue(BkDXFUnit_ScaleFac(vnumUnitsBase, vnumOldUnitsMetric, vnumNewUnitsMetric, vnumOldUnitsBritish, vnumNewUnitsBritish));
			dvarFac2 = ((!Operators.ConditionalCompareObjectEqual(dvarFac2, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false)) ? Operators.DivideObject(Interaction.IIf(Expression: false, 1m, 1.0), dvarFac2) : RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)));
			return RuntimeHelpers.GetObjectValue(dvarFac2);
		}

		public static object BkDXFUnit_ScaleFac(hwpDxf_Enums.UNITS_BASE vnumUnitsBase, hwpDxf_Enums.UNITS_METRIC vnumOldUnitsMetric, hwpDxf_Enums.UNITS_METRIC vnumNewUnitsMetric, hwpDxf_Enums.UNITS_BRITISCH vnumOldUnitsBritish, hwpDxf_Enums.UNITS_BRITISCH vnumNewUnitsBritish)
		{
			switch (vnumUnitsBase)
			{
				case hwpDxf_Enums.UNITS_BASE.unBritish:
					return RuntimeHelpers.GetObjectValue(BkDXFUnit_BritishFac(vnumOldUnitsBritish, vnumNewUnitsBritish));
				case hwpDxf_Enums.UNITS_BASE.unMetric:
					return RuntimeHelpers.GetObjectValue(BkDXFUnit_MetricFac(vnumOldUnitsMetric, vnumNewUnitsMetric));
				default:
					return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			}
		}

		public static object BkDXFUnit_MetricFac(hwpDxf_Enums.UNITS_METRIC vnumOldUnitsMetric, hwpDxf_Enums.UNITS_METRIC vnumNewUnitsMetric)
		{
			return Operators.ExponentObject(Interaction.IIf(Expression: false, new decimal(10L), 10.0), (double)vnumNewUnitsMetric - (double)vnumOldUnitsMetric);
		}

		public static object BkDXFUnit_BritishFac(hwpDxf_Enums.UNITS_BRITISCH vnumOldUnitsBritish, hwpDxf_Enums.UNITS_BRITISCH vnumNewUnitsBritish)
		{
			object dvarInchToFoot = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(12L), 12.0));
			object dvarFootToYard = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(3L), 3.0));
			object dvarYardToMile = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(1760L), 1760.0));
			object dvarFac = (vnumOldUnitsBritish == vnumNewUnitsBritish) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : (((double)vnumOldUnitsBritish == 0.0 || (double)vnumNewUnitsBritish == 0.0) ? (((double)vnumOldUnitsBritish == 1.0 || (double)vnumNewUnitsBritish == 1.0) ? RuntimeHelpers.GetObjectValue(dvarInchToFoot) : (((double)vnumOldUnitsBritish == 2.0 || (double)vnumNewUnitsBritish == 2.0) ? Operators.MultiplyObject(dvarInchToFoot, dvarFootToYard) : ((!((double)vnumOldUnitsBritish == 3.0 || (double)vnumNewUnitsBritish == 3.0)) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : Operators.MultiplyObject(Operators.MultiplyObject(dvarInchToFoot, dvarFootToYard), dvarYardToMile)))) : (((double)vnumOldUnitsBritish == 1.0 || (double)vnumNewUnitsBritish == 1.0) ? (((double)vnumOldUnitsBritish == 0.0 || (double)vnumNewUnitsBritish == 0.0) ? RuntimeHelpers.GetObjectValue(dvarInchToFoot) : (((double)vnumOldUnitsBritish == 2.0 || (double)vnumNewUnitsBritish == 2.0) ? RuntimeHelpers.GetObjectValue(dvarFootToYard) : ((!((double)vnumOldUnitsBritish == 3.0 || (double)vnumNewUnitsBritish == 3.0)) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : Operators.MultiplyObject(dvarFootToYard, dvarYardToMile)))) : (((double)vnumOldUnitsBritish == 2.0 || (double)vnumNewUnitsBritish == 2.0) ? (((double)vnumOldUnitsBritish == 0.0 || (double)vnumNewUnitsBritish == 0.0) ? Operators.MultiplyObject(dvarFootToYard, dvarInchToFoot) : (((double)vnumOldUnitsBritish == 1.0 || (double)vnumNewUnitsBritish == 1.0) ? RuntimeHelpers.GetObjectValue(dvarFootToYard) : ((!((double)vnumOldUnitsBritish == 3.0 || (double)vnumNewUnitsBritish == 3.0)) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : RuntimeHelpers.GetObjectValue(dvarYardToMile)))) : ((!((double)vnumOldUnitsBritish == 3.0 || (double)vnumNewUnitsBritish == 3.0)) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : (((double)vnumOldUnitsBritish == 0.0 || (double)vnumNewUnitsBritish == 0.0) ? Operators.MultiplyObject(Operators.MultiplyObject(dvarYardToMile, dvarFootToYard), dvarInchToFoot) : (((double)vnumOldUnitsBritish == 1.0 || (double)vnumNewUnitsBritish == 1.0) ? Operators.MultiplyObject(dvarYardToMile, dvarFootToYard) : ((!((double)vnumOldUnitsBritish == 2.0 || (double)vnumNewUnitsBritish == 2.0)) ? RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)) : RuntimeHelpers.GetObjectValue(dvarYardToMile))))))));
			if (vnumOldUnitsBritish > vnumNewUnitsBritish)
			{
				dvarFac = Operators.DivideObject(Interaction.IIf(Expression: false, 1m, 1.0), dvarFac);
			}
			return RuntimeHelpers.GetObjectValue(dvarFac);
		}
	}
}
