using MQuince.IntegrationMySQL.DataProvider;
using MQuince.IntegrationMySQL.PersistenceEntities;
using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTest
{
    public class MedicationsConsumptationMapperTest
    {
        [Fact]
        public void MapMedicationsConsumptationPersistenceToMedicationsConsumptationEntity_Given_null_should_be_null()
        {
            MedicationsConsumption medicationsConsumptation = MedicationsConsumptionMapper.MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(null);

            Assert.Null(medicationsConsumptation);
        }
        [Fact]
        public void MapMedicationsConsumptationPersistenceToMedicationsConsumptationEntity_Given_some_value_should_back_new_MyPharamcy()
        {

            var medicationsTest = new MedicationsConsumptionPersistance(new Guid(), "LekTest", new DateTime(2020, 11, 27), 2);

            MedicationsConsumption medicationsConsumptation = MedicationsConsumptionMapper.MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(medicationsTest);

            Assert.NotNull(medicationsConsumptation);
        }

        [Fact]
        public void MedicationsConsumptationEntityToMedicationsConsumptationPersistence_Given_null_should_be_null()
        {
            MedicationsConsumptionPersistance persistance = MedicationsConsumptionMapper.MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(null);

            Assert.Null(persistance);


        }

        [Fact]
        public void MedicationsConsumptationEntityToMedicationsConsumptationPersistence_Given_some_value_should_back_new_MedicationsConsumptation()
        {
            MedicationsConsumption medicationsTest = new MedicationsConsumption(new Guid(), "LekTest", new DateTime(2020, 11, 27), 2);

            MedicationsConsumptionPersistance persistance = MedicationsConsumptionMapper.MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(medicationsTest);

            Assert.NotNull(persistance);


        }

    }
}
