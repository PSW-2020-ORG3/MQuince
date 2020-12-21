using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Rooms
{
    public class Renovate
    {
        private Guid _id;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Note { get; set; }
        public Guid RoomId { get; set; }

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
