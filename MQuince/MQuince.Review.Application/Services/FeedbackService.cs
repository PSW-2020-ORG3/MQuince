using MQuince.Core.IdentifiableDTO;
using MQuince.Infrastructure.DataProvider;
using MQuince.Review.Application.Services.Util;
using MQuince.Review.Contracts.DTO;
using MQuince.Review.Contracts.Repository;
using MQuince.Review.Contracts.Service;
using MQuince.Review.Domain;
using MQuince.Review.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Review.Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private EventRepository _eventRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository, EventRepository eventRepository)
        {
            _feedbackRepository = feedbackRepository;
            _eventRepository = eventRepository;
        }

        public Guid Create(FeedbackDTO entityDTO)
        {
            Feedback feedback = FeedbackMapper.CreateFeedbackFromDTO(entityDTO);
            FeedbackEvent feedbackEvent = new FeedbackEvent(FeedbackEventType.CREATED, feedback.Id);

            _feedbackRepository.Create(feedback);
            _eventRepository.Create(feedbackEvent);

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
                FeedbackEvent feedbackEvent = new FeedbackEvent(FeedbackEventType.APPROVED, feedback.Id);

                feedback.Approve();
                _feedbackRepository.Update(feedback);
                _eventRepository.Create(feedbackEvent);

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
