using MQuince.Core.IdentifiableDTO;
using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Scheduler.Infrastructure.Util
{
    public class ReportMapper
    {
        public static Report MapReportPersistenceToReportEntity(ReportPersistence report)
        => report == null ? throw new ArgumentNullException()
                                        : new Report(report.Id,report.Report,report.AppointmentPersistanceId);

    }
}
