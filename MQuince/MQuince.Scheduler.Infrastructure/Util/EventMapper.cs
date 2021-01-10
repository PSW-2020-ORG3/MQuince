using MQuince.Infrastructure.PersistenceEntities.Events.Scheduler;
using MQuince.Scheduler.Domain.Events;
using System;

namespace MQuince.Scheduler.Infrastructure.Util
{
    public class EventMapper
    {
        public static ScheduleEventPersistence MapScheduleEventEntityToScheduleEventPersistence(ScheduleEvent entity)
            => entity == null ? null : new ScheduleEventPersistence() { Id = Guid.NewGuid(), EventType = entity.EventType, TimeStamp = entity.TimeStamp, AppointmentId = entity.BaseEntityId, PatientId = entity.PatientId };

    }
}
