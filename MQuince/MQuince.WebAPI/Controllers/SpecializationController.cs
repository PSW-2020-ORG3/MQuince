using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController([FromServices] ISpecializationService specializationService)
        {
            this._specializationService = specializationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
