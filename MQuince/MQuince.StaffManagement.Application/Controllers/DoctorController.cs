using Microsoft.AspNetCore.Mvc;
using MQuince.StaffManagement.Application.Controllers.Util;
using MQuince.StaffManagement.Contracts.Exceptions;
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
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

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
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

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
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

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

        private bool IsValidAuthenticationRole(string requiredRole)
        {
            try
            {
                Request.Headers.TryGetValue("Authorization", out var outToken);

                if (String.IsNullOrEmpty(outToken))
                    return false;

                string userRole = JWTRoleDecoder.DecodeJWTToken(outToken);

                if (userRole.Equals(requiredRole))
                    return true;

                return false;
            }catch (InvalidJWTTokenException)
            {
                return false;
            }catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }
    }
}
