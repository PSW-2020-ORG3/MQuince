using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Services.Util
{
	public class AppointmentMapper
	{
        public static Appointment CreateAppointmentFromDTO(AppointmentDTO appointment, Guid? id = null)
            => id == null ? new Appointment(new DateRange(appointment.StartDateTime, appointment.EndDateTime), appointment.DoctorId, appointment.PatientId, appointment.IsCanceled)
                          : new Appointment(new DateRange(appointment.StartDateTime, appointment.EndDateTime), appointment.DoctorId, appointment.PatientId, appointment.IsCanceled);

        public static IdentifiableDTO<AppointmentDTO> MapAppointmentEntityToAppointmentIdentifierDTO(Appointment appointment)
         => appointment == null ? throw new ArgumentNullException()
                                      : new IdentifiableDTO<AppointmentDTO>
                                      {
                                          Id = appointment.Id,
                                          EntityDTO = new AppointmentDTO()
                                          {
                                              StartDateTime = appointment.DateRange.StartDateTime,
                                              EndDateTime = appointment.DateRange.EndDateTime,
                                              DoctorId = appointment.DoctorId,
                                              PatientId = appointment.PatientId,
                                              IsCanceled = appointment.IsCanceled
                                          }
                                      };

    }
}
