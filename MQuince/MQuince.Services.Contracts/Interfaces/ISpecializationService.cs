using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<IdentifiableDTO<SpecializationDTO>> GetAll();
    }
}
