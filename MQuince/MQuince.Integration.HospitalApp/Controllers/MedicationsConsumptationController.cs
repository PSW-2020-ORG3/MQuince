using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
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
