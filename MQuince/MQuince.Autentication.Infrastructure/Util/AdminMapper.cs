using MQuince.Autentication.Domain;
using MQuince.Infrastructure.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Autentication.Infrastructure.Util
{
    public class AdminMapper
    {
        public static Admin MapAdminPersistenceToAdminEntity(AdminPersistence adminPersistence)
            => adminPersistence == null ? throw new ArgumentNullException()
                                      : new Admin()
                                      {
                                          Id = adminPersistence.Id,
                                          Username = adminPersistence.Username,
                                          Password = adminPersistence.Password,
                                          Jmbg = adminPersistence.Jmbg,
                                          Name = adminPersistence.Name,
                                          Surname = adminPersistence.Surname
                                      };


        public static IEnumerable<Admin> MapAdminPersistenceCollectionToAdminEntityCollection(IEnumerable<AdminPersistence> adminPersistence)
              => adminPersistence == null ? throw new ArgumentNullException()
                                         : adminPersistence.Select(entity => MapAdminPersistenceToAdminEntity(entity));
    }
}
