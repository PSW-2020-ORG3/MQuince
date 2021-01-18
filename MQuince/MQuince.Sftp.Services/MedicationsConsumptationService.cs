using iTextSharp.text;
using iTextSharp.text.pdf;
using MQuince.Core.IdentifiableDTO;
using MQuince.Sftp.Constracts.DTO;
using MQuince.Sftp.Constracts.Repository;
using MQuince.Sftp.Constracts.Services;
using MQuince.Sftp.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MQuince.Sftp.Services
{
    public class MedicationsConsumptationService : IMedicationsConsumptionService
    {
        private readonly IMedicationsConsumptionRepository _medicationsConsumptionRepository;
        IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> listMedicationsByDate = new List<IdentifiableDTO<MedicationsConsumptionDTO>>();

        public MedicationsConsumptationService(IMedicationsConsumptionRepository medicationsConsumptionReposotiry)
        {
            _medicationsConsumptionRepository = medicationsConsumptionReposotiry == null ? throw new ArgumentNullException(nameof(medicationsConsumptionReposotiry) + "is set to null") : medicationsConsumptionReposotiry;
        }

        public Guid Create(MedicationsConsumptionDTO entityDTO)
        {
            MedicationsConsumption medicationsConsumption = CreateMedicationsConsumptionFromDTO(entityDTO);

            _medicationsConsumptionRepository.Create(medicationsConsumption);

            return medicationsConsumption.KeyConsumtion;
        }

        public bool Delete(Guid id) => _medicationsConsumptionRepository.Delete(id);


        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetAll()
            => _medicationsConsumptionRepository.GetAll().Select(c => CreateDTOFromMedicationsConsumption(c));

        public IdentifiableDTO<MedicationsConsumptionDTO> GetById(Guid id) => CreateDTOFromMedicationsConsumption(_medicationsConsumptionRepository.GetById(id));



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
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("Report_" + dto.From.Day.ToString() + "." + dto.From.Month.ToString() + "." + dto.From.Year.ToString() +"-"+ dto.To.Day.ToString() + "." + dto.To.Month.ToString() + "." + dto.To.Year.ToString() + ".pdf", FileMode.Create));
            

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
            _medicationsConsumptionRepository.Update(CreateMedicationsConsumptionFromDTO(entityDTO));
        }

        private IdentifiableDTO<MedicationsConsumptionDTO> CreateDTOFromMedicationsConsumption(MedicationsConsumption medicationsConsumptation)
        {
            if (medicationsConsumptation == null) return null;

            return new IdentifiableDTO<MedicationsConsumptionDTO>()
            {
                Id = medicationsConsumptation.KeyConsumtion,
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
