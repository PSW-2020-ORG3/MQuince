using MQuince.Entities.Appointments;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;
namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAppointmentService : IService<AppointmentDTO, IdentifiableDTO<AppointmentDTO>>
    {
        IEnumerable<Appointment> GetAllAppointmentsByPatient(Guid patientId);
    }
}
