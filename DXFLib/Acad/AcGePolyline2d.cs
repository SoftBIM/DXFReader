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
	public class AcGePolyline2d
	{
		private const string cstrClassName = "AcGePolyline2d";

		private bool mblnOpened;

		private int mlngIndex;

		private int mlngBulged;

		private bool mblnClosed;

		private Dictionary<object, object> mobjDictVertices;

		internal bool FriendLetClosed
		{
			set
			{
				mblnClosed = value;
			}
		}

		public int NumberOfVertices => mobjDictVertices.Count;

		public bool Bulged => mlngBulged > 0;

		public bool Closed => mblnClosed;

		public AcGePolyline2d()
		{
			mblnOpened = true;
			mlngBulged = hwpDxf_Vars.plngBulged;
			mblnClosed = hwpDxf_Vars.pblnClosed;
			mobjDictVertices = new Dictionary<object, object>();
			mlngIndex = -1;
		}

		~AcGePolyline2d()
		{
			FriendQuit();
			base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				mobjDictVertices.Clear();
				mobjDictVertices = null;
				mblnOpened = false;
			}
		}

		internal void FriendAddVertex(object vvarCoordX, object vvarCoordY, object vvarBulge)
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
			double ddblBulge2 = default(double);
			rvarValueDbl = ddblBulge2;
			object objectValue3 = RuntimeHelpers.GetObjectValue(vvarBulge);
			nrstrErrMsg = "";
			object ddecBulge = default(object);
			bool num3 = hwpDxf_Functions.BkDXF_SetValueReal(ref ddecBulge, ref rvarValueDbl, objectValue3, ref nrstrErrMsg);
			ddblBulge2 = Conversions.ToDouble(rvarValueDbl);
			checked
			{
				if (num3)
				{
					bool flag = false;
					if (ddblBulge2 != hwpDxf_Vars.pdblBulge)
					{
						mlngBulged++;
					}
					mlngIndex++;
					AcGeVertex2d dobjAcGeVertex2d2 = new AcGeVertex2d();
					AcGeVertex2d acGeVertex2d = dobjAcGeVertex2d2;
					acGeVertex2d.FriendLetCoordX = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordX), ddblCoordX2));
					acGeVertex2d.FriendLetCoordY = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecCoordY), ddblCoordY2));
					acGeVertex2d.FriendLetBulge = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(ddecBulge), ddblBulge2));
					acGeVertex2d = null;
					mobjDictVertices.Add("K" + Conversions.ToString(mlngIndex), dobjAcGeVertex2d2);
					dobjAcGeVertex2d2 = null;
				}
			}
		}

		public AcGeVertex2d GetVertex(int vlngIndex)
		{
			return (AcGeVertex2d)mobjDictVertices["K" + Conversions.ToString(vlngIndex)];
		}
	}
}
