using MQuince.Entities;
using MQuince.Repository.SQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class UserMapper
    {
        public static User MapUserPersistenceToUserEntity(UserPersistence user)
            => user == null ? null : new User(user.Id, user.UserType, user.Username, user.Password, user.Jmbg, user.Name, user.Surname,
                user.BirthDate, user.BirthPlace, user.Residence, user.Contact);

        public static IEnumerable<User> MapUserPersistenceCollectionToUserEntityCollection(IEnumerable<UserPersistence> users)
            => users.Select(c => MapUserPersistenceToUserEntity(c));

        public static UserPersistence MapUserEntityToUserPersistence(User user)
        {
            if (user == null) return null;

            UserPersistence retVal = new UserPersistence() {
               Id = user.Id, Username = user.Username, BirthDate = user.BirthDate, BirthPlace = user.BirthPlace, Contact = user.Contact, Jmbg = user.Jmbg,
               Name = user.Name, UserType = user.UserType, Password = user.Password, Residence = user.Residence, Surname = user.Surname
            };
            return retVal;
        }
    }
}
