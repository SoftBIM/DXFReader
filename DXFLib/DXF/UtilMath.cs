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
    public class UtilMath
	{
		private const string cstrClassName = "UtilMath";

		private const int clngAngRound = 16;

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private object InternConvDec(object vvarValue)
		{
			bool dblnValid = false;
			object dvarValue = RuntimeHelpers.GetObjectValue(vvarValue);
			try
			{
				dvarValue = Conversions.ToDecimal(vvarValue);
				dblnValid = true;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex2 = ex3;
				ProjectData.ClearProjectError();
			}
			if (!dblnValid)
			{
				try
				{
					dvarValue = Conversions.ToDouble(vvarValue);
					dblnValid = true;
				}
				catch (Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					Exception ex = ex4;
					ProjectData.ClearProjectError();
				}
			}
			if (!dblnValid)
			{
				Information.Err().Raise(50000, "UtilMath", "Ungültiger Variablentyp.");
			}
			return RuntimeHelpers.GetObjectValue(dvarValue);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private object InternConvDbl(object vvarValue)
		{
			bool dblnValid = false;
			object dvarValue = RuntimeHelpers.GetObjectValue(vvarValue);
			try
			{
				dvarValue = Conversions.ToDouble(vvarValue);
				dblnValid = true;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
			}
			if (!dblnValid)
			{
				Information.Err().Raise(50000, "UtilMath", "Ungültiger Variablentyp.");
			}
			return RuntimeHelpers.GetObjectValue(dvarValue);
		}

		private object InternConvValue(object vvarValue)
		{
			bool flag = false;
			object dvarValue = RuntimeHelpers.GetObjectValue(InternConvDbl(RuntimeHelpers.GetObjectValue(vvarValue)));
			return RuntimeHelpers.GetObjectValue(dvarValue);
		}

		private object InternConv2Array(object vvar2Array)
		{
			return Support.CopyArray(new object[2]
			{
			RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvar2Array, new object[1]
			{
				0
			}, null)))),
			RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvar2Array, new object[1]
			{
				1
			}, null))))
			});
		}

		private object InternConv3Array(object vvar3Array)
		{
			return Support.CopyArray(new object[3]
			{
			RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvar3Array, new object[1]
			{
				0
			}, null)))),
			RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvar3Array, new object[1]
			{
				1
			}, null)))),
			RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvar3Array, new object[1]
			{
				2
			}, null))))
			});
		}

		public object Pi()
		{
			bool flag = false;
			return Conversions.ToDouble("3,1415926535897932384626433832795");
		}

		public object AngRad2Deg(object vvarRad)
		{
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			return Operators.DivideObject(Operators.MultiplyObject(vvarRad, Interaction.IIf(Expression: false, new decimal(180L), 180.0)), Pi());
		}

		public object AngDeg2Rad(object vvarDegree)
		{
			vvarDegree = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarDegree)));
			return Operators.DivideObject(Operators.MultiplyObject(vvarDegree, Pi()), Interaction.IIf(Expression: false, new decimal(180L), 180.0));
		}

		public object AngRad0()
		{
			return RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0))));
		}

		public object AngRad90()
		{
			return RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(90L), 90.0))));
		}

		public object AngRad180()
		{
			return RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(180L), 180.0))));
		}

		public object AngRad270()
		{
			return RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(270L), 270.0))));
		}

		public object AngRad360()
		{
			return RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(360L), 360.0))));
		}

		public object AngTangens(object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			return Math.Tan(Conversions.ToDouble(vvarAngle));
		}

		public object AngArcusTangens(object vvarValue, bool nvblnAngleInDegree = false)
		{
			vvarValue = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarValue)));
			object dvarAngle = Math.Atan(Conversions.ToDouble(vvarValue));
			if (nvblnAngleInDegree)
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle);
		}

		public object AngCosinus(object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			return Math.Cos(Conversions.ToDouble(vvarAngle));
		}

		public object AngArcusCosinus(object vvarValue, bool nvblnAngleInDegree = false)
		{
			vvarValue = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarValue)));
			object left = vvarValue;
			object dvarAngle2;
			if (Operators.ConditionalCompareObjectEqual(left, Interaction.IIf(Expression: false, 1m, 1.0), TextCompare: false))
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			else if (Operators.ConditionalCompareObjectEqual(left, Interaction.IIf(Expression: false, -1m, -1.0), TextCompare: false))
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(AngRad180());
			}
			else
			{
				bool flag = false;
				dvarAngle2 = Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
				Operators.SubtractObject(1.0, Operators.ExponentObject(vvarValue, 2.0))
				}, null, null, null)));
				dvarAngle2 = ((!Operators.ConditionalCompareObjectEqual(dvarAngle2, 0.0, TextCompare: false)) ? ((object)(Math.Atan(Conversions.ToDouble(Operators.DivideObject(Operators.MultiplyObject(-1.0, vvarValue), dvarAngle2))) + 2.0 * Math.Atan(1.0))) : ((object)0.0));
			}
			if (nvblnAngleInDegree)
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle2)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle2);
		}

		public object AngSinus(object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			return Math.Sin(Conversions.ToDouble(vvarAngle));
		}

		public object AngArcusSinus(object vvarValue, bool nvblnAngleInDegree = false)
		{
			vvarValue = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarValue)));
			object left = vvarValue;
			object dvarAngle;
			if (Operators.ConditionalCompareObjectEqual(left, Interaction.IIf(Expression: false, 1m, 1.0), TextCompare: false))
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(AngRad90());
			}
			else if (Operators.ConditionalCompareObjectEqual(left, Interaction.IIf(Expression: false, -1m, -1.0), TextCompare: false))
			{
				dvarAngle = Operators.MultiplyObject(AngRad90(), Interaction.IIf(Expression: false, -1m, -1.0));
			}
			else
			{
				bool flag = false;
				dvarAngle = Math.Atan(Conversions.ToDouble(Operators.DivideObject(vvarValue, Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
				Operators.SubtractObject(1.0, Operators.ExponentObject(vvarValue, 2.0))
				}, null, null, null))))));
			}
			if (nvblnAngleInDegree)
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle);
		}

		public object AngSub(object vvarAngle, bool vblnReturn360, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			object dvarFullAngle = RuntimeHelpers.GetObjectValue(AngRad360());
			if (vblnReturn360)
			{
				Type typeFromHandle = typeof(Math);
				object[] obj = new object[1]
				{
				vvarAngle
				};
				object[] array = obj;
				bool[] obj2 = new bool[1]
				{
				true
				};
				bool[] array2 = obj2;
				object left = NewLateBinding.LateGet(null, typeFromHandle, "Abs", obj, null, null, obj2);
				if (array2[0])
				{
					vvarAngle = RuntimeHelpers.GetObjectValue(array[0]);
				}
				if (Operators.ConditionalCompareObjectGreater(left, dvarFullAngle, TextCompare: false))
				{
					vvarAngle = Operators.SubtractObject(vvarAngle, Operators.MultiplyObject(Conversion.Fix(Operators.DivideObject(vvarAngle, dvarFullAngle)), dvarFullAngle));
				}
			}
			else
			{
				Type typeFromHandle2 = typeof(Math);
				object[] obj3 = new object[1]
				{
				vvarAngle
				};
				object[] array = obj3;
				bool[] obj4 = new bool[1]
				{
				true
				};
				bool[] array2 = obj4;
				object left2 = NewLateBinding.LateGet(null, typeFromHandle2, "Abs", obj3, null, null, obj4);
				if (array2[0])
				{
					vvarAngle = RuntimeHelpers.GetObjectValue(array[0]);
				}
				if (Operators.ConditionalCompareObjectGreaterEqual(left2, dvarFullAngle, TextCompare: false))
				{
					vvarAngle = Operators.SubtractObject(vvarAngle, Operators.MultiplyObject(Conversion.Fix(Operators.DivideObject(vvarAngle, dvarFullAngle)), dvarFullAngle));
				}
			}
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			return RuntimeHelpers.GetObjectValue(vvarAngle);
		}

		public object Determinate33(object vvarRow1, object vvarRow2, object vvarRow3)
		{
			return Operators.MultiplyObject(Interaction.IIf(Expression: false, 1m, 1.0), Operators.SubtractObject(Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			1
			}, null)), NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			2
			}, null)), Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			2
			}, null)), NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			0
			}, null))), Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			0
			}, null)), NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			1
			}, null))), Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			1
			}, null)), NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			2
			}, null)), Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			2
			}, null)), NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			0
			}, null))), Operators.MultiplyObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarRow3, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarRow2, new object[1]
			{
			0
			}, null)), NewLateBinding.LateIndexGet(vvarRow1, new object[1]
			{
			1
			}, null)))));
		}

		public object Vector(object vvarPoint1, object vvarPoint2)
		{
			object[] davarVector = new object[3];
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			davarVector[0] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			1
			}, null));
			davarVector[2] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			2
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object Vector2D(object vvarPoint1, object vvarPoint2)
		{
			object[] davarVector = new object[2];
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			davarVector[0] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			1
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object VecLength(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			bool flag = false;
			return Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			Operators.AddObject(Operators.AddObject(Operators.ExponentObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
				0
			}, null), 2.0), Operators.ExponentObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
				1
			}, null), 2.0)), Operators.ExponentObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
				2
			}, null), 2.0))
			}, null, null, null)));
		}

		public object VecRotate2D(object vvarVector, object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			object dvarCoordX = Operators.SubtractObject(Operators.MultiplyObject(AngCosinus(RuntimeHelpers.GetObjectValue(vvarAngle)), NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			0
			}, null)), Operators.MultiplyObject(AngSinus(RuntimeHelpers.GetObjectValue(vvarAngle)), NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			1
			}, null)));
			object dvarCoordY = default(object);
			return new object[2]
			{
			dvarCoordX,
			dvarCoordY
			};
		}

		public object VecLength2D(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			bool flag = false;
			return Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			Operators.AddObject(Operators.ExponentObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
				0
			}, null), 2.0), Operators.ExponentObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
				1
			}, null), 2.0))
			}, null, null, null)));
		}

		public bool VecIsNull(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			return Operators.ConditionalCompareObjectEqual(VecLength(RuntimeHelpers.GetObjectValue(vvarVector)), Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false);
		}

		public bool VecIsNorm(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			return Operators.ConditionalCompareObjectEqual(VecLength(RuntimeHelpers.GetObjectValue(vvarVector)), Interaction.IIf(Expression: false, 1m, 1.0), TextCompare: false);
		}

		public object VecCosinus(object vvarVector, short vintAxis)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			object dvarLen = RuntimeHelpers.GetObjectValue(VecLength(RuntimeHelpers.GetObjectValue(vvarVector)));
			object dvarCos = default(object);
			switch (vintAxis)
			{
				case 1:
					dvarCos = Operators.DivideObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
					{
				0
					}, null), dvarLen);
					break;
				case 2:
					dvarCos = Operators.DivideObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
					{
				1
					}, null), dvarLen);
					break;
				case 3:
					dvarCos = Operators.DivideObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
					{
				2
					}, null), dvarLen);
					break;
			}
			return RuntimeHelpers.GetObjectValue(dvarCos);
		}

		public object VecByLenCos(object vvarVecLength, object vvarCosinusX, object vvarCosinusY, object vvarCosinusZ)
		{
			object[] davarVector = new object[3];
			vvarVecLength = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarVecLength)));
			vvarCosinusX = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCosinusX)));
			vvarCosinusY = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCosinusY)));
			vvarCosinusZ = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCosinusZ)));
			davarVector[0] = Operators.MultiplyObject(vvarVecLength, vvarCosinusX);
			davarVector[1] = Operators.MultiplyObject(vvarVecLength, vvarCosinusY);
			davarVector[2] = Operators.MultiplyObject(vvarVecLength, vvarCosinusZ);
			return Support.CopyArray(davarVector);
		}

		public object VecByLenCos2D(object vvarVecLength, object vvarCosinusX, object vvarCosinusY)
		{
			object[] davarVector = new object[2];
			vvarVecLength = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarVecLength)));
			vvarCosinusX = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCosinusX)));
			vvarCosinusY = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCosinusY)));
			davarVector[0] = Operators.MultiplyObject(vvarVecLength, vvarCosinusX);
			davarVector[1] = Operators.MultiplyObject(vvarVecLength, vvarCosinusY);
			return Support.CopyArray(davarVector);
		}

		public object VecAddTwo(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[3];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = Operators.AddObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.AddObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null));
			davarVector[2] = Operators.AddObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			2
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object VecAddTwo2D(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[2];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = Operators.AddObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.AddObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object VecSubTwo(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[3];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null));
			davarVector[2] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			2
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object VecSubTwo2D(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[2];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null));
			davarVector[1] = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null));
			return Support.CopyArray(davarVector);
		}

		public object VecScalar(object vvarVector, object vvarScalar)
		{
			object[] davarVector = new object[3];
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			vvarScalar = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarScalar)));
			davarVector[0] = Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			0
			}, null), vvarScalar);
			davarVector[1] = Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			1
			}, null), vvarScalar);
			davarVector[2] = Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			2
			}, null), vvarScalar);
			return Support.CopyArray(davarVector);
		}

		public object VecScalar2D(object vvarVector, object vvarScalar)
		{
			object[] davarVector = new object[2];
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			vvarScalar = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarScalar)));
			davarVector[0] = Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			0
			}, null), vvarScalar);
			davarVector[1] = Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector, new object[1]
			{
			1
			}, null), vvarScalar);
			return Support.CopyArray(davarVector);
		}

		public object VecMirr(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			return RuntimeHelpers.GetObjectValue(VecScalar(RuntimeHelpers.GetObjectValue(vvarVector), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, -1m, -1.0))));
		}

		public object VecScalProd(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			return Operators.AddObject(Operators.AddObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null)), Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null))), Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			2
			}, null)));
		}

		public bool VecOrthogonal(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			return Operators.ConditionalCompareObjectEqual(VecScalProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)), Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false);
		}

		public object VecIntCos(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			return Operators.DivideObject(VecScalProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)), Operators.MultiplyObject(VecLength(RuntimeHelpers.GetObjectValue(vvarVector1)), VecLength(RuntimeHelpers.GetObjectValue(vvarVector2))));
		}

		public object VecProd(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[3];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = Operators.SubtractObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			2
			}, null)), Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null)));
			davarVector[1] = Operators.SubtractObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null)), Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			2
			}, null)));
			davarVector[2] = Operators.SubtractObject(Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			1
			}, null)), Operators.MultiplyObject(NewLateBinding.LateIndexGet(vvarVector1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarVector2, new object[1]
			{
			0
			}, null)));
			return Support.CopyArray(davarVector);
		}

		public object VecProdLength(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			return RuntimeHelpers.GetObjectValue(VecLength(RuntimeHelpers.GetObjectValue(VecProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)))));
		}

		public object VecProdLengthDet(object vvarVector1, object vvarVector2)
		{
			object[] davarVector = new object[3];
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			davarVector[0] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			davarVector[1] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			davarVector[2] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			return RuntimeHelpers.GetObjectValue(Determinate33(davarVector, RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)));
		}

		public bool VecKollinear(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			object dvarVector = RuntimeHelpers.GetObjectValue(VecProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)));
			return Operators.ConditionalCompareObjectEqual(VecLength(RuntimeHelpers.GetObjectValue(dvarVector)), Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false);
		}

		public object VecSpatProd(object vvarVector1, object vvarVector2, object vvarVector3)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			vvarVector3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector3)));
			object vvarVector4 = RuntimeHelpers.GetObjectValue(VecProd(RuntimeHelpers.GetObjectValue(vvarVector2), RuntimeHelpers.GetObjectValue(vvarVector3)));
			return RuntimeHelpers.GetObjectValue(VecScalProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector4)));
		}

		public object VecSpatProdDet(object vvarVector1, object vvarVector2, object vvarVector3)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			vvarVector3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector3)));
			return RuntimeHelpers.GetObjectValue(Determinate33(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2), RuntimeHelpers.GetObjectValue(vvarVector3)));
		}

		public bool VecKomplanar(object vvarVector1, object vvarVector2, object vvarVector3)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			vvarVector3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector3)));
			return Operators.ConditionalCompareObjectEqual(VecSpatProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2), RuntimeHelpers.GetObjectValue(vvarVector3)), Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false);
		}

		public object VecXAng(object vvarVector, bool nvblnAngleInDegree = false)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			NewLateBinding.LateIndexSet(vvarVector, new object[2]
			{
			2,
			Interaction.IIf(Expression: false, 0m, 0.0)
			}, null);
			object dvarAngle;
			if (VecIsNull(RuntimeHelpers.GetObjectValue(vvarVector)))
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			else
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(AngArcusCosinus(RuntimeHelpers.GetObjectValue(VecCosinus(RuntimeHelpers.GetObjectValue(vvarVector), 1))));
				object dvarProdLengthDet = RuntimeHelpers.GetObjectValue(VecProdLengthDet(RuntimeHelpers.GetObjectValue(vvarVector), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new object[3]
				{
				1m,
				0m,
				0m
				}, new object[3]
				{
				1.0,
				0.0,
				0.0
				}))));
				if (Operators.ConditionalCompareObjectGreater(dvarProdLengthDet, 0, TextCompare: false))
				{
					dvarAngle = Operators.SubtractObject(AngRad360(), dvarAngle);
				}
			}
			if (nvblnAngleInDegree)
			{
				dvarAngle = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle);
		}

		public object VecNorm(object vvarVector)
		{
			vvarVector = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector)));
			object dvarLength = RuntimeHelpers.GetObjectValue(VecLength(RuntimeHelpers.GetObjectValue(vvarVector)));
			object dvarVector = (!Operators.ConditionalCompareObjectEqual(dvarLength, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(VecScalar(RuntimeHelpers.GetObjectValue(vvarVector), Operators.DivideObject(Interaction.IIf(Expression: false, 1m, 1.0), dvarLength))) : RuntimeHelpers.GetObjectValue(vvarVector);
			return RuntimeHelpers.GetObjectValue(dvarVector);
		}

		public object VecProjection(object vvarVector1, object vvarVector2)
		{
			vvarVector1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector1)));
			vvarVector2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarVector2)));
			return RuntimeHelpers.GetObjectValue(VecScalar(RuntimeHelpers.GetObjectValue(vvarVector2), Operators.DivideObject(VecScalProd(RuntimeHelpers.GetObjectValue(vvarVector1), RuntimeHelpers.GetObjectValue(vvarVector2)), VecScalProd(RuntimeHelpers.GetObjectValue(vvarVector2), RuntimeHelpers.GetObjectValue(vvarVector2)))));
		}

		public object VecNormX()
		{
			return Support.CopyArray(new object[3]
			{
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0))
			});
		}

		public object VecNormY()
		{
			return Support.CopyArray(new object[3]
			{
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0))
			});
		}

		public object VecNormZ()
		{
			return Support.CopyArray(new object[3]
			{
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0)),
			RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0))
			});
		}

		public object Point2DTo3D(object vvarPoint2D)
		{
			object[] davarPoint3D = new object[3];
			vvarPoint2D = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2D)));
			davarPoint3D[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint2D, new object[1]
			{
			0
			}, null));
			davarPoint3D[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint2D, new object[1]
			{
			1
			}, null));
			davarPoint3D[2] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			return Support.CopyArray(davarPoint3D);
		}

		public object Point3DTo2D(object vvarPoint3D)
		{
			object[] davarPoint2D = new object[2];
			vvarPoint3D = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint3D)));
			davarPoint2D[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint3D, new object[1]
			{
			0
			}, null));
			davarPoint2D[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint3D, new object[1]
			{
			1
			}, null));
			return Support.CopyArray(davarPoint2D);
		}

		public object AngSweep(object vvarBegAngle, object vvarEndAngle, bool nvblnAngleInDegree = false)
		{
			vvarBegAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBegAngle)));
			vvarEndAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarEndAngle)));
			if (nvblnAngleInDegree)
			{
				vvarBegAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarBegAngle)));
				vvarEndAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarEndAngle)));
			}
			object dvarSweepAngle;
			if (Operators.ConditionalCompareObjectLess(vvarBegAngle, vvarEndAngle, TextCompare: false))
			{
				dvarSweepAngle = Operators.SubtractObject(vvarEndAngle, vvarBegAngle);
			}
			else if (Operators.ConditionalCompareObjectGreater(vvarBegAngle, vvarEndAngle, TextCompare: false))
			{
				object dvarRad360 = RuntimeHelpers.GetObjectValue(AngRad360());
				dvarSweepAngle = Operators.AddObject(Operators.SubtractObject(dvarRad360, vvarBegAngle), vvarEndAngle);
			}
			else
			{
				dvarSweepAngle = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			if (nvblnAngleInDegree)
			{
				dvarSweepAngle = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarSweepAngle)));
			}
			return RuntimeHelpers.GetObjectValue(dvarSweepAngle);
		}

		public object AngRadArcArea(object vvarAngle, object vvarRad, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			object dvarRad180 = RuntimeHelpers.GetObjectValue(AngRad180());
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			object dvarHighVal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
			object dvarDiv = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
			return Operators.MultiplyObject(Operators.DivideObject(Operators.ExponentObject(vvarRad, dvarHighVal), dvarDiv), Operators.SubtractObject(Operators.DivideObject(Operators.MultiplyObject(Pi(), vvarAngle), dvarRad180), Math.Sin(Conversions.ToDouble(vvarAngle))));
		}

		public object BulgeAng(object vvarBulge, bool nvblnAngleInDegree = false)
		{
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarAngle2 = Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(4L), 4.0), Math.Atan(Conversions.ToDouble(vvarBulge)));
			dvarAngle2 = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(dvarAngle2), vblnReturn360: false));
			if (nvblnAngleInDegree)
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle2)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle2);
		}

		public object AngBulge(object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			return Math.Tan(Conversions.ToDouble(Operators.DivideObject(vvarAngle, Interaction.IIf(Expression: false, new decimal(4L), 4.0))));
		}

		public object BulgeChordArcHeight(object vvarBulge, object vvarChord)
		{
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			return Operators.DivideObject(Operators.MultiplyObject(vvarBulge, vvarChord), Interaction.IIf(Expression: false, new decimal(2L), 2.0));
		}

		public object BulgeArcHeightChord(object vvarBulge, object vvarArcHeight)
		{
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			vvarArcHeight = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarArcHeight)));
			return Operators.DivideObject(Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(2L), 2.0), vvarArcHeight), vvarBulge);
		}

		public object ChordArcHeightBulge(object vvarChord, object vvarArcHeight)
		{
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			vvarArcHeight = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarArcHeight)));
			return Operators.DivideObject(Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(2L), 2.0), vvarArcHeight), vvarChord);
		}

		public object AngRadArcLen(object vvarAngle, object vvarRad, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			object dvarRad180 = RuntimeHelpers.GetObjectValue(AngRad180());
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			return Operators.MultiplyObject(Operators.MultiplyObject(Pi(), vvarRad), Operators.DivideObject(vvarAngle, dvarRad180));
		}

		public object AngArcLenRad(object vvarAngle, object vvarArcLen, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarArcLen = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarArcLen)));
			object dvarRad180 = RuntimeHelpers.GetObjectValue(AngRad180());
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			return Operators.DivideObject(vvarArcLen, Operators.MultiplyObject(Pi(), Operators.DivideObject(vvarAngle, dvarRad180)));
		}

		public object RadArcLenAng(object vvarRad, object vvarArcLen, bool nvblnAngleInDegree = false)
		{
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			vvarArcLen = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarArcLen)));
			object dvarRad180 = RuntimeHelpers.GetObjectValue(AngRad180());
			object dvarAngle2 = Operators.DivideObject(Operators.MultiplyObject(vvarArcLen, dvarRad180), Operators.MultiplyObject(Pi(), vvarRad));
			dvarAngle2 = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(dvarAngle2), vblnReturn360: false));
			if (nvblnAngleInDegree)
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(dvarAngle2)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle2);
		}

		public object AngRadChord(object vvarAngle, object vvarRad, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			if (Operators.ConditionalCompareObjectNotEqual(vvarAngle, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
				return Operators.MultiplyObject(Operators.MultiplyObject(dvarFac, vvarRad), Math.Sin(Conversions.ToDouble(Operators.DivideObject(vvarAngle, dvarFac))));
			}
			object AngRadChord = default(object);
			return AngRadChord;
		}

		public object AngChordRad(object vvarAngle, object vvarChord, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			if (Operators.ConditionalCompareObjectNotEqual(vvarAngle, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
				return Operators.DivideObject(vvarChord, Operators.MultiplyObject(dvarFac, Math.Sin(Conversions.ToDouble(Operators.DivideObject(vvarAngle, dvarFac)))));
			}
			object AngChordRad = default(object);
			return AngChordRad;
		}

		public object RadChordAng(object vvarRad, object vvarChord, bool nvblnAngleInDegree = false)
		{
			vvarRad = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRad)));
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			object dvarAngle2;
			if (Operators.ConditionalCompareObjectEqual(vvarRad, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			else
			{
				object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
				dvarAngle2 = Operators.MultiplyObject(AngArcusSinus(Operators.DivideObject(vvarChord, Operators.MultiplyObject(dvarFac, vvarRad))), dvarFac);
			}
			dvarAngle2 = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(dvarAngle2), vblnReturn360: false));
			if (nvblnAngleInDegree)
			{
				dvarAngle2 = RuntimeHelpers.GetObjectValue(AngRad2Deg(RuntimeHelpers.GetObjectValue(dvarAngle2)));
			}
			return RuntimeHelpers.GetObjectValue(dvarAngle2);
		}

		public object PointsBulgeArcArea(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarChord = RuntimeHelpers.GetObjectValue(PointsDist(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			return RuntimeHelpers.GetObjectValue(BulgeChordArcArea(RuntimeHelpers.GetObjectValue(vvarBulge), RuntimeHelpers.GetObjectValue(dvarChord)));
		}

		public object BulgeChordArcArea(object vvarBulge, object vvarChord)
		{
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			object dvarAngle = RuntimeHelpers.GetObjectValue(BulgeAng(RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarRad = RuntimeHelpers.GetObjectValue(AngChordRad(RuntimeHelpers.GetObjectValue(dvarAngle), RuntimeHelpers.GetObjectValue(vvarChord)));
			return RuntimeHelpers.GetObjectValue(AngRadArcArea(RuntimeHelpers.GetObjectValue(dvarAngle), RuntimeHelpers.GetObjectValue(dvarRad)));
		}

		public object AngChordCenHeight(object vvarAngle, object vvarChord, bool nvblnAngleInDegree = false)
		{
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			vvarChord = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarChord)));
			if (nvblnAngleInDegree)
			{
				vvarAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarAngle)));
			}
			vvarAngle = RuntimeHelpers.GetObjectValue(AngSub(RuntimeHelpers.GetObjectValue(vvarAngle), vblnReturn360: false));
			if (Operators.ConditionalCompareObjectNotEqual(vvarAngle, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
				return Operators.DivideObject(vvarChord, Operators.MultiplyObject(Math.Tan(Conversions.ToDouble(Operators.DivideObject(vvarAngle, dvarFac))), dvarFac));
			}
			object AngChordCenHeight = default(object);
			return AngChordCenHeight;
		}

		public object BulgedLineRad(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarRadius;
			if (Operators.ConditionalCompareObjectEqual(vvarBulge, 0, TextCompare: false))
			{
				dvarRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			else
			{
				object dvarChord = RuntimeHelpers.GetObjectValue(PointsDist(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
				object dvarAngle = RuntimeHelpers.GetObjectValue(BulgeAng(RuntimeHelpers.GetObjectValue(vvarBulge)));
				dvarRadius = RuntimeHelpers.GetObjectValue(AngChordRad(RuntimeHelpers.GetObjectValue(dvarAngle), RuntimeHelpers.GetObjectValue(dvarChord)));
			}
			return RuntimeHelpers.GetObjectValue(dvarRadius);
		}

		public object BulgedLineRad2D(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarRadius;
			if (Operators.ConditionalCompareObjectEqual(vvarBulge, 0, TextCompare: false))
			{
				dvarRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			else
			{
				object dvarChord = RuntimeHelpers.GetObjectValue(PointsDist2D(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
				object dvarAngle = RuntimeHelpers.GetObjectValue(BulgeAng(RuntimeHelpers.GetObjectValue(vvarBulge)));
				dvarRadius = RuntimeHelpers.GetObjectValue(AngChordRad(RuntimeHelpers.GetObjectValue(dvarAngle), RuntimeHelpers.GetObjectValue(dvarChord)));
			}
			return RuntimeHelpers.GetObjectValue(dvarRadius);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object BulgedLineCenter(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			object[] davarCenter3D = new object[3];
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			2
			}, null), TextCompare: false))
			{
				Information.Err().Raise(50000, "UtilMath", "Z-Koordinaten sind verschieden.");
			}
			object dvarPoint1 = RuntimeHelpers.GetObjectValue(Point3DTo2D(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(Point3DTo2D(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarCenter2D = RuntimeHelpers.GetObjectValue(BulgedLineCenter2D(RuntimeHelpers.GetObjectValue(dvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), RuntimeHelpers.GetObjectValue(vvarBulge)));
			davarCenter3D[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarCenter2D, new object[1]
			{
			0
			}, null));
			davarCenter3D[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarCenter2D, new object[1]
			{
			1
			}, null));
			davarCenter3D[2] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			2
			}, null));
			return Support.CopyArray(davarCenter3D);
		}

		public object BulgedLineCenter2D(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			object[] davarCenter = new object[2];
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			if (Operators.ConditionalCompareObjectEqual(vvarBulge, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				return RuntimeHelpers.GetObjectValue(PointsMid2D(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			}
			object dvarFac1 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			object dvarFac2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
			object dvarCot = Operators.DivideObject(Operators.SubtractObject(Operators.DivideObject(dvarFac1, vvarBulge), vvarBulge), dvarFac2);
			davarCenter[0] = Operators.DivideObject(Operators.SubtractObject(Operators.AddObject(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null)), Operators.MultiplyObject(Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			1
			}, null)), dvarCot)), dvarFac2);
			davarCenter[1] = Operators.DivideObject(Operators.AddObject(Operators.AddObject(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			1
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			1
			}, null)), Operators.MultiplyObject(Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null)), dvarCot)), dvarFac2);
			return Support.CopyArray(davarCenter);
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object BulgedLineLen(object vvarPoint1, object vvarPoint2, object vvarBulge)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarBulge = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBulge)));
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			2
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			2
			}, null), TextCompare: false))
			{
				Information.Err().Raise(50000, "UtilMath", "Z-Koordinaten sind verschieden.");
			}
			if (Operators.ConditionalCompareObjectEqual(vvarBulge, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))
			{
				return RuntimeHelpers.GetObjectValue(PointsDist(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			}
			object dvarCenter = RuntimeHelpers.GetObjectValue(BulgedLineCenter(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2), RuntimeHelpers.GetObjectValue(vvarBulge)));
			object dvarRad = RuntimeHelpers.GetObjectValue(PointsDist(RuntimeHelpers.GetObjectValue(dvarCenter), RuntimeHelpers.GetObjectValue(vvarPoint1)));
			object dvarAng = RuntimeHelpers.GetObjectValue(BulgeAng(RuntimeHelpers.GetObjectValue(vvarBulge)));
			return RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			AngRadArcLen(RuntimeHelpers.GetObjectValue(dvarAng), RuntimeHelpers.GetObjectValue(dvarRad))
			}, null, null, null));
		}

		public object PointsDist(object vvarPoint1, object vvarPoint2)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			return RuntimeHelpers.GetObjectValue(VecLength(RuntimeHelpers.GetObjectValue(dvarVector)));
		}

		public object PointsDist2D(object vvarPoint1, object vvarPoint2)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector = RuntimeHelpers.GetObjectValue(Vector2D(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			return RuntimeHelpers.GetObjectValue(VecLength2D(RuntimeHelpers.GetObjectValue(dvarVector)));
		}

		public object PointsMid(object vvarPoint1, object vvarPoint2)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(VecScalar(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0.5m, 0.5))));
			return RuntimeHelpers.GetObjectValue(VecAddTwo(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(dvarVector2)));
		}

		public object PointsMid2D(object vvarPoint1, object vvarPoint2)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector2D(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(VecScalar2D(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0.5m, 0.5))));
			return RuntimeHelpers.GetObjectValue(VecAddTwo2D(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(dvarVector2)));
		}

		public object PointsRotate2D(object vvarOrigin, object vvarPoint, object vvarAngle, bool nvblnAngleInDegree = false)
		{
			vvarOrigin = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarOrigin)));
			vvarPoint = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint)));
			vvarAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarAngle)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector2D(RuntimeHelpers.GetObjectValue(vvarOrigin), RuntimeHelpers.GetObjectValue(vvarPoint)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(VecRotate2D(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(vvarAngle), nvblnAngleInDegree));
			return RuntimeHelpers.GetObjectValue(VecAddTwo2D(RuntimeHelpers.GetObjectValue(vvarOrigin), RuntimeHelpers.GetObjectValue(dvarVector2)));
		}

		public object PointsGradient2D(object vvarPoint1, object vvarPoint2)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null), TextCompare: false))
			{
				object dvarDeltaX = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				0
				}, null));
				object dvarDeltaY = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				1
				}, null));
				return Operators.DivideObject(dvarDeltaY, dvarDeltaX);
			}
			return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
		}

		public bool PointsIntersYAxis2D(object vvarPoint1, object vvarPoint2, ref object rvarPoint3)
		{
			object[] dvarPoint3 = new object[2];
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
			{
			0
			}, null), TextCompare: false))
			{
				object dvarDeltaX = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				0
				}, null));
				object dvarDeltaY = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint2, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				1
				}, null));
				object dvarGradient = Operators.DivideObject(dvarDeltaY, dvarDeltaX);
				object dvarCoordY = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				1
				}, null), Operators.MultiplyObject(dvarGradient, NewLateBinding.LateIndexGet(vvarPoint1, new object[1]
				{
				0
				}, null)));
				dvarPoint3[0] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
				dvarPoint3[1] = RuntimeHelpers.GetObjectValue(dvarCoordY);
				rvarPoint3 = Support.CopyArray(dvarPoint3);
				return true;
			}
			bool PointsIntersYAxis2D = default(bool);
			return PointsIntersYAxis2D;
		}

		public bool PointsInters2D(object vvarPointA1, object vvarPointA2, object vvarPointB1, object vvarPointB2, ref object rvarPoint, bool nvblnCheckOnA = false, bool nvblnCheckOnB = false, short nvintPrec = 12)
		{
			object[] dvarPoint = new object[2];
			object dvarFac0 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			object dvarFac1p = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			object dvarFac1n = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, -1m, -1.0));
			vvarPointA1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPointA1)));
			vvarPointA2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPointA2)));
			vvarPointB1 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPointB1)));
			vvarPointB2 = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarPointB2)));
			object dvarGradientA;
			object dvarAxisAY;
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
			{
			0
			}, null), TextCompare: false))
			{
				dvarGradientA = Operators.DivideObject(Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
				{
				1
				}, null)), Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
				{
				0
				}, null)));
				dvarAxisAY = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
				{
				1
				}, null), Operators.MultiplyObject(dvarGradientA, NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
				{
				0
				}, null)));
			}
			else
			{
				dvarGradientA = RuntimeHelpers.GetObjectValue(dvarFac1p);
				dvarAxisAY = RuntimeHelpers.GetObjectValue(dvarFac0);
			}
			object dvarGradientB;
			object dvarAxisBY;
			if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
			{
			0
			}, null), NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
			{
			0
			}, null), TextCompare: false))
			{
				dvarGradientB = Operators.DivideObject(Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
				{
				1
				}, null)), Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
				{
				0
				}, null)));
				dvarAxisBY = Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
				{
				1
				}, null), Operators.MultiplyObject(dvarGradientB, NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
				{
				0
				}, null)));
			}
			else
			{
				dvarGradientB = RuntimeHelpers.GetObjectValue(dvarFac1p);
				dvarAxisBY = RuntimeHelpers.GetObjectValue(dvarFac0);
			}
			object dvarGradient = Operators.AddObject(dvarGradientA, Operators.MultiplyObject(dvarGradientB, dvarFac1n));
			object dvarAxisY = Operators.AddObject(dvarAxisAY, Operators.MultiplyObject(dvarAxisBY, dvarFac1n));
			if (Operators.ConditionalCompareObjectNotEqual(dvarGradient, dvarFac0, TextCompare: false))
			{
				object dvarCoordX = (!Operators.ConditionalCompareObjectEqual(dvarGradientA, dvarFac1p, TextCompare: false)) ? Operators.DivideObject(Operators.MultiplyObject(dvarAxisY, dvarFac1n), dvarGradient) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
				{
				0
				}, null));
				object dvarCoordY = (!Operators.ConditionalCompareObjectEqual(dvarGradientA, dvarFac1p, TextCompare: false)) ? Operators.AddObject(Operators.MultiplyObject(dvarGradientA, dvarCoordX), dvarAxisAY) : Operators.AddObject(Operators.MultiplyObject(dvarGradientB, dvarCoordX), dvarAxisBY);
				dvarPoint[0] = RuntimeHelpers.GetObjectValue(dvarCoordX);
				dvarPoint[1] = RuntimeHelpers.GetObjectValue(dvarCoordY);
				rvarPoint = Support.CopyArray(dvarPoint);
				if (!(nvblnCheckOnA || nvblnCheckOnB))
				{
					return true;
				}
				object left = nvblnCheckOnA;
				object[] array;
				bool[] array2;
				object obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
				{
				NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
					{
						0
					}, null), NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
					{
						0
					}, null))
				}, null, null, null),
				nvintPrec
				}, null, null, array2 = new bool[2]
				{
				false,
				true
				});
				if (array2[1])
				{
					nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
				}
				object left2 = obj;
				obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
				{
				Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
					{
						0
					}, null), dvarCoordX)
				}, null, null, null), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
					{
						0
					}, null), dvarCoordX)
				}, null, null, null)),
				nvintPrec
				}, null, null, array2 = new bool[2]
				{
				false,
				true
				});
				if (array2[1])
				{
					nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
				}
				object left3 = Operators.CompareObjectNotEqual(left2, obj, TextCompare: false);
				obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
				{
				NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
					{
						1
					}, null), NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
					{
						1
					}, null))
				}, null, null, null),
				nvintPrec
				}, null, null, array2 = new bool[2]
				{
				false,
				true
				});
				if (array2[1])
				{
					nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
				}
				object left4 = obj;
				obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
				{
				Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA1, new object[1]
					{
						1
					}, null), dvarCoordY)
				}, null, null, null), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
					Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointA2, new object[1]
					{
						1
					}, null), dvarCoordY)
				}, null, null, null)),
				nvintPrec
				}, null, null, array2 = new bool[2]
				{
				false,
				true
				});
				if (array2[1])
				{
					nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
				}
				if (!Conversions.ToBoolean(Operators.AndObject(left, Operators.OrObject(left3, Operators.CompareObjectNotEqual(left4, obj, TextCompare: false)))))
				{
					object left5 = nvblnCheckOnB;
					Type typeFromHandle = typeof(Math);
					object[] obj2 = new object[2]
					{
					NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
						{
							0
						}, null), NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
						{
							0
						}, null))
					}, null, null, null),
					nvintPrec
					};
					array = obj2;
					bool[] obj3 = new bool[2]
					{
					false,
					true
					};
					array2 = obj3;
					obj = NewLateBinding.LateGet(null, typeFromHandle, "Round", obj2, null, null, obj3);
					if (array2[1])
					{
						nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
					}
					object left6 = obj;
					obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
					{
					Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
						{
							0
						}, null), dvarCoordX)
					}, null, null, null), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
						{
							0
						}, null), dvarCoordX)
					}, null, null, null)),
					nvintPrec
					}, null, null, array2 = new bool[2]
					{
					false,
					true
					});
					if (array2[1])
					{
						nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
					}
					object left7 = Operators.CompareObjectNotEqual(left6, obj, TextCompare: false);
					obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
					{
					NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
						{
							1
						}, null), NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
						{
							1
						}, null))
					}, null, null, null),
					nvintPrec
					}, null, null, array2 = new bool[2]
					{
					false,
					true
					});
					if (array2[1])
					{
						nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
					}
					object left8 = obj;
					obj = NewLateBinding.LateGet(null, typeof(Math), "Round", array = new object[2]
					{
					Operators.AddObject(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB1, new object[1]
						{
							1
						}, null), dvarCoordY)
					}, null, null, null), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
						Operators.SubtractObject(NewLateBinding.LateIndexGet(vvarPointB2, new object[1]
						{
							1
						}, null), dvarCoordY)
					}, null, null, null)),
					nvintPrec
					}, null, null, array2 = new bool[2]
					{
					false,
					true
					});
					if (array2[1])
					{
						nvintPrec = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(short));
					}
					if (!Conversions.ToBoolean(Operators.AndObject(left5, Operators.OrObject(left7, Operators.CompareObjectNotEqual(left8, obj, TextCompare: false)))))
					{
						return true;
					}
				}
			}
			bool PointsInters2D = default(bool);
			return PointsInters2D;
		}

		public bool TriangleClockwise(object vvarPoint1, object vvarPoint2, object vvarPoint3)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarPoint3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint3)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint3)));
			return Operators.ConditionalCompareObjectLessEqual(VecProdLengthDet(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(dvarVector2)), Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false);
		}

		public object TriangleArea(object vvarPoint1, object vvarPoint2, object vvarPoint3)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarPoint3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint3)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint3)));
			return Operators.DivideObject(VecProdLength(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(dvarVector2)), Interaction.IIf(Expression: false, new decimal(2L), 2.0));
		}

		public object TriangleAreaDet(object vvarPoint1, object vvarPoint2, object vvarPoint3)
		{
			vvarPoint1 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint1)));
			vvarPoint2 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint2)));
			vvarPoint3 = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarPoint3)));
			object dvarVector1 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint2)));
			object dvarVector2 = RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarPoint1), RuntimeHelpers.GetObjectValue(vvarPoint3)));
			return Operators.DivideObject(VecProdLengthDet(RuntimeHelpers.GetObjectValue(dvarVector1), RuntimeHelpers.GetObjectValue(dvarVector2)), Interaction.IIf(Expression: false, new decimal(2L), 2.0));
		}

		public object LineLength(object vvarStartPoint, object vvarEndPoint)
		{
			vvarStartPoint = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarStartPoint)));
			vvarEndPoint = RuntimeHelpers.GetObjectValue(InternConv3Array(RuntimeHelpers.GetObjectValue(vvarEndPoint)));
			return RuntimeHelpers.GetObjectValue(VecLength(RuntimeHelpers.GetObjectValue(Vector(RuntimeHelpers.GetObjectValue(vvarStartPoint), RuntimeHelpers.GetObjectValue(vvarEndPoint)))));
		}

		public object EllipseArea(object vvarRadius1, object vvarRadius2)
		{
			vvarRadius1 = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius1)));
			vvarRadius2 = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius2)));
			return Operators.MultiplyObject(Operators.MultiplyObject(Pi(), vvarRadius1), vvarRadius2);
		}

		public object EllipseCircum(object vvarRadius1, object vvarRadius2)
		{
			vvarRadius1 = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius1)));
			vvarRadius2 = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius2)));
			if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectLessEqual(vvarRadius1, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false), Operators.CompareObjectLessEqual(vvarRadius2, Interaction.IIf(Expression: false, 0m, 0.0), TextCompare: false))))
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			}
			if (Operators.ConditionalCompareObjectLess(vvarRadius1, vvarRadius2, TextCompare: false))
			{
				object dvarTemp = RuntimeHelpers.GetObjectValue(vvarRadius1);
				vvarRadius1 = RuntimeHelpers.GetObjectValue(vvarRadius2);
				vvarRadius2 = RuntimeHelpers.GetObjectValue(dvarTemp);
			}
			object dvarLambda2 = Operators.DivideObject(Operators.SubtractObject(vvarRadius1, vvarRadius2), Operators.AddObject(vvarRadius1, vvarRadius2));
			dvarLambda2 = Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(3L), 3.0), Operators.ExponentObject(dvarLambda2, Interaction.IIf(Expression: false, new decimal(2L), 2.0)));
			return Operators.MultiplyObject(Operators.MultiplyObject(Operators.AddObject(vvarRadius1, vvarRadius2), Pi()), Operators.AddObject(1, Operators.DivideObject(dvarLambda2, Operators.AddObject(Interaction.IIf(Expression: false, new decimal(10L), 10.0), Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			Operators.SubtractObject(4, dvarLambda2)
			}, null, null, null)))))));
		}

		public object CircRadArea(object vvarRadius)
		{
			vvarRadius = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius)));
			return Operators.MultiplyObject(Pi(), Operators.ExponentObject(vvarRadius, Interaction.IIf(Expression: false, new decimal(2L), 2.0)));
		}

		public object CircAreaRad(object vvarArea)
		{
			vvarArea = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarArea)));
			return Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			Operators.DivideObject(vvarArea, Pi())
			}, null, null, null)));
		}

		public object CircRadCircum(object vvarRadius)
		{
			vvarRadius = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius)));
			return Operators.MultiplyObject(Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(2L), 2.0), Pi()), vvarRadius);
		}

		public object CircCircumRad(object vvarCircum)
		{
			vvarCircum = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarCircum)));
			return Operators.DivideObject(vvarCircum, Operators.MultiplyObject(Interaction.IIf(Expression: false, new decimal(2L), 2.0), Pi()));
		}

		public void ArcPoints2D(object vvarCentrum2D, object vvarRadius, object vvarBegAngle, object vvarEndAngle, ref object[] rvarBegPoint2D, ref object[] rvarEndPoint2D, bool nvblnAngleInDegree = false)
		{
			vvarCentrum2D = RuntimeHelpers.GetObjectValue(InternConv2Array(RuntimeHelpers.GetObjectValue(vvarCentrum2D)));
			vvarRadius = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarRadius)));
			vvarBegAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarBegAngle)));
			vvarEndAngle = RuntimeHelpers.GetObjectValue(InternConvValue(RuntimeHelpers.GetObjectValue(vvarEndAngle)));
			if (nvblnAngleInDegree)
			{
				vvarBegAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarBegAngle)));
				vvarEndAngle = RuntimeHelpers.GetObjectValue(AngDeg2Rad(RuntimeHelpers.GetObjectValue(vvarEndAngle)));
			}
			object dvarRad90 = RuntimeHelpers.GetObjectValue(AngRad90());
			object dvarCosBegAngX = Math.Cos(Conversions.ToDouble(vvarBegAngle));
			object dvarCosEndAngX = Math.Cos(Conversions.ToDouble(vvarEndAngle));
			object dvarCosBegAngY = Math.Cos(Conversions.ToDouble(Operators.SubtractObject(dvarRad90, vvarBegAngle)));
			object dvarCosEndAngY = Math.Cos(Conversions.ToDouble(Operators.SubtractObject(dvarRad90, vvarEndAngle)));
			object dvarVecBeg = RuntimeHelpers.GetObjectValue(VecByLenCos2D(RuntimeHelpers.GetObjectValue(vvarRadius), RuntimeHelpers.GetObjectValue(dvarCosBegAngX), RuntimeHelpers.GetObjectValue(dvarCosBegAngY)));
			object dvarVecEnd = RuntimeHelpers.GetObjectValue(VecByLenCos2D(RuntimeHelpers.GetObjectValue(vvarRadius), RuntimeHelpers.GetObjectValue(dvarCosEndAngX), RuntimeHelpers.GetObjectValue(dvarCosEndAngY)));
			object dvarBegPoint2D = RuntimeHelpers.GetObjectValue(VecAddTwo2D(RuntimeHelpers.GetObjectValue(vvarCentrum2D), RuntimeHelpers.GetObjectValue(dvarVecBeg)));
			object dvarEndPoint2D = RuntimeHelpers.GetObjectValue(VecAddTwo2D(RuntimeHelpers.GetObjectValue(vvarCentrum2D), RuntimeHelpers.GetObjectValue(dvarVecEnd)));
			rvarBegPoint2D[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarBegPoint2D, new object[1]
			{
			0
			}, null));
			rvarBegPoint2D[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarBegPoint2D, new object[1]
			{
			1
			}, null));
			rvarEndPoint2D[0] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarEndPoint2D, new object[1]
			{
			0
			}, null));
			rvarEndPoint2D[1] = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarEndPoint2D, new object[1]
			{
			1
			}, null));
		}
	}
}
