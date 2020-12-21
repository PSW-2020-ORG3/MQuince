using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Communication
{
    [Table("Article")]
    public class ArticlePersistence
    {
        [Key]
        public Guid Id;
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        [ForeignKey("StaffId")]
        public Guid StaffId { get; set; }
    }
}
