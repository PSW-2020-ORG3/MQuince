using MQuince.Infrastructure.PersistenceEntities.Events.Feedback;
using MQuince.Infrastructure.PersistenceEntities.Events.Scheduler;
using MQuince.Review.Domain.Events;
using MQuince.Scheduler.Domain.Events;
using System;

namespace MQuince.Infrastructure.DataProvider.Util
{
    public class EventMapper
    {
        public static FeedbackEventPersistence MapFeedbackEventEntityToFeedbackEventPersistence(FeedbackEvent entity)
            => entity == null ? null : new FeedbackEventPersistence() { Id = Guid.NewGuid(), EventType = entity.EventType, TimeStamp = entity.TimeStamp, FeedbackId = entity.BaseEntityId };

        public static ScheduleEventPersistence MapScheduleEventEntityToScheduleEventPersistence(ScheduleEvent entity)
            => entity == null ? null : new ScheduleEventPersistence() { Id = Guid.NewGuid(), EventType = entity.EventType, TimeStamp = entity.TimeStamp, AppointmentId = entity.BaseEntityId };

    }
}
