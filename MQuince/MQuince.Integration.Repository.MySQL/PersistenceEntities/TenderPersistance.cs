using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Integration.Repository.MySQL.PersistenceEntities
{
    [Table("Tender")]
    public class TenderPersistance
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Descritpion { get; set; }

        [Required]
        public string FormLink { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }
        [Required]

        public Boolean Opened { get; set; }

        public TenderPersistance() { }
    }
}
