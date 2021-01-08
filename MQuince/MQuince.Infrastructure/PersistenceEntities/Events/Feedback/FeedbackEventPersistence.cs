using MQuince.Infrastructure.PersistenceEntities.Communication;
using MQuince.Review.Domain.Events;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MQuince.Infrastructure.PersistenceEntities.Events.Feedback
{

    [Table("FeedbackEvent")]
    public class FeedbackEventPersistence : BaseEventPersistence
    {
        public FeedbackEventType EventType { get; set; }

        [ForeignKey("FeedbackId")]
        public Guid FeedbackId { get; set; }
        public FeedbackPersistence Feedback { get; set; }
    }
}
