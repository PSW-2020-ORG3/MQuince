using System;

namespace MQuince.Autentication.Contracts.DTO
{
    public class PatientDTO : UserDTO
    {
        public bool Guest { get; set; }
        public Guid PersonalDoctor { get; set; }
    }
}
