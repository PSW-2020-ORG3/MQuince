
using MQuince.Core.IdentifiableDTO;
using MQuince.Pharmacy.Contracts.DTO;
using MQuince.Pharmacy.Contracts.Repository;
using MQuince.Pharmacy.Contracts.Services;
using MQuince.Pharmacy.Domain;
using MQuince.Pharmacy.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MQuince.Integration.HospitalApp.Tests.ServiceTest
{
    public class PharmacyServiceTests
    {
        IPharmacyService pharmacyService;
        IPharmacyRepository pharmacyRepository = Substitute.For<IPharmacyRepository>();

        public PharmacyServiceTests()
        {
            pharmacyService = new PharmacyService(pharmacyRepository);
        }

        [Fact]
        public void Constructor_when_give_repository_as_null()
        {
            Assert.Throws<ArgumentNullException>(() => new PharmacyService(null));
        }

        [Fact]
        public void Constructor_when_give_correctly_repository()
        {
            IPharmacyService pharmacyService = new PharmacyService(pharmacyRepository);

            Assert.IsType<PharmacyService>(pharmacyService);
        }

        [Fact]
        public void Get_all_returns_data()
        {
            pharmacyRepository.GetAll().Returns(this.GetListOfPharmacy());

            List<IdentifiableDTO<PharmacyDTO>> returnedList = pharmacyService.GetAll().ToList();

            Assert.Equal(2, returnedList.Count);
        }

        


        [Fact]
        public void Get_by_id_returns_pharmacy()
        {
            pharmacyRepository.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526")).Returns(this.GetFirstPharmacy());

            IdentifiableDTO<PharmacyDTO> pharmacy = pharmacyService.GetById(Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"));

            Assert.True(this.ComparePharmacyAndIdentifierPharmacy(this.GetFirstPharmacy(), pharmacy));
        }

        private bool ComparePharmacyAndIdentifierPharmacy(MyPharmacy pharmacy, IdentifiableDTO<PharmacyDTO> identifierPharmacy)
        {
            if (pharmacy.ApiKey != identifierPharmacy.EntityDTO.ApiKey)
                return false;

            if (!pharmacy.Name.Equals(identifierPharmacy.EntityDTO.Name))
                return false;
            

            if (!pharmacy.Url.Equals(identifierPharmacy.EntityDTO.Url))
                return false;

            return true;
        }



        private List<MyPharmacy> GetListOfPharmacy()
        {
            List<MyPharmacy> listOfPharmacy = new List<MyPharmacy>()
            {
                this.GetFirstPharmacy(),
                this.GetSecondPharmacy()
            };

            return listOfPharmacy;
        }




        private MyPharmacy GetFirstPharmacy()
            => new MyPharmacy()
            {
                ApiKey = Guid.Parse("51d5a046-bc14-4cce-9ab0-222565f50526"),
                Name = "Dusan",
                Url = "dusan@gmail.com"
            };

        private MyPharmacy GetSecondPharmacy()
            => new MyPharmacy()
            {
                ApiKey = Guid.Parse("61d5a046-bc14-4cce-9ab0-222565f50526"),
                Name = "Benu",
                Url = "benu@gmail.com"
            };

        
    }
}
