using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Scheduler.Infrastructure.Util
{
    public class AppointmentMapper
    {
        public static Appointment MapAppointmentsPersistenceToAppointmentsEntity(AppointmentPersistence appointments)
        => appointments == null ? throw new ArgumentNullException()
                                        : new Appointment(appointments.Id,
                                                          new DateRange(appointments.DateRange.StartDateTime, appointments.DateRange.EndDateTime),
                                                          appointments.DoctorPersistanceId, appointments.PatientPersistanceId,
                                                          appointments.IsCanceled);
        public static AppointmentPersistence MapAppointmentEntityToAppointmentPersistence(Appointment appointment)
        {
            if (appointment == null) return null;

            AppointmentPersistence retVal = new AppointmentPersistence() { Id = appointment.Id, DateRange = new DateRangePersistence() { StartDateTime = appointment.DateRange.StartDateTime, EndDateTime = appointment.DateRange.EndDateTime }, DoctorPersistanceId = appointment.DoctorId, PatientPersistanceId = appointment.PatientId, IsCanceled = appointment.IsCanceled };
            return retVal;
        }
        public static IEnumerable<Appointment> MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(IEnumerable<AppointmentPersistence> appointments)
        => appointments == null ? throw new ArgumentNullException()
                                         : appointments.Select(entity => MapAppointmentsPersistenceToAppointmentsEntity(entity));
    }
}
