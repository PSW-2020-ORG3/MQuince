using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Review.Contracts.Exceptions
{
    public class FeedbackCommentEmptyException : Exception
    {
        private static readonly string _message = "Feedback comment can't be empty";
        public FeedbackCommentEmptyException() : base(_message)
        {
        }
    }
}
