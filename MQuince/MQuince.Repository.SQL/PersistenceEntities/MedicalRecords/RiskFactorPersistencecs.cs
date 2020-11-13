using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("RiskFactor")]
    public class RiskFactorPersistencecs
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid MedicalStatusId{ get; set; }
        [ForeignKey("riskFactorId")]
        public Guid riskFactorId { get; set; }
    }
}
