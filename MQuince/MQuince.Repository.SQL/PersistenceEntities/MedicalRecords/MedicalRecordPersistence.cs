using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("MedicalRecord")]
    public class MedicalRecordPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Note { get; set; }
        public List<Guid> MedicalHistoryId = new List<Guid>();
        public List<Guid> RiskFactorId = new List<Guid>();
        public List<Guid> FamilyRiskFactorId = new List<Guid>();
        public List<Guid> RiskAllergiesId = new List<Guid>();
        public List<Guid> ImmunizationId = new List<Guid>();
        public List<Guid> TreatmentId = new List<Guid>();
    }
}
