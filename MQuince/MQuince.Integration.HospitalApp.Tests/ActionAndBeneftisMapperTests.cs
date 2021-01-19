using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Domain;
using MQuince.ActionAndBenefits.Infrastructure.Util;
using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities.ActionAndBenefits;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MQuince.Integration.HospitalApp.Tests
{
    public class ActionAndBenefitsMapperTests
    {
        [Fact]
        public void Map_actions_and_benefits_persistence_to_actions_and_benefits_entity()
        {
            ActionAndBenefitsPersistance actionAndBenefitsPersistance = this.GetActionAndBenefitsPersistance();

            ActionsAndBenefits action = ActionAndBenefitsMapper.MapActionsAndBenefitsPersistenceToActionsAndBenefitsEntity(actionAndBenefitsPersistance);

            Assert.True(IsEqualeActionsAndBenefitsPersistanceAndActionsAndBenefitsEntity(actionAndBenefitsPersistance, action));
        }

        [Fact]
        public void Map_actions_and_benefits_persistence_to_actions_and_benefits_entity_when_actions_and_benefits_persistance_is_null()
        {
            ActionAndBenefitsPersistance actionAndBenefitsPersistance = null;

            Assert.Throws<ArgumentNullException>(()
                 => ActionAndBenefitsMapper.MapActionsAndBenefitsPersistenceToActionsAndBenefitsEntity(actionAndBenefitsPersistance));
        }

        [Fact]
        public void Map_actions_and_benefits_entity_to_actions_and_benefits_identifier_dto()
        {
            ActionsAndBenefits action = this.GetActionAndBenefits();

            IdentifiableDTO<ActionAndBenefitsDTO> actionsAndBenefitsDTO = ActionAndBenefitsMapper.MapActionsAndBenefitsEntityToActionsAndBenefitsIdentifierDTO(action);

            Assert.True(IsEqualeActionsAndBenefitsPersistanceAndActionsAndBenefitsEntity(actionsAndBenefitsDTO, action));
        }

        public bool IsEqualeActionsAndBenefitsPersistanceAndActionsAndBenefitsEntity(IdentifiableDTO<ActionAndBenefitsDTO> actionsAndBenefitsDTO, ActionsAndBenefits action)
        {

            if (action.IDAction != actionsAndBenefitsDTO.Id)
                return false;
            if (action.IsApproved != actionsAndBenefitsDTO.EntityDTO.IsApproved)
                return false;

            if (!action.ActionName.Equals(actionsAndBenefitsDTO.EntityDTO.ActionName))
                return false;

            if (action.DateRange.StartDateTime != actionsAndBenefitsDTO.EntityDTO.BeginDate)
                return false;
            if (action.DateRange.EndDateTime != actionsAndBenefitsDTO.EntityDTO.EndDate)
                return false;
            if (action.Price.OldPrice != actionsAndBenefitsDTO.EntityDTO.OldCost)
                return false;
            if (action.Price.NewPrice != actionsAndBenefitsDTO.EntityDTO.NewCost)
                return false;

            return true;
        }


        private bool IsEqualeActionsAndBenefitsPersistanceAndActionsAndBenefitsEntity(ActionAndBenefitsPersistance actionsAndBenefitsPersistence, ActionsAndBenefits actions)
        {
            if (actions.IDAction != actionsAndBenefitsPersistence.ActionKey)
                return false;
            if (actions.IsApproved != actionsAndBenefitsPersistence.IsApproved)
                return false;

            if (!actions.ActionName.Equals(actionsAndBenefitsPersistence.ActionName))
                return false;

            if (actions.DateRange.StartDateTime != actionsAndBenefitsPersistence.BeginDate)
                return false;
            if (actions.DateRange.EndDateTime != actionsAndBenefitsPersistence.EndDate)
                return false;

            if (actions.Price.OldPrice != actionsAndBenefitsPersistence.OldCost)
                return false;

            if (actions.Price.NewPrice != actionsAndBenefitsPersistence.NewCost)
                return false;

            return true;
        }


        private ActionAndBenefitsPersistance GetActionAndBenefitsPersistance()
            => new ActionAndBenefitsPersistance()
            {
                ActionKey = Guid.Parse("11115a55-094f-4081-89b3-757cafbd5ea1"),
                ActionName = "Brufen",
                BeginDate = new DateTime(2020, 12, 21),
                EndDate = new DateTime(2020, 12, 31),
                OldCost = 320,
                NewCost = 200,
                IsApproved = false


            };
        private ActionsAndBenefits GetActionAndBenefits()
            => new ActionsAndBenefits()
            {
                IDAction = Guid.Parse("11115a55-094f-4081-89b3-757cafbd5ea1"),
                ActionName = "Brufen",
                DateRange = new DateRange(new DateTime(2020, 12, 21), new DateTime(2020, 12, 31)),
                Price = new Price(320 , 200),
                IsApproved = true
            };
    }
}
