using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Infrastructure.DataProvider.Util;
using MQuince.Review.Domain.Events;
using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Infrastructure.DataProvider
{
    public class EventRepository
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

        public void Create(ScheduleEvent entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.ScheduleEvents.Add(EventMapper.MapScheduleEventEntityToScheduleEventPersistence(entity));
                _context.SaveChanges();
            }
        }
    }
}
