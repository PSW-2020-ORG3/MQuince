using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
  
    public interface IMedicationsService : IService<MedicationsDTO, IdentifiableDTO<MedicationsDTO>>
    {
        bool DeleteByName(string name);
        string[] GetData(string data);
    }
}
