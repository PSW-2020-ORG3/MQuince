using MQuince.Entities.Users;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Repositories.Tests
{
    public class AdminMapperTests
    {
        [Fact]
        public void Map_admin_persistence_to_admin_entity()
        {
            AdminPersistence adminPersistance = this.GetAdminPersistanceFirst();

            Admin adminEntity = AdminMapper.MapAdminPersistenceToAdminEntity(adminPersistance);

            Assert.True(this.IsEqualAdminPersistanceAndAdminEntity(adminPersistance, adminEntity));
        }

        [Fact]
        public void Map_admin_persistance_to_admin_entity_when_persistance_is_null()
        {
            AdminPersistence adminPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => AdminMapper.MapAdminPersistenceToAdminEntity(adminPersistance));
        }


        [Fact]
        public void Map_admin_persistances_collection_to_admin_entities_collection()
        {
            List<AdminPersistence> listOfAdminPersistences = this.GetListOfAdminPersistance();

            List<Admin> listOfAdminEntities = AdminMapper.MapAdminPersistenceCollectionToAdminEntityCollection(listOfAdminPersistences).ToList();

            Assert.True(this.IsEqualAdminPersistanceAndAdminEntity(listOfAdminPersistences[0], listOfAdminEntities[0]));
            Assert.True(this.IsEqualAdminPersistanceAndAdminEntity(listOfAdminPersistences[1], listOfAdminEntities[1]));
        }

        [Fact]
        public void Map_admin_persistance_collection_to_admin_entity_collection_when_collection_is_null()
        {
            List<AdminPersistence> listOfAdminPersistences = null;

            Assert.Throws<ArgumentNullException>(()
                    => AdminMapper.MapAdminPersistenceCollectionToAdminEntityCollection(listOfAdminPersistences));
        }

        private AdminPersistence GetAdminPersistanceFirst()
                => new AdminPersistence()
                {
                    Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "Doctor1",
                    Password = "Doctor1",
                    Jmbg = "1234567890123"
                };

        private AdminPersistence GetAdminPersistanceSecond()
                => new AdminPersistence()
                {
                    Id = Guid.Parse("c84268b1-ca63-45d1-9be1-44976dd1119e"),
                    Name = "Uros",
                    Surname = "Urosevic",
                    Username = "Doctor2",
                    Password = "Doctor2",
                    Jmbg = "7234567890123"
                };

        private List<AdminPersistence> GetListOfAdminPersistance()
        {
            List<AdminPersistence> listOfAdminPersistance = new List<AdminPersistence>();
            listOfAdminPersistance.Add(this.GetAdminPersistanceFirst());
            listOfAdminPersistance.Add(this.GetAdminPersistanceSecond());
            return listOfAdminPersistance;
        }

        private bool IsEqualAdminPersistanceAndAdminEntity(AdminPersistence adminPersistence, Admin admin)
        {
            if (adminPersistence.Id != admin.Id)
                return false;

            if (!adminPersistence.Jmbg.Equals(admin.Jmbg))
                return false;

            if (!adminPersistence.Username.Equals(admin.Username))
                return false;

            if (!adminPersistence.Password.Equals(admin.Password))
                return false;

            if (!adminPersistence.Name.Equals(admin.Name))
                return false;

            if (!adminPersistence.Surname.Equals(admin.Surname))
                return false;


            return true;
        }
    }
}
