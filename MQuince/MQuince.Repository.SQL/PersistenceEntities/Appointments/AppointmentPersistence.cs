using MQuince.Enums;
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
        //public TreatmentType Type { get; set; }

        public bool isCanceled { get; set; }
        
        [ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }

        
       


    }
}
