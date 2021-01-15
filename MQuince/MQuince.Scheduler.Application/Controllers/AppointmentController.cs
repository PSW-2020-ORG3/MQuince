using Microsoft.AspNetCore.Mvc;
using MQuince.Scheduler.Application.Controllers.Util;
using MQuince.Scheduler.Contracts.DTO;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.Scheduler.Contracts.Service;
using System;

namespace MQuince.Scheduler.Application.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
        private readonly IAppointmentService _appointmentService;

        public AppointmentController([FromServices] IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult Create(AppointmentDTO dto)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            if (ModelState.IsValid)
            {
                _appointmentService.Create(dto);
            }
            return Ok();
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
                return Ok(_appointmentService.GetAll());
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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            try
            {
                return Ok(_appointmentService.GetById(id));
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

        [HttpGet("GetFreeApp")]
        public IActionResult GetFreeApp(Guid patientId, Guid doctorId, DateTime date)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            try
            {
                return Ok(_appointmentService.GetFreeAppointments(patientId, doctorId, date));
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

        [HttpGet("GetForPatient")]
        public IActionResult GetForPatient(Guid patientId)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            try
            {
                return Ok(_appointmentService.GetForPatient(patientId));
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

        [HttpGet("GetReportForAppointment")]
        public IActionResult GetReportForAppointment(Guid id)
        {/*
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }
            */
            try
            {
                return Ok(_appointmentService.GetReportForAppointment(id));
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

        [HttpPut("CancelAppointment/{appointmentId}")]
        public IActionResult CancelAppointment(Guid appointmentId)
        {
            if (!IsValidAuthenticationRole("Patient"))
            {
                return StatusCode(403);
            }

            try
            {
                bool isCanceled = _appointmentService.CancelAppointment(appointmentId);
                if (isCanceled)
                    return Ok();
                else
                    return BadRequest();
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
