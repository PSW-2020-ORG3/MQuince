using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class DoctorRepository : IDoctorRepository
    {
        public Doctor GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorsPerSpecialization(Guid specializationId)
        {
            throw new NotImplementedException();
        }
    }
}
