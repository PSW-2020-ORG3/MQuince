using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionAndBenefitsController : ControllerBase
    {
        private readonly IActionAndBenefitsService _actionAndBenefitsService;

        public ActionAndBenefitsController([FromServices] IActionAndBenefitsService actionAndBenefitsService)
        {
            _actionAndBenefitsService = actionAndBenefitsService;
        }
        [HttpGet]
        public IEnumerable<IdentifiableDTO<ActionAndBenefitsDTO>> GetAll()
        {
            return _actionAndBenefitsService.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody] ActionAndBenefitsDTO dto)
        {
            try
            {
                _actionAndBenefitsService.Create(dto);

                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
