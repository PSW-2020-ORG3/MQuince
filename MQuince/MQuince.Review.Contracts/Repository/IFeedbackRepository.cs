using MQuince.Core.Contracts;
using MQuince.Review.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Review.Contracts.Repository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        IEnumerable<Feedback> GetByStatus(bool publish, bool approved);
        IEnumerable<Feedback> GetByParams(bool anonymous, bool approved);
    }
}
