using MQuince.IntegrationMySQL.PersistenceEntities;
using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.IntegrationMySQL.DataProvider
{
    public class MedicationsConsumptionMapper
    {
        public static MedicationsConsumption MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(MedicationsConsumptionPersistance medicationsConsumptionPersistance)
        {
            if (medicationsConsumptionPersistance == null) return null;

            return new MedicationsConsumption(medicationsConsumptionPersistance.KeyConsumtion,
                                                medicationsConsumptionPersistance.Name,
                                               medicationsConsumptionPersistance.DateOfConsumtion,
                                                medicationsConsumptionPersistance.Quantity);

        }
        
        public static MedicationsConsumptionPersistance MapMedicationsConsumptionEntityToMedicationsConsumptionPersistance(MedicationsConsumption medicationsConsumption)
        {
            if (medicationsConsumption == null) return null;

            MedicationsConsumptionPersistance retVal = new MedicationsConsumptionPersistance() { KeyConsumtion = medicationsConsumption.getKeyConsumtion, 
                                                                     Name = medicationsConsumption.Name,
                                                                     DateOfConsumtion = medicationsConsumption.DateOfConsumtion,
                                                                     Quantity = medicationsConsumption.Quantity    };
            return retVal;
        }
        

       
        public static IEnumerable<MedicationsConsumption> MapMedicationsConsumptionPersistanceCollectionToMedicationsConsumptationEntityCollection(IEnumerable<MedicationsConsumptionPersistance> clients)
           => clients.Select(c => MapMedicationsConsumptionPersistenceToMedicationsConsumptionEntity(c));


    }
}
