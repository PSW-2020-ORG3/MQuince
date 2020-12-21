using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("TreatmentReport")]
    public class TreatmentReportPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Anamnesis { get; set; }
        public string Note { get; set; }
        public string Diagnosis { get; set; }
        public string Theraphy { get; set; }
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        public Guid PrescriptionId { get; set; }
        public List<Guid> RefferalId = new List<Guid>();

    }

}
