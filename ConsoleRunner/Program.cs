using DXFLib.Acad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DXFReaderConsoleRunner");
            AcadApplications acadApplication = new AcadApplications();
            AcadDocument acadDocument = new AcadDocument();
            string fileName = string.Empty;
            acadDocument.OpenDoc(fileName);



            Console.WriteLine("Press any key to exit the program");
            Console.ReadKey();
        }
    }
}
