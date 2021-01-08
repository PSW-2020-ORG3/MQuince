using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Drug
{
    [Table("Allergen")]
    public class AllergenPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
