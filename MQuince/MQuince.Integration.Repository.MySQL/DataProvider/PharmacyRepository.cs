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
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly DbContextOptions _dbContext;

        public PharmacyRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(MyPharmacy entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Pharmacies.Add(PharmacyMapper.MapPharmacyEntityToPharmacyPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                PharmacyPersistence pharmacy = _context.Pharmacies.Find(id);
                if (pharmacy == null) return false;

                _context.Pharmacies.Remove(pharmacy);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<MyPharmacy> GetAll()
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyMapper.MapPharmacyPersistenceCollectionToPharmacyEntityCollection(_context.Pharmacies.ToList());
            }
        }

        public MyPharmacy GetById(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(_context.Pharmacies.SingleOrDefault(c => c.ApiKey.Equals(id)));
            }
        }

        public void Update(MyPharmacy entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Update(PharmacyMapper.MapPharmacyEntityToPharmacyPersistence(entity));
                _context.SaveChanges();
            }
        }

        public IEnumerable<MyPharmacy> GetByAllParams(string name, string url, Guid api)
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyMapper.MapPharmacyPersistenceCollectionToPharmacyEntityCollection(_context.Pharmacies.Where(p => p.Name == name && p.Url == url && p.ApiKey == api).ToList());
            }
        }
    }
 }
