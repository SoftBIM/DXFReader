using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;

namespace DXFLib.Acad
{
	public class AcadBlockReference : AcadEntity
	{
		private const string cstrClassName = "AcadBlockReference";

		private bool mblnOpened;

		private int mlngImpNodeID;

		private bool mblnHasAttributes;

		private double mdblReferencedBlockObjectID;

		private object[] madecInsertionPoint;

		private double[] madblInsertionPoint;

		private object mdecXScaleFactor;

		private double mdblXScaleFactor;

		private object mdecYScaleFactor;

		private double mdblYScaleFactor;

		private object mdecZScaleFactor;

		private double mdblZScaleFactor;

		private object mdecRotationDegree;

		private double mdblRotationDegree;

		private object[] madecNormal;

		private double[] madblNormal;

		private OrderedDictionary mcolClass;

		private AcadSequenceEnd mobjAcadSequenceEnd;

		private AcadAttributeRefDictionary mobjAcadAttributeReferenceDictionary;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendLetDatabaseIndex = value;
				}
				if (mobjAcadAttributeReferenceDictionary != null)
				{
					mobjAcadAttributeReferenceDictionary.FriendLetDatabaseIndex = value;
				}
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
				if (mobjAcadAttributeReferenceDictionary != null)
				{
					mobjAcadAttributeReferenceDictionary.FriendLetDocumentIndex = value;
				}
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
				if (mobjAcadAttributeReferenceDictionary != null)
				{
					mobjAcadAttributeReferenceDictionary.FriendLetApplicationIndex = value;
				}
			}
		}

		internal bool FriendLetHasAttributes
		{
			set
			{
				mblnHasAttributes = value;
			}
		}

		internal int FriendLetImpNodeID
		{
			set
			{
				mlngImpNodeID = value;
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

		public int CountAttributes => mcolClass.Count;

		public bool HasAttributes => mblnHasAttributes;

		public string Name
		{
			get
			{
				return ReferencedBlock;
			}
			set
			{
				ReferencedBlock = value;
			}
		}

		public object InsertionPoint
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, madecInsertionPoint, madblInsertionPoint));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object[] reference = ref madecInsertionPoint;
				object ravarArrayDec = reference;
				ref double[] reference2 = ref madblInsertionPoint;
				object ravarArrayDbl = reference2;
				string dstrErrMsg = default(string);
				bool flag = hwpDxf_Functions.BkDXF_SetArrayReal(ref ravarArrayDec, ref ravarArrayDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference2 = (double[])ravarArrayDbl;
				reference = (object[])ravarArrayDec;
				if (!flag)
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public object XScaleFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecXScaleFactor), mdblXScaleFactor));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecXScaleFactor;
				ref double reference = ref mdblXScaleFactor;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public object YScaleFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecYScaleFactor), mdblYScaleFactor));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecYScaleFactor;
				ref double reference = ref mdblYScaleFactor;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public object ZScaleFactor
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecZScaleFactor), mdblZScaleFactor));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecZScaleFactor;
				ref double reference = ref mdblZScaleFactor;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public object RotationDegree
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecRotationDegree), mdblRotationDegree));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				ref object rvarValueDec = ref mdecRotationDegree;
				ref double reference = ref mdblRotationDegree;
				object rvarValueDbl = reference;
				string dstrErrMsg = default(string);
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (!num)
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public object Rotation
		{
			get
			{
				return RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(RotationDegree)));
			}
			[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
			set
			{
				string dstrErrMsg = default(string);
				if (!hwpDxf_Functions.BkDXF_CheckVariantForValueReal(RuntimeHelpers.GetObjectValue(value), ref dstrErrMsg))
				{
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
					return;
				}
				bool flag = false;
				mdblRotationDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
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
					Information.Err().Raise(50000, "AcadBlockReference", dstrErrMsg);
				}
			}
		}

		public AcadAttributeRefDictionary AttributeReferenceDictionary => InternGetAttributeReferenceDictionary();

		public double ReferencedBlockObjectID => mdblReferencedBlockObjectID;

		public string ReferencedBlockReference
		{
			get
			{
				if (mdblReferencedBlockObjectID > 0.0)
				{
					return hwpDxf_Functions.BkDXF_DblToHex(mdblReferencedBlockObjectID);
				}
				return null;
			}
		}

		public string ReferencedBlock
		{
			get
			{
				string ReferencedBlock = default(string);
				AcadBlock dobjAcadBlock2;
				AcadObject dobjAcadObject2 = default(AcadObject);
				if (mdblReferencedBlockObjectID > 0.0)
				{
					AcadDatabase database = base.Database;
					double vdblObjectID = mdblReferencedBlockObjectID;
					string nrstrErrMsg = "";
					if (database.FriendObjectIdToObject(vdblObjectID, ref dobjAcadObject2, ref nrstrErrMsg) && Operators.CompareString(dobjAcadObject2.ObjectName, "AcDbBlockTableRecord", TextCompare: false) == 0)
					{
						dobjAcadBlock2 = (AcadBlock)dobjAcadObject2;
						ReferencedBlock = dobjAcadBlock2.Name;
					}
				}
				dobjAcadBlock2 = null;
				dobjAcadObject2 = null;
				return ReferencedBlock;
			}
			set
			{
				AcadBlock dobjAcadBlock2 = (AcadBlock)base.Database.Blocks.FriendGetItem(value);
				if (dobjAcadBlock2 != null)
				{
					mdblReferencedBlockObjectID = dobjAcadBlock2.ObjectID;
				}
				dobjAcadBlock2 = null;
			}
		}

		public AcadBlockReference()
		{
			madecInsertionPoint = new object[3];
			madblInsertionPoint = new double[3];
			madecNormal = new object[3];
			madblNormal = new double[3];
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 239;
			base.FriendLetNodeImageDisabledID = 240;
			base.FriendLetNodeName = "Blockeinfügung";
			base.FriendLetNodeText = "Blockeinfügung";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mlngImpNodeID = -1;
			bool flag = false;
			madblInsertionPoint[0] = hwpDxf_Vars.padblInsertionPoint[0];
			madblInsertionPoint[1] = hwpDxf_Vars.padblInsertionPoint[1];
			madblInsertionPoint[2] = hwpDxf_Vars.padblInsertionPoint[2];
			mdblXScaleFactor = hwpDxf_Vars.pdblXScaleFactor;
			mdblYScaleFactor = hwpDxf_Vars.pdblYScaleFactor;
			mdblZScaleFactor = hwpDxf_Vars.pdblZScaleFactor;
			mdblRotationDegree = hwpDxf_Vars.pdblRotationDegree;
			madblNormal[0] = hwpDxf_Vars.padblNormal[0];
			madblNormal[1] = hwpDxf_Vars.padblNormal[1];
			madblNormal[2] = hwpDxf_Vars.padblNormal[2];
			mblnHasAttributes = hwpDxf_Vars.pblnHasAttributes;
			mcolClass = new OrderedDictionary();
			base.FriendLetDXFName = "INSERT";
			base.FriendLetObjectName = "AcDbBlockReference";
			base.FriendLetEntityType = Enums.AcEntityName.acBlockReference;
		}

		internal AcadSequenceEnd FriendAddAcadObjectSequenceEnd(double nvdblObjectID = -1.0, bool nvblnWithoutObjectID = false, ref string nrstrErrMsg = "")
		{
			AcadSequenceEnd dobjAcadSequenceEnd2;
			if (mblnHasAttributes && mobjAcadSequenceEnd == null)
			{
				dobjAcadSequenceEnd2 = new AcadSequenceEnd();
				if (nvdblObjectID == -1.0)
				{
					nvdblObjectID = base.Database.FriendGetNextObjectID;
				}
				AcadSequenceEnd acadSequenceEnd = dobjAcadSequenceEnd2;
				acadSequenceEnd.FriendLetNodeParentID = Conversions.ToInteger(Interaction.IIf(mlngImpNodeID == -1, base.NodeID, mlngImpNodeID));
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

		~AcadBlockReference()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				InternClear();
				if (mobjAcadAttributeReferenceDictionary != null)
				{
					mobjAcadAttributeReferenceDictionary.FriendQuit();
				}
				if (mobjAcadSequenceEnd != null)
				{
					mobjAcadSequenceEnd.FriendQuit();
				}
				base.FriendQuit();
				mobjAcadAttributeReferenceDictionary = null;
				mobjAcadSequenceEnd = null;
				hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "AcadBlockReference");
				mcolClass = null;
				mblnOpened = false;
			}
		}

		private void InternClear()
		{
			IEnumerator enumerator = default(IEnumerator);
			AcadEntity dobjAcadEntity2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjAcadEntity2 = (AcadEntity)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjAcadEntity2.ObjectID));
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			dobjAcadEntity2 = null;
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}

		internal bool FriendReplaceObjectID(ref AcadObject robjAcadObject, double vdblOldObjectID, double vdblNewObjectID)
		{
			bool FriendReplaceObjectID2 = default(bool);
			try
			{
				mcolClass.Remove("K" + Conversions.ToString(vdblOldObjectID));
				mcolClass.Add("K" + Conversions.ToString(vdblNewObjectID), robjAcadObject);
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				FriendReplaceObjectID2 = false;
				ProjectData.ClearProjectError();
				return FriendReplaceObjectID2;
			}
			string objectName = robjAcadObject.ObjectName;
			if (Operators.CompareString(objectName, "AcDbAttribute", TextCompare: false) == 0)
			{
				if (InternGetAttributeReferenceDictionary().FriendReplaceObjectID(vdblOldObjectID, vdblNewObjectID))
				{
					mblnHasAttributes = (InternGetAttributeReferenceDictionary().Count > 0);
					return true;
				}
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint("FriendReplaceObjectID: Unbekanntes Entity " + robjAcadObject.ObjectName);
			}
			return FriendReplaceObjectID2;
		}

		internal AcadAttributeReference FriendAddAcadObjectAttributeReference(double vdblObjectID, object vvarHeight, Enums.AcAttributeMode vnumMode, object vvarInsertionPoint, string vstrTag, string vstrValue, ref string nrstrErrMsg = "")
		{
			AcadAttributeReference dobjAcadAttributeReference3 = new AcadAttributeReference();
			AcadAttributeReference acadAttributeReference = dobjAcadAttributeReference3;
			acadAttributeReference.Height = RuntimeHelpers.GetObjectValue(vvarHeight);
			acadAttributeReference.FriendLetAttribFlags = vnumMode;
			acadAttributeReference.InsertionPoint = RuntimeHelpers.GetObjectValue(vvarInsertionPoint);
			acadAttributeReference.TagString = vstrTag;
			acadAttributeReference.TextString = vstrValue;
			acadAttributeReference.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadAttributeReference.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadAttributeReference.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadAttributeReference.FriendLetOwnerID = base.ObjectID;
			AcadAttributeReference acadAttributeReference2 = acadAttributeReference;
			AcadObject nrobjAcadObject = dobjAcadAttributeReference3;
			bool flag = acadAttributeReference2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadAttributeReference3 = (AcadAttributeReference)nrobjAcadObject;
			bool dblnValid = default(bool);
			if (flag)
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadAttributeReference.ObjectName + ": " + nrstrErrMsg);
			}
			acadAttributeReference = null;
			AcadAttributeReference FriendAddAcadObjectAttributeReference = default(AcadAttributeReference);
			if (dblnValid)
			{
				mcolClass.Add("K" + Conversions.ToString(dobjAcadAttributeReference3.ObjectID), dobjAcadAttributeReference3);
				InternGetAttributeReferenceDictionary().FriendAdd(ref dobjAcadAttributeReference3);
				mblnHasAttributes = (InternGetAttributeReferenceDictionary().Count > 0);
				FriendAddAcadObjectAttributeReference = dobjAcadAttributeReference3;
			}
			dobjAcadAttributeReference3 = null;
			return FriendAddAcadObjectAttributeReference;
		}

		internal object FriendGetAttribute(int vintIndex)
		{
			object FriendGetAttribute = default(object);
			try
			{
				FriendGetAttribute = RuntimeHelpers.GetObjectValue(mcolClass[checked(vintIndex - 1)]);
				return FriendGetAttribute;
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex = ex2;
				ProjectData.ClearProjectError();
				return FriendGetAttribute;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public AcadAttributeReference AddAttributeReference(object vvarHeight, Enums.AcAttributeMode vnumMode, object vvarInsertionPoint, string vstrTag, string vstrValue, string nvstrHandle = "")
		{
			double ddblObjectID = (Operators.CompareString(nvstrHandle, null, TextCompare: false) != 0) ? hwpDxf_Functions.BkDXF_HexToDbl(nvstrHandle) : base.Database.FriendGetNextObjectID;
			string dstrErrMsg = default(string);
			AcadAttributeReference dobjAcadAttributeReference2 = FriendAddAcadObjectAttributeReference(ddblObjectID, RuntimeHelpers.GetObjectValue(vvarHeight), vnumMode, RuntimeHelpers.GetObjectValue(vvarInsertionPoint), vstrTag, vstrValue, ref dstrErrMsg);
			AcadAttributeReference AddAttributeReference = default(AcadAttributeReference);
			if (dobjAcadAttributeReference2 == null)
			{
				Information.Err().Raise(50000, "AcadBlockReference", "Das Objekt konnte nicht hinzugefügt werden.\n" + dstrErrMsg);
			}
			else
			{
				AddAttributeReference = dobjAcadAttributeReference2;
			}
			dobjAcadAttributeReference2 = null;
			return AddAttributeReference;
		}

		private AcadAttributeRefDictionary InternGetAttributeReferenceDictionary()
		{
			if (mobjAcadAttributeReferenceDictionary == null)
			{
				mobjAcadAttributeReferenceDictionary = new AcadAttributeRefDictionary();
				mobjAcadAttributeReferenceDictionary.FriendLetNodeParentID = Conversions.ToInteger(Interaction.IIf(mlngImpNodeID == -1, base.NodeID, mlngImpNodeID));
				mobjAcadAttributeReferenceDictionary.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
				mobjAcadAttributeReferenceDictionary.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
				mobjAcadAttributeReferenceDictionary.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
				mobjAcadAttributeReferenceDictionary.FriendLetOwnerID = base.ObjectID;
			}
			return mobjAcadAttributeReferenceDictionary;
		}
	}
}
