using Hospital.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using MQuince.IntegrationMySQL;
using MQuince.IntegrationMySQL.DataAccess;
using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Interfaces;
using MQuince.IntegrationMySQL.PersistenceEntities;
using MQuince.IntegrationMySQL.Pharmacy;
using MQuince.IntegrationMySQL.Repository;
using MQuince.IntegrationMySQL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HospitalAppTest
{
    public class OperationsWithDatabaseTest
    {/*
        private PharmacyController pharmacyController;
        private IPharmacyServices pharmacyService;
        private IPharmacyRepository pharmacyRepository;

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "pharmacydb");

            pharmacyRepository = new PharmacyRepository(optionsBuilder);
            using (var dataBase = new DataContext(optionsBuilder.Options))
            {
                dataBase.Database.EnsureDeleted();
                dataBase.Database.EnsureCreated();

                PharmacyPersistence p1 = new PharmacyPersistence()
                {
                    ApiKey = new Guid(),
                    Name = "Pharmacy_test1"
                };
                PharmacyPersistence p2 = new PharmacyPersistence()
                {
                    ApiKey = new Guid(),
                    Name = "Pharmacy_test2"
                };
                dataBase.Pharmacies.AddRange(p1, p2);
                dataBase.SaveChanges();
            }
        }

        public OperationsWithDatabaseTest()
        {
            InitDB();
            pharmacyService = new PharmacyServices(pharmacyRepository);
            pharmacyController = new PharmacyController(pharmacyService);
        }

        [Fact]
        public void Test1()
        {    InitDB(); 
            PharmacyDTO p3 = new PharmacyDTO()
            {
                Name = "Pharmacy_name_3"
            };

            List<MyPharmacy> pharmacies = pharmacyRepository.GetAll().ToList();

            Assert.Equal(3, pharmacies.Count());
        }

        */
        [Fact]
        public void Create_entity_in_mock_database()
        {
            var stubRepository = new Mock<IPharmacyRepository>();

            PharmacyDTO pharmacy = new PharmacyDTO()
            {
                Name = "some_name"
            };

            PharmacyServices service = new PharmacyServices(stubRepository.Object);

            Assert.NotNull(service.Create(pharmacy));

        }
        
    }
}
