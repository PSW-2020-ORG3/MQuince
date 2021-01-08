using System;

namespace MQuince.Autentication.Domain
{
    public class Patient : User
    {
        public bool Guest { get; set; }
        public Guid? PersonalDoctor { get; set; }
    }
}
