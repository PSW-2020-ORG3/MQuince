﻿using MQuince.Enums;
using System;

namespace MQuince.Entities.Appointment
{

    public class Appointment
    {
        private Guid _id;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public TreatmentType Type { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public bool IsCanceled { get; set; }

        public Appointment()
        {
        }

        public Appointment(DateTime startDateTime, DateTime endDateTime, TreatmentType type, Guid doctorId, Guid patientId, bool isCanceled)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Type = type;
            DoctorId = doctorId;
            PatientId = patientId;
            IsCanceled = isCanceled;
        }

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
