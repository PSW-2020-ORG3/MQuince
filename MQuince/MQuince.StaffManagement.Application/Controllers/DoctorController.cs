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
            }catch(NotFoundEntityException)
            {
                return StatusCode(404);
            }catch(InternalServerErrorException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_doctorService.GetAll());
            }
            catch (NotFoundEntityException)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException)
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
            }catch (NotFoundEntityException)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException)
            {
                return StatusCode(500);
            }
        }
    }
}
