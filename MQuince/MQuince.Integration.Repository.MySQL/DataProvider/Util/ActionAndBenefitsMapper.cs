using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider.Util
{
    public class ActionAndBenefitsMapper
    {
        public static ActionsAndBenefits MapActionsAndBenefitsPersistenceToActionsAndBenefitsEntity(ActionAndBenefitsPersistance actionAndBenefitsPersistance)
        {
            if (actionAndBenefitsPersistance == null) throw new ArgumentNullException();

            return new ActionsAndBenefits(actionAndBenefitsPersistance.ActionKey,
                                                actionAndBenefitsPersistance.PharmacyName,
                                                actionAndBenefitsPersistance.ActionName,
                                                actionAndBenefitsPersistance.BeginDate,
                                                actionAndBenefitsPersistance.EndDate,
                                                actionAndBenefitsPersistance.OldCost,
                                                actionAndBenefitsPersistance.NewCost,
                                                actionAndBenefitsPersistance.IsApproved);

        }

        public static ActionAndBenefitsPersistance MapActionsAndBenefitsEntityToActionsAndBenefitsPersistance(ActionsAndBenefits actionsAndBenefits)
        {
            if (actionsAndBenefits == null) return null;

            ActionAndBenefitsPersistance retVal = new ActionAndBenefitsPersistance()
            {
                ActionKey = actionsAndBenefits.IDAction,
                PharmacyName = actionsAndBenefits.PharmacyName,
                ActionName = actionsAndBenefits.ActionName,
                BeginDate = actionsAndBenefits.BeginDate,
                EndDate = actionsAndBenefits.EndDate,
                OldCost = actionsAndBenefits.OldCost,
                NewCost = actionsAndBenefits.NewCost,
                IsApproved = actionsAndBenefits.IsApproved
            };
            return retVal;
        }

        public static IdentifiableDTO<ActionAndBenefitsDTO> MapActionsAndBenefitsEntityToActionsAndBenefitsIdentifierDTO(ActionsAndBenefits actionsAndBenefits)
               => actionsAndBenefits == null ? throw new ArgumentNullException()
                                           : new IdentifiableDTO<ActionAndBenefitsDTO>()
                                           {
                                               Key = actionsAndBenefits.IDAction,
                                               IsApproved = actionsAndBenefits.IsApproved,
                                               EntityDTO = new ActionAndBenefitsDTO()
                                               {
                                                   PharmacyName = actionsAndBenefits.PharmacyName,
                                                   ActionName = actionsAndBenefits.ActionName,
                                                   BeginDate = actionsAndBenefits.BeginDate,
                                                   EndDate = actionsAndBenefits.EndDate,
                                                   OldCost = actionsAndBenefits.OldCost,
                                                   NewCost = actionsAndBenefits.NewCost
                                               }
                                           };


        public static IEnumerable<ActionsAndBenefits> MapActionsAndBenefitsPersistanceCollectionToActionsAndBenefitsEntityCollection(IEnumerable<ActionAndBenefitsPersistance> clients)
           => clients.Select(c => MapActionsAndBenefitsPersistenceToActionsAndBenefitsEntity(c));
    }
}
