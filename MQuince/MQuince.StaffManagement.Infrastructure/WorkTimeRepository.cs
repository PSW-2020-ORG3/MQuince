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
