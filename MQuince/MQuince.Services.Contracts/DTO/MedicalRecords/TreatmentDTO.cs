using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class TreatmentDTO
    {
        public DateTime Date { get; set; }
        public TreatmentType Type { get; set; }
        public Guid TreatmentReportId { get; set; }
        public String Creator { get; set; }
    }
}
