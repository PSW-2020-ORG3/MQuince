using MQuince.Entities.Users;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using Xunit;

namespace MQuince.Repositories.Tests
{
    public class SpecializationMapperTests
    {
        [Fact]
        public void Map_specialization_persistence_to_specialization_entity()
        {
            SpecializationPersistence specializationPersistance = new SpecializationPersistence()
            {
                Id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"),
                Name = "Hirurg"
            };

            Specialization specialization = SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(specializationPersistance);

            Assert.Equal(specializationPersistance.Id, specialization.Id);
            Assert.Equal(specializationPersistance.Name, specialization.Name);
        }

        [Fact]
        public void Map_specialization_persistance_to_specialization_entity_when_persistance_is_null()
        {
            SpecializationPersistence specializationPersistance = null;

            Assert.Throws<ArgumentNullException>( () 
                  => SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(specializationPersistance));
        }

        [Fact]
        public void Map_specialization_entity_to_specialization_persistance()
        {
            Guid id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a");
            Specialization specialization = new Specialization(id, "Hirurg");

            SpecializationPersistence specializationPersistance = SpecializationMapper.MapSpecializationEntityToSpecializationPersistence(specialization);

            Assert.Equal(specializationPersistance.Id, specialization.Id);
            Assert.Equal(specializationPersistance.Name, specialization.Name);
        }

        [Fact]
        public void Map_specialization_entity_to_specialization_persistance_when_entity_is_null()
        {
            Specialization specialization = null;

            Assert.Throws<ArgumentNullException>(()
                    => SpecializationMapper.MapSpecializationEntityToSpecializationPersistence(specialization));
        }

        [Fact]
        public void Map_specialization_persistance_collection_to_specialization_entity_collection()
        {
            SpecializationPersistence specializationPersistanceFirst = new SpecializationPersistence()
            {
                Id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"),
                Name = "Hirurg"
            };
            SpecializationPersistence specializationPersistanceSecond = new SpecializationPersistence()
            {
                Id = Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69"),
                Name = "Oftamolog"
            };
            List<SpecializationPersistence> listOfSpecializationPersistance = new List<SpecializationPersistence>();
            listOfSpecializationPersistance.Add(specializationPersistanceFirst);
            listOfSpecializationPersistance.Add(specializationPersistanceSecond);

            List<Specialization> listOfSpecialization = (List<Specialization>)SpecializationMapper.MapSpecializationPersistenceCollectionToSpecializationEntityCollection(listOfSpecializationPersistance);

            Assert.Equal(listOfSpecialization[0].Id, specializationPersistanceFirst.Id);
            Assert.Equal(listOfSpecialization[0].Name, specializationPersistanceFirst.Name);
            Assert.Equal(listOfSpecialization[1].Id, specializationPersistanceSecond.Id);
            Assert.Equal(listOfSpecialization[1].Name, specializationPersistanceSecond.Name);
        }

        [Fact]
        public void Map_specialization_persistance_collection_to_specialization_entity_collection_when_collection_is_null()
        {
            List<SpecializationPersistence> listOfSpecializationPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                    => SpecializationMapper.MapSpecializationPersistenceCollectionToSpecializationEntityCollection(listOfSpecializationPersistance));
        }
    }
}
