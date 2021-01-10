using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Exceptions
{
	public class InternalServerErrorException : Exception
	{
		private static readonly string _message = "Internal server error exception";
		public InternalServerErrorException() : base(_message)
		{
		}
	}
}
