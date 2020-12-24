﻿using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Implementation.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class AdminServiceTests
    {
        [Fact]
        public void Map_doctor_entity_to_identifier_doctor_dto()
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
        public void Map_Admin_entities_collection_to_identifier_AdminDTO_collection_when_entities_collection_is_null()
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
            if (admin.Id != identfierAdminDTO.Id)
                return false;

            if (!admin.Jmbg.Equals(identfierAdminDTO.EntityDTO.Jmbg))
                return false;

            if (!admin.Username.Equals(identfierAdminDTO.EntityDTO.Username))
                return false;

            if (!admin.Password.Equals(identfierAdminDTO.EntityDTO.Password))
                return false;

            if (!admin.Name.Equals(identfierAdminDTO.EntityDTO.Name))
                return false;

            if (!admin.Surname.Equals(identfierAdminDTO.EntityDTO.Surname))
                return false;

            return true;
        }
         private Admin GetAdminFirts()
                => new Admin()
                {
                    Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
                    Username = "Doctor1",
                    Password = "Doctor1",
                    Jmbg = "1234567890123",
                    Name = "Petar",
                    Surname = "Petrovic"
                };

        private Admin GetAdminSecond()
                => new Admin()
                {
                    Id = Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"),
                    Username = "Doctor2",
                    Password = "Doctor2",
                    Jmbg = "5554567890123",
                    Name = "Dusan",
                    Surname = "Dusanovic"
                };
    }
}