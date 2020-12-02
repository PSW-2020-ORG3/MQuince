using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Services.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions _dbContext;

        public UserRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        /*private readonly DbContextOptions _dbContext;

        public UserRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public IEnumerable<User> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return UserMapper.MapUserPersistenceCollectionToUserEntityCollection(_context.Users.ToList());
            }
        }

        public User GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return UserMapper.MapUserPersistenceToUserEntity(_context.Users.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Create(User entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Users.Add(UserMapper.MapUserEntityToUserPersistence(entity));
                _context.SaveChanges();
            }
        }*/
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
