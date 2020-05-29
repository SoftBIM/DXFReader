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
	public class AcadPolyline : AcadCurve
	{
		private const string cstrClassName = "AcadPolyline";

		private const int clngClosed = 1;

		private const int clngIsCurve = 2;

		private const int clngIsSpline = 4;

		private const int clngLinetypeGeneration = 128;

		private const short clngSplineTypeNone = 0;

		private const short clngSplineTypeCubicSpline = 5;

		private const short clngSplineTypeQuadSpline = 6;

		private bool mblnOpened;

		private int mlngBulged;

		private bool mblnClockwise;

		private object mdecMinMaxCenterX;

		private double mdblMinMaxCenterX;

		private object mdecMinMaxCenterY;

		private double mdblMinMaxCenterY;

		private object mdecMinMaxCenterZ;

		private double mdblMinMaxCenterZ;

		private object mdecMaxCoordX;

		private double mdblMaxCoordX;

		private object mdecMinCoordX;

		private double mdblMinCoordX;

		private object mdecMaxCoordY;

		private double mdblMaxCoordY;

		private object mdecMinCoordY;

		private double mdblMinCoordY;

		private object mdecMaxCoordZ;

		private double mdblMaxCoordZ;

		private object mdecMinCoordZ;

		private double mdblMinCoordZ;

		private int mlngFlags66;

		private object mdecCode10;

		private double mdblCode10;

		private object mdecCode20;

		private double mdblCode20;

		private object mdecElevation;

		private double mdblElevation;

		private object mdecThickness;

		private double mdblThickness;

		private int mlngFlags70;

		private bool mblnIsCurve;

		private bool mblnIsSpline;

		private bool mblnLinetypeGeneration;

		private bool mblnHasConstantWidth;

		private object mdecConstantWidth;

		private double mdblConstantWidth;

		private object mdecStartWidth;

		private double mdblStartWidth;

		private object mdecEndWidth;

		private double mdblEndWidth;

		private int mlngSplineType;

		private Enums.AcPolylineType mnumPType;

		private object[] madecNormal;

		private double[] madblNormal;

		private bool mblnFriendLetFlags;

		private bool mblnFriendCalcSizeStop;

		private Dictionary<object, object> mobjDictVertices;

		private AcadSequenceEnd mobjAcadSequenceEnd;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetDatabaseIndex = value;
				}
				Acad2DVertex dobjAcad2DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad2DVertex2 != null)
						{
							dobjAcad2DVertex2.FriendLetDatabaseIndex = value;
						}
					}
				}
				dobjAcad2DVertex2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetDocumentIndex = value;
				}
				Acad2DVertex dobjAcad2DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad2DVertex2 != null)
						{
							dobjAcad2DVertex2.FriendLetDocumentIndex = value;
						}
					}
				}
				dobjAcad2DVertex2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetApplicationIndex = value;
				}
				Acad2DVertex dobjAcad2DVertex2;
				if (mobjDictVertices != null && mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad2DVertex2 != null)
						{
							dobjAcad2DVertex2.FriendLetApplicationIndex = value;
						}
					}
				}
				dobjAcad2DVertex2 = null;
			}
		}

		internal int FriendLetFlags66
		{
			set
			{
				mlngFlags66 = value;
			}
		}

		internal int FriendGetFlags66 => mlngFlags66;

		internal object FriendGetCode10 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode10), mdblCode10));

		internal object FriendGetCode20 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode20), mdblCode20));

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				Closed = ((1 & mlngFlags70) == 1);
				IsCurve = ((2 & mlngFlags70) == 2);
				IsSpline = (!IsCurve & ((4 & mlngFlags70) == 4));
				LinetypeGeneration = ((0x80 & mlngFlags70) == 128);
				mblnFriendLetFlags = false;
				InternCalcFlags70();
			}
		}

		internal bool FriendCalcSizeStop
		{
			set
			{
				mblnFriendCalcSizeStop = value;
			}
		}

		internal string FriendGetPTypeString
		{
			get
			{
				switch (mnumPType)
				{
					case Enums.AcPolylineType.acSimplePoly:
						return "Einfache Polylinie";
					case Enums.AcPolylineType.acFitCurvePoly:
						return "Kurvenangeglichene Polylinie";
					case Enums.AcPolylineType.acCubicSplinePoly:
						return "Kubische geglättete Polylinie";
					case Enums.AcPolylineType.acQuadSplinePoly:
						return "Quadratisch geglättete Polylinie";
					default:
						{
							string dstrPolylineType = default(string);
							return dstrPolylineType;
						}
				}
			}
		}

		internal string FriendGetSplineTypeString
		{
			get
			{
				switch (mlngSplineType)
				{
					case 0:
						return "Keine glatte Oberfläche angepaßt";
					case 5:
						return "Oberfläche eines quadratischen B-Spline";
					case 6:
						return "Oberfläche eines kubischen B-Spline";
					default:
						{
							string dstrSplineType = default(string);
							return dstrSplineType;
						}
				}
			}
		}

		public AcadSequenceEnd SequenceEnd
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectSequenceEnd(-1.0, nvblnWithoutObjectID: false, ref nrstrErrMsg);
			}
		}

		public int Flags70 => mlngFlags70;

		public bool Closed
		{
			get
			{
				return base.IsClosed;
			}
			set
			{
				if (base.IsClosed != value)
				{
					base.FriendLetIsClosed = value;
					InternCalcFlags70();
					InternCalcSize();
				}
			}
		}

		public bool IsCurve
		{
			get
			{
				return mblnIsCurve;
			}
			set
			{
				if (mblnIsCurve != value)
				{
					mblnIsCurve = value;
					if (mblnIsCurve)
					{
						mblnIsSpline = false;
					}
					InternCalcFlags70();
					InternCalcPType();
					InternCalcSize();
				}
			}
		}

		public bool IsSpline
		{
			get
			{
				return mblnIsSpline;
			}
			set
			{
				if (mblnIsSpline != value)
				{
					mblnIsSpline = value;
					if (mblnIsSpline)
					{
						mblnIsCurve = false;
					}
					InternCalcFlags70();
					InternCalcPType();
					InternCalcSize();
				}
			}
		}

		public bool LinetypeGeneration
		{
			get
			{
				return mblnLinetypeGeneration;
			}
			set
			{
				mblnLinetypeGeneration = value;
				InternCalcFlags70();
			}
		}

		public int SplineType
		{
			get
			{
				return mlngSplineType;
			}
			set
			{
				if ((value == 0 || value == 5 || value == 6) && mlngSplineType != value)
				{
					mlngSplineType = value;
					if (mlngSplineType == 0)
					{
						mblnIsSpline = false;
					}
					else if (mlngSplineType == 5)
					{
						mblnIsSpline = true;
						mblnIsCurve = false;
					}
					else if (mlngSplineType == 6)
					{
						mblnIsSpline = true;
						mblnIsCurve = false;
					}
					InternCalcFlags70();
					InternCalcPType();
					InternCalcSize();
				}
			}
		}

		public Enums.AcPolylineType PType
		{
			set
			{
				if (mnumPType != value)
				{
					mnumPType = value;
					switch (mnumPType)
					{
						case Enums.AcPolylineType.acSimplePoly:
							mblnIsCurve = false;
							mblnIsSpline = false;
							mlngSplineType = 0;
							break;
						case Enums.AcPolylineType.acFitCurvePoly:
							mblnIsCurve = true;
							mblnIsSpline = false;
							mlngSplineType = 0;
							break;
						case Enums.AcPolylineType.acCubicSplinePoly:
							mblnIsSpline = true;
							mblnIsCurve = false;
							mlngSplineType = 5;
							break;
						case Enums.AcPolylineType.acQuadSplinePoly:
							mblnIsSpline = true;
							mblnIsCurve = false;
							mlngSplineType = 6;
							break;
					}
					InternCalcFlags70();
					InternCalcSize();
				}
			}
		}

		public Enums.AcPolylineType PolylineType
		{
			get
			{
				PType = mnumPType;
				Enums.AcPolylineType PolylineType = default(Enums.AcPolylineType);
				return PolylineType;
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
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
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
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
			}
		}

		public object StartWidth
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartWidth), mdblStartWidth));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecStartWidth;
				ref double reference = ref mdblStartWidth;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
			}
		}

		public object EndWidth
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndWidth), mdblEndWidth));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecEndWidth;
				ref double reference = ref mdblEndWidth;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
			}
		}

		public object ConstantWidth
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecConstantWidth), mdblConstantWidth));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecConstantWidth;
				ref double reference = ref mdblConstantWidth;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				Acad2DVertex dobjAcad2DVertex;
				if (!num)
				{
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
				else
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int num2 = Information.LBound((Array)dvarItems);
					int num3 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num2; dlngIdx <= num3; dlngIdx = checked(dlngIdx + 1))
					{
						dobjAcad2DVertex = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null);
						if (dobjAcad2DVertex != null)
						{
							bool flag = false;
							dobjAcad2DVertex.FriendSetStartWidth(mdblConstantWidth);
							dobjAcad2DVertex.FriendSetEndWidth(mdblConstantWidth);
						}
					}
					bool flag2 = false;
					mdblStartWidth = mdblConstantWidth;
					mdblEndWidth = mdblConstantWidth;
					mblnHasConstantWidth = true;
				}
				dobjAcad2DVertex = null;
			}
		}

		public object Coordinate
		{
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			get
			{
				object[] dadecCoordinate = new object[3];
				double[] dadblCoordinate = new double[3];
				object Coordinate = default(object);
				Acad2DVertex dobjAcad2DVertex2;
				if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
				}
				else
				{
					dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcad2DVertex2 != null)
					{
						Coordinate = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex2.Coordinate);
					}
				}
				dobjAcad2DVertex2 = null;
				return Coordinate;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				Acad2DVertex dobjAcad2DVertex2;
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
				else if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
				}
				else
				{
					dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcad2DVertex2 != null)
					{
						dobjAcad2DVertex2.FriendSetCoordinate(RuntimeHelpers.GetObjectValue(value));
						InternCalcSize();
					}
				}
				dobjAcad2DVertex2 = null;
			}
		}

		public object Coordinates
		{
			get
			{
				checked
				{
					object Coordinates = default(object);
					Acad2DVertex dobjAcad2DVertex2;
					if (mobjDictVertices.Count > 0)
					{
						bool flag = false;
						double[] dadblCoordinate = new double[mobjDictVertices.Count * 3 - 1 + 1];
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngIndex = 0;
						int num = Information.LBound((Array)dvarItems);
						int num2 = Information.UBound((Array)dvarItems);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							if (dobjAcad2DVertex2 != null)
							{
								bool flag2 = false;
								dadblCoordinate[dlngIndex * 3] = Conversions.ToDouble(dobjAcad2DVertex2.CoordX);
								dadblCoordinate[dlngIndex * 3 + 1] = Conversions.ToDouble(dobjAcad2DVertex2.CoordY);
								dadblCoordinate[dlngIndex * 3 + 2] = Conversions.ToDouble(dobjAcad2DVertex2.CoordZ);
							}
							dlngIndex++;
						}
						object[] dadecCoordinate = default(object[]);
						Coordinates = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
					}
					dobjAcad2DVertex2 = null;
					return Coordinates;
				}
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				if (value == null)
				{
					InternClearVertices();
					return;
				}
				checked
				{
					int dlngLBound = default(int);
					int dlngUBound2 = default(int);
					if ((VariantType.Array & Information.VarType(RuntimeHelpers.GetObjectValue(value))) == VariantType.Array)
					{
						dlngLBound = Information.LBound((Array)value);
						dlngUBound2 = Information.UBound((Array)value);
						int dlngCount2 = dlngUBound2 - dlngLBound + 1;
						dlngCount2 = (int)Math.Round(Conversion.Fix((double)dlngCount2 / 3.0) * 3.0);
						dlngUBound2 = dlngCount2 - 1 + dlngLBound;
					}
					string dstrErrMsg = default(string);
					if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), dlngLBound, dlngUBound2, ref dstrErrMsg))
					{
						Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
						return;
					}
					InternClearVertices();
					int num = dlngLBound;
					int num2 = dlngUBound2;
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 3)
					{
						double ddblObjectID = base.Database.FriendGetNextObjectID;
						object dvar2DHWVertex = RuntimeHelpers.GetObjectValue(InternCreate2DHWVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 1
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 2
						}, null)), dlngIdx == dlngLBound));
						object objectValue = RuntimeHelpers.GetObjectValue(dvar2DHWVertex);
						string nrstrErrMsg = "";
						FriendAppendVertex(ddblObjectID, objectValue, ref nrstrErrMsg);
					}
					InternCalcSize();
				}
			}
		}

		public object Bulges
		{
			get
			{
				checked
				{
					object Bulges = default(object);
					Acad2DVertex dobjAcad2DVertex2;
					if (mobjDictVertices.Count > 0)
					{
						bool flag = false;
						double[] dadblBulges = new double[mobjDictVertices.Count - 1 + 1];
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngIndex = 0;
						int num = Information.LBound((Array)dvarItems);
						int num2 = Information.UBound((Array)dvarItems);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							if (dobjAcad2DVertex2 != null)
							{
								bool flag2 = false;
								dadblBulges[dlngIndex] = Conversions.ToDouble(dobjAcad2DVertex2.Bulge);
							}
							dlngIndex++;
						}
						object[] dadecBulges = default(object[]);
						Bulges = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecBulges, dadblBulges));
					}
					dobjAcad2DVertex2 = null;
					return Bulges;
				}
			}
		}

		public object MaxCoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordX), mdblMaxCoordX));

		public object MaxCoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordY), mdblMaxCoordY));

		public object MaxCoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMaxCoordZ), mdblMaxCoordZ));

		public object MinCoordX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordX), mdblMinCoordX));

		public object MinCoordY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordY), mdblMinCoordY));

		public object MinCoordZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinCoordZ), mdblMinCoordZ));

		public object MinMaxCenterX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterX), mdblMinMaxCenterX));

		public object MinMaxCenterY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterY), mdblMinMaxCenterY));

		public object MinMaxCenterZ => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterZ), mdblMinMaxCenterZ));

		public int NumVerts => mobjDictVertices.Count;

		public bool Clockwise => mblnClockwise;

		public bool Bulged => mlngBulged > 0;

		public bool HasConstantWidth => mblnHasConstantWidth;

		public object Area => RuntimeHelpers.GetObjectValue(base.FriendGetArea);

		public object Length => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

		public bool Is2DWorld => Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		0
		}, null), 0m, TextCompare: false), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		1
		}, null), 0m, TextCompare: false)), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(Normal, new object[1]
		{
		2
		}, null), 1m, TextCompare: false)), Operators.CompareObjectEqual(Thickness, 0m, TextCompare: false)), Operators.CompareObjectEqual(Elevation, 0m, TextCompare: false)));

		public AcadPolyline()
		{
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurvePolyline;
			base.FriendLetNodeImageEnabledID = 309;
			base.FriendLetNodeImageDisabledID = 310;
			base.FriendLetNodeName = "2D-Polylinie";
			base.FriendLetNodeText = "2D-Polylinie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCode10 = hwpDxf_Vars.pdblCode10;
			mdblCode20 = hwpDxf_Vars.pdblCode20;
			mdblElevation = hwpDxf_Vars.pdblElevation;
			mdblThickness = hwpDxf_Vars.pdblThickness;
			mdblStartWidth = hwpDxf_Vars.pdblStartWidth;
			mdblEndWidth = hwpDxf_Vars.pdblEndWidth;
			mdblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mlngFlags66 = hwpDxf_Vars.plngFlags66;
			mblnIsCurve = hwpDxf_Vars.pblnIsCurve;
			mblnIsSpline = hwpDxf_Vars.pblnIsSpline;
			mblnLinetypeGeneration = hwpDxf_Vars.pblnLinetypeGeneration;
			mblnHasConstantWidth = hwpDxf_Vars.pblnHasConstantWidth;
			mlngSplineType = 0;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			InternCalcPType();
			mblnFriendCalcSizeStop = false;
			mobjDictVertices = new Dictionary<object, object>();
			InternClearVertices();
			base.FriendLetDXFName = "POLYLINE";
			base.FriendLetObjectName = "AcDb2dPolyline";
			base.FriendLetEntityType = Enums.AcEntityName.acPolyline;
		}

		~AcadPolyline()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClearVertices();
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendQuit();
				}
				base.FriendQuit();
				mobjDictVertices = null;
				mobjAcadSequenceEnd = null;
				mblnOpened = false;
			}
		}

		internal AcadSequenceEnd FriendAddAcadObjectSequenceEnd(double nvdblObjectID = -1.0, bool nvblnWithoutObjectID = false, ref string nrstrErrMsg = "")
		{
			AcadSequenceEnd dobjAcadSequenceEnd2;
			if (mobjAcadSequenceEnd == null)
			{
				dobjAcadSequenceEnd2 = new AcadSequenceEnd();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadSequenceEnd acadSequenceEnd = dobjAcadSequenceEnd2;
				acadSequenceEnd.FriendLetNodeParentID = base.NodeID;
				acadSequenceEnd.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				acadSequenceEnd.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				acadSequenceEnd.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				acadSequenceEnd.FriendLetOwnerID = base.ObjectID;
				bool dblnValid = default(bool);
				if (nvblnWithoutObjectID)
				{
					dblnValid = true;
				}
				else
				{
					AcadSequenceEnd acadSequenceEnd2 = acadSequenceEnd;
					double vdblObjectID = nvdblObjectID;
					AcadObject nrobjAcadObject = dobjAcadSequenceEnd2;
					bool flag = acadSequenceEnd2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
					dobjAcadSequenceEnd2 = (AcadSequenceEnd)nrobjAcadObject;
					if (flag)
					{
						dblnValid = true;
					}
					else
					{
						hwpDxf_Functions.BkDXF_DebugPrint(acadSequenceEnd.ObjectName + ": " + nrstrErrMsg);
					}
				}
				acadSequenceEnd = null;
				if (dblnValid)
				{
					mobjAcadSequenceEnd = dobjAcadSequenceEnd2;
				}
			}
			AcadSequenceEnd FriendAddAcadObjectSequenceEnd = mobjAcadSequenceEnd;
			dobjAcadSequenceEnd2 = null;
			return FriendAddAcadObjectSequenceEnd;
		}

		internal void FriendCalcSize()
		{
			mblnFriendCalcSizeStop = false;
			InternCalcSize();
		}

		internal Acad2DVertex FriendAppendVertex(double vdblObjectID, object vvar2DHWVertex, ref string nrstrErrMsg = "")
		{
			object[] dadecCoordinate = new object[3];
			double[] dadblCoordinate = new double[3];
			nrstrErrMsg = null;
			bool flag = false;
			dadblCoordinate[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			0
			}, null));
			dadblCoordinate[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			1
			}, null));
			dadblCoordinate[2] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			2
			}, null));
			double ddblStartWidth = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			4
			}, null));
			double ddblEndWidth = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			5
			}, null));
			double ddblBulge = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DHWVertex, new object[1]
			{
			3
			}, null));
			Acad2DVertex dobjAcad2DVertex3 = new Acad2DVertex();
			Acad2DVertex acad2DVertex = dobjAcad2DVertex3;
			acad2DVertex.FriendLetCoordinate = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
			object ddecStartWidth = default(object);
			acad2DVertex.FriendLetStartWidth = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecStartWidth), ddblStartWidth));
			object ddecEndWidth = default(object);
			acad2DVertex.FriendLetEndWidth = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecEndWidth), ddblEndWidth));
			object ddecBulge = default(object);
			acad2DVertex.FriendLetBulge = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecBulge), ddblBulge));
			acad2DVertex.FriendLetNodeParentID = base.NodeID;
			acad2DVertex.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acad2DVertex.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acad2DVertex.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acad2DVertex.FriendLetOwnerID = base.ObjectID;
			Acad2DVertex acad2DVertex2 = acad2DVertex;
			AcadObject nrobjAcadObject = dobjAcad2DVertex3;
			bool flag2 = acad2DVertex2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcad2DVertex3 = (Acad2DVertex)nrobjAcadObject;
			if (flag2)
			{
				bool dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acad2DVertex.ObjectName + ": " + nrstrErrMsg);
			}
			acad2DVertex = null;
			mobjDictVertices.Add("K" + Conversions.ToString(mobjDictVertices.Count), dobjAcad2DVertex3);
			bool flag3 = false;
			checked
			{
				if (Operators.ConditionalCompareObjectNotEqual(dobjAcad2DVertex3.Bulge, 0.0, TextCompare: false))
				{
					mlngBulged++;
				}
				if (mobjDictVertices.Count - 1 == 0)
				{
					base.FriendLetStartPoint = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex3.Coordinate);
					Acad2DVertex acad2DVertex3 = dobjAcad2DVertex3;
					acad2DVertex3.FriendLetStartWidth = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartWidth), mdblStartWidth));
					acad2DVertex3.FriendLetEndWidth = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndWidth), mdblEndWidth));
					acad2DVertex3 = null;
				}
				base.FriendLetEndPoint = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex3.Coordinate);
				InternCheckWidth();
				InternCalcSize();
				Acad2DVertex FriendAppendVertex = dobjAcad2DVertex3;
				dobjAcad2DVertex3 = null;
				return FriendAppendVertex;
			}
		}

		public void Explode()
		{
		}

		public void Offset(object vvarDistance)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public Acad2DVertex AppendVertex(object vvarVertex, string nvstrHandle = null)
		{
			string dstrErrMsg = default(string);
			Acad2DVertex AppendVertex = default(Acad2DVertex);
			Acad2DVertex dobjAcad2DVertex2;
			if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(vvarVertex), 0, 2, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
			}
			else
			{
				double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
				object dvar2DHWVertex = RuntimeHelpers.GetObjectValue(InternCreate2DHWVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				0
				}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				1
				}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
				{
				2
				}, null)), mobjDictVertices.Count == 0));
				dobjAcad2DVertex2 = FriendAppendVertex(ddblObjectID, RuntimeHelpers.GetObjectValue(dvar2DHWVertex), ref dstrErrMsg);
				if (dobjAcad2DVertex2 == null)
				{
					Information.Err().Raise(50000, "AcadPolyline", "Der Kontrollpunkt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
				}
				else
				{
					AppendVertex = dobjAcad2DVertex2;
				}
			}
			dobjAcad2DVertex2 = null;
			return AppendVertex;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetBulge(int vlngIndex, object vvarBulge)
		{
			checked
			{
				string dstrErrMsg = default(string);
				Acad2DVertex dobjAcad2DVertex2;
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarBulge), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
				}
				else if ((vlngIndex < 0) | (vlngIndex > mobjDictVertices.Count - 1))
				{
					Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
				}
				else
				{
					dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
					if (dobjAcad2DVertex2 != null && Operators.ConditionalCompareObjectNotEqual(dobjAcad2DVertex2.Bulge, vvarBulge, TextCompare: false))
					{
						bool flag = false;
						if (Operators.ConditionalCompareObjectNotEqual(dobjAcad2DVertex2.Bulge, 0.0, TextCompare: false))
						{
							mlngBulged--;
						}
						dobjAcad2DVertex2.FriendLetBulge = RuntimeHelpers.GetObjectValue(vvarBulge);
						bool flag2 = false;
						if (Operators.ConditionalCompareObjectNotEqual(dobjAcad2DVertex2.Bulge, 0.0, TextCompare: false))
						{
							mlngBulged++;
						}
						InternCalcSize();
					}
				}
				dobjAcad2DVertex2 = null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object GetBulge(int vlngIndex)
		{
			object GetBulge = default(object);
			Acad2DVertex dobjAcad2DVertex2;
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
			}
			else
			{
				dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
				if (dobjAcad2DVertex2 != null)
				{
					GetBulge = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex2.Bulge);
				}
			}
			dobjAcad2DVertex2 = null;
			return GetBulge;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetWidth(int vlngIndex, object vvarStartWidth, object vvarEndWidth)
		{
			string dstrErrMsg = default(string);
			Acad2DVertex dobjAcad2DVertex2;
			if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarStartWidth), ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
			}
			else if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarEndWidth), ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadPolyline", dstrErrMsg);
			}
			else if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
			}
			else
			{
				dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
				if (dobjAcad2DVertex2 != null)
				{
					Acad2DVertex acad2DVertex = dobjAcad2DVertex2;
					if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(acad2DVertex.StartWidth, vvarStartWidth, TextCompare: false), Operators.CompareObjectNotEqual(acad2DVertex.EndWidth, vvarEndWidth, TextCompare: false))))
					{
						dobjAcad2DVertex2.FriendSetStartWidth(RuntimeHelpers.GetObjectValue(vvarStartWidth));
						dobjAcad2DVertex2.FriendSetEndWidth(RuntimeHelpers.GetObjectValue(vvarEndWidth));
						InternCheckWidth();
					}
					acad2DVertex = null;
				}
			}
			dobjAcad2DVertex2 = null;
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void GetWidth(int vlngIndex, ref object rvarStartWidth, ref object rvarEndWidth)
		{
			Acad2DVertex dobjAcad2DVertex2;
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadPolyline", "Ungültiger Index.");
			}
			else
			{
				dobjAcad2DVertex2 = (Acad2DVertex)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
				if (dobjAcad2DVertex2 != null)
				{
					rvarStartWidth = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex2.StartWidth);
					rvarEndWidth = RuntimeHelpers.GetObjectValue(dobjAcad2DVertex2.EndWidth);
				}
			}
			dobjAcad2DVertex2 = null;
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Closed, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsCurve, 2, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(IsSpline, 4, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(LinetypeGeneration, 128, 0)));
			}
		}

		private void InternCalcPType()
		{
			if (IsSpline & (mlngSplineType == 6))
			{
				mnumPType = Enums.AcPolylineType.acQuadSplinePoly;
			}
			else if (IsSpline & (mlngSplineType == 5))
			{
				mnumPType = Enums.AcPolylineType.acCubicSplinePoly;
			}
			else if (IsSpline)
			{
				mnumPType = Enums.AcPolylineType.acQuadSplinePoly;
				mlngSplineType = 6;
			}
			else if (IsCurve)
			{
				mnumPType = Enums.AcPolylineType.acFitCurvePoly;
				mlngSplineType = 0;
			}
			else
			{
				mnumPType = Enums.AcPolylineType.acSimplePoly;
				mlngSplineType = 0;
			}
		}

		private object InternCreate2DHWVertex(object vvarCoordX, object vvarCoordY, object vvarCoordZ, bool vblnFirst)
		{
			object[] dadec2DHWVertex = new object[6];
			double[] dadbl2DHWVertex = new double[6];
			bool flag = false;
			dadbl2DHWVertex[0] = Conversions.ToDouble(vvarCoordX);
			dadbl2DHWVertex[1] = Conversions.ToDouble(vvarCoordY);
			dadbl2DHWVertex[2] = Conversions.ToDouble(vvarCoordZ);
			dadbl2DHWVertex[3] = hwpDxf_Vars.pdblBulge;
			dadbl2DHWVertex[4] = Conversions.ToDouble(Interaction.IIf(vblnFirst, mdblStartWidth, mdblEndWidth));
			dadbl2DHWVertex[5] = mdblEndWidth;
			return Support.CopyArray(dadbl2DHWVertex);
		}

		private void InternClearVertices()
		{
			object[] dadecPoint = new object[3];
			double[] dadblPoint = new double[3];
			Acad2DVertex dobjAcad2DVertex3;
			if (mobjDictVertices.Count > 0)
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				mobjDictVertices.Clear();
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcad2DVertex3 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					dobjAcad2DVertex3.FriendQuit();
					dobjAcad2DVertex3 = null;
				}
			}
			mlngBulged = 0;
			bool flag = false;
			mdblMaxCoordX = 0.0;
			mdblMinCoordX = 0.0;
			mdblMaxCoordY = 0.0;
			mdblMinCoordY = 0.0;
			mdblMaxCoordZ = 0.0;
			mdblMinCoordZ = 0.0;
			mdblMinMaxCenterX = 0.0;
			mdblMinMaxCenterY = 0.0;
			mdblMinMaxCenterZ = 0.0;
			dadblPoint[0] = 0.0;
			dadblPoint[1] = 0.0;
			dadblPoint[2] = 0.0;
			base.FriendLetStartPoint = Support.CopyArray(dadblPoint);
			base.FriendLetEndPoint = Support.CopyArray(dadblPoint);
			base.FriendLetLength = 0.0;
			base.FriendLetArea = 0.0;
			dobjAcad2DVertex3 = null;
		}

		private void InternCalcSize()
		{
			checked
			{
				Acad2DVertex dobjSecondAcad2DVertex2;
				Acad2DVertex dobjFirstAcad2DVertex2;
				Acad2DVertex dobjStartAcad2DVertex2;
				if (!mblnFriendCalcSizeStop)
				{
					object dvarLen = 0m;
					object dvarArea2 = 0m;
					bool dblnClosed = Closed;
					if (mobjDictVertices.Count > 1)
					{
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngLBound = Information.LBound((Array)dvarItems);
						int dlngUBound = Information.UBound((Array)dvarItems);
						dobjStartAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngLBound
						}, null);
						dobjFirstAcad2DVertex2 = dobjStartAcad2DVertex2;
						int num = dlngLBound + 1;
						int num2 = dlngUBound;
						object dvarSegLen = default(object);
						object dvarSegArea = default(object);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							dobjSecondAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null);
							InternCalcSeg(dlngIdx == dlngLBound + 1, dobjFirstAcad2DVertex2, dobjSecondAcad2DVertex2, ref dvarSegLen, ref dvarSegArea, vblnCalcLen: true, vblnIgnoreBulg: false);
							dvarLen = Operators.AddObject(dvarLen, dvarSegLen);
							dvarArea2 = Operators.AddObject(dvarArea2, dvarSegArea);
							dobjFirstAcad2DVertex2 = dobjSecondAcad2DVertex2;
						}
						InternCalcSeg(vblnFirst: false, dobjFirstAcad2DVertex2, dobjStartAcad2DVertex2, ref dvarSegLen, ref dvarSegArea, dblnClosed, !dblnClosed);
						dvarLen = Operators.AddObject(dvarLen, dvarSegLen);
						dvarArea2 = Operators.AddObject(dvarArea2, dvarSegArea);
					}
					base.FriendLetLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(dvarLen), Conversions.ToDouble(dvarLen)));
					base.FriendLetArea = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.DivideObject(dvarArea2, new decimal(2L))
					}, null, null, null)), Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.DivideObject(dvarArea2, 2.0)
					}, null, null, null))));
					object left = dvarArea2;
					object[] array;
					bool[] array2;
					object right = NewLateBinding.LateGet(null, typeof(Math), "Abs", array = new object[1]
					{
					dvarArea2
					}, null, null, array2 = new bool[1]
					{
					true
					});
					if (array2[0])
					{
						dvarArea2 = RuntimeHelpers.GetObjectValue(array[0]);
					}
					mblnClockwise = Operators.ConditionalCompareObjectNotEqual(left, right, TextCompare: false);
					bool flag = false;
					mdblMinMaxCenterX = mdblMinCoordX + (mdblMaxCoordX - mdblMinCoordX) / 2.0;
					mdblMinMaxCenterY = mdblMinCoordY + (mdblMaxCoordY - mdblMinCoordY) / 2.0;
					mdblMinMaxCenterZ = mdblMinCoordZ + (mdblMaxCoordZ - mdblMinCoordZ) / 2.0;
				}
				dobjSecondAcad2DVertex2 = null;
				dobjFirstAcad2DVertex2 = null;
				dobjStartAcad2DVertex2 = null;
			}
		}

		private void InternCalcSeg(bool vblnFirst, Acad2DVertex dobjFirstAcad2DVertex, Acad2DVertex dobjSecondAcad2DVertex, ref object rvarLen, ref object rvarArea, bool vblnCalcLen, bool vblnIgnoreBulg)
		{
			object[] dadecPoint1 = new object[3];
			double[] dadblPoint1 = new double[3];
			object[] dadecPoint2 = new object[3];
			double[] dadblPoint2 = new double[3];
			rvarLen = 0m;
			rvarArea = 0m;
			bool flag = false;
			double ddblCoordX1 = Conversions.ToDouble(dobjFirstAcad2DVertex.CoordX);
			double ddblCoordY1 = Conversions.ToDouble(dobjFirstAcad2DVertex.CoordY);
			double ddblCoordZ1 = Conversions.ToDouble(dobjFirstAcad2DVertex.CoordZ);
			double ddblCoordX2 = Conversions.ToDouble(dobjSecondAcad2DVertex.CoordX);
			double ddblCoordY2 = Conversions.ToDouble(dobjSecondAcad2DVertex.CoordY);
			double ddblCoordZ2 = Conversions.ToDouble(dobjSecondAcad2DVertex.CoordZ);
			if (vblnFirst)
			{
				bool flag2 = false;
				mdblMaxCoordX = ddblCoordX1;
				mdblMinCoordX = ddblCoordX1;
				mdblMaxCoordY = ddblCoordY1;
				mdblMinCoordY = ddblCoordY1;
				mdblMaxCoordZ = ddblCoordZ1;
				mdblMinCoordZ = ddblCoordZ1;
			}
			else
			{
				bool flag3 = false;
				if (ddblCoordX1 > mdblMaxCoordX)
				{
					mdblMaxCoordX = ddblCoordX1;
				}
				if (ddblCoordX1 < mdblMinCoordX)
				{
					mdblMinCoordX = ddblCoordX1;
				}
				if (ddblCoordY1 > mdblMaxCoordY)
				{
					mdblMaxCoordY = ddblCoordY1;
				}
				if (ddblCoordY1 < mdblMinCoordY)
				{
					mdblMinCoordY = ddblCoordY1;
				}
				if (ddblCoordZ1 > mdblMaxCoordZ)
				{
					mdblMaxCoordZ = ddblCoordZ1;
				}
				if (ddblCoordZ1 < mdblMinCoordZ)
				{
					mdblMinCoordZ = ddblCoordZ1;
				}
			}
			bool flag4 = false;
			dadblPoint1[0] = ddblCoordX1;
			dadblPoint1[1] = ddblCoordY1;
			dadblPoint1[2] = 0.0;
			dadblPoint2[0] = ddblCoordX2;
			dadblPoint2[1] = ddblCoordY2;
			dadblPoint2[2] = 0.0;
			double ddblBulge = (!vblnIgnoreBulg) ? Conversions.ToDouble(dobjFirstAcad2DVertex.Bulge) : 0.0;
			bool dblnBulged = ddblBulge != 0.0;
			if (vblnCalcLen)
			{
				bool flag5 = false;
				rvarLen = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.BulgedLineLen(dadblPoint1, dadblPoint2, ddblBulge));
			}
			bool flag6 = false;
			rvarArea = dadblPoint1[0] * dadblPoint2[1] - dadblPoint1[1] * dadblPoint2[0];
			if (dblnBulged)
			{
				bool flag7 = false;
				rvarArea = Operators.AddObject(rvarArea, Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.PointsBulgeArcArea(dadblPoint1, dadblPoint2, ddblBulge), 2.0));
			}
		}

		private void InternCheckWidth()
		{
			bool dblnHasConstantWidth = true;
			object ddecConstantWidth = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecConstantWidth);
			double ddblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
			Acad2DVertex dobjAcad2DVertex2;
			if (mobjDictVertices.Count == 0)
			{
				dblnHasConstantWidth = true;
			}
			else
			{
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				int num = Information.LBound((Array)dvarItems);
				int num2 = Information.UBound((Array)dvarItems);
				bool dblnFirst = default(bool);
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
				{
					dobjAcad2DVertex2 = (Acad2DVertex)NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null);
					Acad2DVertex acad2DVertex = dobjAcad2DVertex2;
					if (Operators.ConditionalCompareObjectNotEqual(acad2DVertex.StartWidth, acad2DVertex.EndWidth, TextCompare: false))
					{
						dblnHasConstantWidth = false;
						break;
					}
					if (!dblnFirst)
					{
						bool flag = false;
						ddblConstantWidth = Conversions.ToDouble(acad2DVertex.StartWidth);
						dblnFirst = true;
					}
					else if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(acad2DVertex.StartWidth, ddblConstantWidth, TextCompare: false), Operators.CompareObjectNotEqual(acad2DVertex.EndWidth, ddblConstantWidth, TextCompare: false))))
					{
						dblnHasConstantWidth = false;
						break;
					}
					acad2DVertex = null;
				}
			}
			mblnHasConstantWidth = dblnHasConstantWidth;
			bool flag2 = false;
			if (mblnHasConstantWidth)
			{
				mdecConstantWidth = ddblConstantWidth;
				mdblStartWidth = mdblConstantWidth;
				mdblEndWidth = mdblConstantWidth;
			}
			else
			{
				mdblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
			}
			dobjAcad2DVertex2 = null;
		}
	}
}
