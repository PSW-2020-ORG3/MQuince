using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Repository.SQL.DataProvider
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DbContextOptions _dbContext;

        public QuestionRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public void Create(Question entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Questions.Add(QuestionMapper.MapQuestionEntityToQuestionPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return QuestionMapper.MapQuestionPersistenceCollectionToQuestionEntityCollection(_context.Questions.ToList());
            }
        }

        public Question GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
