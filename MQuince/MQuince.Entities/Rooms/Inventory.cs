using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Rooms
{
    public class Inventory
    {
        private Guid _id;
        public string Name { get; set; }
        public int QuantityStorage { get; set; }
        public int QuantityHospital { get; set; }
        public Guid InventoryTypeId { get; set; }

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
