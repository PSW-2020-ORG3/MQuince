using MQuince.Infrastructure.PersistenceEntities.Events.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Communication
{
    [Table("Feedback")]
    public class FeedbackPersistence
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public string User { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public bool Approved { get; set; }
    }
}
