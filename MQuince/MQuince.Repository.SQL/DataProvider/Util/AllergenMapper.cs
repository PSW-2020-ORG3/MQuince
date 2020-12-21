using MQuince.Entities.Drug;
using MQuince.Repository.SQL.PersistenceEntities.Drug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class AllergenMapper
    {
        public static Allergen MapAllergenPersistenceToAllergenEntity(AllergenPersistence allergen)
        {
            if (allergen == null) return null;

            return new Allergen(allergen.Id,allergen.Name);

        }

        public static AllergenPersistence MapAllergenEntityToAllergenPersistence(Allergen allergen)
        {
            if (allergen == null) return null;

            AllergenPersistence retVal = new AllergenPersistence() { Id = allergen.Id, Name = allergen.Name};
            return retVal;
        }

        public static IEnumerable<Allergen> MapAllergenPersistenceCollectionToAllergenEntityCollection(IEnumerable<AllergenPersistence> clients)
            => clients.Select(c => MapAllergenPersistenceToAllergenEntity(c));
    }
}
