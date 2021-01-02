using System.Collections.Generic;

namespace MQuince.Scheduler.Domain
{
    public class Scheduler
    {
        public WorkTime WorkTime { get; private set; }
        public IEnumerable<Appointment> ScheduledAppointments { get; private set; }

        public Scheduler(IEnumerable<Appointment> appointments, WorkTime workTime)
        {
            WorkTime = workTime;
            ScheduledAppointments = appointments;
        }


    }
}
