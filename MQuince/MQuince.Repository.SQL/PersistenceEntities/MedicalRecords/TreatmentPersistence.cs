using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MQuince.Enums;

namespace MQuince.Repository.SQL.PersistenceEntities.MedicalRecords
{
    [Table("Treatment")]
    public class TreatmentPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TreatmentType TypeId { get; set; }

        [ForeignKey("TreatmentReportId")]
        public Guid TreatmentReportId { get; set; }
        public String Creator { get; set; }
    }
}
