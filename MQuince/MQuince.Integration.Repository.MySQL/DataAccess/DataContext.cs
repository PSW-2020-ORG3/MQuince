using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataAccess
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
        public DbSet<ActionAndBenefitsPersistance> ActionAndBenefits { get; set; }
        public DbSet<MedicationsPersistence> Medications{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=Mucibabic*1;database=pharmacydb1");
        }
    }
}
