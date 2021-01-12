using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.ActionAndBenefits.Constracts.Exceptions
{
	public class NotFoundEntityException : Exception
	{
		private static readonly string _message = "Entity not found in database";
		public NotFoundEntityException() : base(_message)
		{
		}
	}
}
