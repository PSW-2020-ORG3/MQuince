using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Rooms
{
    public class InventoryDTO
    {
        public string Name { get; set; }
        public int QuantityStorage { get; set; }
        public int QuantityHospital { get; set; }
        public Guid InventoryTypeId { get; set; }
    }
}
