using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class DoctorDTO : StaffDTO
    {
        public string Biography { get; set; }
        public List<Guid> SpecializationId { get; set; }
        public Guid WorkRoomId { get; set; }
        public Guid WorkPlaceId { get; set; }
    }
}
