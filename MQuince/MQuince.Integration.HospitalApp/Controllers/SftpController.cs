using Microsoft.AspNetCore.Mvc;
using MQuince.Sftp.Constracts.DTO;
using MQuince.Sftp.Constracts.Services;
using MQuince.Sftp.Services;
using System;

namespace MQuince.Integration.HospitalApp.Controllers
{
	[Route("api/sftpController")]
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

		[HttpPost]
		public IActionResult Post(DateDTO dto)
		{
			_medicationsConsumptionService.GeneratePdf(dto);

			if (_sftpService.SendFile("Report_in_" + dto.To + "_" + dto.From + ".pdf"))
				return Ok();
			else
				return BadRequest();
		}


		[HttpPost("rebexCall")]
		public IActionResult SaveFile([FromForm] String name)
		{

			if (_sftpService.SaveFile(name + ".txt"))
				return Ok();
			else
				return BadRequest();


		}
	}
}
