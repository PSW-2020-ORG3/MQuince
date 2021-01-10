using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.Exceptions;
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
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_tenderService.GetAll());
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

        [HttpPut]
        public IActionResult Update([FromQuery] Guid id,Boolean opened)
        {
            IdentifiableDTO<TenderDTO> tender = _tenderService.GetById(id);

            try
            {
                _tenderService.Update(new TenderDTO()
                {
                    Name= tender.EntityDTO.Name,
                    Descritpion=tender.EntityDTO.Descritpion,
                    EndDate=tender.EntityDTO.EndDate,
                    StartDate=tender.EntityDTO.StartDate,
                    FormLink=tender.EntityDTO.FormLink,
                    Opened=opened
                },tender.Key);
                _tenderService.Delete(id);
                return Ok(tender.Key);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
