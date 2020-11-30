using Microsoft.EntityFrameworkCore;
using MQuince.IntegrationMySQL.DataAccess;
using MQuince.IntegrationMySQL.DataProvider;
using MQuince.IntegrationMySQL.PersistenceEntities;
using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.IntegrationMySQL.Repository
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
                _context.SaveChanges(); //ako ne sacuvamo nece se update-ovati baza
            }
        }

        public bool Delete(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                PharmacyPersistence pharmacy = _context.Pharmacies.Find(id);
                if (pharmacy == null) return false; //ako ne pronadjemo id, operacija nije uspesna

                _context.Pharmacies.Remove(pharmacy);
                _context.SaveChanges(); // cuvamo promene
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

        public IEnumerable<MyPharmacy> GetByApi(bool publish)
        {
            throw new NotImplementedException();
        }

        public MyPharmacy GetById(Guid id)
        {
            using (DataContext _context = new DataContext())
            {
                //pomocu lambda izraza se izvuce farmacija sa API-jem koji je isti kao prosledjeni
                //isti rezultat ima i foreach gde se unutar nekog if-a porede API-jevi
                return PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(_context.Pharmacies.SingleOrDefault(c => c.ApiKey.Equals(id)));
            }
        }

        public void Update(MyPharmacy entity)
        {
            using (DataContext _context = new DataContext())
            {
                //Entity Framework ce po id-ju naci feedback i azurirati ga
                _context.Update(PharmacyMapper.MapPharmacyEntityToPharmacyPersistence(entity));
                _context.SaveChanges(); //moramo sacuvati promene
            }
        }

        public IEnumerable<MyPharmacy> GetByAllParams(string name,string url, Guid api)
        {
            using (DataContext _context = new DataContext())
            {
                return PharmacyMapper.MapPharmacyPersistenceCollectionToPharmacyEntityCollection(_context.Pharmacies.Where(p => p.Name == name && p.Url == url && p.ApiKey == api).ToList());
            }
        }

        public IEnumerable<MyPharmacy> GetByAllParams()
        {
            throw new NotImplementedException();
        }
        
    }
}
