using Microsoft.AspNetCore.Mvc;
using MQuince.Scheduler.Contracts.DTO;
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
            if (ModelState.IsValid)
            {
                _scheduleEventService.Create(dto);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetStatistics()
        {
            return Ok(_scheduleEventService.GetScheduleStatistics());

        }
    }
}
