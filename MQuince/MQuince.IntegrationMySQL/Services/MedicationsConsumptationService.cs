using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Pharmacy;
using MQuince.IntegrationMySQL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.IntegrationMySQL.Services
{
    public class MedicationsConsumptationService : IMedicationsConsumptionService
    {
        private readonly IMedicationsConsumptionRepository _medicationsConsumptionRepository;
        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> listMedicationsByDate = null;

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


        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> getConsumptionBetweenDates(DateTime from, DateTime to)
        {
           /* IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> listMedicationsConsumtion = GetAll();
       
            
            foreach (IdentifiableDTO<MedicationsConsumptionDTO> entity in listMedicationsConsumtion)
            {
                if (entity.EntityDTO.DateOfConsumtion >= from || entity.EntityDTO.DateOfConsumtion <= to)
                    listMedicationsByDate.Append(entity);

            }*/

            return null;


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
