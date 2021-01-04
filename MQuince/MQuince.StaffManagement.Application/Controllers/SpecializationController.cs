using Microsoft.AspNetCore.Mvc;
using MQuince.StafManagement.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.StafManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController([FromServices] ISpecializationService specializationService)
        {
            this._specializationService = specializationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_specializationService.GetAll());
            }
            catch (NotFoundEntityException e)
            {
                return StatusCode(404);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
