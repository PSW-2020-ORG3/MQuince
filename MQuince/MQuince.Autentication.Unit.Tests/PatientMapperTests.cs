using MQuince.Autentication.Application.Services.Util;
using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Domain;
using MQuince.Core.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Autentication.Unit.Tests
{
    public class PatientMapperTests
    {
        [Fact]
        public void Map_patient_entity_to_patient_identifier_dto()
        {
            Patient patient = this.GetPatient();

            IdentifiableDTO<PatientDTO> patientDTO = PatientMapper.MapPatientEntityToPatientIdentifierDTO(patient);

            Assert.True(IsEqualPatientPersistanceAndPatientEntity(patientDTO, patient));
        }

        [Fact]
        public void Map_patient_persistence_to_patient_entity_when_patient_persistance_is_null()
        {
            Patient patient = null;

            Assert.Throws<ArgumentNullException>(()
                 => PatientMapper.MapPatientEntityToPatientIdentifierDTO(patient));
        }

        public bool IsEqualPatientPersistanceAndPatientEntity(IdentifiableDTO<PatientDTO> patientDTO, Patient patient)
        {

            if (patient.Id != patientDTO.Id)
                return false;

            if (!patient.Jmbg.Equals(patientDTO.EntityDTO.Jmbg))
                return false;

            if (!patient.Username.Equals(patientDTO.EntityDTO.Username))
                return false;

            if (!patient.Password.Equals(patientDTO.EntityDTO.Password))
                return false;

            if (!patient.Name.Equals(patientDTO.EntityDTO.Name))
                return false;

            if (!patient.Surname.Equals(patientDTO.EntityDTO.Surname))
                return false;

            if (patient.Guest != patientDTO.EntityDTO.Guest)
                return false;

            if (patient.PersonalDoctor != patientDTO.EntityDTO.PersonalDoctor)
                return false;

            return true;
        }

        private Patient GetPatient()
            => new Patient()
            {
                Id = Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"),
                Name = "Petar",
                Surname = "Petrovic",
                Guest = false,
                Jmbg = "1234567890123",
                Password = "patient3",
                Username = "patient3",
                PersonalDoctor = Guid.Parse("54477a86-094f-4081-89b3-757cafbd5ea1")
            };
    }
}
