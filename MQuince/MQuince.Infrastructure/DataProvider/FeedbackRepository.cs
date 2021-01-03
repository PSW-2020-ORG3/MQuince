using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Infrastructure.DataProvider.Util;
using MQuince.Infrastructure.PersistenceEntities.Communication;
using MQuince.Review.Contracts.Repository;
using MQuince.Review.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Infrastructure.DataProvider
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbContextOptions _dbContext;

        public FeedbackRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(Feedback entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Feedbacks.Add(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                FeedbackPersistence feedback = _context.Feedbacks.Find(id);
                if (feedback == null) return false;

                _context.Feedbacks.Remove(feedback);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Feedback> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(_context.Feedbacks.ToList());
            }
        }

        public Feedback GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return FeedbackMapper.MapFeedbackPersistenceToFeedbackEntity(_context.Feedbacks.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Update(Feedback entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Update(FeedbackMapper.MapFeedbackEntityToFeedbackPersistence(entity));
                _context.SaveChanges();
            }
        }

        public IEnumerable<Feedback> GetByStatus(bool publish, bool approved)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(_context.Feedbacks.Where(p => p.Publish == publish && p.Approved == approved).ToList());
            }
        }

        public IEnumerable<Feedback> GetByParams(bool anonymous, bool approved)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(_context.Feedbacks.Where(p => p.Anonymous == anonymous && p.Approved == approved).ToList());
            }
        }

        public IEnumerable<Feedback> GetByAllParams(bool publish, bool anonymous, bool approved)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return FeedbackMapper.MapFeedbackPersistenceCollectionToFeedbackEntityCollection(_context.Feedbacks.Where(p => p.Publish == publish && p.Anonymous == anonymous && p.Approved == approved).ToList());
            }
        }
    }
}
