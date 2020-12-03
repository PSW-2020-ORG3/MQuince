using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IDoctorRepository
    {
        Doctor GetById(Guid id);
        IEnumerable<Doctor> GetDoctorsPerSpecialization(Guid specializationId);
    }
}
