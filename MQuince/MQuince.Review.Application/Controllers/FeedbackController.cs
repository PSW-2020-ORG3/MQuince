using Microsoft.AspNetCore.Mvc;
using MQuince.Core.IdentifiableDTO;
using MQuince.Review.Contracts.DTO;
using MQuince.Review.Contracts.Exceptions;
using MQuince.Review.Contracts.Service;
using System;
using System.Collections.Generic;

namespace MQuince.Review.Application.Controllers
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
            try
            {
                Guid id = _feedbackService.Create(dto);
                return Created("/api/feedback", id);
            }
            catch (FeedbackCommentEmptyException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_feedbackService.GetById(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_feedbackService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("GetByParams")]
        public IActionResult GetByParams(bool anonymous, bool approved)
        {
            try
            {
                return Ok(_feedbackService.GetByParams(anonymous, approved));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(bool publish, bool approved)
        {
            try
            {
                return Ok(_feedbackService.GetByStatus(publish, approved));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("Approve/{feedbackId}")]
        public IActionResult ApproveFeedback(Guid feedbackId)
        {
            try
            {
                _feedbackService.ApproveFeedback(feedbackId);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
