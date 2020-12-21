using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MQuince.Entities.MedicalRecords
{
    public class Immunization
    {

        private Guid _id;
        public DateTime Date { get; set; }
        public GivingType GivingType { get; set; }
        public VaccineType VaccineType { get; set; }

        public Guid Vaccine { get; set; }

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
