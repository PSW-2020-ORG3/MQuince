using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.TenderProcurement.Contracts.DTO
{
    public class TenderDTO
    {
        public string Name { get; set; }

        public string Descritpion { get; set; }

        public string FormLink { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Boolean Opened { get; set; }

        public TenderDTO() { }

    }
}
