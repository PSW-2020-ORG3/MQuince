using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities.UrgentProcurement;
using MQuince.UrgentProcurement.Contracts.DTO;
using MQuince.UrgentProcurement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.UrgentProcurement.Infrastructure.Util
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
                                                Id = medications.KeyMedication,
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
