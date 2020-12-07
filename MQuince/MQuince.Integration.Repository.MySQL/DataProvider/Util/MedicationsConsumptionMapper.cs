﻿using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider.Util
{
    public class MedicationsConsumptionMapper
    {

        public static MedicationsConsumption MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(MedicationsConsumptionPersistance medicationsConsumptionPersistance)
        {
            if (medicationsConsumptionPersistance == null) throw new ArgumentNullException();

            return new MedicationsConsumption(medicationsConsumptionPersistance.KeyConsumtion,
                                                medicationsConsumptionPersistance.Name,
                                                medicationsConsumptionPersistance.DateOfConsumtion,
                                                medicationsConsumptionPersistance.Quantity);

        }

        public static MedicationsConsumptionPersistance MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(MedicationsConsumption medicationsConsumption)
        {
            if (medicationsConsumption == null) return null;

            MedicationsConsumptionPersistance retVal = new MedicationsConsumptionPersistance()
            {
                KeyConsumtion = medicationsConsumption.KeyConsumtion,
                Name = medicationsConsumption.Name,
                DateOfConsumtion = medicationsConsumption.DateOfConsumtion,
                Quantity = medicationsConsumption.Quantity
            };
            return retVal;
        }


        public static IdentifiableDTO<MedicationsConsumptionDTO> MapMedicationsConsumptionEntityToMedicationsConsumptionIdentifierDTO(MedicationsConsumption medicationsConsumption)
                => medicationsConsumption == null ? throw new ArgumentNullException()
                                            : new IdentifiableDTO<MedicationsConsumptionDTO>()
                                            {
                                                Key = medicationsConsumption.KeyConsumtion,
                                                EntityDTO = new MedicationsConsumptionDTO()
                                                {
                                                    Name = medicationsConsumption.Name,
                                                    DateOfConsumtion = medicationsConsumption.DateOfConsumtion,
                                                    Quantity = medicationsConsumption.Quantity
                                                }
                                            };
        public static IEnumerable<MedicationsConsumption> MapMedicationsConsumptionPersistanceCollectionToMedicationsConsumptationEntityCollection(IEnumerable<MedicationsConsumptionPersistance> clients)
           => clients.Select(c => MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(c));


    }
}