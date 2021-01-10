using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class ActionsAndBenefits
    {
        public string Action { get; set; }
        public string Date { get; set; }

        public ActionsAndBenefits(string _action, string _date)
        {
            this.Action = _action;
            this.Date = _date;
        }

    }
}
