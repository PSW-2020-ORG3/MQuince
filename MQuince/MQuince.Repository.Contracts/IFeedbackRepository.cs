using MQuince.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        IEnumerable<Feedback> GetByStatus(bool publish, bool approved);
        IEnumerable<Feedback> GetByParams(bool anonymous, bool approved);
    }
}
