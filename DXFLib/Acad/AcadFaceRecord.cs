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
	public class AcadFaceRecord : AcadEntity
	{
		private const string cstrClassName = "AcadFaceRecord";

		private const int clngIsFaceRecord = 128;

		private bool mblnOpened;

		private object mdecCode10;

		private double mdblCode10;

		private object mdecCode20;

		private double mdblCode20;

		private object mdecCode30;

		private double mdblCode30;

		private int mlngFlags70;

		private bool mblnIsFaceRecord;

		private int mlngVertex1;

		private int mlngVertex2;

		private int mlngVertex3;

		private int mlngVertex4;

		internal object FriendGetCode10 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode10), mdblCode10));

		internal object FriendGetCode20 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode20), mdblCode20));

		internal object FriendGetCode30 => RuntimeHelpers.GetObjectValue(Interaction.IIf(Expression: false, RuntimeHelpers.GetObjectValue(mdecCode30), mdblCode30));

		internal int FriendLetFlags70
		{
			set
			{
				mlngFlags70 = value;
				mblnIsFaceRecord = ((0x80 & mlngFlags70) == 128);
			}
		}

		internal bool FriendGetIsFaceRecord => mblnIsFaceRecord;

		internal int FriendLetVertex1
		{
			set
			{
				mlngVertex1 = value;
			}
		}

		internal int FriendLetVertex2
		{
			set
			{
				mlngVertex2 = value;
			}
		}

		internal int FriendLetVertex3
		{
			set
			{
				mlngVertex3 = value;
			}
		}

		internal int FriendLetVertex4
		{
			set
			{
				mlngVertex4 = value;
			}
		}

		public int Flags70 => mlngFlags70;

		public int Vertex1 => mlngVertex1;

		public int Vertex2 => mlngVertex2;

		public int Vertex3 => mlngVertex3;

		public int Vertex4 => mlngVertex4;

		public AcadFaceRecord()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 341;
			base.FriendLetNodeImageDisabledID = 342;
			base.FriendLetNodeName = "Vielflächennetz-Fläche";
			base.FriendLetNodeText = "A Vielflächennetz-Fläche";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			bool flag = false;
			mdblCode10 = hwpDxf_Vars.pdblCode10;
			mdblCode20 = hwpDxf_Vars.pdblCode20;
			mdblCode30 = hwpDxf_Vars.pdblCode30;
			mblnIsFaceRecord = hwpDxf_Vars.pblnIsFaceRecord;
			InternCalcFlags70();
			base.FriendLetDXFName = "VERTEX";
			base.FriendLetObjectName = "AcDbFaceRecord";
			base.FriendLetEntityType = Enums.AcEntityName.acFaceRecord;
		}

		~AcadFaceRecord()
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

		private void InternCalcFlags70()
		{
			mlngFlags70 = 0;
			mlngFlags70 = Conversions.ToInteger(Operators.OrObject(mlngFlags70, Interaction.IIf(FriendGetIsFaceRecord, 128, 0)));
		}
	}
}
