using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.Repository
{
    public interface IReportRepository
    {
        public Report GetReportForAppointment(Guid id);
    }
}
