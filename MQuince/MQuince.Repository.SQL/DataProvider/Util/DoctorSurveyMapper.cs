using MQuince.Entities.Communication;
using MQuince.Entities.Users;
using MQuince.Repository.SQL.PersistenceEntities.Communication;
using MQuince.Repository.SQL.PersistenceEntities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class DoctorSurveyMapper
    {
        public static DoctorSurvey MapDoctorSurveyPersistenceToDoctorSurveyEntity(DoctorSurveyPersistence doctorSurvey)
        {
            if (doctorSurvey == null) return null;
            Question question = null;
            if (doctorSurvey.Question != null)
                question = new Question(doctorSurvey.Question.Id, doctorSurvey.Question.Question, doctorSurvey.Question.QuestionType);
            Doctor doctor = null;
            return new DoctorSurvey(doctorSurvey.Id, doctor, question, doctorSurvey.OneStar, doctorSurvey.TwoStar, doctorSurvey.ThreeStar, doctorSurvey.FourStar, doctorSurvey.FiveStar);

        }

        public static DoctorSurveyPersistence MapDoctorSurveyEntityToDoctorSurveyPersistence(DoctorSurvey doctorSurvey)
        {
            if (doctorSurvey == null) return null;
            QuestionPersistence question = null;
            if (doctorSurvey.Question != null) question = new QuestionPersistence() { Id = doctorSurvey.Question.Id, Question = doctorSurvey.Question._question, QuestionType = doctorSurvey.Question.QuestionType };
            //DoctorPersistence doctor = null;
            DoctorSurveyPersistence retVal = new DoctorSurveyPersistence() { Id = doctorSurvey.Id, DoctorId = 1, Question = question, OneStar = doctorSurvey.OneStar, TwoStar = doctorSurvey.TwoStar, ThreeStar = doctorSurvey.ThreeStar, FourStar = doctorSurvey.FourStar, FiveStar = doctorSurvey.FiveStar };
            return retVal;
        }

        public static IEnumerable<DoctorSurvey> MapDoctorSurveyPersistenceCollectionToDoctorSurveyEntityCollection(IEnumerable<DoctorSurveyPersistence> clients)
            => clients.Select(c => MapDoctorSurveyPersistenceToDoctorSurveyEntity(c));
    }
}
