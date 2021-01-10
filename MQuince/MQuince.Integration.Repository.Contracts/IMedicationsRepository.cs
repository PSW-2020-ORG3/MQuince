using MQuince.Integration.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Repository.Contracts
{

    public interface IMedicationsRepository : IRepository<Medications>
    {
        Medications GetByName(string Name);
        bool DeleteByName(string name);
    }
}
