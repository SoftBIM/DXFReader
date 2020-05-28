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
	public class AcadLineTypeDash : NodeObject
	{
		private const string cstrClassName = "AcadLineTypeDash";

		private const int clngShapeIsUcsOriented = 1;

		private bool mblnOpened;

		private int mlngApplicationIndex;

		private int mlngDocumentIndex;

		private int mlngDatabaseIndex;

		private int mlngTableIndex;

		private int mlngIndex;

		private string mstrDashTypeString;

		private object mdecLength;

		private double mdblLength;

		private hwpDxf_Enums.DASH_TYPE mnumDashType;

		private bool mblnShapeIsUcsOriented;

		private int mlngShapeNumber;

		private int mlngShapeStyle;

		private object mdecShapeScale;

		private double mdblShapeScale;

		private object mdecShapeRotationDegree;

		private double mdblShapeRotationDegree;

		private object mdecShapeOffsetX;

		private double mdblShapeOffsetX;

		private object mdecShapeOffsetY;

		private double mdblShapeOffsetY;

		private string mstrText;

		private int mlngFlags74;

		private bool mblnFriendLetFlags;

		internal int FriendGetTableIndex => mlngTableIndex;

		internal int FriendLetTableIndex
		{
			set
			{
				mlngTableIndex = value;
			}
		}

		internal int FriendGetDatabaseIndex => mlngDatabaseIndex;

		internal int FriendLetDatabaseIndex
		{
			set
			{
				mlngDatabaseIndex = value;
			}
		}

		internal int FriendGetDocumentIndex => mlngDocumentIndex;

		internal int FriendLetDocumentIndex
		{
			set
			{
				mlngDocumentIndex = value;
			}
		}

		internal int FriendGetApplicationIndex => mlngApplicationIndex;

		internal int FriendLetApplicationIndex
		{
			set
			{
				mlngApplicationIndex = value;
			}
		}

		internal string FriendGetDashTypeString => mstrDashTypeString;

		internal int FriendLetIndex
		{
			set
			{
				mlngIndex = value;
			}
		}

		internal object FriendLetLength
		{
			set
			{
				object dvarLength2 = RuntimeHelpers.GetObjectValue(value);
				ref object rvarValueDec = ref mdecLength;
				ref double reference = ref mdblLength;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				bool num = hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
				if (num)
				{
					bool flag = false;
					AcadLineTypeDashes dashes = Linetype.Dashes;
					object vvarOldLength = Math.Abs(mdblLength);
					Type typeFromHandle = typeof(Math);
					object[] obj = new object[1]
					{
					dvarLength2
					};
					object[] array = obj;
					bool[] obj2 = new bool[1]
					{
					true
					};
					bool[] array2 = obj2;
					object obj3 = NewLateBinding.LateGet(null, typeFromHandle, "Abs", obj, null, null, obj2);
					if (array2[0])
					{
						dvarLength2 = RuntimeHelpers.GetObjectValue(array[0]);
					}
					dashes.FriendChangePatternLength(vvarOldLength, RuntimeHelpers.GetObjectValue(obj3));
				}
			}
		}

		internal hwpDxf_Enums.DASH_TYPE FriendLetDashType
		{
			set
			{
				mnumDashType = value;
				InterSetDashTypeString();
				InternCalcFlags74();
			}
		}

		internal bool FriendLetShapeIsUcsOriented
		{
			set
			{
				mblnShapeIsUcsOriented = value;
				InternCalcFlags74();
			}
		}

		internal int FriendLetShapeNumber
		{
			set
			{
				mlngShapeNumber = value;
			}
		}

		internal int FriendLetShapeStyle
		{
			set
			{
				mlngShapeStyle = value;
			}
		}

		internal object FriendLetShapeScale
		{
			set
			{
				ref object rvarValueDec = ref mdecShapeScale;
				ref double reference = ref mdblShapeScale;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetShapeRotationDegree
		{
			set
			{
				ref object rvarValueDec = ref mdecShapeRotationDegree;
				ref double reference = ref mdblShapeRotationDegree;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetShapeRotation
		{
			set
			{
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				if (hwpDxf_Functions.BkDXF_CheckVariantForValueReal(objectValue, ref nrstrErrMsg))
				{
					bool flag = false;
					mdblShapeRotationDegree = Conversions.ToDouble(hwpDxf_Vars.pobjUtilMath.AngRad2Deg(RuntimeHelpers.GetObjectValue(value)));
				}
			}
		}

		internal object FriendLetShapeOffsetX
		{
			set
			{
				ref object rvarValueDec = ref mdecShapeOffsetX;
				ref double reference = ref mdblShapeOffsetX;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal object FriendLetShapeOffsetY
		{
			set
			{
				ref object rvarValueDec = ref mdecShapeOffsetY;
				ref double reference = ref mdblShapeOffsetY;
				object rvarValueDbl = reference;
				object objectValue = RuntimeHelpers.GetObjectValue(value);
				string nrstrErrMsg = "";
				hwpDxf_Functions.BkDXF_SetValueReal(ref rvarValueDec, ref rvarValueDbl, objectValue, ref nrstrErrMsg);
				reference = Conversions.ToDouble(rvarValueDbl);
			}
		}

		internal string FriendLetText
		{
			set
			{
				mstrText = value;
			}
		}

		internal int FriendLetFlags74
		{
			set
			{
				mblnFriendLetFlags = true;
				mlngFlags74 = value;
				if ((2 & mlngFlags74) == 2)
				{
					FriendLetDashType = hwpDxf_Enums.DASH_TYPE.dtText;
				}
				else if ((4 & mlngFlags74) == 4)
				{
					FriendLetDashType = hwpDxf_Enums.DASH_TYPE.dtSymbol;
				}
				else
				{
					FriendLetDashType = hwpDxf_Enums.DASH_TYPE.dtStandard;
				}
				FriendLetShapeIsUcsOriented = ((1 & mlngFlags74) == 1);
				InterSetDashTypeString();
				mblnFriendLetFlags = false;
			}
		}

		public AcadLineType Linetype
		{
			get
			{
				if (mlngDatabaseIndex > -1 && mlngTableIndex > -1)
				{
					return (AcadLineType)hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex).Linetypes.Item(mlngTableIndex);
				}
				AcadLineType Linetype = default(AcadLineType);
				return Linetype;
			}
		}

		public AcadDatabase Database
		{
			get
			{
				if (mlngDatabaseIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadDatabases.Item(mlngDatabaseIndex);
				}
				AcadDatabase Database = default(AcadDatabase);
				return Database;
			}
		}

		public AcadDocument Document
		{
			get
			{
				if (mlngApplicationIndex > -1 && mlngDocumentIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex).Documents.Item(mlngDocumentIndex);
				}
				AcadDocument Document = default(AcadDocument);
				return Document;
			}
		}

		public AcadApplication Application
		{
			get
			{
				if (mlngApplicationIndex > -1)
				{
					return hwpDxf_Vars.pobjAcadApplications.Item(mlngApplicationIndex);
				}
				AcadApplication Application = default(AcadApplication);
				return Application;
			}
		}

		public int Index => mlngIndex;

		public object Length => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecLength), mdblLength));

		public int DashType => (int)mnumDashType;

		public bool ShapeIsUcsOriented => mblnShapeIsUcsOriented;

		public int ShapeNumber => mlngShapeNumber;

		public int ShapeStyle => mlngShapeStyle;

		public object ShapeScale => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecShapeScale), mdblShapeScale));

		public object ShapeRotationDegree => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecShapeRotationDegree), mdblShapeRotationDegree));

		public object ShapeRotation => RuntimeHelpers.GetObjectValue(hwpDxf_Vars.pobjUtilMath.AngDeg2Rad(RuntimeHelpers.GetObjectValue(ShapeRotationDegree)));

		public object ShapeOffsetX => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecShapeOffsetX), mdblShapeOffsetX));

		public object ShapeOffsetY => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecShapeOffsetY), mdblShapeOffsetY));

		public object ShapeOffset => new object[2]
		{
		mdblShapeOffsetX,
		mdblShapeOffsetY
		};

		public string Text => mstrText;

		public int Flags74 => mlngFlags74;

		public AcadLineTypeDash()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 153;
			base.FriendLetNodeImageDisabledID = 154;
			base.FriendLetNodeName = "Linientypelement";
			base.FriendLetNodeText = "Linientypelement";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblLength = hwpDxf_Vars.pdblLength;
			mdblShapeScale = hwpDxf_Vars.pdblShapeScale;
			mdblShapeRotationDegree = hwpDxf_Vars.pdblShapeRotationDegree;
			mdblShapeOffsetX = hwpDxf_Vars.pdblShapeOffsetX;
			mdblShapeOffsetY = hwpDxf_Vars.pdblShapeOffsetY;
			mnumDashType = hwpDxf_Vars.pnumDashType;
			mblnShapeIsUcsOriented = hwpDxf_Vars.pblnShapeIsUcsOriented;
			mlngShapeNumber = hwpDxf_Vars.plngShapeNumber;
			mlngShapeStyle = hwpDxf_Vars.plngShapeStyle;
			mstrText = mstrText;
			InterSetDashTypeString();
			mblnFriendLetFlags = false;
			InternCalcFlags74();
			mlngApplicationIndex = -1;
			mlngDocumentIndex = -1;
			mlngDatabaseIndex = -1;
			mlngTableIndex = -1;
			mlngIndex = -1;
		}

		~AcadLineTypeDash()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mblnOpened = false;
			}
		}

		private void InterSetDashTypeString()
		{
			switch (mnumDashType)
			{
				case (hwpDxf_Enums.DASH_TYPE)1:
				case (hwpDxf_Enums.DASH_TYPE)3:
					break;
				case hwpDxf_Enums.DASH_TYPE.dtStandard:
					mstrDashTypeString = "Standard";
					break;
				case hwpDxf_Enums.DASH_TYPE.dtSymbol:
					mstrDashTypeString = "Symbol";
					break;
				case hwpDxf_Enums.DASH_TYPE.dtText:
					mstrDashTypeString = "Text";
					break;
			}
		}

		private void InternCalcFlags74()
		{
			if (!mblnFriendLetFlags)
			{
				mlngFlags74 = DashType;
				mlngFlags74 = Conversions.ToInteger(Operators.OrObject(mlngFlags74, Interaction.IIf(ShapeIsUcsOriented, 1, 0)));
			}
		}
	}

}
