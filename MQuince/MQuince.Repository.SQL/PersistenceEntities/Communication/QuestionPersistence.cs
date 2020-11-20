using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Communication
{
    
    [Table("Question")]
    public class QuestionPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public string Question { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
