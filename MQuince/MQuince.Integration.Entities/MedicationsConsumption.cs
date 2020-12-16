using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class MedicationsConsumption
    {

        private Guid KeyConsumtion { get; set; }

        public string Name { get; set; }

        public DateTime DateOfConsumtion { get; set; }

        public int Quantity { get; set; }

        public MedicationsConsumption()
        {

        }
        public MedicationsConsumption(Guid keyConsumtion, string name, DateTime dateOfConsumtion, int quantity)
        {
            KeyConsumtion = keyConsumtion;
            Name = name;
            DateOfConsumtion = dateOfConsumtion;
            Quantity = quantity;
        }
        public MedicationsConsumption(string name, DateTime dateOfConsumtion, int quantity)
        {
            Name = name;
            DateOfConsumtion = dateOfConsumtion;
            Quantity = quantity;
        }


        public Guid getKeyConsumtion
        {
            get { return KeyConsumtion; }
            private set
            {
                KeyConsumtion = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(getKeyConsumtion)) : value;
            }
        }
    }
}
