using MQuince.Entities.MedicalRecords;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.DataReport
{
    public class PatientTreatmentReportDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public Patient Patient { get; set; }
        public IList<Treatment> Treatment { get; set; }
    }
}
