using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MQuince.TenderProcurement.Contracts.DTO;
using MQuince.TenderProcurement.Contracts.Exceptions;
using MQuince.TenderProcurement.Contracts.Services;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyOffersController : ControllerBase
    {
        private readonly IPharmacyOffersService _pharmacyOfferssService;

        public PharmacyOffersController([FromServices] IPharmacyOffersService pharmacyOffersService)
        {
            _pharmacyOfferssService = pharmacyOffersService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
           try
            {
                return Ok(_pharmacyOfferssService.GetAll());
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

        [HttpPost]
        public IActionResult Add(PharmacyOffersDTO dto)
        {
            try
            {
                Guid key = _pharmacyOfferssService.Create(dto);
                return Ok(key);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] Guid id, Boolean approve)
        {
            try
            {
                Guid key = _pharmacyOfferssService.sendOffers(id,approve);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
