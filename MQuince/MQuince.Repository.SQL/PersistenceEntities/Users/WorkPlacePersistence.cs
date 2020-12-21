using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("WorkPlace")]
    public class WorkPlacePersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
