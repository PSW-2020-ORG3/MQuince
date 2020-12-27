using Microsoft.AspNetCore.Mvc;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.Exceptions;
using MQuince.Services.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController([FromServices] IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                var response = _userService.Login(loginDTO);

                return Ok(response);
            }
            catch (NotFoundEntityException e)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }catch(InternalServerErrorException e)
            {
                return StatusCode(500);
            }


        }
    }
}
