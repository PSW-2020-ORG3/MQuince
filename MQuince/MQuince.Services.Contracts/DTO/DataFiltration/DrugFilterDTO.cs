using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataFiltration
{
    public class DrugFilterDTO
    {
        public string Name { get; set; }
        public int Status { get; set; }
        public string Manufacturer { get; set; }
        public int AmountFrom { get; set; }
        public int AmountTo { get; set; }

    }
}
