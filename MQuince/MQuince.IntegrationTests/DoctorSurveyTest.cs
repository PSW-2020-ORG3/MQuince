using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Repository.SQL.DataAccess;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Repository.SQL.PersistenceEntities.Communication;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;
using MQuince.WebAPI.Controllers;
using Xunit;

namespace MQuince.IntegrationTests
{
    public class DoctorSurveyTest
    {
        private DoctorSurveyController doctorSurveyController;
        private IDoctorSurveyService doctorSurveyService;
        private IDoctorSurveyRepository doctorSurveyRepository;

        private void InitDB()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MQuinceDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "mquince");

            doctorSurveyRepository = new DoctorSurveyRepository(optionsBuilder);
            using (var dataBase = new MQuinceDbContext(optionsBuilder.Options))
            {
                dataBase.Database.EnsureDeleted();
                dataBase.Database.EnsureCreated();

                DoctorSurveyPersistence ds = new DoctorSurveyPersistence()
                {
                    Id = new Guid("f7ab176f-c1bd-47fc-8c2a-6ebb6c82d9bd"),
                    OneStar = 1,
                    TwoStar = 2,
                    ThreeStar = 3,
                    FourStar = 4,
                    FiveStar = 5,
                    Question = new QuestionPersistence() { Question = "Are you satisfied with our service", QuestionType = Enums.QuestionType.StaffQuestion }
                };
                dataBase.DoctorSurveys.AddRange(ds);
                dataBase.SaveChanges();
            }
        }

        public DoctorSurveyTest()
        {
            InitDB();
            doctorSurveyService = new DoctorSurveyService(doctorSurveyRepository);
            doctorSurveyController = new DoctorSurveyController(doctorSurveyService);
        }

        [Fact]
        public void Test1()
        {
            DoctorSurveyDTO doctorSurveyDTO = new DoctorSurveyDTO() { OneStar = 1, TwoStar = 3, ThreeStar = 3, FourStar = 4, FiveStar = 5, Question = new Question() { _question = "Are you satisfied with our service", QuestionType = Enums.QuestionType.StaffQuestion } };
            IdentifiableDTO<DoctorSurveyDTO> survey = new IdentifiableDTO<DoctorSurveyDTO>()
            {
                Id = new Guid("f7ab176f-c1bd-47fc-8c2a-6ebb6c82d9bd"),
                EntityDTO = doctorSurveyDTO
            };
            List<IdentifiableDTO<DoctorSurveyDTO>> list = new List<IdentifiableDTO<DoctorSurveyDTO>>();
            list.Add(survey);
            doctorSurveyController.Update(list);

            List<IdentifiableDTO<DoctorSurveyDTO>> surveys = doctorSurveyController.GetAll().ToList();

            Assert.Equal(3, surveys[0].EntityDTO.TwoStar);
        }

        [Fact]
        public void Test2()
        {
            DoctorSurveyDTO doctorSurveyDTO = new DoctorSurveyDTO() { OneStar = 1, TwoStar = 3, ThreeStar = 3, FourStar = 4, FiveStar = 5, Question = new Question() { _question = "Are you satisfied with our service", QuestionType = Enums.QuestionType.StaffQuestion } };
            IdentifiableDTO<DoctorSurveyDTO> survey = new IdentifiableDTO<DoctorSurveyDTO>()
            {
                Id = new Guid("f7ab176f-c1bd-47fc-8c2a-6ebb6c82d9dd"),
                EntityDTO = doctorSurveyDTO
            };
            List<IdentifiableDTO<DoctorSurveyDTO>> list = new List<IdentifiableDTO<DoctorSurveyDTO>>();
            list.Add(survey);
            

            //List<IdentifiableDTO<DoctorSurveyDTO>> surveys = doctorSurveyController.GetAll().ToList();

            Assert.Throws<DbUpdateConcurrencyException>(() => doctorSurveyController.Update(list));
        }
    }
}
