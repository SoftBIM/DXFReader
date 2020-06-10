using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Threading;
using System.Diagnostics;

namespace DXFLib.Acad
{
	public class AcadCurve : AcadEntity
	{
		public delegate void CurveMinMaxCoordsEventHandler(object MinMaxCoords);

		private const string cstrClassName = "AcadCurve";

		private bool mblnOpened;

		private bool mblnAllData;

		private bool mblnCalcBasePoint;

		private bool mblnCalcSecondPoint;

		private bool mblnCalcCenter;

		private bool mblnCalcStartPoint;

		private bool mblnCalcEndPoint;

		private bool mblnCalcMiddlePoint;

		private bool mblnCalcStartParameter;

		private bool mblnCalcEndParameter;

		private bool mblnCalcStartParameterDegree;

		private bool mblnCalcEndParameterDegree;

		private bool mblnCalcIsClosed;

		private bool mblnCalcIsPeriodic;

		private bool mblnCalcIsPlanar;

		private bool mblnCalcArea;

		private bool mblnCalcLength;

		private bool mblnCalcTotalAngle;

		private bool mblnCalcTotalAngleDegree;

		private bool mblnCalcNormal;

		private bool mblnCalcVector;

		private bool mblnCalcVectorLength;

		private bool mblnCalcDirectionVector;

		private bool mblnCalcRadius;

		private bool mblnCalcMajorAxis;

		private bool mblnCalcMajorNorm;

		private bool mblnCalcMajorRadius;

		private bool mblnCalcRadiusRatio;

		private bool mblnCalcMinorAxis;

		private bool mblnCalcMinorNorm;

		private bool mblnCalcMinorRadius;

		private Enums.AcCurveName mnumCurveName;

		private object mvarBasePoint;

		private object[] madecBasePoint;

		private double[] madblBasePoint;

		private object mvarSecondPoint;

		private object[] madecSecondPoint;

		private double[] madblSecondPoint;

		private object mvarCenter;

		private object[] madecCenter;

		private double[] madblCenter;

		private object mvarStartPoint;

		private object[] madecStartPoint;

		private double[] madblStartPoint;

		private object mvarEndPoint;

		private object[] madecEndPoint;

		private double[] madblEndPoint;

		private object mvarMiddlePoint;

		private object[] madecMiddlePoint;

		private double[] madblMiddlePoint;

		private object mvarStartParameter;

		private object mdecStartParameter;

		private double mdblStartParameter;

		private object mvarEndParameter;

		private object mdecEndParameter;

		private double mdblEndParameter;

		private object mvarStartParameterDegree;

		private object mdecStartParameterDegree;

		private double mdblStartParameterDegree;

		private object mvarEndParameterDegree;

		private object mdecEndParameterDegree;

		private double mdblEndParameterDegree;

		private bool mblnIsClosed;

		private bool mblnIsPeriodic;

		private bool mblnIsPlanar;

		private object mvarArea;

		private object mdecArea;

		private double mdblArea;

		private object mvarLength;

		private object mdecLength;

		private double mdblLength;

		private object mvarTotalAngle;

		private object mdecTotalAngle;

		private double mdblTotalAngle;

		private object mvarTotalAngleDegree;

		private object mdecTotalAngleDegree;

		private double mdblTotalAngleDegree;

		private object mvarNormal;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mvarVector;

		private object[] madecVector;

		private double[] madblVector;

		private object mvarVectorLength;

		private object mdecVectorLength;

		private double mdblVectorLength;

		private object mvarDirectionVector;

		private object[] madecDirectionVector;

		private double[] madblDirectionVector;

		private object mvarRadius;

		private object mdecRadius;

		private double mdblRadius;

		private object mvarMajorAxis;

		private object[] madecMajorAxis;

		private double[] madblMajorAxis;

		private object mvarMajorNorm;

		private object[] madecMajorNorm;

		private double[] madblMajorNorm;

		private object mvarMajorRadius;

		private object mdecMajorRadius;

		private double mdblMajorRadius;

		private object mvarRadiusRatio;

		private object mdecRadiusRatio;

		private double mdblRadiusRatio;

		private object mvarMinorAxis;

		private object[] madecMinorAxis;

		private double[] madblMinorAxis;

		private object mvarMinorNorm;

		private object[] madecMinorNorm;

		private double[] madblMinorNorm;

		private object mvarMinorRadius;

		private object mdecMinorRadius;

		private double mdblMinorRadius;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CurveMinMaxCoordsEventHandler CurveMinMaxCoordsEvent;

		internal Enums.AcCurveName FriendLetCurveName
		{
			set
			{
				InternCalcCurveName(value);
			}
		}

		internal Enums.AcCurveName FriendGetCurveName => mnumCurveName;

		internal object FriendLetBasePoint
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						InternSetBasePoint(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveXLine:
								InternObjCalcXLineBasePoint();
								break;
							case Enums.AcCurveName.acCurveRay:
								InternObjCalcRayBasePoint();
								break;
							case Enums.AcCurveName.acCurveLine:
								InternObjCalcLineBasePoint();
								break;
							case Enums.AcCurveName.acCurveCircle:
								InternObjCalcCircleBasePoint();
								break;
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcBasePoint();
								break;
							case Enums.AcCurveName.acCurveEllipse:
								InternObjCalcEllipseBasePoint();
								break;
						}
						break;
					default:
						InternSetBasePoint(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetBasePoint => RuntimeHelpers.GetObjectValue(mvarBasePoint);

		internal object FriendLetSecondPoint
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
						InternSetSecondPoint(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveXLine:
								InternObjCalcXLineSecondPoint();
								break;
							case Enums.AcCurveName.acCurveRay:
								InternObjCalcRaySecondPoint();
								break;
						}
						break;
					default:
						InternSetSecondPoint(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetSecondPoint => RuntimeHelpers.GetObjectValue(mvarSecondPoint);

		internal object FriendLetCenter
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						InternSetCenter(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveCircle:
								InternObjCalcCircleCenter();
								break;
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcCenter();
								break;
							case Enums.AcCurveName.acCurveEllipse:
								InternObjCalcEllipseCenter();
								break;
						}
						break;
					default:
						InternSetCenter(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetCenter => RuntimeHelpers.GetObjectValue(mvarCenter);

		internal object FriendLetStartPoint
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
						break;
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
						InternSetStartPoint(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveRay:
								InternObjCalcRayStartPoint();
								break;
							case Enums.AcCurveName.acCurveLine:
								InternObjCalcLineStartPoint();
								break;
						}
						break;
					default:
						InternSetStartPoint(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetStartPoint => RuntimeHelpers.GetObjectValue(mvarStartPoint);

		internal object FriendLetEndPoint
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
						break;
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveLine:
						{
							InternSetEndPoint(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveLine)
							{
								InternObjCalcLineEndPoint();
							}
							break;
						}
					default:
						InternSetEndPoint(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetEndPoint => RuntimeHelpers.GetObjectValue(mvarEndPoint);

		internal object FriendLetMiddlePoint
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetMiddlePoint => RuntimeHelpers.GetObjectValue(mvarMiddlePoint);

		internal object FriendLetStartParameter
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveCircle:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						InternSetStartParameter(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcStartParameter();
								break;
							case Enums.AcCurveName.acCurveEllipse:
								InternObjCalcEllipseStartParameter();
								break;
						}
						break;
					default:
						InternSetStartParameter(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetStartParameter
		{
			get
			{
				if (mvarStartParameter == null)
				{
					if (mvarStartParameterDegree == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree)));
				}
				return RuntimeHelpers.GetObjectValue(mvarStartParameter);
			}
		}

		internal object FriendLetEndParameter
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveCircle:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						InternSetEndParameter(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveCircle:
								break;
							case Enums.AcCurveName.acCurveLine:
								InternObjCalcLineEndParameter();
								break;
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcEndParameter();
								break;
							case Enums.AcCurveName.acCurveEllipse:
								InternObjCalcEllipseEndParameter();
								break;
						}
						break;
					default:
						InternSetEndParameter(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetEndParameter
		{
			get
			{
				if (mvarEndParameter == null)
				{
					if (mvarEndParameterDegree == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree)));
				}
				return RuntimeHelpers.GetObjectValue(mvarEndParameter);
			}
		}

		internal object FriendLetStartParameterDegree
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
						break;
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveArc:
						{
							InternSetStartParameterDegree(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveArc)
							{
								InternObjCalcArcEndParameterDegree();
							}
							break;
						}
					default:
						InternSetStartParameterDegree(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetStartParameterDegree
		{
			get
			{
				if (mvarStartParameterDegree == null)
				{
					if (mvarStartParameter == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(mvarStartParameter)));
				}
				return RuntimeHelpers.GetObjectValue(mvarStartParameterDegree);
			}
		}

		internal object FriendLetEndParameterDegree
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
						break;
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveArc:
						{
							InternSetEndParameterDegree(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveArc)
							{
								InternObjCalcArcEndParameterDegree();
							}
							break;
						}
					default:
						InternSetEndParameterDegree(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetEndParameterDegree
		{
			get
			{
				if (mvarEndParameterDegree == null)
				{
					if (mvarEndParameter == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(mvarEndParameter)));
				}
				return RuntimeHelpers.GetObjectValue(mvarEndParameterDegree);
			}
		}

		internal bool FriendLetIsClosed
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						break;
					case Enums.AcCurveName.acCurveSpline:
						{
							InternSetIsClosed(value);
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveSpline)
							{
								InternObjCalcSplineIsClosed();
							}
							break;
						}
					default:
						InternSetIsClosed(value);
						break;
				}
			}
		}

		internal bool FriendLetIsPeriodic
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						break;
					case Enums.AcCurveName.acCurveSpline:
						{
							InternSetIsPeriodic(value);
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveSpline)
							{
								InternObjCalcSplineIsPeriodic();
							}
							break;
						}
					default:
						InternSetIsPeriodic(value);
						break;
				}
			}
		}

		internal bool FriendLetIsPlanar
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
						break;
					case Enums.AcCurveName.acCurveSpline:
						{
							InternSetIsPlanar(value);
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveSpline)
							{
								InternObjCalcSplineIsPlanar();
							}
							break;
						}
					default:
						InternSetIsPlanar(value);
						break;
				}
			}
		}

		internal object FriendLetArea
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
						break;
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveCircle:
						{
							InternSetArea(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveCircle)
							{
								InternObjCalcCircleArea();
							}
							break;
						}
					default:
						InternSetArea(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetArea => RuntimeHelpers.GetObjectValue(mvarArea);

		internal object FriendLetLength
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
						break;
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
						InternSetLength(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveLine:
								InternObjCalcLineLength();
								break;
							case Enums.AcCurveName.acCurveCircle:
								InternObjCalcCircleLength();
								break;
						}
						break;
					default:
						InternSetLength(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetLength => RuntimeHelpers.GetObjectValue(mvarLength);

		internal object FriendLetTotalAngle
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetTotalAngle
		{
			get
			{
				if (mvarTotalAngle == null)
				{
					if (mvarTotalAngleDegree == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree)));
				}
				return RuntimeHelpers.GetObjectValue(mvarTotalAngle);
			}
		}

		internal object FriendLetTotalAngleDegree
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetTotalAngleDegree(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetTotalAngleDegree
		{
			get
			{
				if (mvarTotalAngleDegree == null)
				{
					if (mvarTotalAngle == null)
					{
						return null;
					}
					return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(mvarTotalAngle)));
				}
				return RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree);
			}
		}

		internal object FriendLetNormal
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
						break;
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
					case Enums.AcCurveName.acCurveEllipse:
					case Enums.AcCurveName.acCurveSpline:
						InternSetNormal(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveLine:
								InternObjCalcLineNormal();
								break;
							case Enums.AcCurveName.acCurveCircle:
								InternObjCalcCircleNormal();
								break;
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcNormal();
								break;
							case Enums.AcCurveName.acCurveEllipse:
								InternObjCalcEllipseNormal();
								break;
							case Enums.AcCurveName.acCurveSpline:
								InternObjCalcSplineNormal();
								break;
						}
						break;
					default:
						InternSetNormal(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetNormal => RuntimeHelpers.GetObjectValue(mvarNormal);

		internal object FriendLetVector
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetVector(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetVector => RuntimeHelpers.GetObjectValue(mvarVector);

		internal object FriendLetVectorLength
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetVectorLength(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetVectorLength => RuntimeHelpers.GetObjectValue(mvarVectorLength);

		internal object FriendLetDirectionVector
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetDirectionVector => RuntimeHelpers.GetObjectValue(mvarDirectionVector);

		internal object FriendLetRadius
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
						InternSetRadius(RuntimeHelpers.GetObjectValue(value));
						switch (mnumCurveName)
						{
							case Enums.AcCurveName.acCurveCircle:
								InternObjCalcCircleRadius();
								break;
							case Enums.AcCurveName.acCurveArc:
								InternObjCalcArcRadius();
								break;
						}
						break;
					default:
						InternSetRadius(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetRadius => RuntimeHelpers.GetObjectValue(mvarRadius);

		internal object FriendLetMajorAxis
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveEllipse:
						{
							InternSetMajorAxis(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveEllipse)
							{
								InternObjCalcEllipseMajorAxis();
							}
							break;
						}
					default:
						InternSetMajorAxis(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetMajorAxis => RuntimeHelpers.GetObjectValue(mvarMajorAxis);

		internal object FriendLetMajorNorm
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetMajorNorm(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetMajorNorm => RuntimeHelpers.GetObjectValue(mvarMajorNorm);

		internal object FriendLetMajorRadius
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveEllipse:
						{
							InternSetMajorRadius(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveEllipse)
							{
								InternObjCalcEllipseMajorRadius();
							}
							break;
						}
					default:
						InternSetMajorRadius(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetMajorRadius => RuntimeHelpers.GetObjectValue(mvarMajorRadius);

		internal object FriendLetRadiusRatio
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveEllipse:
						{
							InternSetRadiusRatio(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveEllipse)
							{
								InternObjCalcEllipseRadiusRatio();
							}
							break;
						}
					default:
						InternSetRadiusRatio(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetRadiusRatio => RuntimeHelpers.GetObjectValue(mvarRadiusRatio);

		internal object FriendLetMinorAxis
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetMinorAxis(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetMinorAxis => RuntimeHelpers.GetObjectValue(mvarMinorAxis);

		internal object FriendLetMinorNorm
		{
			set
			{
				Enums.AcCurveName acCurveName = mnumCurveName;
				if ((uint)(acCurveName - 1) > 6u)
				{
					InternSetMinorNorm(RuntimeHelpers.GetObjectValue(value));
				}
			}
		}

		internal object FriendGetMinorNorm => RuntimeHelpers.GetObjectValue(mvarMinorNorm);

		internal object FriendLetMinorRadius
		{
			set
			{
				switch (mnumCurveName)
				{
					case Enums.AcCurveName.acCurveXLine:
					case Enums.AcCurveName.acCurveRay:
					case Enums.AcCurveName.acCurveLine:
					case Enums.AcCurveName.acCurveCircle:
					case Enums.AcCurveName.acCurveArc:
						break;
					case Enums.AcCurveName.acCurveSpline:
						break;
					case Enums.AcCurveName.acCurveEllipse:
						{
							InternSetMinorRadius(RuntimeHelpers.GetObjectValue(value));
							Enums.AcCurveName acCurveName = mnumCurveName;
							if (acCurveName == Enums.AcCurveName.acCurveEllipse)
							{
								InternObjCalcEllipseMinorRadius();
							}
							break;
						}
					default:
						InternSetMinorRadius(RuntimeHelpers.GetObjectValue(value));
						break;
				}
			}
		}

		internal object FriendGetMinorRadius => RuntimeHelpers.GetObjectValue(mvarMinorRadius);

		public bool IsClosed => mblnIsClosed;

		public bool IsPeriodic => mblnIsPeriodic;

		public bool IsPlanar => mblnIsPlanar;

		public event CurveMinMaxCoordsEventHandler CurveMinMaxCoords
		{
			[CompilerGenerated]
			add
			{
				CurveMinMaxCoordsEventHandler curveMinMaxCoordsEventHandler = CurveMinMaxCoordsEvent;
				CurveMinMaxCoordsEventHandler curveMinMaxCoordsEventHandler2;
				do
				{
					curveMinMaxCoordsEventHandler2 = curveMinMaxCoordsEventHandler;
					CurveMinMaxCoordsEventHandler value2 = (CurveMinMaxCoordsEventHandler)Delegate.Combine(curveMinMaxCoordsEventHandler2, value);
					curveMinMaxCoordsEventHandler = Interlocked.CompareExchange(ref CurveMinMaxCoordsEvent, value2, curveMinMaxCoordsEventHandler2);
				}
				while ((object)curveMinMaxCoordsEventHandler != curveMinMaxCoordsEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				CurveMinMaxCoordsEventHandler curveMinMaxCoordsEventHandler = CurveMinMaxCoordsEvent;
				CurveMinMaxCoordsEventHandler curveMinMaxCoordsEventHandler2;
				do
				{
					curveMinMaxCoordsEventHandler2 = curveMinMaxCoordsEventHandler;
					CurveMinMaxCoordsEventHandler value2 = (CurveMinMaxCoordsEventHandler)Delegate.Remove(curveMinMaxCoordsEventHandler2, value);
					curveMinMaxCoordsEventHandler = Interlocked.CompareExchange(ref CurveMinMaxCoordsEvent, value2, curveMinMaxCoordsEventHandler2);
				}
				while ((object)curveMinMaxCoordsEventHandler != curveMinMaxCoordsEventHandler2);
			}
		}

		public AcadCurve()
		{
			madecBasePoint = new object[3];
			madblBasePoint = new double[3];
			madecSecondPoint = new object[3];
			madblSecondPoint = new double[3];
			madecCenter = new object[3];
			madblCenter = new double[3];
			madecStartPoint = new object[3];
			madblStartPoint = new double[3];
			madecEndPoint = new object[3];
			madblEndPoint = new double[3];
			madecMiddlePoint = new object[3];
			madblMiddlePoint = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			madecVector = new object[3];
			madblVector = new double[3];
			madecDirectionVector = new object[3];
			madblDirectionVector = new double[3];
			madecMajorAxis = new object[3];
			madblMajorAxis = new double[3];
			madecMajorNorm = new object[3];
			madblMajorNorm = new double[3];
			madecMinorAxis = new object[3];
			madblMinorAxis = new double[3];
			madecMinorNorm = new object[3];
			madblMinorNorm = new double[3];
			mblnOpened = true;
			InternCalcCurveName(Enums.AcCurveName.acCurveCurve);
			base.FriendLetDXFName = "CURVE";
			base.FriendLetObjectName = "AcDbCurve";
			base.FriendLetEntityType = Enums.AcEntityName.acCurve;
		}

		~AcadCurve()
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

		public object PointAtParam(object vvarParameter)
		{
			return RuntimeHelpers.GetObjectValue(InternPointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
		}

		public object ParamAtPoint(object vvarPoint)
		{
			return null;
		}

		public object PointAtDist(object vvarDistance)
		{
			return null;
		}

		public object ParamAtDist(object vvarDistance)
		{
			return null;
		}

		public object DistAtParam(object vvarParameter)
		{
			return null;
		}

		public object DistAtPoint(object vvarPoint)
		{
			return null;
		}

		public object ClosestPointTo(object vvarPoint)
		{
			return null;
		}

		public object FirstDeriv(object vvarParameter)
		{
			return null;
		}

		public object SecondDeriv(object vvarParameter)
		{
			return null;
		}

		private void InternCalcCurveName(Enums.AcCurveName vnumCurveName)
		{
			InternResetAll();
			mnumCurveName = vnumCurveName;
			switch (mnumCurveName)
			{
				case Enums.AcCurveName.acCurveXLine:
					InternObjCalcXLineStart();
					break;
				case Enums.AcCurveName.acCurveRay:
					InternObjCalcRayStart();
					break;
				case Enums.AcCurveName.acCurveLine:
					InternObjCalcLineStart();
					break;
				case Enums.AcCurveName.acCurveCircle:
					InternObjCalcCircleStart();
					break;
				case Enums.AcCurveName.acCurveArc:
					InternObjCalcArcStart();
					break;
				case Enums.AcCurveName.acCurveEllipse:
					InternObjCalcEllipseStart();
					break;
				case Enums.AcCurveName.acCurveSpline:
					InternObjCalcSplineStart();
					break;
			}
		}

		private bool InternAllData()
		{
			if (mblnAllData)
			{
				return true;
			}
			switch (mnumCurveName)
			{
				case Enums.AcCurveName.acCurveXLine:
					if (InternObjCalcXLineAllData())
					{
						mblnAllData = true;
						InternObjCalcXLineAll();
					}
					break;
				case Enums.AcCurveName.acCurveRay:
					if (InternObjCalcRayAllData())
					{
						mblnAllData = true;
						InternObjCalcRayAll();
					}
					break;
				case Enums.AcCurveName.acCurveLine:
					if (InternObjCalcLineAllData())
					{
						mblnAllData = true;
						InternObjCalcLineAll();
					}
					break;
				case Enums.AcCurveName.acCurveCircle:
					if (InternObjCalcCircleAllData())
					{
						mblnAllData = true;
						InternObjCalcCircleAll();
					}
					break;
				case Enums.AcCurveName.acCurveArc:
					if (InternObjCalcArcAllData())
					{
						mblnAllData = true;
						InternObjCalcArcAll();
					}
					break;
				case Enums.AcCurveName.acCurveEllipse:
					if (InternObjCalcEllipseAllData())
					{
						mblnAllData = true;
						InternObjCalcEllipseAll();
					}
					break;
				case Enums.AcCurveName.acCurveSpline:
					if (InternObjCalcSplineAllData())
					{
						mblnAllData = true;
						InternObjCalcSplineAll();
					}
					break;
			}
			bool InternAllData = default(bool);
			return InternAllData;
		}

		private object InternPointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			switch (mnumCurveName)
			{
				case Enums.AcCurveName.acCurveXLine:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcXLinePointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveRay:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcRayPointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveLine:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcLinePointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveCircle:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveArc:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveEllipse:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
				case Enums.AcCurveName.acCurveSpline:
					dvarPoint = RuntimeHelpers.GetObjectValue(InternObjCaclSplinePointAtParam(RuntimeHelpers.GetObjectValue(vvarParameter)));
					break;
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private void InternResetAll()
		{
			mblnAllData = false;
			mvarBasePoint = null;
			mblnCalcBasePoint = false;
			mvarSecondPoint = null;
			mblnCalcSecondPoint = false;
			mvarCenter = null;
			mblnCalcCenter = false;
			mvarStartPoint = null;
			mblnCalcStartPoint = false;
			mvarEndPoint = null;
			mblnCalcEndPoint = false;
			mvarMiddlePoint = null;
			mblnCalcMiddlePoint = false;
			mvarStartParameter = null;
			mblnCalcStartParameter = false;
			mvarEndParameter = null;
			mblnCalcEndParameter = false;
			mvarStartParameterDegree = null;
			mblnCalcStartParameterDegree = false;
			mvarEndParameterDegree = null;
			mblnCalcEndParameterDegree = false;
			mblnIsClosed = false;
			mblnCalcIsClosed = false;
			mblnIsPeriodic = false;
			mblnCalcIsPeriodic = false;
			mblnIsPlanar = false;
			mblnCalcIsPlanar = false;
			mvarArea = null;
			mblnCalcArea = false;
			mvarLength = null;
			mblnCalcLength = false;
			mvarTotalAngle = null;
			mblnCalcTotalAngle = false;
			mvarTotalAngleDegree = null;
			mblnCalcTotalAngleDegree = false;
			mvarNormal = null;
			mblnCalcNormal = false;
			mvarVector = null;
			mblnCalcVector = false;
			mvarVectorLength = null;
			mblnCalcVectorLength = false;
			mvarDirectionVector = null;
			mblnCalcDirectionVector = false;
			mvarRadius = null;
			mblnCalcRadius = false;
			mvarMajorAxis = null;
			mblnCalcMajorAxis = false;
			mvarMajorNorm = null;
			mblnCalcMajorNorm = false;
			mvarMajorRadius = null;
			mblnCalcMajorRadius = false;
			mvarRadiusRatio = null;
			mblnCalcRadiusRatio = false;
			mvarMinorAxis = null;
			mblnCalcMinorAxis = false;
			mvarMinorNorm = null;
			mblnCalcMinorNorm = false;
			mvarMinorRadius = null;
			mblnCalcMinorRadius = false;
		}

		private void InternSetBasePoint(object vvarBasePoint)
		{
			ref object[] reference = ref madecBasePoint;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblBasePoint;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarBasePoint);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecBasePoint, madblBasePoint));
				mblnCalcBasePoint = true;
			}
		}

		private void InternSetSecondPoint(object vvarSecondPoint)
		{
			ref object[] reference = ref madecSecondPoint;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblSecondPoint;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarSecondPoint);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarSecondPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecSecondPoint, madblSecondPoint));
				mblnCalcSecondPoint = true;
			}
		}

		private void InternSetCenter(object vvarCenter)
		{
			ref object[] reference = ref madecCenter;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblCenter;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarCenter);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarCenter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecCenter, madblCenter));
				mblnCalcCenter = true;
			}
		}

		private void InternSetStartPoint(object vvarStartPoint)
		{
			ref object[] reference = ref madecStartPoint;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblStartPoint;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarStartPoint);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecStartPoint, madblStartPoint));
				mblnCalcStartPoint = true;
			}
		}

		private void InternSetEndPoint(object vvarEndPoint)
		{
			ref object[] reference = ref madecEndPoint;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblEndPoint;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarEndPoint);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecEndPoint, madblEndPoint));
				mblnCalcEndPoint = true;
			}
		}

		private void InternSetMiddlePoint(object vvarMiddlePoint)
		{
			ref object[] reference = ref madecMiddlePoint;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblMiddlePoint;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMiddlePoint);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarMiddlePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMiddlePoint, madblMiddlePoint));
				mblnCalcMiddlePoint = true;
			}
		}

		private void InternSetStartParameter(object vvarStartParameter)
		{
			ref object rvarValueDec = ref mdecStartParameter;
			ref double reference = ref mdblStartParameter;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarStartParameter);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarStartParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartParameter), mdblStartParameter));
				mvarStartParameterDegree = null;
				if (mvarEndParameterDegree != null)
				{
					InternSetEndParameter(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))));
				}
				mblnCalcStartParameter = true;
				mblnCalcStartParameterDegree = false;
			}
		}

		private void InternSetEndParameter(object vvarEndParameter)
		{
			ref object rvarValueDec = ref mdecEndParameter;
			ref double reference = ref mdblEndParameter;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarEndParameter);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarEndParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndParameter), mdblEndParameter));
				mvarEndParameterDegree = null;
				if (mvarStartParameterDegree != null)
				{
					InternSetStartParameter(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))));
				}
				mblnCalcEndParameter = true;
				mblnCalcEndParameterDegree = false;
			}
		}

		private void InternSetStartParameterDegree(object vvarStartParameterDegree)
		{
			ref object rvarValueDec = ref mdecStartParameterDegree;
			ref double reference = ref mdblStartParameterDegree;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarStartParameterDegree);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarStartParameterDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecStartParameterDegree), mdblStartParameterDegree));
				mvarStartParameter = null;
				if (mvarEndParameter != null)
				{
					InternSetEndParameterDegree(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				}
				mblnCalcStartParameterDegree = true;
				mblnCalcStartParameter = false;
			}
		}

		private void InternSetEndParameterDegree(object vvarEndParameterDegree)
		{
			ref object rvarValueDec = ref mdecEndParameterDegree;
			ref double reference = ref mdblEndParameterDegree;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarEndParameterDegree);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarEndParameterDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecEndParameterDegree), mdblEndParameterDegree));
				mvarEndParameter = null;
				if (mvarStartParameter != null)
				{
					InternSetStartParameterDegree(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				}
				mblnCalcEndParameterDegree = true;
				mblnCalcEndParameter = false;
			}
		}

		private void InternSetIsClosed(bool vblnIsClosed)
		{
			mblnIsClosed = vblnIsClosed;
			mblnCalcIsClosed = true;
		}

		private void InternSetIsPeriodic(bool vblnIsPeriodic)
		{
			mblnIsPeriodic = vblnIsPeriodic;
			mblnCalcIsPeriodic = true;
		}

		private void InternSetIsPlanar(bool vblnIsPlanar)
		{
			mblnIsPlanar = vblnIsPlanar;
			mblnCalcIsPlanar = true;
		}

		private void InternSetArea(object vvarArea)
		{
			ref object rvarValueDec = ref mdecArea;
			ref double reference = ref mdblArea;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarArea);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarArea = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecArea), mdblArea));
				mblnCalcArea = true;
			}
		}

		private void InternSetLength(object vvarLength)
		{
			ref object rvarValueDec = ref mdecLength;
			ref double reference = ref mdblLength;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarLength);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecLength), mdblLength));
				mblnCalcLength = true;
			}
		}

		private void InternSetTotalAngle(object vvarTotalAngle)
		{
			ref object rvarValueDec = ref mdecTotalAngle;
			ref double reference = ref mdblTotalAngle;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarTotalAngle);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarTotalAngle = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecTotalAngle), mdblTotalAngle));
				mvarTotalAngleDegree = null;
				mblnCalcTotalAngle = true;
				mblnCalcTotalAngleDegree = false;
			}
		}

		private void InternSetTotalAngleDegree(object vvarTotalAngleDegree)
		{
			ref object rvarValueDec = ref mdecTotalAngleDegree;
			ref double reference = ref mdblTotalAngleDegree;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarTotalAngleDegree);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarTotalAngleDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecTotalAngleDegree), mdblTotalAngleDegree));
				mvarTotalAngle = null;
				mblnCalcTotalAngleDegree = true;
				mblnCalcTotalAngle = false;
			}
		}

		private void InternSetNormal(object vvarNormal)
		{
			ref object[] reference = ref madecNormal;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblNormal;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarNormal);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarNormal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecNormal, madblNormal));
				mblnCalcNormal = true;
			}
		}

		private void InternSetVector(object vvarVector)
		{
			ref object[] reference = ref madecVector;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblVector;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarVector);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecVector, madblVector));
				mblnCalcVector = true;
			}
		}

		private void InternSetVectorLength(object vvarVectorLength)
		{
			ref object rvarValueDec = ref mdecVectorLength;
			ref double reference = ref mdblVectorLength;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarVectorLength);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarVectorLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecVectorLength), mdblVectorLength));
				mblnCalcVectorLength = true;
			}
		}

		private void InternSetDirectionVector(object vvarDirectionVector)
		{
			ref object[] reference = ref madecDirectionVector;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblDirectionVector;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarDirectionVector);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarDirectionVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecDirectionVector, madblDirectionVector));
				mblnCalcDirectionVector = true;
			}
		}

		private void InternSetRadius(object vvarRadius)
		{
			ref object rvarValueDec = ref mdecRadius;
			ref double reference = ref mdblRadius;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarRadius);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRadius), mdblRadius));
				mblnCalcRadius = true;
			}
		}

		private void InternSetMajorAxis(object vvarMajorAxis)
		{
			ref object[] reference = ref madecMajorAxis;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblMajorAxis;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMajorAxis);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarMajorAxis = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMajorAxis, madblMajorAxis));
				mblnCalcMajorAxis = true;
			}
		}

		private void InternSetMajorNorm(object vvarMajorNorm)
		{
			ref object[] reference = ref madecMajorNorm;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblMajorNorm;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMajorNorm);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarMajorNorm = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMajorNorm, madblMajorNorm));
				mblnCalcMajorNorm = true;
			}
		}

		private void InternSetMajorRadius(object vvarMajorRadius)
		{
			ref object rvarValueDec = ref mdecMajorRadius;
			ref double reference = ref mdblMajorRadius;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMajorRadius);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarMajorRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMajorRadius), mdblMajorRadius));
				mblnCalcMajorRadius = true;
			}
		}

		private void InternSetRadiusRatio(object vvarRadiusRatio)
		{
			ref object rvarValueDec = ref mdecRadiusRatio;
			ref double reference = ref mdblRadiusRatio;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarRadiusRatio);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarRadiusRatio = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRadiusRatio), mdblRadiusRatio));
				mblnCalcRadiusRatio = true;
			}
		}

		private void InternSetMinorAxis(object vvarMinorAxis)
		{
			ref object[] reference = ref madecMinorAxis;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblMinorAxis;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMinorAxis);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarMinorAxis = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMinorAxis, madblMinorAxis));
				mblnCalcMinorAxis = true;
			}
		}

		private void InternSetMinorNorm(object vvarMinorNorm)
		{
			ref object[] reference = ref madecMinorNorm;
			object ravarArrayDec = reference;
			ref double[] reference2 = ref madblMinorNorm;
			object ravarArrayDbl = reference2;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMinorNorm);
			string nrstrErrMsg = "";
			bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, objectValue, ref nrstrErrMsg);
			reference2 = (double[])ravarArrayDbl;
			reference = (object[])ravarArrayDec;
			if (flag)
			{
				mvarMinorNorm = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecMinorNorm, madblMinorNorm));
				mblnCalcMinorNorm = true;
			}
		}

		private void InternSetMinorRadius(object vvarMinorRadius)
		{
			ref object rvarValueDec = ref mdecMinorRadius;
			ref double reference = ref mdblMinorRadius;
			object rvarValueDbl = reference;
			object objectValue = RuntimeHelpers.GetObjectValue(vvarMinorRadius);
			string nrstrErrMsg = "";
			bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
			reference = Conversions.ToDouble(rvarValueDbl);
			if (num)
			{
				mvarMinorRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinorRadius), mdblMinorRadius));
				mblnCalcMinorRadius = true;
			}
		}

		private bool InternObjCalcXLineAllData()
		{
			return mblnCalcBasePoint & mblnCalcSecondPoint;
		}

		private void InternObjCalcXLineStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarSecondPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne));
			mblnIsClosed = false;
			mblnIsPeriodic = false;
			mblnIsPlanar = true;
			mvarDirectionVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne));
		}

		private void InternObjCalcXLineAll()
		{
			if (InternAllData())
			{
				if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				0
				}, null), TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				1
				}, null), TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				2
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				2
				}, null), TextCompare: false))))
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarSecondPoint))))));
				}
				else
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne)));
				}
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcXLineMinMaxCoords();
			}
		}

		private void InternObjCalcXLineBasePoint()
		{
			if (InternAllData())
			{
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcXLineMinMaxCoords();
			}
		}

		private void InternObjCalcXLineSecondPoint()
		{
			if (InternAllData())
			{
				if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				0
				}, null), TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				1
				}, null), TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				2
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				2
				}, null), TextCompare: false))))
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarSecondPoint))))));
				}
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcXLineMinMaxCoords();
			}
		}

		private void InternObjCalcXLineMinMaxCoords()
		{
			if (InternAllData())
			{
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					0
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					0
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					1
				}, null)
				});
			}
		}

		private object InternObjCalcXLinePointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					object dvarVecSkalar = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(vvarParameter)));
					dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(dvarVecSkalar)));
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcRayAllData()
		{
			return mblnCalcBasePoint & mblnCalcSecondPoint;
		}

		private void InternObjCalcRayStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarSecondPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne));
			mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mblnIsClosed = false;
			mblnIsPeriodic = false;
			mblnIsPlanar = true;
			mvarDirectionVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne));
		}

		private void InternObjCalcRayAll()
		{
			if (InternAllData())
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(mvarBasePoint));
				if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				0
				}, null), TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				1
				}, null), TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				2
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				2
				}, null), TextCompare: false))))
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarSecondPoint))))));
				}
				else
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointXOne, hwpDxf_Vars.padblPointXOne)));
				}
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcRayMinMaxCoords();
			}
		}

		private void InternObjCalcRayBasePoint()
		{
			if (InternAllData())
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(mvarBasePoint));
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcRayMinMaxCoords();
			}
		}

		private void InternObjCalcRaySecondPoint()
		{
			if (InternAllData())
			{
				if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				0
				}, null), TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				1
				}, null), TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
				2
				}, null), NewLateBinding.LateIndexGet(mvarSecondPoint, new object[1]
				{
				2
				}, null), TextCompare: false))))
				{
					InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarSecondPoint))))));
				}
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcRayMinMaxCoords();
			}
		}

		private void InternObjCalcRayStartPoint()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarStartPoint));
				InternSetSecondPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternObjCalcRayMinMaxCoords();
			}
		}

		private void InternObjCalcRayMinMaxCoords()
		{
			if (InternAllData())
			{
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					0
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					0
				}, null),
				NewLateBinding.LateIndexGet(mvarBasePoint, new object[1]
				{
					1
				}, null)
				});
			}
		}

		private object InternObjCalcRayPointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg) && Operators.ConditionalCompareObjectGreaterEqual(vvarParameter, mvarStartParameter, TextCompare: false))
				{
					object dvarVecSkalar = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(vvarParameter)));
					dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(dvarVecSkalar)));
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcLineAllData()
		{
			return mblnCalcStartPoint & mblnCalcEndPoint & mblnCalcNormal;
		}

		private void InternObjCalcLineStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMiddlePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarEndParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mblnIsClosed = false;
			mblnIsPeriodic = false;
			mblnIsPlanar = true;
			mvarLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarTotalAngle = null;
			mvarTotalAngleDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarNormal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			mvarVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarVectorLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarDirectionVector = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
		}

		private void InternObjCalcLineAll()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarStartPoint));
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternSetVectorLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecLength(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetTotalAngle(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecXAng(RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternSetLength(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetEndParameter(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineStartPoint()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarStartPoint));
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternSetVectorLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecLength(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetTotalAngle(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecXAng(RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternSetLength(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetEndParameter(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineEndPoint()
		{
			if (InternAllData())
			{
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternSetVectorLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecLength(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetDirectionVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(mvarVector))));
				InternSetTotalAngle(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecXAng(RuntimeHelpers.GetObjectValue(mvarDirectionVector))));
				InternSetLength(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetEndParameter(RuntimeHelpers.GetObjectValue(mvarVectorLength));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineNormal()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcLineBasePoint()
		{
			if (InternAllData())
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(mvarBasePoint));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(mvarVectorLength))))));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarBasePoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineLength()
		{
			if (InternAllData())
			{
				InternSetEndParameter(RuntimeHelpers.GetObjectValue(mvarLength));
				InternSetVectorLength(RuntimeHelpers.GetObjectValue(mvarLength));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(mvarVectorLength))))));
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineEndParameter()
		{
			if (InternAllData())
			{
				InternSetEndParameter(RuntimeHelpers.GetObjectValue(mvarEndParameter));
				InternSetVectorLength(RuntimeHelpers.GetObjectValue(mvarEndParameter));
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), Operators.MultiplyObject(mvarVectorLength, Interaction.IIf(Expression: false, 0.5m, 0.5)))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(mvarVectorLength))))));
				InternSetVector(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.Vector(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(mvarEndPoint))));
				InternObjCalcLineMinMaxCoords();
			}
		}

		private void InternObjCalcLineMinMaxCoords()
		{
			if (InternAllData())
			{
				object dvarMaxCoordX = (!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null));
				object dvarMaxCoordY = (!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null));
				object dvarMinCoordX = (!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null));
				object dvarMinCoordY = (!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null));
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				dvarMaxCoordX,
				dvarMaxCoordY,
				dvarMinCoordX,
				dvarMinCoordY
				});
			}
		}

		private object InternObjCalcLinePointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg) && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vvarParameter, mvarStartParameter, TextCompare: false), Operators.CompareObjectLessEqual(vvarParameter, mvarEndParameter, TextCompare: false))))
				{
					object dvarVecSkalar = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarDirectionVector), RuntimeHelpers.GetObjectValue(vvarParameter)));
					dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarStartPoint), RuntimeHelpers.GetObjectValue(dvarVecSkalar)));
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcCircleAllData()
		{
			return mblnCalcCenter & mblnCalcRadius;
		}

		private void InternObjCalcCircleStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarCenter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMiddlePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarEndParameter = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad360());
			mblnIsClosed = true;
			mblnIsPeriodic = true;
			mblnIsPlanar = true;
			mvarArea = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarTotalAngle = null;
			mvarTotalAngleDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(360L), 360.0));
			mvarNormal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			mvarRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
		}

		private void InternObjCalcCircleAll()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadArea(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadCircum(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleCenter()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleRadius()
		{
			if (InternAllData())
			{
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadArea(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadCircum(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleNormal()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcCircleBasePoint()
		{
			if (InternAllData())
			{
				InternSetCenter(RuntimeHelpers.GetObjectValue(mvarBasePoint));
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleLength()
		{
			if (InternAllData())
			{
				InternSetRadius(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircCircumRad(RuntimeHelpers.GetObjectValue(mvarLength))));
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadArea(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleArea()
		{
			if (InternAllData())
			{
				InternSetRadius(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircAreaRad(RuntimeHelpers.GetObjectValue(mvarArea))));
				InternSetStartPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetEndPoint(new object[3]
				{
				Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					0
				}, null), mvarRadius),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					1
				}, null),
				NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
					2
				}, null)
				});
				InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcCirclePointAtParam(Operators.DivideObject(Operators.SubtractObject(mvarEndParameter, mvarStartParameter), Interaction.IIf(Expression: false, 0.5m, 0.5)))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.CircRadCircum(RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcCircleMinMaxCoords();
			}
		}

		private void InternObjCalcCircleMinMaxCoords()
		{
			if (InternAllData())
			{
				object dvarMaxCoordX = Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
				0
				}, null), mvarRadius);
				object dvarMaxCoordY = Operators.AddObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
				1
				}, null), mvarRadius);
				object dvarMinCoordX = Operators.SubtractObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
				0
				}, null), mvarRadius);
				object dvarMinCoordY = Operators.SubtractObject(NewLateBinding.LateIndexGet(mvarCenter, new object[1]
				{
				1
				}, null), mvarRadius);
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				dvarMaxCoordX,
				dvarMaxCoordY,
				dvarMinCoordX,
				dvarMinCoordY
				});
			}
		}

		private object InternObjCalcCirclePointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg) && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vvarParameter, mvarStartParameter, TextCompare: false), Operators.CompareObjectLessEqual(vvarParameter, mvarEndParameter, TextCompare: false))))
				{
					object dvarCos = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
					object dvarSin = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
					object dvarVector = new object[3]
					{
					dvarCos,
					dvarSin,
					Interaction.IIf(Expression: false, 0m, 0.0)
					};
					object dvarVecSkalar = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(dvarVector), RuntimeHelpers.GetObjectValue(mvarRadius)));
					dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarCenter), RuntimeHelpers.GetObjectValue(dvarVecSkalar)));
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcArcAllData()
		{
			return mblnCalcCenter & mblnCalcRadius & (mblnCalcStartParameter | mblnCalcStartParameterDegree) & (mblnCalcEndParameter | mblnCalcEndParameterDegree);
		}

		private void InternObjCalcArcStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarCenter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMiddlePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartParameter = null;
			mvarEndParameter = null;
			mvarStartParameterDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarEndParameterDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mblnIsClosed = false;
			mblnIsPeriodic = false;
			mblnIsPlanar = true;
			mvarArea = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarTotalAngle = null;
			mvarTotalAngleDegree = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarNormal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			mvarRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
		}

		private void InternObjCalcArcAll()
		{
			if (!InternAllData())
			{
				return;
			}
			InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
			if (mblnCalcStartParameterDegree & mblnCalcEndParameterDegree)
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetTotalAngleDegree(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngleDegree(Operators.SubtractObject(Interaction.IIf(Expression: false, new decimal(360L), 360.0), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
			}
			else
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
			}
			InternObjCalcArcMinMaxCoords();
		}

		private void InternObjCalcArcCenter()
		{
			if (!InternAllData())
			{
				return;
			}
			InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
			if (mblnCalcStartParameterDegree & mblnCalcEndParameterDegree)
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
			}
			else
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
			}
			InternObjCalcArcMinMaxCoords();
		}

		private void InternObjCalcArcRadius()
		{
			if (!InternAllData())
			{
				return;
			}
			if (mblnCalcStartParameterDegree & mblnCalcEndParameterDegree)
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
			}
			else
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
			}
			InternObjCalcArcMinMaxCoords();
		}

		private void InternObjCalcArcStartParameter()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcArcMinMaxCoords();
			}
		}

		private void InternObjCalcArcEndParameter()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngle), RuntimeHelpers.GetObjectValue(mvarRadius))));
				InternObjCalcArcMinMaxCoords();
			}
		}

		private void InternObjCalcArcStartParameterDegree()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetTotalAngleDegree(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngleDegree(Operators.SubtractObject(Interaction.IIf(Expression: false, new decimal(360L), 360.0), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternObjCalcArcMinMaxCoords();
			}
		}

		private void InternObjCalcArcEndParameterDegree()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetTotalAngleDegree(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngleDegree(Operators.SubtractObject(Interaction.IIf(Expression: false, new decimal(360L), 360.0), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcArea(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRadArcLen(RuntimeHelpers.GetObjectValue(mvarTotalAngleDegree), RuntimeHelpers.GetObjectValue(mvarRadius), nvblnAngleInDegree: true)));
				InternObjCalcArcMinMaxCoords();
			}
		}

		private void InternObjCalcArcNormal()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcArcBasePoint()
		{
			if (!InternAllData())
			{
				return;
			}
			InternSetCenter(RuntimeHelpers.GetObjectValue(mvarBasePoint));
			if (mblnCalcStartParameterDegree & mblnCalcEndParameterDegree)
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree))))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree))))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameterDegree, mvarStartParameterDegree, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameterDegree, mvarStartParameterDegree))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameterDegree, mvarEndParameterDegree))));
				}
			}
			else
			{
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
			}
			InternObjCalcArcMinMaxCoords();
		}

		private void InternObjCalcArcMinMaxCoords()
		{
			if (InternAllData())
			{
				object dvarPointQuad1 = RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad0())));
				object dvarPointQuad2 = RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad90())));
				object dvarPointQuad3 = RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad180())));
				object dvarPointQuad4 = RuntimeHelpers.GetObjectValue(InternObjCalcArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad270())));
				object dvarMaxCoordX = (dvarPointQuad1 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad1, new object[1]
				{
				0
				}, null)) : ((!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null)));
				object dvarMaxCoordY = (dvarPointQuad2 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad2, new object[1]
				{
				1
				}, null)) : ((!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null)));
				object dvarMinCoordX = (dvarPointQuad3 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad3, new object[1]
				{
				0
				}, null)) : ((!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null)));
				object dvarMinCoordY = (dvarPointQuad4 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad4, new object[1]
				{
				1
				}, null)) : ((!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null)));
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				dvarMaxCoordX,
				dvarMaxCoordY,
				dvarMinCoordX,
				dvarMinCoordY
				});
			}
		}

		private object InternObjCalcArcPointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					object dvarStartParameter;
					object dvarEndParameter;
					if (mblnCalcStartParameterDegree & mblnCalcEndParameterDegree)
					{
						dvarStartParameter = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarStartParameterDegree)));
						dvarEndParameter = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(mvarEndParameterDegree)));
					}
					else
					{
						dvarStartParameter = RuntimeHelpers.GetObjectValue(mvarStartParameter);
						dvarEndParameter = RuntimeHelpers.GetObjectValue(mvarEndParameter);
					}
					if (Operators.ConditionalCompareObjectGreater(dvarStartParameter, dvarEndParameter, TextCompare: false))
					{
						dvarStartParameter = Operators.SubtractObject(dvarStartParameter, hwpDxf_Vars.pobjUtilMath.AngRad360());
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vvarParameter, dvarStartParameter, TextCompare: false), Operators.CompareObjectLessEqual(vvarParameter, dvarEndParameter, TextCompare: false))))
					{
						object dvarCos = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
						object dvarSin = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
						object dvarVector = new object[3]
						{
						dvarCos,
						dvarSin,
						Interaction.IIf(Expression: false, 0m, 0.0)
						};
						object dvarVecSkalar = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(dvarVector), RuntimeHelpers.GetObjectValue(mvarRadius)));
						dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarCenter), RuntimeHelpers.GetObjectValue(dvarVecSkalar)));
					}
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcEllipseAllData()
		{
			return mblnCalcCenter & mblnCalcMajorAxis & mblnCalcRadiusRatio;
		}

		private void InternObjCalcEllipseStart()
		{
			mvarBasePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarCenter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMiddlePoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarStartParameter = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarEndParameter = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad360());
			mvarStartParameterDegree = null;
			mvarEndParameterDegree = null;
			mblnIsClosed = true;
			mblnIsPeriodic = true;
			mblnIsPlanar = true;
			mvarArea = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarLength = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarTotalAngle = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad360());
			mvarTotalAngleDegree = null;
			mvarNormal = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecNormal, hwpDxf_Vars.padblNormal));
			mvarMajorAxis = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMajorNorm = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMajorRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
			mvarRadiusRatio = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueOne), hwpDxf_Vars.pdblValueOne));
			mvarMinorAxis = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMinorNorm = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, hwpDxf_Vars.padecPointNull, hwpDxf_Vars.padblPointNull));
			mvarMinorRadius = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pdecValueNull), hwpDxf_Vars.pdblValueNull));
		}

		private void InternObjCalcEllipseAll()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
				InternSetMajorNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(mvarMajorAxis))));
				InternSetMajorRadius(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecLength(RuntimeHelpers.GetObjectValue(mvarMajorAxis))));
				InternSetMinorRadius(Operators.MultiplyObject(mvarMajorRadius, mvarRadiusRatio));
				InternSetMinorNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecProd(RuntimeHelpers.GetObjectValue(mvarNormal), RuntimeHelpers.GetObjectValue(mvarMajorNorm))));
				InternSetMinorAxis(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarMinorNorm), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseArea(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseCircum(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseCenter()
		{
			if (InternAllData())
			{
				InternSetBasePoint(RuntimeHelpers.GetObjectValue(mvarCenter));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseMajorAxis()
		{
			if (InternAllData())
			{
				InternSetMajorNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecNorm(RuntimeHelpers.GetObjectValue(mvarMajorAxis))));
				InternSetMajorRadius(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecLength(RuntimeHelpers.GetObjectValue(mvarMajorAxis))));
				InternSetRadiusRatio(Operators.DivideObject(mvarMajorRadius, mvarMinorRadius));
				InternSetMinorNorm(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecProd(RuntimeHelpers.GetObjectValue(mvarNormal), RuntimeHelpers.GetObjectValue(mvarMajorNorm))));
				InternSetMinorAxis(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarMinorNorm), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseArea(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseCircum(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseRadiusRatio()
		{
			if (InternAllData())
			{
				InternSetMinorRadius(Operators.MultiplyObject(mvarMajorRadius, mvarRadiusRatio));
				InternSetMinorAxis(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarMinorNorm), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseArea(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseCircum(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseNormal()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcEllipseBasePoint()
		{
			if (InternAllData())
			{
				InternSetCenter(RuntimeHelpers.GetObjectValue(mvarBasePoint));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseStartParameter()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseEndParameter()
		{
			if (InternAllData())
			{
				if (Operators.ConditionalCompareObjectGreaterEqual(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetTotalAngle(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarEndParameter, mvarStartParameter)
					}, null, null, null)));
				}
				else
				{
					InternSetTotalAngle(Operators.SubtractObject(hwpDxf_Vars.pobjUtilMath.AngRad360(), NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.SubtractObject(mvarStartParameter, mvarEndParameter)
					}, null, null, null)));
				}
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseMajorRadius()
		{
			if (InternAllData())
			{
				InternSetMajorAxis(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarMajorNorm), RuntimeHelpers.GetObjectValue(mvarMajorRadius))));
				InternSetRadiusRatio(Operators.DivideObject(mvarMajorRadius, mvarMinorRadius));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseArea(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseCircum(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseMinorRadius()
		{
			if (InternAllData())
			{
				InternSetMinorAxis(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecScalar(RuntimeHelpers.GetObjectValue(mvarMinorNorm), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetRadiusRatio(Operators.DivideObject(mvarMajorRadius, mvarMinorRadius));
				InternSetStartPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarStartParameter))));
				InternSetEndPoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(RuntimeHelpers.GetObjectValue(mvarEndParameter))));
				if (Operators.ConditionalCompareObjectGreater(mvarEndParameter, mvarStartParameter, TextCompare: false))
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarEndParameter, mvarStartParameter))));
				}
				else
				{
					InternSetMiddlePoint(RuntimeHelpers.GetObjectValue(InternObjCalcEllipsePointAtParam(Operators.SubtractObject(mvarStartParameter, mvarEndParameter))));
				}
				InternSetArea(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseArea(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternSetLength(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.EllipseCircum(RuntimeHelpers.GetObjectValue(mvarMajorRadius), RuntimeHelpers.GetObjectValue(mvarMinorRadius))));
				InternObjCalcEllipseMinMaxCoords();
			}
		}

		private void InternObjCalcEllipseMinMaxCoords()
		{
			if (InternAllData())
			{
				object dvarCosX = Operators.DivideObject(NewLateBinding.LateIndexGet(mvarMajorAxis, new object[1]
				{
				0
				}, null), mvarMajorRadius);
				object dvarAngleX = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngArcusCosinus(RuntimeHelpers.GetObjectValue(dvarCosX)));
				object dvarPointQuad1 = RuntimeHelpers.GetObjectValue(InternObjCalcEllipseAsArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad0())));
				object dvarPointQuad2 = RuntimeHelpers.GetObjectValue(InternObjCalcEllipseAsArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad90())));
				object dvarPointQuad3 = RuntimeHelpers.GetObjectValue(InternObjCalcEllipseAsArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad180())));
				object dvarPointQuad4 = RuntimeHelpers.GetObjectValue(InternObjCalcEllipseAsArcPointAtParam(RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad270())));
				object dvarMaxCoordX = (dvarPointQuad1 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad1, new object[1]
				{
				0
				}, null)) : ((!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null)));
				object dvarMaxCoordY = (dvarPointQuad2 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad2, new object[1]
				{
				1
				}, null)) : ((!Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null)));
				object dvarMinCoordX = (dvarPointQuad3 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad3, new object[1]
				{
				0
				}, null)) : ((!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				0
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				0
				}, null)));
				object dvarMinCoordY = (dvarPointQuad4 != null) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPointQuad4, new object[1]
				{
				1
				}, null)) : ((!Operators.ConditionalCompareObjectLessEqual(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null), NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null), TextCompare: false)) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarEndPoint, new object[1]
				{
				1
				}, null)) : RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(mvarStartPoint, new object[1]
				{
				1
				}, null)));
				CurveMinMaxCoordsEvent?.Invoke(new object[4]
				{
				dvarMaxCoordX,
				dvarMaxCoordY,
				dvarMinCoordX,
				dvarMinCoordY
				});
			}
		}

		private object InternObjCalcEllipsePointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					object dvarStartParameter = RuntimeHelpers.GetObjectValue(mvarStartParameter);
					object dvarEndParameter = RuntimeHelpers.GetObjectValue(mvarEndParameter);
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(vvarParameter, dvarStartParameter, TextCompare: false), Operators.CompareObjectLessEqual(vvarParameter, dvarEndParameter, TextCompare: false))))
					{
						object dvarCos = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
						object dvarSin = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
						object dvarMajor = Operators.MultiplyObject(mvarMajorRadius, dvarCos);
						object dvarMinor = Operators.MultiplyObject(mvarMinorRadius, dvarSin);
						object dvarCosX = Operators.DivideObject(NewLateBinding.LateIndexGet(mvarMajorAxis, new object[1]
						{
						0
						}, null), mvarMajorRadius);
						object dvarAngleX = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngArcusCosinus(RuntimeHelpers.GetObjectValue(dvarCosX)));
						object dvarCoordX = Operators.SubtractObject(Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(dvarAngleX)), dvarMajor), Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(dvarAngleX)), dvarMinor));
						object dvarCoordY = Operators.AddObject(Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(dvarAngleX)), dvarMajor), Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(dvarAngleX)), dvarMinor));
						object dvarVector = new object[3]
						{
						dvarCoordX,
						dvarCoordY,
						Interaction.IIf(Expression: false, 0m, 0.0)
						};
						dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarCenter), RuntimeHelpers.GetObjectValue(dvarVector)));
					}
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private object InternObjCalcEllipseAsArcPointAtParam(object vvarParameter)
		{
			object dvarPoint = null;
			if (InternAllData())
			{
				object objectValue = RuntimeHelpers.GetObjectValue(vvarParameter);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					object dvarCos = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngCosinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
					object dvarSin = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngSinus(RuntimeHelpers.GetObjectValue(vvarParameter)));
					object dvarMajor = Operators.MultiplyObject(mvarMajorRadius, dvarCos);
					object dvarMinor = Operators.MultiplyObject(mvarMajorRadius, dvarSin);
					object dvarVector = new object[3]
					{
					dvarMajor,
					dvarMinor,
					Interaction.IIf(Expression: false, 0m, 0.0)
					};
					dvarPoint = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.VecAddTwo(RuntimeHelpers.GetObjectValue(mvarCenter), RuntimeHelpers.GetObjectValue(dvarVector)));
				}
			}
			return RuntimeHelpers.GetObjectValue(dvarPoint);
		}

		private bool InternObjCalcSplineAllData()
		{
			bool InternObjCalcSplineAllData = default(bool);
			return InternObjCalcSplineAllData;
		}

		private void InternObjCalcSplineStart()
		{
		}

		private void InternObjCalcSplineAll()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcSplineNormal()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcSplineIsClosed()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcSplineIsPeriodic()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcSplineIsPlanar()
		{
			if (!InternAllData())
			{
			}
		}

		private void InternObjCalcSplineMinMaxCoords()
		{
			if (!InternAllData())
			{
			}
		}

		private object InternObjCaclSplinePointAtParam(object vvarParameter)
		{
			if (InternAllData())
			{
			}
			object InternObjCaclSplinePointAtParam = default(object);
			return InternObjCaclSplinePointAtParam;
		}
	}
}
