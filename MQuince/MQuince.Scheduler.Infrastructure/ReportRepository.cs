using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.DataAccess;
using MQuince.Scheduler.Contracts.Repository;
using MQuince.Scheduler.Domain;
using MQuince.Scheduler.Infrastructure.Util;
using System;
using System.Linq;

namespace MQuince.Scheduler.Infrastructure
{
    public class ReportRepository : IReportRepository
    {
        private readonly DbContextOptions _dbContext;

        public ReportRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public Report GetReportForAppointment(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                 return ReportMapper.MapReportPersistenceToReportEntity(_context.Reports.SingleOrDefault(c => c.AppointmentPersistanceId.Equals(id)));
            }
        }
    }
}
