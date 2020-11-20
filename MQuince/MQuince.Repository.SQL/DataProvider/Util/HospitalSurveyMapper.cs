using MQuince.Entities.Communication;
using MQuince.Repository.SQL.PersistenceEntities.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class HospitalSurveyMapper
    {
        public static HospitalSurvey MapHospitalSurveyPersistenceToHospitalSurveyEntity(HospitalSurveyPersistence hospitalSurvey)
        {
            if (hospitalSurvey == null) return null;
            Question question = null;
            if (hospitalSurvey.Question != null)
                question = new Question(hospitalSurvey.Question.Id, hospitalSurvey.Question.Question, hospitalSurvey.Question.QuestionType);
            return new HospitalSurvey(hospitalSurvey.Id, question, hospitalSurvey.OneStar, hospitalSurvey.TwoStar, hospitalSurvey.ThreeStar, hospitalSurvey.FourStar, hospitalSurvey.FiveStar);

        }

        public static HospitalSurveyPersistence MapHospitalSurveyEntityToHospitalSurveyPersistence(HospitalSurvey hospitalSurvey)
        {
            if (hospitalSurvey == null) return null;
            QuestionPersistence question = null;
            if(hospitalSurvey.Question != null) question = new QuestionPersistence() { Id = hospitalSurvey.Question.Id, Question = hospitalSurvey.Question._question, QuestionType = hospitalSurvey.Question.QuestionType };
            HospitalSurveyPersistence retVal = new HospitalSurveyPersistence() { Id = hospitalSurvey.Id, Question = question, OneStar = hospitalSurvey.OneStar, TwoStar = hospitalSurvey.TwoStar, ThreeStar = hospitalSurvey.ThreeStar, FourStar = hospitalSurvey.FourStar, FiveStar = hospitalSurvey.FiveStar };
            return retVal;
        }

        public static IEnumerable<HospitalSurvey> MapHospitalSurveyPersistenceCollectionToHospitalSurveyEntityCollection(IEnumerable<HospitalSurveyPersistence> clients)
            => clients.Select(c => MapHospitalSurveyPersistenceToHospitalSurveyEntity(c));
    }
}
