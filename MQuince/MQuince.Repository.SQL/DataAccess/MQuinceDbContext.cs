
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Appointment;
using MQuince.Repository.SQL.PersistenceEntities;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.SQL.DataAccess
{
    public class MQuinceDbContext : DbContext
    {
        public DbSet<FeedbackPersistence> Feedbacks { get; set; }
        public DbSet<AllergenPersistence> Allergens { get; set; }
        public DbSet<SpecializationPersistence> Specializations { get; set; }
        public DbSet<DoctorPersistence> Doctors { get; set; }
        public DbSet<PatientPersistence> Patients { get; set; }
        public DbSet<WorkTimePersistence> WorkTimes { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public MQuinceDbContext(DbContextOptions options) : base(options) {
            
        }
        public MQuinceDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=mquince;user=root;password=root;");
        }

    }
}
