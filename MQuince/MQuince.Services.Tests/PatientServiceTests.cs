using MQuince.Entities.Users;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class PatientServiceTests
    {
        IPatientService patientService;
        IPatientRepository patientRepository = Substitute.For<IPatientRepository>();

        public PatientServiceTests()
        {
            patientService = new PatientService(patientRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new PatientService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IPatientService patientService = new PatientService(patientRepository);

            Assert.IsType<PatientService>(patientService);
        }

        [Fact]
        public void Get_by_id_returns_doctor()
        {
            patientRepository.GetById(Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1")).Returns(this.GetPatient());

            IdentifiableDTO<PatientDTO> patient = patientService.GetById(Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"));

            Assert.True(this.IsEqualPatientAndIdentifierPatient(this.GetPatient(), patient));
        }

        [Fact]
        public void Get_by_id_returns_null()
        {
            Patient patient = null;
            patientRepository.GetById(Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1")).Returns(patient);

            Assert.Throws<NotFoundEntityException>(() => patientService.GetById(Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1")));
        }

        [Fact]
        public void Get_by_id_returns_any_argument_null_exception()
        {
            patientRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => patientService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_by_id_returns_any_other_exception()
        {
            patientRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => patientService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
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

        public bool IsEqualPatientAndIdentifierPatient(Patient patient, IdentifiableDTO<PatientDTO> patientDTO)
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
    }
}
