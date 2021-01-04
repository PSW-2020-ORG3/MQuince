using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Autentication.Contracts.DTO
{
    public class PatientDTO : UserDTO
    {
        public bool Guest { get; set; }
        public Guid PersonalDoctor { get; set; }
    }
}
