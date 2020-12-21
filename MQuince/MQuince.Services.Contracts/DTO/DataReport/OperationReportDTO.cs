using MQuince.Entities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataReport
{
    public class OperationReportDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<Treatment> Treatment { get; set; }
    }
}
