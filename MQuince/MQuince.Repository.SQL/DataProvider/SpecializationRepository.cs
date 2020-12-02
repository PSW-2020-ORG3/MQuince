using System;
using System.Collections.Generic;
using MQuince.Repository.Contracts;
using System.Text;
using System.Linq;

using MQuince.Entities.Users;
using Microsoft.EntityFrameworkCore;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;

namespace MQuince.Repository.SQL.DataProvider
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
