using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Communication
{
    [Table("SoftwareRating")]
    public class SoftwareRatingPersistence
    {
        [Key]
        public Guid Id;
        public Grade Functionality { get; set; }
        public Grade Speed { get; set; }
        public Grade Reliabillity { get; set; }
        public Grade Design { get; set; }
        public string Note { get; set; }
    }
}
