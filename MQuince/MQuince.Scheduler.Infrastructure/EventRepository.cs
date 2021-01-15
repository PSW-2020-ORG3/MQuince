using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Domain.Events;
using MQuince.Scheduler.Infrastructure.Util;
using System;
using System.Collections.Generic;

namespace MQuince.Scheduler.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly DbContextOptions _dbContext;

        public EventRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(ScheduleEvent entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.ScheduleEvents.Add(EventMapper.MapScheduleEventEntityToScheduleEventPersistence(entity));
                _context.SaveChanges();
            }
        }

        public IEnumerable<ScheduleEvent> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
