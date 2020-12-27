using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IAdminService
    {
        IdentifiableDTO<AdminDTO> GetById(Guid id);

        IEnumerable<IdentifiableDTO<AdminDTO>> GetAll();
    }
}
