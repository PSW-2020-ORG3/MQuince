using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MQuince.Integration.Entities;
using MQuince.Integration.Repository.MySQL.PersistenceEntities;
using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using MQuince.Integration.Services.Constracts.Interfaces;
using MQuince.Services.Contracts.Exceptions;

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
            catch(Exception e)
            {
                return BadRequest();
            }
                                         

        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id)
        {
            IdentifiableDTO<ActionAndBenefitsDTO> actionAndBenefits = _actionAndBenefitsService.GetByID(id);            
            try
              {
                  _actionAndBenefitsService.Update(new ActionAndBenefitsDTO()
                  {
                      PharmacyName = actionAndBenefits.EntityDTO.PharmacyName,
                      ActionName = actionAndBenefits.EntityDTO.ActionName,
                      BeginDate = actionAndBenefits.EntityDTO.BeginDate,
                      EndDate = actionAndBenefits.EntityDTO.EndDate,
                      OldCost = actionAndBenefits.EntityDTO.OldCost,
                      NewCost = actionAndBenefits.EntityDTO.NewCost
                  }, actionAndBenefits.Key, true);

                  return Ok(actionAndBenefits.Key);
              }
              catch(Exception e)
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
             }catch(Exception e)
             {
                 return BadRequest(e.Message);
             }
            
        }


        
    }
    
       
}
