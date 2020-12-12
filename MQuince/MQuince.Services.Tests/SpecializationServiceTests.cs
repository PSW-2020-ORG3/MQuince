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
    public class SpecializationServiceTests
    {
        ISpecializationService specializationService;
        ISpecializationRepository specializationRepository = Substitute.For<ISpecializationRepository>();

        public SpecializationServiceTests()
        {
            specializationService = new SpecializationService(specializationRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new SpecializationService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            ISpecializationService specializationService = new SpecializationService(specializationRepository);


            Assert.IsType<SpecializationService>(specializationService);
        }

        [Fact]
        public void GetAll_returns_data()
        {
            specializationRepository.GetAll().Returns(this.GetListOfSpecializations());

            List<IdentifiableDTO<SpecializationDTO>> returnedList = specializationService.GetAll().ToList();

            Assert.Equal(returnedList[0].Id, Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"));
            Assert.Equal("Hirurg", returnedList[0].EntityDTO.Name);
            Assert.Equal(returnedList[1].Id, Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69"));
            Assert.Equal("Oftamolog", returnedList[1].EntityDTO.Name);
        }

        [Fact]
        public void GetAll_returns_null()
        {
            List<Specialization> listOfSpecialization = null;
            specializationRepository.GetAll().Returns(listOfSpecialization);

            Assert.Throws<NotFoundEntityException>(() => specializationService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_argument_null_exception()
        {
            specializationRepository.GetAll().Returns(x => { throw new ArgumentNullException(); });

            Assert.Throws<NotFoundEntityException>(() => specializationService.GetAll());
        }

        [Fact]
        public void GetAll_returns_any_other_exception()
        {
            specializationRepository.GetAll().Returns(x => { throw new Exception(); });

            Assert.Throws<InternalServerErrorException>(() => specializationService.GetAll());
        }

        private List<Specialization> GetListOfSpecializations()
        {
            List<Specialization> listOfSpecialization = new List<Specialization>()
            {
                new Specialization(Guid.Parse("11ac21e1-1361-4c06-9751-9666ce10d30a"), "Hirurg"),
                new Specialization(Guid.Parse("c389f917-3eb8-4f1a-a22c-bbc34b137f69"), "Oftamolog")
            };


            return listOfSpecialization;
        }
    }
}
