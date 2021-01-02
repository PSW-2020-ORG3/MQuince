using MQuince.Core.Contracts;
using System.Collections.Generic;

namespace MQuince.Review.Domain.Contracts.Repository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        IEnumerable<Feedback> GetByStatus(bool publish, bool approved);
        IEnumerable<Feedback> GetByParams(bool anonymous, bool approved);
    }
}
