using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities
{
    public class User
    {
        private Guid _id;
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

        public User(Guid id, Usertype usertype, string username, string password, int jmbg, string name, string surname,
            DateTime birthDate, City birthPlace, Adress residence, Contact contact)
        {
            _id = id;
            Username = username;
            UserType = usertype;
            Password = password;
            Jmbg = jmbg;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Residence = residence;
            Contact = contact;
        }

        public User(Usertype usertype, string username, string password, int jmbg, string name, string surname,
            DateTime birthDate, City birthPlace, Adress residence, Contact contact) : this(Guid.NewGuid(), usertype, username, password, jmbg, 
                name, surname, birthDate, birthPlace, residence, contact)
        {
        }

        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
