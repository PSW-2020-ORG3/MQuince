﻿using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Infrastructure.DataAccess;
using MQuince.Integration.Infrastructure.PersistenceEntities.UrgentProcurement;
using MQuince.UrgentProcurement.Contracts.Repository;
using MQuince.UrgentProcurement.Domain;
using MQuince.UrgentProcurement.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.UrgentProcurement.Infrastructure
{
    public class MedicationsRepository : IMedicationsRepository
    {

        private readonly DbContextOptions _dbContext;

        public MedicationsRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }


        public void Create(Medications entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Medications.Add(MedicationsMapper.MapMedicationsEntityToMedicationsPersistance(entity));
                _context.SaveChanges();
            }
        }


        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                MedicationsPersistence medications = _context.Medications.Find(id);
                if (medications == null) return false;

                _context.Medications.Remove(medications);
                _context.SaveChanges();
                return true;
            }
        }



        public bool DeleteByName(string name)
        {
            using (DataContext _context = new DataContext())
            {
                MedicationsPersistence medications = _context.Medications.Find(name);
                if (medications == null) return false;

                _context.Medications.Remove(medications);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Medications> GetAll()
        {
            using (DataContext _context = new DataContext())
            {
                return MedicationsMapper.MapMedicationsPersistanceCollectionToMedicationsEntityCollection(_context.Medications.ToList());
            }
        }


        public Medications GetById(Guid id)
        {

            using (DataContext _context = new DataContext())
            {
                return MedicationsMapper.MapMedicationsPersistenceToMedicationsEntity(_context.Medications.SingleOrDefault(c => c.KeyMedication.Equals(id)));
            }
        }

        public Medications GetByName(string Name)
        {
            using (DataContext _context = new DataContext())
            {
                return MedicationsMapper.MapMedicationsPersistenceToMedicationsEntity(_context.Medications.SingleOrDefault(c => c.Name.Equals(Name)));
            }

        }

        public void Update(Medications entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Update(MedicationsMapper.MapMedicationsEntityToMedicationsPersistance(entity));
                _context.SaveChanges();
            }
        }



    }

}
