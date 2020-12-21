using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class UrgentSurgeryRequestDTO
    {
        public bool Approved { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
