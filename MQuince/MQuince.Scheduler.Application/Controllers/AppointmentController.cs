using Microsoft.AspNetCore.Mvc;
using MQuince.Scheduler.Application.Contracts;
using MQuince.Scheduler.Application.Contracts.Exceptions;
using MQuince.Scheduler.Application.DTO;
using MQuince.Scheduler.Domain;
using MQuince.Scheduler.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (ModelState.IsValid)
            {
                _appointmentService.Create(dto);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_appointmentService.GetAll());
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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_appointmentService.GetById(id));
            }
            catch (NotFoundEntityException e)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetFreeApp")]
        public IActionResult GetFreeApp(Guid patientId, Guid doctorId, DateTime date)
        {

            try
            {
                return Ok(_appointmentService.GetFreeAppointments(patientId, doctorId, date));
            }
            catch (NotFoundEntityException e)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetForPatient")]
        public IActionResult GetForPatient(Guid patientId)
        {
            try
            {
                return Ok(_appointmentService.GetForPatient(patientId));
            }
            catch (NotFoundEntityException e)
            {
                return StatusCode(404);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("Update/{appointmentId}")]
        public IActionResult Update(AppointmentDTO appointment, Guid appointmentId)
        {
            _appointmentService.Update(appointment, appointmentId);
            return Ok();
        }

        [HttpPut("CancelAppointment/{appointmentId}")]
        public IActionResult CancelAppointment(Guid appointmentId)
        {
            try
            {
                bool isCanceled = _appointmentService.CancelAppointment(appointmentId);
                if (isCanceled)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (NotFoundEntityException e)
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
