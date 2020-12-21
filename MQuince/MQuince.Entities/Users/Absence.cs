using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Absence
    {
        private Guid _id;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AbsenceType AbsenceType { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }
        public Guid StaffId { get; set; }

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
