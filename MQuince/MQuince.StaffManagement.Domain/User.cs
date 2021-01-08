using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.StafManagement.Domain
{
    public class User
    {
        private Guid _id;
        public string Username { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User()
        {

        }
        public User(Guid id, string username, string password, string jmbg, string name, string surname)
        {
            _id = id;
            Username = username;
            Password = password;
            Jmbg = jmbg;
            Name = name;
            Surname = surname;
        }

        public User(string username, string password, string jmbg, string name, string surname) : this(Guid.NewGuid(), username, password, jmbg, 
                name, surname)
        {
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }

        public static implicit operator string(User v)
        {
            throw new NotImplementedException();
        }
    }
}
