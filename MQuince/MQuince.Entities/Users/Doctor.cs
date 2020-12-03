using MQuince.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Doctor : Staff
    {
        public string Biography { get; set; }
        public Guid SpecializationId { get; set; }
    }
}
