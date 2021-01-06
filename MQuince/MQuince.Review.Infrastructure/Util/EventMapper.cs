using MQuince.Infrastructure.PersistenceEntities.Events.Feedback;
using MQuince.Review.Domain.Events;
using System;

namespace MQuince.Review.Infrastructure.Util
{
    public class EventMapper
    {
        public static FeedbackEventPersistence MapFeedbackEventEntityToFeedbackEventPersistence(FeedbackEvent entity)
            => entity == null ? null : new FeedbackEventPersistence() { Id = Guid.NewGuid(), EventType = entity.EventType, TimeStamp = entity.TimeStamp, FeedbackId = entity.BaseEntityId };
    }
}
