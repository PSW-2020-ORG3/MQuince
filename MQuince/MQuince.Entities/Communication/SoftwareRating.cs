using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class SoftwareRating
    {
        private Guid _id;
        public Grade Functionality { get; set; }
        public Grade Speed { get; set; }
        public Grade Reliabillity { get; set; }
        public Grade Design { get; set; }
        public string Note { get; set; }
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
