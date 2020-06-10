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
	public class AcadBlocks : AcadTable
	{
		private const string cstrClassName = "AcadBlocks";

		private bool mblnOpened;

		private AcadPaperSpace mobjAcadPaperSpace;

		private AcadModelSpace mobjAcadModelSpace;

		private AcadPaperSpace mobjAcadPaperSpace0;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				IEnumerator<AcadBlock> enumerator = default(IEnumerator<AcadBlock>);
				AcadBlock dobjAcadBlock2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadBlock2 = (AcadBlock)enumerator.Current;
						dobjAcadBlock2.FriendLetDatabaseIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadBlock2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				IEnumerator<AcadBlock> enumerator = default(IEnumerator<AcadBlock>);
				AcadBlock dobjAcadBlock2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadBlock2 = (AcadBlock)enumerator.Current;
						dobjAcadBlock2.FriendLetDocumentIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadBlock2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				IEnumerator<AcadBlock> enumerator = default(IEnumerator<AcadBlock>);
				AcadBlock dobjAcadBlock2;
				try
				{
					enumerator = GetValues().GetEnumerator();
					while (enumerator.MoveNext())
					{
						dobjAcadBlock2 = (AcadBlock)enumerator.Current;
						dobjAcadBlock2.FriendLetApplicationIndex = value;
					}
				}
				finally
				{
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
				}
				dobjAcadBlock2 = null;
			}
		}

		public AcadPaperSpace PaperSpace
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlockPaperSpace(ref nrstrErrMsg, - 1.0);
			}
		}

		public AcadModelSpace ModelSpace
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlockModelSpace(ref nrstrErrMsg, -1.0);
			}
		}

		public AcadPaperSpace PaperSpace0
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectBlockPaperSpace0(ref nrstrErrMsg, - 1.0);
			}
		}

		public AcadBlocks()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 147;
			base.FriendLetNodeImageDisabledID = 148;
			base.FriendLetNodeName = "Tabelle Block-Container";
			base.FriendLetNodeText = "Tabelle Block-Container";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			base.FriendLetDXFName = "BLOCK_RECORD";
			base.FriendLetObjectName = "AcDbBlockTable";
			base.FriendLetSubordinateObjectName = "AcDbBlockTable";
		}

		internal AcadPaperSpace FriendAddAcadObjectBlockPaperSpace(ref string nrstrErrMsg, double nvdblObjectID = -1.0)
		{
			AcadLayout dobjAcadLayout2;
			AcadBlock dobjAcadBlock3;
			if (mobjAcadPaperSpace == null)
			{
				string dstrBlockName = "*Paper_Space";
				dobjAcadBlock3 = (AcadBlock)FriendGetItem(dstrBlockName);
				if (dobjAcadBlock3 == null)
				{
					dobjAcadBlock3 = FriendAddAcadObject(ref nrstrErrMsg, dstrBlockName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)));
					if (dobjAcadBlock3 == null)
					{
						goto IL_00c7;
					}
					dobjAcadLayout2 = base.Database.Layouts.Layout1;
					AcadLayout acadLayout = dobjAcadLayout2;
					acadLayout.TabOrder = 1;
					acadLayout.FriendLetPaperSpaceObjectID = dobjAcadBlock3.ObjectID;
					acadLayout = null;
					AcadBlock acadBlock = dobjAcadBlock3;
					acadBlock.FriendLetLayoutObjectID = dobjAcadLayout2.ObjectID;
					acadBlock = null;
				}
			}
			goto IL_00c7;
		IL_00c7:
			dobjAcadLayout2 = null;
			dobjAcadBlock3 = null;
			return mobjAcadPaperSpace;
		}

		internal AcadModelSpace FriendAddAcadObjectBlockModelSpace(ref string nrstrErrMsg, double nvdblObjectID = -1.0)
		{
			AcadLayout dobjAcadLayout2;
			AcadBlock dobjAcadBlock3;
			if (mobjAcadModelSpace == null)
			{
				string dstrBlockName = "*Model_Space";
				dobjAcadBlock3 = (AcadBlock)FriendGetItem(dstrBlockName);
				if (dobjAcadBlock3 == null)
				{
					dobjAcadBlock3 = FriendAddAcadObject(ref nrstrErrMsg, dstrBlockName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)));
					if (dobjAcadBlock3 == null)
					{
						goto IL_00c7;
					}
					dobjAcadLayout2 = base.Database.Layouts.LayoutModel;
					AcadLayout acadLayout = dobjAcadLayout2;
					acadLayout.TabOrder = 0;
					acadLayout.FriendLetPaperSpaceObjectID = dobjAcadBlock3.ObjectID;
					acadLayout = null;
					AcadBlock acadBlock = dobjAcadBlock3;
					acadBlock.FriendLetLayoutObjectID = dobjAcadLayout2.ObjectID;
					acadBlock = null;
				}
			}
			goto IL_00c7;
		IL_00c7:
			dobjAcadLayout2 = null;
			dobjAcadBlock3 = null;
			return mobjAcadModelSpace;
		}

		internal AcadPaperSpace FriendAddAcadObjectBlockPaperSpace0(ref string nrstrErrMsg, double nvdblObjectID = -1.0)
		{
			AcadLayout dobjAcadLayout2;
			AcadBlock dobjAcadBlock3;
			if (mobjAcadPaperSpace0 == null)
			{
				string dstrBlockName = "*Paper_Space0";
				dobjAcadBlock3 = (AcadBlock)FriendGetItem(dstrBlockName);
				if (dobjAcadBlock3 == null)
				{
					dobjAcadBlock3 = FriendAddAcadObject(ref nrstrErrMsg, dstrBlockName, Conversions.ToDouble(Interaction.IIf(nvdblObjectID == -1.0, base.Database.FriendGetNextObjectID, nvdblObjectID)));
					if (dobjAcadBlock3 == null)
					{
						goto IL_00c7;
					}
					dobjAcadLayout2 = base.Database.Layouts.Layout2;
					AcadLayout acadLayout = dobjAcadLayout2;
					acadLayout.TabOrder = 2;
					acadLayout.FriendLetPaperSpaceObjectID = dobjAcadBlock3.ObjectID;
					acadLayout = null;
					AcadBlock acadBlock = dobjAcadBlock3;
					acadBlock.FriendLetLayoutObjectID = dobjAcadLayout2.ObjectID;
					acadBlock = null;
				}
			}
			goto IL_00c7;
		IL_00c7:
			dobjAcadLayout2 = null;
			dobjAcadBlock3 = null;
			return mobjAcadPaperSpace0;
		}

		~AcadBlocks()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadPaperSpace = null;
				mobjAcadModelSpace = null;
				mobjAcadPaperSpace0 = null;
				mblnOpened = false;
			}
		}

		internal AcadBlock FriendAddAcadObject(ref string nrstrErrMsg, string vstrName, double nvdblObjectID = -1.0)
		{
			AcadBlock dobjAcadBlock3 = new AcadBlock();
			if (nvdblObjectID == -1.0)
			{
				nvdblObjectID = base.Database.FriendGetNextObjectID;
			}
			AcadBlock acadBlock = dobjAcadBlock3;
			acadBlock.Name = vstrName;
			acadBlock.FriendLetNodeParentID = base.NodeID;
			acadBlock.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
			acadBlock.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
			acadBlock.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
			acadBlock.FriendLetOwnerID = base.ObjectID;
			AcadBlock acadBlock2 = acadBlock;
			double vdblObjectID = nvdblObjectID;
			AcadObject nrobjAcadObject = dobjAcadBlock3;
			bool flag = acadBlock2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
			dobjAcadBlock3 = (AcadBlock)nrobjAcadObject;
			bool dblnValid = default(bool);
			AcadObject dobjAcadObject5;
			if (flag)
			{
				dblnValid = true;
				if (!hwpDxf_Vars.pblnReadDocument)
				{
					if (dblnValid)
					{
						dobjAcadObject5 = acadBlock.FriendAddAcadObjectBlockBegin(ref nrstrErrMsg , - 1.0, nvblnWithoutObjectID: false);
						if (dobjAcadObject5 == null)
						{
							dblnValid = false;
						}
						dobjAcadObject5 = null;
					}
					if (dblnValid)
					{
						dobjAcadObject5 = acadBlock.FriendAddAcadObjectBlockEnd(ref nrstrErrMsg , - 1.0, nvblnWithoutObjectID: false);
						if (dobjAcadObject5 == null)
						{
							dblnValid = false;
						}
						dobjAcadObject5 = null;
					}
					if (dblnValid)
					{
						acadBlock.FriendNewEntityDictionaries();
					}
				}
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint(acadBlock.ObjectName + ": " + nrstrErrMsg);
			}
			acadBlock = null;
			AcadBlock FriendAddAcadObject = default(AcadBlock);
			if (dblnValid)
			{
				AcadTableRecord robjAcadTableRecord = dobjAcadBlock3;
				Add(ref robjAcadTableRecord, vstrName);
				dobjAcadBlock3 = (AcadBlock)robjAcadTableRecord;
				string left = Strings.UCase(vstrName);
				if (Operators.CompareString(left, Strings.UCase("*Model_Space"), TextCompare: false) == 0)
				{
					if (mobjAcadModelSpace == null)
					{
						mobjAcadModelSpace = new AcadModelSpace();
						mobjAcadModelSpace.FriendInit(ref dobjAcadBlock3);
					}
				}
				else if (Operators.CompareString(left, Strings.UCase("*Paper_Space"), TextCompare: false) == 0)
				{
					if (mobjAcadPaperSpace == null)
					{
						if (!hwpDxf_Vars.pblnReadDocument)
						{
							dobjAcadBlock3.BlockBegin.FriendLetIsPaperSpace = true;
							dobjAcadBlock3.BlockEnd.FriendLetIsPaperSpace = true;
						}
						mobjAcadPaperSpace = new AcadPaperSpace();
						mobjAcadPaperSpace.FriendInit(ref dobjAcadBlock3);
					}
				}
				else if (Operators.CompareString(left, Strings.UCase("*Paper_Space0"), TextCompare: false) == 0 && mobjAcadPaperSpace0 == null)
				{
					mobjAcadPaperSpace0 = new AcadPaperSpace();
					mobjAcadPaperSpace0.FriendInit(ref dobjAcadBlock3);
				}
				FriendAddAcadObject = dobjAcadBlock3;
			}
			dobjAcadObject5 = null;
			dobjAcadBlock3 = null;
			return FriendAddAcadObject;
		}
	}
}
