using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXFLib.Basic
{
    public class ExceptionHelper
	{
		public static string GetExceptionMessage(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			string exceptionMessage = exception.Message;
			while (exception.InnerException != null)
			{
				exceptionMessage = exceptionMessage + "\r\n" + Convert.ToString(exception.InnerException.Message);
				exception = exception.InnerException;
			}
			return exceptionMessage;
		}
	}
}
