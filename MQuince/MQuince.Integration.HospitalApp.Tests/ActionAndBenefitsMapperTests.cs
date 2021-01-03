using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.DataProvider.Util;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
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

             if (action.IDAction != actionsAndBenefitsDTO.Key)
                 return false;
            if (action.IsApproved != actionsAndBenefitsDTO.IsApproved)
                return false;

            if (!action.ActionName.Equals(actionsAndBenefitsDTO.EntityDTO.ActionName))
                 return false;

             if (action.BeginDate != actionsAndBenefitsDTO.EntityDTO.BeginDate)
                 return false;
             if (action.EndDate != actionsAndBenefitsDTO.EntityDTO.EndDate)
                 return false;
             if (action.OldCost != actionsAndBenefitsDTO.EntityDTO.OldCost)
                 return false;
             if (action.NewCost != actionsAndBenefitsDTO.EntityDTO.NewCost)
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

             if (actions.BeginDate != actionsAndBenefitsPersistence.BeginDate)
                 return false;
             if (actions.EndDate != actionsAndBenefitsPersistence.EndDate)
                 return false;

             if (actions.OldCost != actionsAndBenefitsPersistence.OldCost)
                 return false;

             if (actions.NewCost != actionsAndBenefitsPersistence.NewCost)
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
                 BeginDate = new DateTime(2020, 12, 21),
                 EndDate = new DateTime(2020, 12, 31),
                 OldCost = 320,
                 NewCost = 200,
                 IsApproved = true


             };
     }
    }
