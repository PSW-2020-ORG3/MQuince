using MQuince.Review.Domain.Events;
using MQuince.Scheduler.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Infrastructure.DataProvider
{
    public interface IEventRepository
    {
        void Create(FeedbackEvent entity);
        void Create(ScheduleEvent entity);
    }
}
