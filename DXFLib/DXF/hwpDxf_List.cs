using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.DXF
{
	public class hwpDxf_List
	{
		//public static void BkDXFList_AddToDictLine(ref int rlngIdx, int vlngCode, object vvarValue, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	robjDictReadCodes.Add(rlngIdx, vlngCode);
		//	robjDictReadValues.Add(rlngIdx, RuntimeHelpers.GetObjectValue(vvarValue));
		//	checked
		//	{
		//		rlngIdx++;
		//	}
		//}

		//public static void BkDXFList_CodeDictionary(Dictionary<object, object> vobjDict, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	if (vobjDict != null && vobjDict.Count > 0)
		//	{
		//		object dvarKeys = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_KeyCollectionToArray(vobjDict.Keys));
		//		object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDict.Values));
		//		int num = Information.LBound((Array)dvarKeys);
		//		int num2 = Information.UBound((Array)dvarKeys);
		//		for (int dlngIndex = num; dlngIndex <= num2; dlngIndex = checked(dlngIndex + 1))
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, Conversions.ToInteger(NewLateBinding.LateIndexGet(dvarItems, new object[1]
		//			{
		//			dlngIndex
		//			}, null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarKeys, new object[1]
		//			{
		//			dlngIndex
		//			}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//	}
		//}

		//public static void BkDXFList_Brackets(string vstrBracketName, Dictionary<object, object> vobjDict, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	if (vobjDict != null && vobjDict.Count > 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 102, vstrBracketName, ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_CodeDictionary(vobjDict, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 102, "}", ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//}

		//public static void BkDXFList_Reactors(Dictionary<object, object> vobjDictReactors, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	BkDXFList_Brackets("{ACAD_REACTORS", vobjDictReactors, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}

		//public static void BkDXFList_XDictionary(Dictionary<object, object> vobjDictXDictionary, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	BkDXFList_Brackets("{ACAD_XDICTIONARY", vobjDictXDictionary, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}

		//public static void BkDXFList_Blkrefs(Dictionary<object, object> vobjDictBlkrefs, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	BkDXFList_Brackets("{BLKREFS", vobjDictBlkrefs, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}

		//public static void BkDXFList_PreviewIcon(Dictionary<object, object> vobjDictPreviewIcon, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	if (vobjDictPreviewIcon != null && vobjDictPreviewIcon.Count > 0)
		//	{
		//		object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(vobjDictPreviewIcon.Values));
		//		int num = Information.LBound((Array)dvarItems);
		//		int num2 = Information.UBound((Array)dvarItems);
		//		for (int dlngIndex = num; dlngIndex <= num2; dlngIndex = checked(dlngIndex + 1))
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 310, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
		//			{
		//			dlngIndex
		//			}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//	}
		//}

		//public static void BkDXFList_XData(object vvarXDataType, object vvarXDataValue, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	if (!((Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataType)) == (VariantType)8201) & (Information.VarType(RuntimeHelpers.GetObjectValue(vvarXDataValue)) == (VariantType)8201)))
		//	{
		//		return;
		//	}
		//	int num = Information.LBound((Array)vvarXDataType);
		//	int num2 = Information.UBound((Array)vvarXDataType);
		//	checked
		//	{
		//		for (int dlngIndex = num; dlngIndex <= num2; dlngIndex++)
		//		{
		//			short dintCode = Conversions.ToShort(NewLateBinding.LateIndexGet(vvarXDataType, new object[1]
		//			{
		//			dlngIndex
		//			}, null));
		//			object dvarValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(vvarXDataValue, new object[1]
		//			{
		//			dlngIndex
		//			}, null));
		//			short vintCode = dintCode;
		//			short nrintNextCode = 0;
		//			if (hwpDxf_XData.BkDXFXData_IsArrayCode(vintCode, ref nrintNextCode))
		//			{
		//				int num3 = Information.LBound((Array)dvarValue);
		//				int num4 = Information.UBound((Array)dvarValue);
		//				for (int dlngArray = num3; dlngArray <= num4; dlngArray++)
		//				{
		//					BkDXFList_AddToDictLine(ref rlngIdx, dintCode, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarValue, new object[1]
		//					{
		//					dlngArray
		//					}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//					dintCode = (short)unchecked(dintCode + 10);
		//				}
		//			}
		//			else
		//			{
		//				BkDXFList_AddToDictLine(ref rlngIdx, dintCode, RuntimeHelpers.GetObjectValue(dvarValue), ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//	}
		//}

		//public static void BkDXFList_AcadBlockEntities(string vstrAcadVer, AcadBlock vobjAcadBlock, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadObject dobjAcadObject2;
		//	try
		//	{
		//		enumerator = vobjAcadBlock.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadObject2 = (AcadObject)enumerator.Current;
		//			BkDXFList_AcadObject(dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AcadEntity(vstrAcadVer, (AcadEntity)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			switch (dobjAcadObject2.DXFName)
		//			{
		//				case "ARC":
		//					BkDXFList_AcadArc((AcadArc)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "CIRCLE":
		//					BkDXFList_AcadCircle((AcadCircle)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "LINE":
		//					BkDXFList_AcadLine((AcadLine)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "ELLIPSE":
		//					BkDXFList_AcadEllipse((AcadEllipse)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "POINT":
		//					BkDXFList_AcadPoint((AcadPoint)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "XLINE":
		//					BkDXFList_AcadXLine((AcadXline)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "RAY":
		//					BkDXFList_AcadRay((AcadRay)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "LWPOLYLINE":
		//					BkDXFList_AcadLWPolyline((AcadLWPolyline)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "POLYLINE":
		//					BkDXFList_AcadPolyline((AcadPolyline)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "MTEXT":
		//					BkDXFList_AcadMText(vstrAcadVer, (AcadMText)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "TEXT":
		//					BkDXFList_AcadText((AcadText)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "ATTDEF":
		//					BkDXFList_AcadAttributeDefinition((AcadAttribute)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "INSERT":
		//					{
		//						string objectName = dobjAcadObject2.ObjectName;
		//						if (Operators.CompareString(objectName, "AcDbBlockReference", TextCompare: false) != 0)
		//						{
		//							if (Operators.CompareString(objectName, "AcDbMInsertBlock", TextCompare: false) == 0)
		//							{
		//								BkDXFList_AcadMInsertBlock(vstrAcadVer, (AcadMInsertBlock)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//							}
		//						}
		//						else
		//						{
		//							BkDXFList_AcadBlockReference(vstrAcadVer, (AcadBlockReference)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//						}
		//						break;
		//					}
		//				case "SHAPE":
		//					BkDXFList_AcadShape((AcadShape)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "HATCH":
		//					BkDXFList_AcadHatch((AcadHatch)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "SPLINE":
		//					BkDXFList_AcadSpline((AcadSpline)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "SOLID":
		//					BkDXFList_AcadSolid((AcadSolid)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//				case "TRACE":
		//					BkDXFList_AcadTrace((AcadTrace)dobjAcadObject2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//					break;
		//			}
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadObject2 = null;
		//}

		//public static void BkDXFList_AcadObject(AcadObject vobjAcadObject, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadObject acadObject = vobjAcadObject;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 0, acadObject.DXFName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 5, acadObject.Handle, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_Reactors((Dictionary<object, object>)acadObject.DictReactors, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_XDictionary((Dictionary<object, object>)acadObject.DictXDictionaries, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 330, acadObject.OwnerID, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadObject = null;
		//}

		//public static void BkDXFList_AcadEntity(string vstrAcadVer, AcadEntity vobjAcadEntity, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues, bool nvblnIsPaperSpace = false)
		//{
		//	AcadEntity acadEntity = vobjAcadEntity;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, "AcDbEntity", ref robjDictReadCodes, ref robjDictReadValues);
		//	if (nvblnIsPaperSpace)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 67, 1, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 8, acadEntity.Layer, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Operators.CompareString(acadEntity.Linetype, hwpDxf_Vars.pstrEntityLinetype, TextCompare: false) != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 6, acadEntity.Linetype, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadEntity.Color != hwpDxf_Vars.pnumEntityColor)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 62, acadEntity.Color, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Operators.CompareString(vstrAcadVer, "AC1018", TextCompare: false) >= 0 && acadEntity.RGB_Renamed != hwpDxf_Vars.plngRGB)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 420, acadEntity.RGB_Renamed, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadEntity.LinetypeScale, hwpDxf_Vars.pdecLinetypeScale, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadEntity.LinetypeScale, hwpDxf_Vars.pdblLinetypeScale, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 48, RuntimeHelpers.GetObjectValue(acadEntity.LinetypeScale), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadEntity.Visible != hwpDxf_Vars.pblnVisible)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 60, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadEntity.Visible, 0, 1)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if ((double)acadEntity.Lineweight != (double)hwpDxf_ConstMisc.pclngLineweight)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 370, acadEntity.Lineweight, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadEntity.PlotStyleNameObjectID != -1.0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, Conversions.ToInteger("390"), acadEntity.PlotStyleNameReference, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	acadEntity = null;
		//}

		//public static void BkDXFList_AcadArc(AcadArc vobjAcadArc, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadArc acadArc = vobjAcadArc;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, "AcDbCircle", ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadArc.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadArc.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadArc.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadArc.Center, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadArc.Center, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadArc.Center, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadArc.Radius), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, "AcDbArc", ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadArc.StartAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadArc.EndAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadArc.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadArc.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadArc = null;
		//}

		//public static void BkDXFList_AcadCircle(AcadCircle vobjAcadCircle, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadCircle acadCircle = vobjAcadCircle;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadCircle.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadCircle.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadCircle.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadCircle.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadCircle.Center, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadCircle.Center, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadCircle.Center, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadCircle.Radius), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadCircle.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadCircle.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadCircle = null;
		//}

		//public static void BkDXFList_AcadEllipse(AcadEllipse vobjAcadEllipse, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadEllipse acadEllipse = vobjAcadEllipse;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadEllipse.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Center, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Center, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Center, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.MajorAxis, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.MajorAxis, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.MajorAxis, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Normal, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Normal, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadEllipse.Normal, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadEllipse.RadiusRatio), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadEllipse.StartParameter), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadEllipse.EndParameter), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadEllipse.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadEllipse = null;
		//}

		//public static void BkDXFList_AcadLine(AcadLine vobjAcadLine, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadLine acadLine = vobjAcadLine;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadLine.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadLine.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadLine.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadLine.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.StartPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.StartPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.StartPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.EndPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.EndPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadLine.EndPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadLine.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadLine.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadLine = null;
		//}

		//public static void BkDXFList_AcadPoint(AcadPoint vobjAcadPoint, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadPoint acadPoint = vobjAcadPoint;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadPoint.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadPoint.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadPoint.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadPoint.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadPoint.Coordinate, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadPoint.Coordinate, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadPoint.Coordinate, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadPoint.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadPoint.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadPoint = null;
		//}

		//public static void BkDXFList_AcadXLine(AcadXline vobjAcadXline, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadXline acadXline = vobjAcadXline;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadXline.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.BasePoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.BasePoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.BasePoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.DirectionVector, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.DirectionVector, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadXline.DirectionVector, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadXline.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadXline = null;
		//}

		//public static void BkDXFList_AcadRay(AcadRay vobjAcadRay, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadRay acadRay = vobjAcadRay;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadRay.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.BasePoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.BasePoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.BasePoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.DirectionVector, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.DirectionVector, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadRay.DirectionVector, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadRay.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadRay = null;
		//}

		//public static void BkDXFList_AcadLWPolyline(AcadLWPolyline vobjAcadLWPolyline, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadLWPolyline acadLWPolyline = vobjAcadLWPolyline;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadLWPolyline.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 90, acadLWPolyline.NumVerts, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 70, acadLWPolyline.Flags70, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadLWPolyline.HasConstantWidth)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadLWPolyline.ConstantWidth), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadLWPolyline.Elevation, hwpDxf_Vars.pdecElevation, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadLWPolyline.Elevation, hwpDxf_Vars.pdblElevation, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 38, RuntimeHelpers.GetObjectValue(acadLWPolyline.Elevation), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadLWPolyline.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadLWPolyline.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadLWPolyline.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	Dictionary<object, object> dobjVertices2 = (Dictionary<object, object>)acadLWPolyline.Vertices;
		//	object dvarItems = RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(dobjVertices2.Values));
		//	int num = Information.LBound((Array)dvarItems);
		//	int num2 = Information.UBound((Array)dvarItems);
		//	for (int dlngIdx = num; dlngIdx <= num2; dlngIdx = checked(dlngIdx + 1))
		//	{
		//		object dvar2DVertex = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarItems, new object[1]
		//		{
		//		dlngIdx
		//		}, null));
		//		BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		if (!acadLWPolyline.HasConstantWidth)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//			{
		//			3
		//			}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		if (!acadLWPolyline.HasConstantWidth)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//			{
		//			4
		//			}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//		{
		//		2
		//		}, null), hwpDxf_Vars.pdecBulge, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//		{
		//		2
		//		}, null), hwpDxf_Vars.pdblBulge, TextCompare: false)))))
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvar2DVertex, new object[1]
		//			{
		//			2
		//			}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadLWPolyline.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadLWPolyline.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadLWPolyline = null;
		//	dobjVertices2 = null;
		//}

		//public static void BkDXFList_AcadPolyline(AcadPolyline vobjAcadPolyline, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//}

		//public static void BkDXFList_AcadMText(string vstrAcadVer, AcadMText vobjAcadMText, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadMText acadMText = vobjAcadMText;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadMText.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMText.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMText.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMText.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadMText.Height), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadMText.Width), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 71, acadMText.AttachmentPoint, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 72, acadMText.DrawingDirection, ref robjDictReadCodes, ref robjDictReadValues);
		//	string dstrTextString = acadMText.TextString;
		//	if (Strings.Len(dstrTextString) <= 250)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 1, dstrTextString, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	else
		//	{
		//		while (Strings.Len(dstrTextString) > 250)
		//		{
		//			string dstrSubTextString = Strings.Left(dstrTextString, 250);
		//			dstrTextString = Strings.Mid(dstrTextString, 251);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 3, dstrSubTextString, ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		if (Operators.CompareString(dstrTextString, null, TextCompare: false) != 0)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 3, dstrTextString, ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//	}
		//	if (Operators.CompareString(acadMText.TextStyle, hwpDxf_Vars.pstrTextStyleName, TextCompare: false) != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 7, acadMText.TextStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint2 = RuntimeHelpers.GetObjectValue(acadMText.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	dvarPoint2 = RuntimeHelpers.GetObjectValue(acadMText.Direction);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecDirection[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecDirection[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecDirection[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblDirection[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblDirection[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblDirection[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint2, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMText.ActualWidth, hwpDxf_Vars.pdecActualWidth, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMText.ActualWidth, hwpDxf_Vars.pdblActualWidth, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadMText.ActualWidth), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMText.ActualHeight, hwpDxf_Vars.pdecActualHeight, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMText.ActualHeight, hwpDxf_Vars.pdblActualHeight, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadMText.ActualHeight), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMText.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMText.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadMText.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, acadMText.LineSpacingStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadMText.LineSpacingFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Operators.CompareString(vstrAcadVer, "AC1018", TextCompare: false) >= 0 && acadMText.BackgroundMode > 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 90, acadMText.BackgroundMode, ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 63, acadMText.BackgroundFillColor, ref robjDictReadCodes, ref robjDictReadValues);
		//		if (acadMText.BackgroundFillRGB > hwpDxf_Vars.plngBackgroundFillRGB)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 421, acadMText.BackgroundFillRGB, ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		BkDXFList_AddToDictLine(ref rlngIdx, 45, RuntimeHelpers.GetObjectValue(acadMText.BackgroundBorderOffsetFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 441, acadMText.BackgroundCode441, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadMText.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadMText = null;
		//}

		//public static void BkDXFList_AcadText(AcadText vobjAcadText, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadText acadText = vobjAcadText;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadText.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadText.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadText.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadText.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadText.Height), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 1, acadText.TextString, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadText.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadText.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadText.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadText.ScaleFactor, hwpDxf_Vars.pdecScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadText.ScaleFactor, hwpDxf_Vars.pdblScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadText.ScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadText.ObliqueAngleDegree, hwpDxf_Vars.pdecObliqueAngleDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadText.ObliqueAngleDegree, hwpDxf_Vars.pdblObliqueAngleDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadText.ObliqueAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Operators.CompareString(Strings.UCase(acadText.TextStyle), Strings.UCase(hwpDxf_Vars.pstrTextStyleName), TextCompare: false) != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 7, acadText.TextStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadText.TextGenerationFlag != hwpDxf_Vars.pnumTextGenerationFlag)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 71, acadText.TextGenerationFlag, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadText.HorizontalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 72, acadText.HorizontalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if ((acadText.HorizontalAlignment != Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft) | (acadText.VerticalAlignment != Enums.AcVerticalAlignment.acVerticalAlignmentBaseline))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.TextAlignmentPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.TextAlignmentPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadText.TextAlignmentPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadText.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadText.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadText.VerticalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 73, acadText.VerticalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadText.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadText = null;
		//}

		//public static void BkDXFList_AcadBlockReference(string vstrAcadVer, AcadBlockReference vobjAcadBlockReference, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadBlockReference acadBlockReference = vobjAcadBlockReference;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadBlockReference.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadBlockReference.HasAttributes != hwpDxf_Vars.pblnHasAttributes)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 66, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadBlockReference.HasAttributes, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadBlockReference.Name, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadBlockReference.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadBlockReference.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadBlockReference.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockReference.XScaleFactor, hwpDxf_Vars.pdecXScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockReference.XScaleFactor, hwpDxf_Vars.pdblXScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadBlockReference.XScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockReference.YScaleFactor, hwpDxf_Vars.pdecYScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockReference.YScaleFactor, hwpDxf_Vars.pdblYScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadBlockReference.YScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockReference.ZScaleFactor, hwpDxf_Vars.pdecZScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockReference.ZScaleFactor, hwpDxf_Vars.pdblZScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadBlockReference.ZScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadBlockReference.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadBlockReference.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadBlockReference.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadBlockReference.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadBlockReference.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadBlockReference = null;
		//	AcadSequenceEnd dobjAcadSequenceEnd2;
		//	AcadAttributeReference dobjAcadAttributeReference2;
		//	if (vobjAcadBlockReference.HasAttributes)
		//	{
		//		IEnumerator enumerator = default(IEnumerator);
		//		try
		//		{
		//			enumerator = vobjAcadBlockReference.GetValues().GetEnumerator();
		//			while (enumerator.MoveNext())
		//			{
		//				dobjAcadAttributeReference2 = (AcadAttributeReference)enumerator.Current;
		//				BkDXFList_AcadObject(dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//				BkDXFList_AcadEntity(vstrAcadVer, dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//				BkDXFList_AcadAttributeReference(dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//		finally
		//		{
		//			if (enumerator is IDisposable)
		//			{
		//				(enumerator as IDisposable).Dispose();
		//			}
		//		}
		//		dobjAcadSequenceEnd2 = vobjAcadBlockReference.SequenceEnd;
		//		BkDXFList_AcadSequenceEnd(dobjAcadSequenceEnd2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	dobjAcadSequenceEnd2 = null;
		//	dobjAcadAttributeReference2 = null;
		//}

		//public static void BkDXFList_AcadMInsertBlock(string vstrAcadVer, AcadMInsertBlock vobjAcadMInsertBlock, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadMInsertBlock acadMInsertBlock = vobjAcadMInsertBlock;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadMInsertBlock.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadMInsertBlock.HasAttributes != hwpDxf_Vars.pblnHasAttributes)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 66, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadMInsertBlock.HasAttributes, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadMInsertBlock.Name, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMInsertBlock.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMInsertBlock.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadMInsertBlock.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.XScaleFactor, hwpDxf_Vars.pdecXScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.XScaleFactor, hwpDxf_Vars.pdblXScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadMInsertBlock.XScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.YScaleFactor, hwpDxf_Vars.pdecYScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.YScaleFactor, hwpDxf_Vars.pdblYScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadMInsertBlock.YScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.ZScaleFactor, hwpDxf_Vars.pdecZScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.ZScaleFactor, hwpDxf_Vars.pdblZScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadMInsertBlock.ZScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadMInsertBlock.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadMInsertBlock.Columns != hwpDxf_Vars.plngColumns)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 70, acadMInsertBlock.Columns, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadMInsertBlock.Rows != hwpDxf_Vars.plngRows)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 71, acadMInsertBlock.Rows, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.ColumnSpacing, hwpDxf_Vars.pdecColumnSpacing, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.ColumnSpacing, hwpDxf_Vars.pdblColumnSpacing, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadMInsertBlock.ColumnSpacing), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadMInsertBlock.RowSpacing, hwpDxf_Vars.pdecRowSpacing, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadMInsertBlock.RowSpacing, hwpDxf_Vars.pdblRowSpacing, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 45, RuntimeHelpers.GetObjectValue(acadMInsertBlock.RowSpacing), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadMInsertBlock.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadMInsertBlock.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadMInsertBlock = null;
		//	AcadSequenceEnd dobjAcadSequenceEnd2;
		//	AcadAttributeReference dobjAcadAttributeReference2;
		//	if (vobjAcadMInsertBlock.HasAttributes)
		//	{
		//		IEnumerator enumerator = default(IEnumerator);
		//		try
		//		{
		//			enumerator = vobjAcadMInsertBlock.GetValues().GetEnumerator();
		//			while (enumerator.MoveNext())
		//			{
		//				dobjAcadAttributeReference2 = (AcadAttributeReference)enumerator.Current;
		//				BkDXFList_AcadObject(dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//				BkDXFList_AcadEntity(vstrAcadVer, dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//				BkDXFList_AcadAttributeReference(dobjAcadAttributeReference2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//		finally
		//		{
		//			if (enumerator is IDisposable)
		//			{
		//				(enumerator as IDisposable).Dispose();
		//			}
		//		}
		//		dobjAcadSequenceEnd2 = vobjAcadMInsertBlock.SequenceEnd;
		//		BkDXFList_AcadSequenceEnd(dobjAcadSequenceEnd2, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	dobjAcadSequenceEnd2 = null;
		//	dobjAcadAttributeReference2 = null;
		//}

		//private static void BkDXFList_AcadSequenceEnd(AcadSequenceEnd vobjAcadSequenceEnd, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadSequenceEnd acadSequenceEnd = vobjAcadSequenceEnd;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 0, acadSequenceEnd.DXFName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 5, acadSequenceEnd.Handle, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_Reactors((Dictionary<object, object>)acadSequenceEnd.DictReactors, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 330, acadSequenceEnd.OwnerID, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, "AcDbEntity", ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 8, acadSequenceEnd.Layer, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadSequenceEnd = null;
		//}

		//public static void BkDXFList_AcadAttributeReference(AcadAttributeReference vobjAcadAttributeReference, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadAttributeReference acadAttributeReference = vobjAcadAttributeReference;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadAttributeReference.SuperiorObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttributeReference.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttributeReference.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadAttributeReference.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadAttributeReference.Height), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 1, acadAttributeReference.TextString, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttributeReference.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttributeReference.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadAttributeReference.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttributeReference.ScaleFactor, hwpDxf_Vars.pdecScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttributeReference.ScaleFactor, hwpDxf_Vars.pdblScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadAttributeReference.ScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttributeReference.ObliqueAngleDegree, hwpDxf_Vars.pdecObliqueAngleDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttributeReference.ObliqueAngleDegree, hwpDxf_Vars.pdblObliqueAngleDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadAttributeReference.ObliqueAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Operators.CompareString(Strings.UCase(acadAttributeReference.TextStyle), Strings.UCase(hwpDxf_Vars.pstrTextStyleName), TextCompare: false) != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 7, acadAttributeReference.TextStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttributeReference.TextGenerationFlag != hwpDxf_Vars.pnumTextGenerationFlag)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 71, acadAttributeReference.TextGenerationFlag, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttributeReference.HorizontalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 72, acadAttributeReference.HorizontalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if ((acadAttributeReference.HorizontalAlignment != Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft) | (acadAttributeReference.VerticalAlignment != Enums.AcVerticalAlignment.acVerticalAlignmentBaseline))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.TextAlignmentPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.TextAlignmentPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttributeReference.TextAlignmentPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadAttributeReference.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadAttributeReference.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadAttributeReference.TagString, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 70, acadAttributeReference.AttribFlags, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadAttributeReference.FieldLength != hwpDxf_Vars.plngFieldLength)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 73, acadAttributeReference.FieldLength, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttributeReference.VerticalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 74, acadAttributeReference.VerticalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadAttributeReference.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadAttributeReference = null;
		//}

		//public static void BkDXFList_AcadAttributeDefinition(AcadAttribute vobjAcadAttribute, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadAttribute acadAttribute = vobjAcadAttribute;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadAttribute.SuperiorObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttribute.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttribute.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadAttribute.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadAttribute.Height), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 1, acadAttribute.TextString, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttribute.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttribute.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadAttribute.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttribute.ScaleFactor, hwpDxf_Vars.pdecScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttribute.ScaleFactor, hwpDxf_Vars.pdblScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadAttribute.ScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadAttribute.ObliqueAngleDegree, hwpDxf_Vars.pdecObliqueAngleDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadAttribute.ObliqueAngleDegree, hwpDxf_Vars.pdblObliqueAngleDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadAttribute.ObliqueAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Operators.CompareString(Strings.UCase(acadAttribute.TextStyle), Strings.UCase(hwpDxf_Vars.pstrTextStyleName), TextCompare: false) != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 7, acadAttribute.TextStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttribute.TextGenerationFlag != hwpDxf_Vars.pnumTextGenerationFlag)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 71, acadAttribute.TextGenerationFlag, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttribute.HorizontalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 72, acadAttribute.HorizontalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if ((acadAttribute.HorizontalAlignment != Enums.AcHorizontalAlignment.acHorizontalAlignmentLeft) | (acadAttribute.VerticalAlignment != Enums.AcVerticalAlignment.acVerticalAlignmentBaseline))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.TextAlignmentPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.TextAlignmentPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadAttribute.TextAlignmentPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadAttribute.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadAttribute.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 3, acadAttribute.PromptString, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadAttribute.TagString, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 70, acadAttribute.AttribFlags, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadAttribute.FieldLength != hwpDxf_Vars.plngFieldLength)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 73, acadAttribute.FieldLength, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadAttribute.VerticalAlignment != 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 74, acadAttribute.VerticalAlignment, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadAttribute.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadAttribute = null;
		//}

		//public static void BkDXFList_AcadShape(AcadShape vobjAcadShape, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadShape acadShape = vobjAcadShape;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadShape.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadShape.Thickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadShape.Thickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(acadShape.Thickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadShape.InsertionPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadShape.InsertionPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadShape.InsertionPoint, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadShape.Height), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadShape.Name, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadShape.RotationDegree, hwpDxf_Vars.pdecRotationDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadShape.RotationDegree, hwpDxf_Vars.pdblRotationDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acadShape.RotationDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadShape.ScaleFactor, hwpDxf_Vars.pdecScaleFactor, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadShape.ScaleFactor, hwpDxf_Vars.pdblScaleFactor, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadShape.ScaleFactor), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadShape.ObliqueAngleDegree, hwpDxf_Vars.pdecObliqueAngleDegree, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadShape.ObliqueAngleDegree, hwpDxf_Vars.pdblObliqueAngleDegree, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acadShape.ObliqueAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(acadShape.Normal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadShape.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadShape = null;
		//}

		//public static void BkDXFList_AcadHatch(AcadHatch vobjAcadHatch, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadHatch acadHatch = vobjAcadHatch;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadHatch.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Elevation, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Elevation, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Elevation, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Normal, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Normal, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadHatch.Normal, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 2, acadHatch.PatternName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 70, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadHatch.IsSolid, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 71, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadHatch.AssociativeHatch, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 91, acadHatch.NumberOfLoops, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AcadHatchLoops(acadHatch.Loops, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 75, acadHatch.HatchStyle, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 76, acadHatch.PatternType, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (!acadHatch.IsSolid)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 52, RuntimeHelpers.GetObjectValue(acadHatch.PatternAngle), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(acadHatch.PatternScale), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 77, RuntimeHelpers.GetObjectValue(Interaction.IIf(acadHatch.PatternDouble, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 78, acadHatch.NumberOfPatternDefinitions, ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AcadPatternDefinitions(acadHatch.PatternDefinitions, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(acadHatch.PixelSize, hwpDxf_Vars.pdecPixelSize, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(acadHatch.PixelSize, hwpDxf_Vars.pdblPixelSize, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 47, RuntimeHelpers.GetObjectValue(acadHatch.PixelSize), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 98, acadHatch.NumberOfSeedPoints, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AcadSeedPoints(acadHatch.SeedPoints, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	acadHatch.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//	acadHatch = null;
		//}

		//public static void BkDXFList_AcadHatchLoops(AcadLoops vobjAcadLoops, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadLoop dobjAcadLoop2;
		//	try
		//	{
		//		enumerator = vobjAcadLoops.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadLoop2 = (AcadLoop)enumerator.Current;
		//			AcadLoop acadLoop = dobjAcadLoop2;
		//			BkDXFList_AddToDictLine(ref rlngIdx, 92, acadLoop.LoopType, ref robjDictReadCodes, ref robjDictReadValues);
		//			if (acadLoop.IsPolyline)
		//			{
		//				BkDXFList_AcGePolyline2d(acadLoop.Polyline, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			else
		//			{
		//				BkDXFList_AddToDictLine(ref rlngIdx, 93, acadLoop.NumberOfEdges, ref robjDictReadCodes, ref robjDictReadValues);
		//				BkDXFList_AcadLoopEdges(acadLoop.Edges, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			BkDXFList_AddToDictLine(ref rlngIdx, 97, acadLoop.NumberOfAssocObjects, ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_CodeDictionary((Dictionary<object, object>)acadLoop.AssocObjects, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			acadLoop = null;
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadLoop2 = null;
		//}

		//public static void BkDXFList_AcGePolyline2d(AcGePolyline2d vobjAcGePolyline2d, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcGePolyline2d acGePolyline2d = vobjAcGePolyline2d;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 72, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGePolyline2d.Bulged, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGePolyline2d.Closed, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 93, acGePolyline2d.NumberOfVertices, ref robjDictReadCodes, ref robjDictReadValues);
		//	checked
		//	{
		//		int num = acGePolyline2d.NumberOfVertices - 1;
		//		AcGeVertex2d dobjAcGeVertex2d;
		//		for (int dlngIdx = 0; dlngIdx <= num; dlngIdx++)
		//		{
		//			dobjAcGeVertex2d = acGePolyline2d.GetVertex(dlngIdx);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(dobjAcGeVertex2d.CoordX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(dobjAcGeVertex2d.CoordY), ref robjDictReadCodes, ref robjDictReadValues);
		//			if (acGePolyline2d.Bulged)
		//			{
		//				BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(dobjAcGeVertex2d.Bulge), ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//		acGePolyline2d = null;
		//		dobjAcGeVertex2d = null;
		//	}
		//}

		//public static void BkDXFList_AcadLoopEdges(AcadLoopEdges vobjAcadLoopEdges, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadLoopEdge dobjAcadLoopEdge2;
		//	try
		//	{
		//		enumerator = vobjAcadLoopEdges.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadLoopEdge2 = (AcadLoopEdge)enumerator.Current;
		//			AcadLoopEdge acadLoopEdge = dobjAcadLoopEdge2;
		//			BkDXFList_AddToDictLine(ref rlngIdx, 72, RuntimeHelpers.GetObjectValue(acadLoopEdge.EdgeType), ref robjDictReadCodes, ref robjDictReadValues);
		//			object edgeType = acadLoopEdge.EdgeType;
		//			if (Operators.ConditionalCompareObjectEqual(edgeType, Enums.AcLoopEdgeType.acHatchLoopEdgeTypeLine, TextCompare: false))
		//			{
		//				BkDXFList_AcGeLinSeg2d((AcGeLinSeg2d)acadLoopEdge.EdgeObject, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			else if (Operators.ConditionalCompareObjectEqual(edgeType, Enums.AcLoopEdgeType.acHatchLoopEdgeTypeCirArc, TextCompare: false))
		//			{
		//				BkDXFList_AcGeCircArc2d((AcGeCircArc2d)acadLoopEdge.EdgeObject, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			else if (Operators.ConditionalCompareObjectEqual(edgeType, Enums.AcLoopEdgeType.acHatchLoopEdgeTypeEllArc, TextCompare: false))
		//			{
		//				BkDXFList_AcGeEllipArc2d((AcGeEllipArc2d)acadLoopEdge.EdgeObject, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			else if (Operators.ConditionalCompareObjectEqual(edgeType, Enums.AcLoopEdgeType.acHatchLoopEdgeTypeSpline, TextCompare: false))
		//			{
		//				BkDXFList_AcGeNurbCurve2d((AcGeNurbCurve2d)acadLoopEdge.EdgeObject, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//			acadLoopEdge = null;
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadLoopEdge2 = null;
		//}

		//public static void BkDXFList_AcGeLinSeg2d(AcGeLinSeg2d vobjAcGeLinSeg2d, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcGeLinSeg2d acGeLinSeg2d = vobjAcGeLinSeg2d;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeLinSeg2d.StartPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeLinSeg2d.StartPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeLinSeg2d.EndPoint, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeLinSeg2d.EndPoint, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	acGeLinSeg2d = null;
		//}

		//public static void BkDXFList_AcGeCircArc2d(AcGeCircArc2d vobjAcGeCircArc2d, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcGeCircArc2d acGeCircArc2d = vobjAcGeCircArc2d;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeCircArc2d.Center, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeCircArc2d.Center, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acGeCircArc2d.Radius), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acGeCircArc2d.StartAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acGeCircArc2d.EndAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGeCircArc2d.IsClockWise, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	acGeCircArc2d = null;
		//}

		//public static void BkDXFList_AcGeEllipArc2d(AcGeEllipArc2d vobjAcGeEllipArc2d, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcGeEllipArc2d acGeEllipArc2d = vobjAcGeEllipArc2d;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeEllipArc2d.Center, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeEllipArc2d.Center, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeEllipArc2d.MajorAxis, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acGeEllipArc2d.MajorAxis, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acGeEllipArc2d.RadiusRatio), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 50, RuntimeHelpers.GetObjectValue(acGeEllipArc2d.StartAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 51, RuntimeHelpers.GetObjectValue(acGeEllipArc2d.EndAngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGeEllipArc2d.IsClockWise, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	acGeEllipArc2d = null;
		//}

		//public static void BkDXFList_AcGeNurbCurve2d(AcGeNurbCurve2d vobjAcGeNurbCurve2d, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcGeNurbCurve2d acGeNurbCurve2d = vobjAcGeNurbCurve2d;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 94, acGeNurbCurve2d.Degree, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGeNurbCurve2d.IsRational, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 74, RuntimeHelpers.GetObjectValue(Interaction.IIf(acGeNurbCurve2d.IsPeriodic, 1, 0)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 95, acGeNurbCurve2d.NumberOfKnots, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 96, acGeNurbCurve2d.NumberOfControlPoints, ref robjDictReadCodes, ref robjDictReadValues);
		//	checked
		//	{
		//		int num = acGeNurbCurve2d.NumberOfKnots - 1;
		//		for (int dlngIdx2 = 0; dlngIdx2 <= num; dlngIdx2++)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acGeNurbCurve2d.GetKnot(dlngIdx2)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		int num2 = acGeNurbCurve2d.NumberOfControlPoints - 1;
		//		AcGeCtrlPoint2d dobjAcGeCtrlPoint2d;
		//		for (int dlngIdx2 = 0; dlngIdx2 <= num2; dlngIdx2++)
		//		{
		//			dobjAcGeCtrlPoint2d = acGeNurbCurve2d.GetControlPoint(dlngIdx2);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint2d.CoordX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint2d.CoordY), ref robjDictReadCodes, ref robjDictReadValues);
		//			if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(dobjAcGeCtrlPoint2d.Weight, hwpDxf_Vars.pdecWeight, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(dobjAcGeCtrlPoint2d.Weight, hwpDxf_Vars.pdblWeight, TextCompare: false)))))
		//			{
		//				BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint2d.Weight), ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//		acGeNurbCurve2d = null;
		//		dobjAcGeCtrlPoint2d = null;
		//	}
		//}

		//public static void BkDXFList_AcadPatternDefinitions(AcadPatternDefinitions vobjAcadPatternDefinitions, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadPatternDefinition dobjAcadPatternDefinition2;
		//	try
		//	{
		//		enumerator = vobjAcadPatternDefinitions.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadPatternDefinition2 = (AcadPatternDefinition)enumerator.Current;
		//			AcadPatternDefinition acadPatternDefinition = dobjAcadPatternDefinition2;
		//			BkDXFList_AddToDictLine(ref rlngIdx, 53, RuntimeHelpers.GetObjectValue(acadPatternDefinition.AngleDegree), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadPatternDefinition.BaseX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadPatternDefinition.BaseY), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 45, RuntimeHelpers.GetObjectValue(acadPatternDefinition.OffsetX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 46, RuntimeHelpers.GetObjectValue(acadPatternDefinition.OffsetY), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 79, acadPatternDefinition.NumberOfDashes, ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AcadPatternDefDashes(acadPatternDefinition.Dashes, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//			acadPatternDefinition = null;
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadPatternDefinition2 = null;
		//}

		//public static void BkDXFList_AcadPatternDefDashes(AcadPatternDefDashes vobjAcadPatternDefDashes, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadPatternDefDash dobjAcadPatternDefDash2;
		//	try
		//	{
		//		enumerator = vobjAcadPatternDefDashes.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadPatternDefDash2 = (AcadPatternDefDash)enumerator.Current;
		//			AcadPatternDefDash acadPatternDefDash = dobjAcadPatternDefDash2;
		//			BkDXFList_AddToDictLine(ref rlngIdx, 49, RuntimeHelpers.GetObjectValue(acadPatternDefDash.Length), ref robjDictReadCodes, ref robjDictReadValues);
		//			acadPatternDefDash = null;
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadPatternDefDash2 = null;
		//}

		//public static void BkDXFList_AcadSeedPoints(AcadSeedPoints vobjAcadSeedPoints, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	IEnumerator enumerator = default(IEnumerator);
		//	AcadSeedPoint dobjAcadSeedPoint2;
		//	try
		//	{
		//		enumerator = vobjAcadSeedPoints.GetValues().GetEnumerator();
		//		while (enumerator.MoveNext())
		//		{
		//			dobjAcadSeedPoint2 = (AcadSeedPoint)enumerator.Current;
		//			AcadSeedPoint acadSeedPoint = dobjAcadSeedPoint2;
		//			BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(acadSeedPoint.CoordX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(acadSeedPoint.CoordY), ref robjDictReadCodes, ref robjDictReadValues);
		//			acadSeedPoint = null;
		//		}
		//	}
		//	finally
		//	{
		//		if (enumerator is IDisposable)
		//		{
		//			(enumerator as IDisposable).Dispose();
		//		}
		//	}
		//	dobjAcadSeedPoint2 = null;
		//}

		//public static void BkDXFList_AcadSpline(AcadSpline vobjAcadSpline, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	AcadSpline acadSpline = vobjAcadSpline;
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, acadSpline.ObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadSpline.IsPlanar)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.Normal, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.Normal, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.Normal, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 70, acadSpline.SplineFlags, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 71, acadSpline.Degree, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 72, acadSpline.NumberOfKnots, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 73, acadSpline.NumberOfControlPoints, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 74, acadSpline.NumberOfFitPoints, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 42, RuntimeHelpers.GetObjectValue(acadSpline.KnotTolerance), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 43, RuntimeHelpers.GetObjectValue(acadSpline.ControlPointTolerance), ref robjDictReadCodes, ref robjDictReadValues);
		//	if (acadSpline.NumberOfFitPoints > 0)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 44, RuntimeHelpers.GetObjectValue(acadSpline.FitTolerance), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadSpline.HasStartTangent)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.StartTangent, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.StartTangent, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 32, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.StartTangent, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	if (acadSpline.HasEndTangent)
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 13, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.EndTangent, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 23, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.EndTangent, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 33, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(acadSpline.EndTangent, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	checked
		//	{
		//		int num = acadSpline.NumberOfKnots - 1;
		//		for (int dlngIdx3 = 0; dlngIdx3 <= num; dlngIdx3++)
		//		{
		//			BkDXFList_AddToDictLine(ref rlngIdx, 40, RuntimeHelpers.GetObjectValue(acadSpline.GetKnot(dlngIdx3)), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		int num2 = acadSpline.NumberOfControlPoints - 1;
		//		AcGeCtrlPoint3d dobjAcGeCtrlPoint3d;
		//		for (int dlngIdx3 = 0; dlngIdx3 <= num2; dlngIdx3++)
		//		{
		//			dobjAcGeCtrlPoint3d = acadSpline.GetControlPoint(dlngIdx3);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d.CoordX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d.CoordY), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d.CoordZ), ref robjDictReadCodes, ref robjDictReadValues);
		//			if (acadSpline.IsRational)
		//			{
		//				BkDXFList_AddToDictLine(ref rlngIdx, 41, RuntimeHelpers.GetObjectValue(dobjAcGeCtrlPoint3d.Weight), ref robjDictReadCodes, ref robjDictReadValues);
		//			}
		//		}
		//		int num3 = acadSpline.NumberOfFitPoints - 1;
		//		AcGePoint3d dobjAcGePoint3d;
		//		for (int dlngIdx3 = 0; dlngIdx3 <= num3; dlngIdx3++)
		//		{
		//			dobjAcGePoint3d = acadSpline.GetFitPoint(dlngIdx3);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(dobjAcGePoint3d.CoordX), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(dobjAcGePoint3d.CoordY), ref robjDictReadCodes, ref robjDictReadValues);
		//			BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(dobjAcGePoint3d.CoordZ), ref robjDictReadCodes, ref robjDictReadValues);
		//		}
		//		object dvarXDataType = default(object);
		//		object dvarXDataValue = default(object);
		//		acadSpline.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//		BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//		acadSpline = null;
		//		dobjAcGePoint3d = null;
		//		dobjAcGeCtrlPoint3d = null;
		//	}
		//}

		//public static void BkDXFList_AcDbTrace(AcadObject vobjAcadObject, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	string dXFName = vobjAcadObject.DXFName;
		//	string dstrObjectName = default(string);
		//	object dobjCoordinates = default(object);
		//	object dobjThickness = default(object);
		//	object dobjNormal = default(object);
		//	if (Operators.CompareString(dXFName, "SOLID", TextCompare: false) != 0)
		//	{
		//		if (Operators.CompareString(dXFName, "TRACE", TextCompare: false) == 0)
		//		{
		//			AcadTrace dobjAcadTrace2 = (AcadTrace)vobjAcadObject;
		//			AcadTrace acadTrace = dobjAcadTrace2;
		//			dstrObjectName = acadTrace.ObjectName;
		//			dobjCoordinates = RuntimeHelpers.GetObjectValue(acadTrace.Coordinates);
		//			dobjThickness = RuntimeHelpers.GetObjectValue(acadTrace.Thickness);
		//			dobjNormal = RuntimeHelpers.GetObjectValue(acadTrace.Normal);
		//			acadTrace = null;
		//		}
		//	}
		//	else
		//	{
		//		AcadSolid dobjAcadSolid2 = (AcadSolid)vobjAcadObject;
		//		AcadSolid acadSolid = dobjAcadSolid2;
		//		dstrObjectName = acadSolid.ObjectName;
		//		dobjCoordinates = RuntimeHelpers.GetObjectValue(acadSolid.Coordinates);
		//		dobjThickness = RuntimeHelpers.GetObjectValue(acadSolid.Thickness);
		//		dobjNormal = RuntimeHelpers.GetObjectValue(acadSolid.Normal);
		//		acadSolid = null;
		//	}
		//	BkDXFList_AddToDictLine(ref rlngIdx, 100, dstrObjectName, ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 10, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	0
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 20, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	1
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 30, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	2
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 11, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	3
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 21, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	4
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 31, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	5
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 12, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	6
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 22, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	7
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 32, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	8
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 13, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	9
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 23, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	10
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	BkDXFList_AddToDictLine(ref rlngIdx, 33, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dobjCoordinates, new object[1]
		//	{
		//	11
		//	}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.CompareObjectNotEqual(dobjThickness, hwpDxf_Vars.pdecThickness, TextCompare: false)), Operators.AndObject(true, Operators.CompareObjectNotEqual(dobjThickness, hwpDxf_Vars.pdblThickness, TextCompare: false)))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 39, RuntimeHelpers.GetObjectValue(dobjThickness), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	object dvarPoint = RuntimeHelpers.GetObjectValue(dobjNormal);
		//	if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(false, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padecNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padecNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padecNormal[2], TextCompare: false))), Operators.AndObject(true, Operators.OrObject(Operators.OrObject(Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	0
		//	}, null), hwpDxf_Vars.padblNormal[0], TextCompare: false), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	1
		//	}, null), hwpDxf_Vars.padblNormal[1], TextCompare: false)), Operators.CompareObjectNotEqual(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//	{
		//	2
		//	}, null), hwpDxf_Vars.padblNormal[2], TextCompare: false))))))
		//	{
		//		BkDXFList_AddToDictLine(ref rlngIdx, 210, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		0
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 220, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		1
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//		BkDXFList_AddToDictLine(ref rlngIdx, 230, RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(dvarPoint, new object[1]
		//		{
		//		2
		//		}, null)), ref robjDictReadCodes, ref robjDictReadValues);
		//	}
		//	string dXFName2 = vobjAcadObject.DXFName;
		//	object dvarXDataType = default(object);
		//	object dvarXDataValue = default(object);
		//	if (Operators.CompareString(dXFName2, "SOLID", TextCompare: false) != 0)
		//	{
		//		if (Operators.CompareString(dXFName2, "TRACE", TextCompare: false) == 0)
		//		{
		//			AcadTrace dobjAcadTrace2 = (AcadTrace)vobjAcadObject;
		//			dobjAcadTrace2.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//		}
		//	}
		//	else
		//	{
		//		AcadSolid dobjAcadSolid2 = (AcadSolid)vobjAcadObject;
		//		dobjAcadSolid2.GetXData(null, ref dvarXDataType, ref dvarXDataValue);
		//	}
		//	BkDXFList_XData(RuntimeHelpers.GetObjectValue(dvarXDataType), RuntimeHelpers.GetObjectValue(dvarXDataValue), ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}

		//public static void BkDXFList_AcadSolid(AcadSolid vobjAcadSolid, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	BkDXFList_AcDbTrace(vobjAcadSolid, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}

		//public static void BkDXFList_AcadTrace(AcadTrace vobjAcadTrace, ref int rlngIdx, ref Dictionary<object, object> robjDictReadCodes, ref Dictionary<object, object> robjDictReadValues)
		//{
		//	BkDXFList_AcDbTrace(vobjAcadTrace, ref rlngIdx, ref robjDictReadCodes, ref robjDictReadValues);
		//}
	}
}
