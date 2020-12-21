using MQuince.Entities.Rooms;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.DataFiltration
{
    public class RoomFilterDTO
    {
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public Sector Sector { get; set; }
        public double RoomSizeFrom { get; set; }
        public double RoomSizeTo { get; set; }


    }
}
