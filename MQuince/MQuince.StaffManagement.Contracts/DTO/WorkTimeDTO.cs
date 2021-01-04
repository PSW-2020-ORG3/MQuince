using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.DTO
{
    public class WorkTimeDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Guid DoctorId { get; set; }
    }
}
