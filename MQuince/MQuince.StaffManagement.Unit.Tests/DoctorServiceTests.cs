﻿using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Application.Service;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using MQuince.StafManagement.Contracts.Repository;
using MQuince.StafManagement.Domain;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.StaffManagement.Unit.Tests
{
    public class DoctorServiceTests
    {
        IDoctorService doctorService;
        IUserRepository userRepository = Substitute.For<IUserRepository>();

        public DoctorServiceTests()
        {
            doctorService = new DoctorService(userRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new DoctorService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IDoctorService doctorService = new DoctorService(userRepository);

            Assert.IsType<DoctorService>(doctorService);
        }

        [Fact]
        public void Get_all_returns_data()
        {
            userRepository.GetAllDoctors().Returns(this.GetListOfDoctors());

            List<IdentifiableDTO<DoctorDTO>> returnedList = doctorService.GetAll().ToList();

            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public void Get_all_returns_null()
        {
            doctorService = new DoctorService(userRepository);
            List<Doctor> listOfDoctors = null;
            userRepository.GetAllDoctors().Returns(listOfDoctors);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetAll());
        }

        [Fact]
        public void Get_all_returns_any_argument_null_exception()
        {
            userRepository.GetAllDoctors().Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetAll());
        }

        [Fact]
        public void Get_all_returns_any_other_exception()
        {
            userRepository.GetAllDoctors().Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => doctorService.GetAll());
        }

        [Fact]
        public void Get_by_id_returns_doctor()
        {
            userRepository.GetDoctorById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(this.GetFirstDoctor());

            IdentifiableDTO<DoctorDTO> doctor = doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"));

            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetFirstDoctor(), doctor));
        }

        [Fact]
        public void Get_by_id_returns_null()
        {
            Doctor doctor = null;
            userRepository.GetDoctorById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(doctor);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_by_id_returns_any_argument_null_exception()
        {
            userRepository.GetDoctorById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_by_id_returns_any_other_exception()
        {
            userRepository.GetDoctorById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => doctorService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")));
        }

        [Fact]
        public void Get_doctors_per_specialization_returns_doctor()
        {
            userRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(this.GetListOfDoctors());

            List<IdentifiableDTO<DoctorDTO>> doctors = doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).ToList();

            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetFirstDoctor(), doctors[0]));
            Assert.True(this.CompareDoctorAndIdentifierDoctor(this.GetSecondDoctor(), doctors[1]));

        }

        [Fact]
        public void Get_doctors_per_specialization_returns_null()
        {
            List<Doctor> doctors = null;
            userRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(doctors);

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_doctors_per_specialization_returns_any_argument_null_exception()
        {
            userRepository.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")).Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => doctorService.GetDoctorsPerSpecialization(Guid.Parse("b1a7b927-6489-456e-bee6-4bd1fa5e2c7c")));
        }

        [Fact]
        public void Get_doctors_per_specialization_return_any_other_exception()
        {
            userRepository.GetDoctorsPerSpecialization(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(x => { throw new Exception(); });

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
