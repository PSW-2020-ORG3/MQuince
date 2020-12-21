using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("RiskAllergies")]
    public class RiskAllergiesPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("MedicalStatusId")]
        public Guid MedicalStatusId { get; set; }

        [ForeignKey("AllergenId")]
        public Guid AllergenId { get; set; }
    }
}
