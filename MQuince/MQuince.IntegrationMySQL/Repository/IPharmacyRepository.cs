using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Pharmacy;
using MQuince.IntegrationMySQL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.IntegrationMySQL
{
    public interface IPharmacyRepository: IRepository<MyPharmacy>
    {
        IEnumerable<MyPharmacy> GetByAllParams(string name, string url,Guid api);

    }
}
