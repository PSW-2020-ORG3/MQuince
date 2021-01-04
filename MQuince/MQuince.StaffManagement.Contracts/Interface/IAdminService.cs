using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Interfaces
{
    public interface IAdminService
    {
        IdentifiableDTO<AdminDTO> GetById(Guid id);

        IEnumerable<IdentifiableDTO<AdminDTO>> GetAll();
    }
}
