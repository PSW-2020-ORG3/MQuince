using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Contracts.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<IdentifiableDTO<SpecializationDTO>> GetAll();
    }
}
