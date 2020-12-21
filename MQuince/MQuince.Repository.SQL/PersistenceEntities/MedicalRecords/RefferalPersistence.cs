using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("Refferal")]
    public class RefferalPersistence
    {
        [Key]
        public Guid Id { get; set; }
    }
}
