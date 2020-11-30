using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL.Interfaces
{
    public interface IPharmacyServices : IService<PharmacyDTO, IdentifiableDTO<PharmacyDTO>>
    {
        IEnumerable<IdentifiableDTO<PharmacyDTO>> GetByAllParams(string name,string url,Guid api);

    }
}
