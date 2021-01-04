
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Infrastructure.DataProvider.Util
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
