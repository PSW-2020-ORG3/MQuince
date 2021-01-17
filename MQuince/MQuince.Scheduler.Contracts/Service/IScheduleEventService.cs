using MQuince.Scheduler.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.Service
{
    public interface IScheduleEventService
    {
        public Guid Create(ScheduleEventDTO entityDTO);

        public ScheduleEventStatisticsResponseDTO GetScheduleStatistics();
    }
}
