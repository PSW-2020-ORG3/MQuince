using MQuince.Review.Domain.Exceptions;
using System;

namespace MQuince.Review.Domain
{
    public class Feedback
    {
        public Guid Id { get; private set; }
        public string Comment { get; private set; }
        public string User { get; private set; }
        public bool Anonymous { get; private set; }
        public bool Publish { get; private set; }
        public bool Approved { get; private set; }

        public Feedback() { }

        public Feedback(Guid id, string comment, string user, bool anonymous, bool publish, bool approved)
        {
            Id = id;
            Comment = comment;
            User = user;
            Anonymous = anonymous;
            Publish = publish;
            Approved = approved;
            Validate();
        }

        public Feedback(string comment, string user, bool anonymous, bool publish, bool approved)
            : this(Guid.NewGuid(), comment, user, anonymous, publish, approved)
        {
        }

        private void Validate()
        {
            if (Id == Guid.Empty)
                throw new ArgumentException("Argument can not be Guid.Empty", nameof(Id));

            if (Comment == "")
                throw new FeedbackCommentEmptyException();
        }

        public void Approve()
        {
            this.Approved = true;
        }
    }
}
