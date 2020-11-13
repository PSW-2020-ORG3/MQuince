using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("HospitalTreatment")]
    public class HospitalTreatmentPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateTo { get; set; }
        public string Note { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        [ForeignKey("SectorId")]
        public Guid SectorId { get; set; }
    }
}
