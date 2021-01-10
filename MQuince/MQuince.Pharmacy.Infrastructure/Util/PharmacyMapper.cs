using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Pharmacy.Contracts.DTO;
using MQuince.Pharmacy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Pharmacy.Infrastructure.Util
{
    public class PharmacyMapper
    {
        public static MyPharmacy MapPharmacyPersistenceToPharmacyEntity(PharmacyPersistence pharmacy)
        {
            if (pharmacy == null) throw new ArgumentNullException();

            return new MyPharmacy(pharmacy.ApiKey, pharmacy.Name, pharmacy.Url);

        }

        public static PharmacyPersistence MapPharmacyEntityToPharmacyPersistence(MyPharmacy pharmacy)
        {
            if (pharmacy == null) return null;

            PharmacyPersistence retVal = new PharmacyPersistence()
            {
                ApiKey = pharmacy.ApiKey,
                Name = pharmacy.Name,
                Url = pharmacy.Url
            };
            return retVal;
        }
       
        public static IEnumerable<MyPharmacy> MapPharmacyPersistenceCollectionToPharmacyEntityCollection(IEnumerable<PharmacyPersistence> clients)
            => clients.Select(c => MapPharmacyPersistenceToPharmacyEntity(c));

        public static IdentifiableDTO<PharmacyDTO> MapPhamracyEntityToPharmacyIdentifierDTO(MyPharmacy pharmacy)
         => pharmacy == null ? throw new ArgumentNullException()
                                      : new IdentifiableDTO<PharmacyDTO>
                                      {                                         
                                          EntityDTO = new PharmacyDTO()
                                          {
                                              ApiKey = pharmacy.ApiKey,
                                              Name = pharmacy.Name,
                                              Url = pharmacy.Url
                                              
                                          }
                                      };
    }
}
