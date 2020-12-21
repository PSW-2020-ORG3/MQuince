using MQuince.Entities;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Communication
{
    [Table("Notification")]
    public class NotificationPersistence
    {
        public Guid Id;
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("UserId")]

        public List<Guid> UserId;
        [ForeignKey("CreatedByStaffId")]
        public Guid CreatedByStaffId;
    }
}
