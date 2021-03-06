﻿using Microsoft.AspNetCore.Mvc;
using MQuince.Core.IdentifiableDTO;
using MQuince.Sftp.Constracts.DTO;
using MQuince.Sftp.Constracts.Services;
using System;
using System.Collections.Generic;

namespace MQuince.Integration.HospitalApp.Controllers
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicationsConsumptionService.Delete(id);
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost]
        public IActionResult Add([FromBody] MedicationsConsumptionDTO dto)
        {
            try
            {
                _medicationsConsumptionService.Create(dto);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
