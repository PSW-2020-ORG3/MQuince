using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Rooms
{
    public class Room
    {
        private Guid _id;
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
        public double RoomSize { get; set; }
        public int Floor { get; set; }
        public Guid SectorId { get; set; }
        public List<Guid> PatientsId;

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
