using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Appointment;
using MQuince.Repository.Contracts;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
