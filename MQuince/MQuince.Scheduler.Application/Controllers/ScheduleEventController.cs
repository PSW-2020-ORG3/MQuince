using Microsoft.AspNetCore.Mvc;
using MQuince.Scheduler.Application.Controllers.Util;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.Scheduler.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Scheduler.Application.Controllers
{
    [Route("api/ScheduleEvent")]
    [ApiController]
    public class ScheduleEventController : ControllerBase
    {
        private readonly IScheduleEventService _scheduleEventService;

        public ScheduleEventController([FromServices] IScheduleEventService scheduleEventService)
        {
            this._scheduleEventService = scheduleEventService;
        }

        [HttpPost]
        public IActionResult CreateEvent(ScheduleEventDTO dto)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _scheduleEventService.Create(dto);
                }
                return Ok();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            if (!IsValidAuthenticationRole("Admin"))
            {
                return StatusCode(403);
            }

            try
            {
                return Ok(_scheduleEventService.GetScheduleStatistics());
            } catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private bool IsValidAuthenticationRole(string requiredRole)
        {
            try
            {
                var Authorization = Request.Headers.TryGetValue("Authorization", out var outToken);

                if (String.IsNullOrEmpty(outToken))
                    return false;

                string userRole = JWTRoleDecoder.DecodeJWTToken(outToken);

                if (userRole.Equals(requiredRole))
                    return true;

                return false;
            }
            catch (InvalidJWTTokenException)
            {
                return false;
            }
            catch (Exception)
            {
                throw new InternalServerErrorException();
            }
        }
    }
}
