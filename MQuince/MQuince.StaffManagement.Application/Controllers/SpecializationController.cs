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
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }
            try
            {
                return Ok(_specializationService.GetAll());
            }
            catch (NotFoundEntityException)
            {
                return StatusCode(404);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        private bool IsValidAuthenticationRole(string role)
        {
            try
            {
                var Authorization = Request.Headers.TryGetValue("Authorization", out var outToken);

                if (String.IsNullOrEmpty(outToken))
                    return false;

                string userRole = JWTRoleDecoder.DecodeJWTToken(outToken);

                if (userRole.Equals(role))
                    return true;

                return false;
            }
            catch (InvalidJWTTokenException)
            {
                return false;
            }
        }
    }
}
