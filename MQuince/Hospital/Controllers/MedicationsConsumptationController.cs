using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Services;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsConsumptationController : ControllerBase
    {
        private readonly IMedicationsConsumptionService _medicationsConsumptionService;

        public MedicationsConsumptationController(IMedicationsConsumptionService medicationsConsumptionService)
        {
            this._medicationsConsumptionService = medicationsConsumptionService;
        } 

        [HttpGet]
        public IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetAll()
        {
            return _medicationsConsumptionService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(MedicationsConsumptionDTO dto)
        {
            if(dto.Name.Length<=0)
            {
                return BadRequest();
            }
            _medicationsConsumptionService.Create(dto);
            return Ok(dto);
        }
    }
}
