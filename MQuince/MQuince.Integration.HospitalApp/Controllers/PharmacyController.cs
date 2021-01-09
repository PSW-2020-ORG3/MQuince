using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MQuince.Core.IdentifiableDTO;
using MQuince.Pharmacy.Contracts.DTO;
using MQuince.Pharmacy.Contracts.Services;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController([FromServices] IPharmacyService pharmacyService)
        {
            this._pharmacyService = pharmacyService;
        }

        [HttpGet]
        public IEnumerable<IdentifiableDTO<PharmacyDTO>> GetAll()
        {
            return _pharmacyService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(PharmacyDTO dto)
        {
            try
            {
                _pharmacyService.Create(dto);
                return Ok(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
    }
}
