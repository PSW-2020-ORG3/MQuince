using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataReport
{
    public class TreatmentReportDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}
