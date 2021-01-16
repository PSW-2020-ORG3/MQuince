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
        public int NumberOfCreatedAppointment { get; set; }
        public double AverageTimeOnSpecialization { get; set; }

        public double AverageTimeOnDoctors { get; set; }
        public double AverageTimeOnChooseDate { get; set; }
        public double AverageTimeOnChoosePeriod { get; set; }

    }
}
