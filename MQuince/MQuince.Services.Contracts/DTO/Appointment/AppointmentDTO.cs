using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    public class AppointmentDTO
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Canceled { get; set; }
    }
}
