using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class PharmacyOffers
    {

        private Guid _idOffer;        
        public Guid IdTender { get; set; }
        public string PharmacyName { get; set; }       
        public string PharmacyEmail { get; set; }        
        public string Medicationes { get; set; }     
        public string Quantity { get; set; }        
        public string Price { get; set; }

        public PharmacyOffers() { }
        public PharmacyOffers(Guid idOffer, Guid idTender, string pharmacyName, string pharmacyEmail, string medication, string quantity, string price)
        {
            _idOffer = idOffer;
            IdTender = idTender;
            PharmacyName = pharmacyName;
            PharmacyEmail = pharmacyEmail;
            Medicationes = medication;
            Quantity = quantity;
            Price = price;

        }

        public PharmacyOffers(Guid idTender, string pharmacyName, string pharmacyEmail, string medication, string quantity, string price)
        {
            IDOffer = Guid.NewGuid();
            IdTender = idTender;
            PharmacyName = pharmacyName;
            PharmacyEmail = pharmacyEmail;
            Medicationes = medication;
            Quantity = quantity;
            Price = price;

        }

        public Guid IDOffer
        {
            get { return _idOffer; }
            set
            {
                _idOffer = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty!", nameof(IDOffer)) : value;
            }
        }

    }
}
