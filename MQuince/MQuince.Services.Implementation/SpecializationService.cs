using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class SpecializationService : ISpecializationService
    {
        public IEnumerable<IdentifiableDTO<SpecializationDTO>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
