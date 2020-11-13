using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("InventoryAmount")]
    public class InventoryAmountPersistence
    {
        [Key]
        public Guid _id;
        public int Amount { get; set; }
        public int Usage { get; set; } = 0;

        [ForeignKey("InventoryId")]
        public Guid InventoryId { get; set; }
        public Guid RoomId { get; set; }
    }
}
