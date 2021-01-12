using Microsoft.AspNetCore.Mvc;
using MQuince.Core.IdentifiableDTO;
using MQuince.UrgentProcurement.Contracts.DTO;
using MQuince.UrgentProcurement.Contracts.Services;
using MQuince.UrgentProcurement.Services;
using System;
using System.Collections.Generic;

namespace MQuince.Integration.HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentProcurementController : ControllerBase
    {

        ClientScheduledService service;
        private readonly IMedicationsService _medicationsService;

        public UrgentProcurementController([FromServices] IMedicationsService medicationsService)
        {
            this._medicationsService = medicationsService;
            service = new ClientScheduledService();

        }

        [HttpGet]
        public IEnumerable<IdentifiableDTO<MedicationsDTO>> GetAll()
        {
            return _medicationsService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(MedicationsDTO dto)
        {
            try
            {
                _medicationsService.Create(dto);
                return Ok(dto);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("{data}")]
        public IActionResult Update(String data)
        {
            string[] parts = _medicationsService.GetData(data);
            IdentifiableDTO<MedicationsDTO> medications = _medicationsService.GetById(new Guid(parts[0]));
            service.SendUrgentMessage(medications.EntityDTO.Name, medications.EntityDTO.Quantity.ToString());
            _medicationsService.Delete(new Guid(parts[0]));
            try
            {
                _medicationsService.Update(new MedicationsDTO()
                {
                    Name = medications.EntityDTO.Name,
                    Quantity = (medications.EntityDTO.Quantity + Int32.Parse(parts[1]))
                }, medications.Id);
                return Ok(medications.Id);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicationsService.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
