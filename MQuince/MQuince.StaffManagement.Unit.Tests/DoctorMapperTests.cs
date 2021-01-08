using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Application.Services.Util;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MQuince.StaffManagement.Unit.Tests
{
    public class DoctorMapperTests
    {
        [Fact]
        public void Map_doctor_entity_to_identifier_doctor_dto()
        {
            Doctor doctor = this.GetDoctorFirts();

            IdentifiableDTO<DoctorDTO> identifierDoctorDTO = DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(doctor);

            Assert.True(IsEqualDoctorEntitiesAndIdentifierDoctorDTO(doctor, identifierDoctorDTO));
        }


        [Fact]
        public void Map_doctor_entity_to_identifier_doctor_dto_when_when_entity_is_null()
        {
            Doctor doctor = null;

            Assert.Throws<ArgumentNullException>(()
                 => DoctorMapper.MapDoctorEntityToIdentifierDoctorDTO(doctor));
        }

        [Fact]
        public void Map_doctor_entites_collection_to_identifier_doctorDTO_collection()
        {
            List<Doctor> listOfdoctors = this.GetListOfDoctors();

            List<IdentifiableDTO<DoctorDTO>> listOfIdentifierDoctorDTO = DoctorMapper.MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(listOfdoctors).ToList();

            Assert.True(this.IsEqualDoctorEntitiesAndIdentifierDoctorDTO(listOfdoctors[0], listOfIdentifierDoctorDTO[0]));
            Assert.True(this.IsEqualDoctorEntitiesAndIdentifierDoctorDTO(listOfdoctors[1], listOfIdentifierDoctorDTO[1]));
        }


        [Fact]
        public void Map_doctor_entities_collection_to_identifier_doctorDTO_collection_when_entities_collection_is_null()
        {
            List<Doctor> listOfDoctors = null;

            Assert.Throws<ArgumentNullException>(()
                    => DoctorMapper.MapDoctorEntityCollectionToIdentifierDoctorDTOCollection(listOfDoctors));
        }

        private List<Doctor> GetListOfDoctors()
        {
            List<Doctor> listOfDoctors = new List<Doctor>();

            listOfDoctors.Add(this.GetDoctorFirts());
            listOfDoctors.Add(this.GetDoctorSecond());

            return listOfDoctors;
        }

        private bool IsEqualDoctorEntitiesAndIdentifierDoctorDTO(Doctor doctor, IdentifiableDTO<DoctorDTO> identfierDoctorDTO)
        {
            if (doctor.Id != identfierDoctorDTO.Id)
                return false;

            if (!doctor.Jmbg.Equals(identfierDoctorDTO.EntityDTO.Jmbg))
                return false;

            if (!doctor.Username.Equals(identfierDoctorDTO.EntityDTO.Username))
                return false;

            if (!doctor.Password.Equals(identfierDoctorDTO.EntityDTO.Password))
                return false;

            if (!doctor.Name.Equals(identfierDoctorDTO.EntityDTO.Name))
                return false;

            if (!doctor.Surname.Equals(identfierDoctorDTO.EntityDTO.Surname))
                return false;

            if (!doctor.Biography.Equals(identfierDoctorDTO.EntityDTO.Biography))
                return false;

            if (doctor.SpecializationId != identfierDoctorDTO.EntityDTO.Specialization)
                return false;

            return true;
        }

        private Doctor GetDoctorFirts()
                => new Doctor()
                {
                    Id = Guid.Parse("664596ef-c5e2-4b2e-911f-f71ac65d4b8d"),
                    Name = "Petar",
                    Surname = "Petrovic",
                    Username = "Doctor1",
                    Password = "Doctor1",
                    Jmbg = "1234567890123",
                    Biography = "Test",
                    SpecializationId = Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")
                };

        private Doctor GetDoctorSecond()
                => new Doctor()
                {
                    Id = Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"),
                    Name = "Dusan",
                    Surname = "Dusanovic",
                    Username = "Doctor2",
                    Password = "Doctor2",
                    Jmbg = "5554567890123",
                    Biography = "Test123",
                    SpecializationId = Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")
                };
    }
}
