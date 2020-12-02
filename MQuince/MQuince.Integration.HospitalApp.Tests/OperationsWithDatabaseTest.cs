using Moq;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.HospitalAppTests
{
    public class OperationsWithDatabaseTest
    {
        [Fact]
        public void Create_entity_in_mock_database()
        {
            var stubRepository = new Mock<IPharmacyRepository>();

            PharmacyDTO pharmacy = new PharmacyDTO()
            {
                Name = "some_name"
            };

            PharmacyService service = new PharmacyService(stubRepository.Object);

            Assert.NotNull(service.Create(pharmacy));

        }
    }
}
