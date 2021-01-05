using MQuince.Infrastructure.DataProvider.Util;
using MQuince.Infrastructure.PersistenceEntities.Users;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Infrastructure.Unit.Tests
{
    public class DoctorMapperTests
    {
        [Fact]
        public void Map_doctor_persistence_to_doctor_entity()
        {
            DoctorPersistence doctorPersistance = this.GetDoctorPersistanceFirst();

            Doctor doctorEntity = DoctorMapper.MapDoctorPersistenceToDoctorEntity(doctorPersistance);

            Assert.True(this.IsEqualDoctorPersistanceAndDoctorEntity(doctorPersistance, doctorEntity));
        }

        [Fact]
        public void Map_doctor_persistance_to_doctor_entity_when_persistance_is_null()
        {
            DoctorPersistence doctorPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => DoctorMapper.MapDoctorPersistenceToDoctorEntity(doctorPersistance));
        }


        [Fact]
        public void Map_doctor_persistances_collection_to_doctor_entities_collection()
        {
            List<DoctorPersistence> listOfdoctorPersistences = this.GetListOfDoctorPersistance();

            List<Doctor> listOfDoctorEntities = DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(listOfdoctorPersistences).ToList();

            Assert.True(this.IsEqualDoctorPersistanceAndDoctorEntity(listOfdoctorPersistences[0], listOfDoctorEntities[0]));
            Assert.True(this.IsEqualDoctorPersistanceAndDoctorEntity(listOfdoctorPersistences[1], listOfDoctorEntities[1]));
        }

        [Fact]
        public void Map_specialization_persistance_collection_to_specialization_entity_collection_when_collection_is_null()
        {
            List<DoctorPersistence> listOfdoctorPersistences = null;

            Assert.Throws<ArgumentNullException>(()
                    => DoctorMapper.MapDoctorPersistenceCollectionToDoctorEntityCollection(listOfdoctorPersistences));
        }

        private DoctorPersistence GetDoctorPersistanceFirst()
                => new DoctorPersistence()
                {
                    Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "Doctor1",
                    Password = "Doctor1",
                    Jmbg = "1234567890123",
                    Biography = "Test",
                    Specialization = new SpecializationPersistence() { Id = Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c") }
                };

        private DoctorPersistence GetDoctorPersistanceSecond()
                => new DoctorPersistence()
                {
                    Id = Guid.Parse("c84268b1-ca63-45d1-9be1-44976dd1119e"),
                    Name = "Uros",
                    Surname = "Urosevic",
                    Username = "Doctor2",
                    Password = "Doctor2",
                    Jmbg = "7234567890123",
                    Biography = "Test1",
                    Specialization = new SpecializationPersistence() { Id = Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c") }
                };

        private List<DoctorPersistence> GetListOfDoctorPersistance()
        {
            List<DoctorPersistence> listOfDoctorPersistance = new List<DoctorPersistence>();
            listOfDoctorPersistance.Add(this.GetDoctorPersistanceFirst());
            listOfDoctorPersistance.Add(this.GetDoctorPersistanceSecond());
            return listOfDoctorPersistance;
        }

        private bool IsEqualDoctorPersistanceAndDoctorEntity(DoctorPersistence doctorPersistence, Doctor doctor)
        {
            if (doctorPersistence.Id != doctor.Id)
                return false;

            if (!doctorPersistence.Jmbg.Equals(doctor.Jmbg))
                return false;

            if (!doctorPersistence.Username.Equals(doctor.Username))
                return false;

            if (!doctorPersistence.Password.Equals(doctor.Password))
                return false;

            if (!doctorPersistence.Name.Equals(doctor.Name))
                return false;

            if (!doctorPersistence.Surname.Equals(doctor.Surname))
                return false;

            if (doctorPersistence.SpecializationId != doctor.SpecializationId)
                return false;


            return true;
        }
    }
}
