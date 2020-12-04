﻿using MQuince.Entities.Appointment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IAppointmentRepository
    {
        Appointment GetById(Guid id);
        IEnumerable<Appointment> GetAppointments();
    }
}