﻿using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Repository.MySQL.DataAccess;
using MQuince.Integration.Repository.MySQL.DataProvider.Util;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider
{
    public class MedicationsConsumptionRepository : IMedicationsConsumptionRepository
    {
        private readonly DbContextOptions _dbContext;

        public MedicationsConsumptionRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }


        public void Create(MedicationsConsumption entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.MedicationsConsumptions.Add(MedicationsConsumptionMapper.MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                MedicationsConsumptionPersistance medicationsConsumptions = _context.MedicationsConsumptions.Find(id);
                if (medicationsConsumptions == null) return false;

                _context.MedicationsConsumptions.Remove(medicationsConsumptions);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<MedicationsConsumption> GetAll()
        {
            using (DataContext _context = new DataContext())
            {
                return MedicationsConsumptionMapper.MapMedicationsConsumptionPersistanceCollectionToMedicationsConsumptationEntityCollection(_context.MedicationsConsumptions.ToList());
            }
        }

        public MedicationsConsumption GetById(Guid id)
        {

            using (DataContext _context = new DataContext())
            {
                return MedicationsConsumptionMapper.MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(_context.MedicationsConsumptions.SingleOrDefault(c => c.KeyConsumtion.Equals(id)));
            }
        }


        public void Update(MedicationsConsumption entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Update(MedicationsConsumptionMapper.MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(entity));
                _context.SaveChanges();
            }
        }
    }
}
