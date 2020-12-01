using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Interfaces;
using MQuince.IntegrationMySQL.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Controllers
{
    [Route("api/mojKontroler")]
    [ApiController]

       public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyServices _pharmacyService;

        public PharmacyController([FromServices] IPharmacyServices pharmacyService)
        {
            this._pharmacyService = pharmacyService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<IdentifiableDTO<PharmacyDTO>> GetAll()
        {
            return _pharmacyService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(PharmacyDTO dto)
        {
            if (dto.Name.Length <= 0)
            {
                return BadRequest();
            }
            _pharmacyService.Create(dto);
            return Ok(dto);
        }

        
    }
}
