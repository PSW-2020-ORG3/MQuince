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
        private readonly IMedicationsConsumptionRepository _medicationsConsumptionReposotiry;

        public MedicationsConsumptationService(IMedicationsConsumptionRepository medicationsConsumptionReposotiry)
        {
            _medicationsConsumptionReposotiry = medicationsConsumptionReposotiry;
        }

        public Guid Create(MedicationsConsumptionDTO entityDTO)
        {
            MedicationsConsumption medicationsConsumption = CreateMedicationsConsumptionFromDTO(entityDTO);

            _medicationsConsumptionReposotiry.Create(medicationsConsumption);

            return medicationsConsumption.getKeyConsumtion;
        }

        public bool Delete(Guid id) => _medicationsConsumptionReposotiry.Delete(id);

        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetAll()
            => _medicationsConsumptionReposotiry.GetAll().Select(c => CreateDTOFromMedicationsConsumption(c));

        public IdentifiableDTO<MedicationsConsumptionDTO> GetByApi(Guid id) => CreateDTOFromMedicationsConsumption(_medicationsConsumptionReposotiry.GetById(id));

        public IEnumerable<MedicationsConsumption> getConsumptionBetweenDates(DateTime from, DateTime to)
        {
            IEnumerable<MedicationsConsumption> listMedicationsConsumtion = (IEnumerable<MedicationsConsumption>)GetAll();
            IEnumerable<MedicationsConsumption> listMedicationsByDate = null;
            foreach (MedicationsConsumption entity in listMedicationsConsumtion)
            {
                if (entity.DateOfConsumtion >= from || entity.DateOfConsumtion <= to)
                    listMedicationsByDate.Append(entity);

            }

            return listMedicationsByDate;


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
