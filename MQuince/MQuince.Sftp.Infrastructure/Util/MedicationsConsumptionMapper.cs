using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Sftp.Constracts.DTO;
using MQuince.Sftp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQuince.Sftp.Infrastructure.Util
{
    public class MedicationsConsumptionMapper    {

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
                                                Id = medicationsConsumption.KeyConsumtion,
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
