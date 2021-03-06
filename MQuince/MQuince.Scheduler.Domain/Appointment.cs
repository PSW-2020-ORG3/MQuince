﻿using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;

namespace MQuince.Scheduler.Domain
{
    public class Appointment
    {
        private Guid _id;
        public DateRange DateRange { get; private set; }
        public Guid DoctorId { get; private set; }
        public Guid PatientId { get; private set; }
        public bool IsCanceled { get; private set; }

        public Appointment() { }

        public Appointment(DateRange dateRange)
		{
            DateRange = dateRange;
            Id = Guid.NewGuid();
		}

        public Appointment(Guid id, DateRange dateRange, Guid doctorId, Guid patientId, bool isCanceled)
        {
            Id = id;
            DateRange = dateRange;
            DoctorId = doctorId;
            PatientId = patientId;
            IsCanceled = isCanceled;
        }


        public Appointment(DateRange dateRange, Guid doctorId, Guid patientId, bool isCanceled = false)
            : this(Guid.NewGuid(), dateRange, doctorId, patientId, isCanceled)
        {
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public void Cancel()
        {
            if (!IsCancelable()) throw new ArgumentException("Appointment cannot be canceled", nameof(IsCanceled));

            this.IsCanceled = true;
        }

        public bool IsCancelable()
        {
            if (this.DateRange.StartDateTime < DateTime.Now.AddHours(48))
                return false;

            return true;
        }
    }
}
