using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Domain;
using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities.ActionAndBenefits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQuince.ActionAndBenefits.Infrastructure.Util
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
                                               Id = actionsAndBenefits.IDAction,
                                              
                                               EntityDTO = new ActionAndBenefitsDTO()
                                               {
                                                   IsApproved = actionsAndBenefits.IsApproved,
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
