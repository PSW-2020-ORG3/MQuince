using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Rooms
{
    public class InventoryAmount
    {
        private Guid _id;
        public int Amount { get; set; }
        public int Usage { get; set; } = 0;
        public Guid InventoryId { get; set; }
        public Guid RoomId { get; set; }

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
