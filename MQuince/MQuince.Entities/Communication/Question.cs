using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class Question
    {
        private Guid _id;
        public string _question;
        public string Title { get; set; }
        public string Answer { get; set; }
        public bool IsAnswered { get; set; } = false;
        public bool IsFAQ { get; set; } = false;
        public bool ForFAQ { get; set; } = false;
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

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
