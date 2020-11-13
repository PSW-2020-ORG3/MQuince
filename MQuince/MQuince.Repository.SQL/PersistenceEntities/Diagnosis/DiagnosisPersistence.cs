using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Diagnosis
{
    [Table("Diagnosis")]
    public class DiagnosisPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Theraphy { get; set; }
        [ForeignKey("SymptomsId")]
        public List<Guid> SymptomsId = new List<Guid>();
        [ForeignKey("TheraphyDrugsId")]
        public List<Guid> TheraphyDrugsId = new List<Guid>();
        public string DoctorCreated { get; set; }
    }
}
