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
    public class TenderRepository : ITenderRepository
    {
        private readonly DbContextOptions _dbContext;

        public TenderRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(Tender entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Tenders.Add(TenderMapper.MapTenderEntityToTenderPersistance(entity));
                _context.SaveChanges();
                Console.WriteLine("uslo tu");
            }
        }

        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                TenderPersistance tender = _context.Tenders.Find(id);
                if (tender == null) return false;

                _context.Tenders.Remove(tender);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<Tender> GetAll()
        {
            using (DataContext _context = new DataContext())
            {
                return TenderMapper.MapTenderPersistanceCollectionToTenderEntityCollection(_context.Tenders.ToList());
            }
        }

        public Tender GetById(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                return TenderMapper.MapTenderPersistenceToTenderEntity(_context.Tenders.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Update(Tender entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Update(TenderMapper.MapTenderEntityToTenderPersistance(entity));
                _context.SaveChanges();
                
            }
        }
    }
}
