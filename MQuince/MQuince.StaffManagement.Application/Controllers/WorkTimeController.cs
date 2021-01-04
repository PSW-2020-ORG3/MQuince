using Microsoft.AspNetCore.Mvc;
using MQuince.Scheduler.Contracts.Exceptions;
using MQuince.StafManagement.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.StaffManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTimeController : ControllerBase
    {
        private readonly IWorkTimeService _workTimeService;

        public WorkTimeController([FromServices] IWorkTimeService workTimeService)
        {
            this._workTimeService = workTimeService;
        }

        [HttpGet("GetWorkHours")]
        public IActionResult GetWorkHours(Guid doctorId, DateTime date)
        {
            try
            {
                return Ok(_workTimeService.GetWorkHoursForDoctorForDate(doctorId, date));
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
