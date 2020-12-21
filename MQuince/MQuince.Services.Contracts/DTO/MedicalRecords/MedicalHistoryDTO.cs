using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class MedicalHistoryDTO
    {
        public DateTime Date { get; set; }
        public MedicalStatus MedicalStatus { get; set; }
        public Guid DiagnosisId { get; set; }
    }
}
