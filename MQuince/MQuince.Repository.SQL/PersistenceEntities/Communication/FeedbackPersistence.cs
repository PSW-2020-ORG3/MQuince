using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities
{
    [Table("Feedback")]
    public class FeedbackPersistence
    {
        [Key] //Anotacija za primarni kljuc 
        public Guid Id { get; set; }
        [Required]//Anotacija pomocu koje se ogranicava tabela da se ne moze proslediti null za username
        public string Comment { get; set; }
        public String User { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public bool Approved { get; set; }
    }
}
