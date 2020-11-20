using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSurveyController : ControllerBase
    {
        private readonly IDoctorSurveyService _docotrSurveyService;
        public DoctorSurveyController([FromServices] IDoctorSurveyService doctorSurveyService)
        {
            _docotrSurveyService = doctorSurveyService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<DoctorSurveyDTO>> GetAll()
        {
            return _docotrSurveyService.GetAll();
        }

        [HttpPost("Update")]
        public IActionResult Update(List<IdentifiableDTO<DoctorSurveyDTO>> survey)
        {
            foreach (IdentifiableDTO<DoctorSurveyDTO> doctorSurvey in survey)
            {
                _docotrSurveyService.Update(new DoctorSurveyDTO() { Question = doctorSurvey.EntityDTO.Question, Doctor = doctorSurvey.EntityDTO.Doctor, OneStar = doctorSurvey.EntityDTO.OneStar, TwoStar = doctorSurvey.EntityDTO.TwoStar, ThreeStar = doctorSurvey.EntityDTO.ThreeStar, FourStar = doctorSurvey.EntityDTO.FourStar, FiveStar = doctorSurvey.EntityDTO.FiveStar }, doctorSurvey.Id);
            }
            return Ok();
        }
    }
}
