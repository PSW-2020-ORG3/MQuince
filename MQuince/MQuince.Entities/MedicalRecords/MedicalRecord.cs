using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.MedicalRecords
{
    public class MedicalRecord
    {
        private Guid _id;
        public string Note { get; set; }
        public List<Guid> MedicalHistoryId = new List<Guid>();
        public List<Guid> RiskFactorId = new List<Guid>();
        public List<Guid> FamilyRiskFactorId = new List<Guid>();
        public List<Guid> RiskAllergiesId = new List<Guid>();
        public List<Guid> ImmunizationId = new List<Guid>();
        public List<Guid> TreatmentId = new List<Guid>();
        public Guid PatientId { get; set; }

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
