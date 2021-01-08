using MQuince.Core.BaseEvent;
using System;

namespace MQuince.Review.Domain.Events
{
    public class FeedbackEvent : BaseEvent
    {
        public FeedbackEventType EventType { get; private set; }

        public FeedbackEvent(FeedbackEventType eventType, Guid baseEntityId) : base(baseEntityId)
        {
            EventType = eventType;
        }

        public FeedbackEvent(FeedbackEventType eventType, DateTime dateTime, Guid baseEntityId) : base(dateTime, baseEntityId)
        {
            EventType = eventType;
        }
    }
}
