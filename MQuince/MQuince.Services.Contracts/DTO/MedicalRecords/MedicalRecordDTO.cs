using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class MedicalRecordDTO
    {
        public string Note { get; set; }
        public List<Guid> MedicalHistoryId = new List<Guid>();
        public List<Guid> RiskFactorId = new List<Guid>();
        public List<Guid> FamilyRiskFactorId = new List<Guid>();
        public List<Guid> RiskAllergiesId = new List<Guid>();
        public List<Guid> ImmunizationId = new List<Guid>();
        public List<Guid> TreatmentId = new List<Guid>();

    }
}
