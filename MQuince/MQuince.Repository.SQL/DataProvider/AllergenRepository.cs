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
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                _context.Allergens.Add(AllergenMapper.MapAllergenEntityToAllergenPersistence(entity));
                _context.SaveChanges(); //ako ne sacuvamo nece se update-ovati baza
            }
        }

        public bool Delete(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                AllergenPersistence allergen = _context.Allergens.Find(id);
                if (allergen == null) return false; //u principu vracamo true ili false, kao indikator uspesnosti operacije, ako ne pronadjemo id, operacija nije uspesna

                _context.Allergens.Remove(allergen);
                _context.SaveChanges(); // cuvamo promene
                return true;
            }
        }

        public IEnumerable<Allergen> GetAll()
        {
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                return AllergenMapper.MapAllergenPersistenceCollectionToAllergenEntityCollection(_context.Allergens.ToList());
            }
        }

        public Allergen GetById(Guid id)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                //pomocu lambda izraza se izvuce korisnik sa Id-jem koji je isti kao prosledjeni
                //isti rezultat ima i foreach gde se unutar nekog if-a porede id-jevi
                return AllergenMapper.MapAllergenPersistenceToAllergenEntity(_context.Allergens.SingleOrDefault(c => c.Id.Equals(id)));
            }
        }

        public void Update(Allergen entity)
        {
            using (MQuinceDbContext _context = new MQuinceDbContext())
            {
                //Entity Framework ce po id-ju naci feedback i azurirati ga
                _context.Update(AllergenMapper.MapAllergenEntityToAllergenPersistence(entity));
                _context.SaveChanges(); //moramo sacuvati promene
            }
        }
    }
}
