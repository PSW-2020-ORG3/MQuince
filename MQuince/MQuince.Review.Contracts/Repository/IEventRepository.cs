using MQuince.Core.Contracts;
using MQuince.Review.Domain.Events;

namespace MQuince.Review.Contracts.Repository
{
    public interface IEventRepository : ICreate<FeedbackEvent>
    {
    }
}
