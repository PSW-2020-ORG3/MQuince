using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("FamilyRiskFactor")]
    public class FamilyRiskFactorPersistence
    {
        [Key]
        public Guid _id { get; set; }
        public DateTime Date { get; set; }

        public Guid Relationship { get; set; }

    }
}
