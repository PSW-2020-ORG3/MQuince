using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Contracts.Repository;
using MQuince.ActionAndBenefits.Contracts.Service;
using MQuince.ActionAndBenefits.Domain;
using MQuince.Core.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.ActionAndBenefits.Services
{
    public class ActionAndBenefitsService : IActionAndBenefitsService
    {
        private readonly IActionAndBenefitsRepository _actionAndBenefitsRepository;

        public ActionAndBenefitsService(IActionAndBenefitsRepository actionAndBenefitsRepository)
        {
            _actionAndBenefitsRepository = actionAndBenefitsRepository == null ? throw new ArgumentNullException(nameof(actionAndBenefitsRepository) + "is set to null") : actionAndBenefitsRepository;

        }

        public Guid Create(ActionAndBenefitsDTO entityDTO)
        {
            ActionsAndBenefits action = CreateActionsAndBenefitsFromDTO(entityDTO);
            _actionAndBenefitsRepository.Create(action);
            return action.IDAction;

        }

        public bool Delete(Guid id) => _actionAndBenefitsRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<ActionAndBenefitsDTO>> GetAll()
        {
            return _actionAndBenefitsRepository.GetAll().Select(c => CreateDTOFromActionAndBenefits(c));

        }

        public IdentifiableDTO<ActionAndBenefitsDTO> GetById(Guid id) => CreateDTOFromActionAndBenefits(_actionAndBenefitsRepository.GetById(id));

        private IdentifiableDTO<ActionAndBenefitsDTO> CreateDTOFromActionAndBenefits(ActionsAndBenefits actionAndBenefits)
        {
            if (actionAndBenefits == null) return null;

            return new IdentifiableDTO<ActionAndBenefitsDTO>()
            {
                Id = actionAndBenefits.IDAction,
                
                EntityDTO = new ActionAndBenefitsDTO()
                {
                    IsApproved = actionAndBenefits.IsApproved,
                    PharmacyName = actionAndBenefits.PharmacyName,
                    ActionName = actionAndBenefits.ActionName,
                    BeginDate = actionAndBenefits.BeginDate,
                    EndDate = actionAndBenefits.EndDate,
                    OldCost = actionAndBenefits.OldCost,
                    NewCost = actionAndBenefits.NewCost
                }

            };
        }

        private ActionsAndBenefits CreateActionsAndBenefitsFromDTOWithIsApproved(ActionAndBenefitsDTO action, Guid? actionKey = null, Boolean? isApproved = false)
          => actionKey == null && isApproved == false ? new ActionsAndBenefits(action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost)
                        : new ActionsAndBenefits(actionKey.Value, action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost, isApproved.Value);
        private ActionsAndBenefits CreateActionsAndBenefitsFromDTO(ActionAndBenefitsDTO action, Guid? actionKey = null)
          => actionKey == null ? new ActionsAndBenefits(action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost)
                        : new ActionsAndBenefits(actionKey.Value, action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost, false);


        public void Update(ActionAndBenefitsDTO entityDTO, Guid id, Boolean isApproved)
        {
            _actionAndBenefitsRepository.Update(CreateActionsAndBenefitsFromDTOWithIsApproved(entityDTO, id, isApproved));
        }

        public void Update(ActionAndBenefitsDTO entityDTO, Guid id)
        {
            _actionAndBenefitsRepository.Update(CreateActionsAndBenefitsFromDTO(entityDTO));
        }

    }
}
