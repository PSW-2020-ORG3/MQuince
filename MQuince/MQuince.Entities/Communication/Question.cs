using MQuince.Entities.Users;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Communication
{
    public class Question
    {
        private Guid _id;
        public string _question { get; set; }
        public QuestionType QuestionType { get; set; }

        public Question() { }
        public Question(Guid id, string question, QuestionType questionType)
        {
            _id = id;
            _question = question;
            QuestionType = questionType;
        }
        public Question(string question, QuestionType questionType) : this(Guid.NewGuid(), question,questionType)
        {
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value == Guid.Empty ? throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id)) : value;
            }
        }
    }
}
