using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Diagnosis
{
    [Table("Symptom")]
    public class SymptomPersistence
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("DiagnosisId")]
        public List<Guid> DiagnosisId { get; set; }
    }
}
