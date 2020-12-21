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
        [Key] 
        public Guid Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public String User { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public bool Approved { get; set; }
    }
}
