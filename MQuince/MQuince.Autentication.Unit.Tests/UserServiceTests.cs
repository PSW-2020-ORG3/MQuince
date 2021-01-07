using MQuince.Autentication.Application.Services;
using MQuince.Autentication.Contracts.DTO;
using MQuince.Autentication.Contracts.Exceptions;
using MQuince.Autentication.Contracts.Repository;
using MQuince.Autentication.Contracts.Service;
using MQuince.Autentication.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace MQuince.Autentication.Unit.Tests
{
    public class UserServiceTests
    {
        IUserService userService;
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        public UserServiceTests()
        {
            userService = new UserService(userRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IUserService userService = new UserService(userRepository);

            Assert.IsType<UserService>(userService);
        }

        [Fact]
        public void Login_when_give_valid_data()
        {
            LoginDTO loginDTO = this.GetValidLoginDTO();
            userRepository.GetAllPatients().Returns(this.GetListOfPatient());

            AuthenticateResponseDTO authentificateResponse = userService.Login(loginDTO);

            Assert.True(IsValidAuthentificateResponse(authentificateResponse));
        }

        [Fact]
        public void Login_when_user_with_given_data_not_found()
        {
            LoginDTO loginDTO = this.GetInvalidLoginDTO();
            userRepository.GetAllPatients().Returns(this.GetListOfPatient());

            Assert.Throws<EntityNotFoundException>(() => userService.Login(loginDTO));
        }

        [Fact]
        public void Login_when_repositories_give_any_exception()
        {
            LoginDTO loginDTO = this.GetInvalidLoginDTO();
            userRepository.GetAllPatients().Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => userService.Login(loginDTO));
        }

        private LoginDTO GetValidLoginDTO()
            => new LoginDTO()
            {
                Username = "patient3",
                Password = "patient3"
            };

        private LoginDTO GetInvalidLoginDTO()
            => new LoginDTO()
            {
                Username = "patient1",
                Password = "patient3"
            };

        private bool IsValidAuthentificateResponse(AuthenticateResponseDTO authentificateResponse)
        {
            if (!authentificateResponse.Name.Equals("Petar"))
                return false;

            if (!authentificateResponse.Surname.Equals("Petrovic"))
                return false;

            if (!authentificateResponse.Username.Equals("patient3"))
                return false;

            if (authentificateResponse.Id != Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"))
                return false;

            if (authentificateResponse.Token.Equals(""))
                return false;

            return true;
        }

        private Patient GetPatientFirst()
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

        private Patient GetPatientSecond()
            => new Patient()
            {
                Id = Guid.Parse("12345a55-094f-4081-89b3-757cafbd5ea1"),
                Name = "Dusan",
                Surname = "Dusanic",
                Guest = false,
                Jmbg = "9876543210123",
                Password = "patient1",
                Username = "patientpassword",
                PersonalDoctor = Guid.Parse("54433a86-094f-4081-89b3-757cafbd5ea1")
            };

        private List<Patient> GetListOfPatient()
        {
            List<Patient> listOfPatient = new List<Patient>();

            listOfPatient.Add(this.GetPatientFirst());
            listOfPatient.Add(this.GetPatientSecond());

            return listOfPatient;
        }
    }
}
