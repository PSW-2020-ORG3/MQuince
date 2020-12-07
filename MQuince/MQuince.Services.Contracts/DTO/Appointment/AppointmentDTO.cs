using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    public class AppointmentDTO
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        // public TreatmentType Type { get; set; }
        public bool isCanceled { get; set; }
        public Guid DoctorId { get; set; }
        
    }
}
