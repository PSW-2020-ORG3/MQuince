using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities
{

    //Anotacija ispod [Table("User")] u EntityFrameworku pomocu koje se zadaje naziv tabele, ova klasa se pravi da se u Entitetima ne bi mesale anotacije, 
    //jer se tad krsi singular responsibility princip
    [Table("User")]
    public class UserPersistence
    {
        [Key] //Anotacija za primarni kljuc 
        public Guid Id { get; set; }
        [Required]//Anotacija pomocu koje se ogranicava tabela da se ne moze proslediti null za username
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
