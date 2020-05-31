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
	public class AcadSpline : AcadCurve
	{
		private const string cstrClassName = "AcadSpline";

		private const int clngIsClosed = 1;

		private const int clngIsPeriodic = 2;

		private const int clngIsRational = 4;

		private const int clngIsPlanar = 8;

		private const int clngIsLinear = 16;

		private bool mblnOpened;

		private int mlngKnotIndex;

		private int mlngControlPointIndex;

		private int mlngFitPointIndex;

		private int mlngSplineFlags;

		private bool mblnIsRational;

		private bool mblnIsLinear;

		private int mlngDegree;

		private object mdecKnotTolerance;

		private double mdblKnotTolerance;

		private object mdecControlPointTolerance;

		private double mdblControlPointTolerance;

		private object mdecFitTolerance;

		private double mdblFitTolerance;

		private bool mblnHasStartTangent;

		private bool mblnHasEndTangent;

		private object[] madecStartTangent;

		private double[] madblStartTangent;

		private object[] madecEndTangent;

		private double[] madblEndTangent;

		private bool mblnFriendLetFlags;

		private Dictionary<object, object> mobjDictKnots;

		private Dictionary<object, object> mobjDictControlPoints;

		private Dictionary<object, object> mobjDictFitPoints;

		internal int FriendLetSplineFlags
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngSplineFlags = value;
				base.FriendLetIsClosed = ((1 & mlngSplineFlags) == 1);
				base.FriendLetIsPeriodic = ((2 & mlngSplineFlags) == 2);
				FriendLetIsRational = ((4 & mlngSplineFlags) == 4);
				base.FriendLetIsPlanar = ((8 & mlngSplineFlags) == 8);
				FriendLetIsLinear = ((0x10 & mlngSplineFlags) == 16);
				mblnFriendLetFlags = false;
			}
		}

		internal bool FriendLetIsRational
		{
			set
			{
				mblnIsRational = value;
				InternCalcSplineFlags();
			}
		}

		internal bool FriendLetIsLinear
		{
			set
			{
				mblnIsLinear = value;
				InternCalcSplineFlags();
			}
		}

		internal int FriendLetDegree
		{
			set
			{
				mlngDegree = value;
			}
		}

		internal bool FriendLetHasStartTangent
		{
			set
			{
				mblnHasStartTangent = value;
			}
		}

		internal bool FriendLetHasEndTangent
		{
			set
			{
				mblnHasEndTangent = value;
			}
		}

		public object Normal
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(base.FriendGetNormal);
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 2, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
				else
				{
					base.FriendLetNormal = RuntimeHelpers.GetObjectValue(value);
				}
			}
		}

		public int SplineFlags => mlngSplineFlags;

		public bool Closed => base.IsClosed;

		public bool IsRational => mblnIsRational;

		public bool IsLinear => mblnIsLinear;

		public int Degree => mlngDegree;

		public int NumberOfKnots => mobjDictKnots.Count;

		public int NumberOfControlPoints => mobjDictControlPoints.Count;

		public int NumberOfFitPoints => mobjDictFitPoints.Count;

		public object KnotTolerance
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecKnotTolerance), mdblKnotTolerance));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecKnotTolerance;
				ref double reference = ref mdblKnotTolerance;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
			}
		}

		public object ControlPointTolerance
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecControlPointTolerance), mdblControlPointTolerance));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecControlPointTolerance;
				ref double reference = ref mdblControlPointTolerance;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
			}
		}

		public object FitTolerance
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecFitTolerance), mdblFitTolerance));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecFitTolerance;
				ref double reference = ref mdblFitTolerance;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
			}
		}

		public bool HasStartTangent => mblnHasStartTangent;

		public bool HasEndTangent => mblnHasEndTangent;

		public object StartTangent
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecStartTangent, madblStartTangent));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecStartTangent;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblStartTangent;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
			}
		}

		public object EndTangent
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecEndTangent, madblEndTangent));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecEndTangent;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblEndTangent;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadSpline", dstrErrMsg);
				}
			}
		}

		public AcadSpline()
		{
			madecStartTangent = new object[3];
			madblStartTangent = new double[3];
			madecEndTangent = new object[3];
			madblEndTangent = new double[3];
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurveSpline;
			base.FriendLetNodeImageEnabledID = 291;
			base.FriendLetNodeImageDisabledID = 292;
			base.FriendLetNodeName = "Splinekurve";
			base.FriendLetNodeText = "Splinekurve";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblKnotTolerance = hwpDxf_Vars.pdblKnotTolerance;
			mdblControlPointTolerance = hwpDxf_Vars.pdblControlPointTolerance;
			mdblFitTolerance = hwpDxf_Vars.pdblFitTolerance;
			madblStartTangent[0] = hwpDxf_Vars.padblStartTangent[0];
			madblStartTangent[1] = hwpDxf_Vars.padblStartTangent[1];
			madblStartTangent[2] = hwpDxf_Vars.padblStartTangent[2];
			madblEndTangent[0] = hwpDxf_Vars.padblEndTangent[0];
			madblEndTangent[1] = hwpDxf_Vars.padblEndTangent[1];
			madblEndTangent[2] = hwpDxf_Vars.padblEndTangent[2];
			mblnIsRational = hwpDxf_Vars.pblnIsRational;
			mblnIsLinear = hwpDxf_Vars.pblnIsLinear;
			mblnHasStartTangent = hwpDxf_Vars.pblnHasStartTangent;
			mblnHasEndTangent = hwpDxf_Vars.pblnHasEndTangent;
			mblnFriendLetFlags = false;
			InternCalcSplineFlags();
			mobjDictKnots = new Dictionary<object, object>();
			mobjDictControlPoints = new Dictionary<object, object>();
			mobjDictFitPoints = new Dictionary<object, object>();
			mlngKnotIndex = -1;
			mlngControlPointIndex = -1;
			mlngFitPointIndex = -1;
			base.FriendLetDXFName = "SPLINE";
			base.FriendLetObjectName = "AcDbSpline";
			base.FriendLetEntityType = Enums.AcEntityName.acSpline;
		}

		~AcadSpline()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictKnots.Clear();
				mobjDictControlPoints.Clear();
				mobjDictFitPoints.Clear();
				base.FriendQuit();
				mobjDictKnots = null;
				mobjDictControlPoints = null;
				mobjDictFitPoints = null;
				mblnOpened = false;
			}
		}

		internal void FriendAddKnot(object vvarKnot)
		{
			double ddblKnot2 = default(double);
			object rvarValueDbl = ddblKnot2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarKnot);
			string nrstrErrMsg = "";
			object ddecKnot = default(object);
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecKnot, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			ddblKnot2 = Conversions.ToDouble(rvarValueDbl);
			checked
			{
				if (num)
				{
					mlngKnotIndex++;
					mobjDictKnots.Add("K" + Conversions.ToString(mlngKnotIndex), RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecKnot), ddblKnot2)));
				}
			}
		}

		internal void FriendAddControlPoint(object vvarCoordX, object vvarCoordY, object vvarCoordZ, object vvarWeight)
		{
			double ddblCoordX2 = default(double);
			object rvarValueDbl = ddblCoordX2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarCoordX);
			string nrstrErrMsg = "";
			object ddecCoordX = default(object);
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordX, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			ddblCoordX2 = Conversions.ToDouble(rvarValueDbl);
			if (!num)
			{
				return;
			}
			double ddblCoordY2 = default(double);
			rvarValueDbl = ddblCoordY2;
			object objectValue2 = RuntimeHelpers.GetObjectValue(vvarCoordY);
			nrstrErrMsg = "";
			object ddecCoordY = default(object);
			bool num2 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordY, ref rvarValueDbl, objectValue2, ref nrstrErrMsg);
			ddblCoordY2 = Conversions.ToDouble(rvarValueDbl);
			if (!num2)
			{
				return;
			}
			double ddblCoordZ2 = default(double);
			rvarValueDbl = ddblCoordZ2;
			object objectValue3 = RuntimeHelpers.GetObjectValue(vvarCoordZ);
			nrstrErrMsg = "";
			object ddecCoordZ = default(object);
			bool num3 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordZ, ref rvarValueDbl, objectValue3, ref nrstrErrMsg);
			ddblCoordZ2 = Conversions.ToDouble(rvarValueDbl);
			if (!num3)
			{
				return;
			}
			double ddblWeight2 = default(double);
			rvarValueDbl = ddblWeight2;
			object objectValue4 = RuntimeHelpers.GetObjectValue(vvarWeight);
			nrstrErrMsg = "";
			object ddecWeight = default(object);
			bool num4 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecWeight, ref rvarValueDbl, objectValue4, ref nrstrErrMsg);
			ddblWeight2 = Conversions.ToDouble(rvarValueDbl);
			if (!num4)
			{
				return;
			}
			if (!IsRational)
			{
				bool flag = false;
				if (ddblWeight2 != hwpDxf_Vars.pdblWeight)
				{
					FriendLetIsRational = true;
				}
			}
			checked
			{
				mlngControlPointIndex++;
				AcGeCtrlPoint3d dobjAcGeCtrlPoint3d2 = new AcGeCtrlPoint3d();
				AcGeCtrlPoint3d acGeCtrlPoint3d = dobjAcGeCtrlPoint3d2;
				acGeCtrlPoint3d.FriendLetCoordX = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordX), ddblCoordX2));
				acGeCtrlPoint3d.FriendLetCoordY = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordY), ddblCoordY2));
				acGeCtrlPoint3d.FriendLetCoordZ = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordZ), ddblCoordZ2));
				acGeCtrlPoint3d.FriendLetWeight = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecWeight), ddblWeight2));
				acGeCtrlPoint3d = null;
				mobjDictControlPoints.Add("K" + Conversions.ToString(mlngControlPointIndex), dobjAcGeCtrlPoint3d2);
				dobjAcGeCtrlPoint3d2 = null;
			}
		}

		internal void FriendAddFitPoint(object vvarCoordX, object vvarCoordY, object vvarCoordZ)
		{
			double ddblCoordX2 = default(double);
			object rvarValueDbl = ddblCoordX2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarCoordX);
			string nrstrErrMsg = "";
			object ddecCoordX = default(object);
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordX, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			ddblCoordX2 = Conversions.ToDouble(rvarValueDbl);
			if (!num)
			{
				return;
			}
			double ddblCoordY2 = default(double);
			rvarValueDbl = ddblCoordY2;
			object objectValue2 = RuntimeHelpers.GetObjectValue(vvarCoordY);
			nrstrErrMsg = "";
			object ddecCoordY = default(object);
			bool num2 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordY, ref rvarValueDbl, objectValue2, ref nrstrErrMsg);
			ddblCoordY2 = Conversions.ToDouble(rvarValueDbl);
			checked
			{
				if (num2)
				{
					double ddblCoordZ2 = default(double);
					rvarValueDbl = ddblCoordZ2;
					object objectValue3 = RuntimeHelpers.GetObjectValue(vvarCoordZ);
					nrstrErrMsg = "";
					object ddecCoordZ = default(object);
					bool num3 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecCoordZ, ref rvarValueDbl, objectValue3, ref nrstrErrMsg);
					ddblCoordZ2 = Conversions.ToDouble(rvarValueDbl);
					if (num3)
					{
						mlngFitPointIndex++;
						AcGePoint3d dobjAcGePoint3d2 = new AcGePoint3d();
						AcGePoint3d acGePoint3d = dobjAcGePoint3d2;
						acGePoint3d.FriendLetCoordX = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordX), ddblCoordX2));
						acGePoint3d.FriendLetCoordY = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordY), ddblCoordY2));
						acGePoint3d.FriendLetCoordZ = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordZ), ddblCoordZ2));
						acGePoint3d = null;
						mobjDictFitPoints.Add("K" + Conversions.ToString(mlngFitPointIndex), dobjAcGePoint3d2);
						dobjAcGePoint3d2 = null;
					}
				}
			}
		}

		public object GetKnot(int vlngIndex)
		{
			return RuntimeHelpers.GetObjectValue(mobjDictKnots["K" + Conversions.ToString(vlngIndex)]);
		}

		public AcGeCtrlPoint3d GetControlPoint(int vlngIndex)
		{
			return (AcGeCtrlPoint3d)mobjDictControlPoints["K" + Conversions.ToString(vlngIndex)];
		}

		public AcGePoint3d GetFitPoint(int vlngIndex)
		{
			return (AcGePoint3d)mobjDictFitPoints["K" + Conversions.ToString(vlngIndex)];
		}

		private void InternCalcSplineFlags()
		{
			if (!mblnFriendLetFlags)
			{
				mlngSplineFlags = Conversions.ToInteger(Interaction.IIf(Closed, 1, 0));
				mlngSplineFlags = Conversions.ToInteger(Operators.OrObject(mlngSplineFlags, Interaction.IIf(base.IsPeriodic, 2, 0)));
				mlngSplineFlags = Conversions.ToInteger(Operators.OrObject(mlngSplineFlags, Interaction.IIf(IsRational, 4, 0)));
				mlngSplineFlags = Conversions.ToInteger(Operators.OrObject(mlngSplineFlags, Interaction.IIf(base.IsPlanar, 8, 0)));
				mlngSplineFlags = Conversions.ToInteger(Operators.OrObject(mlngSplineFlags, Interaction.IIf(IsLinear, 16, 0)));
			}
		}
	}

}
