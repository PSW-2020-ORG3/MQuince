using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Application
{
    public class App
    {
        private DbContextOptionsBuilder _optionsBuilder;

        public App(IConfiguration configuration)
        {
            _optionsBuilder = new DbContextOptionsBuilder();
            //_optionsBuilder.UseSqlServer(configuration.GetConnectionString("FeedbackExampleDB"));
            _optionsBuilder.UseMySql(@"server=localhost;port=3306;database=mquince;user=root;password=root");
        }

        public IUserService GetUserService()
            => new UserService(this.GetUserRepository());

        public IFeedbackService GetFeedbackService()
            => new FeedbackService(this.GetFeedbackRepository());
        public IQuestionService GetQuestionService()
            => new QuestionService(this.GetQuestionRepository());
        public IHospitalSurveyService GetHospitalSurveyService()
            => new HospitalSurveyService(this.GetHospitalSurveyRepository());
        public IDoctorSurveyService GetDoctorSurveyService()
            => new DoctorSurveyService(this.GetDoctorSurveyRepository());


        private IUserRepository GetUserRepository()
            => new UserRepository(_optionsBuilder);
        private IFeedbackRepository GetFeedbackRepository()
             => new FeedbackRepository(_optionsBuilder);
        private IQuestionRepository GetQuestionRepository()
             => new QuestionRepository(_optionsBuilder);
        private IHospitalSurveyRepository GetHospitalSurveyRepository()
             => new HospitalSurveyRepository(_optionsBuilder);
        private IDoctorSurveyRepository GetDoctorSurveyRepository()
             => new DoctorSurveyRepository(_optionsBuilder);
    }
}
