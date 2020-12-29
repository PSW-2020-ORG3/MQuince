using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Entities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;

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
        public IEnumerable<IdentifiableDTO<ActionAndBenefitsDTO>> GetAll()
        {
            return _actionAndBenefitsService.GetAll();
        }

        [HttpPost]
        public IActionResult Add(ActionAndBenefitsDTO dto)
        {
            try
            {
                _actionAndBenefitsService.Create(dto);
                return Ok(dto);

            }
            catch(Exception e)
            {
                return BadRequest(dto);
            }
                                         

        }
        [HttpPut]
        public IActionResult Update(ActionsAndBenefits action)
        {
            try
            {
                _actionAndBenefitsService.Update(new ActionAndBenefitsDTO()
                {
                    PharmacyName = action.PharmacyName,
                    ActionName = action.ActionName,
                    BeginDate = action.BeginDate,
                    EndDate = action.EndDate,
                    OldCost = action.OldCost,
                    NewCost = action.NewCost
                }, action.IDAction, action.IsApproved);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
             
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(ActionsAndBenefits action)
        {

            try
            {
                _actionAndBenefitsService.Delete(action.IDAction);
                return Ok("Successefully deleted action and benefits!");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


        
    }
    
       
}
