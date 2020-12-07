using MQuince.Entities.Appointments;
using MQuince.Repository.SQL.PersistenceEntities.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class AppointmentMapper
    {
        public static Appointment MapAppointmentPersistenceToAppointmentEntity(AppointmentPersistence appointmentPersistance)
              => appointmentPersistance == null ? throw new ArgumentNullException()
                                        : new Appointment() {
                                            StartDateTime = appointmentPersistance.StartDateTime,
                                            EndDateTime = appointmentPersistance.EndDateTime, 
                                            isCanceled = appointmentPersistance.isCanceled,
                                            DoctorId = appointmentPersistance.DoctorId
                                        };

        public static IEnumerable<Appointment> MapAppointmentPersistenceCollectionToAppointmentEntityCollection(IEnumerable<AppointmentPersistence> appointmentPersistences)
              => appointmentPersistences == null ? throw new ArgumentNullException()
                                         : appointmentPersistences.Select(entity => MapAppointmentPersistenceToAppointmentEntity(entity));
    }

}

