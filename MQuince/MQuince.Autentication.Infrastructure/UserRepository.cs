using Microsoft.EntityFrameworkCore;
using MQuince.Autentication.Contracts.Repository;
using MQuince.Autentication.Domain;
using MQuince.Autentication.Infrastructure.Util;
using MQuince.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Autentication.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions _dbContext;

        public UserRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
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
    }
}
