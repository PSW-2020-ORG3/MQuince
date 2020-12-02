using iTextSharp.text;
using iTextSharp.text.pdf;
using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MQuince.Integration.Services.Implementation
{
    public class MedicationsConsumptationService : IMedicationsConsumptionService
    {
        private readonly IMedicationsConsumptionRepository _medicationsConsumptionRepository;
        IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> listMedicationsByDate= new List<IdentifiableDTO<MedicationsConsumptionDTO>>();

        public MedicationsConsumptationService(IMedicationsConsumptionRepository medicationsConsumptionReposotiry)
        {
            _medicationsConsumptionRepository = medicationsConsumptionReposotiry;
        }

        public Guid Create(MedicationsConsumptionDTO entityDTO)
        {
            MedicationsConsumption medicationsConsumption = CreateMedicationsConsumptionFromDTO(entityDTO);

            _medicationsConsumptionRepository.Create(medicationsConsumption);

            return medicationsConsumption.getKeyConsumtion;
        }

        public bool Delete(Guid id) => _medicationsConsumptionRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetAll()
            => _medicationsConsumptionRepository.GetAll().Select(c => CreateDTOFromMedicationsConsumption(c));

        public IdentifiableDTO<MedicationsConsumptionDTO> GetByApi(Guid id) => CreateDTOFromMedicationsConsumption(_medicationsConsumptionRepository.GetById(id));


        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetConsumptionBetweenDates(DateTime from, DateTime to)
        {
            
            foreach (IdentifiableDTO<MedicationsConsumptionDTO> medication in GetAll().ToList())
            {
                if (medication.EntityDTO.DateOfConsumtion >= from && medication.EntityDTO.DateOfConsumtion <= to)
                {
                    listMedicationsByDate.Append(medication);
                }
            }
            
            return listMedicationsByDate;


        }
        
        public void GeneratePdf(DateDTO dto)
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("izvjestaj.pdf", FileMode.Create));
            doc.Open();

            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("\t\t Medications consumption records \n");
            doc.Add(p);


            foreach (IdentifiableDTO<MedicationsConsumptionDTO> medication in GetAll().ToList())
            {
                if (medication.EntityDTO.DateOfConsumtion >= dto.From && medication.EntityDTO.DateOfConsumtion <= dto.To)
                {
                    iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph("\n Name:  " + medication.EntityDTO.Name + "  -- Quantity: " + medication.EntityDTO.Quantity + " -- Date: " + medication.EntityDTO.DateOfConsumtion);
                    doc.Add(p1);
                }
            }
            doc.Close();
            
        }

        public void Update(MedicationsConsumptionDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }

        private IdentifiableDTO<MedicationsConsumptionDTO> CreateDTOFromMedicationsConsumption(MedicationsConsumption medicationsConsumptation)
        {
            if (medicationsConsumptation == null) return null;

            return new IdentifiableDTO<MedicationsConsumptionDTO>()
            {
                Key = medicationsConsumptation.getKeyConsumtion,
                EntityDTO = new MedicationsConsumptionDTO()
                {
                    Name = medicationsConsumptation.Name,
                    DateOfConsumtion = medicationsConsumptation.DateOfConsumtion,
                    Quantity = medicationsConsumptation.Quantity
                }

            };
        }

        private MedicationsConsumption CreateMedicationsConsumptionFromDTO(MedicationsConsumptionDTO medicationsConsumptation, Guid? keyConsumption = null)
          => keyConsumption == null ? new MedicationsConsumption(medicationsConsumptation.Name, medicationsConsumptation.DateOfConsumtion, medicationsConsumptation.Quantity)
                        : new MedicationsConsumption(keyConsumption.Value, medicationsConsumptation.Name,
                            medicationsConsumptation.DateOfConsumtion, medicationsConsumptation.Quantity);


    }
}
