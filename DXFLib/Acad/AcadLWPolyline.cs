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
	public class AcadLWPolyline : AcadCurve
	{
		private const string cstrClassName = "AcadLWPolyline";

		private const int clngClosed = 1;

		private const int clngLinetypeGeneration = 128;

		private bool mblnOpened;

		private int mlngBulged;

		private bool mblnHasConstantWidth;

		private object mdecConstantWidth;

		private double mdblConstantWidth;

		private object mdecElevation;

		private double mdblElevation;

		private bool mblnLinetypeGeneration;

		private object[] madecNormal;

		private double[] madblNormal;

		private object mdecThickness;

		private double mdblThickness;

		private object mdecMinMaxCenterX;

		private double mdblMinMaxCenterX;

		private object mdecMinMaxCenterY;

		private double mdblMinMaxCenterY;

		private object mvarMaxCoordX;

		private double mvarMaxCoordY;

		private object mvarMinCoordX;

		private double mvarMinCoordY;

		private int mlngFlags70;

		private bool mblnClockwise;

		private bool mblnFriendLetFlags;

		private bool mblnFriendCalcSizeStop;

		private Dictionary<object, object> mobjDictVertices;

		internal int FriendLetFlags70
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags70 = value;
				Closed = ((1 & mlngFlags70) == 1);
				LinetypeGeneration = ((0x80 & mlngFlags70) == 128);
				mblnFriendLetFlags = false;
			}
		}

		internal bool FriendCalcSizeStop
		{
			set
			{
				mblnFriendCalcSizeStop = value;
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
				base.FriendLetIsClosed = value;
				InternCalcFlags70();
				InternCalcSize();
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
					Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
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
					Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
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
				if (!num)
				{
					Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
					return;
				}
				object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(mobjDictVertices.Keys));
				object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
				mobjDictVertices.Clear();
				int num2 = Information.LBound((Array)dvarKeys);
				int num3 = Information.UBound((Array)dvarKeys);
				for (int dlngIdx = num2; dlngIdx <= num3; dlngIdx = checked(dlngIdx + 1))
				{
					string dstrKey = Conversions.ToString(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
					{
					dlngIdx
					}, null));
					object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null));
					bool flag = false;
					NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
					{
					3,
					mdblConstantWidth
					}, null);
					NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
					{
					4,
					mdblConstantWidth
					}, null);
					mobjDictVertices.Add(dstrKey, RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
				}
				mblnHasConstantWidth = true;
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
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), 0, 1, ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
					return;
				}
				if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
				{
					Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
					return;
				}
				object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
				NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
				{
				0,
				NewLateBinding.LateIndexGet(value, new object[1]
				{
					0
				}, null)
				}, null);
				NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
				{
				1,
				NewLateBinding.LateIndexGet(value, new object[1]
				{
					1
				}, null)
				}, null);
				InternReplaceDictionaryEntry(vlngIndex, RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
				InternCalcSize();
			}
		}

		public object Coordinates
		{
			get
			{
				checked
				{
					if (mobjDictVertices.Count > 0)
					{
						bool flag = false;
						double[] dadblCoordinate = new double[mobjDictVertices.Count * 2 - 1 + 1];
						object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
						int dlngIndex = 0;
						int num = Information.LBound((Array)dvarItems);
						int num2 = Information.UBound((Array)dvarItems);
						for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
						{
							object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null));
							bool flag2 = false;
							dadblCoordinate[dlngIndex * 2] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
							{
							0
							}, null));
							dadblCoordinate[dlngIndex * 2 + 1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
							{
							1
							}, null));
							dlngIndex++;
						}
						object[] dadecCoordinate = default(object[]);
						return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecCoordinate, dadblCoordinate));
					}
					object Coordinates = default(object);
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
						dlngCount2 = (int)Math.Round(Conversion.Fix((double)dlngCount2 / 2.0) * 2.0);
						dlngUBound2 = dlngCount2 - 1 + dlngLBound;
					}
					string dstrErrMsg = default(string);
					if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(value), dlngLBound, dlngUBound2, ref dstrErrMsg))
					{
						Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
						return;
					}
					InternClearVertices();
					int num = dlngLBound;
					int num2 = dlngUBound2;
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx += 2)
					{
						object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(InternCreate2DLWVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx
						}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(value, new object[1]
						{
						dlngIdx + 1
						}, null))));
						InternAddVertex(RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
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
							object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
							{
							dlngIdx
							}, null));
							bool flag2 = false;
							dadblBulges[dlngIndex] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
							{
							2
							}, null));
							dlngIndex++;
						}
						object[] dadecBulges = default(object[]);
						return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecBulges, dadblBulges));
					}
					object Bulges = default(object);
					return Bulges;
				}
			}
		}

		public object MaxCoordX => RuntimeHelpers.GetObjectValue(mvarMaxCoordX);

		public object MaxCoordY => mvarMaxCoordY;

		public object MinCoordX => RuntimeHelpers.GetObjectValue(mvarMinCoordX);

		public object MinCoordY => mvarMinCoordY;

		public object MinMaxCenterX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterX), mdblMinMaxCenterX));

		public object MinMaxCenterY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecMinMaxCenterY), mdblMinMaxCenterY));

		public int NumVerts => mobjDictVertices.Count;

		public bool Clockwise => mblnClockwise;

		public bool Bulged => mlngBulged > 0;

		public bool HasConstantWidth => mblnHasConstantWidth;

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

		public object Vertices
		{
			get
			{
				return mobjDictVertices;
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				object[] dadec2DLWVertex = new object[5];
				double[] dadbl2DLWVertex = new double[5];
				object[] dadecPoint = new object[3];
				double[] dadblPoint = new double[3];
				bool dblnError = false;
				Dictionary<object, object> dobjDictVertices3 = (Dictionary<object, object>)value;
				checked
				{
					Dictionary<object, object> dobjDictVertices6 = default(Dictionary<object, object>);
					if (dobjDictVertices3.Count < 2)
					{
						dblnError = true;
					}
					else
					{
						int dlngBulged = default(int);
						try
						{
							object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjDictVertices3.Values));
							dobjDictVertices6 = new Dictionary<object, object>();
							int dlngCoordinates = 0;
							dlngBulged = 0;
							int num = Information.LBound((Array)dvarItems);
							int num2 = Information.UBound((Array)dvarItems);
							for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
							{
								object dvar2DLWVertex4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
								{
								dlngIdx
								}, null));
								bool flag = false;
								dadbl2DLWVertex[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								0
								}, null));
								dadbl2DLWVertex[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								1
								}, null));
								dadbl2DLWVertex[2] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								2
								}, null));
								dadbl2DLWVertex[3] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								3
								}, null));
								dadbl2DLWVertex[4] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								4
								}, null));
								dvar2DLWVertex4 = Support.CopyArray(dadbl2DLWVertex);
								dobjDictVertices6.Add("K" + Conversions.ToString(dlngCoordinates), RuntimeHelpers.GetObjectValue(dvar2DLWVertex4));
								dlngCoordinates++;
								if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
								{
								2
								}, null), 0, TextCompare: false))
								{
									dlngBulged++;
								}
							}
						}
						catch (Exception ex2)
						{
							ProjectData.SetProjectError(ex2);
							Exception ex = ex2;
							dblnError = true;
							ProjectData.ClearProjectError();
						}
						if (!dblnError)
						{
							InternClearVertices();
							mobjDictVertices = dobjDictVertices6;
							mlngBulged = dlngBulged;
							object dvar2DLWVertex4 = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(0)]);
							bool flag2 = false;
							dadblPoint[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
							{
							0
							}, null));
							dadblPoint[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
							{
							1
							}, null));
							dadblPoint[2] = 0.0;
							base.FriendLetStartPoint = Support.CopyArray(dadblPoint);
							dvar2DLWVertex4 = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(mobjDictVertices.Count - 1)]);
							bool flag3 = false;
							dadblPoint[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
							{
							0
							}, null));
							dadblPoint[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex4, new object[1]
							{
							1
							}, null));
							dadblPoint[2] = 0.0;
							base.FriendLetEndPoint = Support.CopyArray(dadblPoint);
							InternCalcSize();
							dobjDictVertices6 = null;
							dobjDictVertices3 = null;
						}
					}
					dobjDictVertices6 = null;
					dobjDictVertices3 = null;
					if (dblnError)
					{
						Information.Err().Raise(50000, "AcadLWPolyline", "Kontrollpunkte konnten nicht übertragen werden.");
					}
				}
			}
		}

		public object Area => RuntimeHelpers.GetObjectValue(base.FriendGetArea);

		public object Length => RuntimeHelpers.GetObjectValue(base.FriendGetLength);

		public AcadLWPolyline()
		{
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetCurveName = Enums.AcCurveName.acCurvePolylineLight;
			base.FriendLetNodeImageEnabledID = 177;
			base.FriendLetNodeImageDisabledID = 178;
			base.FriendLetNodeName = "LWPolylinie";
			base.FriendLetNodeText = "LWPolylinie";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
			mdblElevation = hwpDxf_Vars.pdblElevation;
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mdblThickness = hwpDxf_Vars.pdblThickness;
			mblnHasConstantWidth = hwpDxf_Vars.pblnHasConstantWidth;
			mlngBulged = hwpDxf_Vars.plngBulged;
			mblnLinetypeGeneration = hwpDxf_Vars.pblnLinetypeGeneration;
			mblnClockwise = true;
			mblnFriendLetFlags = false;
			InternCalcFlags70();
			mblnFriendCalcSizeStop = false;
			mobjDictVertices = new Dictionary<object, object>();
			InternClearVertices();
			base.FriendLetDXFName = "LWPOLYLINE";
			base.FriendLetObjectName = "AcDbPolyline";
			base.FriendLetEntityType = Enums.AcEntityName.acPolylineLight;
		}

		~AcadLWPolyline()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjDictVertices = null;
				mblnOpened = false;
			}
		}

		internal void FriendCalcSize()
		{
			mblnFriendCalcSizeStop = false;
			InternCalcSize();
		}

		public void Explode()
		{
		}

		public void Offset(object vvarDistance)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void AddVertex(int vlngIndex, object vvarVertex)
		{
			string dstrErrMsg = default(string);
			if (!hwpDxf_Functions.BkDXF_CheckVariantForArrayReal(RuntimeHelpers.GetObjectValue(vvarVertex), 0, 1, ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
				return;
			}
			if ((vlngIndex < 0) | (vlngIndex > mobjDictVertices.Count))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
				return;
			}
			object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(InternCreate2DLWVertex(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
			{
			0
			}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarVertex, new object[1]
			{
			1
			}, null))));
			InternAddVertex(RuntimeHelpers.GetObjectValue(dvar2DLWVertex), vlngIndex);
			InternCalcSize();
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetBulge(int vlngIndex, object vvarBulge)
		{
			string dstrErrMsg = default(string);
			if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarBulge), ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
				return;
			}
			checked
			{
				if ((vlngIndex < 0) | (vlngIndex > mobjDictVertices.Count - 1))
				{
					Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
					return;
				}
				object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
				if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
				{
				2
				}, null), vvarBulge, TextCompare: false))
				{
					bool flag = false;
					if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
					{
					2
					}, null), 0.0, TextCompare: false))
					{
						mlngBulged--;
					}
					NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
					{
					2,
					vvarBulge
					}, null);
					InternReplaceDictionaryEntry(vlngIndex, RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
					bool flag2 = false;
					if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
					{
					2
					}, null), 0.0, TextCompare: false))
					{
						mlngBulged++;
					}
					InternCalcSize();
				}
			}
		}

		public object GetCoordinate(int vlngIndex)
		{
			return RuntimeHelpers.GetObjectValue(InternGetCoordinate(vlngIndex));
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public object GetBulge(int vlngIndex)
		{
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
				object GetBulge = default(object);
				return GetBulge;
			}
			object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
			return RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
			{
			2
			}, null));
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void SetWidth(int vlngIndex, object vvarStartWidth, object vvarEndWidth)
		{
			string dstrErrMsg = default(string);
			if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarStartWidth), ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
				return;
			}
			if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(vvarEndWidth), ref dstrErrMsg))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", dstrErrMsg);
				return;
			}
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
				return;
			}
			object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
			NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
			{
			3,
			vvarStartWidth
			}, null);
			NewLateBinding.LateIndexSet(dvar2DLWVertex, new object[2]
			{
			4,
			vvarEndWidth
			}, null);
			InternReplaceDictionaryEntry(vlngIndex, RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
			bool flag = false;
			if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(vvarStartWidth, mdblConstantWidth, TextCompare: false), Operators.CompareObjectNotEqual(vvarEndWidth, mdblConstantWidth, TextCompare: false))))
			{
				mblnHasConstantWidth = false;
				mdblConstantWidth = hwpDxf_Vars.pdblConstantWidth;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public void GetWidth(int vlngIndex, ref object rvarStartWidth, ref object rvarEndWidth)
		{
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
				return;
			}
			object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
			rvarStartWidth = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
			{
			3
			}, null));
			rvarEndWidth = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
			{
			4
			}, null));
		}

		private void InternCalcFlags70()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags70 = 0;
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(Closed, 1, 0)));
				mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(LinetypeGeneration, 128, 0)));
			}
		}

		private object InternCreate2DLWVertex(object vvarCoordX, object vvarCoordY)
		{
			object[] dadec2DLWVertex = new object[5];
			double[] dadbl2DLWVertex = new double[5];
			bool flag = false;
			dadbl2DLWVertex[0] = Conversions.ToDouble(vvarCoordX);
			dadbl2DLWVertex[1] = Conversions.ToDouble(vvarCoordY);
			dadbl2DLWVertex[2] = hwpDxf_Vars.pdblBulge;
			dadbl2DLWVertex[3] = mdblConstantWidth;
			dadbl2DLWVertex[4] = mdblConstantWidth;
			return Support.CopyArray(dadbl2DLWVertex);
		}

		private void InternClearVertices()
		{
			object[] dadecPoint = new object[3];
			double[] dadblPoint = new double[3];
			mobjDictVertices.Clear();
			mlngBulged = 0;
			bool flag = false;
			mdblMinMaxCenterX = 0.0;
			mdblMinMaxCenterY = 0.0;
			mvarMaxCoordX = 0.0;
			mvarMaxCoordY = 0.0;
			mvarMinCoordX = 0.0;
			mvarMinCoordY = 0.0;
			dadblPoint[0] = 0.0;
			dadblPoint[1] = 0.0;
			dadblPoint[2] = 0.0;
			base.FriendLetStartPoint = Support.CopyArray(dadblPoint);
			base.FriendLetEndPoint = Support.CopyArray(dadblPoint);
			base.FriendLetLength = 0.0;
			base.FriendLetArea = 0.0;
		}

		private void InternAddVertex(object vvar2DLWVertex, int nvlngIndex = -1)
		{
			object[] dadecPoint = new object[3];
			double[] dadblPoint = new double[3];
			if (nvlngIndex == -1)
			{
				nvlngIndex = mobjDictVertices.Count;
			}
			checked
			{
				bool dblnAdded = default(bool);
				if (mobjDictVertices.Count == nvlngIndex)
				{
					mobjDictVertices.Add("K" + Conversions.ToString(nvlngIndex), RuntimeHelpers.GetObjectValue(vvar2DLWVertex));
					dblnAdded = true;
				}
				else if (mobjDictVertices.Count > 0)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					mobjDictVertices.Clear();
					int dlngIndex = 0;
					int num = Information.LBound((Array)dvarItems);
					int num2 = Information.UBound((Array)dvarItems);
					for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
					{
						if (dlngIndex == nvlngIndex)
						{
							mobjDictVertices.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(vvar2DLWVertex));
							dblnAdded = true;
							dlngIndex++;
						}
						object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx
						}, null));
						mobjDictVertices.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(dvar2DLWVertex));
						dlngIndex++;
					}
				}
				if (dblnAdded)
				{
					bool flag = false;
					if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateIndexGet(vvar2DLWVertex, new object[1]
					{
					2
					}, null), 0.0, TextCompare: false))
					{
						mlngBulged++;
					}
					dadblPoint[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DLWVertex, new object[1]
					{
					0
					}, null));
					dadblPoint[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(vvar2DLWVertex, new object[1]
					{
					1
					}, null));
					dadblPoint[2] = 0.0;
					if (nvlngIndex == 0)
					{
						base.FriendLetStartPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecPoint, dadblPoint));
					}
					if (nvlngIndex == mobjDictVertices.Count - 1)
					{
						base.FriendLetEndPoint = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, dadecPoint, dadblPoint));
					}
				}
			}
		}

		private void InternCalcSize()
		{
			if (mblnFriendCalcSizeStop)
			{
				return;
			}
			object dvarLen = 0m;
			object dvarArea = 0m;
			bool dblnClosed = Closed;
			mblnClockwise = true;
			checked
			{
				if (mobjDictVertices.Count > 1)
				{
					object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
					int dlngLBound = Information.LBound((Array)dvarItems);
					int dlngUBound = Information.UBound((Array)dvarItems);
					object dvarStart2DLWVertex2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngLBound
					}, null));
					object dvarFirst2DLWVertex2 = RuntimeHelpers.GetObjectValue(dvarStart2DLWVertex2);
					int num = dlngLBound + 1;
					int num2 = dlngUBound;
					object dvarSegLen = default(object);
					object dvarSegArea = default(object);
					object dvarLenUnbulged2 = default(object);
					object dvarAreaUnbulged2 = default(object);
					for (int dlngIdx2 = num; dlngIdx2 <= num2; dlngIdx2++)
					{
						object dvarSecond2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx2
						}, null));
						InternCalcSegUnbulged(dlngIdx2 == dlngLBound + 1, RuntimeHelpers.GetObjectValue(dvarFirst2DLWVertex2), RuntimeHelpers.GetObjectValue(dvarSecond2DLWVertex), ref dvarSegLen, ref dvarSegArea, vblnCalcLen: true, vblnIgnoreBulg: false);
						dvarLenUnbulged2 = Operators.AddObject(dvarLenUnbulged2, dvarSegLen);
						dvarAreaUnbulged2 = Operators.AddObject(dvarAreaUnbulged2, dvarSegArea);
						dvarFirst2DLWVertex2 = RuntimeHelpers.GetObjectValue(dvarSecond2DLWVertex);
					}
					InternCalcSegUnbulged(vblnFirst: false, RuntimeHelpers.GetObjectValue(dvarFirst2DLWVertex2), RuntimeHelpers.GetObjectValue(dvarStart2DLWVertex2), ref dvarSegLen, ref dvarSegArea, dblnClosed, !dblnClosed);
					dvarLenUnbulged2 = Operators.AddObject(dvarLenUnbulged2, dvarSegLen);
					dvarAreaUnbulged2 = Operators.AddObject(dvarAreaUnbulged2, dvarSegArea);
					object left = dvarAreaUnbulged2;
					object[] array;
					bool[] array2;
					object right = NewLateBinding.LateGet(null, typeof(Math), "Abs", array = new object[1]
					{
					dvarAreaUnbulged2
					}, null, null, array2 = new bool[1]
					{
					true
					});
					if (array2[0])
					{
						dvarAreaUnbulged2 = RuntimeHelpers.GetObjectValue(array[0]);
					}
					mblnClockwise = Operators.ConditionalCompareObjectNotEqual(left, right, TextCompare: false);
					dvarStart2DLWVertex2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngLBound
					}, null));
					dvarFirst2DLWVertex2 = RuntimeHelpers.GetObjectValue(dvarStart2DLWVertex2);
					int num3 = dlngLBound + 1;
					int num4 = dlngUBound;
					object dvarLenBulged2 = default(object);
					object dvarAreaBulged2 = default(object);
					for (int dlngIdx2 = num3; dlngIdx2 <= num4; dlngIdx2++)
					{
						object dvarSecond2DLWVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
						{
						dlngIdx2
						}, null));
						InternCalcSegBulged(mblnClockwise, RuntimeHelpers.GetObjectValue(dvarFirst2DLWVertex2), RuntimeHelpers.GetObjectValue(dvarSecond2DLWVertex), ref dvarSegLen, ref dvarSegArea, vblnCalcLen: true, vblnIgnoreBulg: false);
						dvarLenBulged2 = Operators.AddObject(dvarLenBulged2, dvarSegLen);
						dvarAreaBulged2 = Operators.AddObject(dvarAreaBulged2, dvarSegArea);
						dvarFirst2DLWVertex2 = RuntimeHelpers.GetObjectValue(dvarSecond2DLWVertex);
					}
					InternCalcSegBulged(mblnClockwise, RuntimeHelpers.GetObjectValue(dvarFirst2DLWVertex2), RuntimeHelpers.GetObjectValue(dvarStart2DLWVertex2), ref dvarSegLen, ref dvarSegArea, dblnClosed, !dblnClosed);
					dvarLenBulged2 = Operators.AddObject(dvarLenBulged2, dvarSegLen);
					dvarAreaBulged2 = Operators.AddObject(dvarAreaBulged2, dvarSegArea);
					dvarLen = Operators.AddObject(dvarLenUnbulged2, dvarLenBulged2);
					dvarArea = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
					{
					Operators.AddObject(dvarAreaUnbulged2, dvarAreaBulged2)
					}, null, null, null));
				}
				base.FriendLetLength = RuntimeHelpers.GetObjectValue(dvarLen);
				base.FriendLetArea = RuntimeHelpers.GetObjectValue(dvarArea);
				FriendSetMinMaxCoords(new object[4]
				{
				mvarMaxCoordX,
				mvarMaxCoordY,
				mvarMinCoordX,
				mvarMinCoordY
				});
				bool flag = false;
				mdblMinMaxCenterX = Conversions.ToDouble(Operators.AddObject(mvarMinCoordX, Operators.DivideObject(Operators.SubtractObject(mvarMaxCoordX, mvarMinCoordX), 2.0)));
				mdblMinMaxCenterY = mvarMinCoordY + (mvarMaxCoordY - mvarMinCoordY) / 2.0;
			}
		}

		private void InternCalcSegUnbulged(bool vblnFirst, object vvarFirst2DLWVertex, object vvarSecond2DLWVertex, ref object rvarLen, ref object rvarArea, bool vblnCalcLen, bool vblnIgnoreBulg)
		{
			object dvarFac0 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
			rvarLen = RuntimeHelpers.GetObjectValue(dvarFac0);
			rvarArea = RuntimeHelpers.GetObjectValue(dvarFac0);
			object dvarCoordX1 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			0
			}, null));
			object dvarCoordY1 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			1
			}, null));
			object dvarCoordX2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarSecond2DLWVertex, new object[1]
			{
			0
			}, null));
			object dvarCoordY2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarSecond2DLWVertex, new object[1]
			{
			1
			}, null));
			object dvarBulge = (!vblnIgnoreBulg) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			2
			}, null)) : RuntimeHelpers.GetObjectValue(dvarFac0);
			bool dblnBulged = Operators.ConditionalCompareObjectNotEqual(dvarBulge, dvarFac0, TextCompare: false);
			if (vblnCalcLen && !dblnBulged)
			{
				object dvarVecCoordX = Operators.SubtractObject(dvarCoordX2, dvarCoordX1);
				object dvarVecCoordY = Operators.SubtractObject(dvarCoordY2, dvarCoordY1);
				rvarLen = Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
				Operators.AddObject(Operators.ExponentObject(dvarVecCoordX, dvarFac), Operators.ExponentObject(dvarVecCoordY, dvarFac))
				}, null, null, null)));
			}
			rvarArea = Operators.DivideObject(Operators.SubtractObject(Operators.MultiplyObject(dvarCoordX1, dvarCoordY2), Operators.MultiplyObject(dvarCoordY1, dvarCoordX2)), dvarFac);
			if (vblnFirst)
			{
				mvarMaxCoordX = RuntimeHelpers.GetObjectValue(dvarCoordX1);
				mvarMinCoordX = RuntimeHelpers.GetObjectValue(dvarCoordX1);
				mvarMaxCoordY = Conversions.ToDouble(dvarCoordY1);
				mvarMinCoordY = Conversions.ToDouble(dvarCoordY1);
				return;
			}
			if (Operators.ConditionalCompareObjectGreater(dvarCoordX1, mvarMaxCoordX, TextCompare: false))
			{
				mvarMaxCoordX = RuntimeHelpers.GetObjectValue(dvarCoordX1);
			}
			if (Operators.ConditionalCompareObjectLess(dvarCoordX1, mvarMinCoordX, TextCompare: false))
			{
				mvarMinCoordX = RuntimeHelpers.GetObjectValue(dvarCoordX1);
			}
			if (Operators.ConditionalCompareObjectGreater(dvarCoordY1, mvarMaxCoordY, TextCompare: false))
			{
				mvarMaxCoordY = Conversions.ToDouble(dvarCoordY1);
			}
			if (Operators.ConditionalCompareObjectLess(dvarCoordY1, mvarMinCoordY, TextCompare: false))
			{
				mvarMinCoordY = Conversions.ToDouble(dvarCoordY1);
			}
		}

		private void InternCalcSegBulged(bool vblnClockwise, object vvarFirst2DLWVertex, object vvarSecond2DLWVertex, ref object rvarLen, ref object rvarArea, bool vblnCalcLen, bool vblnIgnoreBulg)
		{
			object dvarFac0 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0m, 0.0));
			object dvarFac = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 0.5m, 0.5));
			object dvarFac2 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, 1m, 1.0));
			object dvarFac3 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(2L), 2.0));
			object dvarFac4 = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, new decimal(4L), 4.0));
			object dvarFac1n = RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, -1m, -1.0));
			rvarLen = RuntimeHelpers.GetObjectValue(dvarFac0);
			rvarArea = RuntimeHelpers.GetObjectValue(dvarFac0);
			object dvarCoordX1 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			0
			}, null));
			object dvarCoordY1 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			1
			}, null));
			object dvarCoordX2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarSecond2DLWVertex, new object[1]
			{
			0
			}, null));
			object dvarCoordY2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarSecond2DLWVertex, new object[1]
			{
			1
			}, null));
			object dvarBulge = (!vblnIgnoreBulg) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarFirst2DLWVertex, new object[1]
			{
			2
			}, null)) : RuntimeHelpers.GetObjectValue(dvarFac0);
			if (!Operators.ConditionalCompareObjectNotEqual(dvarBulge, dvarFac0, TextCompare: false))
			{
				return;
			}
			object dvarCot = Operators.DivideObject(Operators.SubtractObject(Operators.DivideObject(dvarFac2, dvarBulge), dvarBulge), dvarFac3);
			object dvarCenCoordX = Operators.DivideObject(Operators.SubtractObject(Operators.AddObject(dvarCoordX1, dvarCoordX2), Operators.MultiplyObject(Operators.SubtractObject(dvarCoordY2, dvarCoordY1), dvarCot)), dvarFac3);
			object dvarCenCoordY = Operators.DivideObject(Operators.AddObject(Operators.AddObject(dvarCoordY1, dvarCoordY2), Operators.MultiplyObject(Operators.SubtractObject(dvarCoordX2, dvarCoordX1), dvarCot)), dvarFac3);
			object dvarVecCoordX2 = Operators.SubtractObject(dvarCoordX1, dvarCenCoordX);
			object dvarVecCoordY1 = Operators.SubtractObject(dvarCoordY1, dvarCenCoordY);
			object dvarVecCoordX4 = Operators.SubtractObject(dvarCoordX2, dvarCenCoordX);
			object dvarVecCoordY2 = Operators.SubtractObject(dvarCoordY2, dvarCenCoordY);
			object dvarRadius = Math.Sqrt(Conversions.ToDouble(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
			{
			Operators.AddObject(Operators.ExponentObject(dvarVecCoordX2, dvarFac3), Operators.ExponentObject(dvarVecCoordY1, dvarFac3))
			}, null, null, null)));
			object dvarScalar = Operators.DivideObject(dvarFac2, dvarRadius);
			dvarVecCoordX2 = Operators.MultiplyObject(dvarVecCoordX2, dvarScalar);
			dvarVecCoordX4 = Operators.MultiplyObject(dvarVecCoordX4, dvarScalar);
			object dvarAngleRad0 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad0());
			object dvarAngleRad4 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad90());
			object dvarAngleRad = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad180());
			object dvarAngleRad2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad270());
			object dvarAngleRad3 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngRad360());
			object dvarAngleRad90n = Operators.MultiplyObject(dvarAngleRad4, dvarFac1n);
			object dvarAngleRad180n = Operators.MultiplyObject(dvarAngleRad, dvarFac1n);
			object dvarAngleRad270n = Operators.MultiplyObject(dvarAngleRad2, dvarFac1n);
			object dvarBulgeAngleRad2 = Operators.MultiplyObject(dvarFac4, Math.Atan(Conversions.ToDouble(dvarBulge)));
			dvarBulgeAngleRad2 = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngSub(RuntimeHelpers.GetObjectValue(dvarBulgeAngleRad2), vblnReturn360: false));
			bool dblnInside = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(vblnClockwise, Operators.CompareObjectGreaterEqual(dvarBulgeAngleRad2, dvarFac0, TextCompare: false)), Operators.AndObject(!vblnClockwise, Operators.CompareObjectLess(dvarBulgeAngleRad2, dvarFac0, TextCompare: false))));
			bool dblnArcClockwise = (dblnInside && !vblnClockwise) || (!dblnInside && vblnClockwise);
			object dvarStartAngleRad = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngArcusCosinus(RuntimeHelpers.GetObjectValue(dvarVecCoordX2)));
			if (Operators.ConditionalCompareObjectLess(dvarVecCoordY1, dvarFac0, TextCompare: false))
			{
				dvarStartAngleRad = Operators.SubtractObject(dvarAngleRad3, dvarStartAngleRad);
			}
			object dvarEndAngleRad = RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngArcusCosinus(RuntimeHelpers.GetObjectValue(dvarVecCoordX4)));
			if (Operators.ConditionalCompareObjectLess(dvarVecCoordY2, dvarFac0, TextCompare: false))
			{
				dvarEndAngleRad = Operators.SubtractObject(dvarAngleRad3, dvarEndAngleRad);
			}
			rvarArea = Operators.MultiplyObject(Operators.DivideObject(Operators.ExponentObject(dvarRadius, dvarFac3), dvarFac3), Operators.SubtractObject(Operators.DivideObject(Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.Pi(), dvarBulgeAngleRad2), dvarAngleRad), Math.Sin(Conversions.ToDouble(dvarBulgeAngleRad2))));
			if (vblnCalcLen)
			{
				rvarLen = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(null, typeof(Math), "Abs", new object[1]
				{
				Operators.MultiplyObject(Operators.MultiplyObject(hwpDxf_Vars.pobjUtilMath.Pi(), dvarRadius), Operators.DivideObject(dvarBulgeAngleRad2, dvarAngleRad))
				}, null, null, null));
			}
			bool dblnQuad1;
			bool dblnQuad2;
			bool dblnQuad3;
			bool dblnQuad4;
			if (dblnArcClockwise)
			{
				if (Operators.ConditionalCompareObjectGreater(dvarEndAngleRad, dvarStartAngleRad, TextCompare: false))
				{
					dvarEndAngleRad = Operators.SubtractObject(dvarEndAngleRad, dvarAngleRad3);
				}
				dblnQuad1 = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad0, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad0, TextCompare: false)));
				dblnQuad2 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad4, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad4, TextCompare: false)), Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad270n, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad270n, TextCompare: false))));
				dblnQuad3 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad, TextCompare: false)), Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad180n, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad180n, TextCompare: false))));
				dblnQuad4 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad2, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad2, TextCompare: false)), Operators.AndObject(Operators.CompareObjectGreaterEqual(dvarStartAngleRad, dvarAngleRad90n, TextCompare: false), Operators.CompareObjectLessEqual(dvarEndAngleRad, dvarAngleRad90n, TextCompare: false))));
			}
			else
			{
				if (Operators.ConditionalCompareObjectGreater(dvarStartAngleRad, dvarEndAngleRad, TextCompare: false))
				{
					dvarStartAngleRad = Operators.SubtractObject(dvarStartAngleRad, dvarAngleRad3);
				}
				dblnQuad1 = Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad0, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad0, TextCompare: false)));
				dblnQuad2 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad4, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad4, TextCompare: false)), Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad270n, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad270n, TextCompare: false))));
				dblnQuad3 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad, TextCompare: false)), Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad180n, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad180n, TextCompare: false))));
				dblnQuad4 = Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad2, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad2, TextCompare: false)), Operators.AndObject(Operators.CompareObjectLessEqual(dvarStartAngleRad, dvarAngleRad90n, TextCompare: false), Operators.CompareObjectGreaterEqual(dvarEndAngleRad, dvarAngleRad90n, TextCompare: false))));
			}
			if (dblnQuad1)
			{
				object dvarQuadCoordX2 = Operators.AddObject(dvarCenCoordX, dvarRadius);
				if (Operators.ConditionalCompareObjectGreater(dvarQuadCoordX2, mvarMaxCoordX, TextCompare: false))
				{
					mvarMaxCoordX = RuntimeHelpers.GetObjectValue(dvarQuadCoordX2);
				}
			}
			if (dblnQuad2)
			{
				object dvarQuadCoordY2 = Operators.AddObject(dvarCenCoordY, dvarRadius);
				if (Operators.ConditionalCompareObjectGreater(dvarQuadCoordY2, mvarMaxCoordY, TextCompare: false))
				{
					mvarMaxCoordY = Conversions.ToDouble(dvarQuadCoordY2);
				}
			}
			if (dblnQuad3)
			{
				object dvarQuadCoordX2 = Operators.SubtractObject(dvarCenCoordX, dvarRadius);
				if (Operators.ConditionalCompareObjectLess(dvarQuadCoordX2, mvarMinCoordX, TextCompare: false))
				{
					mvarMinCoordX = RuntimeHelpers.GetObjectValue(dvarQuadCoordX2);
				}
			}
			if (dblnQuad4)
			{
				object dvarQuadCoordY2 = Operators.SubtractObject(dvarCenCoordY, dvarRadius);
				if (Operators.ConditionalCompareObjectLess(dvarQuadCoordY2, mvarMinCoordY, TextCompare: false))
				{
					mvarMinCoordY = Conversions.ToDouble(dvarQuadCoordY2);
				}
			}
		}

		private void InternReplaceDictionaryEntry(int vlngIndex, object vvarValue)
		{
			object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(mobjDictVertices.Keys));
			object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictVertices.Values));
			mobjDictVertices.Clear();
			int dlngIndex = 0;
			int num = Information.LBound((Array)dvarKeys);
			int num2 = Information.UBound((Array)dvarKeys);
			checked
			{
				for (int dlngIdx = num; dlngIdx <= num2; dlngIdx++)
				{
					string dstrKey = Conversions.ToString(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
					{
					dlngIdx
					}, null));
					object dvarValue = (Operators.CompareString(dstrKey, "K" + Conversions.ToString(vlngIndex), TextCompare: false) != 0) ? RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
					{
					dlngIdx
					}, null)) : RuntimeHelpers.GetObjectValue(vvarValue);
					mobjDictVertices.Add("K" + Conversions.ToString(dlngIndex), RuntimeHelpers.GetObjectValue(dvarValue));
					dlngIndex++;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		private object InternGetCoordinate(int vlngIndex)
		{
			object[] dadecCoordinate = new object[2];
			double[] dadblCoordinate = new double[2];
			if ((vlngIndex < 0) | (vlngIndex > checked(mobjDictVertices.Count - 1)))
			{
				Information.Err().Raise(50000, "AcadLWPolyline", "Ungültiger Index.");
				object InternGetCoordinate = default(object);
				return InternGetCoordinate;
			}
			object dvar2DLWVertex = RuntimeHelpers.GetObjectValue(mobjDictVertices["K" + Conversions.ToString(vlngIndex)]);
			bool flag = false;
			dadblCoordinate[0] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
			{
			0
			}, null));
			dadblCoordinate[1] = Conversions.ToDouble(NewLateBinding.LateIndexGet(dvar2DLWVertex, new object[1]
			{
			1
			}, null));
			return Support.CopyArray(dadblCoordinate);
		}
	}

}
