using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class FamilyRiskFactor
    {
        private Guid _id;
        public DateTime Date { get; set; }
        public Relationship Relationship { get; set; }
        public Guid familyRiskFactor { get; set; }

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
