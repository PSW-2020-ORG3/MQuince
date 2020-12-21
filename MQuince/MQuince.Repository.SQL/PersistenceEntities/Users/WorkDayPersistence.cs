using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("WorkDay")]
    public class WorkDayPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public Days Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
