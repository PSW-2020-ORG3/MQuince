using MQuince.Core.BaseEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain.Events
{
    public class ScheduleEvent : BaseEvent
    {
        public ScheduleEventType EventType { get; private set; }

        public ScheduleEvent(ScheduleEventType eventType, Guid baseEntityId) : base(baseEntityId)
        {
            EventType = eventType;
        }

        public ScheduleEvent(ScheduleEventType eventType, DateTime dateTime, Guid baseEntityId) : base(dateTime, baseEntityId)
        {
            EventType = eventType;
        }
    }
}
