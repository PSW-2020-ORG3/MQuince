using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Rooms;
using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Appointments
{

    public class Appointment
    {
        private Guid _id;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        // public TreatmentType Type { get; set; }
        public bool isCanceled { get; set; }
        public Guid DoctorId { get; set; }


        public Appointment()
        {

        }

        public Appointment(Guid id, DateTime startDate, DateTime endDate, bool canceled, Guid doctorId)
        {
            _id = id;
            StartDateTime = startDate;
            EndDateTime = endDate;
            isCanceled = canceled;
            DoctorId = doctorId;
        }

        public Appointment(Guid id, DateTime startTime, DateTime endTime, bool canceled)
        {
            _id = id;
            StartDateTime = startTime;
            EndDateTime = endTime;
            isCanceled = canceled;
        }
        /*  public Appointment(DateTime startDate, DateTime endDate, bool canceled)
              : this(Guid.NewGuid(), startDate, endDate, canceled, Guid.NewGuid())
          { 
          }*/

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

    }
}
