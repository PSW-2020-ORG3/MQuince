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
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Appointment> MapAppointmentsPersistenceCollectionToAppointmentsEntityCollection(IEnumerable<AppointmentPersistence> appointments)
        {
            throw new NotImplementedException();
        }
    }
}
