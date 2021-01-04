using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Infrastructure.DataProvider.Util;
using MQuince.StafManagement.Contracts.Repository;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Infrastructure.DataProvider
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions _dbContext;
        public UserRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(_context.Doctors.ToList());
            }
        }


        public Doctor GetDoctorById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                var doctor = _context.Doctors.Include("Specialization").SingleOrDefault(c => c.Id.Equals(id));
                return DoctorMapper.MapDoctorPersistenceToDoctorEntity(doctor);
            }
        }

        public IEnumerable<Doctor> GetDoctorsPerSpecialization(Guid specializationId)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(_context.Doctors.Where(c => c.SpecializationId == specializationId).ToList());
            }
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(_context.Patients.ToList());
            }
        }

        public Patient GetPatientById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                var patient = _context.Patients.Include("DoctorPersistance").SingleOrDefault(c => c.Id.Equals(id));
                return PatientMapper.MapPatientPersistenceToPatientEntity(patient);
            }
        }

        public Admin GetAdminById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AdminMapper.MapAdminPersistenceToAdminEntity(_context.Admin.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AdminMapper.MapAdminPersistenceCollectionToAdminEntityCollection(_context.Admin.ToList());
            }
        }

    }
}
