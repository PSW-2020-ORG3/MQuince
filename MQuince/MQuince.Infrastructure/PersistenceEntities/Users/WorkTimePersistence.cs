using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Users
{
    [Table("WorkTime")]
    public class WorkTimePersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }

        [ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        public DoctorPersistence Doctor { get; set; }
    }
}
