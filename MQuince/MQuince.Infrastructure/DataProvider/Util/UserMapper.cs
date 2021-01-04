﻿
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Infrastructure.DataProvider.Util
{
    public class UserMapper
    {
        public static User MapUserPersistenceToUserEntity(UserPersistence user)
            => user == null ? null : new User(user.Id, user.Username, user.Password, user.Jmbg, user.Name, user.Surname);

        public static IEnumerable<User> MapUserPersistenceCollectionToUserEntityCollection(IEnumerable<UserPersistence> users)
            => users.Select(c => MapUserPersistenceToUserEntity(c));

        public static UserPersistence MapUserEntityToUserPersistence(User user)
        {
            if (user == null) return null;

            UserPersistence retVal = new UserPersistence() {
               Id = user.Id, Username = user.Username, Jmbg = user.Jmbg,
               Name = user.Name, Password = user.Password, Surname = user.Surname
            };
            return retVal;
        }
    }
}
