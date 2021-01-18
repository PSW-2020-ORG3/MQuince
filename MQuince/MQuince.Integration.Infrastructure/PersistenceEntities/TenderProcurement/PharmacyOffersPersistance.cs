using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Integration.Infrastructure.PersistenceEntities.TenderProcurement
{
    [Table("PharmacyOffersPersistance")]
    public class PharmacyOffersPersistance
    {
        [Key]
        public Guid IdOffer { get; set; }
        [Required]
        public Guid IdTender { get; set; }
        [Required]
        public string PharmacyName { get; set; }
        [Required]
        public string PharmacyEmail { get; set; }
        [Required]
        public string Medicationes { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Price { get; set; }

        public PharmacyOffersPersistance() { }

        public PharmacyOffersPersistance(Guid idOffer, Guid idTender, string pharmacyName, string pharmacyEmail, string medication, string quantity, string price)
        {
            IdOffer = idOffer;
            IdTender = idTender;
            PharmacyName = pharmacyName;
            PharmacyEmail = pharmacyEmail;
            Medicationes = medication;
            Quantity = quantity;
            Price = price;

        }
    }
}
