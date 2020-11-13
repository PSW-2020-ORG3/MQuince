using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("InventoryType")]
    public class InventoryTypePersistence
    {
        [Key]
        public Guid _id;
        public string Name { get; set; }
    }
}
