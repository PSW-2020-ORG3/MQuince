using System;

namespace MQuince.Entities.Users
{
    public class Patient : User
    {
        public bool Guest { get; set; }
        public Guid? PersonalDoctor { get; set; }

    }
}
