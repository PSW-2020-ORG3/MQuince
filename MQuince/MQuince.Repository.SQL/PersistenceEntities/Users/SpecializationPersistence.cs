using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Specialization")]
    public class SpecializationPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
