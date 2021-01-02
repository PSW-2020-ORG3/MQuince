using System;

namespace MQuince.Review.Domain.Exceptions
{
    public class FeedbackCommentEmptyException : Exception
    {
        private static readonly string _message = "Feedback comment can't be empty";
        public FeedbackCommentEmptyException() : base(_message)
        {
        }
    }
}
