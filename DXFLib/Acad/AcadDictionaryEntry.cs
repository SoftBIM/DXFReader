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
	class AcadDictionaryEntry : AcadObject
	{
		private const string cstrClassName = "AcadDictionaryEntry";

		private bool mblnOpened;

		private string mstrName;

		private Dictionary<object, object> mobjDictCodes;

		private Dictionary<object, object> mobjDictValues;

		internal string FriendLetName
		{
			set
			{
				mstrName = value;
			}
		}

		internal Dictionary<object, object> FriendSetDictCodes
		{
			set
			{
				mobjDictCodes = value;
			}
		}

		internal Dictionary<object, object> FriendGetDictCodes => mobjDictCodes;

		internal object FriendGetCodes => RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictCodes.Values));

		internal Dictionary<object, object> FriendSetDictValues
		{
			set
			{
				mobjDictValues = value;
			}
		}

		internal Dictionary<object, object> FriendGetDictValues => mobjDictValues;

		internal object FriendGetValues => RuntimeHelpers.GetObjectValue(hwpDxf_Functions.BkDXF_ValueCollectionToArray(mobjDictValues.Values));

		public string Name => mstrName;

		public AcadDictionaryEntry()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 101;
			base.FriendLetNodeImageDisabledID = 101;
			base.FriendLetNodeName = "Wörtebucheintrag";
			base.FriendLetNodeText = "Wörtebucheintrag";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mstrName = hwpDxf_Vars.pstrName;
			mobjDictCodes = new Dictionary<object, object>();
			mobjDictValues = new Dictionary<object, object>();
			base.FriendLetDXFName = "DICTIONARYENTRY";
			base.FriendLetObjectName = "DictionaryEntry";
		}

		~AcadDictionaryEntry()
		{
			FriendQuit();
			base.Finalize();
		}

		internal new void FriendQuit()
		{
			if (mblnOpened)
			{
				base.FriendQuit();
				mobjDictCodes = null;
				mobjDictValues = null;
				mblnOpened = false;
			}
		}

		internal void FriendAddProperty(int vlngCode, object vvarValue)
		{
		}
	}
}
