using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
    public interface IPharmacyOffersService : IService<PharmacyOffersDTO, IdentifiableDTO<PharmacyOffersDTO>>
    {
        Guid sendOffers(Guid id,Boolean approve);

    }
}
