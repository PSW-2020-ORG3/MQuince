using Microsoft.AspNetCore.Mvc;
using MQuince.ActionAndBenefits.Constracts.Exceptions;
using MQuince.ActionAndBenefits.Contracts.DTO;
using MQuince.ActionAndBenefits.Contracts.Service;
using MQuince.Core.IdentifiableDTO;
using System;

namespace MQuince.Integration.HospitalApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActionAndBenefitsController : ControllerBase
	{
		private readonly IActionAndBenefitsService _actionAndBenefitsService;

		public ActionAndBenefitsController([FromServices] IActionAndBenefitsService actionAndBenefitsService)
		{
			_actionAndBenefitsService = actionAndBenefitsService;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				return Ok(_actionAndBenefitsService.GetAll());
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
		public IActionResult Add(ActionAndBenefitsDTO dto)
		{
			try
			{
				return Ok(_actionAndBenefitsService.Create(dto));

			}
			catch (Exception e)
			{
				return BadRequest();
			}


		}
		[HttpPut("{id}")]
		public IActionResult Update(Guid id)
		{
			
			IdentifiableDTO<ActionAndBenefitsDTO> actionAndBenefits = _actionAndBenefitsService.GetById(id);
			try
			{
				_actionAndBenefitsService.Update(new ActionAndBenefitsDTO()
				{
					IsApproved = true,
					PharmacyName = actionAndBenefits.EntityDTO.PharmacyName,
					ActionName = actionAndBenefits.EntityDTO.ActionName,
					BeginDate = actionAndBenefits.EntityDTO.BeginDate,
					EndDate = actionAndBenefits.EntityDTO.EndDate,
					OldCost = actionAndBenefits.EntityDTO.OldCost,
					NewCost = actionAndBenefits.EntityDTO.NewCost
				
				}, actionAndBenefits.Id,true);

				return Ok(actionAndBenefits.Id);
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
				_actionAndBenefitsService.Delete(id);
				return Ok(id);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

		}



	}


}
