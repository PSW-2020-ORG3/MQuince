using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Autentication.Contracts.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
