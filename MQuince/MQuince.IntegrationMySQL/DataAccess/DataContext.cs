using Microsoft.EntityFrameworkCore;
using MQuince.IntegrationMySQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL.DataAccess
{
    public class DataContext : DbContext
    {
        private DbContextOptions options;

        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions options)
        {
            this.options = options;
        }

        public DbSet<PharmacyPersistence> Pharmacies { get; set; }
        public DbSet<MedicationsConsumptionPersistance> MedicationsConsumptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=pharmacydb");
        }
    }
}
