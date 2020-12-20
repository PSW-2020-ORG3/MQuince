using MQuince.Enums;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Appointments
{
    [Table("Appointment")]
    public class AppointmentPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }

        [ForeignKey("DoctorPersistanceId")]
        public DoctorPersistence DoctorPersistance { get; set; }
        public Guid DoctorPersistanceId { get; set; }

        [ForeignKey("PatientPersistanceId")]
        public PatientPersistence PatientPersistance { get; set; }
        public Guid PatientPersistanceId { get; set; }
    }
}
