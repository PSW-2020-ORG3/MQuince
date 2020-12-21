using MQuince.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.DataFiltration
{
    public class RenovateFilterDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomNumber { get; set; }
        public Sector Sector { get; set; }
        public int RoomType { get; set; }

    }
}
