using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MQuince.Enums;

namespace MQuince.Repository.SQL.PersistenceEntities.Rooms
{
    [Table("Room")]
    public class RoomPersistence
    {
        [Key]
        public Guid _id;
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
        public double RoomSize { get; set; }
        public int Floor { get; set; }
        [ForeignKey("SectorId")]
        public Guid SectorId { get; set; }
        [ForeignKey("PatientsId")]
        public List<Guid> PatientsId;
    }
}
