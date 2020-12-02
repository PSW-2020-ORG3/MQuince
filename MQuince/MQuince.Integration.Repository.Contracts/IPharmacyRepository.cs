using MQuince.Integration.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Repository.Contracts
{
    public interface IPharmacyRepository : IRepository<MyPharmacy>
    {
        IEnumerable<MyPharmacy> GetByAllParams(string name, string url, Guid api);

    }
}
