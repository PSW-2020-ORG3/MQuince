using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;

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
            _pharmacyService.Create(dto);
            return Ok(dto);
        }
    }
}
