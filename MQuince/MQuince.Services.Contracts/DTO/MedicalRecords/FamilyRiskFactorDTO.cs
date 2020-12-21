using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class FamilyRiskFactorDTO
    {
        public DateTime Date { get; set; }
        public Relationship Relationship { get; set; }
    }
}
