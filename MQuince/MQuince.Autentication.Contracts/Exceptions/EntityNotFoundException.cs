using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Autentication.Contracts.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private static readonly string _message = "Entity not found in database";
        public EntityNotFoundException() : base(_message)
        {
        }
    }
}
