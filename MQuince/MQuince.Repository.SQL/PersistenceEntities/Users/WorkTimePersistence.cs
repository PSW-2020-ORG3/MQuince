using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("WorkTime")]
    public class WorkTimePersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("WorkDayId")]
        public List<Guid> WorkDayId { get; set; }
        [ForeignKey("StaffId")]
        public Guid StaffId { get; set; }
    }
}
