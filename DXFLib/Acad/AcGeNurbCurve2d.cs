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
	public class AcGeNurbCurve2d
	{
		private const string cstrClassName = "AcGeNurbCurve2d";

		private bool mblnOpened;

		private int mlngKnotIndex;

		private int mlngControlPointIndex;

		private int mlngDegree;

		private bool mblnIsRational;

		private bool mblnIsPeriodic;

		private Dictionary<object, object> mobjDictKnots;

		private Dictionary<object, object> mobjDictControlPoints;

		internal int FriendLetDegree
		{
			set
			{
				mlngDegree = value;
			}
		}

		internal bool FriendLetIsRational
		{
			set
			{
				mblnIsRational = value;
			}
		}

		internal bool FriendLetIsPeriodic
		{
			set
			{
				mblnIsPeriodic = value;
			}
		}

		public int NumberOfKnots => mobjDictKnots.Count;

		public int NumberOfControlPoints => mobjDictControlPoints.Count;

		public int Degree => mlngDegree;

		public bool IsRational => mblnIsRational;

		public bool IsPeriodic => mblnIsPeriodic;

		public AcGeNurbCurve2d()
		{
			mblnOpened = true;
			mlngDegree = hwpDxf_Vars.plngDegree;
			mblnIsRational = hwpDxf_Vars.pblnIsRational;
			mblnIsPeriodic = (hwpDxf_Vars.pblnIsPeriodic != 0.0);
			mobjDictKnots = new Dictionary<object, object>();
			mobjDictControlPoints = new Dictionary<object, object>();
			mlngKnotIndex = -1;
			mlngControlPointIndex = -1;
		}

		~AcGeNurbCurve2d()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictKnots.Clear();
				mobjDictControlPoints.Clear();
				mobjDictKnots = null;
				mobjDictControlPoints = null;
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

		internal void FriendAddControlPoint(object vvarCoordX, object vvarCoordY, object vvarWeight)
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
					double ddblWeight2 = default(double);
					rvarValueDbl = ddblWeight2;
					object objectValue3 = RuntimeHelpers.GetObjectValue(vvarWeight);
					nrstrErrMsg = "";
					object ddecWeight = default(object);
					bool num3 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecWeight, ref rvarValueDbl, objectValue3, ref nrstrErrMsg);
					ddblWeight2 = Conversions.ToDouble(rvarValueDbl);
					if (num3)
					{
						mlngControlPointIndex++;
						AcGeCtrlPoint2d dobjAcGeCtrlPoint2d2 = new AcGeCtrlPoint2d();
						AcGeCtrlPoint2d acGeCtrlPoint2d = dobjAcGeCtrlPoint2d2;
						acGeCtrlPoint2d.FriendLetCoordX = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordX), ddblCoordX2));
						acGeCtrlPoint2d.FriendLetCoordY = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordY), ddblCoordY2));
						acGeCtrlPoint2d.FriendLetWeight = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecWeight), ddblWeight2));
						acGeCtrlPoint2d = null;
						mobjDictControlPoints.Add("K" + Conversions.ToString(mlngControlPointIndex), dobjAcGeCtrlPoint2d2);
						dobjAcGeCtrlPoint2d2 = null;
					}
				}
			}
		}

		public object GetKnot(int vlngIndex)
		{
			return RuntimeHelpers.GetObjectValue(mobjDictKnots["K" + Conversions.ToString(vlngIndex)]);
		}

		public AcGeCtrlPoint2d GetControlPoint(int vlngIndex)
		{
			return (AcGeCtrlPoint2d)mobjDictControlPoints["K" + Conversions.ToString(vlngIndex)];
		}
	}
}
