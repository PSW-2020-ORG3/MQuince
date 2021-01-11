using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using System;

namespace MQuince.ActionAndBenefits.Contracts.Service
{
    public interface IActionAndBenefitsService : IService<ActionAndBenefitsDTO, IdentifiableDTO<ActionAndBenefitsDTO>>
    {
        void Update(ActionAndBenefitsDTO entityDTO, Guid id, Boolean isApproved);
    }
}
