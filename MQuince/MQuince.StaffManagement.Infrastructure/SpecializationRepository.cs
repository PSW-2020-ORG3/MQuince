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
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DbContextOptions _dbContext;
        public SpecializationRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public IEnumerable<Specialization> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return SpecializationMapper.MapSpecializationPersistenceCollectionToSpecializationEntityCollection(_context.Specializations.ToList());
            }
        }
    }
}
