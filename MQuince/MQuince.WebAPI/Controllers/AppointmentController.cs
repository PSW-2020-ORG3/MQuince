using Microsoft.AspNetCore.Mvc;
using MQuince.Entities.Appointment;
using MQuince.Enums;
using MQuince.Services.Contracts.DTO.Appointment;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.WebAPI.Controllers 
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
            TreatmentType treatmentType = TreatmentType.Examination;

            try
            {
                return Ok(_appointmentService.GetFreeAppointments(patientId, doctorId, date, treatmentType));
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

        [HttpPost("Update")]
        public IActionResult Update(Appointment appointment)
        {
            _appointmentService.Update(new AppointmentDTO() { StartDateTime = appointment.StartDateTime, EndDateTime = appointment.EndDateTime, Type = appointment.Type, DoctorId = appointment.DoctorId, PatientId = appointment.PatientId, IsCanceled = appointment.IsCanceled }, appointment.Id);
            return Ok();
        }

        [HttpPut("canceledAppointment/{IdAppointment}")]
        public IActionResult CancelAppointment(Guid IdAppointment)
        {
            try
            {
                return Ok(_appointmentService.CancelAppointment(IdAppointment, DateTime.Now));
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
