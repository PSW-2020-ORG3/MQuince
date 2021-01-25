using MQuince.Core.BaseEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain.Events
{
    public class ScheduleEvent : BaseEvent
    {
        public ScheduleEventType EventType { get; set; }

        public Guid SessionId { get; set; }

        public ScheduleEvent(ScheduleEventType eventType, Guid baseEntityId, Guid sessionId) : base(baseEntityId)
        {
            EventType = eventType;
            SessionId = sessionId;
        }

        public ScheduleEvent(ScheduleEventType eventType, DateTime dateTime, Guid baseEntityId, Guid sessionId) : base(dateTime, baseEntityId)
        {
            EventType = eventType;
            SessionId = sessionId;
        }
    }
}
