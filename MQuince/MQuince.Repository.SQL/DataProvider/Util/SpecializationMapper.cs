using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class SpecializationMapper
    {
        public static Specialization MapSpecializationPersistenceToSpecializationEntity(SpecializationPersistence specialization)
              => specialization == null ? throw new ArgumentNullException()
                                        : new Specialization(specialization.Id, specialization.Name);


        public static IEnumerable<Specialization> MapSpecializationPersistenceCollectionToSpecializationEntityCollection(IEnumerable<SpecializationPersistence> specializations)
              => specializations == null ? throw new ArgumentNullException()
                                         : specializations.Select(entity => MapSpecializationPersistenceToSpecializationEntity(entity));
    }
}
