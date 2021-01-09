using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MQuince.Integration.Services.Implementation
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
                Key = pharmacyOffers.IDOffer,
                EntityDTO = new PharmacyOffersDTO()
                {
                    TenderID = pharmacyOffers.IdTender,
                    PharmacyName = pharmacyOffers.PharmacyName,
                    PharmacyEmail = pharmacyOffers.PharmacyEmail,
                    Medicationes = pharmacyOffers.Medicationes,
                    Quantity = pharmacyOffers.Quantity,
                    Price = pharmacyOffers.Price
                }

            };

        }

        private PharmacyOffers CreatePharmacyOffersFromDTO(PharmacyOffersDTO pharmacyOffers, Guid? idOffer = null)
          => idOffer == null ? new PharmacyOffers(pharmacyOffers.TenderID, pharmacyOffers.PharmacyName,pharmacyOffers.PharmacyEmail , pharmacyOffers.Medicationes, pharmacyOffers.Quantity, pharmacyOffers.Price)
                        : new PharmacyOffers(idOffer.Value,pharmacyOffers.TenderID, pharmacyOffers.PharmacyName, pharmacyOffers.PharmacyEmail, pharmacyOffers.Medicationes, pharmacyOffers.Quantity, pharmacyOffers.Price);
        public Guid sendOffers(string id)
        {
            IdentifiableDTO<PharmacyOffersDTO> offer = null;
            String[] parts = id.Split("|");
            if (id.Contains("true"))
            {
                
                offer = GetById(new Guid(parts[0]));               
                sendEmail(true, offer);
               
            }

            else
            {
                offer = GetById(new Guid(parts[0]));
                sendEmail(false, offer);
                Console.WriteLine("NE SADRZI");
            }

            _pharmacyOffersRepository.Delete(new Guid(parts[0]));
            return new Guid(parts[0]);
            
        }

        private void sendEmail(Boolean value, IdentifiableDTO<PharmacyOffersDTO> offer)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("mquince.medic@gmail.com");
                mail.To.Add(offer.EntityDTO.PharmacyEmail);
                mail.Subject = "TENDER " + offer.EntityDTO.TenderID;

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
