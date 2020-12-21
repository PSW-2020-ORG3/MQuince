using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class Notification
    {
        private Guid _id;
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public List<Guid> UserId;

        public Guid CreatedByStaffId;

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
