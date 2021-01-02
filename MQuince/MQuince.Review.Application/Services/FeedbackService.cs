using MQuince.Core.IdentifiableDTO;
using MQuince.Review.Application.Services.Util;
using MQuince.Review.Domain;
using MQuince.Review.Domain.Contracts.DTO;
using MQuince.Review.Domain.Contracts.Repository;
using MQuince.Review.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Review.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        public IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Guid Create(FeedbackDTO entityDTO)
        {
            Feedback feedback = FeedbackMapper.CreateFeedbackFromDTO(entityDTO);

            _feedbackRepository.Create(feedback);

            return feedback.Id;
        }

        public bool Delete(Guid id) => _feedbackRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetAll()
            => _feedbackRepository.GetAll().Select(c => FeedbackMapper.CreateDTOFromFeedback(c));


        public IdentifiableDTO<FeedbackDTO> GetById(Guid id) => FeedbackMapper.CreateDTOFromFeedback(_feedbackRepository.GetById(id)); 

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByStatus(bool publish, bool approved)
            => _feedbackRepository.GetByStatus(publish, approved).Select(c => FeedbackMapper.CreateDTOFromFeedback(c));

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByParams(bool anonymous, bool approved)
            => _feedbackRepository.GetByParams(anonymous, approved).Select(c => FeedbackMapper.CreateDTOFromFeedback(c));

        public bool ApproveFeedback(Guid id)
        {
            try
            {
                Feedback feedback = _feedbackRepository.GetById(id);
                feedback.Approve();
                _feedbackRepository.Update(feedback);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(FeedbackDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
