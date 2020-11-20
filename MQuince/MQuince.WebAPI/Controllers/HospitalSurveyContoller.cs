using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Communication;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalSurveyContoller : ControllerBase
    {
        private readonly IHospitalSurveyService _hospitalSurveyService;
        public HospitalSurveyContoller([FromServices] IHospitalSurveyService hospitalSurveyService)
        {
            _hospitalSurveyService = hospitalSurveyService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<HospitalSurveyDTO>> GetAll()
        {
            return _hospitalSurveyService.GetAll();
        }

        [HttpPost("Update")]
        public IActionResult Update(List<IdentifiableDTO<HospitalSurveyDTO>> survey)
        {
            foreach (IdentifiableDTO<HospitalSurveyDTO> hospitalSurvey in survey)
            {
                _hospitalSurveyService.Update(new HospitalSurveyDTO() { Question = hospitalSurvey.EntityDTO.Question, OneStar = hospitalSurvey.EntityDTO.OneStar, TwoStar = hospitalSurvey.EntityDTO.TwoStar, ThreeStar = hospitalSurvey.EntityDTO.ThreeStar, FourStar = hospitalSurvey.EntityDTO.FourStar, FiveStar = hospitalSurvey.EntityDTO.FiveStar }, hospitalSurvey.Id);
            }
            return Ok();
        }
    }
}
