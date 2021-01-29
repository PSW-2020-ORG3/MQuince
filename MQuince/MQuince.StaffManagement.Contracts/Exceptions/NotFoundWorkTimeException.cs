using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StaffManagement.Contracts.Exceptions
{
    public class NotFoundWorkTimeException : Exception
	{
		private static readonly string _message = "Worktime for given date not found";
		public NotFoundWorkTimeException() : base(_message)
		{
		}
	}
}
