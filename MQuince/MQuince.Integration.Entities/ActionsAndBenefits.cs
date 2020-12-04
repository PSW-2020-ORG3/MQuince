using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class ActionsAndBenefits
    {
        public string Message { get; set; }
        private Guid _id { get; set; }

        public ActionsAndBenefits(Guid id, string name = "")
        {
            _id = id;
            Message = name;
        }
        public ActionsAndBenefits(string message)
        {
            Message = message;
        }
        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

    }
}
