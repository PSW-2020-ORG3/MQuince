using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Infrastructure.PersistenceEntities.Communication;

namespace MQuince.Infrastructure.DataAccess
{
    public class MQuinceDbContext : DbContext
    {
        public DbSet<AppointmentPersistence> Appointments { get; set; }
        public DbSet<FeedbackPersistence> Feedbacks { get; set; }

        public MQuinceDbContext(DbContextOptions options) : base(options)
        {

        }
        public MQuinceDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentPersistence>().OwnsOne(e => e.DateRange);
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=probicadb");
        }*/
    }
}
