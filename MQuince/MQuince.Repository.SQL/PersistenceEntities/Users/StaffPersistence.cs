using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Staff")]
    public class StaffPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Picture { get; set; }
        public int PictureNumber { get; set; }
    }
}
