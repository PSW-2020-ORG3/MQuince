using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class Treatment
    {
        private Guid _id;
        public DateTime Date { get; set; }
        public TreatmentType Type { get; set; }
        public Guid TreatmentReportId { get; set; }
        public String Creator { get; set; }


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
