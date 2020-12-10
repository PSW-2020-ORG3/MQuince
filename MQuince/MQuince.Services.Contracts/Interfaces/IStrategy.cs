using MQuince.Entities.Appointment;
using MQuince.Services.Contracts.DTO.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IStrategy
    {
        AppointmentDTO recommend(Guid patientId, Guid doctorId);
    }
}
