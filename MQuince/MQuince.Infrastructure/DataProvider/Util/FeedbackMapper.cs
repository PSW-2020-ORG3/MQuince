using MQuince.Infrastructure.PersistenceEntities.Communication;
using MQuince.Review.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Infrastructure.DataProvider.Util
{
    public class FeedbackMapper
    {
        public static Feedback MapFeedbackPersistenceToFeedbackEntity(FeedbackPersistence feedback)
        {
            if (feedback == null) return null;

            return new Feedback(feedback.Id, feedback.Comment, feedback.User, feedback.Anonymous, feedback.Publish, feedback.Approved);

        }

        public static FeedbackPersistence MapFeedbackEntityToFeedbackPersistence(Feedback feedback)
        {
            if (feedback == null) return null;

            FeedbackPersistence retVal = new FeedbackPersistence() { Id = feedback.Id, User = feedback.User, Comment = feedback.Comment, Anonymous = feedback.Anonymous, Publish = feedback.Publish, Approved = feedback.Approved };
            return retVal;
        }

        public static IEnumerable<Feedback> MapFeedbackPersistenceCollectionToFeedbackEntityCollection(IEnumerable<FeedbackPersistence> clients)
            => clients.Select(c => MapFeedbackPersistenceToFeedbackEntity(c));
    }
}
