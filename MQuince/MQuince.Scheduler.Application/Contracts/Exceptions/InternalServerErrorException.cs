using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Contracts.Exceptions
{
	public class InternalServerErrorException : Exception
	{
		private static readonly string _message = "Internal server error exception";
		public InternalServerErrorException() : base(_message)
		{
		}
	}
}
