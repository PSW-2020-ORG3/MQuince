using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Integration.Infrastructure.PersistenceEntities.UrgentProcurement;

namespace MQuince.Integration.Infrastructure.DataAccess
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
		public DbSet<MedicationsPersistence> Medications { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(@"server=localhost;user=root;password=Mucibabic*1;database=pharmacydb1");
		}
	}
}
