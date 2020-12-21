using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class QuestionDTO
    {
        public string _question;
        public string Title { get; set; }
        public string Answer { get; set; }
        public bool IsAnswered { get; set; } = false;
        public bool IsFAQ { get; set; } = false;
        public bool ForFAQ { get; set; } = false;
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
