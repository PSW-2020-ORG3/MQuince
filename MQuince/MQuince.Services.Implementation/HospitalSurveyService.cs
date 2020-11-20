using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class HospitalSurveyService : IHospitalSurveyService
    {
        public IHospitalSurveyRepository _hospitalSurveyRepository;
        public HospitalSurveyService(IHospitalSurveyRepository hospitalSurveyRepository)
        {
            _hospitalSurveyRepository = hospitalSurveyRepository;
        }

        public Guid Create(HospitalSurveyDTO entityDTO)
        {
            HospitalSurvey hospitalSurvey = CreateHospitalSurveyFromDTO(entityDTO);
            _hospitalSurveyRepository.Create(hospitalSurvey);
            return hospitalSurvey.Id;
        }

        public IEnumerable<IdentifiableDTO<HospitalSurveyDTO>> GetAll()
           => _hospitalSurveyRepository.GetAll().Select(c => CreateDTOFromHospitalSurvey(c));

        public IdentifiableDTO<HospitalSurveyDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(HospitalSurveyDTO entityDTO, Guid id)
        {
            _hospitalSurveyRepository.Update(CreateHospitalSurveyFromDTO(entityDTO, id));
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        private HospitalSurvey CreateHospitalSurveyFromDTO(HospitalSurveyDTO question, Guid? id = null)
            => id == null ? new HospitalSurvey(question.Question, question.OneStar, question.TwoStar, question.ThreeStar, question.FourStar, question.FiveStar)
                          : new HospitalSurvey(id.Value, question.Question, question.OneStar, question.TwoStar, question.ThreeStar, question.FourStar, question.FiveStar);
        private IdentifiableDTO<HospitalSurveyDTO> CreateDTOFromHospitalSurvey(HospitalSurvey hospitalSurvey)
        {
            if (hospitalSurvey == null) return null;

            return new IdentifiableDTO<HospitalSurveyDTO>()
            {
                Id = hospitalSurvey.Id,
                EntityDTO = new HospitalSurveyDTO()
                {
                    Question = hospitalSurvey.Question,
                    OneStar = hospitalSurvey.OneStar,
                    TwoStar = hospitalSurvey.TwoStar,
                    ThreeStar = hospitalSurvey.ThreeStar,
                    FourStar = hospitalSurvey.FourStar,
                    FiveStar = hospitalSurvey.FiveStar
                }

            };
        }
    }
}
