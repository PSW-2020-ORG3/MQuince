using MQuince.Infrastructure.PersistenceEntities.Events.Scheduler;
using MQuince.Scheduler.Domain.Events;
using System;

namespace MQuince.Scheduler.Infrastructure.Util
{
    public class EventMapper
    {
        public static ScheduleEventPersistence MapScheduleEventEntityToScheduleEventPersistence(ScheduleEvent entity)
            => entity == null ? null : new ScheduleEventPersistence() { Id= entity.BaseEntityId, EventType = entity.EventType, TimeStamp = entity.TimeStamp, SessionId=entity.SessionId};

    }
}
