using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Rooms
{
    public class RenovateDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Note { get; set; }
        public Guid RoomId { get; set; }
    }
}
