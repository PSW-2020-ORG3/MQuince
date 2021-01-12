using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.UrgentProcurement.Contracts.DTO
{
    public class MedicationsDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public MedicationsDTO()
        {
        }

        public MedicationsDTO(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

    }
}
