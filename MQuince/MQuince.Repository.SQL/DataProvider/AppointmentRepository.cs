using MQuince.Entities.Appointment;
using MQuince.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    class AppointmentRepository : IAppointmentRepository
    {
        public void Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetForDoctor(Guid doctorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetForPatient(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public void Update(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
