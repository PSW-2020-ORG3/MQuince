using MQuince.Entities.Appointment;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IEnumerable<Appointment> GetForDoctor(Guid doctorId);

        IEnumerable<Appointment> GetForPatient(Guid patientId);
        IEnumerable<Appointment> GetAppointmentForDoctorForDate(Guid doctorId, DateTime time);
    }
}
