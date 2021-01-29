using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.DTO
{
    public class ScheduleEventDTO
    {
        public ScheduleEventType EventType { get; set; }

        public Guid SessionId { get; set; }
    }
}
