using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using DXFLib.DXF;
using System.Drawing;
using System.Resources;

namespace DXFLib.Acad
{
	public class NodeObject
	{
		private const string cstrClassName = "NodeObject";

		private bool mblnOpened;

		private int mlngNodeImageEnabledID;

		private int mlngNodeImageDisabledID;

		private int mlngNodeID;

		private string mstrNodeName;

		private int mlngNodeParentID;

		private string mstrNodeText;

		internal int FriendLetNodeID
		{
			set
			{
				mlngNodeID = value;
			}
		}

		internal int FriendLetNodeImageEnabledID
		{
			set
			{
				mlngNodeImageEnabledID = value;
			}
		}

		internal int FriendLetNodeImageDisabledID
		{
			set
			{
				mlngNodeImageDisabledID = value;
			}
		}

		internal string FriendLetNodeName
		{
			set
			{
				mstrNodeName = value;
			}
		}

		internal int FriendLetNodeParentID
		{
			set
			{
				mlngNodeParentID = value;
			}
		}

		internal string FriendLetNodeText
		{
			set
			{
				mstrNodeText = value;
			}
		}

		public int NodeImageEnabledID => mlngNodeImageEnabledID;

		public int NodeImageDisabledID => mlngNodeImageDisabledID;

		public int NodeID => mlngNodeID;

		public bool NodeHasParent => mlngNodeParentID > -1;

		public string NodeKey => "K" + Conversions.ToString(mlngNodeID);

		public string NodeName => mstrNodeName;

		public int NodeParentID => mlngNodeParentID;

		public string NodeParentKey => "K" + Conversions.ToString(mlngNodeParentID);

		public string NodeText => mstrNodeText;

		public NodeObject()
		{
			mblnOpened = false;
			mlngNodeImageEnabledID = 101;
			mlngNodeImageDisabledID = 102;
			mlngNodeID = -1;
			mstrNodeName = "Unbekannt";
			mlngNodeParentID = -1;
			mstrNodeText = "Unbekannt";
		}

		~NodeObject()
		{
			FriendQuit();
			//base.Finalize();
		}

		internal void FriendQuit()
		{
			if (mblnOpened)
			{
				if (hwpDxf_Vars.pobjNodeObjects != null)
				{
					hwpDxf_Vars.pobjNodeObjects.Remove(mlngNodeID);
				}
				mblnOpened = false;
			}
		}

		internal void FriendAddToCollection(ref object robjObject)
		{
			if (!mblnOpened)
			{
				mlngNodeID = hwpDxf_Vars.pobjNodeObjects.Add(ref robjObject);
				mblnOpened = true;
			}
		}

		public Image NodeGetImageEnabled()
		{
			ResourceManager resMan = Resources.ResourceManager;
			object obj = RuntimeHelpers.GetObjectValue(resMan.GetObject("ico" + mlngNodeImageEnabledID, CultureInfo.InvariantCulture));
			Icon theIcon = (Icon)obj;
			return theIcon.ToBitmap();
		}

		public Image NodeGetImageDisabled()
		{
			ResourceManager resMan = null;
			//resMan = Resources.ResourceManager;
			object obj = RuntimeHelpers.GetObjectValue(resMan.GetObject("ico" + mlngNodeImageDisabledID, CultureInfo.InvariantCulture));
			Icon theIcon = (Icon)obj;
			return theIcon.ToBitmap();
		}
	}
}
