using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Infrastructure.PersistenceEntities.Events.Scheduler
{
    [Table("ScheduleEvent")]
    public class ScheduleEventPersistence : BaseEventPersistence
    {
        public ScheduleEventType EventType { get; set; }

        [ForeignKey("AppointmentId")]
        public Guid AppointmentId { get; set; }
        public AppointmentPersistence Appointment { get; set; }
    }
}
