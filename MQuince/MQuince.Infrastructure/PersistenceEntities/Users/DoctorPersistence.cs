using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Users
{
    [Table("Doctor")]
    public class DoctorPersistence : UserPersistence
    {
        public string Biography { get; set; }
        [ForeignKey("SpecializationId")]
        public Guid SpecializationId { get; set; }
        public SpecializationPersistence Specialization { get; set; }
    }
}
