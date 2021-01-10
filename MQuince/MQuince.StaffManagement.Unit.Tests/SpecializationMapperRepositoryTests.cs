using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StaffManagement.Infrastructure.Util;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.StaffManagement.Unit.Tests
{
    public class SpecializationMapperRepositoryTests
    {
        [Fact]
        public void Map_specialization_persistence_to_specialization_entity()
        {
            SpecializationPersistence specializationPersistance = this.GetSpecializationPersistanceFirst();

            Specialization specialization = SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(specializationPersistance);

            Assert.True(this.IsEqualSpecializationPersistanceAndSpecilizationEntity(specializationPersistance, specialization));
        }

        [Fact]
        public void Map_specialization_persistance_to_specialization_entity_when_persistance_is_null()
        {
            SpecializationPersistence specializationPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => SpecializationMapper.MapSpecializationPersistenceToSpecializationEntity(specializationPersistance));
        }


        [Fact]
        public void Map_specialization_persistance_collection_to_specialization_entity_collection()
        {
            List<SpecializationPersistence> specializationPersistences = this.GetListOfSpecificationPersistance();

            List<Specialization> listOfSpecialization = SpecializationMapper.MapSpecializationPersistenceCollectionToSpecializationEntityCollection(specializationPersistences).ToList();

            Assert.True(this.IsEqualSpecializationPersistanceAndSpecilizationEntity(specializationPersistences[0], listOfSpecialization[0]));
            Assert.True(this.IsEqualSpecializationPersistanceAndSpecilizationEntity(specializationPersistences[1], listOfSpecialization[1]));
        }

        [Fact]
        public void Map_specialization_persistance_collection_to_specialization_entity_collection_when_collection_is_null()
        {
            List<SpecializationPersistence> listOfSpecializationPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                    => SpecializationMapper.MapSpecializationPersistenceCollectionToSpecializationEntityCollection(listOfSpecializationPersistance));
        }

        private SpecializationPersistence GetSpecializationPersistanceFirst()
                => new SpecializationPersistence()
                {
                    Id = Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"),
                    Name = "Hirurg"
                };

        private SpecializationPersistence GetSpecializationPersistanceSecond()
                => new SpecializationPersistence()
                {
                    Id = Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69"),
                    Name = "Oftamolog"
                };

        private List<SpecializationPersistence> GetListOfSpecificationPersistance()
        {
            List<SpecializationPersistence> listOfSpecificationPersistance = new List<SpecializationPersistence>();
            listOfSpecificationPersistance.Add(this.GetSpecializationPersistanceFirst());
            listOfSpecificationPersistance.Add(this.GetSpecializationPersistanceSecond());
            return listOfSpecificationPersistance;
        }

        private bool IsEqualSpecializationPersistanceAndSpecilizationEntity(SpecializationPersistence specializationPersistence, Specialization specialization)
        {
            if (specializationPersistence.Id != specialization.Id)
                return false;

            if (!specializationPersistence.Name.Equals(specialization.Name))
                return false;

            return true;
        }
    }
}
