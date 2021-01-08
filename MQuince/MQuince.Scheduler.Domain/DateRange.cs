using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain
{
    public class DateRange
    {
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }

        public DateRange(DateTime startDateTime, DateTime endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Validate();
        }

        private void Validate()
        {
            if (StartDateTime >= EndDateTime)
            {
                throw new ArgumentException("Invalid argument", nameof(StartDateTime));
            }
        }

        public bool IsOverlapping(DateRange dateRange)
        {
            return dateRange.StartDateTime < this.EndDateTime && dateRange.EndDateTime > this.StartDateTime;
        }
    }
}
