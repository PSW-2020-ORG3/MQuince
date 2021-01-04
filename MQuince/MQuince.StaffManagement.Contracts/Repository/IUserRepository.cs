using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Repository
{
    public interface IUserRepository
    {
        Doctor GetDoctorById(Guid id);
        IEnumerable<Doctor> GetDoctorsPerSpecialization(Guid specializationId);
        IEnumerable<Doctor> GetAllDoctors();
        Patient GetPatientById(Guid id);
        IEnumerable<Patient> GetAllPatients();
        Admin GetAdminById(Guid id);
        IEnumerable<Admin> GetAllAdmins();
    }
}
