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
	public class AcadDictionaryWithDefault : AcadDictionary
	{
		private const string cstrClassName = "AcadDictionaryWithDefault";

		private bool mblnOpened;

		private double mdblDefaultID;

		private AcadPlaceholder mobjAcadPlaceholderNormal;

		internal override int FriendLetDatabaseIndex
		{
			set
			{
				base.FriendLetDatabaseIndex = value;
				AcadPlaceholder dobjAcadPlaceholder2;
				AcadObject dobjAcadObject2;
				if (Operators.CompareString(base.Name, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
				{
					IEnumerator enumerator = default(IEnumerator);
					try
					{
						enumerator = GetValues().GetEnumerator();
						while (enumerator.MoveNext())
						{
							dobjAcadPlaceholder2 = (AcadPlaceholder)enumerator.Current;
							dobjAcadPlaceholder2.FriendLetDatabaseIndex = value;
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator2 = default(IEnumerator);
					try
					{
						enumerator2 = GetValues().GetEnumerator();
						while (enumerator2.MoveNext())
						{
							dobjAcadObject2 = (AcadObject)enumerator2.Current;
							hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref dobjAcadObject2, value);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
				}
				dobjAcadPlaceholder2 = null;
				dobjAcadObject2 = null;
			}
		}

		internal override int FriendLetDocumentIndex
		{
			set
			{
				base.FriendLetDocumentIndex = value;
				AcadPlaceholder dobjAcadPlaceholder2;
				AcadObject dobjAcadObject2;
				if (Operators.CompareString(base.Name, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
				{
					IEnumerator enumerator = default(IEnumerator);
					try
					{
						enumerator = GetValues().GetEnumerator();
						while (enumerator.MoveNext())
						{
							dobjAcadPlaceholder2 = (AcadPlaceholder)enumerator.Current;
							dobjAcadPlaceholder2.FriendLetDocumentIndex = value;
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator2 = default(IEnumerator);
					try
					{
						enumerator2 = GetValues().GetEnumerator();
						while (enumerator2.MoveNext())
						{
							dobjAcadObject2 = (AcadObject)enumerator2.Current;
							hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref dobjAcadObject2, value);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
				}
				dobjAcadPlaceholder2 = null;
				dobjAcadObject2 = null;
			}
		}

		internal override int FriendLetApplicationIndex
		{
			set
			{
				base.FriendLetApplicationIndex = value;
				AcadPlaceholder dobjAcadPlaceholder2;
				AcadObject dobjAcadObject2;
				if (Operators.CompareString(base.Name, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
				{
					IEnumerator enumerator = default(IEnumerator);
					try
					{
						enumerator = GetValues().GetEnumerator();
						while (enumerator.MoveNext())
						{
							dobjAcadPlaceholder2 = (AcadPlaceholder)enumerator.Current;
							dobjAcadPlaceholder2.FriendLetApplicationIndex = value;
						}
					}
					finally
					{
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				else
				{
					IEnumerator enumerator2 = default(IEnumerator);
					try
					{
						enumerator2 = GetValues().GetEnumerator();
						while (enumerator2.MoveNext())
						{
							dobjAcadObject2 = (AcadObject)enumerator2.Current;
							hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref dobjAcadObject2, value);
						}
					}
					finally
					{
						if (enumerator2 is IDisposable)
						{
							(enumerator2 as IDisposable).Dispose();
						}
					}
				}
				dobjAcadPlaceholder2 = null;
				dobjAcadObject2 = null;
			}
		}

		internal double FriendLetDefaultID
		{
			set
			{
				mdblDefaultID = value;
			}
		}

		public AcadPlaceholder PlaceholderNormal
		{
			get
			{
				string nrstrErrMsg = "";
				return FriendAddAcadObjectPlaceholderNormal(-1.0, ref nrstrErrMsg);
			}
		}

		public int DefaultID => checked((int)Math.Round(mdblDefaultID));

		public AcadDictionaryWithDefault()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 213;
			base.FriendLetNodeImageDisabledID = 214;
			base.FriendLetNodeName = "Wörterbuch mit Vorgabe";
			base.FriendLetNodeText = "Wörterbuch mit Vorgabe";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mdblDefaultID = -1.0;
			base.FriendLetDXFName = "ACDBDICTIONARYWDFLT";
			base.FriendLetObjectName = "AcDbDictionaryWithDefault";
		}

		internal AcadPlaceholder FriendAddAcadObjectPlaceholderNormal(double nvdblObjectID = -1.0, ref string nrstrErrMsg = "")
		{
			if (Operators.CompareString(base.Name, "ACAD_PLOTSTYLENAME", TextCompare: false) == 0)
			{
				if (mobjAcadPlaceholderNormal == null)
				{
					string dstrPlaceholderName = "Normal";
					AcadPlaceholder dobjAcadPlaceholderNormal2 = (AcadPlaceholder)FriendGetItem(dstrPlaceholderName);
					bool dblnValid = default(bool);
					if (dobjAcadPlaceholderNormal2 != null)
					{
						dblnValid = true;
					}
					else
					{
						base.Database.Classes.FriendAddAcDbPlaceholder();
						dobjAcadPlaceholderNormal2 = new AcadPlaceholder();
						if (nvdblObjectID == -1.0)
						{
							nvdblObjectID = base.Database.FriendGetNextObjectID;
						}
						AcadPlaceholder acadPlaceholder = dobjAcadPlaceholderNormal2;
						acadPlaceholder.FriendLetName = dstrPlaceholderName;
						acadPlaceholder.FriendLetNodeParentID = base.NodeID;
						acadPlaceholder.FriendLetApplicationIndex = base.FriendGetApplicationIndex;
						acadPlaceholder.FriendLetDocumentIndex = base.FriendGetDocumentIndex;
						acadPlaceholder.FriendLetDatabaseIndex = base.FriendGetDatabaseIndex;
						acadPlaceholder.FriendLetOwnerID = base.ObjectID;
						AcadPlaceholder acadPlaceholder2 = acadPlaceholder;
						double vdblObjectID = nvdblObjectID;
						AcadObject nrobjAcadObject = dobjAcadPlaceholderNormal2;
						bool flag = acadPlaceholder2.FriendSetObjectID(vdblObjectID, ref nrobjAcadObject, ref nrstrErrMsg);
						dobjAcadPlaceholderNormal2 = (AcadPlaceholder)nrobjAcadObject;
						if (flag)
						{
							acadPlaceholder.FriendAddReactorsID(base.ObjectID, 330);
							dblnValid = true;
						}
						else
						{
							hwpDxf_Functions.BkDXF_DebugPrint(acadPlaceholder.ObjectName + ": " + nrstrErrMsg);
						}
						acadPlaceholder = null;
					}
					if (dblnValid)
					{
						mobjAcadPlaceholderNormal = dobjAcadPlaceholderNormal2;
						FriendAddItem(mobjAcadPlaceholderNormal.Name, mobjAcadPlaceholderNormal);
						FriendLetDefaultID = mobjAcadPlaceholderNormal.ObjectID;
					}
				}
				return mobjAcadPlaceholderNormal;
			}
			AcadPlaceholder FriendAddAcadObjectPlaceholderNormal = default(AcadPlaceholder);
			return FriendAddAcadObjectPlaceholderNormal;
		}

		~AcadDictionaryWithDefault()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjAcadPlaceholderNormal = null;
				mblnOpened = false;
			}
		}

		internal new AcadObject FriendAdd(string vstrName, double vdblObjectID, ref AcadObject robjAcadObject)
		{
			hwpDxf_AcadObject.BkAcadObject_LetNodeParentID(ref robjAcadObject, base.NodeID);
			hwpDxf_AcadObject.BkAcadObject_LetApplicationIndex(ref robjAcadObject, base.FriendGetApplicationIndex);
			hwpDxf_AcadObject.BkAcadObject_LetDocumentIndex(ref robjAcadObject, base.FriendGetDocumentIndex);
			hwpDxf_AcadObject.BkAcadObject_LetDatabaseIndex(ref robjAcadObject, base.FriendGetDatabaseIndex);
			hwpDxf_AcadObject.BkAcadObject_LetOwnerID(ref robjAcadObject, base.ObjectID);
			string dstrErrMsg = default(string);
			bool dblnValid = default(bool);
			if (hwpDxf_AcadObject.BkAcadObject_SetObjectID(ref robjAcadObject, vdblObjectID, ref dstrErrMsg))
			{
				dblnValid = true;
			}
			else
			{
				hwpDxf_Functions.BkDXF_DebugPrint("DictWithDefault FriendAdd: " + robjAcadObject.ObjectName + ": " + dstrErrMsg);
			}
			if (dblnValid && FriendAddItem(vstrName, robjAcadObject))
			{
				return robjAcadObject;
			}
			AcadObject FriendAdd = default(AcadObject);
			return FriendAdd;
		}
	}
}
