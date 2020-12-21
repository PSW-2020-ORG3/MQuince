using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class WorkTimeRepository : IWorkTimeRepository
    {
        private readonly DbContextOptions _dbContext;
        public WorkTimeRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<WorkTime> GetWorkTimesForDoctor(Guid doctorId)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                var workTimes = _context.WorkTimes.Where(entity => entity.Doctor.Id == doctorId);
                return WorkTimeMapper.MapWorkTimePersistenceCollectionToWorkTimeEntityCollection(workTimes.ToList());
            }
        }
    }
}
