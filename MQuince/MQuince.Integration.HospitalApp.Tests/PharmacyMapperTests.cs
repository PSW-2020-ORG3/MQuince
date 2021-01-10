using MQuince.Integration.Infrastructure.PersistenceEntities;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Pharmacy.Contracts.DTO;
using MQuince.Pharmacy.Domain;
using MQuince.Pharmacy.Infrastructure.Util;
using System;
using Xunit;

namespace MQuince.HospitalAppTests
{
    public class PharmacyMapperTests
    {
     
        [Fact]
        public void Map_pharmacy_persistence_to_pharmacy_entity()
        {
            PharmacyPersistence pharmacyPersistence = this.GetPharmacyPersistence();

            MyPharmacy pharmacy = PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(pharmacyPersistence);

            Assert.True(IsEqualPharmacyPersistanceAndPharmacyEntity(pharmacyPersistence, pharmacy));
        }

        [Fact]
        public void Map_pharmacy_persistence_to_pharmacy_entity_when_pharmacy_persistance_is_null()
        {
            PharmacyPersistence pharmacyPersistence = null;

            Assert.Throws<ArgumentNullException>(()
                 => PharmacyMapper.MapPharmacyPersistenceToPharmacyEntity(pharmacyPersistence));
        }



        private bool IsEqualPharmacyPersistanceAndPharmacyEntity(PharmacyPersistence pharmacyPersistence, MyPharmacy pharmacy)
        {
            if (pharmacy.ApiKey != pharmacyPersistence.ApiKey)
                return false;

            if (!pharmacy.Name.Equals(pharmacyPersistence.Name))
                return false;

            if (!pharmacy.Url.Equals(pharmacyPersistence.Url))
                return false;


            return true;
        }

        private PharmacyPersistence GetPharmacyPersistence()
            => new PharmacyPersistence()
            {
                ApiKey = Guid.Parse("54477a86-094f-4081-89b3-757cafbd5ea1"),
                Name = "Pharmacy1",
                Url = "pharmacy1Url"
            };

        public bool IsEqualPharmacyPersistanceAndPharmacyEntity(IdentifiableDTO<PharmacyDTO> pharmacyDTO, MyPharmacy pharmacy)
        {

            if (pharmacy.ApiKey != pharmacyDTO.Key)
                return false;

            if (!pharmacy.Name.Equals(pharmacyDTO.EntityDTO.Name))
                return false;

            if (!pharmacy.Url.Equals(pharmacyDTO.EntityDTO.Url))
                return false;

            return true;
        }

        private MyPharmacy GetPharmacy()
            => new MyPharmacy()
            {
                ApiKey = Guid.Parse("54455a55-094f-4081-89b3-757cafbd5ea1"),
                Name = "Pharmacy1",
                Url = "Pharmacy1Url"
            };
    }
}


