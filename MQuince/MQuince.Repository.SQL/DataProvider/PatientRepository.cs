using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbContextOptions _dbContext;
        public PatientRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public Patient GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
