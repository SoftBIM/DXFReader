using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Acad
{
    public class AcadDatabases
    {
        private bool mblnOpened = true;
        private OrderedDictionary mcolClass = new OrderedDictionary();
        private long mlngDatabaseIndex = -1;
    }
}
