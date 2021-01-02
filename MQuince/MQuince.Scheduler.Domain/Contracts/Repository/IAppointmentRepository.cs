using MQuince.Core.Contracts;
using System;
using System.Collections.Generic;

namespace MQuince.Scheduler.Domain.Contracts
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetForDoctor(Guid doctorId);
        IEnumerable<Appointment> GetForPatient(Guid patientId);
        IEnumerable<Appointment> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time);
    }
}
