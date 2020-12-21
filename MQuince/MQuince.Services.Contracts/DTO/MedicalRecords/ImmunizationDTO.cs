using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class ImmunizationDTO
    {
        public DateTime Date { get; set; }
        public GivingType GivingType { get; set; }
        public VaccineType VaccineType { get; set; }

        public Guid Vaccine { get; set; }
    }
}
