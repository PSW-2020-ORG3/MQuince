using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain
{
    public class WorkTime
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int StartTime { get; private set; }
        public int EndTime { get; private set; }

        public WorkTime(DateTime startDate, DateTime endDate, int startTime, int endTime)
        {
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
            Validate();
        }

        private void Validate()
        {
            if (StartDate >= EndDate || StartTime >= EndTime)
            {
                throw new ArgumentException("Invalid argument", nameof(StartDate));
            }
        }

        public DateRange GenerateWorkingTimeForDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
