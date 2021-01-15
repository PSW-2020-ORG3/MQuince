using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.DTO
{
    public class ScheduleEventStatisticsResponseDTO
    {
        public double PercentOfSuccessfulCreating { get; set; }
        public double AverageCreatingTime { get; set; }
        public int StepWherePatientsQuit { get; set; }
    }
}
