using MQuince.Entities.Communication;
using MQuince.Repository.SQL.DataProvider.Util;
using MQuince.Repository.SQL.PersistenceEntities.Communication;
using System;
using System.Collections.Generic;
using Xunit;

namespace MQuince.UnitTests.MapperTest
{
    public class DoctorSurveyMapperTests
    {
        [Fact]
        public void MapDoctorSurveyPersistenceToDoctorSurveyEntity_GivenNull_ShouldReturnNull()
        {
            DoctorSurvey  doctorSurvey = DoctorSurveyMapper.MapDoctorSurveyPersistenceToDoctorSurveyEntity(null);
            Assert.Null(doctorSurvey);
        }
        [Fact]
        public void MapDoctorSurveyEntityToDoctorSurveyPersistence_GivenNull_ShouldReturnNull()
        {
            DoctorSurveyPersistence doctorSurveyPersistence = DoctorSurveyMapper.MapDoctorSurveyEntityToDoctorSurveyPersistence(null);
            Assert.Null(doctorSurveyPersistence);
        }

        [Fact]
        public void MapDoctorSurveyPersistenceToDoctorSurveyEntity()
        {
            DoctorSurveyPersistence doctorSurveyPersistence = new DoctorSurveyPersistence
            {
                Id = new Guid("08d88fb2-e51c-453a-8ef8-d7ebdafc6073"),
                OneStar = 1,
                TwoStar = 2,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 5,
                Question = new QuestionPersistence() { QuestionType = Enums.QuestionType.AppointmentQuestion, Question = "pitanje?", Id = new Guid("08d88fb2-e51c-455d-8818-cf47eda0c312") }
            };
            DoctorSurvey doctorSurvey = new DoctorSurvey
            {
                Id = new Guid("08d88fb2-e51c-453a-8ef8-d7ebdafc6073"),
                OneStar = 1,
                TwoStar = 2,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 5,
                Question = new Question() { QuestionType = Enums.QuestionType.AppointmentQuestion, _question = "pitanje?", Id = new Guid("08d88fb2-e51c-455d-8818-cf47eda0c312") }
            };
            DoctorSurvey ret = DoctorSurveyMapper.MapDoctorSurveyPersistenceToDoctorSurveyEntity(doctorSurveyPersistence);
            Assert.Equal(doctorSurvey.Id, ret.Id);
            Assert.Equal(doctorSurvey.OneStar, ret.OneStar);
            Assert.Equal(doctorSurvey.TwoStar, ret.TwoStar);
            Assert.Equal(doctorSurvey.ThreeStar, ret.ThreeStar);
            Assert.Equal(doctorSurvey.FourStar, ret.FourStar);
            Assert.Equal(doctorSurvey.FiveStar, ret.FiveStar);
            Assert.Equal(doctorSurvey.Question.QuestionType, ret.Question.QuestionType);
            Assert.Equal(doctorSurvey.Question._question, ret.Question._question);
            Assert.Equal(doctorSurvey.Question.Id, ret.Question.Id);
        }

        [Fact]
        public void MapDoctorSurveyEntityToDoctorSurveyPersistence()
        {
            DoctorSurvey doctorSurvey = new DoctorSurvey
            {
                Id = new Guid("08d88fb2-e51c-453a-8ef8-d7ebdafc6073"),
                OneStar = 1,
                TwoStar = 2,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 5,
                Question = new Question() { QuestionType = Enums.QuestionType.AppointmentQuestion, _question = "pitanje?", Id = new Guid("08d88fb2-e51c-455d-8818-cf47eda0c312") }
            };
            DoctorSurveyPersistence doctorSurveyPersistence = new DoctorSurveyPersistence
            {
                Id = new Guid("08d88fb2-e51c-453a-8ef8-d7ebdafc6073"),
                OneStar = 1,
                TwoStar = 2,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 5,
                Question = new QuestionPersistence() { QuestionType = Enums.QuestionType.AppointmentQuestion, Question = "pitanje?", Id = new Guid("08d88fb2-e51c-455d-8818-cf47eda0c312") }
            };
            DoctorSurveyPersistence ret = DoctorSurveyMapper.MapDoctorSurveyEntityToDoctorSurveyPersistence(doctorSurvey);
            Assert.Equal(ret.Id, doctorSurveyPersistence.Id);
            Assert.Equal(ret.OneStar, doctorSurveyPersistence.OneStar);
            Assert.Equal(ret.TwoStar, doctorSurveyPersistence.TwoStar);
            Assert.Equal(ret.ThreeStar, doctorSurveyPersistence.ThreeStar);
            Assert.Equal(ret.FourStar, doctorSurveyPersistence.FourStar);
            Assert.Equal(ret.FiveStar, doctorSurveyPersistence.FiveStar);
            Assert.Equal(ret.Question.QuestionType, doctorSurveyPersistence.Question.QuestionType);
            Assert.Equal(ret.Question.Question, doctorSurveyPersistence.Question.Question);
            Assert.Equal(ret.Question.Id, doctorSurveyPersistence.Question.Id);
        }
    }
}
