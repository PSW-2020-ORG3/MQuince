using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Events
{
    [Table("BaseEvent")]
    public class BaseEventPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
