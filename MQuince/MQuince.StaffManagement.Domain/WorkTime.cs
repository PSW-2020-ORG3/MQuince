using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Domain
{
    public class WorkTime
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Guid DoctorId { get; set; }

        public WorkTime(DateTime startDate,DateTime endDate,int startTime,int endTime,Guid doctorId)
        {
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
        }

        public DateRange GetWorkHour(DateTime date)
		{
            if (date < StartDate || date > EndDate)
                throw new ArgumentOutOfRangeException("date is out of range for worktime daterange");
            DateTime startWorkHour = new DateTime(date.Year, date.Month, date.Day, StartTime, 0, 0);
            DateTime endWorkHour = new DateTime(date.Year, date.Month, date.Day, EndTime, 0, 0);
            DateRange workHours = new DateRange(startWorkHour, endWorkHour);
            return workHours;
		}
    }
}
