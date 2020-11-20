using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider
{
    public class DoctorSurveyRepository : IDoctorSurveyRepository
    {
        private readonly DbContextOptions _dbContext;
        public DoctorSurveyRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public void Create(DoctorSurvey entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.DoctorSurveys.Add(DoctorSurveyMapper.MapDoctorSurveyEntityToDoctorSurveyPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorSurvey> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return DoctorSurveyMapper.MapDoctorSurveyPersistenceCollectionToDoctorSurveyEntityCollection(_context.DoctorSurveys.Include("Question").ToList());
            }
        }

        public DoctorSurvey GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorSurvey entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Update(DoctorSurveyMapper.MapDoctorSurveyEntityToDoctorSurveyPersistence(entity));
                _context.SaveChanges();
            }
        }
    }
}
