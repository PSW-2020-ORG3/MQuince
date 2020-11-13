using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class ArticleDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public Guid StaffId { get; set; }
    }
}
