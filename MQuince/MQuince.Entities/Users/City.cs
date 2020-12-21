using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class City
    {
        private Guid _id;
        public string Name { get; set; }
        public int PostNumber { get; set; }
        public Guid CountryId { get; set; }

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
