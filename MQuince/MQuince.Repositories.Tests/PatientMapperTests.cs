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
    public class PatientMapperTests
    {
        [Fact]
        public void Map_patient_persistence_to_patient_entity()
        {
            PatientPersistence patientPersistence = this.GetPatientPersistenceFirst();

            Patient patient = PatientMapper.MapPatientPersistenceToPatientEntity(patientPersistence);

            Assert.True(IsEqualPatientPersistanceAndPatientEntity(patientPersistence, patient));
        }

        [Fact]
        public void Map_patient_persistence_to_patient_entity_when_patient_persistance_is_null()
        {
            PatientPersistence patientPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => PatientMapper.MapPatientPersistenceToPatientEntity(patientPersistance));
        }

        [Fact]
        public void Map_patient_persistance_collection_to_patient_entity_collection()
        {
            List<PatientPersistence> patientPersistences = this.GetListOfPatientPersistance();

            List<Patient> listOfPatients = PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(patientPersistences).ToList();

            Assert.True(this.IsEqualPatientPersistanceAndPatientEntity(patientPersistences[0], listOfPatients[0]));
            Assert.True(this.IsEqualPatientPersistanceAndPatientEntity(patientPersistences[1], listOfPatients[1]));
        }


        [Fact]
        public void Map_patient_persistance_collection_to_patient_entity_collection_when_collection_is_null()
        {
            List<PatientPersistence> listOfPatientPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                    => PatientMapper.MapPatientPersistenceCollectionToPatientEntityCollection(listOfPatientPersistance));
        }

        private bool IsEqualPatientPersistanceAndPatientEntity(PatientPersistence patientPersistence, Patient patient)
        {
            if (patient.Id != patientPersistence.Id)
                return false;

            if (!patient.Jmbg.Equals(patientPersistence.Jmbg))
                return false;

            if (!patient.Username.Equals(patientPersistence.Username))
                return false;

            if (!patient.Password.Equals(patientPersistence.Password))
                return false;

            if (!patient.Name.Equals(patientPersistence.Name))
                return false;

            if (!patient.Surname.Equals(patientPersistence.Surname))
                return false;

            if (patient.Guest != patientPersistence.Guest)
                return false;

            if (patient.PersonalDoctor != patientPersistence.DoctorPersistanceId)
                return false;

            return true;
        }

        private PatientPersistence GetPatientPersistenceFirst()
            => new PatientPersistence()
            {
                Id = Guid.Parse("54477a86-094f-4081-89b3-757cafbd5ea1"),
                Name="Petar",
                Surname="Petrovic",
                Guest=false,
                Jmbg="1234567890123",
                Password="patient3",
                Username="patient3",
                DoctorPersistance = new DoctorPersistence()
                {
                    Id=Guid.Parse("137bda41-c388-4f5b-8016-0105abbd54d0")
                }
            };

        private PatientPersistence GetPatientPersistenceSecond()
            => new PatientPersistence()
            {
                Id = Guid.Parse("54477a86-123f-4081-89b3-757cafbd5ea1"),
                Name = "Dusan",
                Surname = "Dusanic",
                Guest = false,
                Jmbg = "5555567890123",
                Password = "patient8",
                Username = "patient8",
                DoctorPersistance = new DoctorPersistence()
                {
                    Id = Guid.Parse("123bda41-c388-4f5b-8016-0105abbd54d0")
                }
            };

        private List<PatientPersistence> GetListOfPatientPersistance()
        {
            List<PatientPersistence> listOfPatients = new List<PatientPersistence>();

            listOfPatients.Add(this.GetPatientPersistenceFirst());
            listOfPatients.Add(this.GetPatientPersistenceSecond());

            return listOfPatients;
        }
    }
}
