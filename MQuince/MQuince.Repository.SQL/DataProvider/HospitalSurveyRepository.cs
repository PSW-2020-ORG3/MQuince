using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Repository.SQL.DataProvider
{
    public class HospitalSurveyRepository : IHospitalSurveyRepository
    {
        private readonly DbContextOptions _dbContext;

        public HospitalSurveyRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }

        public void Create(HospitalSurvey entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.HospitalSurveys.Add(HospitalSurveyMapper.MapHospitalSurveyEntityToHospitalSurveyPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HospitalSurvey> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return HospitalSurveyMapper.MapHospitalSurveyPersistenceCollectionToHospitalSurveyEntityCollection(_context.HospitalSurveys.Include("Question").ToList());
            }
        }

        public HospitalSurvey GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(HospitalSurvey entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Update(HospitalSurveyMapper.MapHospitalSurveyEntityToHospitalSurveyPersistence(entity));
                _context.SaveChanges();
            }
        }
    }
}
