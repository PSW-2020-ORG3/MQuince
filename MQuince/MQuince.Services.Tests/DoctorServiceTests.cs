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
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Services.Tests
{
    public class DoctorServiceTests
    {
        IDoctorService doctorService;
        IDoctorRepository doctorRepository = Substitute.For<IDoctorRepository>();

        public DoctorServiceTests()
        {
            doctorService = new DoctorService(doctorRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new DoctorService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IDoctorService doctorService = new DoctorService(doctorRepository);

            Assert.IsType<DoctorService>(doctorService);
        }

        [Fact]
        public void GetAll_returns_data()
        {
            doctorRepository.GetAll().Returns(this.GetListOfDoctors());

            List<IdentifiableDTO<DoctorDTO>> returnedList = doctorService.GetAll().ToList();

            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public void GetAll_returns_null()
        {
            doctorService = new DoctorService(doctorRepository);
            List<Doctor> listOfDoctors = null;
            doctorRepository.GetAll().Returns(listOfDoctors);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_argument_null_exception()
        {
            doctorRepository.GetAll().Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_other_exception()
        {
            doctorRepository.GetAll().Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => doctorService.GetAll());
        }

        [Fact]
        public void GetById_returns_doctor()
        {
            doctorRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(this.GetFirstDoctor());

            IdentifiableDTO<DoctorDTO> doctor = doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"));

            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetFirstDoctor(), doctor));
        }

        [Fact]
        public void GetById_returns_null()
        {
            Doctor doctor = null;
            doctorRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(doctor);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void GetById_returns_any_argument_null_exception()
        {
            doctorRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void GetById_returns_any_other_exception()
        {
            doctorRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_doctors_per_specialization_returns_doctor()
        {
            doctorRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(this.GetListOfDoctors());

            List<IdentifiableDTO<DoctorDTO>> doctors = doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).ToList();

            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetFirstDoctor(), doctors[0]));
            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetSecondDoctor(), doctors[1]));

        }

        [Fact]
        public void Get_doctors_per_specialization_returns_null()
        {
            List<Doctor> doctors = null;
            doctorRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(doctors);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_doctors_per_specialization_returns_any_argument_null_exception()
        {
            doctorRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_doctors_per_specialization_return_any_other_exception()
        {
            doctorRepository.GetDoctorsPerSpecialization(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => doctorService.GetDoctorsPerSpecialization(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }


        private bool CompareDoctorAndIdentifierDoctor(Doctor doctor, IdentifiableDTO<DoctorDTO> identifierDoctor)
        {
            if (doctor.Id != identifierDoctor.Id)
                return false;

            if (!doctor.Jmbg.Equals(identifierDoctor.EntityDTO.Jmbg))
                return false;

            if (!doctor.Username.Equals(identifierDoctor.EntityDTO.Username))
                return false;

            if (!doctor.Password.Equals(identifierDoctor.EntityDTO.Password))
                return false;

            if (!doctor.Name.Equals(identifierDoctor.EntityDTO.Name))
                return false;

            if (!doctor.Surname.Equals(identifierDoctor.EntityDTO.Surname))
                return false;

            if (!doctor.Biography.Equals(identifierDoctor.EntityDTO.Biography))
                return false;

            if (doctor.SpecializationId != identifierDoctor.EntityDTO.Specialization)
                return false;

            return true;
        }

        private Doctor GetFirstDoctor()
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

        private Doctor GetSecondDoctor()
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

        private List<Doctor> GetListOfDoctors()
        {
            List<Doctor> listOfDoctors = new List<Doctor>()
            {
                this.GetFirstDoctor(),
                this.GetSecondDoctor()
            };

            return listOfDoctors;
        }
    }
}
