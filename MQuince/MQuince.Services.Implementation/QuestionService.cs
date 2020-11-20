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
    public class QuestionService : IQuestionService
    {
        public IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Guid Create(QuestionDTO entityDTO)
        {
            Question question = CreateQuestionFromDTO(entityDTO);
            _questionRepository.Create(question);
            return question.Id;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<QuestionDTO>> GetAll()
            => _questionRepository.GetAll().Select(c => CreateDTOFromQuestion(c));


        public IdentifiableDTO<QuestionDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
        private Question CreateQuestionFromDTO(QuestionDTO question, Guid? id = null)
            => id == null ? new Question(question._question, question.QuestionType)
                          : new Question(id.Value, question._question, question.QuestionType);
        private IdentifiableDTO<QuestionDTO> CreateDTOFromQuestion(Question question)
        {
            if (question == null) return null;

            return new IdentifiableDTO<QuestionDTO>()
            {
                Id = question.Id,
                EntityDTO = new QuestionDTO()
                {
                    _question = question._question,
                    QuestionType = question.QuestionType
                }

            };
        }
    }
}
