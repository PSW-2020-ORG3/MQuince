using MQuince.Core.BaseEvent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain.Events
{
    public class ScheduleEvent : BaseEvent
    {
        public ScheduleEventType EventType { get; private set; }

        public Guid PatientId { get; private set; }

        public ScheduleEvent(ScheduleEventType eventType, Guid baseEntityId, Guid patientId) : base(baseEntityId)
        {
            EventType = eventType;
            PatientId = patientId;
        }

        public ScheduleEvent(ScheduleEventType eventType, DateTime dateTime, Guid baseEntityId, Guid patientId) : base(dateTime, baseEntityId)
        {
            EventType = eventType;
            PatientId = patientId;
        }
    }
}
