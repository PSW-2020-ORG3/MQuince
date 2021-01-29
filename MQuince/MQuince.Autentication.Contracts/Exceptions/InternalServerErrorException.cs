using System;

namespace MQuince.Autentication.Contracts.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        private static readonly string _message = "Internal server error exception";
        public InternalServerErrorException() : base(_message)
        {
        }
    }
}
