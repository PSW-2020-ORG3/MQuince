using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.Scheduler.Domain.Events;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Events.Scheduler
{
    [Table("ScheduleEvent")]
    public class ScheduleEventPersistence : BaseEventPersistence
    {
        public ScheduleEventType EventType { get; set; }

        [ForeignKey("AppointmentId")]
        public Guid AppointmentId { get; set; }
        public AppointmentPersistence Appointment { get; set; }

        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        public PatientPersistence Patient { get; set; }
    }
}
