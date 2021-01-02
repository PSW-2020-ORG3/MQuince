using MQuince.Core.IdentifiableDTO;
using MQuince.Review.Domain;
using MQuince.Review.Domain.Contracts.DTO;
using System;

namespace MQuince.Review.Application.Services.Util
{
    public class FeedbackMapper
    {
        public static Feedback CreateFeedbackFromDTO(FeedbackDTO feedback, Guid? id = null)
            => id == null ? new Feedback(feedback.Comment, feedback.User, feedback.Anonymous, feedback.Publish, feedback.Approved)
                          : new Feedback(id.Value, feedback.Comment, feedback.User, feedback.Anonymous, feedback.Publish, feedback.Approved);

        public static IdentifiableDTO<FeedbackDTO> CreateDTOFromFeedback(Feedback feedback)
        {
            if (feedback == null) return null;

            return new IdentifiableDTO<FeedbackDTO>()
            {
                Id = feedback.Id,
                EntityDTO = new FeedbackDTO()
                {
                    Comment = feedback.Comment,
                    User = feedback.User,
                    Anonymous = feedback.Anonymous,
                    Publish = feedback.Publish,
                    Approved = feedback.Approved
                }

            };
        }
    }
}
