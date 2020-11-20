using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class QuestionDTO
    {
        public string _question { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
