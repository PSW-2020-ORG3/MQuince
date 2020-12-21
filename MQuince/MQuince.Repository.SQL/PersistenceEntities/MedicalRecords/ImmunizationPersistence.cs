using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MQuince.Enums;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("Immunization")]
    public class ImmunizationPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public GivingType GivingType { get; set; }
        public VaccineType VaccineType { get; set; }

        [ForeignKey("VaccineId")]
        public Guid VaccineId { get; set; }
    }
}
