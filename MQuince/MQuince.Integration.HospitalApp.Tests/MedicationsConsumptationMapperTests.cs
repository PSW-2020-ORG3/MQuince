using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Sftp.Constracts.DTO;
using MQuince.Sftp.Domain;
using MQuince.Sftp.Infrastructure.Util;
using System;
using Xunit;

namespace MQuince.HospitalAppTests
{
    public class MedicationsConsumptationMapperTests
    {
        [Fact]
        public void Map_medications_consumption_persistence_to_medications_consumption_entity()
        {
            MedicationsConsumptionPersistance medicationsConsumptionPersistance = this.GetPMedicationsConsumptionPersistence();

            MedicationsConsumption pharmacy = MedicationsConsumptionMapper.MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(medicationsConsumptionPersistance);

            Assert.True(IsEqualedicationsConsumptionPersistanceAndedicationsConsumptionEntity(medicationsConsumptionPersistance, pharmacy));
        }

        [Fact]
        public void Map_medications_consumption_persistence_to_medications_consumption_entity_when_medications_consumption_persistance_is_null()
        {
            MedicationsConsumptionPersistance medicationsConsumptionPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => MedicationsConsumptionMapper.MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(medicationsConsumptionPersistance));
        }


        [Fact]
        public void Map_medications_consumptiony_entity_to_medications_consumption_identifier_dto()
        {
            MedicationsConsumption medicationsConsumption = this.GetMedicationsConsumption();

            IdentifiableDTO<MedicationsConsumptionDTO> medicationsConsumptionDTO = MedicationsConsumptionMapper.MapMedicationsConsumptionEntityToMedicationsConsumptionIdentifierDTO(medicationsConsumption);

            Assert.True(IsEqualedicationsConsumptionPersistanceAndedicationsConsumptionEntity(medicationsConsumptionDTO, medicationsConsumption));
        }
       
        
        private bool IsEqualedicationsConsumptionPersistanceAndedicationsConsumptionEntity(MedicationsConsumptionPersistance medicationsConsumptionPersistence, MedicationsConsumption medicationsConsumption)
        {
            if (medicationsConsumption.KeyConsumtion != medicationsConsumptionPersistence.KeyConsumtion)
                return false;

            if (!medicationsConsumption.Name.Equals(medicationsConsumptionPersistence.Name))
                return false;

            if (medicationsConsumption.DateOfConsumtion != medicationsConsumptionPersistence.DateOfConsumtion)
                return false;

            if (medicationsConsumption.Quantity != medicationsConsumptionPersistence.Quantity)
                return false;

            return true;
        }

        private MedicationsConsumptionPersistance GetPMedicationsConsumptionPersistence()
            => new MedicationsConsumptionPersistance()
            {
                KeyConsumtion = Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"),
                Name = "Pharmacy1",
                DateOfConsumtion = new DateTime(2020, 10, 10),
                Quantity = 5
            };
        public bool IsEqualedicationsConsumptionPersistanceAndedicationsConsumptionEntity(IdentifiableDTO<MedicationsConsumptionDTO> medicationsConsumptionDTO, MedicationsConsumption medicationsConsumption)
        {

            if (medicationsConsumption.KeyConsumtion != medicationsConsumptionDTO.Id)
                return false;

            if (!medicationsConsumption.Name.Equals(medicationsConsumptionDTO.EntityDTO.Name))
                return false;

            if (medicationsConsumption.DateOfConsumtion != medicationsConsumptionDTO.EntityDTO.DateOfConsumtion)
                return false;

            if (medicationsConsumption.Quantity != medicationsConsumptionDTO.EntityDTO.Quantity)
                return false;

            return true;
        }

        private MedicationsConsumption GetMedicationsConsumption()
            => new MedicationsConsumption()
            {
                KeyConsumtion = Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"),
                Name = "Pharmacy1",
                DateOfConsumtion = new DateTime(2020,10,10),
                Quantity=5

            };
    }
}