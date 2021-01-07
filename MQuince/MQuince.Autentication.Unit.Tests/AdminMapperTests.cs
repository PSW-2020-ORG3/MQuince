using MQuince.Autentication.Application.Services.Util;
using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Domain;
using MQuince.Core.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Autentication.Unit.Tests
{
    public class AdminMapperTests
    {
        [Fact]
        public void Map_admin_entity_to_identifier_admin_dto()
        {
            Admin admin = this.GetAdminFirts();

            IdentifiableDTO<AdminDTO> identifierAdminDTO = AdminMapper.MapAdminEntityToIdentifierAdminDTO(admin);

            Assert.True(IsEqualAdminEntitiesAndIdentifierAdminDTO(admin, identifierAdminDTO));
        }


        [Fact]
        public void Map_admin_entity_to_identifier_admin_dto_when_when_entity_is_null()
        {
            Admin admin = null;

            Assert.Throws<ArgumentNullException>(()
                 => AdminMapper.MapAdminEntityToIdentifierAdminDTO(admin));
        }

        [Fact]
        public void Map_admin_entites_collection_to_identifier_adminDTO_collection()
        {
            List<Admin> listOfAdmins = this.GetListOfAdmins();

            List<IdentifiableDTO<AdminDTO>> listOfIdentifierAdminDTO = AdminMapper.MapAdminEntityCollectionToIdentifierAdminDTOCollection(listOfAdmins).ToList();

            Assert.True(this.IsEqualAdminEntitiesAndIdentifierAdminDTO(listOfAdmins[0], listOfIdentifierAdminDTO[0]));
            Assert.True(this.IsEqualAdminEntitiesAndIdentifierAdminDTO(listOfAdmins[1], listOfIdentifierAdminDTO[1]));
        }


        [Fact]
        public void Map_admin_entities_collection_to_identifier_adminDTO_collection_when_entities_collection_is_null()
        {
            List<Admin> listOfAdmins = null;

            Assert.Throws<ArgumentNullException>(()
                    => AdminMapper.MapAdminEntityCollectionToIdentifierAdminDTOCollection(listOfAdmins));
        }

        private List<Admin> GetListOfAdmins()
        {
            List<Admin> listOfAdmins = new List<Admin>();

            listOfAdmins.Add(this.GetAdminFirts());
            listOfAdmins.Add(this.GetAdminSecond());

            return listOfAdmins;
        }

        private bool IsEqualAdminEntitiesAndIdentifierAdminDTO(Admin admin, IdentifiableDTO<AdminDTO> identfierAdminDTO)
        {
            if (admin.Id != admin.Id)
                return false;

            if (!admin.Jmbg.Equals(admin.Jmbg))
                return false;

            if (!admin.Username.Equals(admin.Username))
                return false;

            if (!admin.Password.Equals(admin.Password))
                return false;

            if (!admin.Name.Equals(admin.Name))
                return false;

            if (!admin.Surname.Equals(admin.Surname))
                return false;


            return true;
        }

        private Admin GetAdminFirts()
                => new Admin()
                {
                    Id = Guid.Parse("c84268b1-ca63-45d1-9be1-44976dd1119e"),
                    Name = "Uros",
                    Surname = "Urosevic",
                    Username = "Doctor2",
                    Password = "Doctor2",
                    Jmbg = "7234567890123"
                };

        private Admin GetAdminSecond()
                => new Admin()
                {
                    Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "Doctor1",
                    Password = "Doctor1",
                    Jmbg = "1234567890123"
                };
    }
}
