﻿using MQuince.Entities.Appointment;
using MQuince.Enums;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAppointmentService : IService<AppointmentDTO, IdentifiableDTO<AppointmentDTO>>
    {
        IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForDoctor(Guid doctorId);

        IEnumerable<IdentifiableDTO<AppointmentDTO>> GetForPatient(Guid patientId);

        IEnumerable<AppointmentDTO> GetFreeAppointments(Guid patientId, Guid doctorId, DateTime date, TreatmentType treatmentType);

        Appointment CancelAppointment(Guid IdAppointment, DateTime today);

        Appointment GetAppointment(Guid id);
    }
}
