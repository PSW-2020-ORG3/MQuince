using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DbContextOptions _dbContext;
        public DoctorRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Doctor> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(_context.Doctors.ToList());
            }
        }

        public Doctor GetById(Guid id)
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
                return DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(_context.Doctors.Where(c=>c.SpecializationId== specializationId).ToList());
            }
        }
    }
}
