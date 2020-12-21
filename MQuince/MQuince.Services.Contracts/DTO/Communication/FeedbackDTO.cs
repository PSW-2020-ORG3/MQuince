using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MQuince.Services.Contracts.DTO
{
    public class FeedbackDTO
    {
        [Required]
        public string Comment { get; set; }
        public String User { get; set; }
        public bool Anonymous { get; set; }
        public bool Publish { get; set; }
        public bool Approved { get; set; }
    }
}
