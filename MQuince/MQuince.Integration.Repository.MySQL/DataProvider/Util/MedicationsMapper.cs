using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider.Util
{
    public class MedicationsMapper
    {
        public static Medications MapMedicationsPersistenceToMedicationsEntity(MedicationsPersistence medicationsPersistance)
        {
            if (medicationsPersistance == null) throw new ArgumentNullException();

            return new Medications(medicationsPersistance.KeyMedication,
                                                medicationsPersistance.Name,
                                                medicationsPersistance.Quantity);

        }

        public static MedicationsPersistence MapMedicationsEntityToMedicationsPersistance(Medications medications)
        {
            if (medications == null) return null;

            MedicationsPersistence retVal = new MedicationsPersistence()
            {
                KeyMedication = medications.KeyMedication,
                Name = medications.Name,
                Quantity = medications.Quantity
            };
            return retVal;
        }


        public static IdentifiableDTO<MedicationsDTO> MapMedicationsEntityToMedicationsIdentifierDTO(Medications medications)
                => medications == null ? throw new ArgumentNullException()
                                            : new IdentifiableDTO<MedicationsDTO>()
                                            {
                                                Key = medications.KeyMedication,
                                                EntityDTO = new MedicationsDTO()
                                                {
                                                    Name = medications.Name,
                                                    Quantity = medications.Quantity
                                                }
                                            };
        public static IEnumerable<Medications> MapMedicationsPersistanceCollectionToMedicationsEntityCollection(IEnumerable<MedicationsPersistence> clients)
           => clients.Select(c => MapMedicationsPersistenceToMedicationsEntity(c));



    }
}
