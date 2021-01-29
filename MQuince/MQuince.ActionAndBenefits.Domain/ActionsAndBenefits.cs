using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.ActionAndBenefits.Domain
{
    public class ActionsAndBenefits
    {
        private Guid _actionKey;
        public string PharmacyName { get; set; }
        public string ActionName { get; set; }
        public DateRange DateRange { get; set;}
        public Price Price { get; set; }
        public bool IsApproved { get; set; }

        public void Approve()
        {
            IsApproved = true;
        }
        public ActionsAndBenefits(Guid actionKey, string pharmacyName, string actionName, DateTime beginDate, DateTime endDate, double oldCost, double newCost, Boolean isApproved)
        {
            _actionKey = actionKey;
            PharmacyName = pharmacyName;
            ActionName = actionName;
            DateRange = new DateRange(beginDate, endDate);
            Price = new Price(oldCost, newCost);
            IsApproved = isApproved;
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
                DateRange = new DateRange(beginDate, endDate);
                Price = new Price(oldCost, newCost);
                IsApproved = false;
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
