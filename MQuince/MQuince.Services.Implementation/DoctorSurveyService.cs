using MQuince.Entities.Communication;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation
{
    public class DoctorSurveyService : IDoctorSurveyService
    {
        public IDoctorSurveyRepository _doctorSurveyRepository;
        public DoctorSurveyService(IDoctorSurveyRepository doctorSurveyRepository)
        {
            _doctorSurveyRepository = doctorSurveyRepository;
        }

        public Guid Create(DoctorSurveyDTO entityDTO)
        {
            DoctorSurvey doctorSurvey = CreateDoctorSurveyFromDTO(entityDTO);
            _doctorSurveyRepository.Create(doctorSurvey);
            return doctorSurvey.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<DoctorSurveyDTO>> GetAll()
           => _doctorSurveyRepository.GetAll().Select(c => CreateDTOFromDoctorSurvey(c));

        public IdentifiableDTO<DoctorSurveyDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorSurveyDTO entityDTO, Guid id)
        {
            _doctorSurveyRepository.Update(CreateDoctorSurveyFromDTO(entityDTO, id));
        }

        private DoctorSurvey CreateDoctorSurveyFromDTO(DoctorSurveyDTO question, Guid? id = null)
            => id == null ? new DoctorSurvey(question.Question, question.Doctor, question.OneStar, question.TwoStar, question.ThreeStar, question.FourStar, question.FiveStar)
                          : new DoctorSurvey(id.Value, question.Doctor, question.Question, question.OneStar, question.TwoStar, question.ThreeStar, question.FourStar, question.FiveStar);
        private IdentifiableDTO<DoctorSurveyDTO> CreateDTOFromDoctorSurvey(DoctorSurvey doctorSurvey)
        {
            if (doctorSurvey == null) return null;

            return new IdentifiableDTO<DoctorSurveyDTO>()
            {
                Id = doctorSurvey.Id,
                EntityDTO = new DoctorSurveyDTO()
                {
                    Doctor = doctorSurvey.Doctor,
                    Question = doctorSurvey.Question,
                    OneStar = doctorSurvey.OneStar,
                    TwoStar = doctorSurvey.TwoStar,
                    ThreeStar = doctorSurvey.ThreeStar,
                    FourStar = doctorSurvey.FourStar,
                    FiveStar = doctorSurvey.FiveStar
                }

            };
        }
    }
}
