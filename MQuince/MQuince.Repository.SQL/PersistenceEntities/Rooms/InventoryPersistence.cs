using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("Inventory")]
    public class InventoryPersistence
    {
        [Key]
        public Guid _id;
        public string Name { get; set; }
        public int QuantityStorage { get; set; }
        public int QuantityHospital { get; set; }

        [ForeignKey("InventoryTypeId")]
        public Guid InventoryTypeId { get; set; }
    }
}
