using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("MedicalHistory")]
    public class MedicalHistoryPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("MedicalStatusId")]
        public Guid MedicalStatusId { get; set; }

        [ForeignKey("DiagnosisId")]
        public Guid DiagnosisId { get; set; }
    }
}
