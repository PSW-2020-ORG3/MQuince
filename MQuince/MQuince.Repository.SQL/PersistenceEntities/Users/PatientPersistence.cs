using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Patient")]
    public class PatientPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public bool Guest { get; set; }
        public BloodType BloodType { get; set; }
        public Rhfactor RhFactor { get; set; }
        [ForeignKey("MedicalRecordId")]
        public Guid MedicalRecordId { get; set; }
    }
}
