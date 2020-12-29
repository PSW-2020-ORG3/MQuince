using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.PersistenceEntities
{
    [Table("ActionAndBenefits")]
    public class ActionAndBenefitsPersistance
    {
        [Key]
        public Guid ActionKey { get; set; }
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double OldCost { get; set; }
        [Required]
        public double NewCost { get; set; }

        public ActionAndBenefitsPersistance() { }
        public ActionAndBenefitsPersistance(Guid actionKey, string pharmacyName, string actionName, DateTime beginDate, DateTime endDate, double oldCost, double newCost)
        {
            ActionKey = actionKey;
            PharmacyName = pharmacyName;
            ActionName = actionName;
            BeginDate = beginDate;
            EndDate = endDate;
            OldCost = oldCost;
            NewCost = newCost;

        }
    }
}
