using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MQuince.Entities;
using MQuince.Entities.Drug;
using MQuince.Repository.SQL;
using MQuince.Repository.SQL.DataProvider;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using MQuince.Services.Implementation;

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

        /// <summary>
        /// POST method for add feedbacks
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(FeedbackDTO dto)
        {
            if (ModelState.IsValid)
            {
                _feedbackService.Create(dto);
            }
            return Ok();
        }

        /// <summary>
        /// GET method for all feedback by status
        /// </summary>
        /// <param name="publish"></param>
        /// <param name="approved"></param>
        /// <returns></returns>
        [HttpGet("GetByStatus")]
        public IEnumerable<IdentifiableDTO<FeedbackDTO>> GetByStatus(bool publish, bool approved)
        {
            return _feedbackService.GetByStatus(publish, approved);
        }

        /// <summary>
        /// GET method for all feedback by parameters
        /// </summary>
        /// <param name="anonymous"></param>
        /// <param name="approved"></param>
        /// <returns></returns>
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