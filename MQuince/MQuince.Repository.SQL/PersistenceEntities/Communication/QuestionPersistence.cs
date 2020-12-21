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
        public Guid Id;
        private string _question;
        public string Title { get; set; }
        public string Answer { get; set; }
        private bool _isAnswered = false;
        private bool _isFAQ = false;
        private bool _forFAQ = false;
        [ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        [ForeignKey("PatientId")]
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
