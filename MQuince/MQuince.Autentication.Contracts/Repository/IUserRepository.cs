using MQuince.Autentication.Domain;
using System;
using System.Collections.Generic;

namespace MQuince.Autentication.Contracts.Repository
{
    public interface IUserRepository
    {
        Patient GetPatientById(Guid id);
        IEnumerable<Patient> GetAllPatients();
        Admin GetAdminById(Guid id);
        IEnumerable<Admin> GetAllAdmins();
    }
}
