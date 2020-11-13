using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Patient
    {
        private Guid _id;
        public bool Guest { get; set; }
        public BloodType BloodType { get; set; }
        public Rhfactor RhFactor { get; set; }
        public Guid MedicalRecordId { get; set; }

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
