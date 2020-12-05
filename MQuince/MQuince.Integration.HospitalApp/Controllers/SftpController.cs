using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;


using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Implementation;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {

        private readonly ISftpService _sftpService;
        private readonly IMedicationsConsumptionService _medicationsConsumptionService;

        public SftpController(IMedicationsConsumptionService medicationsConsumptionService)
        {
            this._sftpService = new SftpService();
            this._medicationsConsumptionService = medicationsConsumptionService;

        }

        [HttpGet]
        public IActionResult Get(DateDTO dto)
        {
            _medicationsConsumptionService.GeneratePdf(dto);

            if (_sftpService.SendFile("izvjestaj.pdf"))
                return Ok();
            else
                return BadRequest();
        }
            
    }
}
