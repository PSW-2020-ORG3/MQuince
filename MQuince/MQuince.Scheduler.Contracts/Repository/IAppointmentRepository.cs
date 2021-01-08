using MQuince.Core.Contracts;
using MQuince.Scheduler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Scheduler.Contracts.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetForDoctor(Guid doctorId);
        IEnumerable<Appointment> GetForPatient(Guid patientId);
        IEnumerable<Appointment> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time);
    }
}
