using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("City")]
    public class CityPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PostNumber { get; set; }
        [ForeignKey("CountryId")]
        public Guid CountryId { get; set; }
    }
}
