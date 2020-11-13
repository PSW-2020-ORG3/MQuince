using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("UrgentSurgeryRequest")]
    public class UrgentSurgeryRequestPersistence
    {
        [Key]
        public Guid _id;
        public bool Approved { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        [ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        public Guid SpecializationId { get; set; }

        

    }
}
