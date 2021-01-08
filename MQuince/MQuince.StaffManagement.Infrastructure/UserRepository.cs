using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.StaffManagement.Infrastructure.Util;
using MQuince.StafManagement.Contracts.Repository;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.StaffManagement.Infrastructure
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
    }
}
