using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class Article
    {
        private Guid _id;
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public Guid StaffId { get; set; }


        public Guid Id
        {
            get { return _id; }
            private set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
