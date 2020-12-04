using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Appointment;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DbContextOptions _dbContext;

        public AppointmentRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AppointmentMapper.MapAppointmentPersistenceCollectionToAppointmentEntityCollection(_context.Appointments.ToList());
            }
        }

        public Appointment GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                var appointment = _context.Appointments.Include("AppointmentPersistance").SingleOrDefault(c => c.Id.Equals(id));
                return AppointmentMapper.MapAppointmentPersistenceToAppointmentEntity(appointment);
            }
        }
    }
}
