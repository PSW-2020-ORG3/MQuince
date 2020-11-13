using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Rooms
{
    public class RoomDTO
    {
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
        public double RoomSize { get; set; }
        public int Floor { get; set; }
        public Guid SectorId { get; set; }
        public List<Guid> PatientsId;
    }
}
