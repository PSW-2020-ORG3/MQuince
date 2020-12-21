using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
    public interface IPharmacyService : IService<PharmacyDTO, IdentifiableDTO<PharmacyDTO>>
    {
        IEnumerable<IdentifiableDTO<PharmacyDTO>> GetByAllParams(string name, string url, Guid api);

    }
}
