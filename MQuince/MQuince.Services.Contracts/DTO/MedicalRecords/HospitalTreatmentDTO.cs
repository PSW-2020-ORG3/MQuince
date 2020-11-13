using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.MedicalRecords
{
    public class HospitalTreatmentDTO
    {
        public DateTime Date { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }
        public Guid PatientId { get; set; }
        public Guid RoomId { get; set; }
        public Guid SectorId { get; set; }
    }
}
