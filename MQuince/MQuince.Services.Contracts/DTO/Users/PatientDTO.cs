using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Users
{
    public class PatientDTO : UserDTO
    {
        public bool Guest { get; set; }

        public Guid PersonalDoctor { get; set; }
    }
}
