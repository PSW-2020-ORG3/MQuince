using Moq;
using MQuince.IntegrationMySQL;
using MQuince.IntegrationMySQL.DataProvider;
using MQuince.IntegrationMySQL.PersistenceEntities;
using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTest
{
    public class PharmacyMapperTest
    {
        [Fact]
        public void MapPharmacyPersistenceToPharmacyEntity_Given_null_should_be_null()
        {
            MyPharmacy pharmacy = PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(null);
            
            Assert.Null(pharmacy);
        }
        [Fact]
        public void MapPharmacyPersistenceToPharmacyEntity_Given_some_value_should_back_new_MyPharamcy()
        {
           
            var pharmacyTest = new PharmacyPersistence(new Guid(), "ApotekaTest","aa.com");
                         
            MyPharmacy pharmacy = PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(pharmacyTest);
            
            Assert.NotNull(pharmacy);
        }

        [Fact]
        public void MapPharmacyEntityToPharmacyPersistence_Given_null_should_be_null()
        {
            PharmacyPersistence persistance = PharmacyMapper.MapPharmacyEntityToPharmacyPersistence(null);

            Assert.Null(persistance);


        }

        [Fact]
        public void MapPharmacyEntityToPharmacyPersistence_Given_some_value_should_back_new_MyPharamcy()
        {
            MyPharmacy pharmacy = new MyPharmacy(new Guid(), "ApotekaTest", "aa.com");

            PharmacyPersistence pharmacyPersistance = PharmacyMapper.MapPharmacyEntityToPharmacyPersistence(pharmacy);

            Assert.NotNull(pharmacyPersistance);


        }
    }
}
