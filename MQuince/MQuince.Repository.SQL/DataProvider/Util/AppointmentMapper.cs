using MQuince.Entities.Appointment;
using MQuince.Repository.SQL.PersistenceEntities.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class AppointmentMapper
    {
        public static Appointment MapAppointmentsPersistenceToAppointmentsEntity(AppointmentPersistence appointments)
        => appointments == null ? throw new ArgumentNullException()
                                        : new Appointment()
                                        {
                                            Id = appointments.Id,
                                            StartDateTime = appointments.StartDateTime,
                                            EndDateTime = appointments.EndDateTime,
                                            Type = appointments.Type,
                                            DoctorId = appointments.DoctorPersistanceId,
                                            PatientId = appointments.PatientPersistanceId
                                        };
        public static AppointmentPersistence MapAppointmentEntityToAppointmentPersistence(Appointment appointment)
        {
            if (appointment == null) return null;

            AppointmentPersistence retVal = new AppointmentPersistence() { Id = appointment.Id, StartDateTime = appointment.StartDateTime, EndDateTime = appointment.EndDateTime, Type = appointment.Type, DoctorPersistanceId = appointment.DoctorId, PatientPersistanceId = appointment.PatientId };
            return retVal;
        }
        public static IEnumerable<Appointment> MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(IEnumerable<AppointmentPersistence> appointments)
        => appointments == null ? throw new ArgumentNullException()
                                         : appointments.Select(entity => MapAppointmentsPersistenceToAppointmentsEntity(entity));
    }
}