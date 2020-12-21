using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Appointments
{
    [Table("RecommendAppointmentParameters")]
    public class RecommendAppointmentParametersPersistence
    {
        [Key]
        public Guid Id;

        [ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public AppointmentPriority Priority { get; set; }
    }
}
