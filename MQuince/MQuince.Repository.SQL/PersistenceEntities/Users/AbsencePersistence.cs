using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MQuince.Enums;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Absencet")]
    public class AbsencePersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AbsenceType AbsenceType { get; set; }
        public string Reason { get; set; }
        public bool Approved { get; set; }

        [ForeignKey("StaffId")]
        public Guid StaffId { get; set; }
    }
}
