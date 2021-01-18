using MQuince.Core.IdentifiableDTO;
using MQuince.TenderProcurement.Contracts.DTO;
using MQuince.TenderProcurement.Contracts.Repository;
using MQuince.TenderProcurement.Contracts.Services;
using MQuince.TenderProcurement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MQuince.TenderProcurement.Services
{
    public class PharmacyOffersService : IPharmacyOffersService
    {
        private readonly IPharmacyOffersRepository _pharmacyOffersRepository;

        public PharmacyOffersService(IPharmacyOffersRepository pharmacyOffersRepository)
        {
            _pharmacyOffersRepository = pharmacyOffersRepository == null ? throw new ArgumentNullException(nameof(pharmacyOffersRepository) + "is set to null") : pharmacyOffersRepository;

        }


        public Guid Create(PharmacyOffersDTO entityDTO)
        {
            PharmacyOffers pharmacyOffers = CreatePharmacyOffersFromDTO(entityDTO);

            _pharmacyOffersRepository.Create(pharmacyOffers);

            return pharmacyOffers.IDOffer;
        }

        public bool Delete(Guid id) => _pharmacyOffersRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<PharmacyOffersDTO>> GetAll()
            => _pharmacyOffersRepository.GetAll().Select(c => CreateDTOFromPharmacyOffers(c));

        public IdentifiableDTO<PharmacyOffersDTO> GetById(Guid id)
            => CreateDTOFromPharmacyOffers(_pharmacyOffersRepository.GetById(id));


        public void Update(PharmacyOffersDTO entityDTO, Guid id)
        => _pharmacyOffersRepository.Update(CreatePharmacyOffersFromDTO(entityDTO));

        private IdentifiableDTO<PharmacyOffersDTO> CreateDTOFromPharmacyOffers(PharmacyOffers pharmacyOffers)
        {
            if (pharmacyOffers == null) return null;

            return new IdentifiableDTO<PharmacyOffersDTO>()
            {
                Id = pharmacyOffers.IDOffer,
                EntityDTO = new PharmacyOffersDTO()
                {
                    IdTender = pharmacyOffers.IdTender,
                    PharmacyName = pharmacyOffers.PharmacyName,
                    PharmacyEmail = pharmacyOffers.PharmacyEmail,
                    Medicationes = pharmacyOffers.Medicationes,
                    Quantity = pharmacyOffers.Quantity,
                    Price = pharmacyOffers.Price
                }

            };

        }

        private PharmacyOffers CreatePharmacyOffersFromDTO(PharmacyOffersDTO pharmacyOffers, Guid? idOffer = null)
          => idOffer == null ? new PharmacyOffers(pharmacyOffers.IdTender, pharmacyOffers.PharmacyName, pharmacyOffers.PharmacyEmail, pharmacyOffers.Medicationes, pharmacyOffers.Quantity, pharmacyOffers.Price)
                        : new PharmacyOffers(idOffer.Value, pharmacyOffers.IdTender, pharmacyOffers.PharmacyName, pharmacyOffers.PharmacyEmail, pharmacyOffers.Medicationes, pharmacyOffers.Quantity, pharmacyOffers.Price);
        public Guid sendOffers(Guid id, Boolean approve)
        {
            IdentifiableDTO<PharmacyOffersDTO> offer = GetById(id);
            sendEmail(approve, offer);
            _pharmacyOffersRepository.Delete(id);
            return id;
        }

        private void sendEmail(Boolean value, IdentifiableDTO<PharmacyOffersDTO> offer)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("mquince.medic@gmail.com");
                mail.To.Add(offer.EntityDTO.PharmacyEmail);
                mail.Subject = "TENDER " + offer.EntityDTO.IdTender;

                if (value)
                    mail.Body = textForBody(offer);

                else
                    mail.Body = "<h1>We didnt choose your offer!</h1><p>Hospital MQuince Medic. More luck next time. :) </p>";


                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("mquince.medic@gmail.com", "mucibabic123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }

        private String textForBody(IdentifiableDTO<PharmacyOffersDTO> offer)
        {
            return "<h1>CONGRATULATION!</h1>"
                    + "<p>We approve your offer! </p>"
                    + "<p> Medication: " + offer.EntityDTO.Medicationes + " </p>"
                    + "<p> Quantity: " + offer.EntityDTO.Quantity + " </p>"
                    + "<p> Price: " + offer.EntityDTO.Price + " </p>"
                    + "<h2> MQuince Medic </h2>";
        }






    }
}
