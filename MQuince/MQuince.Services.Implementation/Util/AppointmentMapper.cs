using MQuince.Entities.Appointment;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class AppointmentMapper
    {
        public static IdentifiableDTO<AppointmentDTO> MapAppointmentEntityToAppointmentIdentifierDTO(Appointment appointment)
         => appointment == null ? throw new ArgumentNullException()
                                      : new IdentifiableDTO<AppointmentDTO>
                                      {
                                          Id = appointment.Id,
                                          EntityDTO = new AppointmentDTO()
                                          {
                                              StartDateTime = appointment.StartDateTime,
                                              EndDateTime = appointment.EndDateTime,
                                              Type = appointment.Type,
                                              DoctorId = appointment.DoctorId,
                                              PatientId = appointment.PatientId,
                                              IsCanceled = appointment.IsCanceled
                                          }
                                      };


    }
}