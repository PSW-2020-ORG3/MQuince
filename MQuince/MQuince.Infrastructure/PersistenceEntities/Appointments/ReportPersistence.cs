using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Appointments
{
    [Table("Report")]
    public class ReportPersistence
    {
        [Key]
        public Guid Id { get; set; }

        public string Report { get; set; }

        [ForeignKey("AppointmentPersistanceId")]
        public Guid AppointmentPersistanceId { get; set; }
        public AppointmentPersistence AppointmentPersistance { get; set; }

    }
}
