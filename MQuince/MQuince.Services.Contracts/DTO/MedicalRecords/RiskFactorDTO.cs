using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class RiskFactorDTO
    {
        public DateTime Date { get; set; }
        public Guid MedicalStatusId { get; set; }
        public Guid riskFactorId { get; set; }
    }
}
