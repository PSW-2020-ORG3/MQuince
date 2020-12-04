using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAppointmentService
    {
        IdentifiableDTO<AppointmentDTO> GetById(Guid id);
        IEnumerable<IdentifiableDTO<AppointmentDTO>> GetAppointments();
    }
}
