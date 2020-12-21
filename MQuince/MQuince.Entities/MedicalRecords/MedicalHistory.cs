using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MQuince.Entities.MedicalRecords
{
    public class MedicalHistory
    {
        private Guid _id;

        public DateTime Date { get; set; }
        public MedicalStatus MedicalStatus { get; set; }
        public Guid DiagnosisId { get; set; }

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
