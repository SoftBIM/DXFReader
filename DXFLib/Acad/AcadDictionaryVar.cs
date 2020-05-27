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
	public class AcadDictionaryVar : AcadObject
	{
		private const string cstrClassName = "AcadDictionaryVar";

		private bool mblnOpened;

		private string mstrName;

		private string mstrAlternateName;

		private int mlngObjectSchemaNumber;

		private object mvarValue;

		internal string FriendLetName
		{
			set
			{
				mstrName = value;
				if (Operators.CompareString(Strings.UCase(mstrName), "DIMASSOC", TextCompare: false) == 0)
				{
					mstrAlternateName = "DIMASO";
				}
				else
				{
					mstrAlternateName = mstrName;
				}
				base.FriendLetNodeText = mstrName;
			}
		}

		internal int FriendLetObjectSchemaNumber
		{
			set
			{
				mlngObjectSchemaNumber = value;
			}
		}

		internal object FriendLetValue
		{
			set
			{
				mvarValue = RuntimeHelpers.GetObjectValue(value);
			}
		}

		internal string FriendGetValueString
		{
			get
			{
				AcadSysVar dobjAcadSysVar = base.Document.FriendFindVariable(mstrAlternateName);
				if (dobjAcadSysVar != null)
				{
					return dobjAcadSysVar.FriendGetValueString;
				}
				return hwpDxf_SysVar.BkDXFSysVar_StringValue(Information.VarType(RuntimeHelpers.GetObjectValue(mvarValue)), RuntimeHelpers.GetObjectValue(mvarValue), nvblnCommaString: false);
			}
		}

		public string Name => mstrName;

		public int ObjectSchemaNumber => mlngObjectSchemaNumber;

		public object Value
		{
			get
			{
				AcadSysVar dobjAcadSysVar = base.Document.FriendFindVariable(mstrAlternateName);
				if (dobjAcadSysVar != null)
				{
					return RuntimeHelpers.GetObjectValue(dobjAcadSysVar.Value);
				}
				return RuntimeHelpers.GetObjectValue(mvarValue);
			}
		}

		public AcadDictionaryVar()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 101;
			base.FriendLetNodeName = "Wörterbuch-Variable";
			base.FriendLetNodeText = "Wörterbuch-Variable";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			mstrAlternateName = mstrName;
			mlngObjectSchemaNumber = hwpDxf_Vars.plngObjectSchemaNumber;
			mvarValue = null;
			base.FriendLetDXFName = "DICTIONARYVAR";
			base.FriendLetObjectName = "DictionaryVariables";
		}

		~AcadDictionaryVar()
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
	}
}
