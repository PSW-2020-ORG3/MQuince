using MQuince.Core.IdentifiableDTO;
using MQuince.TenderProcurement.Contracts.DTO;
using MQuince.TenderProcurement.Contracts.Repository;
using MQuince.TenderProcurement.Contracts.Services;
using MQuince.TenderProcurement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.TenderProcurement.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository == null ? throw new ArgumentNullException(nameof(tenderRepository) + "is set to null") : tenderRepository;
        }

        public Guid Create(TenderDTO entityDTO)
        {
            Tender tender = CreateTenderFromDTO(entityDTO);

            _tenderRepository.Create(tender);

            return tender.Id;
        }

        public bool Delete(Guid id) => _tenderRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<TenderDTO>> GetAll()
             => _tenderRepository.GetAll().Select(c => CreateDTOFromTender(c));


        public IdentifiableDTO<TenderDTO> GetById(Guid id) => CreateDTOFromTender(_tenderRepository.GetById(id));

        public void Update(TenderDTO entityDTO, Guid id)
        {
            _tenderRepository.Update(CreateTenderFromDTO(entityDTO));
        }

        private IdentifiableDTO<TenderDTO> CreateDTOFromTender(Tender tender)
        {
            if (tender == null) return null;

            return new IdentifiableDTO<TenderDTO>()
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
        }

        private Tender CreateTenderFromDTO(TenderDTO tender, Guid? id = null)
          => id == null ? new Tender(tender.Name, tender.Descritpion, tender.FormLink,
                    tender.StartDate, tender.EndDate)
                        : new Tender(id.Value, tender.Name, tender.Descritpion, tender.FormLink,
                    tender.StartDate, tender.EndDate);


    }
}
