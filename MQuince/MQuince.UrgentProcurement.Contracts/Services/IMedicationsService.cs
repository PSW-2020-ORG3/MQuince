using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.UrgentProcurement.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.UrgentProcurement.Contracts.Services
{
    public interface IMedicationsService : IService<MedicationsDTO, IdentifiableDTO<MedicationsDTO>>
    {
        bool DeleteByName(string name);
        string[] GetData(string data);
    }
}
