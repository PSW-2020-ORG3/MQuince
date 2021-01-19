using MQuince.Infrastructure.PersistenceEntities.Events.Scheduler;
using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Scheduler.Infrastructure.Util
{
    public class EventMapper
    {
        public static ScheduleEventPersistence MapScheduleEventEntityToScheduleEventPersistence(ScheduleEvent entity)
            => entity == null ? null : new ScheduleEventPersistence() { Id= entity.BaseEntityId, EventType = entity.EventType, TimeStamp = entity.TimeStamp, SessionId=entity.SessionId};


        public static ScheduleEvent MapSchedulePersistenceToScheduleEntity(ScheduleEventPersistence schedulePersistance)
        => schedulePersistance == null ? throw new ArgumentNullException()
                                        : new ScheduleEvent(schedulePersistance.EventType,schedulePersistance.TimeStamp,schedulePersistance.Id,schedulePersistance.SessionId);
        public static IEnumerable<ScheduleEvent> MapSchedulesPersistenceCollectionTSchedulesEntityCollection(IEnumerable<ScheduleEventPersistence> scheduleEvents)
        => scheduleEvents == null ? throw new ArgumentNullException()
                                         : scheduleEvents.Select(entity => MapSchedulePersistenceToScheduleEntity(entity));
    }
}
