using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController([FromServices] IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_doctorService.GetById(id));
            }catch(NotFoundEntityException e)
            {
                return StatusCode(404);
            }catch(InternalServerErrorException e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("specialization/{id}")]
        public IActionResult GetSpec(Guid id)
        {
            try
            {
                return Ok(_doctorService.GetDoctorsPerSpecialization(id));
            }catch (NotFoundEntityException e)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500);
            }
        }
    }
}
