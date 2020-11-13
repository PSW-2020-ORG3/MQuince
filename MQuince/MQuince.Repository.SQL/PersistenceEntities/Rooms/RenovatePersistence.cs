using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("Renovate")]
    public class RenovatePersistence
    {
        [Key]
        public Guid _id;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Note { get; set; }
        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
    }
}
