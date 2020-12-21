using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Contact
    {
        private Guid _id;
        public string Number { get; set; }
        public string Email { get; set; }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
