using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Contact")]
    public class ContactPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }
}
