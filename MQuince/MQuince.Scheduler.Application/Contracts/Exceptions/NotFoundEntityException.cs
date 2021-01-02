using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Contracts.Exceptions
{
	public class NotFoundEntityException : Exception
	{
		private static readonly string _message = "Entity not found in database";
		public NotFoundEntityException() : base(_message)
		{
		}
	}
}
