using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("Sector")]
    public class SectorPersistence
    {
        [Key]
        public Guid _id;
        public string Name { get; set; }
    }
}
