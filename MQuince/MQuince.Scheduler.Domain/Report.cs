using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Domain
{
    public class Report
    {
        public Guid Id { get; set; }

        public string ReportText { get; set; }
        public Guid AppointmentId { get; private set; }

        public Report(Guid id, string reportText, Guid appointmentId)
        {
            Id = id;
            ReportText = reportText;
            AppointmentId = appointmentId;
        }

    }
}
