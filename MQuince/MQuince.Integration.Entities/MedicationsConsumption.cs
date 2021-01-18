using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class MedicationsConsumption
    {

        private Guid _keyConsumtion;

        public string Name { get; set; }

        public DateTime DateOfConsumtion { get; set; }

        public int Quantity { get; set; }

        public MedicationsConsumption()
        {

        }
        public MedicationsConsumption(Guid keyConsumtion, string name, DateTime dateOfConsumtion, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException();
            _keyConsumtion = keyConsumtion;
            Name = name;
            DateOfConsumtion = dateOfConsumtion;
            Quantity = quantity;
        }
        public MedicationsConsumption(string name, DateTime dateOfConsumtion, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException();
            else if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name can not be empty");
            }
            else
            {
                Name = name;
                DateOfConsumtion = dateOfConsumtion;
                Quantity = quantity;
            }
            
        }


        public Guid KeyConsumtion
        {
            get { return _keyConsumtion; }
            set
            {
                _keyConsumtion = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(KeyConsumtion)) : value;
            }
        }
    }
}
