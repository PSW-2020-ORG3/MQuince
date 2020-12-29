using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class ActionsAndBenefits
    {
        private Guid _actionKey;
        public string PharmacyName { get; set; }
        public string ActionName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double OldCost { get; set; }
        public double NewCost { get; set; }

        public ActionsAndBenefits(Guid actionKey, string pharmacyName, string actionName, DateTime beginDate, DateTime endDate, double oldCost, double newCost)
        {
            _actionKey = actionKey;
            PharmacyName = pharmacyName;
            ActionName = actionName;
            BeginDate = beginDate;
            EndDate = endDate;
            OldCost = oldCost;
            NewCost = newCost;

        }
        public ActionsAndBenefits() { }

        public ActionsAndBenefits(string pharmacyName, string actionName, DateTime beginDate, DateTime endDate, double oldCost, double newCost)
        {
            if (string.IsNullOrEmpty(pharmacyName) && string.IsNullOrEmpty(actionName) && double.IsNaN(oldCost) && double.IsNaN(newCost))
            {
                throw new ArgumentException("Fields can not be empty");
            }
            else
            {
                IDAction = Guid.NewGuid();
                PharmacyName = pharmacyName;
                ActionName = actionName;
                BeginDate = beginDate;
                EndDate = endDate;
                OldCost = oldCost;
                NewCost = newCost;
            }
        }

        public Guid IDAction
        {
            get { return _actionKey; }
            set
            {
                _actionKey = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(IDAction)) : value;
            }
        }

    }
}
