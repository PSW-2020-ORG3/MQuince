using MQuince.Core.Contracts;
using MQuince.Scheduler.Domain.Events;
using System.Collections.Generic;

namespace MQuince.Scheduler.Contracts.Repository
{
    public interface IEventRepository : ICreate<ScheduleEvent>
    {
        IEnumerable<ScheduleEvent> GetAll();
    }
}
