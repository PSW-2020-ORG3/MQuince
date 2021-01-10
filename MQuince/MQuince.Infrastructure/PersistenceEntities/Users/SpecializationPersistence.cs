using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Users
{
    [Table("Specialization")]
    public class SpecializationPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
