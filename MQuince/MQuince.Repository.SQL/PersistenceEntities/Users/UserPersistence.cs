using MQuince.Entities.Users;
using MQuince.Enums;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("User")]
    public class UserPersistence
    {
        [Key] 
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
