using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Implementation.Util;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class SpecializationMapperTests
    {
        [Fact]
        public void Map_specialization_entity_to_specialization_identifier_dto()
        {
            Guid id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a");
            Specialization specialization = new Specialization(id, "Hirurg");

            IdentifiableDTO<SpecializationDTO> identifierSpecificationDTO = SpecializationMapper.MapSpecializationEntityToSpecializationIdentifierDTO(specialization);

            Assert.Equal(specialization.Id, identifierSpecificationDTO.Id);
            Assert.Equal(specialization.Name, identifierSpecificationDTO.EntityDTO.Name);
        }

        [Fact]
        public void Map_specialization_entity_to_specialization_identifier_dto_when_entity_is_null()
        {
            Specialization specialization = null;

            Assert.Throws<ArgumentNullException>(()
                 => SpecializationMapper.MapSpecializationEntityToSpecializationIdentifierDTO(specialization));
        }

        [Fact]
        public void Map_specialization_collection_to_identifier_specialization_collection()
        {
            Guid idFirst = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a");
            Specialization specializationFirst = new Specialization(idFirst, "Hirurg");
            Guid idSecond = Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69");
            Specialization specializationSecond = new Specialization(idSecond, "Oftamolog");
            List<Specialization> listOfSpecialization = new List<Specialization>();
            listOfSpecialization.Add(specializationFirst);
            listOfSpecialization.Add(specializationSecond);

            List<IdentifiableDTO<SpecializationDTO>> listOfIdentifierSpecializations = SpecializationMapper.MapSpecializationEntityCollectionToSpecializationIdentifierDTOCollection(listOfSpecialization).ToList();

            Assert.Equal(listOfIdentifierSpecializations[0].Id, specializationFirst.Id);
            Assert.Equal(listOfIdentifierSpecializations[0].EntityDTO.Name, specializationFirst.Name);
            Assert.Equal(listOfIdentifierSpecializations[1].Id, specializationSecond.Id);
            Assert.Equal(listOfIdentifierSpecializations[1].EntityDTO.Name, specializationSecond.Name);
        }

        [Fact]
        public void Map_specialization_collection_to_identifier_specialization_collection_when_collection_is_null()
        {
            List<Specialization> listOfSpecializations = null;

            Assert.Throws<ArgumentNullException>(()
                    => SpecializationMapper.MapSpecializationEntityCollectionToSpecializationIdentifierDTOCollection(listOfSpecializations));
        }

    }
}
