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
    public class TenderMapper
    {
        public static Tender MapTenderPersistenceToTenderEntity(TenderPersistance tenderPersistance)
        {
            if (tenderPersistance == null) throw new ArgumentNullException();

            return new Tender(tenderPersistance.Id,
                                                tenderPersistance.Name,
                                                tenderPersistance.Descritpion,
                                                tenderPersistance.FormLink,
                                                tenderPersistance.StartDate,
                                                tenderPersistance.EndDate,

                                                tenderPersistance.Opened);

        }

        public static TenderPersistance MapTenderEntityToTenderPersistance(Tender tender)
        {

            if (tender == null) return null;

            TenderPersistance retVal = new TenderPersistance()
            {
                Id = tender.Id,
                Name = tender.Name,
                Descritpion = tender.Descritpion,
                FormLink = tender.FormLink,
                StartDate = tender.StartDate,
                EndDate = tender.EndDate,
                Opened = tender.Opened
            };
            return retVal;
        }


        public static IdentifiableDTO<TenderDTO> MapTenderEntityToTenderIdentifierDTO(Tender tender)
                => tender == null ? throw new ArgumentNullException()
                                            : new IdentifiableDTO<TenderDTO>()
                                            {
                                                Id = tender.Id,
                                                EntityDTO = new TenderDTO()
                                                {
                                                    Name = tender.Name,
                                                    Descritpion = tender.Descritpion,
                                                    FormLink = tender.FormLink,
                                                    StartDate = tender.StartDate,
                                                    EndDate = tender.EndDate,
                                                    Opened = tender.Opened
                                                }
                                            };
        public static IEnumerable<Tender> MapTenderPersistanceCollectionToTenderEntityCollection(IEnumerable<TenderPersistance> clients)
           => clients.Select(c => MapTenderPersistenceToTenderEntity(c));


    }
}
