using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Rooms
{
    public class InventoryAmountDTO
    {
        public int Amount { get; set; }
        public int Usage { get; set; } = 0;
        public Guid InventoryId { get; set; }
        public Guid RoomId { get; set; }
    }
}
