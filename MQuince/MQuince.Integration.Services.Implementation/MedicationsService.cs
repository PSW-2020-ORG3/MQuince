﻿using MQuince.Integration.Entities;
using MQuince.Integration.Repository.Contracts;
using MQuince.Integration.Repository.MySQL.DataProvider;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Integration.Services.Implementation
{
    public class MedicationsService : IMedicationsService
    {
        private readonly IMedicationsRepository _medicationsRepository;

        public MedicationsService(IMedicationsRepository medicationsReposotiry)
        {
            _medicationsRepository = medicationsReposotiry == null ? throw new ArgumentNullException(nameof(medicationsReposotiry) + "is set to null") : medicationsReposotiry;
        }

        public string[] GetData(string data) {
            return  data.Split("|");

        }
        public Guid Create(MedicationsDTO entityDTO)
        {
            Medications medications = CreateMedicationsFromDTO(entityDTO);

            _medicationsRepository.Create(medications);

            return medications.KeyMedication;
        }

        public bool Delete(Guid id) => _medicationsRepository.Delete(id);


        public bool DeleteByName(string name) => _medicationsRepository.DeleteByName(name);




        public IEnumerable<IdentifiableDTO<MedicationsDTO>> GetAll()
            => _medicationsRepository.GetAll().Select(c => CreateDTOFromMedications(c));


        public IdentifiableDTO<MedicationsDTO> GetByID(Guid id) => CreateDTOFromMedications(_medicationsRepository.GetById(id));

        public IdentifiableDTO<MedicationsDTO> GetByName(String name) => CreateDTOFromMedications(_medicationsRepository.GetByName(name));

        public void Update(MedicationsDTO entityDTO, Guid id)
        {
            _medicationsRepository.Update(CreateMedicationsFromDTO(entityDTO));
        }

        private IdentifiableDTO<MedicationsDTO> CreateDTOFromMedications(Medications medications)
        {
            if (medications == null) return null;

            return new IdentifiableDTO<MedicationsDTO>()
            {
                Key = medications.KeyMedication,
                EntityDTO = new MedicationsDTO()
                {
                    Name = medications.Name,
                    Quantity = medications.Quantity
                }

            };
        }

        private Medications CreateMedicationsFromDTO(MedicationsDTO medication)
          => new Medications(medication.Name, medication.Quantity);
    }
}

