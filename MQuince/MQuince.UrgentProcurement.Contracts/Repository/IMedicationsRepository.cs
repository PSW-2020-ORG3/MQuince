using MQuince.Core.Contracts;
using MQuince.UrgentProcurement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.UrgentProcurement.Contracts.Repository
{
    public interface IMedicationsRepository : IRepository<Medications>
    {
        Medications GetByName(string Name);
        bool DeleteByName(string name);
    }
}
