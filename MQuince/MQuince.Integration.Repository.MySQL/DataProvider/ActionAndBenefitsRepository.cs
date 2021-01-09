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
    public class ActionAndBenefitsRepository : IActionAndBenefitsRepository
    {
        private readonly DbContextOptions _dbContext;

        
        public ActionAndBenefitsRepository(DbContextOptionsBuilder optionsBuilders)
        {
           _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(ActionsAndBenefits entity)
        {
           using (DataContext _context = new DataContext())
           {
               _context.ActionAndBenefits.Add(ActionAndBenefitsMapper.MapActionsAndBenefitsEntityToActionsAndBenefitsPersistance(entity));
               _context.SaveChanges();
           }
        }

        public bool Delete(Guid id)
        {
           using (DataContext _context = new DataContext())
           {
               ActionAndBenefitsPersistance action = _context.ActionAndBenefits.Find(id);
               if (action == null) return false;

               _context.ActionAndBenefits.Remove(action);
               _context.SaveChanges();
               return true;
           }
        }

        public IEnumerable<ActionsAndBenefits> GetAll()
        {
           using (DataContext _context = new DataContext())
           {   
               return ActionAndBenefitsMapper.MapActionsAndBenefitsPersistanceCollectionToActionsAndBenefitsEntityCollection(_context.ActionAndBenefits.ToList());
           }
        }

        public ActionsAndBenefits GetById(Guid id)
        {
           using (DataContext _context = new DataContext())
           {
               return ActionAndBenefitsMapper.MapActionsAndBenefitsPersistenceToActionsAndBenefitsEntity(_context.ActionAndBenefits.SingleOrDefault(c => c.ActionKey.Equals(id)));
           }
        }

        public void Update(ActionsAndBenefits entity)
        {
           using (DataContext _context = new DataContext())
           {
               _context.Update(ActionAndBenefitsMapper.MapActionsAndBenefitsEntityToActionsAndBenefitsPersistance(entity));
               _context.SaveChanges();
           }
        }
            }
}
