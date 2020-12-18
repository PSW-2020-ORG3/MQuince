using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Integration.Services.Implementation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Integration.HospitalApp.Tests.ServiceTest
{
   
    public class MedicationsConsumptionServiceTests
    {
        IMedicationsConsumptionService medicationService;
        IMedicationsConsumptionRepository medicationRepository = Substitute.For<IMedicationsConsumptionRepository>();

        public MedicationsConsumptionServiceTests()
        {
            medicationService = new MedicationsConsumptationService(medicationRepository);
        }


        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IMedicationsConsumptionService medicationsConsumptionService = new MedicationsConsumptationService(medicationRepository);

            Assert.IsType<MedicationsConsumptationService>(medicationsConsumptionService);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new MedicationsConsumptationService(null));
        }

        [Fact]
        public void Get_all_returns_data()
        {
            medicationRepository.GetAll().Returns(this.GetListOfMedicationsConsumption());

            List<IdentifiableDTO<MedicationsConsumptionDTO>> returnedList = medicationService.GetAll().ToList();

            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public void Get_by_id_returns_medications()
        {
            medicationRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(this.GetFirstMedication());

            IdentifiableDTO<MedicationsConsumptionDTO> medication = medicationService.GetByApi(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"));

            Assert.True(this.CompareMedicationAndIdentifierMedication(this.GetFirstMedication(), medication));
        }
               



        private MedicationsConsumption GetFirstMedication()
           => new MedicationsConsumption()
           {
               Name = "Andol",
               DateOfConsumtion = new DateTime(2020,12,20),
               Quantity = 3,
              
           };

        private MedicationsConsumption GetSecondMedication()
           => new MedicationsConsumption()
           {
               Name = "Buscopan",
               DateOfConsumtion = new DateTime(2020, 12, 27),
               Quantity = 2,

           };

        private List<MedicationsConsumption> GetListOfMedicationsConsumption()
        {
            List<MedicationsConsumption> listOfMedicationsConsumption = new List<MedicationsConsumption>()
            {
                this.GetFirstMedication(),
                this.GetSecondMedication()
            };

            return listOfMedicationsConsumption;
        }


        private bool CompareMedicationAndIdentifierMedication(MedicationsConsumption medication, IdentifiableDTO<MedicationsConsumptionDTO> identifierMedication)
        {
            if (medication.KeyConsumtion != identifierMedication.Key)
                return false;

            if (!medication.Name.Equals(identifierMedication.EntityDTO.Name))
                return false;

            if (!medication.DateOfConsumtion.Equals(identifierMedication.EntityDTO.DateOfConsumtion))
                return false;

            if (!medication.Quantity.Equals(identifierMedication.EntityDTO.Quantity))
                return false;            

            return true;
        }

    }
}
