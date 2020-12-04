using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Rooms;
using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Appointment
{

    public class Appointment
    {
        private Guid _id;
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Canceled { get; set; }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public Appointment()
        {

        }

        public Appointment(Guid id, Guid doctorId, Guid patientId, DateTime startDateTime, DateTime endDateTime, bool canceled)
        {
            _id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Canceled = canceled;
        }

        public Appointment(Guid id, bool canceled, DateTime startDateTime, DateTime endDateTime)
        {
            _id = id;
            Canceled = canceled;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

    }
}
