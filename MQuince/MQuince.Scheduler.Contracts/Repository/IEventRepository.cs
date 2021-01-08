using MQuince.Core.Contracts;
using MQuince.Scheduler.Domain.Events;

namespace MQuince.Scheduler.Contracts.Repository
{
    public interface IEventRepository : ICreate<ScheduleEvent>
    {
    }
}
