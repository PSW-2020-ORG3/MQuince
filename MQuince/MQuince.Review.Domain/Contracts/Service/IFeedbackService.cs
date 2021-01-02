using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.Review.Domain.Contracts.DTO;
using System;
using System.Collections.Generic;

namespace MQuince.Review.Domain.Contracts.Service
{
    public interface IFeedbackService : IService<FeedbackDTO, IdentifiableDTO<FeedbackDTO>>
    {
        IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByStatus(bool publish, bool approved);
        IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByParams(bool anonymous, bool approved);
        bool ApproveFeedback(Guid id);
    }
}
