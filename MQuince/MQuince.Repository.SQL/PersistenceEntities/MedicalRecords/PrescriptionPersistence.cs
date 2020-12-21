using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("Prescription")]
    public class PrescriptionPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public bool Reserved { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }

        public List<Guid> TheraphyId = new List<Guid>();
    }
}
