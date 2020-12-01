using Microsoft.AspNetCore.Mvc;
using MQuince.Entities;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController([FromServices] IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
        }

        [HttpPost]
        public IActionResult Add(FeedbackDTO dto)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.Create(dto);
            }
            return Ok();
        }

        [HttpGet("GetByStatus")]
        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByStatus(bool publish, bool approved)
        {
            return _feedbackService.GetByStatus(publish, approved);
        }


        [HttpGet("GetByParams")]
        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByParams(bool anonymous, bool approved)
        {
            return _feedbackService.GetByParams(anonymous, approved);
        }

        [HttpPost("Update")]
        public IActionResult Update(Feedback feedback)
        {
            _feedbackService.Update(new FeedbackDTO() { Comment = feedback.Comment, User = feedback.User, Anonymous = feedback.Anonymous, Publish = feedback.Publish, Approved = feedback.Approved }, feedback.Id);
            return Ok();
        }

    }
}
