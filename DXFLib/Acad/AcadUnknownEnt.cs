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
	public class AcadUnknownEnt : AcadEntity
	{
		private const string cstrClassName = "AcadUnknownEnt";

		private bool mblnOpened;

		private Dictionary<object, object> mobjDictCodes;

		private Dictionary<object, object> mobjDictValues;

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

		public AcadUnknownEnt()
		{
			mblnOpened = true;
			base.FriendLetNodeImageEnabledID = 305;
			base.FriendLetNodeImageDisabledID = 306;
			base.FriendLetNodeName = "Unbekanntes Zeichnungsobjekt";
			base.FriendLetNodeText = "Unbekanntes Zeichnungsobjekt";
			object robjObject = this;
			FriendAddToCollection(ref robjObject);
			mobjDictCodes = new Dictionary<object, object>();
			mobjDictValues = new Dictionary<object, object>();
			base.FriendLetDXFName = "UNBEKANNT";
			base.FriendLetObjectName = "AcDbUnknownEnt";
			base.FriendLetEntityType = Enums.AcEntityName.acUnknownEnt;
		}

		~AcadUnknownEnt()
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
	}

}
