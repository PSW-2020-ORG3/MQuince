using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.UrgentProcurement.Domain
{
    public class Medications
    {
        private Guid _keyMedication;

        public string Name { get; set; }

        public int Quantity { get; set; }

        public Medications()
        {

        }
        public Medications(Guid keyConsumtion, string name, int quantity)
        {
            _keyMedication = keyConsumtion;
            Name = name;
            Quantity = quantity;
        }
        public Medications(string name, int quantity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be empty");
            }
            else
            {
                Name = name;
                Quantity = quantity;
            }

        }
        public Guid KeyMedication
        {
            get { return _keyMedication; }
            set
            {
                _keyMedication = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(KeyMedication)) : value;
            }
        }
    }

}
