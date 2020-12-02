using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class WorkTime
    {
        private Guid _id;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Guid DoctorId { get; set; }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public WorkTime(Guid id, DateTime startDate,DateTime endDate,int startTime,int endTime,Guid doctorId)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;
            DoctorId = doctorId;
        }
    }
}
