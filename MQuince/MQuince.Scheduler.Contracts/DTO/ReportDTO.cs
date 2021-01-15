using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.DTO
{
    public class ReportDTO
    {
        public string ReportText { get; set; }
        public Guid AppointmentId { get; set; }

    }
}
