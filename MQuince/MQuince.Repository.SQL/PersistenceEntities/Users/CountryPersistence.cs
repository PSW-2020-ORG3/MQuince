using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Country")]
    public class CountryPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
