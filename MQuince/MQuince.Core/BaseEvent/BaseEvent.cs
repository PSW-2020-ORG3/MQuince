using System;

namespace MQuince.Core.BaseEvent
{
    public abstract class BaseEvent
    {
        public Guid BaseEntityId { get; set; }
        public DateTime TimeStamp { get; set; }
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
