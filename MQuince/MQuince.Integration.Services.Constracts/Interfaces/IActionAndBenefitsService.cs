using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
    public interface IActionAndBenefitsService : IService<ActionAndBenefitsDTO, IdentifiableDTO<ActionAndBenefitsDTO>>
    {
        void Update(ActionAndBenefitsDTO entityDTO, Guid id, Boolean isApproved);
    }
}
