using System;

namespace MQuince.Core.BaseEvent
{
    public abstract class BaseEvent
    {
        public Guid BaseEntityId { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public BaseEvent(Guid baseEntityId)
        {
            TimeStamp = DateTime.Now;
            BaseEntityId = baseEntityId;
        }

        public BaseEvent(DateTime dateTime, Guid baseEntityId)
        {
            TimeStamp = dateTime;
            BaseEntityId = baseEntityId;
        }
    }
}
