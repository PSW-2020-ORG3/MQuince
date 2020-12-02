using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider.Util
{
    public class PharmacyMapper
    {
        public static MyPharmacy MapPharmacyPersistenceToPharmacyEntity(PharmacyPersistence pharmacy)
        {
            if (pharmacy == null) return null;

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
    }
}
