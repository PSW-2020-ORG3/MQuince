using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StaffManagement.Contracts.Exceptions
{
    public class InvalidJWTTokenException : Exception
	{
		private static readonly string _message = "Invalid JWT Token";
		public InvalidJWTTokenException() : base(_message)
		{
		}
	}
}
