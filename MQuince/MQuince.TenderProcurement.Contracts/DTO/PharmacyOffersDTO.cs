using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.TenderProcurement.Contracts.DTO
{
    public class PharmacyOffersDTO
    {
        public Guid IdTender { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyEmail { get; set; }
        public string Medicationes { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public PharmacyOffersDTO() { }
    }
}
