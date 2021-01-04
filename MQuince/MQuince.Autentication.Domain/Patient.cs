using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Autentication.Domain
{
    public class Patient : User
    {
        public bool Guest { get; set; }
        public Guid? PersonalDoctor { get; set; }
    }
}
