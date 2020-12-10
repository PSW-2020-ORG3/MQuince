using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Appointment
{
    public class RecommendAppointmentParameters
    {
        private Guid _id;
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public AppointmentPriority Priority { get; set; }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public RecommendAppointmentParameters()
        {
        }

        public RecommendAppointmentParameters(Guid id, Guid doctorId, DateTime dateFrom, DateTime dateTo, AppointmentPriority priority)
        {
            _id = id;
            DoctorId = doctorId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Priority = priority;
        }

        public RecommendAppointmentParameters(Guid doctorId, DateTime dateFrom, DateTime dateTo, AppointmentPriority priority)
        {
            DoctorId = doctorId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Priority = priority;
        }
    }
}
