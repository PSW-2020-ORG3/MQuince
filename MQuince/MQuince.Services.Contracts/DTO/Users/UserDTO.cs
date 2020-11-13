using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO
{
    public class UserDTO
    {
        public Usertype UserType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        //public Gender Gender { get; set; }
        public City BirthPlace { get; set; }
        public Adress Residence { get; set; }
        public Contact Contact { get; set; }
    }
}
