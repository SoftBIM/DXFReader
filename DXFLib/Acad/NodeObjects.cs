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
	public class NodeObjects
	{
		private const string cstrClassName = "NodeObjects";

		private int mlngIndex;

		private OrderedDictionary mcolClass;

		private Dictionary<object, object> mobjDictIndizies;

		public int Count => mcolClass.Count;

		private void Class_Initialize_Renamed()
		{
			mcolClass = new OrderedDictionary();
			mobjDictIndizies = new Dictionary<object, object>();
		}

		public NodeObjects()
		{
			Class_Initialize_Renamed();
		}

		private void Class_Terminate_Renamed()
		{
			IEnumerator enumerator = default(IEnumerator);
			NodeObject dobjNodeObject2;
			try
			{
				enumerator = mcolClass.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					dobjNodeObject2 = (NodeObject)enumerator.Current;
					mcolClass.Remove("K" + Conversions.ToString(dobjNodeObject2.NodeID));
					mobjDictIndizies.Remove("K" + Conversions.ToString(dobjNodeObject2.NodeID));
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			hwpDxf_Functions.BkDXF_DebugClassNotEmpty(mcolClass, "NodeObjects");
			mcolClass = null;
			mobjDictIndizies = null;
			dobjNodeObject2 = null;
		}

		~NodeObjects()
		{
			Class_Terminate_Renamed();
			base.Finalize();
		}

		internal bool FriendGetItem(int vlngIndex, ref NodeObject robjNodeObject)
		{
			robjNodeObject = null;
			bool FriendGetItem = default(bool);
			NodeObject dobjNodeObject2 = default(NodeObject);
			if (mobjDictIndizies.ContainsKey("K" + Conversions.ToString(vlngIndex)))
			{
				bool dblnValid = false;
				try
				{
					dobjNodeObject2 = (NodeObject)mcolClass["K" + Conversions.ToString(vlngIndex)];
					dblnValid = true;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
				if (dblnValid)
				{
					robjNodeObject = dobjNodeObject2;
					FriendGetItem = true;
				}
			}
			dobjNodeObject2 = null;
			return FriendGetItem;
		}

		public int Add(ref object robjNodeObject)
		{
			checked
			{
				mlngIndex++;
				mcolClass.Add("K" + Conversions.ToString(mlngIndex), RuntimeHelpers.GetObjectValue(robjNodeObject));
				mobjDictIndizies.Add("K" + Conversions.ToString(mlngIndex), null);
				return mlngIndex;
			}
		}

		public object Item(int vlngIndex)
		{
			if (mobjDictIndizies.ContainsKey("K" + Conversions.ToString(vlngIndex)))
			{
				return RuntimeHelpers.GetObjectValue(mcolClass["K" + Conversions.ToString(vlngIndex)]);
			}
			object Item = default(object);
			return Item;
		}

		public void Remove(int vlngIndex)
		{
			if (mobjDictIndizies != null && mobjDictIndizies.ContainsKey("K" + Conversions.ToString(vlngIndex)))
			{
				bool dblnValid = false;
				try
				{
					mcolClass.Remove("K" + Conversions.ToString(vlngIndex));
					dblnValid = true;
				}
				catch (Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					Exception ex = ex2;
					ProjectData.ClearProjectError();
				}
				if (dblnValid)
				{
					mobjDictIndizies.Remove("K" + Conversions.ToString(vlngIndex));
				}
			}
		}

		public ICollection GetValues()
		{
			return mcolClass.Values;
		}
	}
}
