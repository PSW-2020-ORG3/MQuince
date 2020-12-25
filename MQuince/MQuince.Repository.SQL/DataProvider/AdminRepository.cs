using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class AdminRepository
    {
        private readonly DbContextOptions _dbContext;
        public AdminRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Admin> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AdminMapper.MapAdminPersistenceCollectionToAdminEntityCollection(_context.Admin.ToList());
            }
        }

        public Admin GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AdminMapper.MapAdminPersistenceToAdminEntity(_context.Admin.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }
    }
}
