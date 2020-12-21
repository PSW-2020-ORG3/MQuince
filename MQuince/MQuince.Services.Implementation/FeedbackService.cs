using MQuince.Entities;
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
    public class FeedbackService : IFeedbackService
    {
        public IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

       

        public Guid Create(FeedbackDTO entityDTO)
        {
            Feedback feedback = CreateFeedbackFromDTO(entityDTO);

            _feedbackRepository.Create(feedback);

            return feedback.Id;
        }

        public bool Delete(Guid id) => _feedbackRepository.Delete(id);

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetAll()
            => _feedbackRepository.GetAll().Select(c => CreateDTOFromFeedback(c));


        public IdentifiableDTO<FeedbackDTO> GetById(Guid id) => CreateDTOFromFeedback(_feedbackRepository.GetById(id));

        public void Update(FeedbackDTO entityDTO, Guid id)
        {
            _feedbackRepository.Update(CreateFeedbackFromDTO(entityDTO, id));

        }

        /// <summary>
        /// Method for create feedbacks from DTO
        /// </summary>
        /// <param name="feedback"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private Feedback CreateFeedbackFromDTO(FeedbackDTO feedback, Guid? id = null)
            => id == null ? new Feedback(feedback.Comment, feedback.User, feedback.Anonymous, feedback.Publish, feedback.Approved)
                          : new Feedback(id.Value, feedback.Comment, feedback.User, feedback.Anonymous, feedback.Publish, feedback.Approved);

        /// <summary>
        /// Mathod for sreate DTO from feedbacks
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        private IdentifiableDTO<FeedbackDTO> CreateDTOFromFeedback(Feedback feedback)
        {
            if (feedback == null) return null;

            return new IdentifiableDTO<FeedbackDTO>()
            {
                Id = feedback.Id,
                EntityDTO = new FeedbackDTO()
                {
                    Comment = feedback.Comment,
                    User = feedback.User,
                    Anonymous = feedback.Anonymous,
                    Publish = feedback.Publish,
                    Approved = feedback.Approved
                }

            };
        }

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByStatus(bool publish, bool approved)
            => _feedbackRepository.GetByStatus(publish, approved).Select(c => CreateDTOFromFeedback(c));

        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByParams(bool anonymous, bool approved)
            => _feedbackRepository.GetByParams(anonymous, approved).Select(c => CreateDTOFromFeedback(c));
    }
}
