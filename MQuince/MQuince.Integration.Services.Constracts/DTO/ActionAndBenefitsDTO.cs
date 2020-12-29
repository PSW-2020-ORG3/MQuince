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
    }
 }
