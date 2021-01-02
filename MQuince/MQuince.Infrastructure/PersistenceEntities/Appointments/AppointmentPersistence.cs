using MQuince.Infrastructure.PersistenceEntities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Appointments
{
    [Table("Appointment")]
    public class AppointmentPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateRangePersistence DateRange { get; set; }

        [ForeignKey("DoctorPersistanceId")]
        public DoctorPersistence DoctorPersistance { get; set; }
        public Guid DoctorPersistanceId { get; set; }

        [ForeignKey("PatientPersistanceId")]
        public PatientPersistence PatientPersistance { get; set; }
        public Guid PatientPersistanceId { get; set; }
        public bool IsCanceled { get; set; }
    }
}
