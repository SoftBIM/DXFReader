using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadApplications
	{
		bool mblnOpened = true;
		OrderedDictionary<long, AcadApplication> mcolClass = new OrderedDictionary<long, AcadApplication>();
		long mlngApplicationIndex = -1;

		public AcadApplication Item(long index)
		{
			AcadApplication acadApplication = null;
			if (mcolClass.Contains(index)
			{
				acadApplication = mcolClass[index];
			}
			else
			{
				throw new IndexOutOfRangeException();
			}
			return acadApplication;
		}
	}
}
