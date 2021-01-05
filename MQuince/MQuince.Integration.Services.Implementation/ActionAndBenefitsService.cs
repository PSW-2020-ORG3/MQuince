
using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Integration.Services.Implementation
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

        public IdentifiableDTO<ActionAndBenefitsDTO> GetByID(Guid id) => CreateDTOFromActionAndBenefits(_actionAndBenefitsRepository.GetById(id));

        public ActionsAndBenefits GetById(Guid id) => _actionAndBenefitsRepository.GetById(id);
        private IdentifiableDTO<ActionAndBenefitsDTO> CreateDTOFromActionAndBenefits(ActionsAndBenefits actionAndBenefits)
        {
            if (actionAndBenefits == null) return null;

            return new IdentifiableDTO<ActionAndBenefitsDTO>()
            {
                Key = actionAndBenefits.IDAction,
                IsApproved = actionAndBenefits.IsApproved,
                EntityDTO = new ActionAndBenefitsDTO()
                {
                    PharmacyName = actionAndBenefits.PharmacyName,
                    ActionName = actionAndBenefits.ActionName,
                    BeginDate = actionAndBenefits.BeginDate,
                    EndDate = actionAndBenefits.EndDate,
                    OldCost = actionAndBenefits.OldCost,
                    NewCost = actionAndBenefits.NewCost
                }

            };
        }

        private ActionsAndBenefits CreateActionsAndBenefitsFromDTOWithIsApproved(ActionAndBenefitsDTO action, Guid? actionKey = null , Boolean? isApproved = false)
          => actionKey == null && isApproved == false ? new ActionsAndBenefits(action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost)
                        : new ActionsAndBenefits(actionKey.Value, action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost, isApproved.Value);
        private ActionsAndBenefits CreateActionsAndBenefitsFromDTO(ActionAndBenefitsDTO action, Guid? actionKey = null)
          => actionKey == null ? new ActionsAndBenefits(action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost)
                        : new ActionsAndBenefits(actionKey.Value, action.PharmacyName, action.ActionName, action.BeginDate, action.EndDate, action.OldCost, action.NewCost, false);
        

        public void Update(ActionAndBenefitsDTO entityDTO, Guid id,Boolean isApproved)
        {
            _actionAndBenefitsRepository.Update(CreateActionsAndBenefitsFromDTOWithIsApproved(entityDTO,id,isApproved));
        }

        public void Update(ActionAndBenefitsDTO entityDTO, Guid id)
        {
            _actionAndBenefitsRepository.Update(CreateActionsAndBenefitsFromDTO(entityDTO));
        }

    }


}
