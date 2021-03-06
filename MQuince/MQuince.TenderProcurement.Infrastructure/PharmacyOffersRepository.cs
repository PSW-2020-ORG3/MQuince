﻿using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Infrastructure.DataAccess;
using MQuince.Integration.Infrastructure.PersistenceEntities.TenderProcurement;
using MQuince.TenderProcurement.Contracts.Repository;
using MQuince.TenderProcurement.Domain;
using MQuince.TenderProcurement.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.TenderProcurement.Infrastructure
{
    public class PharmacyOffersRepository : IPharmacyOffersRepository
    {
        private readonly DbContextOptions _dbContext;

        public PharmacyOffersRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(PharmacyOffers entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.PharmacyOffers.Add(PharmacyOffersMapper.MapPharmacyOffersEntityToPharmacyOffersPersistance(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                PharmacyOffersPersistance pharmacyOffers = _context.PharmacyOffers.Find(id);
                if (pharmacyOffers == null) return false;

                _context.PharmacyOffers.Remove(pharmacyOffers);
                _context.SaveChanges();
                return true;
            }
        }

        public IEnumerable<PharmacyOffers> GetAll()
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyOffersMapper.MapPharmacyOffersPersistanceCollectionToPharmacyOffersEntityCollection(_context.PharmacyOffers.ToList());
            }
        }

        public PharmacyOffers GetById(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyOffersMapper.MapPharmacyOffersPersistenceToPharmacyOffersEntity(_context.PharmacyOffers.SingleOrDefault(c => c.IdOffer.Equals(id)));
            }
        }

        public void Update(PharmacyOffers entity)
        {
            using (DataContext _context = new DataContext())
            {
                _context.Update(PharmacyOffersMapper.MapPharmacyOffersEntityToPharmacyOffersPersistance(entity));
                _context.SaveChanges();
            }
        }
    }
}
