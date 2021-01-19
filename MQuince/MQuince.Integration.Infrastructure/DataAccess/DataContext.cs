using Microsoft.EntityFrameworkCore;
using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Integration.Infrastructure.PersistenceEntities.ActionAndBenefits;
using MQuince.Integration.Infrastructure.PersistenceEntities.TenderProcurement;
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

		public DbSet<MedicationsConsumptionPersistance> MedicationsConsumptions { get; set; }

		public DbSet<MedicationsPersistence> Medications { get; set; }
		public DbSet<TenderPersistance> Tenders { get; set; }
		public DbSet<PharmacyOffersPersistance> PharmacyOffers { get; set; }

		public DbSet<ActionAndBenefitsPersistance> ActionAndBenefits { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=pharmacydb2");
		}
		

	
	}
}
