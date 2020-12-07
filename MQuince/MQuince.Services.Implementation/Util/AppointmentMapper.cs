using MQuince.Entities.Appointments;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class AppointmentMapper
    {
        public static IdentifiableDTO<AppointmentDTO> MapAppointmentEntityToIdentifierAppointmentDTO(Appointment appointment)
              => appointment == null ? throw new ArgumentNullException()
                                        : new IdentifiableDTO<AppointmentDTO>()
                                        {
                                            Id = appointment.Id,
                                            EntityDTO = new AppointmentDTO()
                                            {
                                                StartDateTime = appointment.StartDateTime,
                                                EndDateTime = appointment.EndDateTime,
                                                isCanceled = appointment.isCanceled,
                                                DoctorId = appointment.DoctorId
                                            }
                                        };

        public static IEnumerable<IdentifiableDTO<AppointmentDTO>> MapAppointmentEntityCollectionToIdentifierAppointmentDTOCollection(IEnumerable<Appointment> appointments)
              => appointments == null ? throw new ArgumentNullException()
                                         : appointments.Select(entity => MapAppointmentEntityToIdentifierAppointmentDTO(entity));
    }
}
