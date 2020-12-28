using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            this._tenderService = tenderService;
        }

        [HttpGet]
        public IEnumerable<IdentifiableDTO<TenderDTO>> GetAll()
        {
            return _tenderService.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TenderDTO dto)
        {
            try
            {
                _tenderService.Create(dto);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
