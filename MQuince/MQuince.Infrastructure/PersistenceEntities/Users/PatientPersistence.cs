using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Users
{
    [Table("Patient")]
    public class PatientPersistence : UserPersistence
    {
        public bool Guest { get; set; }

        [ForeignKey("DoctorPersistanceId")]
        public DoctorPersistence DoctorPersistance { get; set; }
        public Guid? DoctorPersistanceId { get; set; }

    }
}
