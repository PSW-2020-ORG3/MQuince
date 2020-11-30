using Moq;
using MQuince.IntegrationMySQL.Pharmacy;
using MQuince.IntegrationMySQL.Repository;
using MQuince.IntegrationMySQL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalAppTest
{
    public class MedicationsConsumptation_DateOfUsageTest
    {   
        [Fact]
        public  void Date_when_some_medications_are_used()
        {
            MedicationsConsumptationService medicationService = new MedicationsConsumptationService(CreateStubRepository());

            List<MedicationsConsumption> medicationReporst = (List<MedicationsConsumption>)medicationService.getConsumptionBetweenDates(new DateTime(2020, 10, 09), new DateTime(2020, 10, 15));

            Assert.NotEmpty(medicationReporst);

        }
        [Fact]
        public void Date_when_some_medications_are_not_used()
        {
            MedicationsConsumptationService medicationService = new MedicationsConsumptationService(CreateStubRepository());

            List<MedicationsConsumption> medicationReporst = (List<MedicationsConsumption>)medicationService.getConsumptionBetweenDates(new DateTime(2020, 09, 02), new DateTime(2020, 09, 05));

            Assert.Empty(medicationReporst);

        }

        [Fact]




        private static IMedicationsConsumptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IMedicationsConsumptionRepository>();
            List<MedicationsConsumption> listOfMedicationsConsumption = new List<MedicationsConsumption>();

            var medicationsConsumptation_vol1 = new MedicationsConsumption(new Guid(), "Brufen", new DateTime(2020, 11, 03), 10);
            var medicationsConsumptation_vol2 = new MedicationsConsumption(new Guid(), "Andol", new DateTime(2020, 11, 04), 1);
            var medicationsConsumptation_vol3 = new MedicationsConsumption(new Guid(), "Penicilin", new DateTime(2020, 11, 03), 2);
            var medicationsConsumptation_vol4 = new MedicationsConsumption(new Guid(), "Buscopan", new DateTime(2020, 11, 01), 10);
            var medicationsConsumptation_vol5 = new MedicationsConsumption(new Guid(), "Brufen", new DateTime(2020, 10, 10), 4);
            var medicationsConsumptation_vol6 = new MedicationsConsumption(new Guid(), "Andol", new DateTime(2020, 10, 12), 1);

            listOfMedicationsConsumption.Add(medicationsConsumptation_vol1);
            listOfMedicationsConsumption.Add(medicationsConsumptation_vol2);
            listOfMedicationsConsumption.Add(medicationsConsumptation_vol3);
            listOfMedicationsConsumption.Add(medicationsConsumptation_vol4);
            listOfMedicationsConsumption.Add(medicationsConsumptation_vol5);
            listOfMedicationsConsumption.Add(medicationsConsumptation_vol6);

            stubRepository.Setup(a => a.GetAll()).Returns(listOfMedicationsConsumption);

            return stubRepository.Object;

        }
        

    }
}
