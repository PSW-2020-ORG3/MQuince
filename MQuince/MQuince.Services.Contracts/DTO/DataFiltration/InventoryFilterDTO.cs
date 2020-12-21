using MQuince.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataFiltration
{
    public class InventoryFilterDTO
    {
        public string Name { get; set; }
        public InventoryType inventoryType { get; set; }
        public int AmountFrom { get; set; }
        public int AmountTo { get; set; }

    }
}
