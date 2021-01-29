using MQuince.Core.IdentifiableDTO;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Application.Services.Util
{
    public class ReportMapper
    {
        public static IdentifiableDTO<ReportDTO> MapReportEntityToReportIdentifierDTO(Report report)
        => report == null ? throw new ArgumentNullException()
                                     : new IdentifiableDTO<ReportDTO>
                                     {
                                         Id = report.Id,
                                         EntityDTO = new ReportDTO()
                                         {
                                             ReportText = report.ReportText,
                                             AppointmentId = report.AppointmentId,
                                         }
                                     };
    }
}
