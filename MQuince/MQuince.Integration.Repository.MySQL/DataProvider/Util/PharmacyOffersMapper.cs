using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.DataProvider.Util
{
    public class PharmacyOffersMapper
    {
        public static PharmacyOffers MapPharmacyOffersPersistenceToPharmacyOffersEntity(PharmacyOffersPersistance pharmacyOffersPersistance)
        {
            if (pharmacyOffersPersistance == null) throw new ArgumentNullException();

            return new PharmacyOffers(pharmacyOffersPersistance.IdOffer,
                                      pharmacyOffersPersistance.IdTender,
                                      pharmacyOffersPersistance.PharmacyName,
                                      pharmacyOffersPersistance.PharmacyEmail,
                                      pharmacyOffersPersistance.Medicationes,
                                      pharmacyOffersPersistance.Quantity,
                                      pharmacyOffersPersistance.Price
                                      );

        }

        public static PharmacyOffersPersistance MapPharmacyOffersEntityToPharmacyOffersPersistance(PharmacyOffers pharmacyOffers)
        {
            if (pharmacyOffers == null) return null;

            PharmacyOffersPersistance retVal = new PharmacyOffersPersistance()
            {
                IdOffer = pharmacyOffers.IDOffer,
                IdTender = pharmacyOffers.IdTender,
                PharmacyName = pharmacyOffers.PharmacyName,
                PharmacyEmail = pharmacyOffers.PharmacyEmail,
                Medicationes = pharmacyOffers.Medicationes,
                Quantity = pharmacyOffers.Quantity,
                Price = pharmacyOffers.Price
            };
            return retVal;
        }
        public static IdentifiableDTO<PharmacyOffersDTO> MapPharmacyOffersEntityToPharmacyOffersIdentifierDTO(PharmacyOffers pharmacyOffers)
                => pharmacyOffers == null ? throw new ArgumentNullException()
                                            : new IdentifiableDTO<PharmacyOffersDTO>()
                                            {
                                                Key = pharmacyOffers.IDOffer,
                                                
                                                //IDTender = pharmacyOffers.IdTender,
                                                EntityDTO = new PharmacyOffersDTO()
                                                {
                                                    TenderID = pharmacyOffers.IdTender,
                                                    PharmacyName = pharmacyOffers.PharmacyName,
                                                    PharmacyEmail = pharmacyOffers.PharmacyEmail,
                                                    Medicationes = pharmacyOffers.Medicationes,
                                                    Quantity = pharmacyOffers.Quantity,
                                                    Price = pharmacyOffers.Price,

                                                }
                                            };

        public static IEnumerable<PharmacyOffers> MapPharmacyOffersPersistanceCollectionToPharmacyOffersEntityCollection(IEnumerable<PharmacyOffersPersistance> clients)
           => clients.Select(c => MapPharmacyOffersPersistenceToPharmacyOffersEntity(c));

    }
}
