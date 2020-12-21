using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class TreatmentReportDTO
    {
        public string Anamnesis { get; set; }
        public string Note { get; set; }
        public string Diagnosis { get; set; }
        public string Theraphy { get; set; }
        public Guid PatientId { get; set; }
        public Guid PrescriptionId { get; set; }
        public List<Guid> RefferalId = new List<Guid>();
    }
}
