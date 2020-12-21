using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Drug;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL
{
    public class AllergenRepository : IAllergenRepository
    {
        private readonly DbContextOptions _dbContext;

        public AllergenRepository(DbContextOptionsBuilder optionsBuilders)
        {
            _dbContext = optionsBuilders == null ? throw new ArgumentNullException(nameof(optionsBuilders) + "is set to null") : optionsBuilders.Options;
        }
        public void Create(Allergen entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Allergens.Add(AllergenMapper.MapAllergenEntityToAllergenPersistence(entity));
                _context.SaveChanges();
            }
        }

        public bool Delete(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                AllergenPersistence allergen = _context.Allergens.Find(id);
                if (allergen == null) return false; 

                _context.Allergens.Remove(allergen);
                _context.SaveChanges(); 
                return true;
            }
        }

        public IEnumerable<Allergen> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AllergenMapper.MapAllergenPersistenceCollectionToAllergenEntityCollection(_context.Allergens.ToList());
            }
        }

        public Allergen GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                return AllergenMapper.MapAllergenPersistenceToAllergenEntity(_context.Allergens.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Update(Allergen entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext(_dbContext))
            {
                _context.Update(AllergenMapper.MapAllergenEntityToAllergenPersistence(entity));
                _context.SaveChanges(); 
            }
        }
    }
}
