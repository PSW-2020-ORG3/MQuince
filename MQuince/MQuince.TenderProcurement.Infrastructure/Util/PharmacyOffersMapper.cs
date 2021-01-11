using MQuince.Core.IdentifiableDTO;
using MQuince.Integration.Infrastructure.PersistenceEntities.TenderProcurement;
using MQuince.TenderProcurement.Contracts.DTO;
using MQuince.TenderProcurement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.TenderProcurement.Infrastructure.Util
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
                                                Id = pharmacyOffers.IDOffer,

                                                EntityDTO = new PharmacyOffersDTO()
                                                {
                                                    IdTender = pharmacyOffers.IdTender,
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
