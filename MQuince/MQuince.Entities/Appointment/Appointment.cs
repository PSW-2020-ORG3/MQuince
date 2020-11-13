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
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }
        public Guid RoomId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }


        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

    }
}
