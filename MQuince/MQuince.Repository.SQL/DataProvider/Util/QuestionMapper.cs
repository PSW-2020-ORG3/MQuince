using MQuince.Entities.Communication;
using MQuince.Repository.SQL.PersistenceEntities.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class QuestionMapper
    {
        public static Question MapQuestionPersistenceToQuestionEntity(QuestionPersistence question)
        {
            if (question == null) return null;

            return new Question(question.Id, question.Question, question.QuestionType);

        }

        public static QuestionPersistence MapQuestionEntityToQuestionPersistence(Question question)
        {
            if (question == null) return null;

            QuestionPersistence retVal = new QuestionPersistence() { Id = question.Id, Question = question._question, QuestionType = question.QuestionType };
            return retVal;
        }

        public static IEnumerable<Question> MapQuestionPersistenceCollectionToQuestionEntityCollection(IEnumerable<QuestionPersistence> clients)
            => clients.Select(c => MapQuestionPersistenceToQuestionEntity(c));
    }
}
