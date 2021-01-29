using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Review.Contracts.Repository;
using MQuince.Review.Domain.Events;
using MQuince.Review.Infrastructure.Util;
using System;

namespace MQuince.Review.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly DbContextOptions _dbContext;

        public EventRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(FeedbackEvent entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.FeedbackEvents.Add(EventMapper.MapFeedbackEventEntityToFeedbackEventPersistence(entity));
                _context.SaveChanges();
            }
        }
    }
}
