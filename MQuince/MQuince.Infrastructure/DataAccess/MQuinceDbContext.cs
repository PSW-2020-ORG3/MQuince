using Microsoft.EntityFrameworkCore;
using MQuince.Infrastructure.PersistenceEntities.Appointments;
using MQuince.Infrastructure.PersistenceEntities.Communication;
using MQuince.Infrastructure.PersistenceEntities.Drug;
using MQuince.Infrastructure.PersistenceEntities.Events.Feedback;
using MQuince.Infrastructure.PersistenceEntities.Events.Scheduler;
using MQuince.Infrastructure.PersistenceEntities.Users;
using System;

namespace MQuince.Infrastructure.DataAccess
{
    public class MQuinceDbContext : DbContext
    {

        public MQuinceDbContext(DbContextOptions options) : base(options)
        {

        }
        public MQuinceDbContext() { }

        public DbSet<FeedbackPersistence> Feedbacks { get; set; }
        public DbSet<AllergenPersistence> Allergens { get; set; }
        public DbSet<SpecializationPersistence> Specializations { get; set; }
        public DbSet<DoctorPersistence> Doctors { get; set; }
        public DbSet<PatientPersistence> Patients { get; set; }
        public DbSet<WorkTimePersistence> WorkTimes { get; set; }
        public DbSet<AppointmentPersistence> Appointments { get; set; }
        public DbSet<AdminPersistence> Admin { get; set; }
        public DbSet<ScheduleEventPersistence> ScheduleEvents { get; set; }
        public DbSet<FeedbackEventPersistence> FeedbackEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentPersistence>().OwnsOne(e => e.DateRange);

            modelBuilder.Entity<AdminPersistence>().HasData(new AdminPersistence[] {
                new AdminPersistence{
                    Id= Guid.Parse("be809f83-d599-4482-acea-0a4a422a411d"),
                    Username="admin",
                    Password="admin",
                    Jmbg="000000000000",
                    Name="Pera",
                    Surname="Djuric",
                },
                new AdminPersistence{
                    Id= Guid.Parse("28c51a88-870c-42ce-bf4c-b9ad68126784"),
                    Username="admin1",
                    Password="admin123",
                    Jmbg="1233211233211",
                    Name="Dusan",
                    Surname="Petrovic",
                }
            });

            modelBuilder.Entity<SpecializationPersistence>().HasData(new SpecializationPersistence[] {
                new SpecializationPersistence{Id=Guid.Parse("11b55bea-8dd3-4491-84a9-471bc7d28b19"),Name="Neurologija"},
                new SpecializationPersistence{Id=Guid.Parse("2f3c1c3e-9d67-4a0c-acc0-58f8f1fc4e77"),Name="Hirurg"},
                new SpecializationPersistence{Id=Guid.Parse("31b1522c-7343-4565-8bf5-9926d8c710d6"),Name="Pedijatrija"},
                new SpecializationPersistence{Id=Guid.Parse("503d2c35-3b1e-4f98-a443-52c0bbdfe5ba"),Name="Interna medicina"},
                new SpecializationPersistence{Id=Guid.Parse("6ae4064b-cb5b-4b63-9b92-7d4afd4d9ba3"),Name="Psihijatrija"},
                new SpecializationPersistence{Id=Guid.Parse("859642db-736b-4c17-a5d6-84e47a9abb47"),Name="Radiologija"}
            });

            modelBuilder.Entity<DoctorPersistence>().HasData(new DoctorPersistence[] {
                new DoctorPersistence{
                    Id= Guid.Parse("6dd84745-8fcb-4a4b-84da-fe215ebd2f85"),
                    Username="doctor1",
                    Password="doctor1",
                    Jmbg="1234567890123",
                    Name="Petar",
                    Surname="Petrovic",
                    Biography="",
                    SpecializationId=Guid.Parse("2f3c1c3e-9d67-4a0c-acc0-58f8f1fc4e77")
                },new DoctorPersistence{
                    Id= Guid.Parse("90450920-986a-42f4-89c2-a8a4e1a25151"),
                    Username="doctor2",
                    Password="doctor2",
                    Jmbg="0123456789123",
                    Name="Djura",
                    Surname="Djuric",
                    Biography="",
                    SpecializationId=Guid.Parse("2f3c1c3e-9d67-4a0c-acc0-58f8f1fc4e77")
                },new DoctorPersistence{
                    Id= Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32"),
                    Username="doctor3",
                    Password="doctor3",
                    Jmbg="1111111111111",
                    Name="Branimir",
                    Surname="Nestorovic",
                    Biography="",
                    SpecializationId=Guid.Parse("31b1522c-7343-4565-8bf5-9926d8c710d6")
                },new DoctorPersistence{
                    Id= Guid.Parse("36ca2cc1-852c-44d5-815b-206301f227fd"),
                    Username="doctor4",
                    Password="doctor4",
                    Jmbg="2222222222222",
                    Name="Nemanja",
                    Surname="Nemanjic",
                    Biography="",
                    SpecializationId=Guid.Parse("6ae4064b-cb5b-4b63-9b92-7d4afd4d9ba3")
                },new DoctorPersistence{
                    Id= Guid.Parse("cedece3e-bd21-49ab-bee6-17793b0449a9"),
                    Username="doctor5",
                    Password="doctor5",
                    Jmbg="3333333333333",
                    Name="Pera",
                    Surname="Peric",
                    Biography="",
                    SpecializationId=Guid.Parse("11b55bea-8dd3-4491-84a9-471bc7d28b19")
                },new DoctorPersistence{
                    Id= Guid.Parse("8f597ed4-f95e-4b3b-8f0d-b2e0d00a5e74"),
                    Username="doctor6",
                    Password="doctor6",
                    Jmbg="4444444444444",
                    Name="Danilo",
                    Surname="Danilovic",
                    Biography="",
                    SpecializationId=Guid.Parse("503d2c35-3b1e-4f98-a443-52c0bbdfe5ba")
                }
            });

            modelBuilder.Entity<WorkTimePersistence>().HasData(new WorkTimePersistence[] {
                new WorkTimePersistence{
                    Id= Guid.Parse("3296719d-0ca5-40c6-9370-90e50df28539"),
                    StartDate=new DateTime(2020,12,1),
                    EndDate=new DateTime(2020,12,25),
                    StartTime=8,
                    EndTime=16,
                    DoctorId=Guid.Parse("6dd84745-8fcb-4a4b-84da-fe215ebd2f85")
                },new WorkTimePersistence{
                    Id= Guid.Parse("26cee331-20e2-4ab7-ac54-8162a01481e3"),
                    StartDate=new DateTime(2020,12,26),
                    EndDate=new DateTime(2020,12,28),
                    StartTime=11,
                    EndTime=14,
                    DoctorId=Guid.Parse("6dd84745-8fcb-4a4b-84da-fe215ebd2f85")
                },new WorkTimePersistence{
                    Id= Guid.Parse("f37710fe-4724-4819-b405-88fc48759bb5"),
                    StartDate=new DateTime(2020,12,1),
                    EndDate=new DateTime(2020,12,20),
                    StartTime=8,
                    EndTime=13,
                    DoctorId=Guid.Parse("90450920-986a-42f4-89c2-a8a4e1a25151")
                },new WorkTimePersistence{
                    Id= Guid.Parse("f4c9b728-8c16-4587-9d03-37b718d82f79"),
                    StartDate=new DateTime(2020,12,1),
                    EndDate=new DateTime(2020,12,20),
                    StartTime=8,
                    EndTime=14,
                    DoctorId=Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")
                },new WorkTimePersistence{
                    Id= Guid.Parse("fa98f49c-5b7d-4135-938b-8a302ebcb866"),
                    StartDate=new DateTime(2020,12,21),
                    EndDate=new DateTime(2020,12,28),
                    StartTime=14,
                    EndTime=20,
                    DoctorId=Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")
                }
            });

            modelBuilder.Entity<PatientPersistence>().HasData(new PatientPersistence[] {
                new PatientPersistence{
                    Id= Guid.Parse("c1d9ae05-81aa-4203-a830-692383bfca09"),
                    Username="patient1",
                    Password="patient1",
                    Jmbg="55555555555555",
                    Name="Marjan",
                    Surname="Marjanovic",
                    Guest=false,
                    DoctorPersistanceId=Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")
                },new PatientPersistence{
                    Id= Guid.Parse("b7056fcc-48fa-4df5-9e93-334ab7595daa"),
                    Username="patient2",
                    Password="patient2",
                    Jmbg="6666666666666",
                    Name="Aleksandar",
                    Surname="Perovic",
                    Guest=false,
                    DoctorPersistanceId=Guid.Parse("0d619cf3-25d6-49b2-b4c4-1f70d3121b32")
                },new PatientPersistence{
                    Id= Guid.Parse("6459c216-1770-41eb-a56a-7f4524728546"),
                    Username="patient3",
                    Password="patient3",
                    Jmbg="7777777777777",
                    Name="Mirko",
                    Surname="Mirkovic",
                    Guest=false,
                    DoctorPersistanceId=Guid.Parse("90450920-986a-42f4-89c2-a8a4e1a25151")
                }
            });
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=localhost;user=root;password=root;database=mquince");
        }*/
    }
}
