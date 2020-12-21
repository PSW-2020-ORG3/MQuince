using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Diagnosis
{
    public class SymptomDTO
    {
        public string Name { get; set; }
        public List<Guid> DiagnosisId { get; set; }
    }
}
