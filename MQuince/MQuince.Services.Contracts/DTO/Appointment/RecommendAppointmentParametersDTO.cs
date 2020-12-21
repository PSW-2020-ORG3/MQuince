using MQuince.Entities;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Appointment
{
    class RecommendAppointmentParametersDTO
    {
        public Guid DoctorId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public AppointmentPriority Priority { get; set; }
    }
}
