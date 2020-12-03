using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class DoctorDTO : StaffDTO
    {
        public string Biography { get; set; }
        public Guid Specialization { get; set; }
    }
}
