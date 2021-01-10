using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Scheduler.Domain
{
    public class Scheduler
    {
        public DateRange WorkHours { get; private set; }
        public IEnumerable<Appointment> ScheduledAppointments { get; private set; }

        public Scheduler(IEnumerable<Appointment> appointments, DateRange workHours)
        {
            WorkHours = workHours;
            ScheduledAppointments = appointments;
        }

        public IEnumerable<Appointment> GetFreeAppointments()
        {
            if (WorkHours == null)
                return new List<Appointment>();
            else
                return FindFreeAppointments(WorkHours.StartDateTime, WorkHours.EndDateTime);

        }
        private TimeSpan GetAppointmentDuration()
            => new TimeSpan(0, 30, 0);

        private IEnumerable<Appointment> FindFreeAppointments(DateTime startDateTime, DateTime endDateTime)
        {
            List<Appointment> appointments = ScheduledAppointments.ToList();
            appointments.Sort((x, y) => DateTime.Compare(x.DateRange.StartDateTime, y.DateRange.StartDateTime));
            List<Appointment> freeAppointments = new List<Appointment>();

            DateTime startTime = startDateTime;
            DateTime endTime;
            if (appointments.Any())
            {
                foreach (Appointment appointment in appointments)
                {
                    endTime = appointment.DateRange.StartDateTime;
                    freeAppointments.AddRange(FillFreeInterval(startTime, endTime));
                    startTime = appointment.DateRange.EndDateTime;
                }
            }
            endTime = endDateTime;
            freeAppointments.AddRange(FillFreeInterval(startTime, endTime));
            return freeAppointments;
        }
        private IEnumerable<Appointment> FillFreeInterval(DateTime startTime, DateTime endTime)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            while (endTime - startTime >= GetAppointmentDuration())
            {
                DateRange dateRange = new DateRange(startTime, startTime.Add(GetAppointmentDuration()));
                Appointment freeAppointment = new Appointment(dateRange);
                startTime = freeAppointment.DateRange.EndDateTime;
                freeAppointments.Add(freeAppointment);
            }
            return freeAppointments;
        }
    }
}
