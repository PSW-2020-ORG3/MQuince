using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.DTO
{
    public class ActionAndBenefitsDTO
    {
        public string PharmacyName { get; set; }
        public string ActionName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double OldCost { get; set; }
        public double NewCost { get; set; }

        public ActionAndBenefitsDTO() { }

        public ActionAndBenefitsDTO(string pharmacyName, string actionName, DateTime beginDate, DateTime endDate, double oldCost, double newCost)
        {
            PharmacyName = pharmacyName;
            ActionName = actionName;
            BeginDate = beginDate;
            EndDate = endDate;
            OldCost = oldCost;
            NewCost = newCost;
        }
    }
 }
